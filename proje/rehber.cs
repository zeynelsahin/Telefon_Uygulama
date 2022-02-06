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
    public partial class rehber : Form
    {
        public Form1 frm1;
        public güncelle frm;
        public rehber()
        {
            frm1 = new Form1();
            frm = new güncelle();
            InitializeComponent();

        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt2.accdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet dataset = new DataSet();

        public void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Tablo1", baglanti);
            adtr.Fill(dataset, "Tablo1");
            dataGridView1.DataSource = dataset.Tables["Tablo1"];
            adtr.Dispose();
            baglanti.Close();
        }

        private void rehber_Load(object sender, EventArgs e)
        {
            
            listele();
            comboBox1.Text = "Tüm Liste";
            //this.BackColor = Color.Turquoise; this.TransparencyKey = Color.Turquoise;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ekle = new rehber_ekle();
            ekle.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataset.Clear();
            if (comboBox1.Text == "Genel")
            {

                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select * from genel", baglanti);

                adtr.Fill(dataset, "genel");
                dataGridView1.DataSource = dataset.Tables["genel"];
                adtr.Dispose();
                baglanti.Close();
                textBox1.Text = "";
            }
            if (comboBox1.Text == "Aile")
            {
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select * from aile", baglanti);

                adtr.Fill(dataset, "aile");
                dataGridView1.DataSource = dataset.Tables["aile"];
                adtr.Dispose();
                baglanti.Close();
                textBox1.Text = "";
            }
            if (comboBox1.Text == "Arkadaşlar")
            {
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select * from arkadaslar", baglanti);

                adtr.Fill(dataset, "arkadaslar");
                dataGridView1.DataSource = dataset.Tables["arkadaslar"];
                adtr.Dispose();
                baglanti.Close();
                textBox1.Text = "";
            }
            if (comboBox1.Text == "Tüm Liste")
            {
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Tablo1", baglanti);

                adtr.Fill(dataset, "Tablo1");
                dataGridView1.DataSource = dataset.Tables["Tablo1"];
                adtr.Dispose();
                baglanti.Close();
                textBox1.Text = "";
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="Tüm Liste")
            {
                dataset.Clear();

                OleDbDataAdapter adtr = new OleDbDataAdapter("SElect * from Tablo1 where Ad like '" + textBox1.Text + "%'", baglanti);

                baglanti.Open();
                adtr.Fill(dataset, "Tablo1");
                dataGridView1.DataSource = dataset.Tables["Tablo1"];
                baglanti.Close();
            }
            if (comboBox1.Text=="Genel")
            {
                dataset.Clear();

                OleDbDataAdapter adtr = new OleDbDataAdapter("SElect * from genel where Ad like '" + textBox1.Text + "%'", baglanti);

                baglanti.Open();
                adtr.Fill(dataset, "Tablo1");
                dataGridView1.DataSource = dataset.Tables["Tablo1"];
                baglanti.Close();
            }
            if (comboBox1.Text=="Aile")
            {
             dataset.Clear();

             OleDbDataAdapter adtr = new OleDbDataAdapter("SElect *from aile where Ad like '" + textBox1.Text + "%'", baglanti);

                baglanti.Open();
                adtr.Fill(dataset, "Tablo1");
                dataGridView1.DataSource = dataset.Tables["Tablo1"];
                baglanti.Close();   
            }
            if (comboBox1.Text=="Arkadaşlar")
            {
                 dataset.Clear();

                 OleDbDataAdapter adtr = new OleDbDataAdapter("SElect * from arkadaslar where Ad like '" + textBox1.Text + "%'", baglanti);

                baglanti.Open();
                adtr.Fill(dataset, "Tablo1");
                dataGridView1.DataSource = dataset.Tables["Tablo1"];
                baglanti.Close();   
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
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
        private void button4_Click(object sender, EventArgs e)
        {
            
           
            Form guncell = new güncelle();
            guncell.Show();
            
          
        }
        public string silinecek;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            string silinecek;
            try
            {
                int row = 0;
                for (row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    if (dataGridView1.Rows[row].Cells[0].Selected == true || dataGridView1.Rows[row].Cells[1].Selected == true || dataGridView1.Rows[row].Cells[2].Selected == true || dataGridView1.Rows[row].Cells[3].Selected == true)
                    {
                        break;
                    }
                }
                silinecek = dataGridView1.Rows[row].Cells[0].Value.ToString();
                DialogResult cevap;
                cevap = MessageBox.Show("Kayd silmek istedi§inizden eminmisiniz", "Uyar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    if (comboBox1.Text=="Tüm Liste")
                    {
                        komut.CommandText = "DELETE from Tablo1 WHERE Ad='" + silinecek + "'";
                        komut.ExecuteNonQuery();
                        komut.CommandText = "DELETE from genel WHERE Ad='" + silinecek + "'";
                        komut.ExecuteNonQuery();
                        komut.CommandText = "DELETE from aile WHERE Ad='" + silinecek + "'";
                        komut.ExecuteNonQuery();
                        komut.CommandText = "DELETE from arkadaslar WHERE Ad='" + silinecek + "'";
                        komut.ExecuteNonQuery(); 
                    }
                    if (comboBox1.Text=="Genel")
                    {
                        komut.CommandText = "DELETE from genel WHERE Ad='" + silinecek + "'";
                        komut.ExecuteNonQuery();   
                    }
                    if (comboBox1.Text=="Arkadaslar")
                    {
                        komut.CommandText = "DELETE from arkadaslar WHERE Ad='" + silinecek + "'";
                        komut.ExecuteNonQuery(); 
                    }
                    komut.Dispose();
                    baglanti.Close();
                    dataset.Clear();
                    dataset.Tables["Tablo1"].Clear();
                    listele();
                    comboBox1.Text = "Tüm Liste";
                }
            }
            catch
            {
                ;
            }
        }
        public static string ad;
        public  static string soyad;
        public static string ceptel;
        public static string eposta;
        public static string no;
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ad = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            soyad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ceptel = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            eposta = dataGridView1.CurrentRow.Cells[3].Value.ToString();
          no=dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}