using System;


namespace NAuthentification
{
    [Serializable]
    class User : IComparable
    {
        
        public User(string login, string password)
        {
           
            this.login = login;
            this.password = password;
        }
        public String login { get; set; }
        public String password { get; set; }
        
        public int CompareTo(Object obj)
        {
            if (obj is User)
            {
                return login.CompareTo(((User)obj).login);

            }
            return login.CompareTo(obj);
        }

      
    }
}
