namespace ChatServer
{
    partial class Form1
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
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCMD = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.State = new System.Windows.Forms.Label();
            this.tbMessaging = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(365, 40);
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(100, 20);
            this.tbMsg.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Execute";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Execute Command";
            // 
            // tbCMD
            // 
            this.tbCMD.Location = new System.Drawing.Point(115, 37);
            this.tbCMD.Name = "tbCMD";
            this.tbCMD.Size = new System.Drawing.Size(100, 20);
            this.tbCMD.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 104);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(239, 206);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // State
            // 
            this.State.AutoSize = true;
            this.State.Location = new System.Drawing.Point(9, 367);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(55, 13);
            this.State.TabIndex = 10;
            this.State.Text = "No Clients";
            // 
            // tbMessaging
            // 
            this.tbMessaging.Location = new System.Drawing.Point(356, 104);
            this.tbMessaging.Name = "tbMessaging";
            this.tbMessaging.ReadOnly = true;
            this.tbMessaging.Size = new System.Drawing.Size(239, 206);
            this.tbMessaging.TabIndex = 11;
            this.tbMessaging.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 429);
            this.Controls.Add(this.tbMessaging);
            this.Controls.Add(this.State);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCMD);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbMsg);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCMD;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.RichTextBox tbMessaging;
    }
}

