using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEZ01
{
    public partial class gunlukEvleriGoruntule : Form
    {
        public gunlukEvleriGoruntule()
        {
            InitializeComponent();
        }
        string[,] gunlukVerileri;
        string[] gunlukResimİlanNoları;
        Image[,] gunlukVerileriResimler;
        int kayitSayisi;
        int kayitSayisiResim;
        int diziElemanSay = 0;
        int diziElemanSayResim = 0;
        bool tıklandıDizilerDoldu = false;
        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        public void gunlukVerileriDiziyeAta()
        {
            //Select COUNT(ilanNo)From satılık
            kayitSayisi = -1;
            SqlConnection connection = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("select count(ilanNo) from gunlukEv where MusteriTc is NULL", connection);
            connection.Open();
            kayitSayisi = Convert.ToInt32(cmd2.ExecuteScalar());
            connection.Close();
            diziElemanSay = kayitSayisi - 1;
            ////*****************kayıt sayısını bulma************************************        
            //*******************************************************************************************************
            int sayaç = 0;
            gunlukVerileri = new string[kayitSayisi, 11];

            SqlConnection connec = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from gunlukEv where MusteriTc is NULL", connec);
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
            SqlCommand cmdResim = new SqlCommand("select count(ilanNo) from gunlukResimler where musteriTc is NULL", connectionResim);
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
            SqlCommand cmdResimGetir = new SqlCommand("select * from gunlukResimler where musteriTc is NULL", connecResim);
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
            SqlCommand cmdresimgetir = new SqlCommand("select * from gunlukResimler where ilanNo=@RsmİlanNo AND musteriTc is NULL", conresımgetir);
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
            SqlCommand cmd = new SqlCommand("select * from gunlukEv where ilanNo=@id AND MusteriTc is NULL", con);
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

                MessageBox.Show("BU İLAN NUMARASINA AİT KAYIT YOK");
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
            finally
            {
                con.Close();

            }
        }
        private void btndegistir_Click(object sender, EventArgs e)
        {
           
                    
           
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
                pictureBox1.Image = pictureBox2.Image;
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
                pictureBox1.Image = pictureBox3.Image;
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
          
                pictureBox1.Image = pictureBox4.Image;
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

           
                pictureBox1.Image = pictureBox5.Image;
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
                pictureBox1.Image = pictureBox6.Image;
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
           
                pictureBox1.Image = pictureBox11.Image;
            
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
          
                pictureBox1.Image = pictureBox10.Image;
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
           
                pictureBox1.Image = pictureBox9.Image;
            
        }

        private void btntut_Click(object sender, EventArgs e)
        {
            if (txtilanno.Text != "...")
            {
                satınAlMusteriKaydet stnal1 = new satınAlMusteriKaydet();
                stnal1.ilanNo = txtilanno.Text;
                stnal1.satılık = false;
                stnal1.kiralık = false;
                stnal1.arsa = false;
                stnal1.gunluk = true;
                stnal1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Günlük Evi Kiralamak İçin Bir İlan Seçmelisiniz");
            }
        }

        private void txtilanNoGoster_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btndegistir_Click_1(object sender, EventArgs e)
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
                    MessageBox.Show("KAYIT YOK");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("VERİ YOK");
            }
        }
    }
}
