using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _181307046_emirhangurkan
{
    public partial class Form3 : Form
    {
        MySqlConnection baglan = new MySqlConnection("server=localhost;user id=root;database=kelime;");
        public Form3()
        {
            InitializeComponent();
        }
        int uzunluk = 0;
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Environment.Exit(0);
        }
        string ad, tarih, sure, puan,adams;
        private void Form3_Load(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand deneme = new MySqlCommand("select count(*) from oynayanlar", baglan);
            uzunluk = Convert.ToInt32(deneme.ExecuteScalar());
            baglan.Close();
            for (int i = 1; i < uzunluk+1; i++)
            {
                baglan.Open();
                MySqlCommand cmd = new MySqlCommand("select * from oynayanlar where Id = ' " + i + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();

                ad = oku["ad"].ToString();
                tarih = oku["tarih"].ToString();
                sure= oku["sure"].ToString();
                puan= oku["puan"].ToString();
                adams = ad +" adındaki kullanıcının "+ tarih +" tarihinde "+ " bu kadar süresi kalmıştır: "+ sure + " Oyuncunun puanı:" + puan;
                listBox1.Items.Add(adams);
                baglan.Close();

            }
        }
    }
}
