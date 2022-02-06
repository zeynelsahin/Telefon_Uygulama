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
    public partial class şarzdoldurma : Form
    {
        public şarzdoldurma()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =vt.accdb");
        Random rnd = new Random();
        int sayı;
        int sarz;
        OleDbCommand komut = new OleDbCommand();
        DataTable tablo = new DataTable();
        Form frm = new Form1();
        private void veriaktarma()
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into sarj(sarz) values ('" + sarz + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void şarzdoldurma_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            this.Controls.Add(label1);
            label1.BackColor = Color.Transparent;


            label1.Text = "";
            sayı = Convert.ToInt32(Form1.gonderilecekveri.Substring(0, Form1.gonderilecekveri.Length - 1));
            label1.Text = sayı.ToString() + "%";
            progressBar1.Value = sayı;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                sarz = progressBar1.Value;


                veriaktarma();

                this.Hide();
                frm.Show();

            }
            else
            {
                progressBar1.Value++;
                label1.Text = progressBar1.Value.ToString() + "%";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sarz = progressBar1.Value;
            timer1.Stop();


            veriaktarma();


            this.Hide();
            frm.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
