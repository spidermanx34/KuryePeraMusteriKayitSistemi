using KuryePera.FORMLARIM;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryePera.CLASSLARIM
{
    internal class ReportRaporu
    {
        public static string Baslik { get; set; }
        public static string TarihBaslangic { get; set; }
        public static string TarihBitis { get; set; }
        public static string Kurye { get; set; }
        public static string Musteri { get; set; }
        public static string KuryeHakEdis { get; set; }
        public static string KuryeUcreti { get; set; }
        public static string AlimAdresi { get; set; }
        public static string TeslimAdresi { get; set; }
        public static string Kazanc { get; set; }
        public static string Kdv { get; set; }
        public static void RaporSayfasiRaporu(DataGridView dgv)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<KayitTablosuu> kayit = new List<KayitTablosuu>();

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                kayit.Add(new KayitTablosuu
                {
                    MusteriAd = dgv.Rows[i].Cells["MusteriAd"].Value.ToString(),
                    KuryeAd = dgv.Rows[i].Cells["KuryeAd"].Value.ToString(),
                    KuryeUcreti = Convert.ToDouble(dgv.Rows[i].Cells["KuryeUcreti"].Value.ToString()),
                    KuryeHakEdis = Convert.ToDouble(dgv.Rows[i].Cells["KuryeHakEdis"].Value.ToString()),
                    IkıncıAdres = dgv.Rows[i].Cells["IkıncıAdres"].Value.ToString(),
                    TeslimAdresi = dgv.Rows[i].Cells["TeslimAdresi"].Value.ToString(),
                    AlimAdresi = dgv.Rows[i].Cells["AlimAdresi"].Value.ToString(),
                    Id = Convert.ToInt16(dgv.Rows[i].Cells["Id"].Value.ToString()),
                    PaketIcerigi = dgv.Rows[i].Cells["PaketIcerigi"].Value.ToString(),
                    Bende = Convert.ToBoolean(dgv.Rows[i].Cells["Bende"].Value.ToString()),
                    Kuryede = Convert.ToBoolean(dgv.Rows[i].Cells["Kuryede"].Value.ToString()),
                    Faturali = Convert.ToBoolean(dgv.Rows[i].Cells["Faturali"].Value.ToString()),
                    Faturasiz = Convert.ToBoolean(dgv.Rows[i].Cells["Faturasiz"].Value.ToString()),
                    Cari = Convert.ToBoolean(dgv.Rows[i].Cells["Cari"].Value.ToString()),
                    NakitKart = Convert.ToBoolean(dgv.Rows[i].Cells["NakitKart"].Value.ToString()),
                    Kdv = Convert.ToDouble(dgv.Rows[i].Cells["Kdv"].Value.ToString()),
                    Kazanc = Convert.ToDouble(dgv.Rows[i].Cells["Kazanc"].Value.ToString()),
                    Tarih = Convert.ToDateTime(dgv.Rows[i].Cells["Tarih"].Value.ToString())
                });
            }

            ReportDataSource rs = new ReportDataSource();
            rs.Name = "dsGenelRapor";
            rs.Value = kayit;

            Form_RaporGoster reportviever = new Form_RaporGoster();
            reportviever.reportViewer1.LocalReport.DataSources.Clear();
            reportviever.reportViewer1.LocalReport.DataSources.Add(rs);
            reportviever.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\GenelReport.rdlc";

            ReportParameter[] pm = new ReportParameter[9];
            pm[0] = new ReportParameter("Baslik", Baslik);
            pm[1] = new ReportParameter("KuryeUcreti", KuryeUcreti);
            pm[2] = new ReportParameter("KuryeHakEdis", KuryeHakEdis);
            pm[3] = new ReportParameter("Kurye", Kurye);
            pm[4] = new ReportParameter("Kazanc", Kazanc);
            pm[5] = new ReportParameter("Kdv", Kdv);
            pm[6] = new ReportParameter("Müşteri", Musteri);
            pm[7] = new ReportParameter("BaslangicTarihi", TarihBaslangic);
            pm[8] = new ReportParameter("BitisTarihi", TarihBitis);
            reportviever.reportViewer1.LocalReport.SetParameters(pm);

            reportviever.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
