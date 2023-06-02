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
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "insert into Table_Stok_Kontrol(Urunid,UrunAdi,UrunAdet,UrunFiyat) values (@Urunİd,@UrunAdi,@UrunAdet,@UrunFiyat)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand ekle = new SqlCommand(kayit, baglanti);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                ekle.Parameters.AddWithValue("@Urunİd", textBox1.Text);
                ekle.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
                ekle.Parameters.AddWithValue("@UrunAdet", textBox3.Text);
                ekle.Parameters.AddWithValue("@UrunFiyat", textBox8.Text);

                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                ekle.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
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
            //musterino parametresine bağlı olarak müşteri kaydını silen sql sorgusu
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
        private void button7_Click(object sender, EventArgs e)
        {  //Sql Baglantısı finally de donma engellendi.
            SqlConnection baglanti=null;
            try
            {
                baglanti = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
                baglanti.Open();
                SqlCommand sqlKomut = new SqlCommand("SELECT Urunİd,UrunAdi,UrunAdet,UrunFiyat FROM Table_Stok_Kontrol",baglanti);
                SqlDataReader sqlDR=sqlKomut.ExecuteReader();
                while (sqlDR.Read())
                {
                    string id = sqlDR[0].ToString();
                    string ad = sqlDR[1].ToString();
                    string adet = sqlDR[2].ToString();
                    string fiyat = sqlDR[3].ToString();
                    richTextBox1.Text = richTextBox1.Text + id + " " + ad + " " + adet +" "+fiyat+"\n";
                }
            } 
            catch(Exception ex)
            { MessageBox.Show("sql query sırasında hata olustu!"+ex.ToString()); }
            finally { if(baglanti!=null)
                 baglanti.Close(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //güncelle
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //id ile stok sorgula
            
            int sorgu7=Convert.ToInt32(textBox7.Text);
            int id=Convert.ToInt32(textBox1.Text);
            if (sorgu7 == Convert.ToInt32(textBox1.Text))
            { MessageBox.Show("AYNI İD İLE ÜRÜN KAYITLIDIR!"+"\n"+"Ürün Adı= "+textBox2.Text+"\n"+ "Stok Miktarı=  "+textBox3.Text); }
                

            

        }
    }
   
}
