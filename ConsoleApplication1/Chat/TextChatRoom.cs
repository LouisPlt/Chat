using Net;
using System;
using System.Collections.Generic;
namespace Chat
{
    class TextChatRoom : IChatRoom
    {
        private String topic;
        private List<IChatter> listChatter;

        public TextChatRoom(String topic)
        {
            listChatter = new List<IChatter>();
            this.topic = topic;
        }
        public String getTopic()
        {
            return topic;
        }
        
        public void post(String msg, IChatter c)
        {
            lock (listChatter)
            {
                foreach (IChatter chatter in listChatter)
                {
                    chatter.receiveAMessage(msg, c);
                }   
            }
        }

        public void quit(IChatter c)
        {
            lock (listChatter)
            {
                listChatter.Remove(c);
            }
        }
        public void join(IChatter c)
        {
            Console.WriteLine("join called from TextChatRoom");
            lock (listChatter)
            {
                listChatter.Add(c);
            }
        }
    }
}
