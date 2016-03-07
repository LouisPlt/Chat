using Net;
using System;
using System.Net.Sockets;
using Chat;
using System.Net;

namespace Server
{
    class ServerChatRoom : TCPServer, IChatRoom, IChatter
    {
        public String pseudo { get; set; }
        public TextChatRoom concretCR { get; set; }
        
        public ServerChatRoom(IPAddress ip , String topic) : base(ip)
        {
            concretCR = new TextChatRoom(topic);

        }
        
        public override object Clone()
        {
            
            ServerChatRoom clone = new ServerChatRoom(ip,concretCR.getTopic());
            clone.concretCR = concretCR;
            clone.commSocket = commSocket;
            return clone;
        }

        public override void gereClient(TcpClient comm)
        {
            stream = comm.GetStream();
            while (comm.Connected)
            {
                Message msg = getMessage();
               if(msg == null) { return; }
                switch (msg.head.type)
                {
                    case "JOIN_CR":
                        pseudo = msg.head.sender;
                        join(this);
                        break;
                    case "POST":
                        post(msg.data, this);
                        Console.WriteLine("PTDR");
                        break;
                    case "QUITCR":
                        pseudo = msg.head.sender;
                        quit(this);
                        break;
                    default:
                        Console.WriteLine("Default called");
                        break;
                }
            }
        }
        
        public string getTopic()
        {
            return concretCR.getTopic();
        }

        public void join(IChatter c)
        {
            concretCR.join(c);
        }

        public void post(string msg, IChatter c)
        {
            Console.WriteLine("post called");
            concretCR.post(msg, c);
        }

        public void quit(IChatter c)
        {
            concretCR.quit(c);
        }
        
        public string getAlias()
        {
            return pseudo;
           
        }
        public void receiveAMessage(string msg, IChatter c)
        {
            Message message = new Message(new Header(c.getAlias(), "RECV_MSG"), msg);
            Console.WriteLine("receiveAMessage called");
            sendMessage(message);
        }
    }
}