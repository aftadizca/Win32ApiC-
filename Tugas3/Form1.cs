using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxNama.Text == "" || comboBoxJurusan.Text=="")
            {
                MessageBox.Show(this, "Masukkan Nama dan Pilih Jurusan Anda","INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBoxOutput.Text = "";
                textBoxOutput.Text = "NAMA : " + textBoxNama.Text +Environment.NewLine+"JURUSAN : " + comboBoxJurusan.Text;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
