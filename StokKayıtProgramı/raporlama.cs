using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data;
namespace StokKayıtProgramı
{
    class raporlama
    {
        //public void logTut(string veri ) {
       
            
        //    StreamWriter log;

        //    if (!File.Exists("loglar.txt"))
        //    {
        //        log = new StreamWriter("loglar.txt");
        //    }
        //    else
        //    {
        //        log = File.AppendText("loglar.txt");
        //    }

            
        //    log.WriteLine(DateTime.Now);
        //    log.WriteLine(veri);
        //    log.WriteLine();

           
        //    log.Close();
        //}
        //public string logYazdir() {
        //    StreamReader sr = new StreamReader("AppFiles\\loglar.txt");
        //    String veri = sr.ReadLine();
        //    string loglar="";
        //    while (veri != null)
        //    {
        //        loglar = loglar + "\n" + veri;
        //        veri = sr.ReadLine();
        //    }
        //    sr.Close();
        //    return loglar;
            
        //}

        public static OleDbConnection logBaglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=AppFiles\\loglar.accdb");
        public static OleDbDataAdapter logAdaptor = new OleDbDataAdapter("Select * from loglar", logBaglanti);
        public OleDbCommand komut2;
        public DataSet verikumesi = new DataSet();
        public void logEkle(string urunAdi, string degisen, string aciklama, int tutar,int stokAdedi,string urunBilgisi)
        {
            string zaman = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            komut2 = new OleDbCommand();
            logBaglanti.Open();
            komut2.Connection = logBaglanti;
            komut2.CommandText = "insert into loglar (zaman,urunAdi,degisen,aciklama,tutar,stokAdedi,urunBilgisi) values ('" + zaman + "','"  +urunAdi+ "','" + degisen + "','" + aciklama + "','" + tutar+ "','" + stokAdedi +  "','" + urunBilgisi + "')";
            komut2.ExecuteNonQuery();
            logBaglanti.Close();
        
        }

        public void VeriDoldur2(DataGridView dataGridNesnesi1)
        {
            logBaglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=AppFiles\\loglar.accdb");

            logBaglanti.Open();
            logAdaptor.Fill(verikumesi, "loglar");
            dataGridNesnesi1.DataSource = verikumesi.Tables["loglar"];

            logBaglanti.Close();
        }
        public void exeleAktar(DataGridView dataGrid) {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dataGrid.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dataGrid.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {

                    Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = dataGrid[j, i].Value == null ? "" : dataGrid[j, i].Value;
                    myRange.Select();


                }
            }
        }

       }

    }