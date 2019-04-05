using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokKayıtProgramı
{
    public partial class stokİslem : Form
    {
        public stokİslem()
        {
            InitializeComponent();
        }
        raporlama logla = new raporlama();
        static int secili, yeniStok, urunNumara;
        string veriLog;
        veriTabaniİslemeri v5 = new veriTabaniİslemeri();
        raporlama logKaydet = new raporlama();
        #region Gereksiz //bi burda kullandım galiba :D




        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            anaMenu anaMenu = new anaMenu();

            this.Hide();
            anaMenu.Show();
        }

        private void stokİslem_Load(object sender, EventArgs e)
        {
            v5.VeriDoldur(gridControl1);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                urunNumara = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KolonGorunenAdi").ToString());
                label5.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, @"KolonGorunenAdi").ToString();
                label3.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, @"KolonGorunenAdi").ToString();
                label7.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, @"KolonGorunenAdi").ToString();
                label9.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, @"KolonGorunenAdi").ToString();
            }
            catch
            {
                label5.Text = "Secili Ürün Yok";
            }

        }

        int tutar;
        private void button2_Click(object sender, EventArgs e)
        {
            //ekle
            if (textBox1.Text != "")
            {
                if (label5.Text != "Secili Ürün Yok")
                {
                    yeniStok = Convert.ToInt32(dataGridView1.Rows[secili].Cells[2].Value.ToString()) + Convert.ToInt32(textBox1.Text);
                    v5.kayitGuncelle(urunNumara, label5.Text, yeniStok, Convert.ToInt32(label7.Text), label9.Text);
                    ResetDatagridview(gridControl1);
                    tutar = Convert.ToInt32(label7.Text) * Convert.ToInt32(textBox1.Text);
                    veriLog = label5.Text + " Adlı Ürüne " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " Tarihinde " + textBox1.Text + " Adet Stok Girişi Yapıldı.\nAçıklama = " + textBox2.Text +
                        "\nUrunun Yeni Bilgisi ==> Ürün Adı :" + label5.Text + ", Stok Adedi: " + yeniStok + " ,Tutar: " + tutar + ",Ürün Bilgisi:" + label7.Text;
                    logKaydet.logEkle(label5.Text, "Stok Adedi", textBox2.Text, tutar, yeniStok, label7.Text);
                    //  logla.logTut(veriLog);
                    richTextBox1.Text = veriLog;
                }
                else if (label5.Text == "Secili Ürün Yok" && label5.Text != "")
                {
                    MessageBox.Show("Lütfen Bir Ürün Seçiniz", "Ürün Seçilmedi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bir Giriş  Sayısı Girin", "Eksik Bilgi");
            }

        }
        private void ResetDatagridview(DevExpress.XtraGrid.GridControl dataGrid)
        {
            veriTabaniİslemeri v4 = new veriTabaniİslemeri();
            dataGrid.DataSource = null;
            //dataGrid.Rows.Clear();
            v4.VeriDoldur(gridControl1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Çıkar
            if (textBox1.Text != "")
            {
                if (label5.Text != "Secili Ürün Yok" && label5.Text != "")
                {
                    yeniStok = Convert.ToInt32(dataGridView1.Rows[secili].Cells[2].Value.ToString()) - Convert.ToInt32(textBox1.Text);
                    v5.kayitGuncelle(urunNumara, label5.Text, yeniStok, Convert.ToInt32(label7.Text), label9.Text);
                    ResetDatagridview(dataGridView1);
                    tutar = (Convert.ToInt32(label7.Text) * Convert.ToInt32(textBox1.Text));
                    veriLog = label5.Text + " Adlı Ürüne " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " Tarihinde " + textBox1.Text + " Adet Stok Çıkışı Yapıldı.\nAçıklama = " + textBox2.Text +
                  "\nUrunun Yeni Bilgisi ==> Ürün Adı :" + label5.Text + ", Stok Adedi: " + yeniStok + " ,Tutar: " + (-tutar) + ",Ürün Bilgisi:" + label7.Text;
                    //  logla.logYazdir(veriLog);
                    //logla.logTut(veriLog);
                    logKaydet.logEkle(label5.Text, "Stok Adedi", textBox2.Text, (-tutar), yeniStok, label7.Text);
                    richTextBox1.Text = veriLog;
                }
                else if (label5.Text == "Secili Ürün Yok")
                {
                    MessageBox.Show("Lütfen Bir Ürün Seçiniz", "Ürün Seçilmedi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bir  Çıkış Sayısı Girin", "Eksik Bilgi");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
            //{

            //    e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.

            //}
        }

        private void stokİslem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
