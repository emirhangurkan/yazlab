using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _181307046_emirhangurkan
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("server=localhost;user id=root;database=kelime;");
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Environment.Exit(0);
        }
        private void Form4_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Length==4 && textBox1.Text!="")
            {
                baglan.Open();
                MySqlCommand kaydet = new MySqlCommand("Insert into dortlu(soru,cevap) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
                kaydet.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Soru başarıyla eklenmiştir","Bilgi",MessageBoxButtons.OK);
                textBox1.Text = "";
                textBox2.Text = "";

            }
            else if (textBox2.Text.Length == 5 && textBox1.Text != "")
            {
                baglan.Open();
                MySqlCommand kaydet = new MySqlCommand("Insert into besli(soru,cevap) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
                kaydet.ExecuteNonQuery();
                baglan.Close();MessageBox.Show("Soru başarıyla eklenmiştir","Bilgi",MessageBoxButtons.OK); textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (textBox2.Text.Length == 6 && textBox1.Text != "")
            {
                baglan.Open();
                MySqlCommand kaydet = new MySqlCommand("Insert into altılı(soru,cevap) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
                kaydet.ExecuteNonQuery();
                baglan.Close(); MessageBox.Show("Soru başarıyla eklenmiştir", "Bilgi", MessageBoxButtons.OK); textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (textBox2.Text.Length == 7 && textBox1.Text != "")
            {
                baglan.Open();
                MySqlCommand kaydet = new MySqlCommand("Insert into yedili(soru,cevap) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
                kaydet.ExecuteNonQuery();
                baglan.Close(); MessageBox.Show("Soru başarıyla eklenmiştir", "Bilgi", MessageBoxButtons.OK); textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (textBox2.Text.Length == 8 && textBox1.Text != "")
            {
                baglan.Open();
                MySqlCommand kaydet = new MySqlCommand("Insert into sekizli(soru,cevap) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
                kaydet.ExecuteNonQuery();
                baglan.Close(); MessageBox.Show("Soru başarıyla eklenmiştir", "Bilgi", MessageBoxButtons.OK); textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (textBox2.Text.Length == 9 && textBox1.Text != "")
            {
                baglan.Open();
                MySqlCommand kaydet = new MySqlCommand("Insert into dokuzlu(soru,cevap) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
                kaydet.ExecuteNonQuery();
                baglan.Close(); MessageBox.Show("Soru başarıyla eklenmiştir", "Bilgi", MessageBoxButtons.OK); textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (textBox2.Text.Length == 10 && textBox1.Text != "")
            {
                baglan.Open();
                MySqlCommand kaydet = new MySqlCommand("Insert into onlu(soru,cevap) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
                kaydet.ExecuteNonQuery();
                baglan.Close(); MessageBox.Show("Soru başarıyla eklenmiştir", "Bilgi", MessageBoxButtons.OK); textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                if (textBox1.Text!="")
                {
                    MessageBox.Show("Geçerli Uzunlukta bir cevap giriniz.", "Bilgi");
                }
                else
                {
                    MessageBox.Show("Lütfen soru giriniz.", "Bilgi");
                }
            }
        }

       
    }
}
