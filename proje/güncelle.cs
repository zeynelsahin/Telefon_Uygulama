using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace proje
{
    public partial class güncelle : Form
    {
        
        public güncelle()
        {
           
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt2.accdb");
        OleDbCommand komut = new OleDbCommand();
       
        private void button1_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update Tablo1 set Ad='" + textBox1.Text + "',Soyad='" + textBox2.Text + "',CepTelefon='" + maskedTextBox1.Text + "',Eposta='" + textBox3.Text + "'where No=" + label5.Text +"";
            komut.ExecuteNonQuery();
            baglanti.Close();
            this.Close();
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void güncelle_Load(object sender, EventArgs e)
        {
            label5.Text = rehber.no.ToString();
            textBox1.Text = rehber.ad;
            textBox2.Text = rehber.soyad;
            maskedTextBox1.Text = rehber.ceptel;
            textBox3.Text = rehber.eposta;
        }
       
    }
}
