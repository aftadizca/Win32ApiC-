using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PInvoke
{
    public partial class WIN32API : Form
    {
        int flashCounter = 0;
        MEMORYSTATUSEX memori = new MEMORYSTATUSEX();

        //Add text in progressbar memori used
        public void pBMemoryLoad(uint value)
        {
            MemoryLoadProgressBar.Tag = value.ToString() + "%";
            MemoryLoadProgressBar.Value = (int)value;          
        }

        public void pBTotalAvail(ulong ullTotalPhys, ulong ullAvailPhys)
        {
            TotalAvail.Tag = (ullTotalPhys-ullAvailPhys)+" / "+ (ullTotalPhys)+" MB";
            TotalAvail.Value = MemoryLoadProgressBar.Value;           
        }

        public void pBPageFile(ulong ullTotalPageFile, ulong ullAvailPageFile)
        {
            pageFile.Tag = (ullTotalPageFile - ullAvailPageFile) + " / " + ullTotalPageFile + " MB";
            pageFile.Maximum = (int)ullTotalPageFile;
            pageFile.Value =(int)(ullTotalPageFile - ullAvailPageFile);
        }

        public void pBVirtual(ulong ullTotalVirtual, ulong ullAvailVirtual)
        {
            Virtual.Tag = (ullTotalVirtual - ullAvailVirtual) + " / " + ullTotalVirtual + " MB";
            Virtual.Maximum = (int)ullTotalVirtual;
            Virtual.Value = (int)(ullTotalVirtual - ullAvailVirtual);
        }


        public WIN32API()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerClock.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Win32Api.MessageBox(this.Handle, "TEST", "COBA", MessageBoxButtons.OKCancel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<10; i++)
            {
                Win32Api.FlashWindow(this.Handle,true);
                Win32Api.Sleep(50);

            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
                TimerFlash.Start();
                timerMemory.Start();
        }

        private void TimerFlash_Tick(object sender, EventArgs e)
        {
            if (flashCounter < 10)
            {
                Win32Api.FlashWindow(this.Handle, true);
                flashCounter++;
            }
            else
            {
                TimerFlash.Stop();
                flashCounter = 0;
            }
        }

        private void timerMemory_Tick(object sender, EventArgs e)
        {
            Win32Api.GlobalMemoryStatusEx(memori);
            pBMemoryLoad(memori.dwMemoryLoad);
            pBTotalAvail(memori.ullTotalPhys/1024/1024, memori.ullAvailPhys / 1024 / 1024);
            pBPageFile((memori.ullTotalPageFile) / 1024 / 1024, (memori.ullAvailPageFile) / 1024 / 1024);
            pBVirtual((memori.ullTotalVirtual) / 1024 / 1024, (memori.ullAvailVirtual) / 1024 / 1024);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            label4.Text = string.Format("{0:00}:{1:00}", DateTime.Now.Hour, DateTime.Now.Minute);
            label6.Text = string.Format("{0:00}", DateTime.Now.Second);
            label5.Text = DateTime.Now.ToLongDateString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
