using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApplication1;
using Net;

namespace Chat
{
    class TextChatter : IChatter
    {
        private String alias;
       
        public TextChatter(String alias)
        {
            this.alias = alias;
        }

        public String  getAlias()
        {
            return alias;
        }

        public void receiveAMessage(String msg, IChatter c)
        {
            String txt = "(At " + alias + ") :" +c.getAlias()+" $>" + msg;

            Console.WriteLine(txt);
        }
    }
}
