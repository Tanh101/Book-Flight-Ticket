using System;
using System.Collections.Generic;
using System.Text;

namespace Flight
{
    class Account
    {
        public Account(string userName, string password)
        {
            this.userName = userName;
            Password = password;
        }
        public Account()
        {

        }
        public override string ToString()
        {
            return userName + " " + Password;
        }
        public String userName { get; set; }

        public String Password { get; set; }
    }
}
