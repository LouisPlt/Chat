using Chat;
using Client;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                //Surcharge the dispose method to call quit()
                currentCR.quit(chatter);
                
                
            }
            base.Dispose(disposing);
        }

        public TextBox getTextDisplay()
        {
            return textDisplay;
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textDisplay = new System.Windows.Forms.TextBox();
            this.listTopic = new System.Windows.Forms.ListBox();
            this.joinTopicButton = new System.Windows.Forms.Button();
            this.createTopicButton = new System.Windows.Forms.Button();
            this.sendText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.newTopicText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(381, 837);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(637, 64);
            this.textBox3.TabIndex = 3;
            // 
            // textDisplay
            // 
            this.textDisplay.Location = new System.Drawing.Point(330, 45);
            this.textDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textDisplay.Multiline = true;
            this.textDisplay.Name = "textDisplay";
            this.textDisplay.ReadOnly = true;
            this.textDisplay.Size = new System.Drawing.Size(443, 425);
            this.textDisplay.TabIndex = 4;
            // 
            // listTopic
            // 
            this.listTopic.FormattingEnabled = true;
            this.listTopic.ItemHeight = 20;
            this.listTopic.Location = new System.Drawing.Point(38, 73);
            this.listTopic.Name = "listTopic";
            this.listTopic.Size = new System.Drawing.Size(233, 304);
            this.listTopic.TabIndex = 7;
            // 
            // joinTopicButton
            // 
            this.joinTopicButton.Location = new System.Drawing.Point(50, 383);
            this.joinTopicButton.Name = "joinTopicButton";
            this.joinTopicButton.Size = new System.Drawing.Size(85, 37);
            this.joinTopicButton.TabIndex = 8;
            this.joinTopicButton.Text = "Join";
            this.joinTopicButton.UseVisualStyleBackColor = true;
            // 
            // createTopicButton
            // 
            this.createTopicButton.Location = new System.Drawing.Point(64, 499);
            this.createTopicButton.Name = "createTopicButton";
            this.createTopicButton.Size = new System.Drawing.Size(82, 37);
            this.createTopicButton.TabIndex = 9;
            this.createTopicButton.Text = "Create";
            this.createTopicButton.UseVisualStyleBackColor = true;
            // 
            // sendText
            // 
            this.sendText.Location = new System.Drawing.Point(330, 504);
            this.sendText.Multiline = true;
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(350, 52);
            this.sendText.TabIndex = 10;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(695, 504);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(78, 52);
            this.sendButton.TabIndex = 11;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "New topic\r\n";
            // 
            // newTopicText
            // 
            this.newTopicText.Location = new System.Drawing.Point(105, 458);
            this.newTopicText.Name = "newTopicText";
            this.newTopicText.Size = new System.Drawing.Size(100, 26);
            this.newTopicText.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "List of topics";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(168, 383);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(84, 37);
            this.refreshButton.TabIndex = 15;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 571);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newTopicText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendText);
            this.Controls.Add(this.createTopicButton);
            this.Controls.Add(this.joinTopicButton);
            this.Controls.Add(this.listTopic);
            this.Controls.Add(this.textDisplay);
            this.Controls.Add(this.textBox3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChatWindow";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void setEvents()
        {
            //set all the buttons
            createTopicButton.Click += createTopicButton_Click;
            sendButton.Click +=  sendButton_Click;

            joinTopicButton.Click += JoinTopicButton_Click;
            refreshButton.Click += RefreshButton_Click;
            listTopic.DoubleClick += JoinTopicButton_Click;
                
        }

        
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            setTopics();
        }
        
        private void JoinTopicButton_Click(object sender, EventArgs e)
        {
            //if the chatter is already connected to a server, he must be desconnected first 
            if(currentCR != null)
            {
                currentCR.quit(chatter);
            }

           int index = listTopic.SelectedIndex;
            //Test if the user has selected a topic
           if(index >= 0)
            {
                //currentCR attribut is set by th return of the joinTopic() method
                string topic = listTopic.SelectedItem.ToString();
                currentCR = (ClientChatRoom) clientGT.joinTopic(topic);
                currentCR.join(chatter);
                currentCR.window = this;
                textDisplay.Text = "Bienvenue sur le channel " + topic + Environment.NewLine;
            }
            
        }
        
        private void createTopicButton_Click(object sender, EventArgs e)
        {
            string newTopic = newTopicText.Text;
            clientGT.createTopic(newTopic);
            if (!listTopic.Items.Contains(newTopic))
            {
                listTopic.Items.Add(newTopic);
                newTopicText.Text = "";

            }

        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            send();
        }
        private void send()
        {
            //Call the method post to send messages
            String text = sendText.Text;
            currentCR.post(text, chatter);
            sendText.Text = "";
        }

        public void setTopics()
        {
            Console.WriteLine("SET TOPICS");
            listTopic.BeginUpdate();
            /***Get the list without "{" and "}" **/
            String list = clientGT.listTopics();
            list = list.Substring(1, list.Length - 2);
            if(list.Length > 2)
            {

                //Separate the list with ',' 

                string[] tabTopic = list.Split(',');

                for (int i = 0; i < tabTopic.Length; i++)
                {
                    if (!listTopic.Items.Contains(tabTopic[i]))
                    {
                        listTopic.Items.Add(tabTopic[i]);
                        
                    }
                }
            }
            
            listTopic.EndUpdate();
        }
        
        
        public void setCR(ClientChatRoom currentCR)
        {
            this.currentCR = currentCR;
        }

        #endregion
        private TextBox textBox3;
        private TextBox textDisplay;
        private ListBox listTopic;
        private Button joinTopicButton;
        private Button createTopicButton;
        private TextBox sendText;
        private Button sendButton;
        private Label label1;
        private TextBox newTopicText;
        private Label label2;
        private Button refreshButton;

     

    }
}