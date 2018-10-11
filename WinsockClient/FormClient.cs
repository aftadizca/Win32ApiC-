using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;

namespace WinsockClient
{
    public partial class FormClient : Form
    {
        private bool isConnect;

        public void formatText(RichTextBox rtb, string text, Color color, FontStyle fontStyle, bool newLine)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = color;
            rtb.AppendText($@"{text}{(newLine ? "\n" : "")}");
        }

        public FormClient()
        {
            InitializeComponent();
            buttonClose.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void axWinsock1_ConnectEvent(object sender, EventArgs e)
        {
            formatText(richTextBox1, $@"<----Connected to Server---->",Color.Green, FontStyle.Italic,true);
            isConnect = true;
            buttonCon.Enabled = false;
            buttonClose.Enabled = true;
        }

        private void buttonCon_Click(object sender, EventArgs e)
        {
            axWinsock1.Close();
            axWinsock1.Connect(axWinsock1.LocalIP, "11111");
            Console.WriteLine(axWinsock1.RemotePort);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (isConnect)
            {
                axWinsock1.SendData(textBoxMSG.Text);
                formatText(richTextBox1, "You : " + textBoxMSG.Text, Color.Black, FontStyle.Regular, true);
            }
        }

        private void axWinsock1_DataArrival(object sender, AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent e)
        {
            String data = "";

            Object dat = (object) data;

            axWinsock1.GetData(ref dat,8,100);

            data = (string) dat;

            if (data != "")
            {
                formatText(richTextBox1, "Server : " + data, Color.Black, FontStyle.Regular, true); 
            }

        }

        private void axWinsock1_CloseEvent(object sender, EventArgs e)
        {
            formatText(richTextBox1, $@"<----Server Disconnect---->", Color.Red, FontStyle.Italic, true);
            buttonCon.Enabled = true;
            buttonClose.Enabled = false;
            isConnect = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            formatText(richTextBox1, $@"<----Client Disconneted---->", Color.Red, FontStyle.Italic, true);
            buttonCon.Enabled = true;
            buttonClose.Enabled = false;
            isConnect = false;
            axWinsock1.Close();
        }

        private void axWinsock1_Error(object sender, AxMSWinsockLib.DMSWinsockControlEvents_ErrorEvent e)
        {
            formatText(richTextBox1, $@"<----Connection Failed---->", Color.Red, FontStyle.Italic, true);
        }

        private void textBoxMSG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSend.PerformClick();
                textBoxMSG.Text = "";
            }
        }
    }
}
