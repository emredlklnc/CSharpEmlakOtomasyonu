using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TEZ01
{
    public partial class KullanıcıEkle : Form
    {
        public KullanıcıEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
            string kayit = "insert into Kullanıcılar(KullanıcıAdı,Sifre,eposta) values (@KullanıcıAdı,@Sifre,@eposta)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@KullanıcıAdı",textBox1.Text);
            komut.Parameters.AddWithValue("@Sifre", textBox2.Text);
            komut.Parameters.AddWithValue("@eposta",textBox3.Text);
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                if (textBox1.Text.ToLower()=="admin")
                {
                    MessageBox.Show("ADMİN EKLEMESİ YAPAMAZSINIZ");
                    textBox1.Text = "";
                }
                else
                {
                    komut.ExecuteNonQuery();
                    MessageBox.Show("KAYIT BAŞARILI ");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
               
            }
            else
            {
                MessageBox.Show("KAYIT YAPILAMADI");
            }
            baglanti.Close();
        }
    }
}
