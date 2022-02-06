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
    public partial class gonderme : Form
    {
        public gonderme()
        {
            InitializeComponent();
        }
        public void gonder(string konu, string açıklama, string ad, string eposta,string gondereposta,string sifre)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.live.com";
            sc.EnableSsl = true;
            sc.Timeout = 5;

            sc.Credentials = new NetworkCredential(eposta, sifre);

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(eposta, ad);

            mail.To.Add(gondereposta);
            //mail.To.Add("alici2@mail.com");

            //mail.CC.Add("alici3@mail.com");
            //mail.CC.Add("alici4@mail.com");

            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = açıklama;

            //mail.Attachments.Add(new Attachment(@"C:\Rapor.xlsx"));
            //mail.Attachments.Add(new Attachment(@"C:\Sonuc.pptx"));

            sc.Send(mail);
            MessageBox.Show("Mail Gönderildi");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string konu, açıklama, eposta, ad, sifre, epostagonderlicek;
            ad = textBox1.Text.ToString();
            konu = textBox2.Text.ToString();
            açıklama = textBox3.Text.ToString();
            eposta = mailgonderme.gonderilecek1.ToString();
            sifre = mailgonderme.gonderilecek2.ToString();
            epostagonderlicek = textBox4.Text.ToString();
            gonder(konu, açıklama, ad, eposta,epostagonderlicek,sifre);
        }

        private void gonderme_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form geri = new mailgonderme();
            geri.Show();
        }
        
    }
}
