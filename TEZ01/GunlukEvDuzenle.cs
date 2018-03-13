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
using System.Threading;

namespace TEZ01
{
    public partial class GunlukEvDuzenle : Form
    {
        public GunlukEvDuzenle()
        {
            InitializeComponent();
        }
        GünlükEvEkleme ekleVeri = new GünlükEvEkleme();
        private void btnyenigunlukev_Click(object sender, EventArgs e)
        {
            ekleVeri.ShowDialog();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        private void GunlukEvDuzenle_Load(object sender, EventArgs e)
        {
            btngunlukguncelle.Enabled = false;
            panel1.BackColor = Color.Red;
            btngunluksil.Enabled = true;
            

        }
        string[,] gunlukVerileri;
        string[] gunlukResimİlanNoları;
        Image[,] gunlukVerileriResimler;
        int kayitSayisi;
        int kayitSayisiResim;
        int diziElemanSay = 0;
        int diziElemanSayResim = 0;
        bool tıklandıDizilerDoldu = false;
        bool duzenleAcık = false;
        public void gunlukVerileriDiziyeAta()
        {
            //Select COUNT(ilanNo)From satılık
            kayitSayisi = -1;
            SqlConnection connection = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("select count(ilanNo) from gunlukEv", connection);
            connection.Open();
            kayitSayisi = Convert.ToInt32(cmd2.ExecuteScalar());
            connection.Close();
            diziElemanSay = kayitSayisi - 1;
            ////*****************kayıt sayısını bulma************************************        
            //*******************************************************************************************************
            int sayaç = 0;
            gunlukVerileri = new string[kayitSayisi, 11];

            SqlConnection connec = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from gunlukEv", connec);
            if (connec.State != ConnectionState.Open)
                connec.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                gunlukVerileri[sayaç, 0] = dr["ilanNo"].ToString();//1
                gunlukVerileri[sayaç, 1] = dr["ilanTarihi"].ToString();//fazla
                gunlukVerileri[sayaç, 2] = dr["metrekare"].ToString();//2
                gunlukVerileri[sayaç, 3] = dr["odasayısı"].ToString();//3
                gunlukVerileri[sayaç, 4] = dr["bulundugukat"].ToString();//4
                gunlukVerileri[sayaç, 5] = dr["ısıtma"].ToString();//5
                gunlukVerileri[sayaç, 6] = dr["fiyat"].ToString();//6
                gunlukVerileri[sayaç, 7] = dr["adres"].ToString();//7
                gunlukVerileri[sayaç, 8] = dr["wifi"].ToString();//8
                gunlukVerileri[sayaç, 9] = dr["tv"].ToString();//9
                gunlukVerileri[sayaç, 10] = dr["binayası"].ToString();//10

                sayaç++;
            }
            connec.Close();
        }
        public void gunlukResimlerDizisiniEkranaBas()
        {
            for (int i = 0; i < kayitSayisiResim; i++)
            {
                if (gunlukResimİlanNoları[i].ToString() == txtilanNoGoster.Text.ToString())
                {
                    pictureBox2.Image = gunlukVerileriResimler[i, 0];
                    pictureBox3.Image = gunlukVerileriResimler[i, 1];
                    pictureBox4.Image = gunlukVerileriResimler[i, 2];
                    pictureBox5.Image = gunlukVerileriResimler[i, 3];
                    pictureBox6.Image = gunlukVerileriResimler[i, 4];
                    pictureBox9.Image = gunlukVerileriResimler[i, 5];
                    pictureBox10.Image = gunlukVerileriResimler[i, 6];
                    pictureBox11.Image = gunlukVerileriResimler[i, 7];
                }
            }

        }
        public void gunlukVerilerDizisiniEkranaBas()
        {
            for (int i = 0; i < kayitSayisi; i++)
            {
                if (gunlukVerileri[i, 0].ToString() == txtilanNoGoster.Text.ToString())
                {
                    txtilanno.Text = gunlukVerileri[i, 0].ToString();
                    lblkayıttarıh.Text = gunlukVerileri[i, 1].ToString();
                    txtmetre.Text = gunlukVerileri[i, 2].ToString();
                    txtodasayısı.Text = gunlukVerileri[i, 3].ToString();
                    txtkat.Text = gunlukVerileri[i, 4].ToString();
                    cmbxısıtma.Text = gunlukVerileri[i, 5].ToString();
                    txtfiyat.Text = gunlukVerileri[i, 6].ToString();
                    txtadres.Text = gunlukVerileri[i, 7].ToString();
                    cmbxwifi.Text = gunlukVerileri[i, 8].ToString();
                    cmbtv.Text = gunlukVerileri[i, 9].ToString();
                    txtbinayas.Text = gunlukVerileri[i, 10].ToString();

                }

            }
        }
        public void gunlukResimleriDiziyeAta()
        {
            tıklandıDizilerDoldu = true;
            kayitSayisiResim = -1;
            SqlConnection connectionResim = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdResim = new SqlCommand("select count(ilanNo) from gunlukResimler", connectionResim);
            connectionResim.Open();
            kayitSayisiResim = Convert.ToInt32(cmdResim.ExecuteScalar());
            connectionResim.Close();
            diziElemanSayResim = kayitSayisiResim - 1;
            ///*************************************************************************
            int sayaçResim = 0;
            //int kayıtSayısı= Convert.ToInt32(cmd.ExecuteScalar());
            gunlukVerileriResimler = new Image[kayitSayisiResim, 8];
            gunlukResimİlanNoları = new String[kayitSayisiResim];

            //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur

            SqlConnection connecResim = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdResimGetir = new SqlCommand("select * from gunlukResimler", connecResim);
            if (connecResim.State != ConnectionState.Open)
                connecResim.Open();
            SqlDataReader drResim = cmdResimGetir.ExecuteReader();
            while (drResim.Read())
            {
                gunlukResimİlanNoları[sayaçResim] = drResim["ilanNo"].ToString();//1
                Byte[] data = new Byte[0];
                data = (Byte[])(drResim["resim1"]);
                MemoryStream mem = new MemoryStream(data);
                gunlukVerileriResimler[sayaçResim, 0] = Image.FromStream(mem);
                mem.Close();

                Byte[] data2 = new Byte[1];
                data2 = (Byte[])(drResim["resim2"]);
                MemoryStream mem2 = new MemoryStream(data2);
                gunlukVerileriResimler[sayaçResim, 1] = Image.FromStream(mem2);

                Byte[] data3 = new Byte[2];
                data3 = (Byte[])(drResim["resim3"]);
                MemoryStream mem3 = new MemoryStream(data3);
                gunlukVerileriResimler[sayaçResim, 2] = Image.FromStream(mem3);

                Byte[] data4 = new Byte[3];
                data4 = (Byte[])(drResim["resim4"]);
                MemoryStream mem4 = new MemoryStream(data4);
                gunlukVerileriResimler[sayaçResim, 3] = Image.FromStream(mem4);
                mem4.Close();

                Byte[] data5 = new Byte[4];
                data5 = (Byte[])(drResim["resim5"]);
                MemoryStream mem5 = new MemoryStream(data5);
                gunlukVerileriResimler[sayaçResim, 4] = Image.FromStream(mem5);


                Byte[] data6 = new Byte[5];
                data6 = (Byte[])(drResim["resim6"]);
                MemoryStream mem6 = new MemoryStream(data6);
                gunlukVerileriResimler[sayaçResim, 5] = Image.FromStream(mem6);

                Byte[] data7 = new Byte[6];
                data7 = (Byte[])(drResim["resim7"]);
                MemoryStream mem7 = new MemoryStream(data7);
                gunlukVerileriResimler[sayaçResim, 6] = Image.FromStream(mem7);

                Byte[] data8 = new Byte[7];
                data8 = (Byte[])(drResim["resim4"]);
                MemoryStream mem8 = new MemoryStream(data8);
                gunlukVerileriResimler[sayaçResim, 7] = Image.FromStream(mem8);

                sayaçResim++;
            }
            connecResim.Close();

        }

        private void btndegistir_Click(object sender, EventArgs e)
        {
            try
            {
                if (tıklandıDizilerDoldu == false)
                {
                    gunlukResimleriDiziyeAta();
                    gunlukVerileriDiziyeAta();
                }
                if (gunlukVerileri != null || gunlukVerileriResimler != null || diziElemanSay != -1 || diziElemanSayResim != -1)
                {
                    texbaxlarıDokunulmazYap(false);

                    if (diziElemanSay <= 0)
                    {
                        txtilanno.Text = gunlukVerileri[diziElemanSay, 0].ToString();
                        lblkayıttarıh.Text = gunlukVerileri[diziElemanSay, 1].ToString();
                        txtmetre.Text = gunlukVerileri[diziElemanSay, 2].ToString();
                        txtodasayısı.Text = gunlukVerileri[diziElemanSay, 3].ToString();
                        txtkat.Text = gunlukVerileri[diziElemanSay, 4].ToString();
                        cmbxısıtma.Text = gunlukVerileri[diziElemanSay, 5].ToString();
                        txtfiyat.Text = gunlukVerileri[diziElemanSay, 6].ToString();
                        txtadres.Text = gunlukVerileri[diziElemanSay, 7].ToString();
                        cmbxwifi.Text = gunlukVerileri[diziElemanSay, 8].ToString();
                        cmbtv.Text = gunlukVerileri[diziElemanSay, 9].ToString();
                        txtbinayas.Text = gunlukVerileri[diziElemanSay, 10].ToString();
                        diziElemanSay = kayitSayisi - 1;
                    }
                    else
                    {

                        txtilanno.Text = gunlukVerileri[diziElemanSay, 0].ToString();
                        lblkayıttarıh.Text = gunlukVerileri[diziElemanSay, 1].ToString();
                        txtmetre.Text = gunlukVerileri[diziElemanSay, 2].ToString();
                        txtodasayısı.Text = gunlukVerileri[diziElemanSay, 3].ToString();
                        txtkat.Text = gunlukVerileri[diziElemanSay, 4].ToString();
                        cmbxısıtma.Text = gunlukVerileri[diziElemanSay, 5].ToString();
                        txtfiyat.Text = gunlukVerileri[diziElemanSay, 6].ToString();
                        txtadres.Text = gunlukVerileri[diziElemanSay, 7].ToString();
                        cmbxwifi.Text = gunlukVerileri[diziElemanSay, 8].ToString();
                        cmbtv.Text = gunlukVerileri[diziElemanSay, 9].ToString();
                        txtbinayas.Text = gunlukVerileri[diziElemanSay, 10].ToString();
                        diziElemanSay--;

                    }
                    if (diziElemanSayResim <= 0)
                    {
                        pictureBox2.Image = gunlukVerileriResimler[diziElemanSayResim, 0];
                        pictureBox3.Image = gunlukVerileriResimler[diziElemanSayResim, 1];
                        pictureBox4.Image = gunlukVerileriResimler[diziElemanSayResim, 2];
                        pictureBox5.Image = gunlukVerileriResimler[diziElemanSayResim, 3];
                        pictureBox6.Image = gunlukVerileriResimler[diziElemanSayResim, 4];
                        pictureBox9.Image = gunlukVerileriResimler[diziElemanSayResim, 5];
                        pictureBox10.Image = gunlukVerileriResimler[diziElemanSayResim, 6];
                        pictureBox11.Image = gunlukVerileriResimler[diziElemanSayResim, 7];
                        diziElemanSayResim = kayitSayisiResim - 1;
                    }
                    else
                    {

                        pictureBox2.Image = gunlukVerileriResimler[diziElemanSayResim, 0];
                        pictureBox3.Image = gunlukVerileriResimler[diziElemanSayResim, 1];
                        pictureBox4.Image = gunlukVerileriResimler[diziElemanSayResim, 2];
                        pictureBox5.Image = gunlukVerileriResimler[diziElemanSayResim, 3];
                        pictureBox6.Image = gunlukVerileriResimler[diziElemanSayResim, 4];
                        pictureBox9.Image = gunlukVerileriResimler[diziElemanSayResim, 5];
                        pictureBox10.Image = gunlukVerileriResimler[diziElemanSayResim, 6];
                        pictureBox11.Image = gunlukVerileriResimler[diziElemanSayResim, 7];
                        diziElemanSayResim--;
                    }
                }
                else
                {
                    MessageBox.Show("KAYIT YOK !");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("VERİ YOK");
            }
                    
            
        }

        private void cmbxwifi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbtv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbxısıtma_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnbul_Click(object sender, EventArgs e)
        {
            if (txtilanNoGoster.Text == "")
            {
                MessageBox.Show("İLAN NUMARASI GİRMELİSİN TAKVİMDEN TARİHE GÖREDE DE SEÇEBİLİRSİN");
            }
            else
            {

                gunlukGuncelleVeriTabanındanVerileriCek();
                //**********************************************************************************************************************
                //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur
                gunlukGuncelleVeriTabanındanResımCek();
            }
        }
        public void gunlukGuncelleVeriTabanındanResımCek()
        {
            SqlConnection conresımgetir = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdresimgetir = new SqlCommand("select * from gunlukResimler where ilanNo=@RsmİlanNo", conresımgetir);
            cmdresimgetir.Parameters.AddWithValue("@RsmİlanNo", txtilanNoGoster.Text);

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
                    pictureBox2.Image = Image.FromStream(mem);
                    mem.Close();

                    Byte[] data2 = new Byte[1];
                    data2 = (Byte[])(dr["resim2"]);
                    MemoryStream mem2 = new MemoryStream(data2);
                    pictureBox3.Image = Image.FromStream(mem2);

                    Byte[] data3 = new Byte[2];
                    data3 = (Byte[])(dr["resim3"]);
                    MemoryStream mem3 = new MemoryStream(data3);
                    pictureBox4.Image = Image.FromStream(mem3);

                    Byte[] data4 = new Byte[3];
                    data4 = (Byte[])(dr["resim4"]);
                    MemoryStream mem4 = new MemoryStream(data4);
                    pictureBox5.Image = Image.FromStream(mem4);
                    mem4.Close();

                    Byte[] data5 = new Byte[4];
                    data5 = (Byte[])(dr["resim5"]);
                    MemoryStream mem5 = new MemoryStream(data5);
                    pictureBox6.Image = Image.FromStream(mem5);


                    Byte[] data6 = new Byte[5];
                    data6 = (Byte[])(dr["resim6"]);
                    MemoryStream mem6 = new MemoryStream(data6);
                    pictureBox9.Image = Image.FromStream(mem6);

                    Byte[] data7 = new Byte[6];
                    data7 = (Byte[])(dr["resim7"]);
                    MemoryStream mem7 = new MemoryStream(data7);
                    pictureBox10.Image = Image.FromStream(mem7);

                    Byte[] data8 = new Byte[7];
                    data8 = (Byte[])(dr["resim4"]);
                    MemoryStream mem8 = new MemoryStream(data8);
                    pictureBox11.Image = Image.FromStream(mem8);
                }
                else
                {
                    txtilanNoGoster.Text = "";
                    pictureBox1.ImageLocation = Application.StartupPath + "\\gunlukdefault.png";
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    pictureBox4.Image = null;
                    pictureBox5.Image = null;
                    pictureBox6.Image = null;
                    pictureBox9.Image = null;
                    pictureBox10.Image = null;
                    pictureBox11.Image = null;

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
        public void gunlukGuncelleVeriTabanındanVerileriCek()
        {
            //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur
            SqlConnection con = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from gunlukEv where ilanNo=@id", con);
            cmd.Parameters.AddWithValue("@id", txtilanNoGoster.Text);

            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    txtilanno.Text = dr["ilanNo"].ToString();//1
                    lblkayıttarıh.Text = dr["ilanTarihi"].ToString();//fazla
                    txtmetre.Text = dr["metrekare"].ToString();//2
                    txtodasayısı.Text = dr["odasayısı"].ToString();//3
                    txtkat.Text = dr["bulundugukat"].ToString();//4
                    cmbxısıtma.Text = dr["ısıtma"].ToString();//5
                    txtfiyat.Text = dr["fiyat"].ToString();//6
                    txtadres.Text = dr["adres"].ToString();//7
                    cmbxwifi.Text = dr["wifi"].ToString();//8
                    cmbtv.Text = dr["tv"].ToString();//9
                    txtbinayas.Text = dr["binayası"].ToString();//10
            }

            catch (Exception)
            {
                txtilanNoGoster.Text = "";
                MessageBox.Show("BU İLAN NUMARASINA AİT KAYIT YOK");
                txtilanno.Text = "";
                lblkayıttarıh.Text = "";
                txtmetre.Text = "";
                txtodasayısı.Text = "";
                txtkat.Text = "";
                cmbxısıtma.Text = "";
                txtfiyat.Text = "";
                txtadres.Text = "";
                cmbxwifi.Text = "";
                cmbtv.Text = "";
                txtbinayas.Text = "";


            }
            finally
            {
                con.Close();

            }
        }

       

        private void btngunlukduzenle_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {

                duzenleAcık = false;
                texbaxlarıDokunulmazYap(false);
                btngunlukguncelle.Enabled = false;
                btngunluksil.Enabled = true;
                panel1.BackColor = Color.Red;

            }
            else
            {
                duzenleAcık = true;
                texbaxlarıDokunulmazYap(true);
                btngunlukguncelle.Enabled = true;
                btngunluksil.Enabled = false;
                panel1.BackColor = Color.Green;


            }

            //txtilanno.Enabled = true;


        }

        private void btngunlukguncelle_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                try
                {
                    if (txtilanno.Text != "" && txtmetre.Text != "" && txtodasayısı.Text != "" && txtkat.Text != "" && cmbxısıtma.Text != "" && txtfiyat.Text != "" && txtadres.Text != "" && cmbxwifi.Text != "" && cmbtv.Text != "" && txtbinayas.Text != "")
                    {

                        if (pictureBox2.ImageLocation !=null && pictureBox3.ImageLocation != null && pictureBox4.ImageLocation !=null && pictureBox5.ImageLocation != null && pictureBox6.ImageLocation != null && pictureBox9.ImageLocation != null && pictureBox10.ImageLocation != null && pictureBox11.ImageLocation != null)
                        {
                            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                            if (secenek == DialogResult.Yes)
                            {
                                resimGuncelle();
                                verileriGuncelle();
                                YazılarıTemizle();
                                ResimleriTEmizle();
                                tıklandıDizilerDoldu = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("RESİMLER DEGİŞMEDEN GÜNCELLENMEZ");
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
            else
            {
                MessageBox.Show("DÜZENLEME YAPMAK İÇİN DUZENLE YE TIKLA");
            }
        }
        public void verileriGuncelle()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sorgu = "update gunlukEv set ilanTarihi=@ilanTarihi,metrekare=@metrekare,odasayısı=@odasayısı,binayası=@binayası,bulundugukat=@bulundugukat,ısıtma=@ısıtma,fiyat=@fiyat,adres=@adres,wifi=@wifi,tv=@tv where ilanNo=@ilanNo";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@ilanTarihi", lblkayıttarıh.Text);
            cmd.Parameters.AddWithValue("@metrekare", txtmetre.Text);
            cmd.Parameters.AddWithValue("@odasayısı", txtodasayısı.Text);
            cmd.Parameters.AddWithValue("@binayası", txtbinayas.Text);
            cmd.Parameters.AddWithValue("@bulundugukat", txtkat.Text);
            cmd.Parameters.AddWithValue("@ısıtma", cmbxısıtma.Text);
            cmd.Parameters.AddWithValue("@wifi", cmbxwifi.Text);
            cmd.Parameters.AddWithValue("@tv", cmbtv.Text);
            cmd.Parameters.AddWithValue("@fiyat", txtfiyat.Text);
            cmd.Parameters.AddWithValue("@adres", txtadres.Text);
            cmd.Parameters.AddWithValue("@ilanNo", txtilanno.Text);

            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("GÜNCELLEME İŞLEMİ BAŞARILI…");
                baglanti.Close();
                texbaxlarıDokunulmazYap(false);

            }
            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("GÜNCELLEME İŞLEMİ BAŞARISIZ…");
                baglanti.Close();
            }

        }
        public void texbaxlarıDokunulmazYap(bool veri)
        {
            lblkayıttarıh.Enabled = veri;
            txtmetre.Enabled = veri;
            txtodasayısı.Enabled = veri;
            txtkat.Enabled = veri;
            cmbxısıtma.Enabled = veri;
            txtfiyat.Enabled = veri;
            txtadres.Enabled = veri;
            cmbxwifi.Enabled = veri;
            cmbtv.Enabled = veri;
            txtbinayas.Enabled = veri;

        }
        public void ResimleriTEmizle()
        {

            pictureBox1.ImageLocation = Application.StartupPath + "\\gunlukdefault.png";
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox9.Image = null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
        }
        public void YazılarıTemizle()
        {
            txtilanNoGoster.Text = "";
            txtilanno.Text = "";
            lblkayıttarıh.Text = "";
            txtmetre.Text = "";
            txtodasayısı.Text = "";
            txtkat.Text = "";
            cmbxısıtma.Text = "";
            txtfiyat.Text = "";
            txtadres.Text = "";
            cmbxwifi.Text = "";
            cmbtv.Text = "";
            txtbinayas.Text = "";
        }
        public void gunlukResimleriVeritabanınaKaydet()
        {
            try
            {
                FileStream fs1 = new FileStream(pictureBox2.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br1 = new BinaryReader(fs1);
                byte[] resim1 = br1.ReadBytes((int)fs1.Length);
                br1.Close();
                fs1.Close();

                FileStream fs2 = new FileStream(pictureBox3.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br2 = new BinaryReader(fs2);
                byte[] resim2 = br2.ReadBytes((int)fs2.Length);
                br2.Close();
                fs2.Close();

                FileStream fs3 = new FileStream(pictureBox4.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br3 = new BinaryReader(fs3);
                byte[] resim3 = br3.ReadBytes((int)fs3.Length);
                br3.Close();
                fs3.Close();

                FileStream fs4 = new FileStream(pictureBox5.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br4 = new BinaryReader(fs4);
                byte[] resim4 = br4.ReadBytes((int)fs4.Length);
                br4.Close();
                fs4.Close();

                FileStream fs5 = new FileStream(pictureBox6.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br5 = new BinaryReader(fs5);
                byte[] resim5 = br5.ReadBytes((int)fs5.Length);
                br5.Close();
                fs5.Close();

                FileStream fs6 = new FileStream(pictureBox9.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br6 = new BinaryReader(fs6);
                byte[] resim6 = br6.ReadBytes((int)fs6.Length);
                br6.Close();
                fs6.Close();

                FileStream fs7 = new FileStream(pictureBox10.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br7 = new BinaryReader(fs7);
                byte[] resim7 = br7.ReadBytes((int)fs7.Length);
                br7.Close();
                fs7.Close();

                FileStream fs8 = new FileStream(pictureBox11.ImageLocation, FileMode.Open, FileAccess.Read);
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
            catch (Exception)
            {

                MessageBox.Show("RESİM KAYDEDILEMEDİ");
            }
        }
     
        public void resimGuncelle()
        {
            
            string silmeSorgusu = "DELETE from gunlukResimler where ilanNo=@ilannn";
            //musterino parametresine bağlı olarak müşteri kaydını silen sql sorgusu
            SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
            silKomutu.Parameters.AddWithValue("@ilannn", txtilanno.Text);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            silKomutu.ExecuteNonQuery();
            //MessageBox.Show("Kayıt Silindi...");
            baglanti.Close();

            gunlukResimleriVeritabanınaKaydet();

              

                // texbaxlarıDokunulmazYap(false);
                //resimleri seçilmeyı kaldır

            
          
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "dalkılınçEMLAK";
                dosya.ShowDialog();
                pictureBox3.ImageLocation = dosya.FileName;
            }
            else
            {
                pictureBox1.Image = pictureBox3.Image;
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "dalkılınçEMLAK";
                dosya.ShowDialog();
                /* string DosyaYolu = dosya.FileName;

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
                 }*/
                pictureBox2.ImageLocation = dosya.FileName;
            }
            else
            {
                pictureBox1.Image = pictureBox2.Image;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "dalkılınçEMLAK";
                dosya.ShowDialog();
                pictureBox4.ImageLocation = dosya.FileName;
            }
            else
            {
                pictureBox1.Image = pictureBox4.Image;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "dalkılınçEMLAK";
                dosya.ShowDialog();
                pictureBox5.ImageLocation = dosya.FileName;
            }
            else
            {
                pictureBox1.Image = pictureBox5.Image;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "dalkılınçEMLAK";
                dosya.ShowDialog();
                pictureBox6.ImageLocation = dosya.FileName;
            }
            else
            {
                pictureBox1.Image = pictureBox6.Image;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "dalkılınçEMLAK";
                dosya.ShowDialog();
                pictureBox11.ImageLocation = dosya.FileName;
            }
            else
            {
                pictureBox1.Image = pictureBox11.Image;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "dalkılınçEMLAK";
                dosya.ShowDialog();
                pictureBox10.ImageLocation = dosya.FileName;
            }
            else
            {
                pictureBox1.Image = pictureBox10.Image;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (duzenleAcık == true)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "dalkılınçEMLAK";
                dosya.ShowDialog();
                pictureBox9.ImageLocation = dosya.FileName;
            }
            else
            {
                pictureBox1.Image = pictureBox9.Image;
            }
        }

        private void btngunluksil_Click(object sender, EventArgs e)
        {
          
                try
                {
                    if (txtilanno.Text != "" && txtmetre.Text != "" && txtodasayısı.Text != "" && txtkat.Text != "" && cmbxısıtma.Text != "" && txtfiyat.Text != "" && txtadres.Text != "" && cmbxwifi.Text != "" && cmbtv.Text != "" && txtbinayas.Text != "")
                    {                 
                          
                        DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (secenek == DialogResult.Yes)
                        {

                            resimlerisil();
                            verilerisil();
                            YazılarıTemizle();
                            ResimleriTEmizle();
                            tıklandıDizilerDoldu = false;
                        }
                        else if (secenek==DialogResult.No)
                        {
                            MessageBox.Show("İŞLEM İPTAL EDİLDİ");
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
        public void resimlerisil()
        {
            string silmeSorgusu = "DELETE from gunlukResimler where ilanNo=@ilannn";
            //musterino parametresine bağlı olarak müşteri kaydını silen sql sorgusu
            SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
            silKomutu.Parameters.AddWithValue("@ilannn", txtilanno.Text);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            silKomutu.ExecuteNonQuery();
            //MessageBox.Show("Kayıt Silindi...");
            baglanti.Close();
        }
        public void verilerisil()
        {
            string silmeSorgusu = "DELETE from gunlukEv where ilanNo=@ilannn";
            //musterino parametresine bağlı olarak müşteri kaydını silen sql sorgusu
            SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
            silKomutu.Parameters.AddWithValue("@ilannn", txtilanno.Text);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            silKomutu.ExecuteNonQuery();
            //MessageBox.Show("Kayıt Silindi...");
            baglanti.Close();

        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            TariheGöreKayıtlar tarihsırala = new TariheGöreKayıtlar();
            tarihsırala.tarih = dateTimePicker1.Value.ToShortDateString();
            tarihsırala.gunluk = true;
            tarihsırala.satılık = false;
            tarihsırala.arsa = false;
            tarihsırala.kiralık = false;
            tarihsırala.ShowDialog();

            if (tarihsırala.listView1.SelectedItems.Count > 0)
            {
                txtilanNoGoster.Text = tarihsırala.listView1.SelectedItems[0].Text.ToString();
            }
            else
            {
                txtilanNoGoster.Text = "";
            }
        }

        private void txtilanNoGoster_TextChanged(object sender, EventArgs e)
        {
            pnluyarı.BackColor = Color.Red;
            
          
        }

        private void HarfGirisEngelle(object sender, KeyPressEventArgs e)
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

        private void txtfiyat_TextChanged(object sender, EventArgs e)
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
