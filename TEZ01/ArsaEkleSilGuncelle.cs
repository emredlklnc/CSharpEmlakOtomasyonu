using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace TEZ01
{
    public partial class ArsaEkleSilGuncelle : Form
    {
        public ArsaEkleSilGuncelle()
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

        string[,] satılıkVerileri;
        string[] satılıkResimİlanNoları;
        Image[,] satılıkVerileriResimler;
        int kayitSayisi;
        int kayitSayisiResim;
        int diziElemanSay = 0;
        int diziElemanSayResim = 0;


        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        private void btnkaydet_Click(object sender, EventArgs e)
        {

            if (pictureBox1.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox2.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox3.ImageLocation == Application.StartupPath + "\\resim.png" || pictureBox4.ImageLocation == Application.StartupPath + "\\resim.png")
            {
                MessageBox.Show("RESİMLER SEÇİLMEDEN KAYIT YAPILMAZ");
            }
            else
            {
             
                if (txtilanno.Text == "" || txtmetre.Text == "" ||txtfiyat.Text=="" || txtadres.Text == "" || cmbkatkarsılıgı.SelectedItem == null)
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

                            arsaVerileriVeritabanınaKaydet();
                            arsaResimleriVeritabanınaKaydet();
                            MessageBox.Show("ARSA KAYIT İŞLEMİ GERÇEKLEŞTİRİLDİ.");
                            kaydetTemizle();
                        }
                        else if (secenek==DialogResult.No)
                        {
                            MessageBox.Show("İŞLEM İPTAL EDİLDİ");
                        }
                                
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("AYNI İLAN NUMARASINDA KAYIT BULUNMAKTA !!");
                    }

                }
            }
        }
        public void kaydetTemizle()
        {
            txtilanno.Text = "";
            txtmetre.Text = "";
            txtfiyat.Text = "";
            cmbkatkarsılıgı.Text= "";
            txtadres.Text = "";

        }
        public void arsaResimleriVeritabanınaKaydet()
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
            string kayit2 = "insert into ArsaResimler(ilanNo,resim1,resim2,resim3,resim4,ilanTarihi) values (@ilanNo,@resim1,@resim2,@resim3,@resim4,@İlantarih)";
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
        public void arsaVerileriVeritabanınaKaydet()
        {
            // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
            string kayit = "insert into Arsa(ilanTarihi,metrekare,katkarsılıgı,fiyat,adres,ilanNo) values (@tarih,@metrekare,@katkarsı,@fiyat,@adres,@ilanNo)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString().ToString());
            komut.Parameters.AddWithValue("@metrekare", txtmetre.Text);
            komut.Parameters.AddWithValue("@katkarsı", cmbkatkarsılıgı.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@fiyat", txtfiyat.Text);
            komut.Parameters.AddWithValue("@adres", txtadres.Text);
            komut.Parameters.AddWithValue("@ilanNo", txtilanno.Text);
            // komut.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;

            komut.ExecuteNonQuery();
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            baglanti.Close();

        }

        private void ArsaEkleSilGuncelle_Load(object sender, EventArgs e)
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
            label28.Text = DateTime.Now.ToShortDateString();

            toolTip1.SetToolTip(btnresimuyarı, "RESİM DEGİŞTİRMEK İÇİN RESMİN ÜZERİNE TIKLA "); //mesajın yazıldığı yer
            toolTip1.ToolTipTitle = "BİLGİ MESAJI"; // mesajın başlığının yazıldığı yer
            toolTip1.ToolTipIcon = ToolTipIcon.Info; // mesajın ikonunun ayarlandığı yer
            toolTip1.IsBalloon = true;// bu kodu yazmazsak mesaj dikdörtgen şeklinde görünür.

            toolTip2.SetToolTip(btnresımguncelleuyarı, "RESİMLERİ GÜNCELLEMEK İÇİN TÜM RESİMLERİ DEGİŞTİRMEN GEREKİR !!"); //mesajın yazıldığı yer
            toolTip2.ToolTipTitle = "UYARI MESAJI !!"; // mesajın başlığının yazıldığı yer
            toolTip2.ToolTipIcon = ToolTipIcon.Info; // mesajın ikonunun ayarlandığı yer
            toolTip2.IsBalloon = true;// bu kodu yazmazsak mesaj dikdörtgen şeklinde görünür.
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
            OpenFileDialog dosya2 = new OpenFileDialog();
            dosya2.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya2.Title = "dalkılınçEMLAK";
            dosya2.ShowDialog();
            string DosyaYolu = dosya2.FileName;
            if (DosyaYolu == "")
            {
                pictureBox2.ImageLocation = Application.StartupPath + "\\resim.png";
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
                pictureBox3.ImageLocation = Application.StartupPath + "\\resim.png";
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
                pictureBox4.ImageLocation = Application.StartupPath + "\\resim.png";
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

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }
        public void guncelleTemizle()
        {
            txtbulNo.Text = "";
            txtilanNoguncelle.Text = "";
            mkareguncelle.Text = "";
            cmbxkatguncelle.Text = "";
            fiatguncelle.Text = "";
            adresguncelle.Text = "";
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;

        }
        private void btnResimleriGuncelle_Click(object sender, EventArgs e)
        {
            if (GuncelleResimYolu1 != null && GuncelleResimYolu2 != null && GuncelleResimYolu3 != null && GuncelleResimYolu4 != null)
            {
                string silmeSorgusu = "DELETE from ArsaResimler where ilanNo=@ilannn";
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
                string kayit2 = "insert into ArsaResimler(ilanNo,resim1,resim2,resim3,resim4,ilanTarihi) values (@ilanNo,@resim1,@resim2,@resim3,@resim4,@İlantarih)";
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
        public void arsaGuncelleVeriTabanındanResımCek()
        {
            SqlConnection conresımgetir = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdresimgetir = new SqlCommand("select * from ArsaResimler where ilanNo=@RsmİlanNo", conresımgetir);
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
        public void arsaGuncelleVeriTabanındanVerileriCek()
        {
            //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur
            SqlConnection con = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Arsa where ilanNo=@id", con);
            cmd.Parameters.AddWithValue("@id", txtbulNo.Text);

            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    label25.Text = dr["ilanTarihi"].ToString();
                    mkareguncelle.Text = dr["metrekare"].ToString();
                    cmbxkatguncelle.Text= dr["katkarsılıgı"].ToString();
                    fiatguncelle.Text = dr["fiyat"].ToString();
                    adresguncelle.Text = dr["adres"].ToString();
                    txtilanNoguncelle.Text = dr["ilanNo"].ToString();
                
            }

            catch (Exception)
            {

                MessageBox.Show("BU İLAN NUMARASINA AİT KAYIT YOK");
                txtilanNoguncelle.Text = "";
                mkareguncelle.Text = "";
                cmbxkatguncelle.Text = "";
                fiatguncelle.Text = "";
                adresguncelle.Text = "";


            }
            finally
            {
                con.Close();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtbulNo.Text == "")
            {
                MessageBox.Show("İLAN NUMARASI GİRMELİSİN TAKVİMDEN TARİHE GÖREDE DE SEÇEBİLİRSİN");
            }
            else
            {

                arsaGuncelleVeriTabanındanVerileriCek();
                //**********************************************************************************************************************
                //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur
                arsaGuncelleVeriTabanındanResımCek();
            }
        }
        public void arsaResimlerDizisiniEkranaBas()
        {
            for (int i = 0; i < kayitSayisiResim; i++)
            {
                if (satılıkResimİlanNoları[i].ToString() == txtilanNoGoster.Text.ToString())
                {
                    pictureBox7.Image = satılıkVerileriResimler[i, 0];
                    pictureBox10.Image = satılıkVerileriResimler[i, 1];
                    pictureBox11.Image = satılıkVerileriResimler[i, 2];
                    pictureBox12.Image = satılıkVerileriResimler[i, 3];
                }
            }

        }
        public void arsaVerilerDizisiniEkranaBas()
        {
            bool kayıtvar = false;
            for (int i = 0; i < kayitSayisi; i++)
            {
                if (satılıkVerileri[i, 0].ToString() == txtilanNoGoster.Text.ToString())
                {
                    lblilanNo.Text = satılıkVerileri[i, 0].ToString();
                    lblkayıttarih.Text = satılıkVerileri[i, 1].ToString();
                    lblmetrekare.Text = satılıkVerileri[i, 2].ToString();
                    
                    lblkat.Text = satılıkVerileri[i, 3].ToString();
                    
                    lblfiyat.Text = satılıkVerileri[i, 4].ToString();
                    lbladres.Text = satılıkVerileri[i, 5].ToString();
                    kayıtvar = true;
                }

            }
            if (kayıtvar==false)
            {
                silVerileriTemizle();
            }
        }

        public void arsaVerileriDiziyeAta()
        {
            //Select COUNT(ilanNo)From satılık
            kayitSayisi = -1;
            SqlConnection connection = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("select count(ilanNo) from Arsa", connection);
            connection.Open();
            kayitSayisi = Convert.ToInt32(cmd2.ExecuteScalar());
            connection.Close();
            diziElemanSay = kayitSayisi - 1;
            ////*****************kayıt sayısını bulma************************************        
            //*******************************************************************************************************
            int sayaç = 0;
            satılıkVerileri = new string[kayitSayisi, 6];

            SqlConnection connec = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Arsa", connec);
            if (connec.State != ConnectionState.Open)
                connec.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                satılıkVerileri[sayaç, 0] = dr["ilanNo"].ToString();//1
                satılıkVerileri[sayaç, 1] = dr["ilanTarihi"].ToString();//fazla
                satılıkVerileri[sayaç, 2] = dr["metrekare"].ToString();//2
                satılıkVerileri[sayaç, 3] = dr["katkarsılıgı"].ToString();//8
                satılıkVerileri[sayaç, 4] = dr["fiyat"].ToString();//9
                satılıkVerileri[sayaç, 5] = dr["adres"].ToString();//10
                
                sayaç++;
            }
            connec.Close();
        }
        public void arsaResimleriDiziyeAta()
        {
            tıklandıDizilerDoldu = true;
            kayitSayisiResim = -1;
            SqlConnection connectionResim = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdResim = new SqlCommand("select count(ilanNo) from ArsaResimler", connectionResim);
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
            SqlCommand cmdResimGetir = new SqlCommand("select * from ArsaResimler", connecResim);
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtilanNoGoster.Text != "")
                {

                    arsaVerileriDiziyeAta();
                    arsaVerilerDizisiniEkranaBas();
                    arsaResimleriDiziyeAta();
                    arsaResimlerDizisiniEkranaBas();
                    if (lblilanNo.Text == "...")
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

        private void btneksidiger_Click(object sender, EventArgs e)
        {
            try
            {
                if (tıklandıDizilerDoldu == false)
                {
                    arsaResimleriDiziyeAta();
                    arsaVerileriDiziyeAta();
                }
                if (satılıkVerileri != null || satılıkVerileriResimler != null || diziElemanSay != -1 || diziElemanSayResim != -1)
                {
                    txtilanNoGoster.Text = "";

                    if (diziElemanSay <= 0)
                    {

                        lblilanNo.Text = satılıkVerileri[diziElemanSay, 0].ToString();
                        lblkayıttarih.Text = satılıkVerileri[diziElemanSay, 1].ToString();
                        lblmetrekare.Text = satılıkVerileri[diziElemanSay, 2].ToString();

                        lblkat.Text = satılıkVerileri[diziElemanSay, 3].ToString();

                        lblfiyat.Text = satılıkVerileri[diziElemanSay, 4].ToString();
                        lbladres.Text = satılıkVerileri[diziElemanSay, 5].ToString();

                        diziElemanSay = kayitSayisi - 1;

                    }
                    else
                    {

                        lblilanNo.Text = satılıkVerileri[diziElemanSay, 0].ToString();
                        lblkayıttarih.Text = satılıkVerileri[diziElemanSay, 1].ToString();
                        lblmetrekare.Text = satılıkVerileri[diziElemanSay, 2].ToString();

                        lblkat.Text = satılıkVerileri[diziElemanSay, 3].ToString();

                        lblfiyat.Text = satılıkVerileri[diziElemanSay, 4].ToString();
                        lbladres.Text = satılıkVerileri[diziElemanSay, 5].ToString();
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
        public void silVerileriTemizle()
        {
            txtbulNo.Text = "";
            lblilanNo.Text = "...";
            lblkayıttarih.Text = "...";
            lblmetrekare.Text = "...";
            lblkat.Text = "...";
            lblfiyat.Text = "...";
            lbladres.Text = "...";
            
            pictureBox7.Image = null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
            pictureBox12.Image = null;

        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            if (lblilanNo.Text != "...")
            {
                SqlCommand sql_cmd = new SqlCommand("DELETE FROM Arsa WHERE ilanNo=@No", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlParameterCollection param = sql_cmd.Parameters;
                param.AddWithValue("No", lblilanNo.Text);

                DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    sql_cmd.ExecuteNonQuery();
                    baglanti.Close();

                    SqlCommand sql_cmdResimsil = new SqlCommand("DELETE FROM ArsaResimler WHERE ilanNo=@No", baglanti);
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    SqlParameterCollection param2 = sql_cmdResimsil.Parameters;
                    param2.AddWithValue("No", lblilanNo.Text);
                    sql_cmdResimsil.ExecuteNonQuery();
                    baglanti.Close();
                    arsaResimleriDiziyeAta();
                    arsaVerileriDiziyeAta();
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

        private void cmbxkatguncelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.Image != null)
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
       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
            TariheGöreKayıtlar tarihsırala = new TariheGöreKayıtlar();
            tarihsırala.tarih = dateTimePicker1.Value.ToShortDateString();
            tarihsırala.gunluk = false;
            tarihsırala.satılık = false;
            tarihsırala.arsa = true;
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

        private void txtilanno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbkatkarsılıgı_Validated(object sender, EventArgs e)
        {
            if (cmbkatkarsılıgı.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(cmbkatkarsılıgı, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(cmbkatkarsılıgı, "");
        }

        private void txtadres_Validated(object sender, EventArgs e)
        {
            if (txtadres.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtadres, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtadres, "");
        }

        private void txtfiyat_Validated(object sender, EventArgs e)
        {
            if (txtfiyat.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtfiyat, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtfiyat, "");
        }

        private void txtmetre_Validated(object sender, EventArgs e)
        {
            if (txtmetre.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(txtmetre, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(txtmetre, "");
        }

        private void txtmetre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtfiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtilanNoguncelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void mkareguncelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void fiatguncelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtilanNoGoster_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtbulNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void fiatguncelle_Validated(object sender, EventArgs e)
        {
            if (fiatguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(fiatguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(fiatguncelle, "");
        }

        private void cmbxkatguncelle_Validated(object sender, EventArgs e)
        {
            if (cmbxkatguncelle.Text.Trim() == "") //eğer TextBox1 boş ise
                errorProvider1.SetError(cmbxkatguncelle, "BOŞ GEÇİLEMEZ !");
            else
                errorProvider1.SetError(cmbxkatguncelle, "");
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
            arsaResimleriDiziyeAta();
            arsaVerileriDiziyeAta();
            kaydetTemizle();
            guncelleTemizle();
            silVerileriTemizle();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtilanNoguncelle.Text != "" && mkareguncelle.Text != "" && cmbxkatguncelle.Text != "" && fiatguncelle.Text != "" && adresguncelle.Text != "")
                {

                    //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string sorgu = "update Arsa set ilanTarihi=@ilanTarihi,metrekare=@metrekare,katkarsılıgı=@kat,fiyat=@fiyat,adres=@adres where ilanNo=@ilanNo";
                    SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                    cmd.Parameters.AddWithValue("@ilanTarihi", label25.Text);
                    cmd.Parameters.AddWithValue("@metrekare", mkareguncelle.Text);
                    cmd.Parameters.AddWithValue("@kat", cmbxkatguncelle.Text);

                    cmd.Parameters.AddWithValue("@fiyat", fiatguncelle.Text);
                    cmd.Parameters.AddWithValue("@adres", adresguncelle.Text);

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
    }
}
