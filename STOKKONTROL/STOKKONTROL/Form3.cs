﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            string kullaniciadi = "admin";
             string sifre = "1234";
            if (textBox1.Text == kullaniciadi && textBox2.Text == sifre)
            {
                Form1 frm1 = new Form1(); 
                this.Hide();
                frm1.ShowDialog();
              

              }
              else
              { MessageBox.Show("KULLANİCİ ADİ VEYA SİFRE HATALİ TEKRAR DENEYİNİZ!"); }


        }
    }
}
