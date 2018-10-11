namespace WinsockServer
{
    partial class FormServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
            this.axWinsock1 = new AxMSWinsockLib.AxWinsock();
            this.textBoxMSG = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonListen = new System.Windows.Forms.Button();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWinsock1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWinsock1
            // 
            this.axWinsock1.Enabled = true;
            this.axWinsock1.Location = new System.Drawing.Point(332, 219);
            this.axWinsock1.Name = "axWinsock1";
            this.axWinsock1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWinsock1.OcxState")));
            this.axWinsock1.Size = new System.Drawing.Size(28, 28);
            this.axWinsock1.TabIndex = 0;
            this.axWinsock1.Error += new AxMSWinsockLib.DMSWinsockControlEvents_ErrorEventHandler(this.axWinsock1_Error);
            this.axWinsock1.DataArrival += new AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEventHandler(this.axWinsock1_DataArrival);
            this.axWinsock1.ConnectEvent += new System.EventHandler(this.axWinsock1_ConnectEvent);
            this.axWinsock1.ConnectionRequest += new AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEventHandler(this.axWinsock1_ConnectionRequest);
            this.axWinsock1.CloseEvent += new System.EventHandler(this.axWinsock1_CloseEvent);
            // 
            // textBoxMSG
            // 
            this.textBoxMSG.Location = new System.Drawing.Point(13, 254);
            this.textBoxMSG.Name = "textBoxMSG";
            this.textBoxMSG.Size = new System.Drawing.Size(232, 20);
            this.textBoxMSG.TabIndex = 2;
            this.textBoxMSG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMSG_KeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(251, 253);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(332, 116);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 98);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(332, 12);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(75, 98);
            this.buttonListen.TabIndex = 5;
            this.buttonListen.Text = "LISTEN";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxChat.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(314, 235);
            this.richTextBoxChat.TabIndex = 6;
            this.richTextBoxChat.Text = "";
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 290);
            this.Controls.Add(this.richTextBoxChat);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMSG);
            this.Controls.Add(this.axWinsock1);
            this.Name = "FormServer";
            this.Text = "SERVER";
            this.Load += new System.EventHandler(this.FormServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWinsock1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMSWinsockLib.AxWinsock axWinsock1;
        private System.Windows.Forms.TextBox textBoxMSG;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
    }
}

