using Chat;
using ConsoleApplication1;
using Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class ClientChatRoom : TCPClient, IChatRoom
    {
        public String topic { get; set; }
        public bool doRun { get; set; }
        public  ChatWindow window { get; set; }

        public ClientChatRoom(IPAddress ip, int port, String topic) : base(port, ip)
        {
            this.topic = topic;
            doRun = true;
            Console.WriteLine("port :"+port);

        }

        public string getTopic()
        {
            return topic;
        }

        public void join(IChatter c)
        {
            Console.WriteLine("join called");
            //Send the request for join a topic
            Net.Message msg = new Net.Message(new Header(c.getAlias(), "JOIN_CR"), "");
            sendMessage(msg);

            //Start the thread to receive messages
            Thread thread = new Thread(new ThreadStart(receiveMessages));
            thread.Start();
            
        }

        public void receiveMessages()
        {
            while (doRun)
            {
                Net.Message message = getMessage();
                if(message == null) { return; }

                //display the message in the textbox
                window.setTextDisplay(window.getTextDisplay().Text + message.ToString() + Environment.NewLine);
                
            }
        }
        
        public void post(string msg, IChatter c)
        {
            Net.Message postMsg = new Net.Message(new Header(c.getAlias(), "POST"), msg);
            sendMessage(postMsg);
            
        }

        public void quit(IChatter c)
        {
            Net.Message msg = new Net.Message(new Header(c.getAlias(), "QUITCR"), "");
            sendMessage(msg);
            doRun = false;
        }
    }
}