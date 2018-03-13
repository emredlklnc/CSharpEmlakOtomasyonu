using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TEZ01
{
    public partial class TariheGöreKayıtlar : Form
    {
        public TariheGöreKayıtlar()
        {
            InitializeComponent();
        }
        public string tarih { get; set; }
        public bool kiralık { get; set; }
        public bool satılık { get; set; }
        public bool arsa { get; set; }
        public bool gunluk { get; set; }

        SqlConnection baglanti = new SqlConnection(@"Data Source = EMRE\EMRE; Initial Catalog =Emlak; Integrated Security = True");
        private void TariheGöreKayıtlar_Load(object sender, EventArgs e)
        {
            if (kiralık==true)
            {
                listView1.Columns.Add("İLAN NO", 79);
                listView1.Columns.Add("İLAN TARİHİ", 79);
                listView1.Columns.Add("METRE KARE", 79);
                listView1.Columns.Add("ODA SAYISI", 79);
                listView1.Columns.Add("BİNA YAŞI", 79);
                listView1.Columns.Add("KAT", 79);
                listView1.Columns.Add("ISITMA", 79);
                listView1.Columns.Add("EŞYALI", 79);
                listView1.Columns.Add("AİDAT", 79);
                listView1.Columns.Add("FİYAT", 79);
                listView1.Columns.Add("ADRES", 79);
                listView1.Columns.Add("TUR", 79);

                label2.Text = "KİRALIKLAR";
                SqlConnection con = new SqlConnection(baglanti.ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from kiralık where ilanTarihi=@tarih", con);
                cmd.Parameters.AddWithValue("@tarih", tarih);

                try
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        ListViewItem item = new ListViewItem(dr["ilanNo"].ToString());
                        item.SubItems.Add(dr["ilanTarihi"].ToString());
                        item.SubItems.Add(dr["metrekare"].ToString());
                        item.SubItems.Add(dr["odasayısı"].ToString());
                        item.SubItems.Add(dr["binayası"].ToString());
                        item.SubItems.Add(dr["bulundugukat"].ToString());
                        item.SubItems.Add(dr["ısıtma"].ToString());
                        item.SubItems.Add(dr["esyalı"].ToString());
                        item.SubItems.Add(dr["aidat"].ToString());
                        item.SubItems.Add(dr["fiyat"].ToString());
                        item.SubItems.Add(dr["adres"].ToString());
                        item.SubItems.Add(dr["Tur"].ToString());

                        listView1.Items.Add(item);

                    }

                }

                catch (Exception ex)
                {

                    MessageBox.Show("HATA" + ex.Message);

                }
                finally
                {
                    con.Close();

                }
            }
            else if(satılık==true)
            {

                listView1.Columns.Add("İLAN NO", 79);
                listView1.Columns.Add("İLAN TARİHİ", 79);
                listView1.Columns.Add("METRE KARE", 79);
                listView1.Columns.Add("ODA SAYISI", 79);
                listView1.Columns.Add("BİNA YAŞI", 79);
                listView1.Columns.Add("KAT", 79);
                listView1.Columns.Add("ISITMA", 79);
                listView1.Columns.Add("EŞYALI", 79);
                listView1.Columns.Add("AİDAT", 79);
                listView1.Columns.Add("FİYAT", 79);
                listView1.Columns.Add("ADRES", 79);
                listView1.Columns.Add("TUR", 79);

                label2.Text = "SATILIKLAR";
                SqlConnection con = new SqlConnection(baglanti.ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from satılık where ilanTarihi=@tarih", con);
                cmd.Parameters.AddWithValue("@tarih", tarih);

                try
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        ListViewItem item = new ListViewItem(dr["ilanNo"].ToString());
                        item.SubItems.Add(dr["ilanTarihi"].ToString());
                        item.SubItems.Add(dr["metrekare"].ToString());
                        item.SubItems.Add(dr["odasayısı"].ToString());
                        item.SubItems.Add(dr["binayası"].ToString());
                        item.SubItems.Add(dr["bulundugukat"].ToString());
                        item.SubItems.Add(dr["ısıtma"].ToString());
                        item.SubItems.Add(dr["esyalı"].ToString());
                        item.SubItems.Add(dr["aidat"].ToString());
                        item.SubItems.Add(dr["fiyat"].ToString());
                        item.SubItems.Add(dr["adres"].ToString());
                        item.SubItems.Add(dr["Tur"].ToString());
                        listView1.Items.Add(item);

                    }

                }

                catch (Exception ex)
                {

                    MessageBox.Show("HATA" + ex.Message);

                }
                finally
                {
                    con.Close();

                }
            }
            else if (arsa == true)
            {
                listView1.Columns.Add("İLAN NO", 79);
                listView1.Columns.Add("İLAN TARİHİ", 79);
                listView1.Columns.Add("METRE KARE", 79);
                listView1.Columns.Add("KAT KARŞILIGI", 79);
                listView1.Columns.Add("FİYAT", 79);
                listView1.Columns.Add("ADRES", 79);


                label2.Text = "ARSALAR";
                SqlConnection con = new SqlConnection(baglanti.ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from Arsa where ilanTarihi=@tarih", con);
                cmd.Parameters.AddWithValue("@tarih", tarih);

                try
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        ListViewItem item = new ListViewItem(dr["ilanNo"].ToString());
                        
                        item.SubItems.Add(dr["ilanTarihi"].ToString());
                        item.SubItems.Add(dr["metrekare"].ToString());
                        item.SubItems.Add(dr["katkarsılıgı"].ToString());
                        item.SubItems.Add(dr["fiyat"].ToString());
                        item.SubItems.Add(dr["adres"].ToString());
                        
                        listView1.Items.Add(item);

                        
                    }

                }

                catch (Exception ex)
                {

                    MessageBox.Show("HATA" + ex.Message);

                }
                finally
                {
                    con.Close();

                }
            }
            else if (gunluk == true)
            {
                listView1.Columns.Add("İLAN NO", 79);
                listView1.Columns.Add("İLAN TARİHİ", 79);
                listView1.Columns.Add("METRE KARE", 79);
                listView1.Columns.Add("ODA SAYISI", 79);
                listView1.Columns.Add("BİNA YAŞI", 79);
                listView1.Columns.Add("KAT", 79);
                listView1.Columns.Add("ISITMA", 79);
                listView1.Columns.Add("FİYAT", 79);
                listView1.Columns.Add("ADRES", 79);
                listView1.Columns.Add("WİFİ", 79);
                listView1.Columns.Add("TV", 79);

                label2.Text = "GUNLUK EV";
                SqlConnection con = new SqlConnection(baglanti.ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from gunlukEv where ilanTarihi=@tarih", con);
                cmd.Parameters.AddWithValue("@tarih", tarih);

                try
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        ListViewItem item = new ListViewItem(dr["ilanNo"].ToString());
                        item.SubItems.Add(dr["ilanTarihi"].ToString());
                        item.SubItems.Add(dr["metrekare"].ToString());
                        item.SubItems.Add(dr["odasayısı"].ToString());
                        item.SubItems.Add(dr["binayası"].ToString());
                        item.SubItems.Add(dr["bulundugukat"].ToString());
                        item.SubItems.Add(dr["ısıtma"].ToString());
                        item.SubItems.Add(dr["fiyat"].ToString());
                        item.SubItems.Add(dr["adres"].ToString());
                        item.SubItems.Add(dr["wifi"].ToString());
                        item.SubItems.Add(dr["tv"].ToString());
                        
                        listView1.Items.Add(item);

                    }

                }

                catch (Exception ex)
                {

                    MessageBox.Show("HATA" + ex.Message);

                }
                finally
                {
                    con.Close();

                }
            }
            toolTip1.SetToolTip(button2, "Geri Dönüp Güncelleme İşlemine Devam Etmek İcin Bir İlan No Seç Ve Butona Tıkla."); //mesajın yazıldığı yer
            toolTip1.ToolTipTitle = "BİLGİ MESAJI"; // mesajın başlığının yazıldığı yer
            toolTip1.ToolTipIcon = ToolTipIcon.Info; // mesajın ikonunun ayarlandığı yer
            toolTip1.IsBalloon = true;// bu kodu yazmazsak mesaj dikdörtgen şeklinde görünür.
            
            label1.Text = tarih;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("İLAN NUMARASI SEÇMEDEN DEVAM EDEMEZSİN  !!");
               
            }
           

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
