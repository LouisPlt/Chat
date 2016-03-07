using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class TextGestTopics : ITopicsManager
    {

        public Hashtable topicsTable = new Hashtable();


        public String listTopics()
        {
            System.Console.WriteLine("The openned topics are:");
            String topics="{";
            lock (topicsTable)
            {
                foreach (String topic in topicsTable.Keys)
                {

                    topics += topic + ","; ;
                }
            }

            //Remove the last comma
            topics = topics.Substring(0, topics.Length - 1);
            topics += "}";
            Console.WriteLine(topics);
            return topics;
        }

        public void createTopic(String topic)
        {
            lock (topicsTable)
            {
               
                try
                {
                    topicsTable.Add(topic, new TextChatRoom(topic));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
           

        }



         public IChatRoom joinTopic(String topic)
        {
            lock (topicsTable)
            {
                if (topicsTable.Contains(topic))
                {
                   
                        Console.WriteLine(topic + " joined");
                    // return (IChatRoom)topicsTable[topic];
                    return (TextChatRoom)topicsTable[topic];
                }

                else
                {
                    
                    throw new Exception("The topic does not exist !");
                }
            }
            
            
            
        }

    }
}
