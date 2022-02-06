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
    public partial class rehber_ekle : Form
    {
        public rehber_ekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =vt2.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void rehber_ekle_Load(object sender, EventArgs e)
        {
           
        }
        Form rehber = new rehber();



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {

            }
            else
            {


                if (comboBox1.Text == "Genel")
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into genel(Ad,Soyad,CepTelefon,Eposta) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "')";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                if (comboBox1.Text == "Arkadaşlar")
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into arkadaslar(Ad,Soyad,CepTelefon,Eposta) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "')";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                if (comboBox1.Text == "Aile")
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into aile(Ad,Soyad,CepTelefon,Eposta) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "')";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }

                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "insert into Tablo1(Ad,Soyad,CepTelefon,Eposta) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarıyla Tamalandı");
               
                DialogResult cevap;
                cevap = MessageBox.Show("Başka Kayıt Yapmak İster misiniz?", "Sen Bilirsin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    maskedTextBox1.Text = "";
                    comboBox1.Text = "";
                }
                else
                {
                    this.Close();
                    rehber.Show();
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            rehber.Show();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

      
    }
}
