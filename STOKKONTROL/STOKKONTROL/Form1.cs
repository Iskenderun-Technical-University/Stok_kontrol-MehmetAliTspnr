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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
        private object messageBoxButtons;

        private void button1_Click(object sender, EventArgs e)
        {  //Ürünekle

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                // Bağlantı kontrolü ve açılması.
                string kayit = "insert into Table_Stok_Kontrol(Urunid,UrunAdi,UrunAdet,UrunFiyat) values (@Urunİd,@UrunAdi,@UrunAdet,@UrunFiyat)";
                //ilgili yere kayıt
                SqlCommand ekle = new SqlCommand(kayit, baglanti);
                ekle.Parameters.AddWithValue("@Urunİd", textBox1.Text);
                ekle.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
                ekle.Parameters.AddWithValue("@UrunAdet", textBox3.Text);
                ekle.Parameters.AddWithValue("@UrunFiyat", textBox8.Text);
                ekle.ExecuteNonQuery();
                baglanti.Close();
                listBox1.Items.Add(textBox1.Text + "\t" + textBox2.Text + "\t" + textBox3.Text + "\t" + textBox8.Text);
                MessageBox.Show("Ürün Kayıt İşlemi Gerçekleşti!");
                
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
     
        private void button2_Click(object sender, EventArgs e)
        {//Ürün Silme sql
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from Table_Stok_Kontrol where Urunİd=@Urunİd", baglanti);
            komutsil.Parameters.AddWithValue("@Urunİd", textBox1.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Ürün Silindi");
            baglanti.Close();

           
             //baglanti.Open();
            //SqlCommand kayitsil = new SqlCommand("Delete From Table_Stok_Kontrol WHERE id=(" + id + ")", baglanti);
            // kayitsil.ExecuteNonQuery();
            //string silmeSorgusu = "DELETE from Table_Stok_Kontrol where @Urunİd";
            //SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
           // silKomutu.Parameters.AddWithValue("@Urunİd", textBox1.Text);
           // silKomutu.ExecuteNonQuery();
           // MessageBox.Show("Kayıt Silindi...");
            // baglanti.Close() ;
            //Ürün sil
            //listBox1.Items.Remove(listBox1.SelectedItem);
           // MessageBox.Show("Ürün Silindi!");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   

            Application.Exit();


        }
        SqlConnection baglanti2 = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
       // public void verilerigöster(string veriler)
        //{   
         //   SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti2);
         //   DataSet ds=new DataSet();
         //   da.Fill(ds);
         //   dataGridView1.DataSource = ds.Tables[0];

        //}
        private void button7_Click(object sender, EventArgs e)
        //detaylı stok sorgu
        {   
            Form2 f2 = new Form2();
            f2.Show();
            
           // verilerigöster("Select*From Table_Stok_Kontrol");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {//güncelle
            //Form5 f5 = new Form5();
           // f5.Show();

            try
            {
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE Table_Stok_Kontrol SET UrunAd=@UrunAdi, UrunFiyat=@UrunFiyat, UrunAdet=@UrunAdet WHERE Urunİd=@Urunİd", baglanti);
                komut.Parameters.AddWithValue("@Urunİd", Convert.ToInt32(textBox4.Text));
                komut.Parameters.AddWithValue("@UrunAdi", Convert.ToInt32(textBox5.Text));
                komut.Parameters.AddWithValue("@UrunAdet", textBox6.Text);
                komut.Parameters.AddWithValue("@UrunFiyat", Convert.ToInt32(textBox9.Text));
               
                komut.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Bağlantı kurulurken hata oluştu!!!");
            }
            finally
            {
                baglanti.Close();

            }


        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            //id ile stok sorgula

           // int sorgu7=Convert.ToInt32(textBox7.Text);
           // int id=Convert.ToInt32(textBox1.Text);
          //  if (sorgu7 == Convert.ToInt32(textBox1.Text))
          //  { MessageBox.Show("AYNI İD İLE ÜRÜN KAYITLIDIR!"+"\n"+"Ürün Adı= "+textBox2.Text+"\n"+ "Stok Miktarı=  "+textBox3.Text); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from Table_Stok_Kontrol where Urunİd=@Urunİd", baglanti);
            komutsil.Parameters.AddWithValue("@Urunİd", listBox1.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("DEPODAN ÇIKIŞ YAPILDI!"+baglanti);
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
   
}
