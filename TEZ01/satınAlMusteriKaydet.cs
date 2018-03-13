using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TEZ01
{
    public partial class satınAlMusteriKaydet : Form
    {
        public satınAlMusteriKaydet()
        {
            InitializeComponent();
        }
        public string ilanNo { get; set; }
        public bool kiralık { get; set; }
        public bool satılık { get; set; }
        public bool arsa { get; set; }
        public bool gunluk { get; set; }

        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public string ad;
        public string soyad;
        public int güvenlikKodu;
        string metinselGüvenlikKodu;
        string yenilenenMetinselGüvenlikKodu;
        
        private void satınAlMusteriKaydet_Load(object sender, EventArgs e)
        {
            if (satılık == true)
            {
                btnsatınal.Text = "SATIN AL";
            }
            else if (kiralık == true)
            {
                btnsatınal.Text = "KİRALA";
            }
            else if (gunluk == true)
            {
                btnsatınal.Text = "GÜNLÜK KİRALA";
            }
            else if (arsa == true)
            {
                btnsatınal.Text = "ARSAYI AL";
            }

            txtGüvenlikKodu.MaxLength = 4;


            Random rnd_rastgeleGüvenlikKodu = new Random();

            int sayisalGüvenlikKodu;

            int[] diziGüvenlikKodu = new int[4];

            int artim = 0;

            for (int i = 1; i <= 4; i++)
            {
                sayisalGüvenlikKodu = rnd_rastgeleGüvenlikKodu.Next(1, 10);
                diziGüvenlikKodu[artim] = sayisalGüvenlikKodu;
                ++artim;
            }

            metinselGüvenlikKodu = diziGüvenlikKodu[0].ToString() + diziGüvenlikKodu[1].ToString() + diziGüvenlikKodu[2].ToString() + diziGüvenlikKodu[3].ToString();
        }

      

        private void btnguvenlıkkodu_Click(object sender, EventArgs e)
        {
            txtGüvenlikKodu.Clear();

            Random rnd_rastgeleGüvenlikKodu = new Random();

            int sayisalGüvenlikKodu;

            int[] diziGüvenlikKodu = new int[4];

            int artim = 0;

            for (int i = 1; i <= 4; i++)
            {
                sayisalGüvenlikKodu = rnd_rastgeleGüvenlikKodu.Next(1, 10);
                diziGüvenlikKodu[artim] = sayisalGüvenlikKodu;
                ++artim;
            }

            yenilenenMetinselGüvenlikKodu = diziGüvenlikKodu[0].ToString() + diziGüvenlikKodu[1].ToString() + diziGüvenlikKodu[2].ToString() + diziGüvenlikKodu[3].ToString();

            Graphics grp = panel2.CreateGraphics();

            grp.Clear(Color.White);

            grp.SmoothingMode = SmoothingMode.AntiAlias;
            grp.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.WhiteSmoke, Color.CornflowerBlue), new Rectangle(0, 0, 85, 33));

            Font drawFont = new Font("Comic Sans MS", 20, FontStyle.Bold, GraphicsUnit.Point);

            SolidBrush drawBrush = new SolidBrush(Color.White);

            grp.DrawString(yenilenenMetinselGüvenlikKodu.ToString(), drawFont, drawBrush, 0, 0);

            grp.Dispose();
            drawFont.Dispose();
            drawBrush.Dispose();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics grp = e.Graphics;
            grp.SmoothingMode = SmoothingMode.AntiAlias;
            grp.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.WhiteSmoke, Color.CornflowerBlue), new Rectangle(0, 0, 85, 33));

            Font drawFont = new Font("Comic Sans MS", 20, FontStyle.Bold, GraphicsUnit.Point);

            SolidBrush drawBrush = new SolidBrush(Color.White);

            grp.DrawString(metinselGüvenlikKodu.ToString(), drawFont, drawBrush, 0, 0);

            grp.Dispose();
            drawFont.Dispose();
            drawBrush.Dispose();
        }
        Decimal MusteriTc = 0;
        private void btnsatınal_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            
            try
            {
                if (String.IsNullOrWhiteSpace(txttc.Text) || String.IsNullOrWhiteSpace(txtsoyad.Text) || String.IsNullOrWhiteSpace(txtad.Text) || String.IsNullOrWhiteSpace(txteposta.Text) || String.IsNullOrWhiteSpace(txtepostatekrar.Text) || String.IsNullOrWhiteSpace(txtGüvenlikKodu.Text))
                {
                    MessageBox.Show("Giriş Başarısız!Eksiksiz Giriniz!", "..::HATA ::.."); /*textboxların doluluğunu kontrol ediyoruz */
                }
                else
                {
                    if (checkboxsozlesme.Checked == true)
                    {

                        güvenlikKodu = Convert.ToUInt16(txtGüvenlikKodu.Text);

                        if (((güvenlikKodu.ToString() == metinselGüvenlikKodu) || (güvenlikKodu.ToString() == yenilenenMetinselGüvenlikKodu)))
                        {
                            int kod = rnd.Next(10000, 90000);
                            string eposta = txteposta.Text.ToString();


                            var fromAddress = new MailAddress("emredlklnc@gmail.com");
                            var fromPassword = "65866253168";
                            var toAddress = new MailAddress(eposta);
                            string subject = "E POSTA ONAYLAMA";
                            string body = "E Posta Onay Kodu :" + kod.ToString();
                            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                            };
                            using (var message = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = body
                            })
                                smtp.Send(message);

                            string KullanıcıOnaykodu = Interaction.InputBox("E POSTA ONAY KODU GÖNDERİLDİ", "ONAY KODUNU GİRİNİZ.", "...", 100, 100);
                            if (KullanıcıOnaykodu == kod.ToString())
                            {

                                SqlConnection connec = new SqlConnection(baglanti.ConnectionString);
                                SqlCommand cmd = new SqlCommand("select * from Musteriler where tc=@tc", connec);
                                cmd.Parameters.AddWithValue("@tc", txttc.Text);

                                if (connec.State != ConnectionState.Open)
                                    connec.Open();

                                SqlDataReader dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    MusteriTc = Convert.ToDecimal(dr["tc"]);
                                    connec.Close();
                                }
                                else
                                {
                                    if (baglanti.State == ConnectionState.Closed)
                                        baglanti.Open();
                                    string kayit = "insert into Musteriler(tc,ad,soyad,ePosta) values (@tc,@ad,@soyad,@ePosta)";
                                    SqlCommand komut = new SqlCommand(kayit, baglanti);

                                    komut.Parameters.AddWithValue("@tc", txttc.Text);
                                    komut.Parameters.AddWithValue("@ad", txtad.Text);
                                    komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                                    komut.Parameters.AddWithValue("@ePosta", txteposta.Text);

                                    // komut.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;

                                    komut.ExecuteNonQuery();
                                    //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                                    baglanti.Close();
                                    MusteriTc = Convert.ToDecimal(txttc.Text);
                                }

                                TablolarıGuncelle();
                                MessageBox.Show("İŞLEM GERÇEKLEŞTİRİLDİ");
                                Temizle();


                           }
                            else
                            {
                                MessageBox.Show("KOD DOGRU DEGİL");
                            }
                        }

                        #region Güvenlik Kodu Kontrolü

                        if (((güvenlikKodu.ToString() != metinselGüvenlikKodu) || (güvenlikKodu.ToString() != yenilenenMetinselGüvenlikKodu)))
                            errorProvider1.SetError(txtGüvenlikKodu, "Güvenlik Kodu'nu doğru giriniz.");

                        if (((güvenlikKodu.ToString() == metinselGüvenlikKodu) || (güvenlikKodu.ToString() == yenilenenMetinselGüvenlikKodu)))
                            errorProvider1.Clear();

                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("SÖZLEŞMEYİ OKUYUP KABUL ETMEDEN SATIN ALMA İŞLEMİ YAPILAMAZ !");
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("İŞLEM GERÇEKLEŞTİRİLEMEDİ İNTERNET BAGLANTINZI KONTROL EDİN ");
            }
            
        }
        public void TablolarıGuncelle()
        {

            if (satılık==true)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu = "update satılık set kontratTarihi=@kontratTarihi,satıldı=@satıldı,MusteriTc=@MusteriTc where ilanNo=@ilanNo";
                SqlCommand cmd2 = new SqlCommand(sorgu, baglanti);
                cmd2.Parameters.AddWithValue("@kontratTarihi", DateTime.Now.ToShortDateString());
                cmd2.Parameters.AddWithValue("@satıldı", true);
                cmd2.Parameters.AddWithValue("@MusteriTc", MusteriTc);
                cmd2.Parameters.AddWithValue("@ilanNo", Convert.ToInt32(ilanNo));
                cmd2.ExecuteNonQuery();
                baglanti.Close();


                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu3 = "update Resimler set musteriTc=@musteriTc where ilanNo=@ilanNo";
                SqlCommand cmd3 = new SqlCommand(sorgu3, baglanti);
                cmd3.Parameters.AddWithValue("@musteriTc", MusteriTc);
                cmd3.Parameters.AddWithValue("@ilanNo", Convert.ToInt32(ilanNo));
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (kiralık==true)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu = "update kiralık set kontratTarihi=@kontratTarihi,kiralandı=@kiralandı,MusteriTc=@MusteriTc where ilanNo=@ilanNo";
                SqlCommand cmd2 = new SqlCommand(sorgu, baglanti);
                cmd2.Parameters.AddWithValue("@kontratTarihi", DateTime.Now.ToShortDateString());
                cmd2.Parameters.AddWithValue("@kiralandı", true);
                cmd2.Parameters.AddWithValue("@MusteriTc", MusteriTc);
                cmd2.Parameters.AddWithValue("@ilanNo", Convert.ToInt32(ilanNo));
                cmd2.ExecuteNonQuery();
                baglanti.Close();


                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu3 = "update ResimlerKiralık set musteriTc=@musteriTc where ilanNo=@ilanNo";
                SqlCommand cmd3 = new SqlCommand(sorgu3, baglanti);
                cmd3.Parameters.AddWithValue("@musteriTc", MusteriTc);
                cmd3.Parameters.AddWithValue("@ilanNo", Convert.ToInt32(ilanNo));
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (gunluk==true)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu = "update gunlukEv set kontratTarihi=@kontratTarihi,kiralandıGunluk=@kiralandıGunluk,MusteriTc=@MusteriTc where ilanNo=@ilanNo";
                SqlCommand cmd2 = new SqlCommand(sorgu, baglanti);
                cmd2.Parameters.AddWithValue("@kontratTarihi", DateTime.Now.ToShortDateString());
                cmd2.Parameters.AddWithValue("@kiralandıGunluk", true);
                cmd2.Parameters.AddWithValue("@MusteriTc", MusteriTc);
                cmd2.Parameters.AddWithValue("@ilanNo", Convert.ToInt32(ilanNo));
                cmd2.ExecuteNonQuery();
                baglanti.Close();


                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu3 = "update gunlukResimler set musteriTc=@musteriTc where ilanNo=@ilanNo";
                SqlCommand cmd3 = new SqlCommand(sorgu3, baglanti);
                cmd3.Parameters.AddWithValue("@musteriTc", MusteriTc);
                cmd3.Parameters.AddWithValue("@ilanNo", Convert.ToInt32(ilanNo));
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (arsa==true)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu = "update Arsa set kontratTarihi=@kontratTarihi,satıldıArsa=@satıldıArsa,MusteriTc=@MusteriTc where ilanNo=@ilanNo";
                SqlCommand cmd2 = new SqlCommand(sorgu, baglanti);
                cmd2.Parameters.AddWithValue("@kontratTarihi", DateTime.Now.ToShortDateString());
                cmd2.Parameters.AddWithValue("@satıldıArsa", true);
                cmd2.Parameters.AddWithValue("@MusteriTc", MusteriTc);
                cmd2.Parameters.AddWithValue("@ilanNo", Convert.ToInt32(ilanNo));
                cmd2.ExecuteNonQuery();
                baglanti.Close();


                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu3 = "update ArsaResimler set musteriTc=@musteriTc where ilanNo=@ilanNo";
                SqlCommand cmd3 = new SqlCommand(sorgu3, baglanti);
                cmd3.Parameters.AddWithValue("@musteriTc", MusteriTc);
                cmd3.Parameters.AddWithValue("@ilanNo", Convert.ToInt32(ilanNo));
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            


        }
        public void Temizle()
        {
            txtad.Text = "";
            txteposta.Text = "";
            txtepostatekrar.Text = "";
            txtGüvenlikKodu.Text = "";
            txtsoyad.Text = "";
            txttc.Text = "";

        }

        private void HarfEngelle(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            gizlilikPolitikası gzl = new gizlilikPolitikası();
            gzl.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            sozlesme szlesme = new sozlesme();
            szlesme.ShowDialog();

        }

        private void txttc_Validated(object sender, EventArgs e)
        {
            if (txttc.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txttc, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txttc, "");
        }

        private void txtad_Validated(object sender, EventArgs e)
        {

            if (txtad.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtad, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtad, "");
        }

        private void txtsoyad_Validated(object sender, EventArgs e)
        {
            if (txtsoyad.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtsoyad, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtsoyad, "");
        }

        private void txteposta_Validated(object sender, EventArgs e)
        {
            if (txteposta.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txteposta, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txteposta, "");
        }

        private void txtepostatekrar_Validated(object sender, EventArgs e)
        {
            if (txtepostatekrar.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtepostatekrar, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtepostatekrar, "");

        }

        private void txtGüvenlikKodu_Validated(object sender, EventArgs e)
        {
            if (txtGüvenlikKodu.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtGüvenlikKodu, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtGüvenlikKodu, "");
        }
    }
}
