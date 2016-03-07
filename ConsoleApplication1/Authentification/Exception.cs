using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAuthentification
{
    class AuthentificationException : Exception
    {
        
        public String login { get; set; }
        public AuthentificationException(String login)
        {
            this.login = login;
        }

    }


    class WrongPasswordException : AuthentificationException
    {
        public WrongPasswordException(String login) : base(login)
        {
        }

    }

    class UserUnknownException : AuthentificationException
    {
        public UserUnknownException(String login) : base(login)
        {
        }

    }

    class UserExitsException : AuthentificationException
     {
        public UserExitsException(String login) : base(login)
        {
        }

     }
}
