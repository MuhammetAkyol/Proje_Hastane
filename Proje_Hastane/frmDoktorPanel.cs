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
    public partial class frmDoktorPanel : Form
    {
        public frmDoktorPanel()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        private void frmDoktorPanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter("Select * From Tbl_Doktorlar",bgl.baglanti());
            dr.Fill(dt);
            dataGridView1.DataSource = dt;



            //Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }




        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTc,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@p1", txtad.Text);
            komutkaydet.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komutkaydet.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@p4", msktc.Text);
            komutkaydet.Parameters.AddWithValue("@p5", txtsifre.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Kaydedilmiştir");





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {


            SqlCommand komutsil = new SqlCommand("delete From Tbl_Doktorlar where DoktorTc=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", msktc.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silinmiştir");



        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p5 where DoktorTc=@p4", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komutguncelle.Parameters.AddWithValue("@p4", msktc.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtsifre.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi");



        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* cmbbrans.Items.Clear();
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {

                cmbbrans.Items.Add(reader[0] + " " + reader[1]);

            }
            bgl.baglanti().Close();*/
        }
    }
}
