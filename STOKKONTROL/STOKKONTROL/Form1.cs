using STOKKONTROL;
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

namespace STOKKONTROL
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {  //Ürünekle
            listBox1.Items.Add(textBox1.Text+"\t"+textBox2.Text+"\t"+textBox3.Text);
            
            




        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ürün sil
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   

            this.Close();


        }
        private void button7_Click(object sender, EventArgs e)
        {  //Sql Baglantısı finally de donma engellendi.
            SqlConnection baglanti=null;
            try
            {
                baglanti = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
                baglanti.Open();
                SqlCommand sqlKomut = new SqlCommand("SELECT Urunİd,UrunAdi,UrunAdet FROM Table_Stok_Kontrol",baglanti);
                SqlDataReader sqlDR=sqlKomut.ExecuteReader();
                while (sqlDR.Read())
                {
                    string id = sqlDR[0].ToString();
                    string ad = sqlDR[1].ToString();
                    string adet = sqlDR[2].ToString();
                    richTextBox1.Text = richTextBox1.Text + id + " " + ad + " " + adet +"\n";
                }
            } 
            catch(Exception ex)
            { MessageBox.Show("sql query sırasında hata olustu!"+ex.ToString()); }
            finally { if(baglanti!=null)
                 baglanti.Close(); }
        }
    }
   
}
