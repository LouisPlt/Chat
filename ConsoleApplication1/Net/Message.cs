using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Net
{
    [Serializable]
    public class Message : ISerializable
    {
        public Header head{ get; set; }
        public String data { get; set; }

        public Message(Header head, String data)
        {
            this.head = head;
            this.data = data;
        }

        public Message(SerializationInfo info, StreamingContext ctxt)
        {
            head = (Header)info.GetValue("k_head", typeof(Header));
            data = (String)info.GetValue("k_data", typeof(String));
        }
        
        public override String ToString()
        {
            return head.ToString() + ": " + data;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("k_head", head);
            info.AddValue("k_data", data);
        }

        public static void send(Message message, NetworkStream stream)
        {
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                format.Serialize(stream, message);
                stream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public static Message receive(NetworkStream stream)
        {
            BinaryFormatter format = new BinaryFormatter();
            Message msg = null;
            try
            {
                msg = (Message)format.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return msg;
        }
    }
}
