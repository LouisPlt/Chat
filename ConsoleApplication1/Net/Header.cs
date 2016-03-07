using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net

{   [Serializable]
    public class Header
    {
        public String date { get; set; }
        public String sender { get; set; }
        public String type { get; set; }

        public Header(String sender, String type)
        {
            date = DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString()+ " ";
            this.sender = sender;
            this.type = type;

        }

        public override string ToString()
        {
            return sender + " at " + date;
        }
        
    }
}
