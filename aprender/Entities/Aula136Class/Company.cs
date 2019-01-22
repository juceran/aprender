namespace aprender.Entities.Aula136Class
{
    class Company : People
    {
        public int Employee { get; set; }

        public Company(string name, double anualIncome, int employee)
            :base(name, anualIncome)
        {
            Employee = employee;
        }

        public override double TaxesPaid()
        {
            if(Employee <= 10)
            {
                return AnualIncome * 0.16;
            }
            else
            {
                return AnualIncome * 0.14;
            }
        }
    }
}
