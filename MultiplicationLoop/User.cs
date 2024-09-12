using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountsWIthBankAccount
{
    internal class User
    {
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public BankAccount Account { get; }

        public User(string name, string street, string city, string postalCode, int accountNumber)
        {
            Account = new BankAccount(accountNumber, 0M);
            Name = name;
            Street = street;
            City = city;
            PostalCode = postalCode;
        }        
    }
}
