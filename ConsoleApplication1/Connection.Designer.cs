using Chat;
using Client;
using NAuthentification;
using System;
using System.IO;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    partial class Connection
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
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.signUpButton = new System.Windows.Forms.Button();
            this.errorsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginText
            // 
            this.loginText.Location = new System.Drawing.Point(232, 120);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(112, 26);
            this.loginText.TabIndex = 0;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(232, 177);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(112, 26);
            this.passwordText.TabIndex = 1;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(141, 120);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(48, 20);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Login";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(141, 177);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(78, 20);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password";
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(284, 277);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(93, 42);
            this.signInButton.TabIndex = 4;
            this.signInButton.Text = "Sign in";
            this.signInButton.UseVisualStyleBackColor = true;
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(145, 277);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(96, 42);
            this.signUpButton.TabIndex = 5;
            this.signUpButton.Text = "Sign up";
            this.signUpButton.UseVisualStyleBackColor = true;
            // 
            // errorsLabel
            // 
            this.errorsLabel.AutoSize = true;
            this.errorsLabel.ForeColor = System.Drawing.Color.Red;
            this.errorsLabel.Location = new System.Drawing.Point(228, 237);
            this.errorsLabel.Name = "errorsLabel";
            this.errorsLabel.Size = new System.Drawing.Size(0, 20);
            this.errorsLabel.TabIndex = 6;
            // 
            // Windows1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 377);
            this.Controls.Add(this.errorsLabel);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.loginText);
            this.Name = "Windows1";
            this.Text = "Windows1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void setEvents()
        {
            signInButton.Click += SignInButton_Click;
            signUpButton.Click += SignUpButton_Click;
        }
        
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            if (loginText.Text.Length == 0 || passwordText.Text.Length == 0)
            {
                errorsLabel.Text = "Login or password can't be empty";
                
            }
            else
            {
                try
                {
                    IAuthentificationManager am = new Authentification();
                    am.load("users.bin");
                    am.addUser(loginText.Text, passwordText.Text);
                    am.save("users.bin");
                    Console.WriteLine(loginText.Text + " has signed up !");
                    errorsLabel.Text = "";

                    

                }
                catch (UserExitsException ex)
                {
  
                    errorsLabel.Text = ex.login + " already exists";
                }
            }
        }

        

        private void SignInButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                IAuthentificationManager am = new Authentification();
                am.load("users.bin");
                am.authentify(loginText.Text, passwordText.Text);
                Console.WriteLine(loginText.Text + " has signed in !");

               
                ChatWindow chatWindow = new ChatWindow(loginText.Text,clientGT);
                this.Dispose();
                this.chatWindow = chatWindow;
                chatWindow.ShowDialog();
            }
            catch (UserUnknownException ex)
            {
                errorsLabel.Text = ex.login + " is unknown";
            }
            catch (WrongPasswordException ex)
            {
                errorsLabel.Text =  "Invalid password ";
            }
            catch (IOException)
            {
                errorsLabel.Text = "Erreur dans la lecture ou l'ecriture du fichier";
                
            }
        }

        #endregion

        private TextBox loginText;
        private TextBox passwordText;
        private Label loginLabel;
        private Label passwordLabel;
        private Button signInButton;
        private Button signUpButton;
        private Label errorsLabel;
        

    }
}