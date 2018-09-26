namespace PInvoke
{
    partial class WIN32API
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TimerFlash = new System.Windows.Forms.Timer(this.components);
            this.timerMemory = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.batPB = new QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx();
            this.Virtual = new QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx();
            this.pageFile = new QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx();
            this.TotalAvail = new QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx();
            this.MemoryLoadProgressBar = new QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.button1.Location = new System.Drawing.Point(12, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "MESSAGEBOX API";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.button2.Location = new System.Drawing.Point(12, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "FLASH WINDOW";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TimerFlash
            // 
            this.TimerFlash.Interval = 50;
            this.TimerFlash.Tick += new System.EventHandler(this.TimerFlash_Tick);
            // 
            // timerMemory
            // 
            this.timerMemory.Interval = 1000;
            this.timerMemory.Tick += new System.EventHandler(this.timerMemory_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(183, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "RAM  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Salmon;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(183, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "PAGEFILE ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(183, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "VIRTUAL ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 450);
            this.panel1.TabIndex = 13;
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 65.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SlateGray;
            this.label4.Location = new System.Drawing.Point(201, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 107);
            this.label4.TabIndex = 14;
            this.label4.Text = "19:00";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SlateGray;
            this.label5.Location = new System.Drawing.Point(186, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(404, 38);
            this.label5.TabIndex = 15;
            this.label5.Text = "19:00";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Salmon;
            this.label6.Location = new System.Drawing.Point(449, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 107);
            this.label6.TabIndex = 20;
            this.label6.Text = "21";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Lime;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(183, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "BATTERY";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // batPB
            // 
            this.batPB.ForeColor = System.Drawing.Color.Lime;
            this.batPB.Location = new System.Drawing.Point(299, 285);
            this.batPB.Name = "batPB";
            this.batPB.Size = new System.Drawing.Size(289, 23);
            this.batPB.TabIndex = 22;
            this.batPB.Value = 50;
            // 
            // Virtual
            // 
            this.Virtual.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Virtual.Location = new System.Drawing.Point(299, 413);
            this.Virtual.Name = "Virtual";
            this.Virtual.Size = new System.Drawing.Size(289, 23);
            this.Virtual.TabIndex = 19;
            this.Virtual.Value = 50;
            // 
            // pageFile
            // 
            this.pageFile.ForeColor = System.Drawing.Color.Salmon;
            this.pageFile.Location = new System.Drawing.Point(299, 380);
            this.pageFile.Name = "pageFile";
            this.pageFile.Size = new System.Drawing.Size(289, 23);
            this.pageFile.TabIndex = 18;
            this.pageFile.Value = 50;
            // 
            // TotalAvail
            // 
            this.TotalAvail.ForeColor = System.Drawing.Color.SlateGray;
            this.TotalAvail.Location = new System.Drawing.Point(299, 346);
            this.TotalAvail.Name = "TotalAvail";
            this.TotalAvail.Size = new System.Drawing.Size(289, 23);
            this.TotalAvail.TabIndex = 17;
            this.TotalAvail.Value = 50;
            // 
            // MemoryLoadProgressBar
            // 
            this.MemoryLoadProgressBar.ForeColor = System.Drawing.Color.SlateGray;
            this.MemoryLoadProgressBar.Location = new System.Drawing.Point(299, 317);
            this.MemoryLoadProgressBar.Name = "MemoryLoadProgressBar";
            this.MemoryLoadProgressBar.Size = new System.Drawing.Size(289, 23);
            this.MemoryLoadProgressBar.TabIndex = 16;
            this.MemoryLoadProgressBar.Tag = "Test";
            this.MemoryLoadProgressBar.Value = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Turquoise;
            this.label8.Location = new System.Drawing.Point(17, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "AFTA DIZCA WAHANA";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WIN32API
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.batPB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Virtual);
            this.Controls.Add(this.pageFile);
            this.Controls.Add(this.TotalAvail);
            this.Controls.Add(this.MemoryLoadProgressBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WIN32API";
            this.Text = "WIN32 API";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer TimerFlash;
        private System.Windows.Forms.Timer timerMemory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx MemoryLoadProgressBar;
        private QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx TotalAvail;
        private QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx pageFile;
        private QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx Virtual;
        private System.Windows.Forms.Label label6;
        private QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx batPB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
    }
}

