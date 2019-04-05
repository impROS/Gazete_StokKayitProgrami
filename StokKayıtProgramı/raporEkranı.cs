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
    public partial class raporEkranı : Form
    {
        public raporEkranı()
        {
            InitializeComponent();
        }
        raporlama raporlama2 = new raporlama();
        private void raporEkranı_Load(object sender, EventArgs e)
        {
            
           // raporlama raporla=new raporlama();
           // richTextBox1.Text = raporla.logYazdir();
            ResetDatagridview(dataGridView1);
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[4].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            anaMenu anaMenu = new anaMenu();
            anaMenu.Show();
            this.Hide();
        }
        private void ResetDatagridview(DataGridView dataGrid)
        {
           
            dataGrid.DataSource = null;
            dataGrid.Rows.Clear();
            raporlama2.VeriDoldur2(dataGridView1);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void raporEkranı_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            raporlama2.exeleAktar(dataGridView1);
        }
    }
}
