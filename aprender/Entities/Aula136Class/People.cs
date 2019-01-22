namespace aprender.Entities.Aula136Class
{
    abstract class People
    {
        public string Name { get; set; }
        public double AnualIncome { get; set; }

        protected People(string name, double anualIncome)
        {
            Name = name;
            AnualIncome = anualIncome;
        }

        public abstract double TaxesPaid();
    }
}
