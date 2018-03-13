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
using System.Net.Mail;
using System.Net;
namespace TEZ01
{
    public partial class SifreUnuttum : Form
    {
        public SifreUnuttum()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        private void btngonder_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txteposta.Text) && String.IsNullOrWhiteSpace(txtkuladı.Text))
            {
                MessageBox.Show("Şifre Yenileme Başarısız!Eksiksiz Giriniz!", "..::HATA ::.."); /*textboxların doluluğunu kontrol ediyoruz */
            }
            else
            {
                try
                {
                    baglanti.Open();
                    SqlCommand cmd2 = new SqlCommand("select Sifre from Kullanıcılar where KullanıcıAdı=@veri2 and eposta=@veri3", baglanti);
                    cmd2.Parameters.AddWithValue("@veri2", txtkuladı.Text);
                    cmd2.Parameters.AddWithValue("@veri3", txteposta.Text);
                    SqlDataReader dr = cmd2.ExecuteReader();
                    if (dr.Read())
                    {
                       
                        string sifre = dr["Sifre"].ToString();
                        string eposta = txteposta.Text.ToString();


                        var fromAddress = new MailAddress("emredlklnc@gmail.com");
                        var fromPassword = "65866253168";
                        var toAddress = new MailAddress(eposta);                        
                        string subject = "Şifre Kurtarma";
                        string body = "Şifreniz :"+sifre;
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
                        MessageBox.Show("Şifreniz Mail Adresinize Gönderilmiştir");
                        txteposta.Text = "";
                        txtkuladı.Text = "";
                    } 
                    else
                    {
                        MessageBox.Show("E Posta Veye Kullanıcı Adı Hatalı!!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                baglanti.Close();
            }

       }

        private void txteposta_Validated(object sender, EventArgs e)
        {
            if (txteposta.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txteposta, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txteposta, "");
        }

        private void txtkuladı_Validated(object sender, EventArgs e)
        {
            if (txtkuladı.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtkuladı, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtkuladı, "");
        }
    }
}
