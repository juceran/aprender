using System;
using System.Collections.Generic;
using System.Globalization;
using aprender.Entities.Exceptions;
using aprender.Entities.enums;
using System.IO;




namespace aprender
{
    class Program
    {
        static void Main(string[] args)
        {
            Aula196(); //exercicio de fixação
            //Aula194(); //exercicio anterior com INTERFACES
            //Aula191(); //exercicio resolvido sem usar interfaces
            //Aula189(); //exercicio de fixação
            //Aula145(); //exercicio de fixação exceptions
            //Aula142(); //exercicio resolvido
            //Aula140(); //exception
            //Aula136(); // Exercicio Proposto
            //Aula135(); //class e method => abstract
            //Aula132(); // exercicio proposto
            //Aula130(); //sobreposição
            //Aula125(); // Herança e Polimorfismo, continua Aula 126
            //Aula122(); 
            //Aula121(); //exercicio resolvido
            //Aula118(); //aula118 à aula120
        }

        private static void Aula196()
        {
            Console.WriteLine("Enter contract data:");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Entities.Aula196Class.Contract myContract = new Entities.Aula196Class.Contract(contractNumber, contractDate, contractValue);

            Entities.Aula196Class.ContractService contractService = new Entities.Aula196Class.ContractService(new Entities.Aula196Class.PaypalService());
            contractService.ProcessContract(myContract, months);
            foreach (Entities.Aula196Class.Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }
            Console.ReadLine();
        }

        private static void Aula194()
        {
            Console.WriteLine("Dados do aluguel do Veículo");
            Console.Write("Modelo do Veículo: ");
            string modelo = Console.ReadLine();

            Console.Write("UF da locação: ");
            string uf = Console.ReadLine();

            Console.Write("Saida (dd/MM/yyy hh:mm)");
            DateTime saida = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Retorno (dd/MM/yyy hh:mm)");
            DateTime retorno = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Entities.Aula194Class.Locacao locacao = new Entities.Aula194Class.Locacao(saida, retorno, new Entities.Aula194Class.Veiculo( modelo));
            Console.Write("Preço por hora: ");
            double hora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Preço por dia: ");
            double dia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Entities.Aula194Class.LocacaoServico locacaoServico = new Entities.Aula194Class.LocacaoServico(hora, dia, new Entities.Aula194Class.AlagoasTaxaServico());
            locacaoServico.ProcessoImposto(locacao);

            Console.WriteLine("Resumo");
            Console.WriteLine(locacao.Imposto);
            Console.ReadLine();
        }

        private static void Aula191()
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car Model: ");
            string model = Console.ReadLine();

            Console.Write("Pickup (dd/MM/yyy hh:mm)");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Return (dd/MM/yyy hh:mm)");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Entities.Aula191Class.CarRental carRental = new Entities.Aula191Class.CarRental(start, finish, new Entities.Aula191Class.Vehicle(model));

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Entities.Aula191Class.RentalService rentalService = new Entities.Aula191Class.RentalService(hour, day);
            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE");
            Console.WriteLine(carRental.Invoice);
            Console.ReadLine();
        }

        private static void Aula189()
        {
            //Console.Write("Enter file full path: ");
            string sourceFilePath = @"z:\desenvolvimento\aprender\arquivos\189_arquivo.csv"; //Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);
                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);
                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Entities.Aula189Class.Product prod = new Entities.Aula189Class.Product(name, price, quantity);

                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro");
                Console.WriteLine( e.Message );
            }
        }

        private static void Aula145()
        {
            try
            {
                
                Console.WriteLine("Enter account data: ");
                Console.Write("number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial Balance: ");
                double initialBalance = double.Parse(Console.ReadLine());
                Console.Write("Enter withdraw limit: ");
                double limit = double.Parse(Console.ReadLine());

                aprender.Entities.Aula145Class.Account account = new Entities.Aula145Class.Account(number, holder, initialBalance, limit);

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine());

                account.WithDraw(amount);

                Console.WriteLine();
                Console.WriteLine("New Balance: " + account.Balance);
                Console.ReadLine();

            }
            catch(DomainException e)
            {
                Console.WriteLine("Operação bloqueada " + e.Message);
            }
            catch(Exception e )
            {
                Console.WriteLine("erro" + e.Message);
            }
            Console.ReadLine();
        }

        private static void Aula142()
        {
            try
            {
                Console.Write("Room number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("check-in date (dd/mm/yyyy)");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("check-out date (dd/mm/yyyy)");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                aprender.Entities.Aula142Class.Reservation reservation = new Entities.Aula142Class.Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);

                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                reservation.Updatedates(checkIn, checkOut);

                Console.WriteLine("Reservation: " + reservation);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error in format: " + e.Message);
            }
            catch (DomainException e)
            {
                Console.WriteLine("Error in reservation: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }

        private static void Aula140()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(@"Z:\temp\data.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            try
            {
                Console.Write("entre com o dividendo: ");
                int n1 = int.Parse(Console.ReadLine());
                Console.Write("entre com o divisor: ");
                int n2 = int.Parse(Console.ReadLine());

                Console.Write("resultado: ");
                int result = n1 / n2;
                Console.WriteLine(result);
                Console.ReadLine();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Erro! " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error1 " + e.Message);
            }
        }

        private static void Aula136()
        {
            List<aprender.Entities.Aula136Class.People> list = new List<Entities.Aula136Class.People>();

            Console.Write("enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"tax payer #{i}: ");
                Console.Write("Individual or company? (i/c)");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: ");
                double anualincome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthexpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new aprender.Entities.Aula136Class.Individual(name, anualincome, healthexpenditures));
                }
                else
                {
                    Console.Write("Employees: ");
                    int employee = int.Parse(Console.ReadLine());
                    list.Add(new aprender.Entities.Aula136Class.Company(name, anualincome, employee));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            double sum = 0.0;
            foreach (aprender.Entities.Aula136Class.People item in list)
            {
                Console.WriteLine(
                    item.Name
                    + ": $ "
                    + item.TaxesPaid().ToString("f2", CultureInfo.InvariantCulture)
                    );
                sum += item.TaxesPaid();
            }

            Console.WriteLine();
            Console.WriteLine("total Taxes: " + sum.ToString("f2", CultureInfo.InvariantCulture));
            Console.ReadLine();
        }

        private static void Aula135()
        {
            List<aprender.Entities.Aula135Class.Shape> list = new List<Entities.Aula135Class.Shape>();

            Console.Write("Enter the number of sahpes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Shape #{i} data: ");
                Console.Write("Rectangle or circle (r/c) ?");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Color (Black/Blue/Red): ");
                Color color = Enum.Parse<Color>(Console.ReadLine());

                if (ch == 'r')
                {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new aprender.Entities.Aula135Class.Rectangle(width, height, color));
                }
                else
                {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new aprender.Entities.Aula135Class.Circle(radius, color));
                }
            }

            Console.WriteLine("----------------");
            Console.ReadLine();
            Console.WriteLine("Shape areas:");
            foreach (aprender.Entities.Aula135Class.Shape shape in list)
            {
                Console.WriteLine("Area: " + shape.Area().ToString("f2", CultureInfo.InvariantCulture));
            }
            Console.ReadLine();
        }

        private static void Aula132()
        {
            List<Entities.Aula132Class.Product> list = new List<Entities.Aula132Class.Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (type == 'c')
                {
                    list.Add(new Entities.Aula132Class.Product(name, price));
                }
                else if (type == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new Entities.Aula132Class.UsedProduct(name, price, date));
                }
                else
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Entities.Aula132Class.ImportedProduct(name, price, customsFee));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Entities.Aula132Class.Product prod in list)
            {
                Console.WriteLine(prod.priceTag());
            }
        }

        private static void Aula130()
        {
            List<Entities.Aula130Class.Employee> List = new List<Entities.Aula130Class.Employee>();
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

                if (ch == 'Y' || ch == 'y')
                {
                    Console.Write("Adittional Charge: ");
                    double adittionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    List.Add(new Entities.Aula130Class.OutsourcedEmployee(name, hour, valuePerHour, adittionalCharge));
                }
                else
                {
                    List.Add(new Entities.Aula130Class.Employee(name, hour, valuePerHour));
                }
            }
            Console.WriteLine();
            Console.Write("Payment: ");
            foreach (Entities.Aula130Class.Employee emp in List)
            {
                Console.WriteLine("Name: " + emp.Name + " - $ " + emp.Payment().ToString("f2", CultureInfo.InvariantCulture));
            }
        }

        private static void Aula125()
        {
            //BusinessAccount Account = new BusinessAccount(18691, "Juceran", 3641.57, 500);
            //Console.WriteLine(Account.Balance);
            //Account.Balance = 10; // não funciona pois esta protected, só altera nas subclasses que herdam

            Entities.Aula125Class.Account acc = new Entities.Aula125Class.Account(186916, "Juceran", 0.0);
            Entities.Aula125Class.BusinessAccount bacc = new Entities.Aula125Class.BusinessAccount(31584, "CetaSistemas", 3641.57, 500);

            //upcasting
            Entities.Aula125Class.Account acc1 = bacc;
            Entities.Aula125Class.Account acc2 = new Entities.Aula125Class.BusinessAccount(001, "Alex", 8000, 500);
            Entities.Aula125Class.Account acc3 = new Entities.Aula125Class.SavingsAccount(1003, "Sofia", 8000, 0.01);

            //aula 127 
            acc2.Withdraw(5);
            acc3.Withdraw(5);

            Console.WriteLine(acc2.Balance);
            Console.WriteLine(acc3.Balance);

            //downcasting
            Entities.Aula125Class.BusinessAccount acc4 = (Entities.Aula125Class.BusinessAccount)acc2;
            acc4.Loan(102);
            Console.WriteLine(acc4.Balance);

            /*  o downcasting não da erro, na compilação mas da ao executar
            //  acc3 é um SavingsAccount, tem que testar, porém essse metodo não é SEGURO
            */
            //BusinessAccount acc5 = (BusinessAccount)acc3;
            if (acc3 is Entities.Aula125Class.BusinessAccount)
            {
                Entities.Aula125Class.BusinessAccount acc5 = (Entities.Aula125Class.BusinessAccount)acc3;
                acc5.Loan(200.00);
                Console.WriteLine("lOAN!");
            }

            if (acc3 is Entities.Aula125Class.SavingsAccount)
            {
                Entities.Aula125Class.SavingsAccount acc5 = (Entities.Aula125Class.SavingsAccount)acc3;
                Entities.Aula125Class.SavingsAccount acc6 = acc3 as Entities.Aula125Class.SavingsAccount; // outra forma de fazer o casting
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

            Entities.Aula122Class.Client client = new Entities.Aula122Class.Client(name, email, birthDate);
            Entities.Aula122Class.Order order = new Entities.Aula122Class.Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Entities.Aula122Class.Product product = new Entities.Aula122Class.Product(productName, price);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Entities.Aula122Class.OrderItem orderItem = new Entities.Aula122Class.OrderItem(quantity, price, product);

                order.AddItem(orderItem);

            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }

        private static void Aula121()
        {
            Entities.Aula121Class.Comment c1 = new Entities.Aula121Class.Comment("Have a nice trip");
            Entities.Aula121Class.Comment c2 = new Entities.Aula121Class.Comment("Wow that's awesome");
            Entities.Aula121Class.Post p1 = new Entities.Aula121Class.Post(
                DateTime.Parse("16/01/2019 16:01:44"),
                "Traveling to New Zealand",
                "I'm going to visit this wonderful country!",
                12
                );

            p1.AddComment(c1);
            p1.AddComment(c2);

            Entities.Aula121Class.Comment c3 = new Entities.Aula121Class.Comment("Good night");
            Entities.Aula121Class.Comment c4 = new Entities.Aula121Class.Comment("May the force to be with you");

            Entities.Aula121Class.Post p2 = new Entities.Aula121Class.Post(
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

            Entities.Aula122Class.Department dept = new Entities.Aula122Class.Department(deptName);
            Entities.Aula118Class.Worker worker = new Entities.Aula118Class.Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                Entities.Aula118Class.HourContract contract = new Entities.Aula118Class.HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY) ");
            string monthAndYear = Console.ReadLine();
            int year = int.Parse(monthAndYear.Substring(3));
            int month = int.Parse(monthAndYear.Substring(0, 2));

            Console.WriteLine("Name : " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
