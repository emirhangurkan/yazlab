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
    public partial class Form2 : Form
    {
        MySqlConnection baglan = new MySqlConnection("server=localhost;user id=root;database=kelime;");

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Ana Menüye Dönmek istediğinziden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                return;
            }
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        string cevap;
        int sayac = 0;
        int saniye = 59;
        int dakika = 3;
        int puan = 0;
        int anlikpuan = 400;
        int dortlu = 0, besli = 0, altili = 0, yedili = 0, sekizli = 0, dokuzlu = 0, onlu = 0;
        void temizle()
        {
            harf1.Text = "";
            harf2.Text = "";
            harf3.Text = "";
            harf4.Text = "";
            harf5.Text = "";
            harf6.Text = "";
            harf7.Text = "";
            harf8.Text = "";
            harf9.Text = "";
            harf10.Text = "";
        }
        public Random rnd = new Random();
        int random2 = 0, random1 = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer2.Interval = 1000;
            timer1.Start();
            baglan.Open();
            MySqlCommand dortluc = new MySqlCommand("select count(*) from dortlu", baglan);
            dortlu = Convert.ToInt32(dortluc.ExecuteScalar());
            MySqlCommand beslic = new MySqlCommand("select count(*) from besli", baglan);
            besli = Convert.ToInt32(beslic.ExecuteScalar());
            MySqlCommand altilic = new MySqlCommand("select count(*) from altılı", baglan);
            altili = Convert.ToInt32(altilic.ExecuteScalar());
            MySqlCommand yedilic = new MySqlCommand("select count(*) from yedili", baglan);
            yedili = Convert.ToInt32(yedilic.ExecuteScalar());
            MySqlCommand sekizlic = new MySqlCommand("select count(*) from sekizli", baglan);
            sekizli = Convert.ToInt32(sekizlic.ExecuteScalar());
            MySqlCommand dokuzluc = new MySqlCommand("select count(*) from dokuzlu", baglan);
            dokuzlu = Convert.ToInt32(dokuzluc.ExecuteScalar());
            MySqlCommand onluc = new MySqlCommand("select count(*) from onlu", baglan);
            onlu = Convert.ToInt32(onluc.ExecuteScalar());
            tpuan.Text = puan.ToString(); ;
            apuan.Text = "400";
            random1 = rnd.Next(1, dortlu + 1);
            random2 = random1;
            MySqlCommand cmd = new MySqlCommand("select * from dortlu where Id = ' " + random1 + " ' ", baglan);
            MySqlDataReader oku = cmd.ExecuteReader();
            oku.Read();
            soru.Text = oku["soru"].ToString();
            cevap = oku["cevap"].ToString();
            if (cevap.Length == 4)
            {
                sayac = 1;
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
            }
            baglan.Close();
        }
        int tut = 4;
        void oyun()
        {
            baglan.Open();
            if (textBox1.Text == cevap)
            {
                if (sayac == 14)
                {
                    MessageBox.Show("oyun bitti");
                    timer1.Stop();
                    timer2.Stop();
                    label2.Enabled = true;
                    label3.Enabled = true;
                    label5.Enabled = true;
                    textBox1.Text = "";
                    soru.Text="";
                    temizle();
                    baglan.Close();
                    baglan.Open();
                    DateTime bugun = DateTime.Now;
                    MySqlCommand kaydet = new MySqlCommand("Insert into oynayanlar(ad,puan,sure,tarih) values('" + "Emirhan" + "','" + tpuan.Text + "','" + saat.Text + "','" + bugun.ToString() + "')", baglan);
                    kaydet.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                {
                    sayac++;//2
                    textBox1.Text = "";
                    level.Text = sayac.ToString();
                    timer1.Start();
                    sayilar.Clear();
                    sayaca = 0;
                    temizle();
                    zaman = 0;
                    timer2.Stop();
                    puan = puan + anlikpuan;
                    tpuan.Text = puan.ToString();
                }
                

            }
            else
            {
                MessageBox.Show("Yanlış", "Bilgi");
                if (sayac == 14)
                {
                    MessageBox.Show("oyun bitti");
                    timer1.Stop();
                    timer2.Stop();
                    label2.Enabled = true;
                    label3.Enabled = true;
                    label5.Enabled = true;
                    textBox1.Text = "";
                    soru.Text = "";
                    temizle();
                    baglan.Close();
                    baglan.Open();
                    DateTime bugun = DateTime.Now;
                    MySqlCommand kaydet = new MySqlCommand("Insert into oynayanlar(ad,puan,sure,tarih) values('" + "Emirhan" + "','" + tpuan.Text + "','" + saat.Text + "','" + bugun.ToString() + "')", baglan);
                    kaydet.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                {
                    sayac++;
                    textBox1.Text = "";
                    level.Text = sayac.ToString();
                    timer1.Start();
                    sayilar.Clear();
                    sayaca = 0;
                    temizle();
                    zaman = 0;
                    timer2.Stop();
                    puan = puan - anlikpuan;
                    tpuan.Text = puan.ToString();
                }

            }
            if (sayac == 2)
            {
                random1 = rnd.Next(1, dortlu + 1);
                while (random1==random2)
                {
                    random1 = rnd.Next(1, dortlu + 1);
                }
                MySqlCommand cmd = new MySqlCommand("select * from dortlu where Id = ' " + random1 +" ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 400;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                tut++;
            }
            else if (sayac == 3)
            {
                random1 = rnd.Next(1, besli + 1);
                random2 = random1;
                MySqlCommand cmd = new MySqlCommand("select * from besli where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 500;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
            }
            else if (sayac == 4)
            {
                random1 = rnd.Next(1, besli + 1);
                while (random1 == random2)
                {
                    random1 = rnd.Next(1, besli + 1);
                }
                MySqlCommand cmd = new MySqlCommand("select * from besli where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 500;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                tut++;
            }
            else if (sayac == 6)
            {
                random1 = rnd.Next(1, altili + 1);
                random2 = random1;
                MySqlCommand cmd = new MySqlCommand("select * from altılı where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 600;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                tut++;
            }
            else if (sayac == 5)
            {
                random1 = rnd.Next(1, altili + 1);
                while (random1 == random2)
                {
                    random1 = rnd.Next(1, altili + 1);
                }
                MySqlCommand cmd = new MySqlCommand("select * from altılı where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 600;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;

            }
            else if (sayac == 8)
            {
                random1 = rnd.Next(1, yedili + 1);
                random2 = random1;
                MySqlCommand cmd = new MySqlCommand("select * from yedili where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 700;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                harf7.Visible = true;
            }
            else if (sayac == 7)
            {
                random1 = rnd.Next(1, yedili + 1);
                while (random1 == random2)
                {
                    random1 = rnd.Next(1, yedili + 1);
                }
                MySqlCommand cmd = new MySqlCommand("select * from yedili where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 700;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                harf7.Visible = true;
                tut++;
            }
            else if (sayac == 9)
            {
                random1 = rnd.Next(1, sekizli + 1);
                random2 = random1;
                MySqlCommand cmd = new MySqlCommand("select * from sekizli where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 800;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                harf7.Visible = true;
                harf8.Visible = true;
            }
            else if (sayac == 10)
            {
                random1 = rnd.Next(1, sekizli + 1);
                while (random1 == random2)
                {
                    random1 = rnd.Next(1, sekizli + 1);
                }
                MySqlCommand cmd = new MySqlCommand("select * from sekizli where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 800;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                harf7.Visible = true;
                harf8.Visible = true;
                tut++;
            }
            else if (sayac == 11)
            {
                random1 = rnd.Next(1, dokuzlu + 1);
                random2 = random1;
                MySqlCommand cmd = new MySqlCommand("select * from dokuzlu where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 900;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                harf7.Visible = true;
                harf8.Visible = true;
                harf9.Visible = true;
            }
            else if (sayac == 12)
            {
                random1 = rnd.Next(1, dokuzlu + 1);
                while (random1 == random2)
                {
                    random1 = rnd.Next(1, dokuzlu + 1);
                }
                MySqlCommand cmd = new MySqlCommand("select * from dokuzlu where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 900;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                harf7.Visible = true;
                harf8.Visible = true;
                harf9.Visible = true;
                tut++;
            }
            else if (sayac == 13)
            {
                random1 = rnd.Next(1, onlu + 1);
                random2 = random1;
                MySqlCommand cmd = new MySqlCommand("select * from onlu where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 1000;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                harf7.Visible = true;
                harf8.Visible = true;
                harf9.Visible = true;
                harf10.Visible = true;
                tut++;
            }
            else if (sayac == 14)
            {
                random1 = rnd.Next(1, onlu + 1);
                while (random1 == random2)
                {
                    random1 = rnd.Next(1, onlu + 1);
                }
                baglan.Close();
                baglan.Open();
                MySqlCommand cmd = new MySqlCommand("select * from onlu where Id = ' " + random1 + " ' ", baglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                oku.Read();
                anlikpuan = 1000;
                apuan.Text = anlikpuan.ToString();
                cevap = oku["cevap"].ToString();
                soru.Text = oku["soru"].ToString();
                harf1.Visible = true;
                harf2.Visible = true;
                harf3.Visible = true;
                harf4.Visible = true;
                harf5.Visible = true;
                harf6.Visible = true;
                harf7.Visible = true;
                harf8.Visible = true;
                harf9.Visible = true;
                harf10.Visible = true;
            }
            baglan.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            oyun();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye = saniye - 1;
            if (saniye == 0)
            {
                dakika = dakika - 1;
                saniye = 59;
            }
            if (dakika.ToString()=="-1")
            {
                saat.Text = "00:00";
            }
            saat.Text = "0"+ dakika.ToString()+ ":" + saniye.ToString();
        }
        int zaman = 0;
        private void label5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            zaman++;
            if (zaman==20)
            {
                MessageBox.Show("Bilgi","Düşünme süreniz bitti");
                puan = puan - (tut * 100);
                sayac++;
                timer1.Start();
                oyun();
            }
            
        }
        int sayaca = 0;
        Random random = new Random();
        HashSet<int> sayilar = new HashSet<int>();
        private void label3_Click(object sender, EventArgs e)
        {
            char[] ayir = cevap.ToCharArray();
            if (sayaca==ayir.Length-1)
            {
                MessageBox.Show("DAHA FAZLA HARF ALAMAZSIN","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                anlikpuan -= 100;
                apuan.Text = anlikpuan.ToString();
                while (sayilar.Count != ayir.Length)
                sayilar.Add(random.Next(0, ayir.Length));
                int sayacb = 0;
                int[] dizim = new int[sayilar.Count];
                foreach (var item in sayilar)
                {
                    dizim[sayacb] = item;
                    sayacb++;
                }
                switch (dizim[sayaca])
                {
                    case 0: harf1.Text = ayir[0].ToString(); break;
                    case 1: harf2.Text = ayir[1].ToString(); break;
                    case 2: harf3.Text = ayir[2].ToString(); break;
                    case 3: harf4.Text = ayir[3].ToString(); break;
                    case 4: harf5.Text = ayir[4].ToString(); break;
                    case 5: harf6.Text = ayir[5].ToString(); break;
                    case 6: harf7.Text = ayir[6].ToString(); break;
                    case 7: harf8.Text = ayir[7].ToString(); break;
                }
                sayaca++;
            }
        }
    }
}
