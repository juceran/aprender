using System;
using System.Globalization;
using aprender.Entities;
using aprender.Entities.enums;

namespace aprender
{
    class Program
    {
        static void Main(string[] args)
        {
            Aula121(); //exercicio resolvido
            //Aula118(); //aula118 à aula120
        }

        private static void Aula121()
        {
            Comment c1 = new Comment("Have a nice trip");
            Comment c2 = new Comment("Wow that's awesome");
            Post p1 = new Post(
                DateTime.Parse("16/01/2019 16:01:44"),
                "Traveling to New Zealand",
                "I'm going to visit this wonderful country!",
                12
                );

            p1.AddComment(c1);
            p1.AddComment(c2);

            Comment c3 = new Comment("Good night");
            Comment c4 = new Comment("May the force to be with you");

            Post p2 = new Post(
                  DateTime.Parse("16/01/2019 16:07:21"),
                "Good night guys",
                "See you tomorrow",
                5
                );

            p2.AddComment(c3);
            p2.AddComment(c4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);

        }

        private static void Aula118()
        {
            Console.Write("Enter Department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter Worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i=1; i<= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY) ");
            string monthAndYear = Console.ReadLine();
            int year = int.Parse(monthAndYear.Substring(3));
            int month = int.Parse(monthAndYear.Substring(0,2));
           
            Console.WriteLine("Name : " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
