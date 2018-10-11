namespace WinsockClient
{
    partial class FormClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.buttonCon = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxMSG = new System.Windows.Forms.TextBox();
            this.axWinsock1 = new AxMSWinsockLib.AxWinsock();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWinsock1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCon
            // 
            this.buttonCon.Location = new System.Drawing.Point(387, 15);
            this.buttonCon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCon.Name = "buttonCon";
            this.buttonCon.Size = new System.Drawing.Size(87, 121);
            this.buttonCon.TabIndex = 10;
            this.buttonCon.Text = "CONNECT";
            this.buttonCon.UseVisualStyleBackColor = true;
            this.buttonCon.Click += new System.EventHandler(this.buttonCon_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(387, 143);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(87, 121);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(293, 311);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(87, 28);
            this.buttonSend.TabIndex = 8;
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxMSG
            // 
            this.textBoxMSG.Location = new System.Drawing.Point(15, 313);
            this.textBoxMSG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMSG.Name = "textBoxMSG";
            this.textBoxMSG.Size = new System.Drawing.Size(270, 21);
            this.textBoxMSG.TabIndex = 7;
            this.textBoxMSG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMSG_KeyDown);
            // 
            // axWinsock1
            // 
            this.axWinsock1.Enabled = true;
            this.axWinsock1.Location = new System.Drawing.Point(386, 272);
            this.axWinsock1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.axWinsock1.Name = "axWinsock1";
            this.axWinsock1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWinsock1.OcxState")));
            this.axWinsock1.Size = new System.Drawing.Size(28, 28);
            this.axWinsock1.TabIndex = 11;
            this.axWinsock1.Error += new AxMSWinsockLib.DMSWinsockControlEvents_ErrorEventHandler(this.axWinsock1_Error);
            this.axWinsock1.DataArrival += new AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEventHandler(this.axWinsock1_DataArrival);
            this.axWinsock1.ConnectEvent += new System.EventHandler(this.axWinsock1_ConnectEvent);
            this.axWinsock1.CloseEvent += new System.EventHandler(this.axWinsock1_CloseEvent);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 15);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(365, 285);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 356);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.axWinsock1);
            this.Controls.Add(this.buttonCon);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMSG);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormClient";
            this.Text = "CLIENT";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWinsock1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCon;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxMSG;
        private AxMSWinsockLib.AxWinsock axWinsock1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

