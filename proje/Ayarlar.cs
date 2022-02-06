using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
namespace proje
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =vt.accdb");
        OleDbCommand komut = new OleDbCommand();
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);
        public void Mute()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }
        public void VolDown()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }
        public void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }

      
        int sayı;
        int sifre;
        private void button2_Click(object sender, EventArgs e)
        {
           
          
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select sifre from Sifreler ";
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                sifre = Convert.ToInt32(dr["sifre"]);

            }
            baglanti.Close();
            if (sifre == 1)
            {
              
                MessageBox.Show("Ekran Kilidiniz Zaten Kaydırma");
            }
            if (sifre == 2)
            {
                sayı = 1;
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "insert into Sifreler(sifre) values('" + sayı + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ekran Kilidiniz Kaydır Olarak Dedğiştirildi");
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select sifre from Sifreler ";
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                sifre = Convert.ToInt32(dr["sifre"]);

            }
            baglanti.Close();
            if (sifre == 1)
            {
                sayı = 2;
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "insert into Sifreler(sifre) values ('" + sayı + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Ekran Kilidi Pin Olarak Değiştirildi");
            }
            if (sifre == 2)
            {
                MessageBox.Show("Ekran Kilidiniz Zaten Pin");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            VolUp();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            VolDown();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası|*.jpg;*.nef;*.png| Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;

        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {

        }

        
    }
}
