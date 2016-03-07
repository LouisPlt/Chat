using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace NAuthentification
{
    [Serializable]
    class Authentification : IAuthentificationManager, ISerializable
    {
        private List<User> userList = new List<User>();



        public void addUser(string login, string password)
        {
            foreach (User u in userList)
            {
                if (u.login == login)
                {
                    throw new UserExitsException(login);
                }
            }           
            
              userList.Add(new User(login, password));
            
        }

        public void removeUser(string login)
        {
            
            for(int i=0; i< userList.Count ; i++) 
            {
                 if(userList.ElementAt(i).login.Equals(login))
                {
                    
                     userList.Remove(userList.ElementAt(i));
                     return;
                }
            }

            throw new UserUnknownException(login);
            
        }

        public void authentify(string login, string password)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList.ElementAt(i).login.Equals(login))
                {
                    if (userList.ElementAt(i).password.Equals(password))
                    {
                        Console.WriteLine(login + " est connecté");
                        return;
                    }
                    else
                        throw new WrongPasswordException(login);
                }
            }

            throw new UserUnknownException(login);
        }

        public void load(String path)
        {
            IFormatter format = new BinaryFormatter();
            Stream flux = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            if (flux.CanRead)
            {
                using (flux)

                {
                    if(flux.Length != 0)
                    {
                        userList = (List<User>)format.Deserialize(flux);
                    }
                    
                    
                }

            }
            
            else throw new IOException();
            flux.Close();
        }

        public void save(String path)
        {
            IFormatter format = new BinaryFormatter();
            Stream flux = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            if (flux.CanWrite)
            {
                using (flux)
                {
                    format.Serialize(flux, userList);
                }
            }
            else throw new IOException();
            flux.Close();

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
