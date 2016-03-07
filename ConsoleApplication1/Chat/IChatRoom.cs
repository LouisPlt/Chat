using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public interface IChatRoom
    {
        void post(String msg, IChatter c);
        void quit(IChatter c);
        void join(IChatter c);
        String getTopic();
    }
}
