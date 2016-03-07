using Chat;
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
    public partial class ChatWindow : Form
    {
        public ClientGestTopics clientGT { get; set; }
        public ClientChatRoom currentCR { get; set; }
        public IChatter chatter { get; set; }

        public ChatWindow(string pseudo, ClientGestTopics clientGT)
        {

            /***Connect the client***/
            this.clientGT = clientGT;
            textDisplay = new TextBox();
            sendText = new TextBox();
            chatter = new TextChatter(pseudo);

            
            /**Set up the GUI **/
            InitializeComponent();
            setEvents();
           
            /*Set up the topics that already exist*/
            setTopics();
            
        }
        
        //method to set the text of the TextBox
        public void setTextDisplay(String msg)
        {
            if (getTextDisplay().InvokeRequired)
            {
                dSetTexBox d = new dSetTexBox(setTextDisplay);
                Invoke(d, new object[] { msg });

            }
            else
            {
                getTextDisplay().Text = msg;
                getTextDisplay().SelectionStart = getTextDisplay().TextLength;
                getTextDisplay().ScrollToCaret();
            }

        }
        delegate void dSetTexBox(string msg);

    }
}
