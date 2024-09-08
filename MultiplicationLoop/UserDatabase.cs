using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountsWIthBankAccount
{
    internal class UserDatabase
    {
        public List<User> Users { get; private set; }

        public UserDatabase()
        {
            this.Users = new List<User>();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }
    }
}
