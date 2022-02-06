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
    public partial class değiştir : Form
    {
        public değiştir()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =vt2.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update  epostalarım set Eposta='" + textBox1.Text + "',Sifre='" + textBox2.Text + "'where Kimlik =" + mailgonderme.gonderilecek + "";
            komut.ExecuteNonQuery();
            baglanti.Close();

            this.Hide();
            Form geri = new mailgonderme();
            geri.Show();

            
        }

        private void değiştir_Load(object sender, EventArgs e)
        {
            textBox1.Text = mailgonderme.gonderilecek1.ToString();
            textBox2.Text = mailgonderme.gonderilecek2.ToString();
        }
    }
}
