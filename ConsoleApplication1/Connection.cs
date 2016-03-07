using Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    public partial class Connection : Form
    {

        private ChatWindow chatWindow { get; set; }
        private ClientGestTopics clientGT { get; set; }

        public Connection(IPAddress Ip, int port)
        {
            InitializeComponent();
            setEvents();
            clientGT = new ClientGestTopics(port, Ip);
            clientGT.connect();
        }
    }
}
