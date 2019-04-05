using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace StokKayıtProgramı
{
    public partial class urunEkle : Form
    {

    
        public urunEkle()
        {
            InitializeComponent();
        }


        veriTabaniİslemeri v1 = new veriTabaniİslemeri();
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Ürün Adı ve Fiyati bos olamaz", "Eksik Bilgi");
            }
            else
            {
                try
                {
                    if (textBox2.Text == "") { textBox2.Text = "0"; }
                    veriTabaniİslemeri v1 = new veriTabaniİslemeri();
                    v1.kayitEkle(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text);
                    label6.Text = "Kayıt Başarıyla Eklendi.";
                    

                    label8.Text = textBox1.Text;
                    label14.Text = textBox2.Text;
                    label15.Text = textBox3.Text;
                    label16.Text = textBox4.Text;

                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";

                   // textBox1.TabIndex = 1;
                    v1.VeriDoldur(gridControl1);
                    textBox1.Focus();
                }
                catch (Exception hata1) { MessageBox.Show("Kayıt Eklenemedi.Hata Sebebi = " + hata1); }
            }


        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
            {

                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.

            }

            else if ((int)e.KeyChar == 8)
            {

                e.Handled = false;//eğer basılan tuş backspace ise yazdır.

            }

            else
            {

                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
            {

                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.

            }

            else if ((int)e.KeyChar == 8)
            {

                e.Handled = false;//eğer basılan tuş backspace ise yazdır.

            }

            else
            {

                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma

            }
        }

        private void urunEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void urunEkle_Load(object sender, EventArgs e)
        {
            AcceptButton = button2;
            v1.VeriDoldur(gridControl1);
        }

  
        private void urunEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            v1.arama(textBox5, gridControl1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anaMenu anaMenu = new anaMenu();

            this.Hide();
            anaMenu.Show();
        }

   


    }
}