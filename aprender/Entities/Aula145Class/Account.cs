using aprender.Entities.Exceptions;
using System;

namespace aprender.Entities.Aula145Class
{
    class Account
    {
        public int Number { get; set; }
        public String Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimite { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimite)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimite = withdrawLimite;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void WithDraw(double amount)
        {
            if (amount > WithdrawLimite)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }

            if (amount > Balance)
            {
                throw new DomainException("Not enough balance");
            }

            Balance -= amount;
        }
    }
}
