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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void veriaktarma()
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into sarj(sarz) values ('" + sarz + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

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

        public static string gonderilecekveri;
        public static int sayıgonder;

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =vt.accdb");
        Random rnd = new Random();
        int i = 0;
        int sarz;
        OleDbCommand komut = new OleDbCommand();
        DataTable tablo = new DataTable();

        int sifre;
        private void Form1_Load(object sender, EventArgs e)
        {
            Form guncelle = new güncelle();
            guncelle.Hide();


            //uglulamaekrani.Hide();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select sifre from Sifreler ";
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                sifre = Convert.ToInt32(dr["sifre"]);

            }
            baglanti.Close();

            pinsifresi.Hide();


            timer4.Start();
            şarjdanÇıkarToolStripMenuItem.Visible = false;
            kapatmakİçinTıklaToolStripMenuItem.Visible = false;
            progressBar1.Hide();
            panel1.Hide();
            button4.Hide();
            this.BackColor = Color.Turquoise;
            this.TransparencyKey = Color.Turquoise;
            timer2.Start();
            contextMenuStrip1.Visible = true;


            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select sarz from sarj ", baglanti);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sarz = Convert.ToInt32(dr["sarz"]);
                progressBar1.Value = sarz;
            }
            baglanti.Close();


            tarih.Hide();
            saat.Hide();
            şarjgoster.Hide();

            if (sayıgonder == 1)
            {
                kapatmakİçinTıklaToolStripMenuItem.Visible = true;

                progressBar1.Show();
                button4.Show();
                baslangıcekranı.Image = Properties.Resources.Amazing_HD_Wallpapers__12_;

                baslangıcekranı.Controls.Add(şarjgoster);
                şarjgoster.BackColor = Color.Transparent;

                baslangıcekranı.Controls.Add(tarih);
                tarih.BackColor = Color.Transparent;
                baslangıcekranı.Controls.Add(saat);
                saat.BackColor = Color.Transparent;

                timer1.Start();
                timer2.Start();

                timer4.Start();
                saat.Show();
                tarih.Show();
                şarjgoster.Show();

                şarjgoster.Text = sarz.ToString() + "%";
                saat.Hide();
                tarih.Hide();
                button4.Hide();
                panel1.Location = new Point(28, 78);
                baslangıcekranı.Controls.Add(panel1);
                panel1.BackColor = Color.Transparent;
                panel1.Show();

            }
            sayıgonder = 0;

        }
        int tıklanma = 0;
        private void aç_Click(object sender, EventArgs e)
        {
            label4.Hide();
            if (sifre == 1)
            {

                pinsifresi.Hide();

                button4.Show();
            }
            if (sifre == 2)
            {
                tarih.Location = new Point(29, 108);
                saat.Location = new Point(70, 151);
                button4.Hide();
                pinsifresi.Show();
                textBox1.Focus();
                textBox1.Text = "1234";
            }
            if (tıklanma == 0)
            {
                timer5.Start();
                kapatmakİçinTıklaToolStripMenuItem.Visible = true;

                progressBar1.Show();

                baslangıcekranı.Image = Properties.Resources.Amazing_HD_Wallpapers__12_;

                baslangıcekranı.Controls.Add(şarjgoster);
                şarjgoster.BackColor = Color.Transparent;

                baslangıcekranı.Controls.Add(tarih);
                tarih.BackColor = Color.Transparent;
                baslangıcekranı.Controls.Add(saat);
                saat.BackColor = Color.Transparent;

                timer1.Start();
                saat.Show();
                tarih.Show();
                şarjgoster.Show();

                şarjgoster.Text = sarz.ToString() + "%";
                tıklanma++;
            }
            else
            {

            }


        }

        private void evet_Click(object sender, EventArgs e)
        {
            Form şarjdoldurma = new şarzdoldurma();



            timer1.Stop();
            this.Hide();
            şarjdoldurma.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VolUp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VolDown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into sarj(sarz) values ('" + sarz + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            gonderilecekveri = şarjgoster.Text;


            if (i == 100)
            {
                sarz--;
                şarjgoster.Text = sarz.ToString() + "%";
                i = 0;


                progressBar1.Value = sarz;

            }
            else
            {
                i++;
            }

            if (sarz == 100)
            {
                kapatmakİçinTıklaToolStripMenuItem.Visible = false;
            }
            else
            {
                kapatmakİçinTıklaToolStripMenuItem.Visible = true;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            saat.Text = DateTime.Now.ToShortTimeString();
            tarih.Text = DateTime.Now.ToShortDateString();


        }
        int sayaç = 0;



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Down)
            {
                VolDown();


            }
            if (e.Control == true && e.KeyCode == Keys.Up)
            {
                VolUp();
            }
        }

        private void rehber_Click(object sender, EventArgs e)
        {

            veriaktarma();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            this.Hide();
            Form rehber = new rehber();
            rehber.Show();

        }

        private void rehber_MouseMove(object sender, MouseEventArgs e)
        {
            rehber.Image = Properties.Resources.UsersFolder_128x128_rehbe_tıklanma;
        }

        private void uglulamaekrani_MouseMove(object sender, MouseEventArgs e)
        {
            rehber.Image = Properties.Resources.UsersFolder_48x48;
            
        }
        bool suruklenmedurumu = false;
        Point ilkkonum;
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = true;
            button4.Cursor = Cursors.SizeAll;
            ilkkonum = e.Location;

        }
        int konumm;
        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            konumm = e.X + button4.Left - (ilkkonum.X);
            if (konumm >= 28 && konumm <= 180)
            {


                if (suruklenmedurumu)
                {
                    button4.Left = konumm;
                }
                if (konumm >= 150)
                {
                    //baslangıcekranı.Hide();

                    //uglulamaekrani.Show();


                    saat.Hide();
                    tarih.Hide();
                    button4.Hide();
                    panel1.Location = new Point(28, 78);
                    baslangıcekranı.Controls.Add(panel1);
                    panel1.BackColor = Color.Transparent;
                    panel1.Show();


                }
            }
            else
            {

            }

        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            if (button4.Left < 28)
            {
                button4.Left = 28;
            }
            if (button4.Left >= 179)
            {
                button4.Left = 28;
            }
            suruklenmedurumu = false;
            button4.Cursor = Cursors.Default;
            button4.Left = 28;

        }




        private void baslangıcekranı_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            ToolTip Aciklama = new ToolTip();
            Aciklama.ToolTipTitle = "Kısayolu";
            Aciklama.ToolTipIcon = ToolTipIcon.Info;
            Aciklama.IsBalloon = true;

            Aciklama.SetToolTip(button3, "Ctrl + ->");
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            ToolTip Aciklama = new ToolTip();
            Aciklama.ToolTipTitle = "Kısayolu";
            Aciklama.ToolTipIcon = ToolTipIcon.Info;
            Aciklama.IsBalloon = true;

            Aciklama.SetToolTip(button3, "Ctrl + <-");
        }
        int j = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            j = progressBar1.Value;

            if (j == 100)
            {
                timer3.Stop();
                sarz = j;
                veriaktarma();
                progressBar1.Value = 100;
                MessageBox.Show("Şarjınız 100 oldu");
                kapatmakİçinTıklaToolStripMenuItem.Visible = true;
                şarjdanÇıkarToolStripMenuItem.Visible = false;
            }
            else
            {
                j++;
                şarjgoster.Text = j.ToString() + "%".ToString();

                progressBar1.Value++;

            }

        }

        private void açıkKalsnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (şarjgoster.Text == "100%")
            {
                timer3.Stop();
                timer1.Start();

                şarjdanÇıkarToolStripMenuItem.Visible = false;
            }
            else
            {
                şarjdanÇıkarToolStripMenuItem.Visible = true;
                sayaç++; timer1.Stop(); timer3.Start();

                kapatmakİçinTıklaToolStripMenuItem.Visible = false;

            }
        }

        private void şarjdanÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer3.Stop();
            sarz = progressBar1.Value;
            MessageBox.Show("Şarjınız  " + progressBar1.Value + "% oldu ", "Şarj Durduruldu");
            sayaç = 0;
            timer1.Start();
            şarjdanÇıkarToolStripMenuItem.Visible = false;
            kapatmakİçinTıklaToolStripMenuItem.Visible = true;
        }

        private void şarjOlurkenTelefonKapansınmıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form şarzdoldurma = new şarzdoldurma();
            şarzdoldurma.Show();
            kapatmakİçinTıklaToolStripMenuItem.Visible = false;

        }

        private void baslangıcekranı_MouseMove(object sender, MouseEventArgs e)
        {
            rehber.Image = Properties.Resources.UsersFolder_48x48;
        }



        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            rehber.Image = Properties.Resources.UsersFolder_48x48;
            mail.Image = Properties.Resources.posta;
            pictureBox1.Image = Properties.Resources.settings_big_1x;
        }



        private void kapatmakİçinTıklaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer4.Stop();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            DialogResult cevap;
            DialogResult cevap1;

            if (şarjgoster.Text == "15%")
            {
                timer4.Stop();
                cevap = MessageBox.Show("Şarjınız 15% şarj etmek ister misiniz?", "Sen Bilirsin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    cevap1 = MessageBox.Show("Telefon Kapansın mı?", "Sen Bilirsin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap1 == DialogResult.Yes)
                    {
                        şarjOlurkenTelefonKapansınmıToolStripMenuItem.PerformClick();
                    }
                    else
                    {
                        açıkKalsnToolStripMenuItem.PerformClick();
                    }

                }


            }

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (şarjgoster.Text == "0%")
            {

                gonderilecekveri = şarjgoster.Text;


                Form şarjdoldurma = new şarzdoldurma();
                şarjdoldurma.Show();
                this.Hide();
                timer2.Stop();
                timer3.Start();
                timer4.Stop();
                timer1.Stop();
                timer5.Stop();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            textBox1.Text += "2";
        }

        private void button12_Click(object sender, EventArgs e)
        {

            textBox1.Text += "3";
        }

        private void button11_Click(object sender, EventArgs e)
        {

            textBox1.Text += "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {

            textBox1.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {

            textBox1.Text += "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {

            textBox1.Text += "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {

            textBox1.Text += "8";
        }

        private void button13_Click(object sender, EventArgs e)
        {

            textBox1.Text += "9";
        }

        private void button14_Click(object sender, EventArgs e)
        {

            textBox1.Text += "0";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            veriaktarma();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            this.Hide();
            Form ayarlar = new Ayarlar();
            ayarlar.Show();

        }
        int yanlışgiris = 0;
        private void button15_Click(object sender, EventArgs e)
        {
            
            
        

            if (yanlışgiris < 5)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "select *from pinsifre";
                OleDbDataReader ddr = komut.ExecuteReader();
                while (ddr.Read())
                {

                    if (textBox1.Text == ddr["Sifre"].ToString())
                    {
                        saat.Hide();
                        tarih.Hide();
                        button4.Hide();
                        panel1.Location = new Point(28, 78);
                        baslangıcekranı.Controls.Add(panel1);
                        panel1.BackColor = Color.Transparent;
                        panel1.Show();
                        pinsifresi.Hide();
                    }
                    else
                    {
                        yanlışgiris++;
                    }
                }
                baglanti.Close();
            }

            else
            {
                label4.Show();
                yanlışgiris = 0;
                timer6.Start();
               
            }
               
                
           
          
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            veriaktarma();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            this.Hide();
            Form açıl=new mailgonderme();
            açıl.Show();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            mail.Image = Properties.Resources.posta___Kopya;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.settings_big_1x___Kopya;
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Yapımcı : Zeynel Şahin ");
        }
        int say = 0;
        private void timer6_Tick(object sender, EventArgs e)
        {
            if (say==50)
            {
                label4.Text = "";
                timer6.Stop();
            }
            else
            {
                say++;
                label4.Text = say.ToString();
                textBox1.Text = "";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into sarj(sarz) values ('" + sarz + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            Application.Restart();
        }

        private void şarjgoster_Click(object sender, EventArgs e)
        {

        }

        private void saat_Click(object sender, EventArgs e)
        {

        }
    }
}
