using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat;

namespace Chat
{
    public interface IChatter
    {
        
        void receiveAMessage(String msg, IChatter c);
        String getAlias();
        
    }
}
