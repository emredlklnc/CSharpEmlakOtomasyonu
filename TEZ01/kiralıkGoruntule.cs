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
    public partial class kiralıkGoruntule : Form
    {
        public kiralıkGoruntule()
        {
            InitializeComponent();
        }
        string[,] kiralıkVerileri;
        string[] kiralıkResimİlanNoları;
        Image[,] kiralıkVerileriResimler;
        int kayitSayisi;
        int kayitSayisiResim;
        int diziElemanSay = 0;
        int diziElemanSayResim = 0;

        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        private void btnilanNoGöster_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtilanNoGoster.Text != "")
                {

                    kiralıkVerileriDiziyeAta();
                    kiralıkVerilerDizisiniEkranaBas();
                    kiralıkResimleriDiziyeAta();
                    kiralıkResimlerDizisiniEkranaBas();
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
        public void kiralıkResimlerDizisiniEkranaBas()
        {
            bool veriVar = false;
            for (int i = 0; i < kayitSayisiResim; i++)
            {
                if (kiralıkResimİlanNoları[i].ToString() == txtilanNoGoster.Text.ToString())
                {
                    pictureBox7.Image = kiralıkVerileriResimler[i, 0];
                    pictureBox10.Image = kiralıkVerileriResimler[i, 1];
                    pictureBox11.Image = kiralıkVerileriResimler[i, 2];
                    pictureBox12.Image = kiralıkVerileriResimler[i, 3];
                    veriVar = true;
                }
            }
            if (veriVar==false)
            {
                Temizle();
            }
        }
        public void kiralıkVerilerDizisiniEkranaBas()
        {
            for (int i = 0; i < kayitSayisi; i++)
            {
                if (kiralıkVerileri[i, 0].ToString() == txtilanNoGoster.Text.ToString())
                {
                    lblilanNo.Text = kiralıkVerileri[i, 0].ToString();
                    lblkayıttarih.Text = kiralıkVerileri[i, 1].ToString();
                    lblmetrekare.Text = kiralıkVerileri[i, 2].ToString();
                    lblodasayısı.Text = kiralıkVerileri[i, 3].ToString();
                    lblbinayası.Text = kiralıkVerileri[i, 4].ToString();
                    lblkat.Text = kiralıkVerileri[i, 5].ToString();
                    lblısıtma.Text = kiralıkVerileri[i, 6].ToString();
                    lblesyalı.Text = kiralıkVerileri[i, 7].ToString();
                    lblaidat.Text = kiralıkVerileri[i, 8].ToString();
                    lblfiyat.Text = kiralıkVerileri[i, 9].ToString();
                    lbladres.Text = kiralıkVerileri[i, 10].ToString();
                    lbltur.Text = kiralıkVerileri[i, 11].ToString();
                }

            }
        }
        public void kiralıkVerileriDiziyeAta()
        {
            //Select COUNT(ilanNo)From satılık
            kayitSayisi = -1;
            SqlConnection connection = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("select count(ilanNo) from kiralık where MusteriTc is NULL", connection);
            connection.Open();
            kayitSayisi = Convert.ToInt32(cmd2.ExecuteScalar());
            connection.Close();
            diziElemanSay = kayitSayisi - 1;
            ////*****************kayıt sayısını bulma************************************        
            //*******************************************************************************************************
            int sayaç = 0;
            kiralıkVerileri = new string[kayitSayisi, 12];

            SqlConnection connec = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from kiralık where MusteriTc is NULL", connec);
            if (connec.State != ConnectionState.Open)
                connec.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                kiralıkVerileri[sayaç, 0] = dr["ilanNo"].ToString();//1
                kiralıkVerileri[sayaç, 1] = dr["ilanTarihi"].ToString();//fazla
                kiralıkVerileri[sayaç, 2] = dr["metrekare"].ToString();//2
                kiralıkVerileri[sayaç, 3] = dr["odasayısı"].ToString();//3
                kiralıkVerileri[sayaç, 4] = dr["binayası"].ToString();//4
                kiralıkVerileri[sayaç, 5] = dr["bulundugukat"].ToString();//5
                kiralıkVerileri[sayaç, 6] = dr["ısıtma"].ToString();//6
                kiralıkVerileri[sayaç, 7] = dr["esyalı"].ToString();//7
                kiralıkVerileri[sayaç, 8] = dr["aidat"].ToString();//8
                kiralıkVerileri[sayaç, 9] = dr["fiyat"].ToString();//9
                kiralıkVerileri[sayaç, 10] = dr["adres"].ToString();//10
                kiralıkVerileri[sayaç, 11] = dr["Tur"].ToString();//11
                sayaç++;
            }
            connec.Close();
        }
        bool tıklandıDizilerDoldu = false;
        public void kiralıkResimleriDiziyeAta()
        {
            tıklandıDizilerDoldu = true;
            kayitSayisiResim = -1;
            SqlConnection connectionResim = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdResim = new SqlCommand("select count(ilanNo) from ResimlerKiralık where musteriTc is NULL", connectionResim);
            connectionResim.Open();
            kayitSayisiResim = Convert.ToInt32(cmdResim.ExecuteScalar());
            connectionResim.Close();
            diziElemanSayResim = kayitSayisiResim - 1;
            ///*************************************************************************
            int sayaçResim = 0;
            //int kayıtSayısı= Convert.ToInt32(cmd.ExecuteScalar());
            kiralıkVerileriResimler = new Image[kayitSayisiResim, 4];
            kiralıkResimİlanNoları = new String[kayitSayisiResim];

            //ilanTarihi,metrekare,odasayısı,binayası,bulundugukat,ısıtma,esyalı,aidat,fiyat,adres,ilanNo,Tur

            SqlConnection connecResim = new SqlConnection(baglanti.ConnectionString);
            SqlCommand cmdResimGetir = new SqlCommand("select * from ResimlerKiralık where musteriTc is NULL", connecResim);
            if (connecResim.State != ConnectionState.Open)
                connecResim.Open();
            SqlDataReader drResim = cmdResimGetir.ExecuteReader();
            while (drResim.Read())
            {
                kiralıkResimİlanNoları[sayaçResim] = drResim["ilanNo"].ToString();//1
                Byte[] data = new Byte[0];
                data = (Byte[])(drResim["resim1"]);
                MemoryStream mem = new MemoryStream(data);
                kiralıkVerileriResimler[sayaçResim, 0] = Image.FromStream(mem);
                mem.Close();

                Byte[] data2 = new Byte[1];
                data2 = (Byte[])(drResim["resim2"]);
                MemoryStream mem2 = new MemoryStream(data2);
                kiralıkVerileriResimler[sayaçResim, 1] = Image.FromStream(mem2);

                Byte[] data3 = new Byte[2];
                data3 = (Byte[])(drResim["resim3"]);
                MemoryStream mem3 = new MemoryStream(data3);
                kiralıkVerileriResimler[sayaçResim, 2] = Image.FromStream(mem3);

                Byte[] data4 = new Byte[3];
                data4 = (Byte[])(drResim["resim4"]);
                MemoryStream mem4 = new MemoryStream(data4);
                kiralıkVerileriResimler[sayaçResim, 3] = Image.FromStream(mem4);
                sayaçResim++;
            }
            connecResim.Close();

        }
        public void Temizle()
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
            pictureBox7.Image =null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
            pictureBox12.Image = null;

        }
        private void btnkirala_Click(object sender, EventArgs e)
        {
            if (lblilanNo.Text != "...")
            {
                satınAlMusteriKaydet stnal1 = new satınAlMusteriKaydet();
                stnal1.ilanNo = lblilanNo.Text;
                stnal1.satılık = false;
                stnal1.kiralık = true;
                stnal1.arsa = false;
                stnal1.gunluk = false;
                stnal1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kiralamak İçin Bir İlan Seçmelisiniz");
            }
        }

        private void txtilanNoGoster_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btneksidiger_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tıklandıDizilerDoldu == false)
                {
                    kiralıkResimleriDiziyeAta();
                    kiralıkVerileriDiziyeAta();
                }
                if (kiralıkVerileri != null || kiralıkVerileriResimler != null || diziElemanSay != -1 || diziElemanSayResim != -1)
                {
                    txtilanNoGoster.Text = "";

                    if (diziElemanSay <= 0)
                    {

                        lblilanNo.Text = kiralıkVerileri[diziElemanSay, 0].ToString();
                        lblkayıttarih.Text = kiralıkVerileri[diziElemanSay, 1].ToString();
                        lblmetrekare.Text = kiralıkVerileri[diziElemanSay, 2].ToString();
                        lblodasayısı.Text = kiralıkVerileri[diziElemanSay, 3].ToString();
                        lblbinayası.Text = kiralıkVerileri[diziElemanSay, 4].ToString();
                        lblkat.Text = kiralıkVerileri[diziElemanSay, 5].ToString();
                        lblısıtma.Text = kiralıkVerileri[diziElemanSay, 6].ToString();
                        lblesyalı.Text = kiralıkVerileri[diziElemanSay, 7].ToString();
                        lblaidat.Text = kiralıkVerileri[diziElemanSay, 8].ToString();
                        lblfiyat.Text = kiralıkVerileri[diziElemanSay, 9].ToString();
                        lbladres.Text = kiralıkVerileri[diziElemanSay, 10].ToString();
                        lbltur.Text = kiralıkVerileri[diziElemanSay, 11].ToString();
                        diziElemanSay = kayitSayisi - 1;

                    }
                    else
                    {

                        lblilanNo.Text = kiralıkVerileri[diziElemanSay, 0].ToString();
                        lblkayıttarih.Text = kiralıkVerileri[diziElemanSay, 1].ToString();
                        lblmetrekare.Text = kiralıkVerileri[diziElemanSay, 2].ToString();
                        lblodasayısı.Text = kiralıkVerileri[diziElemanSay, 3].ToString();
                        lblbinayası.Text = kiralıkVerileri[diziElemanSay, 4].ToString();
                        lblkat.Text = kiralıkVerileri[diziElemanSay, 5].ToString();
                        lblısıtma.Text = kiralıkVerileri[diziElemanSay, 6].ToString();
                        lblesyalı.Text = kiralıkVerileri[diziElemanSay, 7].ToString();
                        lblaidat.Text = kiralıkVerileri[diziElemanSay, 8].ToString();
                        lblfiyat.Text = kiralıkVerileri[diziElemanSay, 9].ToString();
                        lbladres.Text = kiralıkVerileri[diziElemanSay, 10].ToString();
                        lbltur.Text = kiralıkVerileri[diziElemanSay, 11].ToString();
                        diziElemanSay--;

                    }
                    if (diziElemanSayResim <= 0)
                    {

                        pictureBox7.Image = kiralıkVerileriResimler[diziElemanSayResim, 0];
                        pictureBox10.Image = kiralıkVerileriResimler[diziElemanSayResim, 1];
                        pictureBox11.Image = kiralıkVerileriResimler[diziElemanSayResim, 2];
                        pictureBox12.Image = kiralıkVerileriResimler[diziElemanSayResim, 3];
                        diziElemanSayResim = kayitSayisiResim - 1;
                    }
                    else
                    {

                        pictureBox7.Image = kiralıkVerileriResimler[diziElemanSayResim, 0];
                        pictureBox10.Image = kiralıkVerileriResimler[diziElemanSayResim, 1];
                        pictureBox11.Image = kiralıkVerileriResimler[diziElemanSayResim, 2];
                        pictureBox12.Image = kiralıkVerileriResimler[diziElemanSayResim, 3];
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
