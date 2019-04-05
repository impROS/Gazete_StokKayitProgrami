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
    public partial class anaMenu : Form
    {
        veriTabaniİslemeri v1 = new veriTabaniİslemeri();
        public anaMenu()
        {
            InitializeComponent();
        }



        private void anaMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stokİslem fr = new stokİslem();
            fr.MdiParent = this; fr.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stokİslem fr = new stokİslem();
            fr.MdiParent = this; fr.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            urunEkle fr = new urunEkle();
            fr.MdiParent = this;
            fr.Show();
        }

    }
}
