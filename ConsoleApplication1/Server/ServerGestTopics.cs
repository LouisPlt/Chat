using System;
using Net;
using System.Net.Sockets;
using Chat;
using System.Net;


namespace Server
{
    class ServerGestTopics : TCPServer, ITopicsManager
    {

        public TCPGestTopics concretGT { get; set; }

        public ServerGestTopics(IPAddress ip) : base(ip)
        {
            concretGT = new TCPGestTopics(ip);
        }

        public override void gereClient(TcpClient comm)
        {
            stream = comm.GetStream();
            while (comm.Connected)
            {
                Message msg = getMessage();
                Message replyMsg;
                if (msg == null) { return; }

                switch (msg.head.type)
                {
                    case "LIST_TOPICS":
                        replyMsg = new Message(new Header("Server", "LIST_TOPICS_REPLY"), listTopics());
                        sendMessage(replyMsg);
                        break;

                    case "CREATE_TOPICS":
                        createTopic(msg.data);
                        break;

                    case "JOIN_TOPIC":
                        IChatRoom chatRoom = joinTopic(msg.data);
                        int port = ((ServerChatRoom)chatRoom).port;
                        replyMsg = new Message(new Header("Server", "JOIN_REPLY"), port.ToString());
                        Console.WriteLine("The server respond the port is " +replyMsg.data);
                        sendMessage(replyMsg);
                        break;
                    default:
                        Console.WriteLine("default GuestTopic called :"+ msg.head.type);
                        break;
                }
            }
        }

        public String listTopics()
        {
              return concretGT.listTopics();
        }

        public IChatRoom joinTopic(String topic)
        {
            return concretGT.joinTopic(topic);
        }

        public void createTopic(String topic)
        {
            concretGT.createTopic(topic);
        }

        public override object Clone()
        {
           
            ServerGestTopics clone = new ServerGestTopics(ip);
            clone.concretGT = concretGT;
            clone.commSocket = commSocket;
            return clone;
        }

    }
}
