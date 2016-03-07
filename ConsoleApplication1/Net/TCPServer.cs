using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


namespace Net
{
    abstract class TCPServer : IMessageConnection, ICloneable
    {
        public TcpClient commSocket { get; set; }
        public TcpListener waitSocket { get; set; }
        public IPAddress ip { get; set; }
        public NetworkStream stream { get; set; }

        public bool treatClient { get; set; }
        public bool doRun { get; set; }

        public int port { get; set; }
        


        public TCPServer(IPAddress ip)
        {
            doRun = true;
            this.ip = ip;
            treatClient = false;

        }
        
        public void startServer(Object port)
        {
            Console.WriteLine("startServer");
            this.port = (int)port;
            waitSocket = new TcpListener(ip, (int)port);
            waitSocket.Start();
            run();

        }



        public void stopServer()
        {
            waitSocket.Stop();
            doRun = false;
       
        }

        public void run()
        {
            if (treatClient)
            {
                gereClient(commSocket);
            }
            else
            {
                while (doRun)
                {
                    
                        commSocket = waitSocket.AcceptTcpClient();
                        Console.WriteLine("serverRunning");

                        TCPServer myClone = (TCPServer)Clone();
                        myClone.treatClient = true;
                        Thread newClient = new Thread(new ThreadStart(myClone.run));
                        newClient.Start();
                }
                
            }
        }

        abstract public object Clone();
        
        abstract public void gereClient(TcpClient comm);


        public Message getMessage()
        {
           return  Message.receive(stream);
        }

        public void sendMessage(Message m)
        {
            Message.send(m, stream);
        }
    }
}
