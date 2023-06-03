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

        }
    }
}
