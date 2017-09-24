using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ispsystem.Databasa
{
    public class Login
    {
        public string login { get; set; }
        public string password { get; set; }
        public string type { get; set; }

        public Login(string login, string password, string type) 
        {
            this.login = login;
            this.password = password;
            this.type = type;
        }


    }
}