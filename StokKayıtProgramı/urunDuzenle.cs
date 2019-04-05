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

    public partial class urunDuzenle : Form
    {
        veriTabaniİslemeri v3 = new veriTabaniİslemeri();
        public urunDuzenle()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            anaMenu anaMenu = new anaMenu();

            this.Hide();
            anaMenu.Show();
        }

        private void urunDuzenle_Load(object sender, EventArgs e)
        {
            v3.VeriDoldur(gridControl1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //kaydet
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Ürün Adı ve Fiyati bos olamaz", "Eksik Bilgi");
            }
            else
            {
                try
                {
                    if (textBox2.Text == "") { textBox2.Text = "0"; }
                    v3.kayitGuncelle(Convert.ToInt32(urunNo.Text), textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text);
                    ResetDatagridview(dataGridView1);
                    label6.Text = "Kayıt Başarıyla Eklendi.";
                  
                }
                catch (Exception hata1) { MessageBox.Show("Kayıt Eklenemedi.Var Olan Bir Ürünü Seçtiğinizden Emin Olun","Kayıt Eklenemedi" );
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
                urunNo.Text = "Secili Ürün Yok";
                label6.Text = "Kayıt Eklenemedi";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int secili = dataGridView1.CurrentCell.RowIndex;
                urunNo.Text = dataGridView1.Rows[secili].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[secili].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[secili].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[secili].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[secili].Cells[4].Value.ToString();
            }
            catch {
                urunNo.Text = "";
            }
        }

  

        private void button4_Click(object sender, EventArgs e)
        {
            //kayıt sil


            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Ürün Adı ve Fiyati bos olamaz", "Eksik Bilgi");
            }
            else
            {
                if (urunNo.Text != "Secili Ürün Yok" || urunNo.Text!="")
                {
                    DialogResult result = MessageBox.Show("Bu Ürünü Silmek İstediğinize Emin Misiniz ?", "Onaylama Penceresi", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            v3.UrunSil(urunNo.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Kayıt Eklenemedi.Lütfen Var Olan Bir Ürünü Seçtiğinize Emin Olun.");
                            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
                            urunNo.Text = "Secili Ürün Yok";
                        }
                        urunNo.Text = "Secili Ürün Yok";
                        ResetDatagridview(dataGridView1);
                        label6.Text = "Kayıt Silindi";
                    }
                    else if (result == DialogResult.No)
                    {
                        label6.Text = "Kayıt Silinmedi";
                    }
                    
                }
                else if (urunNo.Text == "Secili Ürün Yok" || urunNo.Text == "")
                {
                    MessageBox.Show("Lütfen Bir Ürün Seçiniz", "Ürün Seçilmedi");
                }
            }
            
        }
        private void ResetDatagridview(DataGridView dataGrid)
        {
            veriTabaniİslemeri v4 = new veriTabaniİslemeri();
            dataGrid.DataSource = null;
            dataGrid.Rows.Clear();
            v4.VeriDoldur(dataGridView1);

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void urunDuzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            v3.arama(textBox5, gridControl1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
