using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;

namespace TEZ01
{
    public partial class SatılıkEkle : Form
    {
        public SatılıkEkle()
        {
            InitializeComponent();
        }

        
        string resimYolu1;
        string resimYolu2;
        string resimYolu3;
        string resimYolu4;

        string GuncelleResimYolu1;
        string GuncelleResimYolu2;
        string GuncelleResimYolu3;
        string GuncelleResimYolu4;

        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        
        
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (pictureBox1.ImageLocation== Application.StartupPath + "\\resim.png" || pictureBox2.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox3.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox4.ImageLocation == Application.StartupPath + "\\resim.png")
            {
                MessageBox.Show("RESİMLER SEÇİLMEDEN KAYIT YAPILMAZ");
            }
            else
            {
               /* FileStream fs = new FileStream(resimYolu, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            */
                if (txtilanno.Text == "" || txtmetre.Text == "" || txtodasayısı.Text == "" || txtbinayas.Text == "" || txtaidat.Text == "" || txtkat.Text == "" || txtfiyat.Text == "" || cmbxesyalı.SelectedItem == null || cmbxısıtma.SelectedItem == null || txtadres.Text == ""||cmbxtur.SelectedItem==null)
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

                                satılıkVerileriVeritabanınaKaydet();
                                satılıkResimleriVeritabanınaKaydet();

                                MessageBox.Show("SATILIK KONUT KAYIT İŞLEMİ GERÇEKLEŞTİRİLDİ.");
                                satılıkEkleTemizle();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("AYNI İLAN NUMARASINDA KAYIT BULUNMAKTA !!");
                        }

                }
            }
           
        }
        public void satılıkEkleTemizle()
        {
            
            txtadres.Text = "";
            txtaidat.Text = "";
            txtbinayas.Text = "";
            txtfiyat.Text = "";
            txtilanno.Text = "";
            txtkat.Text = "";
            txtmetre.Text = "";
            txtodasayısı.Text = "";
            cmbxesyalı.SelectedItem = null;
            cmbxısıtma.SelectedItem = null;
            cmbxtur.SelectedItem = null;
            pictureBox1.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox2.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox3.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox4.ImageLocation = Application.StartupPath + "\\resim.png";
            lblrsmdurum.Text = "Seçilmedi";
            lblsecildi2.Text = "Seçilmedi";
            lblsecildi3.Text = "Seçilmedi";
            lblsecildi4.Text = "Seçilmedi";
            lblrsmdurum.ForeColor = Color.Red;
            lblsecildi2.ForeColor = Color.Red;
            lblsecildi3.ForeColor = Color.Red;
            lblsecildi4.ForeColor = Color.Red;

        }
        public void satılıkResimleriVeritabanınaKaydet()
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

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
            string kayit2 = "insert into Resimler(ilanNo,resim1,resim2,resim3,resim4,ilanTarihi) values (@ilanNo,@resim1,@resim2,@resim3,@resim4,@İlantarih)";
            SqlCommand komut2 = new SqlCommand(kayit2, baglanti);

            komut2.Parameters.Add("@resim1", SqlDbType.Image, resim1.Length).Value = resim1;
            komut2.Parameters.Add("@resim2", SqlDbType.Image, resim2.Length).Value = resim2;
            komut2.Parameters.Add("@resim3", SqlDbType.Image, resim3.Length).Value = resim3;
            komut2.Parameters.Add("@resim4", SqlDbType.Image, resim4.Length).Value = resim4;
            komut2.Parameters.AddWithValue("@İlantarih", DateTime.Now.ToShortDateString().ToString());
            komut2.Parameters.AddWithValue("@ilanNo", txtilanno.Text);

            komut2.ExecuteNonQuery();
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            baglanti.Close();
        }
        public void satılıkVerileriVeritabanınaKaydet()
        {
            // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
            string kayit = "insert into satılık(ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur) values (@tarih,@metrekare,@odasayısı,@binayası,@kat,@ısıtma,@esyalı,@aidat,@fiyat,@adres,@ilanNo,@tur)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);


            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString().ToString());
            komut.Parameters.AddWithValue("@metrekare", txtmetre.Text);
            komut.Parameters.AddWithValue("@odasayısı", txtodasayısı.Text);
            komut.Parameters.AddWithValue("@binayası", txtbinayas.Text);
            komut.Parameters.AddWithValue("@kat", txtkat.Text);
            komut.Parameters.AddWithValue("@ısıtma", cmbxısıtma.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@esyalı", cmbxesyalı.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@aidat", txtaidat.Text);
            komut.Parameters.AddWithValue("@tur", cmbxtur.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@fiyat", txtfiyat.Text);
            komut.Parameters.AddWithValue("@adres", txtadres.Text);
            komut.Parameters.AddWithValue("@ilanNo", txtilanno.Text);
            // komut.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;

            komut.ExecuteNonQuery();
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            baglanti.Close();

        }
        private void SatılıkEkle_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox2.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox3.ImageLocation = Application.StartupPath + "\\resim.png";
            pictureBox4.ImageLocation = Application.StartupPath + "\\resim.png";
  
            lblrsmdurum.Text = "Seçilmedi";
            lblsecildi2.Text = "Seçilmedi";
            lblsecildi3.Text = "Seçilmedi";
            lblsecildi4.Text = "Seçilmedi";
            lblrsmdurum.ForeColor = Color.Red;
            lblsecildi2.ForeColor = Color.Red;
            lblsecildi3.ForeColor = Color.Red;
            lblsecildi4.ForeColor = Color.Red;
            lbltarih.Text = DateTime.Now.ToShortDateString();
            label28.Text= DateTime.Now.ToShortDateString();

            toolTip1.SetToolTip(btnresimuyarı, "RESİM DEGİŞTİRMEK İÇİN RESMİN ÜZERİNE TIKLA "); //mesajın yazıldığı yer
            toolTip1.ToolTipTitle = "BİLGİ MESAJI"; // mesajın başlığının yazıldığı yer
            toolTip1.ToolTipIcon = ToolTipIcon.Info; // mesajın ikonunun ayarlandığı yer
            toolTip1.IsBalloon = true;// bu kodu yazmazsak mesaj dikdörtgen şeklinde görünür.

            toolTip2.SetToolTip(btnresımguncelleuyarı, "RESİMLERİ GÜNCELLEMEK İÇİN TÜM RESİMLERİ DEGİŞTİRMEN GEREKİR !!"); //mesajın yazıldığı yer
            toolTip2.ToolTipTitle = "UYARI MESAJI !!"; // mesajın başlığının yazıldığı yer
            toolTip2.ToolTipIcon = ToolTipIcon.Info; // mesajın ikonunun ayarlandığı yer
            toolTip2.IsBalloon = true;// bu kodu yazmazsak mesaj dikdörtgen şeklinde görünür.

        }

        private void txtmetre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtodasayısı_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtbinayas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtaidat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtkat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtfiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmetre_Validated(object sender, EventArgs e)
        {
            if (txtmetre.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtmetre, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtmetre, "");
        }

        private void txtilanno_Validated(object sender, EventArgs e)
        {
            if (txtilanno.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtilanno, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtilanno, "");
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

        private void txtaidat_Validated(object sender, EventArgs e)
        {
            if (txtaidat.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtaidat, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtaidat, "");
        }

        private void txtkat_Validated(object sender, EventArgs e)
        {
            if (txtkat.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtkat, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtkat, "");
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

        private void cmbxesyalı_Validated(object sender, EventArgs e)
        {
            if (cmbxesyalı.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(cmbxesyalı, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(cmbxesyalı, "");
        }
        private void cmbxtur_Validated(object sender, EventArgs e)
        {
            if (cmbxtur.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(cmbxtur, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(cmbxtur, "");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "dalkılınçEMLAK";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;

            if (DosyaYolu=="")
            {
                pictureBox1.ImageLocation = Application.StartupPath +"\\resim.png";
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
            OpenFileDialog dosya2 = new OpenFileDialog();
            dosya2.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya2.Title = "dalkılınçEMLAK";
            dosya2.ShowDialog();
            string DosyaYolu = dosya2.FileName;
            if (DosyaYolu == "")
            {
                pictureBox2.ImageLocation = Application.StartupPath +"\\resim.png";
                lblsecildi2.Text = "Seçilmedi";
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
            OpenFileDialog dosya3 = new OpenFileDialog();
            dosya3.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya3.Title = "dalkılınçEMLAK";
            dosya3.ShowDialog();
            string DosyaYolu = dosya3.FileName;
            if (DosyaYolu == "")
            {
                pictureBox3.ImageLocation = Application.StartupPath +"\\resim.png";
                lblsecildi3.Text = "Seçilmedi";
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
            OpenFileDialog dosya4 = new OpenFileDialog();
            dosya4.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya4.Title = "dalkılınçEMLAK";
            dosya4.ShowDialog();
            string DosyaYolu = dosya4.FileName;
            if (DosyaYolu == "")
            {
                pictureBox4.ImageLocation = Application.StartupPath +"\\resim.png";
                lblsecildi4.Text = "Seçilmedi";
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

        private void button1_Click(object sender, EventArgs e)
        {
          if (txtbulNo.Text=="")
          {
                MessageBox.Show("İLAN NUMARASI GİRMELİSİN TAKVİMDEN TARİHE GÖREDE DE SEÇEBİLİRSİN");
          }
          else
          {

                satılkGuncelleVeriTabanındanVerileriCek();
                //**********************************************************************************************************************
                //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur
                satılıkGuncelleVeriTabanındanResımCek();
         }
            //***************************************************************************************************************************
        }
        public void satılıkGuncelleVeriTabanındanResımCek()
        {
            SqlConnection conresımgetir = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdresimgetir = new SqlCommand("select * from Resimler where ilanNo=@RsmİlanNo", conresımgetir);
            cmdresimgetir.Parameters.AddWithValue("@RsmİlanNo", txtbulNo.Text);

            try
            {

                if (conresımgetir.State != ConnectionState.Open)
                    conresımgetir.Open();

                SqlDataReader dr = cmdresimgetir.ExecuteReader();

                if (dr.Read())
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dr["resim1"]);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox5.Image = Image.FromStream(mem);
                    mem.Close();

                    Byte[] data2 = new Byte[1];
                    data2 = (Byte[])(dr["resim2"]);
                    MemoryStream mem2 = new MemoryStream(data2);
                    pictureBox6.Image = Image.FromStream(mem2);

                    Byte[] data3 = new Byte[2];
                    data3 = (Byte[])(dr["resim3"]);
                    MemoryStream mem3 = new MemoryStream(data3);
                    pictureBox8.Image = Image.FromStream(mem3);

                    Byte[] data4 = new Byte[3];
                    data4 = (Byte[])(dr["resim4"]);
                    MemoryStream mem4 = new MemoryStream(data4);
                    pictureBox9.Image = Image.FromStream(mem4);
                }
                else
                {
                    pictureBox5.Image = null;
                    pictureBox6.Image = null;
                    pictureBox8.Image = null;
                    pictureBox9.Image = null;

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex.Message);

            }
            finally
            {
                conresımgetir.Close();

            }
        }
        public void satılkGuncelleVeriTabanındanVerileriCek()
        {
            //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur
            SqlConnection con = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from satılık where ilanNo=@id", con);
            cmd.Parameters.AddWithValue("@id", txtbulNo.Text);

            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    label25.Text = dr["ilanTarihi"].ToString();
                mkareguncelle.Text = dr["metrekare"].ToString();
                odaguncelle.Text = dr["odasayısı"].ToString();
                yasguncelle.Text = dr["binayası"].ToString();
                katguncelle.Text = dr["bulundugukat"].ToString();
                ısıtmaguncelle.Text = dr["ısıtma"].ToString();
                esyalıguncelle.Text = dr["esyalı"].ToString();
                aidatguncelle.Text = dr["aidat"].ToString();
                fiatguncelle.Text = dr["fiyat"].ToString();
                adresguncelle.Text = dr["adres"].ToString();
                txtilanNoguncelle.Text = dr["ilanNo"].ToString();
                turguncelle.Text = dr["Tur"].ToString();
            }

            catch (Exception)
            {

                MessageBox.Show("BU İLAN NUMARASINA AİT KAYIT YOK");
                txtbulNo.Text = "";
                txtilanNoguncelle.Text = "";
                mkareguncelle.Text = "";
                odaguncelle.Text = "";
                yasguncelle.Text = "";
                aidatguncelle.Text = "";
                katguncelle.Text = "";
                ısıtmaguncelle.Text = "";
                esyalıguncelle.Text = "";
                turguncelle.Text = "";
                fiatguncelle.Text = "";
                adresguncelle.Text = "";


            }
            finally
            {
                con.Close();

            }
        }
        private void ısıtmaguncelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            e.Handled = true;

        }

        private void esyalıguncelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            e.Handled = true;
        }

        private void turguncelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            e.Handled = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.Image!=null)
            {
                OpenFileDialog resım1SecGuncel = new OpenFileDialog();
                resım1SecGuncel.ShowDialog();
                if (resım1SecGuncel.FileName != null)
                {
                    pictureBox5.ImageLocation = resım1SecGuncel.FileName;
                    GuncelleResimYolu1 = resım1SecGuncel.FileName;
                    //MessageBox.Show(GuncelleResimYolu1);
                }
                else
                {
                    GuncelleResimYolu1 = "";
                }
            }
            else
            {
                MessageBox.Show("BİR KAYIT GETİRMEDEN DEGİŞTİRME YAPAMAZSINIZ !");
            }
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox6.Image != null)
            {
                OpenFileDialog resım1SecGuncel2 = new OpenFileDialog();
                resım1SecGuncel2.ShowDialog();
                if (resım1SecGuncel2.FileName != null)
                {
                    pictureBox6.ImageLocation = resım1SecGuncel2.FileName;
                    GuncelleResimYolu2 = resım1SecGuncel2.FileName;
                    //MessageBox.Show(GuncelleResimYolu2);
                }
                else
                {
                    GuncelleResimYolu2 = "";
                }
            }
            else
            {
                MessageBox.Show("BİR KAYIT GETİRMEDEN DEGİŞTİRME YAPAMAZSINIZ !");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (pictureBox8.Image != null)
            {
                OpenFileDialog resım1SecGuncel3 = new OpenFileDialog();
                resım1SecGuncel3.ShowDialog();
                if (resım1SecGuncel3.FileName != null)
                {
                    pictureBox8.ImageLocation = resım1SecGuncel3.FileName;
                    GuncelleResimYolu3 = resım1SecGuncel3.FileName;
                    //MessageBox.Show(GuncelleResimYolu3);
                }
                else
                {
                    GuncelleResimYolu3 = "";
                }
            }
            else
            {
                MessageBox.Show("BİR KAYIT GETİRMEDEN DEGİŞTİRME YAPAMAZSINIZ !");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (pictureBox9.Image != null)
            {
                OpenFileDialog resım1SecGuncel4 = new OpenFileDialog();
                resım1SecGuncel4.ShowDialog();
                if (resım1SecGuncel4.FileName != null)
                {
                    pictureBox9.ImageLocation = resım1SecGuncel4.FileName;
                    GuncelleResimYolu4 = resım1SecGuncel4.FileName;
                    //MessageBox.Show(GuncelleResimYolu4);
                }
                else
                {
                    GuncelleResimYolu4 = "";
                }
            }
            else
            {
                MessageBox.Show("BİR KAYIT GETİRMEDEN DEGİŞTİRME YAPAMAZSINIZ !");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {/*//Resim kaydetme Kodu
            SaveFileDialog sfd = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.

            sfd.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";//.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.

            sfd.Title = "Kayıt";//diğaloğumuzun başlığını belirliyoruz.

            sfd.FileName = "resim";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.

            DialogResult sonuç = sfd.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                pictureBox7.Image.Save(sfd.FileName);//Böylelikle resmi istediğimiz yere kaydediyoruz.
            }
           */
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            
            TariheGöreKayıtlar tarihsırala = new TariheGöreKayıtlar();
            tarihsırala.tarih = dateTimePicker1.Value.ToShortDateString();
            tarihsırala.gunluk = false;
            tarihsırala.satılık = true;
            tarihsırala.arsa = false;
            tarihsırala.kiralık = false;
            tarihsırala.ShowDialog();

            if (tarihsırala.listView1.SelectedItems.Count > 0)
            {
                txtbulNo.Text = tarihsırala.listView1.SelectedItems[0].Text.ToString();
            }
            else
            {
                txtbulNo.Text = "";
            }
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox5.Image!=null)
            {
                pictureBox5.Height += 120;
                pictureBox5.Width += 120;
                pictureBox5.BringToFront();
            }
            
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox5.Image != null)
            {
                pictureBox5.Height -= 120;
                pictureBox5.Width -= 120;
                pictureBox5.SendToBack();
            }
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox9.Image != null)
            {
                pictureBox9.Height += 120;
                pictureBox9.Width += 120;
                pictureBox9.BringToFront();
            }
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox9.Image != null)
            {
                pictureBox9.Height -= 120;
                pictureBox9.Width -= 120;
                pictureBox9.SendToBack();
            }
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox6.Image != null)
            {
                pictureBox6.Height += 120;
                pictureBox6.Width += 120;
                pictureBox6.BringToFront();
            }
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox6.Image != null)
            {
                pictureBox6.Height -= 120;
                pictureBox6.Width -= 120;
                pictureBox6.SendToBack();
            }
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox8.Image != null)
            {
                pictureBox8.Height += 120;
                pictureBox8.Width += 120;
                pictureBox8.BringToFront();
            }
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox8.Image != null)
            {
                pictureBox8.Height -= 120;
                pictureBox8.Width -= 120;
                pictureBox8.SendToBack();
            }
        }

        private void btnResimleriGuncelle_Click(object sender, EventArgs e)
        {
            if (GuncelleResimYolu1!=null&& GuncelleResimYolu2 != null && GuncelleResimYolu3 != null && GuncelleResimYolu4 != null)
            {
                string silmeSorgusu = "DELETE from Resimler where ilanNo=@ilannn";
                //musterino parametresine bağlı olarak müşteri kaydını silen sql sorgusu
                SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                silKomutu.Parameters.AddWithValue("@ilannn", txtbulNo.Text);
                baglanti.Open();
                silKomutu.ExecuteNonQuery();
                //MessageBox.Show("Kayıt Silindi...");
                baglanti.Close();


                //EKLEME İŞLEMİ
                FileStream fs1 = new FileStream(GuncelleResimYolu1, FileMode.Open, FileAccess.Read);
                BinaryReader br1 = new BinaryReader(fs1);
                byte[] resim1 = br1.ReadBytes((int)fs1.Length);
                br1.Close();
                fs1.Close();

                FileStream fs2 = new FileStream(GuncelleResimYolu2, FileMode.Open, FileAccess.Read);
                BinaryReader br2 = new BinaryReader(fs2);
                byte[] resim2 = br2.ReadBytes((int)fs2.Length);
                br2.Close();
                fs2.Close();

                FileStream fs3 = new FileStream(GuncelleResimYolu3, FileMode.Open, FileAccess.Read);
                BinaryReader br3 = new BinaryReader(fs3);
                byte[] resim3 = br3.ReadBytes((int)fs3.Length);
                br3.Close();
                fs3.Close();

                FileStream fs4 = new FileStream(GuncelleResimYolu4, FileMode.Open, FileAccess.Read);
                BinaryReader br4 = new BinaryReader(fs4);
                byte[] resim4 = br4.ReadBytes((int)fs4.Length);
                br4.Close();
                fs4.Close();

                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit2 = "insert into Resimler(ilanNo,resim1,resim2,resim3,resim4,ilanTarihi) values (@ilanNo,@resim1,@resim2,@resim3,@resim4,@İlantarih)";
                SqlCommand komut2 = new SqlCommand(kayit2, baglanti);

                komut2.Parameters.Add("@resim1", SqlDbType.Image, resim1.Length).Value = resim1;
                komut2.Parameters.Add("@resim2", SqlDbType.Image, resim2.Length).Value = resim2;
                komut2.Parameters.Add("@resim3", SqlDbType.Image, resim3.Length).Value = resim3;
                komut2.Parameters.Add("@resim4", SqlDbType.Image, resim4.Length).Value = resim4;
                komut2.Parameters.AddWithValue("@İlantarih", label25.Text);
                komut2.Parameters.AddWithValue("@ilanNo", txtbulNo.Text);

                komut2.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                baglanti.Close();
                MessageBox.Show("RESİMLER BAŞARIYLA GÜNCELLENDİ");
                pictureBox5.ImageLocation = "";
                pictureBox6.ImageLocation = "";
                pictureBox8.ImageLocation = "";
                pictureBox9.ImageLocation = "";
            }
            else
            {
                MessageBox.Show("RESİMLERİN TAMAMI DEGİŞTİRİLMEDEN GÜNCELLENEMEZ");
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           try
           {
               if (txtilanNoguncelle.Text != "" && mkareguncelle.Text != "" && odaguncelle.Text != "" && yasguncelle.Text != "" && aidatguncelle.Text != "" && katguncelle.Text != "" && ısıtmaguncelle.Text != "" && esyalıguncelle.Text != "" && turguncelle.Text != "" && fiatguncelle.Text != "" && adresguncelle.Text != "")
               {

                //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu = "update satılık set ilanTarihi=@ilanTarihi,metrekare=@metrekare,odasayısı=@odasayısı,binayası=@binayası,bulundugukat=@bulundugukat,ısıtma=@ısıtma,esyalı=@esyalı,aidat=@aidat,fiyat=@fiyat,adres=@adres,Tur=@Tur where ilanNo=@ilanNo";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@ilanTarihi", label25.Text);
                cmd.Parameters.AddWithValue("@metrekare", mkareguncelle.Text);
                cmd.Parameters.AddWithValue("@odasayısı", odaguncelle.Text);
                cmd.Parameters.AddWithValue("@binayası", yasguncelle.Text);
                cmd.Parameters.AddWithValue("@bulundugukat", katguncelle.Text);
                cmd.Parameters.AddWithValue("@ısıtma", ısıtmaguncelle.Text);
                cmd.Parameters.AddWithValue("@esyalı", esyalıguncelle.Text);
                cmd.Parameters.AddWithValue("@aidat", aidatguncelle.Text);
                cmd.Parameters.AddWithValue("@fiyat", fiatguncelle.Text);
                cmd.Parameters.AddWithValue("@adres", adresguncelle.Text);
                cmd.Parameters.AddWithValue("@Tur", turguncelle.Text);
                cmd.Parameters.AddWithValue("@ilanNo", txtilanNoguncelle.Text);

                DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("GÜNCELLEME İŞLEMİ BAŞARILI…");
                    baglanti.Close();
                    guncelleTemizle();
                }
                else if (secenek == DialogResult.No)
                {
                    MessageBox.Show("GÜNCELLEME İŞLEMİ BAŞARISIZ…");
                    baglanti.Close();
                }
                        
             }
             else
             {
                    MessageBox.Show("ALANLAR BOŞ OLARAK GÜNCELLENMEZ");
             }

           }
           catch (Exception)
           {
                MessageBox.Show("GÜNCELLEME İŞLEMİ BAŞARISIZ…");
                baglanti.Close();
           }
        }
        public void guncelleTemizle()
        {
            txtbulNo.Text = "";
            txtilanNoguncelle.Text = "";
            mkareguncelle.Text = "";
            odaguncelle.Text = "";
            yasguncelle.Text = "";
            aidatguncelle.Text = "";
            katguncelle.Text = "";
            ısıtmaguncelle.Text = "";
            esyalıguncelle.Text = "";
            turguncelle.Text = "";
            fiatguncelle.Text = "";
            adresguncelle.Text = "";
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }
        private void txtbulNo_TextChanged(object sender, EventArgs e)
        {
            txtilanNoguncelle.Text = "";
            mkareguncelle.Text = "";
            odaguncelle.Text = "";
            yasguncelle.Text = "";
            aidatguncelle.Text = "";
            katguncelle.Text = "";
            ısıtmaguncelle.Text = "";
            esyalıguncelle.Text = "";
            turguncelle.Text = "";
            fiatguncelle.Text = "";
            adresguncelle.Text = "";
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {

            if (lblilanNo.Text!="...")
            {
                SqlCommand sql_cmd = new SqlCommand("DELETE FROM satılık WHERE ilanNo=@No", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlParameterCollection param = sql_cmd.Parameters;
                param.AddWithValue("No", lblilanNo.Text);
                
                DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    sql_cmd.ExecuteNonQuery();
                    baglanti.Close();

                    SqlCommand sql_cmdResimsil = new SqlCommand("DELETE FROM Resimler WHERE ilanNo=@No", baglanti);
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    SqlParameterCollection param2 = sql_cmdResimsil.Parameters;
                    param2.AddWithValue("No", lblilanNo.Text);
                    sql_cmdResimsil.ExecuteNonQuery();
                    baglanti.Close();
                    satılıkResimleriDiziyeAta();
                    satılıkVerileriDiziyeAta();
                    silVerileriTemizle();
                    MessageBox.Show("SİLME İŞLEMİ BAŞARILI…");
                }
                else if (secenek == DialogResult.No)
                {
                    MessageBox.Show("SİLME İŞLEMİ BAŞARISIZ…");
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("SİLİNECEK VERI YOK");
                baglanti.Close();
            }
          
        }
        public void silVerileriTemizle()
        {
            txtilanNoGoster.Text = "";
            lblilanNo.Text = "...";
            lblkayıttarih.Text = "...";
            lblmetrekare.Text = "...";
            lblodasayısı.Text = "...";
            lblbinayası.Text = "...";
            lblkat.Text = "...";
            lblısıtma.Text = "...";
            lblesyalı.Text = "...";
            lblaidat.Text = "...";
            lblfiyat.Text = "...";
            lbladres.Text = "...";
            lbltur.Text = "...";
            pictureBox7.Image = null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
            pictureBox12.Image = null;

        }
        string[,] satılıkVerileri;
        string[] satılıkResimİlanNoları;
        Image[,] satılıkVerileriResimler;
        int kayitSayisi;
        int kayitSayisiResim;
        int diziElemanSay = 0;
        int diziElemanSayResim = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtilanNoGoster.Text != "")
                {

                    satılıkVerileriDiziyeAta();
                    satılkVerilerDizisiniEkranaBas();
                    satılıkResimleriDiziyeAta();
                    satılkResimlerDizisiniEkranaBas();
                    if (lblilanNo.Text=="...")
                    {
                        MessageBox.Show("YAZILAN İLAN NUMARASANDA VERİ YOK");
                        
                    }
                }
                else
                {
                    MessageBox.Show("İLAN NUMARASINI GİRİNİZ");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("HATA FIRLATILDI");
            }
           

        }
        public void satılkResimlerDizisiniEkranaBas()
        {
            bool veriVar = false;
            for (int i = 0; i < kayitSayisiResim; i++)
            {
                if (satılıkResimİlanNoları[i].ToString()== txtilanNoGoster.Text.ToString())
                {
                    pictureBox7.Image = satılıkVerileriResimler[i, 0];
                    pictureBox10.Image = satılıkVerileriResimler[i, 1];
                    pictureBox11.Image = satılıkVerileriResimler[i, 2];
                    pictureBox12.Image = satılıkVerileriResimler[i, 3];
                    veriVar = true;
                }
            }
            if (veriVar==false)
            {
                silVerileriTemizle();
            }
        }
        public void satılkVerilerDizisiniEkranaBas()
        {
            for (int i = 0; i < kayitSayisi; i++)
            {
                if (satılıkVerileri[i, 0].ToString() == txtilanNoGoster.Text.ToString())
                {
                    lblilanNo.Text = satılıkVerileri[i, 0].ToString();
                    lblkayıttarih.Text = satılıkVerileri[i, 1].ToString();
                    lblmetrekare.Text = satılıkVerileri[i, 2].ToString();
                    lblodasayısı.Text = satılıkVerileri[i, 3].ToString();
                    lblbinayası.Text = satılıkVerileri[i, 4].ToString();
                    lblkat.Text = satılıkVerileri[i, 5].ToString();
                    lblısıtma.Text = satılıkVerileri[i, 6].ToString();
                    lblesyalı.Text = satılıkVerileri[i, 7].ToString();
                    lblaidat.Text = satılıkVerileri[i, 8].ToString();
                    lblfiyat.Text = satılıkVerileri[i, 9].ToString();
                    lbladres.Text = satılıkVerileri[i, 10].ToString();
                    lbltur.Text = satılıkVerileri[i, 11].ToString();
                }

            }
        }
        public void satılıkVerileriDiziyeAta()
        {
            //Select COUNT(ilanNo)From satılık
            kayitSayisi = -1;
            SqlConnection connection = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("select count(ilanNo) from satılık", connection);
            connection.Open();
            kayitSayisi = Convert.ToInt32(cmd2.ExecuteScalar());
            connection.Close();
            diziElemanSay = kayitSayisi - 1;
            ////*****************kayıt sayısını bulma************************************        
            //*******************************************************************************************************
            int sayaç = 0;
            satılıkVerileri = new string[kayitSayisi, 12];

            SqlConnection connec = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from satılık", connec);
            if (connec.State != ConnectionState.Open)
                connec.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                satılıkVerileri[sayaç, 0] = dr["ilanNo"].ToString();//1
                satılıkVerileri[sayaç, 1] = dr["ilanTarihi"].ToString();//fazla
                satılıkVerileri[sayaç, 2] = dr["metrekare"].ToString();//2
                satılıkVerileri[sayaç, 3] = dr["odasayısı"].ToString();//3
                satılıkVerileri[sayaç, 4] = dr["binayası"].ToString();//4
                satılıkVerileri[sayaç, 5] = dr["bulundugukat"].ToString();//5
                satılıkVerileri[sayaç, 6] = dr["ısıtma"].ToString();//6
                satılıkVerileri[sayaç, 7] = dr["esyalı"].ToString();//7
                satılıkVerileri[sayaç, 8] = dr["aidat"].ToString();//8
                satılıkVerileri[sayaç, 9] = dr["fiyat"].ToString();//9
                satılıkVerileri[sayaç, 10] = dr["adres"].ToString();//10
                satılıkVerileri[sayaç, 11] = dr["Tur"].ToString();//11
                sayaç++;
            }
            connec.Close();
        }
        public void satılıkResimleriDiziyeAta()
        {
            tıklandıDizilerDoldu = true;
            kayitSayisiResim = -1;
            SqlConnection connectionResim = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdResim = new SqlCommand("select count(ilanNo) from Resimler", connectionResim);
            connectionResim.Open();
            kayitSayisiResim = Convert.ToInt32(cmdResim.ExecuteScalar());
            connectionResim.Close();
            diziElemanSayResim = kayitSayisiResim - 1;
            ///*************************************************************************
            int sayaçResim = 0;
            //int kayıtSayısı= Convert.ToInt32(cmd.ExecuteScalar());
            satılıkVerileriResimler = new Image[kayitSayisiResim, 4];
            satılıkResimİlanNoları = new String[kayitSayisiResim];

            //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur

            SqlConnection connecResim = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdResimGetir = new SqlCommand("select * from Resimler", connecResim);
            if (connecResim.State != ConnectionState.Open)
                connecResim.Open();
            SqlDataReader drResim = cmdResimGetir.ExecuteReader();
            while (drResim.Read())
            {
                satılıkResimİlanNoları[sayaçResim] = drResim["ilanNo"].ToString();//1
                Byte[] data = new Byte[0];
                data = (Byte[])(drResim["resim1"]);
                MemoryStream mem = new MemoryStream(data);
                satılıkVerileriResimler[sayaçResim, 0] = Image.FromStream(mem);
                mem.Close();

                Byte[] data2 = new Byte[1];
                data2 = (Byte[])(drResim["resim2"]);
                MemoryStream mem2 = new MemoryStream(data2);
                satılıkVerileriResimler[sayaçResim, 1] = Image.FromStream(mem2);

                Byte[] data3 = new Byte[2];
                data3 = (Byte[])(drResim["resim3"]);
                MemoryStream mem3 = new MemoryStream(data3);
                satılıkVerileriResimler[sayaçResim, 2] = Image.FromStream(mem3);

                Byte[] data4 = new Byte[3];
                data4 = (Byte[])(drResim["resim4"]);
                MemoryStream mem4 = new MemoryStream(data4);
                satılıkVerileriResimler[sayaçResim, 3] = Image.FromStream(mem4);
                sayaçResim++;
            }
            connecResim.Close();

        }
        bool tıklandıDizilerDoldu = false;
        private void btneksidiger_Click(object sender, EventArgs e)
        {
         
            try
            {
                if (tıklandıDizilerDoldu == false)
                {
                    satılıkResimleriDiziyeAta();
                    satılıkVerileriDiziyeAta();
                }
                if (satılıkVerileri != null || satılıkResimİlanNoları != null || satılıkVerileriResimler != null || diziElemanSay != -1 || diziElemanSayResim != -1)
                {
                    txtilanNoGoster.Text = "";
                    if (diziElemanSay <= 0)
                    {

                        lblilanNo.Text = satılıkVerileri[diziElemanSay, 0].ToString();
                        lblkayıttarih.Text = satılıkVerileri[diziElemanSay, 1].ToString();
                        lblmetrekare.Text = satılıkVerileri[diziElemanSay, 2].ToString();
                        lblodasayısı.Text = satılıkVerileri[diziElemanSay, 3].ToString();
                        lblbinayası.Text = satılıkVerileri[diziElemanSay, 4].ToString();
                        lblkat.Text = satılıkVerileri[diziElemanSay, 5].ToString();
                        lblısıtma.Text = satılıkVerileri[diziElemanSay, 6].ToString();
                        lblesyalı.Text = satılıkVerileri[diziElemanSay, 7].ToString();
                        lblaidat.Text = satılıkVerileri[diziElemanSay, 8].ToString();
                        lblfiyat.Text = satılıkVerileri[diziElemanSay, 9].ToString();
                        lbladres.Text = satılıkVerileri[diziElemanSay, 10].ToString();
                        lbltur.Text = satılıkVerileri[diziElemanSay, 11].ToString();
                        diziElemanSay = kayitSayisi - 1;

                    }
                    else
                    {

                        lblilanNo.Text = satılıkVerileri[diziElemanSay, 0].ToString();
                        lblkayıttarih.Text = satılıkVerileri[diziElemanSay, 1].ToString();
                        lblmetrekare.Text = satılıkVerileri[diziElemanSay, 2].ToString();
                        lblodasayısı.Text = satılıkVerileri[diziElemanSay, 3].ToString();
                        lblbinayası.Text = satılıkVerileri[diziElemanSay, 4].ToString();
                        lblkat.Text = satılıkVerileri[diziElemanSay, 5].ToString();
                        lblısıtma.Text = satılıkVerileri[diziElemanSay, 6].ToString();
                        lblesyalı.Text = satılıkVerileri[diziElemanSay, 7].ToString();
                        lblaidat.Text = satılıkVerileri[diziElemanSay, 8].ToString();
                        lblfiyat.Text = satılıkVerileri[diziElemanSay, 9].ToString();
                        lbladres.Text = satılıkVerileri[diziElemanSay, 10].ToString();
                        lbltur.Text = satılıkVerileri[diziElemanSay, 11].ToString();
                        diziElemanSay--;

                    }
                    if (diziElemanSayResim <= 0)
                    {

                        pictureBox7.Image = satılıkVerileriResimler[diziElemanSayResim, 0];
                        pictureBox10.Image = satılıkVerileriResimler[diziElemanSayResim, 1];
                        pictureBox11.Image = satılıkVerileriResimler[diziElemanSayResim, 2];
                        pictureBox12.Image = satılıkVerileriResimler[diziElemanSayResim, 3];
                        diziElemanSayResim = kayitSayisiResim - 1;
                    }
                    else
                    {

                        pictureBox7.Image = satılıkVerileriResimler[diziElemanSayResim, 0];
                        pictureBox10.Image = satılıkVerileriResimler[diziElemanSayResim, 1];
                        pictureBox11.Image = satılıkVerileriResimler[diziElemanSayResim, 2];
                        pictureBox12.Image = satılıkVerileriResimler[diziElemanSayResim, 3];
                        diziElemanSayResim--;
                    }

                }
                else
                {
                    MessageBox.Show("KAYIT YOK");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("VERİ YOK");
            }
            
            
        }
        private void btnartıdiger_Click(object sender, EventArgs e)
        {
          
        }

        private void txtbulNo_Validated(object sender, EventArgs e)
        {

        }

        private void txtbulNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtilanNoGoster_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtilanNoguncelle_Validated(object sender, EventArgs e)
        {
            if (txtilanNoguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtilanNoguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtilanNoguncelle, "");
        }

        private void mkareguncelle_Validated(object sender, EventArgs e)
        {
            if (mkareguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(mkareguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(mkareguncelle, "");
        }

        private void odaguncelle_Validated(object sender, EventArgs e)
        {
            if (odaguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(odaguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(odaguncelle, "");
        }

        private void yasguncelle_Validated(object sender, EventArgs e)
        {
            if (yasguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(yasguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(yasguncelle, "");
        }

        private void aidatguncelle_Validated(object sender, EventArgs e)
        {
            if (aidatguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(aidatguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(aidatguncelle, "");
        }

        private void katguncelle_Validated(object sender, EventArgs e)
        {

            if (katguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(katguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(katguncelle, "");
        }

        private void ısıtmaguncelle_Validated(object sender, EventArgs e)
        {

            if (ısıtmaguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(ısıtmaguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(ısıtmaguncelle, "");
        }

        private void esyalıguncelle_Validated(object sender, EventArgs e)
        {
            if (esyalıguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(esyalıguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(esyalıguncelle, "");
        }

        private void turguncelle_Validated(object sender, EventArgs e)
        {
            if (turguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(turguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(turguncelle, "");
        }

        private void fiatguncelle_Validated(object sender, EventArgs e)
        {
            if (fiatguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(fiatguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(fiatguncelle, "");
        }

        private void adresguncelle_Validated(object sender, EventArgs e)
        {
            if (adresguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(adresguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(adresguncelle, "");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            satılıkResimleriDiziyeAta();
            satılıkVerileriDiziyeAta();
            satılıkEkleTemizle();
            guncelleTemizle();
        }
    }
}
