using System;
using Microsoft.EntityFrameworkCore;

namespace ConsoleCongratulator
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class AppContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CongratulatorAppdb;Trusted_connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person[]
                {
                    new Person { Id = 1, Name = "Steven Ball", BirthDate = new DateTime(2021,07,01)},
                    new Person { Id = 2, Name = "Robert Lambert", BirthDate = new DateTime(2021,07,02)},
                    new Person { Id = 3, Name = "Peter Hardy", BirthDate = new DateTime(2021,07,03)},
                    new Person { Id = 4, Name = "Brian Gaines", BirthDate = new DateTime(2021,07,04)},
                    new Person { Id = 5, Name = "Harry Hines", BirthDate = new DateTime(2021,07,05)},
                    new Person { Id = 6, Name = "William Hoges", BirthDate = new DateTime(2021,07,06)},
                    new Person { Id = 7, Name = "Morgan Woods", BirthDate = new DateTime(2021,07,07)},
                    new Person { Id = 8, Name = "Horace Lyons", BirthDate = new DateTime(2021,07,08)},
                    new Person { Id = 9, Name = "Gertrude Tate", BirthDate = new DateTime(2021,07,09)},
                    new Person { Id = 10, Name = "Linda Holland", BirthDate = new DateTime(2021,07,10)},
                    new Person { Id = 11, Name = "Петрович", BirthDate = new DateTime(2021,07,11)},
                    new Person { Id = 12, Name = "Georgia Bridges", BirthDate = new DateTime(2021,07,12)},
                    new Person { Id = 13, Name = "Ann Lee", BirthDate = new DateTime(2021,07,01)},
                    new Person { Id = 14, Name = "Meagan Simpson", BirthDate = new DateTime(2021,07,13)},
                    new Person { Id = 15, Name = "Boris P.", BirthDate = new DateTime(2021,07,14)},
                    new Person { Id = 16, Name = "Madlyn Lamb", BirthDate = new DateTime(2021,07,15)},
                    new Person { Id = 17, Name = "Julia Adams", BirthDate = new DateTime(2021,07,16)},
                    new Person { Id = 18, Name = "Jimmy Carter", BirthDate = new DateTime(2021,07,17)},
                    new Person { Id = 19, Name = "Stephen Turner", BirthDate = new DateTime(2021,07,18)},
                    new Person { Id = 20, Name = "Patricia Cooper", BirthDate = new DateTime(2021,07,19)},
                    new Person { Id = 21, Name = "Danny Andrews", BirthDate = new DateTime(2021,07,20)},
                    new Person { Id = 22, Name = "Shawn Murray", BirthDate = new DateTime(2021,07,21)},
                    new Person { Id = 23, Name = "Marie McGee", BirthDate = new DateTime(2021,07,22)},
                    new Person { Id = 24, Name = "Tom Rose", BirthDate = new DateTime(2021,07,23)},
                    new Person { Id = 25, Name = "Douglas Hudson", BirthDate = new DateTime(2021,07,24)},
                    new Person { Id = 26, Name = "Janice Morrison", BirthDate = new DateTime(2021,07,25)},
                    new Person { Id = 27, Name = "Mary Lewis", BirthDate = new DateTime(2021,07,26)},
                    new Person { Id = 28, Name = "Karen Vega", BirthDate = new DateTime(2021,07,27)},
                    new Person { Id = 29, Name = "Susan Williams", BirthDate = new DateTime(2021,07,28)},
                    new Person { Id = 30, Name = "Daniel Howard", BirthDate = new DateTime(2021,07,29)},
                    new Person { Id = 31, Name = "Barbara Vaughn", BirthDate = new DateTime(2021,07,30)},
                    new Person { Id = 32, Name = "Robert Morris", BirthDate = new DateTime(2021,08,01)},
                    new Person { Id = 33, Name = "Amanda Romero", BirthDate = new DateTime(2021,08,02)},
                    new Person { Id = 34, Name = "Sharon Johnson", BirthDate = new DateTime(2021,08,03)},
                    new Person { Id = 35, Name = "Leslie Sims", BirthDate = new DateTime(2021,08,04)},
                    new Person { Id = 36, Name = "Bobbie Coleman", BirthDate = new DateTime(2021,08,05)},
                    new Person { Id = 37, Name = "Deborah Lawrence", BirthDate = new DateTime(2021,08,06)},
                    new Person { Id = 38, Name = "Doris Elliott", BirthDate = new DateTime(2021,08,07)},
                    new Person { Id = 39, Name = "Annie Byrd", BirthDate = new DateTime(2021,08,08)},
                    new Person { Id = 40, Name = "Boris Britva", BirthDate = new DateTime(2021,08,09)},
                    new Person { Id = 41, Name = "Marilyn Williams", BirthDate = new DateTime(2021,08,10)},
                    new Person { Id = 42, Name = "Francisco Bradley", BirthDate = new DateTime(2021,08,11)},
                    new Person { Id = 43, Name = "Virginia Obrien", BirthDate = new DateTime(2021,08,12)},
                    new Person { Id = 44, Name = "Joyce Poole", BirthDate = new DateTime(2021,08,13)},
                    new Person { Id = 45, Name = "Donald Schmidt", BirthDate = new DateTime(2021,08,14)},
                    new Person { Id = 46, Name = "Joyce Poole", BirthDate = new DateTime(2021,08,15)},
                    new Person { Id = 47, Name = "Donald Schmidt", BirthDate = new DateTime(2021,08,16)},
                    new Person { Id = 48, Name = "Angela Rodriguez", BirthDate = new DateTime(2021,08,17)},
                    new Person { Id = 49, Name = "Robert Wilkerson", BirthDate = new DateTime(2021,08,18)},
                    new Person { Id = 50, Name = "Raymond Carr", BirthDate = new DateTime(2021,08,19)},
                    new Person { Id = 51, Name = "Ronald Austin", BirthDate = new DateTime(2021,08,20)},
                    new Person { Id = 52, Name = "Rhonda Pierce", BirthDate = new DateTime(2021,08,21)}
                });
        }
    }
}
