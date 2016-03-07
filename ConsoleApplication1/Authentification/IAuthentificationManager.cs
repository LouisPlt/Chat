using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAuthentification
{
    interface IAuthentificationManager
    {
        void addUser( String login, String password );
        void removeUser( String login ); 
        void authentify( String login, String password );
        void load( String path );
        void save(String path);

    }
}
