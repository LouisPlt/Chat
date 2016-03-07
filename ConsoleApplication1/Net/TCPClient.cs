using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Net
{
    public class TCPClient : IMessageConnection
    {
        public TcpClient commSock { get; set; }
        public IPAddress ip { get; set; }
        public int port { get; set; }
        public NetworkStream stream { get; set; }

        public TCPClient(int port, IPAddress ip)
        {
            this.ip = ip;
            this.port = port;
            commSock = new TcpClient();
        }

        public void connect()
        {
            commSock.Connect(ip, port);
            Console.WriteLine("Client connected");
            stream = commSock.GetStream();
            
        }

      /*  public Message getMessage()
        {
            if (stream != null)
            {
                IFormatter format = new BinaryFormatter();
                Message m = (Message)format.Deserialize(stream);
                return m;
            }
            else
            {
                Console.WriteLine("STREAM NULL");
                return null;
            }*/
            
                                       
      //  }

        public Message getMessage()
        {
            Message message = Message.receive(stream);
            return message;
        }
        public void sendMessage(Message m)
        {
            Message.send(m, stream);
        }


       /* public void sendMessage(Message m)
        {
            if (stream != null)
            {
                IFormatter format = new BinaryFormatter();
                format.Serialize(stream, m);
            }
            else Console.WriteLine("STREAM NULL");
                      
        }*/

        public void setServer(IPAddress ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

       
    }
}
