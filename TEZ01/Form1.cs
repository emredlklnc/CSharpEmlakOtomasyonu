using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TEZ01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Bildirimler & Tanımlamalar

        Form2 frm2 = new Form2();
        public string ad;
        public string soyad;
        public int güvenlikKodu;
        string metinselGüvenlikKodu;
        string yenilenenMetinselGüvenlikKodu;
        #endregion
        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtAd.CharacterCasing = CharacterCasing.Upper;
            //txtSifre.CharacterCasing = CharacterCasing.Upper;
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
        SifreUnuttum sfrunuttum = new SifreUnuttum();

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics grp = e.Graphics;
            grp.SmoothingMode = SmoothingMode.AntiAlias;
            grp.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.WhiteSmoke, Color.CornflowerBlue), new Rectangle(0, 0, 79, 33));

            Font drawFont = new Font("Comic Sans MS", 20, FontStyle.Bold, GraphicsUnit.Point);

            SolidBrush drawBrush = new SolidBrush(Color.White);

            grp.DrawString(metinselGüvenlikKodu.ToString(), drawFont, drawBrush, 0, 0);

            grp.Dispose();
            drawFont.Dispose();
            drawBrush.Dispose();
        }

        private void btnGüvenlikKoduYenile_Click_1(object sender, EventArgs e)
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

            Graphics grp = panel3.CreateGraphics();

            grp.Clear(Color.White);

            grp.SmoothingMode = SmoothingMode.AntiAlias;
            grp.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.WhiteSmoke, Color.CornflowerBlue), new Rectangle(0, 0, 79, 33));

            Font drawFont = new Font("Comic Sans MS", 20, FontStyle.Bold, GraphicsUnit.Point);

            SolidBrush drawBrush = new SolidBrush(Color.White);

            grp.DrawString(yenilenenMetinselGüvenlikKodu.ToString(), drawFont, drawBrush, 0, 0);

            grp.Dispose();
            drawFont.Dispose();
            drawBrush.Dispose();
        }

        private void btnGirisYap_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtAd.Text) && String.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Giriş Başarısız!Eksiksiz Giriniz!", "..::HATA ::.."); /*textboxların doluluğunu kontrol ediyoruz */
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT* FROM Kullanıcılar WHERE KullanıcıAdı= @KAdi AND Sifre = @KSifre";
                    SqlParameter prms1 = new SqlParameter("@KAdi", txtAd.Text);
                    SqlParameter prms2 = new SqlParameter("@KSifre", txtSifre.Text);
                    SqlCommand cmd = new SqlCommand(sql, baglanti);
                    cmd.Parameters.Add(prms1);
                    cmd.Parameters.Add(prms2);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count != 0)
                    {
                        baglanti.Close();
                        //MessageBox.Show("GİRİŞ YAPILDIMI TEST ETMEK ICIN KOYULDU");
                        try
                        {

                            güvenlikKodu = Convert.ToUInt16(txtGüvenlikKodu.Text);

                            if (((güvenlikKodu.ToString() == metinselGüvenlikKodu) || (güvenlikKodu.ToString() == yenilenenMetinselGüvenlikKodu)))
                            {
                                if (txtAd.Text.ToLower()=="admin")
                                {
                                    frm2.kulAdı = "admin";
                                    this.Hide();
                                    frm2.ShowDialog();
                                }
                                else
                                {
                                    frm2.kulAdı = txtAd.Text;
                                    this.Hide();
                                    frm2.ShowDialog();
                                }
                               
                            }

                            #region Güvenlik Kodu Kontrolü

                            if (((güvenlikKodu.ToString() != metinselGüvenlikKodu) || (güvenlikKodu.ToString() != yenilenenMetinselGüvenlikKodu)))
                                errorProvider1.SetError(txtGüvenlikKodu, "Güvenlik Kodu'nu doğru giriniz.");

                            if (((güvenlikKodu.ToString() == metinselGüvenlikKodu) || (güvenlikKodu.ToString() == yenilenenMetinselGüvenlikKodu)))
                                errorProvider1.Clear();

                            #endregion

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        baglanti.Close();
                        MessageBox.Show("Yanlış Kullanıcı Ve Şifre", "..::HATA::..");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnSıfreUnttum_Click_1(object sender, EventArgs e)
        {
            sfrunuttum.ShowDialog();
        }
    }
}
