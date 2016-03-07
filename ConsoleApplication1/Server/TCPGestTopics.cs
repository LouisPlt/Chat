using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chat;
using System.Net;
using System.Collections;
using System.Threading;

namespace Server
{
    class TCPGestTopics : ITopicsManager//TextGestTopics
    {


        public IPAddress ip { get; set; }
        private static int nextPort = 16000;
        public Hashtable topicTable { get; set; }


        public TCPGestTopics(IPAddress ip)
        {
            this.ip = ip;
            topicTable = new Hashtable();
        }

        
        public void createTopic(string topic)
        {
            lock (topicTable)
            {
                //Check if the topic exists
                if (topicTable.Contains(topic))
                {
                    Console.WriteLine("Topic '" + topic + "'already exists");
                }
                else
                {
                    //If the topic doesn't exist the ServerChatRoom is launched
                    ServerChatRoom chatRoom = new ServerChatRoom(ip, topic);
                    topicTable.Add(topic, chatRoom);
                    ParameterizedThreadStart ts = new ParameterizedThreadStart(chatRoom.startServer);
                    Thread t = new Thread(ts);
                    t.Start(nextPort++);
                    //The port has been changed for new connection
                }
            }
            
        }
        public IChatRoom joinTopic(string topic)
        {
            lock (topicTable)
            {
                if (topicTable.Contains(topic))
                {
                    return (ServerChatRoom)topicTable[topic];
                }
                else
                {
                    return null;
                }
            }
        }

        public String listTopics()
        {
            lock (topicTable)
            {
                String topics = "{";
                foreach (String topic in topicTable.Keys)
                {
                    topics += topic + ",";
                }
                topics += "}";
                return topics;
            }
        }
        
    }
}
