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

namespace Proje_Hastane
{
    public partial class FrmDoktorBilgiDuzenler : Form
    {
        public FrmDoktorBilgiDuzenler()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl=new sqlbaglanti();
        public string tc1;


        private void FrmDoktorBilgiDuzenler_Load(object sender, EventArgs e)
        {
            msktc.Text = tc1;

            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmbbrans.Text = dr[3].ToString();
                txtsifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnbilgiguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTc=@p5", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtsifre.Text);
            komutguncelle.Parameters.AddWithValue("@p5", msktc.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi");
        }
    }
}
