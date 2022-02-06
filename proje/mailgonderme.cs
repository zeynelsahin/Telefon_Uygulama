using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.OleDb;

namespace proje
{
    public partial class mailgonderme : Form
    {
        public mailgonderme()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =vt2.accdb");
        Random rnd = new Random();
        int i = 0;
        int sarz;
        OleDbCommand komut = new OleDbCommand();

        DataSet dataset = new DataSet();
        public static string gonderilecek;
        public static string gonderilecek1;
        public static string gonderilecek2;
        private void veriaktarma()
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into sarj(sarz) values ('" + sarz + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from epostalarım", baglanti);
            adtr.Fill(dataset, "epostalarım");
            dataGridView1.DataSource = dataset.Tables["epostalarım"];
            adtr.Dispose();
            baglanti.Close();
        }
      
        string epostaa;
        private void mailgonderme_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Columns[0].Width = 250;
           
            //baglanti.Open();
            //komut.Connection = baglanti;
            //komut.CommandText = "Select Eposta from epostalarım ";
            //OleDbDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    epostaa = (dr["Eposta"]).ToString();

            //}
            //baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form ekle = new epostaekle();
            ekle.Show();
        }

       
        int satir;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right )//farenin sağ tuşuna basılmışsa
            {
               

                satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (satir >=0)
                {
                   
                   
                    dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    gonderilecek = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    gonderilecek1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    gonderilecek2 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE from epostalarım WHERE Kimlik=" + gonderilecek;
            komut.ExecuteNonQuery();
            baglanti.Close();
            dataset.Clear();
            listele();
        }
      
        private void değiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form değiştir = new değiştir();
            değiştir.Show();
        }

        private void mailGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form gonderr = new gonderme();
            gonderr.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayı = Convert.ToInt32(Form1.sayıgonder);
            if (sayı == 0)
            {
                Form1.sayıgonder = 1;
                Form1 geri = new Form1();
                this.Close();
                geri.Show();

                geri.aç.Enabled = false;

            }
        }
          
    }
}