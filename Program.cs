using System;

namespace CongratulatorAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Congratulator congratulator = new Congratulator();

            congratulator.ShowDataOfPastFiveDays();
            Console.WriteLine(new string('=',60));
            congratulator.ShowDataOfNextFiveDays();

            while (true)
            {
                Console.WriteLine(new string('=', 100));
                Console.WriteLine("Выберите действие");
                Console.Write("1.Показать все записи (сортировка по Id)\t");
                Console.WriteLine("2.Сортировка по количеству дней до дня рождения");
                Console.Write("3.Сортировка записей по имени\t\t\t");
                Console.WriteLine("4.Добавить запись");
                Console.Write("5.Редактировать запись\t\t\t\t");
                Console.WriteLine("6.Удалить запись");

                String action = Console.ReadLine();

                try
                {
                    switch (action)
                    {
                        case "1":
                            congratulator.ShowAllDataSortedById();
                            break;
                        case "2":
                            congratulator.ShowAllDataSortedByDaysLeft();
                            break;
                        case "3":
                            congratulator.ShowDataSortedByAlphabet();
                            break;
                        case "4":
                            congratulator.AddNewPerson();
                            break;
                        case "5":
                            congratulator.RedactPersonData();
                            break;
                        case "6":
                            congratulator.DeletePerson();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Вы выбрали несуществующее действие, повторите выбор");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ошибка, повторите действия");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}

