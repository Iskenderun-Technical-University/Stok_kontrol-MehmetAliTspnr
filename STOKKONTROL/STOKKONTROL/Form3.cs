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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-IL1L0EI\SQLEXPRESS;Initial Catalog=Dbstokkontrol;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {  //Kullanıcı Girişi ve şifresiyle giriş yapılıyor.Sql Bağlantısını yaptım.Veriyi veritabanından alıyor.
            try
            {
                baglanti.Open();
                string SQL = "Select * From KullaniciGirisi Where KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre";
                SqlParameter adm1 = new SqlParameter("KullaniciAdi", textBox1.Text.Trim());
                SqlParameter adm2 = new SqlParameter("Sifre", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(SQL, baglanti);
                komut.Parameters.Add(adm1);
                komut.Parameters.Add(adm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                int x = 0;
                if (dt.Rows.Count > 0)
                {
                    x = 1;
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.Show();
                }
                if (x != 1)
                    MessageBox.Show("ID Veya Şifre Yanlış");
            }
            catch (Exception)
            {
                MessageBox.Show("ID Veya Şifre Yanlış");
            }
            baglanti.Close();
            //SQL BAGLANTISINDAN ÖNCEKİ KOD

            // string kullaniciadi = "admin";
            // string sifre = "1234";
            // if (textBox1.Text == kullaniciadi && textBox2.Text == sifre)
            // {
            //     Form1 frm1 = new Form1(); 
            //     this.Hide();
            //     frm1.ShowDialog();
            //   }
            //   else
            //    { MessageBox.Show("KULLANİCİ ADİ VEYA SİFRE HATALİ TEKRAR DENEYİNİZ!"); }


        }
    }
}
