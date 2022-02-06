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
    public partial class epostaekle : Form
    {
        public epostaekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =vt2.accdb");     
        OleDbCommand komut = new OleDbCommand();
       
        private void veriaktarma()
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into epostalarım(Eposta,Sifre) values ('" + textBox5.Text +"','"+textBox1.Text +"')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void epostaekle_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            veriaktarma();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form geri = new mailgonderme();
            geri.Show();
        }
    }
}
