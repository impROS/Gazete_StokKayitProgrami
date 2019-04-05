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
using DevExpress.XtraEditors;

namespace StokKayıtProgramı
{

    class veriTabaniİslemeri
    {
        public static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=AppFiles\\data.accdb");
        public static OleDbDataAdapter adaptor = new OleDbDataAdapter("Select * from data", baglanti);
        public OleDbCommand komut;
        public DataSet verikumesi = new DataSet();
        public void kayitEkle(string urunAdi, int stokAdi, int urunFiyati, string urunBilgisi)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into data (urunAdi, stokAdedi,urunFiyati,urunBilgisi) values ('" + urunAdi + "','" + stokAdi + "','" + urunFiyati + "','" + urunBilgisi + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void kayitGuncelle(int urunNo, string urunAdi, int stokAdedi, int urunFiyat, string urunBilgisi)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update data set urunAdi='" + urunAdi + "',stokAdedi='" + stokAdedi + "',urunFiyati='" + urunFiyat + "',urunBilgisi='" + urunBilgisi + "' where urunNo=" + urunNo + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void stokIslemleri(int yeniStok1, int urunNo)
        {

            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update data set stokAdedi='" + yeniStok1 + "' where urunNo=" + urunNo;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void VeriDoldur(DevExpress.XtraGrid.GridControl dataGridNesnesi1)
        {
            dataGridNesnesi1.DataSource = null;

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=AppFiles\\data.accdb");

            baglanti.Open();
            adaptor.Fill(verikumesi, "data");
            dataGridNesnesi1.DataSource = verikumesi.Tables["data"];

            baglanti.Close();
        }
        public void kolonEkle(Microsoft.Office.Interop.Excel.TextBox t1)
        {
            try
            {
                if (!Convert.ToBoolean(baglanti.State))
                {
                    baglanti.Open();
                }

                OleDbCommand TabloOlustur = new OleDbCommand("ALTER TABLE data ADD " + t1.Text + " string", baglanti);

                TabloOlustur.ExecuteNonQuery();
                MessageBox.Show(t1.Text + " isimli tabloyu oluşturdunuz...", "Başarılı");

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "Hata..!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (Convert.ToBoolean(baglanti.State))
                {
                    baglanti.Close();
                }
            }
        }
        public void arama(TextBox text, DevExpress.XtraGrid.GridControl dataGrid)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=AppFiles\\data.accdb");
            adaptor = new OleDbDataAdapter("SElect *from data where urunAdi like '" + text.Text + "%'", baglanti);
            verikumesi = new DataSet();
            baglanti.Open();
            adaptor.Fill(verikumesi, "data");
            dataGrid.DataSource = verikumesi.Tables["data"];
            baglanti.Close();
        }
        public void UrunSil(string urunId)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from data where urunNo=" + urunId + "";
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

    }
}
