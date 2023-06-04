using DocumentFormat.OpenXml.Drawing.Diagrams;
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

namespace STOKKONTROL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti2 = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
        public void verilerigöster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
        private void button1_Click(object sender, EventArgs e)
        {

            verilerigöster("Select*From Table_Stok_Kontrol");
        }
        private void btnİslem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("UPDATE Table_Stok_Kontrol SET Urunİd=@Urunİd, UrunAdi=@UrunAdi, UrunAdet=@UrunAdet WHERE UrunFiyat=@UrunFiyat", baglanti2);
                komut.Parameters.AddWithValue("@Urunİd", Convert.ToInt32(dataGridView1.Text));
                komut.Parameters.AddWithValue("@UrunAdi", Convert.ToInt32(dataGridView1.Text));
                komut.Parameters.AddWithValue("@UrunAdet", dataGridView1.Text);
                komut.Parameters.AddWithValue("@UrunFiyat", Convert.ToInt32(dataGridView1.Text));
                baglanti2.Open();
                komut.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Bağlantı kurulurken hata oluştu!!!");
            }
            finally
            {
                baglanti2.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
         //   SqlCommandBuilder commandBuilder;
            //SqlDataAdapter adtr;

            //  baglanti.Open();
            // SqlCommand komutsil = new SqlCommand("delete from Table_Stok_Kontrol where Urunİd=@Urunİd", baglanti);
            //komutsil.Parameters.AddWithValue("@Urunİd", dataGridView1.Text);
            //komutsil.ExecuteNonQuery();
            //MessageBox.Show("Ürün Silindi");
            //baglanti.Close();
        }
    }
}
