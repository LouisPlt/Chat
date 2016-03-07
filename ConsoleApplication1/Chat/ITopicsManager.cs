using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    interface ITopicsManager
    {
        String listTopics();
        IChatRoom joinTopic(String topic);
        void createTopic(String topic);
    }
}
