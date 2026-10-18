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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stok_
{
    public partial class frmÜrünEkle : Form
    {
        public frmÜrünEkle()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Stok_Takıp;Integrated Security=True");
        bool durum;
        private void barkodkontrol()
        {

            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtBarkodNo.Text == read["barkodno"].ToString() || txtBarkodNo.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();

        }


        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                comboKategori.Items.Add(read["kategori"].ToString());

            }
            baglanti.Close();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
            // Olay işleyici kodu buraya
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Olay işleyici kodunu buraya ekleyin
        }


        private void frmÜrünEkle_Load(object sender, EventArgs e)
        {
            kategorigetir();
        }



        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMarka.Items.Clear();
            comboMarka.Text = "";
            using (SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Stok_Takıp;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from markabilgileri where kategori = @kategori", baglanti);
                komut.Parameters.AddWithValue("@kategori", comboKategori.SelectedItem.ToString().Trim());
                SqlDataReader read = komut.ExecuteReader();
                while (read.Read())
                {
                    comboMarka.Items.Add(read["marka"].ToString());
                }
            }
            baglanti.Close();
        }



        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into urun(barkodno,kategori,marka,urunadi,miktar,alisfiyatı,satisfiyatı,tarih) values(@barkodno,@kategori,@marka,@urunadi,@miktar,@alisfiyatı,@satisfiyatı,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
                komut.Parameters.AddWithValue("@marka", comboMarka.Text);
                komut.Parameters.AddWithValue("@urunadi", txtÜrünAdı.Text);
                komut.Parameters.AddWithValue("@miktar", int.Parse(txtMiktarı.Text));
                komut.Parameters.AddWithValue("@alisfiyatı", double.Parse(txtAlışFiyatı.Text));
                komut.Parameters.AddWithValue("@satisfiyatı", double.Parse(txtSatışFiyatı.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün eklendi");


            }
            else
            {
                MessageBox.Show("Böyle bir barkodno var", "uyarı");
            }


            comboMarka.Items.Clear();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    item.Text = "";
                }

                if (item is System.Windows.Forms.ComboBox)
                {
                    item.Text = "";
                }
            }



        }

        private void BarkodNotxt_TextChanged(object sender, EventArgs e)
        {
            if (BarkodNotxt.Text == "")
            {

                lblMiiktari.Text = "";
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is System.Windows.Forms.TextBox)
                    {
                        item.Text = "";


                    }
                }
            }




            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun where barkodno like '" + BarkodNotxt.Text + "' ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Kategoritxt.Text = read["kategori"].ToString();
                Markatxt.Text = read["marka"].ToString();
                ÜrünAdıtxt.Text = read["urunadi"].ToString();
                lblMiiktari.Text = read["miktar"].ToString();
                AlışFiyatıtxt.Text = read["alisfiyatı"].ToString();
                SatışFiyatıtxt.Text = read["satisfiyatı"].ToString();

            }
            baglanti.Close();

        }

        private void btnVarolanaEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update urun set miktar=miktar+'" + int.Parse(Miktarıtxt.Text) + "' where barkodno= ' " + BarkodNotxt.Text + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    item.Text = "";


                }
            }
            MessageBox.Show("var olan ürüne ekleme yapıldı");
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
