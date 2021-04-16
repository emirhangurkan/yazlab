using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _181307046_emirhangurkan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 frm2 = new Form2();
        Form3 frm3 = new Form3();
        Form4 frm4 = new Form4();
        private void label1_Click(object sender, EventArgs e)
        {
            frm2.Show();
            this.Visible = false ;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frm4.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frm3.Show();
            this.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Environment.Exit(0);
        }
    }
}
