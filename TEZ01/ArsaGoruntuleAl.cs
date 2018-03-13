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
    public partial class ArsaGoruntuleAl : Form
    {
        public ArsaGoruntuleAl()
        {
            InitializeComponent();
        }
       

        string[,] satılıkVerileri;
        string[] satılıkResimİlanNoları;
        Image[,] satılıkVerileriResimler;
        int kayitSayisi;
        int kayitSayisiResim;
        int diziElemanSay = 0;
        int diziElemanSayResim = 0;

        bool tıklandıDizilerDoldu = false;
        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
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
        public void arsaResimlerDizisiniEkranaBas()
        {
            bool VeriVar = false;
            for (int i = 0; i < kayitSayisiResim; i++)
            {
                if (satılıkResimİlanNoları[i].ToString() == txtilanNoGoster.Text.ToString())
                {
                    pictureBox7.Image = satılıkVerileriResimler[i, 0];
                    pictureBox10.Image = satılıkVerileriResimler[i, 1];
                    pictureBox11.Image = satılıkVerileriResimler[i, 2];
                    pictureBox12.Image = satılıkVerileriResimler[i, 3];
                    VeriVar = true;
                }
              
            }
            if (VeriVar==false)
            {
                silVerileriTemizle();
                txtilanNoGoster.Text = "";
            }

        }
        public void silVerileriTemizle()
        {
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
        public void arsaVerilerDizisiniEkranaBas()
        {
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

                }

            }
        }
        public void arsaVerileriDiziyeAta()
        {
            //Select COUNT(ilanNo)From satılık
            kayitSayisi = -1;
            SqlConnection connection = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("select count(ilanNo) from Arsa where MusteriTc is NULL", connection);
            connection.Open();
            kayitSayisi = Convert.ToInt32(cmd2.ExecuteScalar());
            connection.Close();
            diziElemanSay = kayitSayisi - 1;
            ////*****************kayıt sayısını bulma************************************        
            //*******************************************************************************************************
            int sayaç = 0;
            satılıkVerileri = new string[kayitSayisi, 6];

            SqlConnection connec = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Arsa where MusteriTc is NULL", connec);
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
            SqlCommand cmdResim = new SqlCommand("select count(ilanNo) from ArsaResimler where musteriTc is NULL", connectionResim);
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
            SqlCommand cmdResimGetir = new SqlCommand("select * from ArsaResimler where musteriTc is NULL", connecResim);
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
        private void btneksidiger_Click(object sender, EventArgs e)
        {
           
           

        }

        private void btnarsaal_Click(object sender, EventArgs e)
        {
            if (lblilanNo.Text != "...")
            {
                satınAlMusteriKaydet stnal1 = new satınAlMusteriKaydet();
                stnal1.ilanNo = lblilanNo.Text;
                stnal1.satılık = false;
                stnal1.kiralık = false;
                stnal1.arsa = true;
                stnal1.gunluk = false;
                stnal1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Günlük Evi Kiralamak İçin Bir İlan Seçmelisiniz");
            }
        }

        private void btneksidiger_Click_1(object sender, EventArgs e)
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
                    MessageBox.Show("KAYIT YOK !");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("VERİ YOK");
            }

        }
    }
}
