using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountsWIthBankAccount
{
    internal class BankAccount
    {
        private int accountNumber;
        private decimal balance;

        public BankAccount(int accountNumber, decimal balance)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
        }

        public int GetAccountNumber()
        {
            return accountNumber;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount < balance)
            {
                balance -= amount;
                return true;
            }
            else
            {                
                return false;
            }
        }

        public void Deposit(decimal amount)
        {
            balance += amount;            
        }


    }
}
