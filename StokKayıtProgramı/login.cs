using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokKayıtProgramı
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        StreamReader sr;
        StreamWriter kontrol2;
        string sifre, kullaniciAdi, kontrol;
        private void login_Load(object sender, EventArgs e)
        {
            sr = new StreamReader("AppFiles\\pass");
        String veri = sr.ReadLine();
       
            kullaniciAdi = veri;
            veri = sr.ReadLine();
             sifre =   veri;

         sr.Close();
        // label1.Text = sifre+"  - "+kullaniciAdi;
         sr = new StreamReader("AppFiles\\control");
         kontrol = sr.ReadLine();
         sr.Close();
         if (kontrol == "1")
         {
             textBox1.Text = kullaniciAdi;
             checkBox1.Checked = true;
             textBox2.Text = sifre;
         }
         else {
             textBox1.Text = kullaniciAdi;
             checkBox1.Checked = false;
             textBox2.Text = "";
         }
         button1.Focus();
       }

        private void button1_Click(object sender, EventArgs e)
        {
            //label2.Text = kullaniciAdi + " " + sifre;
            if (textBox1.Text == kullaniciAdi && textBox2.Text == sifre)
            {
                anaMenu anaMenu = new anaMenu();
                anaMenu.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Kullanıcı Adi veya Şifre Hatalı", "Giriş Başarısız");
            }
        }
        FileStream fs;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fs = new FileStream("AppFiles\\control", FileMode.Create, FileAccess.Write);
            kontrol2 = new StreamWriter(fs);
            if (checkBox1.Checked == true) {
                    kontrol2.WriteLine("1");
            }
            else{
            kontrol2.WriteLine("0");
            }

                   kontrol2.Close();
            }
        }
        }
    
