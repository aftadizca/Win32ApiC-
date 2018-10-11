using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinsockServer
{
    public partial class FormServer : Form
    {
        private bool isConnect;
        public void formatText(RichTextBox rtb, string text, Color color, FontStyle fontStyle, bool newLine)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;
            //rtb.Font = new Font(DefaultFont.FontFamily, DefaultFont.Size, fontStyle);
            rtb.SelectionColor = color;
            rtb.AppendText($@"{text}{(newLine? "\n":"")}");
        }

        public FormServer()
        {
            InitializeComponent();
            buttonClose.Enabled = false;
        }

        private void axWinsock1_ConnectEvent(object sender, EventArgs e)
        {
            //formatText(richTextBoxChat, $@"Client connected : {axWinsock1.RemoteHostIP} : {axWinsock1.RemotePort}", Color.Blue, FontStyle.Italic, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWinsock1.LocalPort = 11111;
            axWinsock1.Listen();
            formatText(richTextBoxChat, $@"<----Server Started---->", Color.Green, FontStyle.Italic, true);
            buttonListen.Enabled = false;
            buttonClose.Enabled = true;
            isConnect = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            axWinsock1.Close();
            buttonListen.Enabled = true;
            buttonClose.Enabled = false;
            formatText(richTextBoxChat, $@"<----Server Shutdown---->", Color.Red, FontStyle.Italic, true);
            isConnect = false;
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
        }

        private void axWinsock1_Error(object sender, AxMSWinsockLib.DMSWinsockControlEvents_ErrorEvent e)
        {
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (isConnect)
            {
                axWinsock1.SendData(textBoxMSG.Text);
                formatText(richTextBoxChat, "You : " + textBoxMSG.Text, Color.Black, FontStyle.Regular, true);
            }
        }

        private void axWinsock1_ConnectionRequest(object sender, AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEvent e)
        {
            axWinsock1.Close();
            axWinsock1.Accept(e.requestID);
            formatText(richTextBoxChat, $@"<----Client Connected---->", Color.Green, FontStyle.Italic, true);
        }

        private void axWinsock1_CloseEvent(object sender, EventArgs e)
        {
            formatText(richTextBoxChat, $@"<----Client Disconnect---->", Color.Red, FontStyle.Italic, true);
            axWinsock1.Close();
            axWinsock1.Listen();
        }

        private void axWinsock1_DataArrival(object sender, AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent e)
        {
            String data = "";

            Object dat = (object)data;

            axWinsock1.GetData(ref dat, 8, 100);

            data = (string)dat;
            if (data != "")
            {
                formatText(richTextBoxChat, "Client : " + data, Color.Black, FontStyle.Regular, true);
            }
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
