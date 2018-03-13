using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TEZ01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string kulAdı { get; set; }
        SatılıkEkle stkEkle = new SatılıkEkle();
        satılıkGoruntule stkgoruntule = new satılıkGoruntule();
        kiralıkDüzenle krlkduzenle = new kiralıkDüzenle();
        GunlukEvDuzenle gnlukduzenle = new GunlukEvDuzenle();
        ArsaEkleSilGuncelle arsaduzenle = new ArsaEkleSilGuncelle();
        kiralıkGoruntule krlgoruntule = new kiralıkGoruntule();
        gunlukEvleriGoruntule grntleGunlukEv = new gunlukEvleriGoruntule();
        ArsaGoruntuleAl arsagrntuleAl = new ArsaGoruntuleAl();
        KullanıcıEkle klekle = new KullanıcıEkle();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (kulAdı == "admin")
            {
                stkEkle.ShowDialog();

            }
            else
            {
                MessageBox.Show("BURAYA ERİŞİM YETKİNİZ YOK !!");
            }
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
           pictureBox1.ImageLocation = Application.StartupPath+"\\resimler\\tıkla.png";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           pictureBox1.ImageLocation = Application.StartupPath + "\\resimler\\satılıkduzenle.png";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictbxkullanıcı.ImageLocation = Application.StartupPath + "\\resimler\\kullanıcı.png";
            lblkuladı.Text = kulAdı.ToUpper();
            if (kulAdı!="admin")
            {
               
                
            }
            pictureBox1.ImageLocation = Application.StartupPath + "\\resimler\\satılıkduzenle.png";
            pictureBox2.ImageLocation = Application.StartupPath + "\\resimler\\gunlukduzenle.png";
            pictureBox3.ImageLocation = Application.StartupPath + "\\resimler\\arsaduzenle.png";
            pictureBox4.ImageLocation = Application.StartupPath + "\\resimler\\kiralıkduzenle.jpg";
            pictureBox5.ImageLocation = Application.StartupPath + "\\resimler\\arsagöruntule.png";
            pictureBox6.ImageLocation = Application.StartupPath + "\\resimler\\gunlukgoruntule.png";
            pictureBox7.ImageLocation = Application.StartupPath + "\\resimler\\kiralıkgörüntüle.png";
            pictureBox8.ImageLocation = Application.StartupPath + "\\resimler\\satılıkgoruntule.png";
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.ImageLocation = Application.StartupPath + "\\resimler\\tıkla.png";
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
           pictureBox2.ImageLocation = Application.StartupPath + "\\resimler\\gunlukduzenle.png";
        }
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.ImageLocation = Application.StartupPath + "\\resimler\\tıkla.png";
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.ImageLocation = Application.StartupPath + "\\resimler\\kiralıkduzenle.jpg";
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.ImageLocation = Application.StartupPath + "\\resimler\\tıkla.png";
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.ImageLocation = Application.StartupPath + "\\resimler\\arsaduzenle.png";
        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox8.ImageLocation = Application.StartupPath + "\\resimler\\tıkla.png";
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
           pictureBox8.ImageLocation = Application.StartupPath + "\\resimler\\satılıkgoruntule.png";
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
           pictureBox7.ImageLocation = Application.StartupPath + "\\resimler\\tıkla.png";
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.ImageLocation = Application.StartupPath + "\\resimler\\kiralıkgörüntüle.png";
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
           pictureBox6.ImageLocation = Application.StartupPath + "\\resimler\\tıkla.png";
        }
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.ImageLocation = Application.StartupPath + "\\resimler\\tıkla.png";
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
           pictureBox5.ImageLocation = Application.StartupPath + "\\resimler\\arsagöruntule.png";
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
           pictureBox6.ImageLocation = Application.StartupPath + "\\resimler\\gunlukgoruntule.png";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            if (kulAdı == "admin")
            {

                krlkduzenle.ShowDialog();
            }
            else
            {
                MessageBox.Show("BURAYA ERİŞİM YETKİNİZ YOK !!");
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (kulAdı == "admin")
            {

                gnlukduzenle.ShowDialog();
            }
            else
            {
                MessageBox.Show("BURAYA ERİŞİM YETKİNİZ YOK !!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (kulAdı == "admin")
            {

                arsaduzenle.ShowDialog();
            }
            else
            {
                MessageBox.Show("BURAYA ERİŞİM YETKİNİZ YOK !!");
            }
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            stkgoruntule.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            krlgoruntule.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            grntleGunlukEv.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            arsagrntuleAl.ShowDialog();
        }

        private void pictbxkullanıcı_Click(object sender, EventArgs e)
        {
            if (kulAdı == "admin")
            {
                klekle.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("BURAYA ERİŞİM YETKİNİZ YOK !!");
            }
        }
    }
}
