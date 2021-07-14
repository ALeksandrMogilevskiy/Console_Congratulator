using System;
using System.Linq;

namespace CongratulatorAPP
{
    public class Congratulator
    {
        AppContext db = new AppContext();
        public void ShowDataOfPastFiveDays()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Прошедшие дни рождения за последние 5 дней:");
            var fivePastDaysData = db.People.Where(p => DateTime.Now.DayOfYear - p.BirthDate.DayOfYear >= 1 &
                                                        DateTime.Now.DayOfYear - p.BirthDate.DayOfYear < 6);
            foreach (var p in fivePastDaysData)
            {
                Console.WriteLine($"{p.Id}.{p.Name,-20}\t{p.BirthDate.ToString("M")}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void ShowDataOfNextFiveDays()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Дни рождения в ближайшие 5 дней:");
            var fiveNextDaysData = db.People.Where(p => p.BirthDate.DayOfYear - DateTime.Now.DayOfYear > 0 &
                                                        p.BirthDate.DayOfYear - DateTime.Now.DayOfYear < 6);
            var birthdayToday = db.People.Where(p => DateTime.Now.DayOfYear - p.BirthDate.DayOfYear == 0);
                foreach (var p in birthdayToday)
                {
                    Console.Write($"{p.Id}.{p.Name,-20}\t{p.BirthDate.ToString("M")}");
                    Console.WriteLine($"\t День рождения сегодня, не забудьте поздравить!");
                }
                foreach (var p in fiveNextDaysData)
                {
                    Console.WriteLine($"{p.Id}.{p.Name,-20}\t{p.BirthDate.ToString("M")}");
                }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void ShowAllDataSortedById()
        {
            var allDatabyId = db.People;
            Console.WriteLine("Все записи:");
            foreach (var p in allDatabyId)
            {
                Console.WriteLine($"{p.Id}.{p.Name,-20}\t{p.BirthDate.ToString("M")}");
            }   
        }

        public void ShowAllDataSortedByDaysLeft()
        {
            int numberOfdaysInCurrentYear;
            if (DateTime.Now.Year % 4 == 0)
                numberOfdaysInCurrentYear = 366;
            else 
                numberOfdaysInCurrentYear = 365;

            var dataSortedByDaysLeft = db.People.OrderBy(p => p.BirthDate.DayOfYear >= DateTime.Today.DayOfYear ?
                                                        p.BirthDate.DayOfYear - DateTime.Today.DayOfYear :
                                                        p.BirthDate.DayOfYear - DateTime.Now.DayOfYear + numberOfdaysInCurrentYear);
            foreach (var p in dataSortedByDaysLeft)
            {
                if (DateTime.Now.DayOfYear > p.BirthDate.DayOfYear)
                {
                    Console.WriteLine($"{p.Id}.{p.Name,-20}\t{p.BirthDate.ToString("M"),-16}" +
                    $"\t Осталось дней до дня рождения:{numberOfdaysInCurrentYear - (DateTime.Now.DayOfYear - p.BirthDate.DayOfYear)}");
                }
                else if (DateTime.Now.DayOfYear <= p.BirthDate.DayOfYear)
                {
                    Console.WriteLine($"{p.Id}.{p.Name,-20}\t{p.BirthDate.ToString("M"),-16}" +
                    $"\t Осталось дней до дня рождения:{p.BirthDate.DayOfYear - DateTime.Now.DayOfYear}");
                }
            } 
        }

        public void ShowDataSortedByAlphabet()
        {
            var allDatabyAlphabet = db.People.OrderBy(p => p.Name);
            foreach (var p in allDatabyAlphabet)
            {
                Console.WriteLine($"{p.Id}.{p.Name,-20}\t{p.BirthDate.ToString("M")}");
            }
        }

        public void AddNewPerson()
        {
            Person newPersonAdded = new Person();

            Console.WriteLine("Введите имя для новой записи");
            newPersonAdded.Name = Console.ReadLine();

            Console.WriteLine("Введите день рождения для новой записи в формате дд.мм");
            newPersonAdded.BirthDate = Convert.ToDateTime(Console.ReadLine());

            db.Add(newPersonAdded);
            db.SaveChanges();

            Console.WriteLine("Новая запись добавлена");
            Console.WriteLine($"Id: {newPersonAdded.Id}\tИмя: {newPersonAdded.Name}" +
                     $"\tДень рождения: {newPersonAdded.BirthDate.ToString("M")}");
        }

        public void RedactPersonData()
        {
            int idOfRedactedPerson;
            Console.WriteLine("Введите Id записи, которую нужно редактировать");
            idOfRedactedPerson = Convert.ToInt32(Console.ReadLine());

            Person newPerson = new Person();

            Console.WriteLine("Введите новое имя для записи");
            newPerson.Name = Console.ReadLine();

            Console.WriteLine("Введите день рождения для новой записи в формате дд.мм");
            newPerson.BirthDate = Convert.ToDateTime(Console.ReadLine());

            Person redactedPerson = db.People.First(p => p.Id == idOfRedactedPerson);

            redactedPerson.Name = newPerson.Name;
            redactedPerson.BirthDate = newPerson.BirthDate;
            db.SaveChanges();
            Console.WriteLine($"Данные успешно изменены\nId: {redactedPerson.Id}\tИмя: {redactedPerson.Name}\tДень рождения:"+
                                                                                $" {redactedPerson.BirthDate.ToString("M")}");
        }

        public void DeletePerson()
        {
            int idOfDeletedPerson;
            Console.WriteLine("Введите Id записи, которую нужно удалить");
            idOfDeletedPerson = Convert.ToInt32(Console.ReadLine());

            Person deletedPerson = db.People.First(p => p.Id == idOfDeletedPerson);
            db.Remove(deletedPerson);
            db.SaveChanges();
            Console.WriteLine($"Запись {idOfDeletedPerson}.{deletedPerson.Name} удалена.");
        }
    }
}
