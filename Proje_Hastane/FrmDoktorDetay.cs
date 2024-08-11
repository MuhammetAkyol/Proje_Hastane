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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl=new sqlbaglanti();
        public string TC;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = TC;


            //doktor ad soyad çekme
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dataReader = komut.ExecuteReader();
            while (dataReader.Read())
            {
                lbladsoyad.Text = dataReader[0] + " " + dataReader[1];
            }
            bgl.baglanti().Close();


            //randevuları çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor='" +lbladsoyad.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenler fr1 = new FrmDoktorBilgiDuzenler();
            fr1.tc1=lbltc.Text;
            fr1.Show();
        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            frmDuyurular frmDuyurular = new frmDuyurular();
            frmDuyurular.Show();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; 
            rchsikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
