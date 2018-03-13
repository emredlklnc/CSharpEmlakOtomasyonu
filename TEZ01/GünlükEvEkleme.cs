using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEZ01
{
    public partial class GünlükEvEkleme : Form
    {
        public GünlükEvEkleme()
        {
            InitializeComponent();
        }



        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        string resimYolu1;
        string resimYolu2;
        string resimYolu3;
        string resimYolu4;
        string resimYolu5;
        string resimYolu6;
        string resimYolu7;
        string resimYolu8;
        private void btnkaydet_Click(object sender, EventArgs e)
        {
           
            if (pictureBox1.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox2.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox3.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox4.ImageLocation == Application.StartupPath + "\\resim.png"|| pictureBox5.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox6.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox7.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox8.ImageLocation == Application.StartupPath + "\\resim.png")
            {
                MessageBox.Show("RESİMLER SEÇİLMEDEN KAYIT YAPILMAZ");
            }
            else
            {
              
                if (txtilanno.Text == "" || txtmetre.Text == "" || txtodasayısı.Text == "" || txtbinayas.Text == ""  || txtkat.Text == "" || txtfiyat.Text == "" || cmbtv.SelectedItem == null || cmbxısıtma.SelectedItem == null || txtadres.Text == "" || cmbxwifi.SelectedItem == null)
                {
                    MessageBox.Show("BÜTÜN ALANLAR DOLDURULMADAN KAYIT YAPILAMAZ !!");
                }
                else
                {
                    try
                    {
                        DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (secenek == DialogResult.Yes)
                        {
                            if (baglanti.State == ConnectionState.Closed)
                                baglanti.Open();
                            gunlukVerileriVeritabanınaKaydet();

                            //*********************************************************************************************************************
                            //bu kısımda farklı tabloya resımlerı eklettırdik


                            gunlukResimleriVeritabanınaKaydet();

                            MessageBox.Show("GUNLUK KAYIT İŞLEMİ GERÇEKLEŞTİRİLDİ.");
                            //************************************************************************************************************************
                            //ekranı temızleme kısmı
                            gunlukEkleTemizle();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("AYNI İLAN NUMARASINDA KAYIT BULUNMAKTA !!");
                    }

                }
            }
        }
        public void gunlukEkleTemizle()
        {

            txtadres.Text = "";
            txtbinayas.Text = "";
            txtfiyat.Text = "";
            txtilanno.Text = "";
            txtkat.Text = "";
            txtmetre.Text = "";
            txtodasayısı.Text = "";
            cmbtv.SelectedItem = null;
            cmbxısıtma.SelectedItem = null;
            cmbxwifi.SelectedItem = null;
            pictureBox1.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox2.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox3.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox4.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox5.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox6.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox7.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox8.ImageLocation = Application.StartupPath + "\\resim.png";
            lblrsmdurum.Text = "Seçilmedi";
            lblsecildi2.Text = "Seçilmedi";
            lblsecildi3.Text = "Seçilmedi";
            lblsecildi4.Text = "Seçilmedi";
            lblsecildi5.Text = "Seçilmedi";
            lblsecildi6.Text = "Seçilmedi";
            lblsecildi7.Text = "Seçilmedi";
            lblsecıldı8.Text = "Seçilmedi";
            lblrsmdurum.ForeColor = Color.Red;
            lblsecildi2.ForeColor = Color.Red;
            lblsecildi3.ForeColor = Color.Red;
            lblsecildi4.ForeColor = Color.Red;
            lblsecildi5.ForeColor = Color.Red;
            lblsecildi6.ForeColor = Color.Red;
            lblsecildi7.ForeColor = Color.Red;
            lblsecıldı8.ForeColor = Color.Red;

        }
        public void gunlukResimleriVeritabanınaKaydet()
        {
            FileStream fs1 = new FileStream(resimYolu1, FileMode.Open, FileAccess.Read);
            BinaryReader br1 = new BinaryReader(fs1);
            byte[] resim1 = br1.ReadBytes((int)fs1.Length);
            br1.Close();
            fs1.Close();

            FileStream fs2 = new FileStream(resimYolu2, FileMode.Open, FileAccess.Read);
            BinaryReader br2 = new BinaryReader(fs2);
            byte[] resim2 = br2.ReadBytes((int)fs2.Length);
            br2.Close();
            fs2.Close();

            FileStream fs3 = new FileStream(resimYolu3, FileMode.Open, FileAccess.Read);
            BinaryReader br3 = new BinaryReader(fs3);
            byte[] resim3 = br3.ReadBytes((int)fs3.Length);
            br3.Close();
            fs3.Close();

            FileStream fs4 = new FileStream(resimYolu4, FileMode.Open, FileAccess.Read);
            BinaryReader br4 = new BinaryReader(fs4);
            byte[] resim4 = br4.ReadBytes((int)fs4.Length);
            br4.Close();
            fs4.Close();

            FileStream fs5 = new FileStream(resimYolu5, FileMode.Open, FileAccess.Read);
            BinaryReader br5 = new BinaryReader(fs5);
            byte[] resim5 = br5.ReadBytes((int)fs5.Length);
            br5.Close();
            fs5.Close();

            FileStream fs6 = new FileStream(resimYolu6, FileMode.Open, FileAccess.Read);
            BinaryReader br6 = new BinaryReader(fs6);
            byte[] resim6 = br6.ReadBytes((int)fs6.Length);
            br6.Close();
            fs6.Close();

            FileStream fs7 = new FileStream(resimYolu7, FileMode.Open, FileAccess.Read);
            BinaryReader br7 = new BinaryReader(fs7);
            byte[] resim7 = br7.ReadBytes((int)fs7.Length);
            br7.Close();
            fs7.Close();

            FileStream fs8 = new FileStream(resimYolu8, FileMode.Open, FileAccess.Read);
            BinaryReader br8 = new BinaryReader(fs8);
            byte[] resim8 = br8.ReadBytes((int)fs8.Length);
            br8.Close();
            fs8.Close();


            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
            string kayit2 = "insert into gunlukResimler(ilanNo,resim1,resim2,resim3,resim4,resim5,resim6,resim7,resim8,ilanTarihi) values (@ilanNo,@resim1,@resim2,@resim3,@resim4,@resim5,@resim6,@resim7,@resim8,@İlantarih)";
            SqlCommand komut2 = new SqlCommand(kayit2, baglanti);

            komut2.Parameters.Add("@resim1", SqlDbType.Image, resim1.Length).Value = resim1;
            komut2.Parameters.Add("@resim2", SqlDbType.Image, resim2.Length).Value = resim2;
            komut2.Parameters.Add("@resim3", SqlDbType.Image, resim3.Length).Value = resim3;
            komut2.Parameters.Add("@resim4", SqlDbType.Image, resim4.Length).Value = resim4;
            komut2.Parameters.Add("@resim5", SqlDbType.Image, resim5.Length).Value = resim5;
            komut2.Parameters.Add("@resim6", SqlDbType.Image, resim6.Length).Value = resim6;
            komut2.Parameters.Add("@resim7", SqlDbType.Image, resim7.Length).Value = resim7;
            komut2.Parameters.Add("@resim8", SqlDbType.Image, resim8.Length).Value = resim8;
            komut2.Parameters.AddWithValue("@İlantarih", DateTime.Now.ToShortDateString().ToString());
            komut2.Parameters.AddWithValue("@ilanNo", txtilanno.Text);

            komut2.ExecuteNonQuery();
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            baglanti.Close();
        }
        public void gunlukVerileriVeritabanınaKaydet()
        {
            // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
            string kayit = "insert into gunlukEv(ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,fiyat,adres,ilanNo,tv,wifi) values (@tarih,@metrekare,@odasayısı,@binayası,@kat,@ısıtma,@fiyat,@adres,@ilanNo,@tv,@wifi)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);


            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString().ToString());
            komut.Parameters.AddWithValue("@metrekare", txtmetre.Text);
            komut.Parameters.AddWithValue("@odasayısı", txtodasayısı.Text);
            komut.Parameters.AddWithValue("@binayası", txtbinayas.Text);
            komut.Parameters.AddWithValue("@kat", txtkat.Text);
            komut.Parameters.AddWithValue("@ısıtma", cmbxısıtma.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@tv", cmbtv.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@wifi", cmbxwifi.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@fiyat", txtfiyat.Text);
            komut.Parameters.AddWithValue("@adres", txtadres.Text);
            komut.Parameters.AddWithValue("@ilanNo", txtilanno.Text);
            // komut.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;

            komut.ExecuteNonQuery();
            
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            baglanti.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu == "")
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\resim.png";
                lblrsmdurum.Text = "Seçilmedi.";
                lblrsmdurum.ForeColor = Color.Red;
            }
            else
            {
                pictureBox1.ImageLocation = DosyaYolu;
                resimYolu1 = DosyaYolu;
                lblrsmdurum.Text = "Seçildi.";
                lblrsmdurum.ForeColor = Color.Green;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu == "")
            {
                pictureBox2.ImageLocation = Application.StartupPath + "\\resim.png";
                lblsecildi2.Text = "Seçilmedi.";
                lblsecildi2.ForeColor = Color.Red;
            }
            else
            {
                pictureBox2.ImageLocation = DosyaYolu;
                resimYolu2 = DosyaYolu;
                lblsecildi2.Text = "Seçildi.";
                lblsecildi2.ForeColor = Color.Green;
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu == "")
            {
                pictureBox3.ImageLocation = Application.StartupPath + "\\resim.png";
                lblsecildi3.Text = "Seçilmedi.";
                lblsecildi3.ForeColor = Color.Red;
            }
            else
            {
                pictureBox3.ImageLocation = DosyaYolu;
                resimYolu3 = DosyaYolu;
                lblsecildi3.Text = "Seçildi.";
                lblsecildi3.ForeColor = Color.Green;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu == "")
            {
                pictureBox4.ImageLocation = Application.StartupPath + "\\resim.png";
                lblsecildi4.Text = "Seçilmedi.";
                lblsecildi4.ForeColor = Color.Red;
            }
            else
            {
                pictureBox4.ImageLocation = DosyaYolu;
                resimYolu4 = DosyaYolu;
                lblsecildi4.Text = "Seçildi.";
                lblsecildi4.ForeColor = Color.Green;
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu == "")
            {
                pictureBox5.ImageLocation = Application.StartupPath + "\\resim.png";
                lblsecildi5.Text = "Seçilmedi.";
                lblsecildi5.ForeColor = Color.Red;
            }
            else
            {
                pictureBox5.ImageLocation = DosyaYolu;
                resimYolu5= DosyaYolu;
                lblsecildi5.Text = "Seçildi.";
                lblsecildi5.ForeColor = Color.Green;
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu == "")
            {
                pictureBox6.ImageLocation = Application.StartupPath + "\\resim.png";
                lblsecildi6.Text = "Seçilmedi.";
                lblsecildi6.ForeColor = Color.Red;
            }
            else
            {
                pictureBox6.ImageLocation = DosyaYolu;
                resimYolu6 = DosyaYolu;
                lblsecildi6.Text = "Seçildi.";
                lblsecildi6.ForeColor = Color.Green;
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu == "")
            {
                pictureBox7.ImageLocation = Application.StartupPath + "\\resim.png";
                lblsecildi7.Text = "Seçilmedi.";
                lblsecildi7.ForeColor = Color.Red;
            }
            else
            {
                pictureBox7.ImageLocation = DosyaYolu;
                resimYolu7 = DosyaYolu;
                lblsecildi7.Text = "Seçildi.";
                lblsecildi7.ForeColor = Color.Green;
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu == "")
            {
                pictureBox8.ImageLocation = Application.StartupPath + "\\resim.png";
                lblsecıldı8.Text = "Seçilmedi.";
                lblsecıldı8.ForeColor = Color.Red;
            }
            else
            {
                pictureBox8.ImageLocation = DosyaYolu;
                resimYolu8= DosyaYolu;
                lblsecıldı8.Text = "Seçildi.";
                lblsecıldı8.ForeColor = Color.Green;
            }
        }

        private void HarfGırısEngelle(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtilanno_Validated(object sender, EventArgs e)
        {
            if (txtilanno.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtilanno, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtilanno, "");
        }

        private void txtmetre_Validated(object sender, EventArgs e)
        {

            if (txtmetre.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtmetre, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtmetre, "");
        }

        private void txtodasayısı_Validated(object sender, EventArgs e)
        {
            if (txtodasayısı.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtodasayısı, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtodasayısı, "");
        }

        private void txtbinayas_Validated(object sender, EventArgs e)
        {
            if (txtbinayas.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtbinayas, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtbinayas, "");
        }

        private void txtkat_Validated(object sender, EventArgs e)
        {
            if (txtkat.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtkat, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtkat, "");
        }

        private void cmbxwifi_Validated(object sender, EventArgs e)
        {

            if (cmbxwifi.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(cmbxwifi, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(cmbxwifi, "");
        }

        private void cmbtv_Validated(object sender, EventArgs e)
        {

            if (cmbtv.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(cmbtv, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(cmbtv, "");
        }

        private void cmbxısıtma_Validated(object sender, EventArgs e)
        {

            if (cmbxısıtma.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(cmbxısıtma, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(cmbxısıtma, "");
        }

        private void txtfiyat_Validated(object sender, EventArgs e)
        {
            if (txtfiyat.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtfiyat, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtfiyat, "");
        }

        private void txtadres_Validated(object sender, EventArgs e)
        {
            if (txtadres.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtadres, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtadres, "");
        }
    }
}
