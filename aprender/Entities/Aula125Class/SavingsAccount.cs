﻿using System;
using System.Collections.Generic;
using System.Text;

namespace aprender.Entities.Aula125Class
{
    class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount()
        {
        }

        public SavingsAccount(int number, string holder, double balance, double interestRate)
            : base(number, holder, balance)
        {
            InterestRate = interestRate;
        }

        public void UpdateBalance()
        {
            Balance += Balance * InterestRate;
        }

        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
            //Balance -= amount;
            Balance -= amount * 0.01;
        }
    }
}
