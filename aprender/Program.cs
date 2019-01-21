using System;
using System.Collections.Generic;
using System.Globalization;
using aprender.Entities;
using aprender.Entities.enums;




namespace aprender
{
    class Program
    {
        static void Main(string[] args)
        {
            Aula130(); //sobreposição
            //Aula125(); // Herança e Polimorfismo, continua Aula 126
            //Aula122(); 
            //Aula121(); //exercicio resolvido
            //Aula118(); //aula118 à aula120
        }

        private static void Aula130()
        {
            List<Employee> List = new List<Employee>();
            Console.Write("enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Employee #{i} data: ");
                Console.Write("Outsourced (y/n)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hour = int.Parse(Console.ReadLine());
                Console.Write("Value per Hours: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'Y' || ch == 'y')
                {
                    Console.Write("Adittional Charge: ");
                    double adittionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    List.Add(new OutsourcedEmployee(name, hour, valuePerHour, adittionalCharge));
                }
                else
                {
                    List.Add(new Employee(name, hour, valuePerHour));
                }
            }
            Console.WriteLine();
            Console.Write("Payment: ");
            foreach (Employee emp in List)
            {
                Console.WriteLine("Name: " + emp.Name + " - $ " + emp.Payment().ToString("f2", CultureInfo.InvariantCulture));
            }
        }

        private static void Aula125()
        {
            //BusinessAccount Account = new BusinessAccount(18691, "Juceran", 3641.57, 500);
            //Console.WriteLine(Account.Balance);
            //Account.Balance = 10; // não funciona pois esta protected, só altera nas subclasses que herdam

            Account acc = new Account(186916, "Juceran", 0.0);
            BusinessAccount bacc = new BusinessAccount(31584, "CetaSistemas", 3641.57, 500);

            //upcasting
            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(001, "Alex", 8000, 500);
            Account acc3 = new SavingsAccount(1003, "Sofia", 8000, 0.01);

            //aula 127 
            acc2.Withdraw(5);
            acc3.Withdraw(5);

            Console.WriteLine(acc2.Balance);
            Console.WriteLine(acc3.Balance);

            //downcasting
            BusinessAccount acc4 = (BusinessAccount)acc2;
            acc4.Loan(102);
            Console.WriteLine(acc4.Balance);

            /*  o downcasting não da erro, na compilação mas da ao executar
            //  acc3 é um SavingsAccount, tem que testar, porém essse metodo não é SEGURO
            */
            //BusinessAccount acc5 = (BusinessAccount)acc3;
            if(acc3 is BusinessAccount)
            {
                BusinessAccount acc5 = (BusinessAccount)acc3;
                acc5.Loan(200.00);
                Console.WriteLine("lOAN!");
            }

            if(acc3 is SavingsAccount)
            {
                SavingsAccount acc5 = (SavingsAccount)acc3;
                SavingsAccount acc6 = acc3 as SavingsAccount; // outra forma de fazer o casting
                acc5.UpdateBalance();
                Console.WriteLine("update! ");
            }
        }

        private static void Aula122()
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("e-mail: ");
            string email = Console.ReadLine();
            Console.Write("Birth date: (dd/mm/yyyy) ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);

            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
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
