using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat;
using NAuthentification;
using System.IO;
using Client;
using System.Threading;
using System.Net;
using Server;
using ConsoleApplication1;
using Net;

namespace ConsoleApplication
{
    public class Programme
    {
        private static IPAddress Ip = IPAddress.Parse("127.0.0.1");
       private static int port = 55555;


        static void Main(string[] args)
        {
            //SERVER
             startServer();


            //CLIENT
             Thread mainThread1 = new Thread(startClient);
             mainThread1.Start();

             Thread mainThread2 = new Thread(startClient);
             mainThread2.Start();

           // test();
            
        }

        public static void startClient()
        {
            Connection conn = new Connection(Ip, port);
            conn.ShowDialog();
        }

        public static void startServer()
        {

            ServerGestTopics server = new ServerGestTopics(Ip);
            ParameterizedThreadStart ts = new ParameterizedThreadStart(server.startServer);
            Thread t = new Thread(ts);
            t.Start(port);
        }
        public static void test()
        {

            IPAddress Ip = IPAddress.Parse("127.0.0.1");
            int port = 55555;

            ServerGestTopics server = new ServerGestTopics(Ip);
            ParameterizedThreadStart ts = new ParameterizedThreadStart(server.startServer);
            Thread t = new Thread(ts);
            t.Start(port);

            ClientGestTopics client1 = new ClientGestTopics(port, Ip);
            Thread test1 = new Thread(new ThreadStart(client1.connect));
            test1.Start();


            ClientGestTopics client2 = new ClientGestTopics(port, Ip);
            Thread test2 = new Thread(new ThreadStart(client2.connect));
            test2.Start();
            
            client1.createTopic("Ruby");
            client1.createTopic("Java");
            client2.createTopic("PHP");

            Console.WriteLine(client1.listTopics());
            ClientChatRoom cr1 = (ClientChatRoom) client1.joinTopic("PHP");
            ClientChatRoom cr2 = (ClientChatRoom)client2.joinTopic("PHP");

            TextChatter bob = new TextChatter("bob");
            TextChatter joe = new TextChatter("joe");


            cr1.join(bob);
            cr1.post("Je suis seul ou quoi ?", bob);
            cr2.join(joe);
            cr1.post("Tiens, salut Bob !", bob);
            cr2.post("Yop", joe);
            cr1.receiveMessages();
           // cr1.quit(bob);
            cr2.post("Toi aussi tu chat sur les forums de jeux pendant les TP,Bob ?", joe);



        }
    }
}

