using Chat;
using Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientGestTopics : TCPClient, ITopicsManager
    {


        public ClientGestTopics(int port, IPAddress ip) : base(port, ip)
        {

        }
        
        public void createTopic(string topic)
        {
            Console.WriteLine("Topic créer");
            //Send the request for create a topic
            Message msg = new Message(new Header("Someone", "CREATE_TOPICS"),topic);
            sendMessage(msg);
        }

        public IChatRoom joinTopic(string topic)
        {
            //Send the request for a socket for the client to join to the topic
            Message msg = new Message(new Header("Someone", "JOIN_TOPIC"), topic);
            sendMessage(msg);

            //Get a free port in reply
            Message replyMsg =  getMessage();
            int port = 0;
            if (replyMsg != null)
            {
                port = int.Parse(replyMsg.data);
                ClientChatRoom chatRoom = new ClientChatRoom(ip, port, topic);
                chatRoom.setServer(ip, port);
                chatRoom.connect();
                return chatRoom;
            }
            //Connect the client to the desired topic with the port

            return null;
            
        }

        public String listTopics()
        {

            //Send a request to get the topics
            Message msg = new Message(new Header("Someone", "LIST_TOPICS"), "List of topics");
            sendMessage(msg);

            //Get the list in a reply message
            Message replyMsg = getMessage();
            if (replyMsg != null)
            {
                return replyMsg.data;
            }
            else
                return "";
            
        }
        
    }
}
