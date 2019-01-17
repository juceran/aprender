namespace aprender.Entities
{
    class BusinessAccount : Account
    {
        public double LoanLimite { get; set; }

        public BusinessAccount()
        {
        }

        public BusinessAccount(int number, string holder, double balance, double loanlimite)
            : base(number, holder, balance)
        {
            LoanLimite = loanlimite;
        }

        public void Loan(double amount)
        {
            if(amount <= LoanLimite)
            {
                Balance += amount;
            }
            
        }
    }
}
