using KuryePera.CLASSLARIM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryePera.FORMLARIM
{
    public partial class Form_Raporlama : Form
    {
        public Form_Raporlama()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities veri = new KuryePeraVeriTabaniEntities();
        private void kuryegetir()
        {
            var kuryeler = veri.PersonelTablosu.OrderBy(x => x.KuryeAdiSoyadi).ToList();
            comboKuryeSec.ValueMember = "Id";
            comboKuryeSec.DisplayMember = "KuryeAdiSoyadi";
            comboKuryeSec.DataSource= kuryeler;
            comboKuryeSec.SelectedIndex = -1;
        }
        private void musterigetir()
        {
            var musteriler = veri.MusteriTablosu.OrderBy(x => x.AdsoyadUnvan).ToList();
            comboMusteriSec.ValueMember = "Id";
            comboMusteriSec.DisplayMember = "AdsoyadUnvan";
            comboMusteriSec.DataSource= musteriler;
            comboMusteriSec.SelectedIndex = -1;
        }
        private void gridgetir()
        {
            var getir = veri.KayitTablosuu.ToList();
            gridRaporSonucu.DataSource = getir;
            gridRaporSonucu.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void gridduzenle()
        {
            gridRaporSonucu.Columns["Id"].Visible = false;
            gridRaporSonucu.Columns["MusteriAd"].HeaderText = "MÜŞTERİ ADI";
            gridRaporSonucu.Columns["KuryeAd"].HeaderText = "KURYE ADI";
            gridRaporSonucu.Columns["AlimAdresi"].HeaderText = "ALIM ADRESİ";
            gridRaporSonucu.Columns["MusteriAd"].DisplayIndex = 0;
            gridRaporSonucu.Columns["KuryeAd"].DisplayIndex = 1;
            gridRaporSonucu.Columns["AlimAdresi"].DisplayIndex = 2;
            gridRaporSonucu.Columns["TeslimAdresi"].HeaderText = "TESLİM ADRESİ";
            gridRaporSonucu.Columns["IkıncıAdres"].HeaderText = "YEDEK ADRES";
            gridRaporSonucu.Columns["PaketIcerigi"].HeaderText = "PAKET";
            gridRaporSonucu.Columns["KuryeUcreti"].HeaderText = "KURYE ÜCRETİ";
            gridRaporSonucu.Columns["Kdv"].HeaderText = "KDV";
            gridRaporSonucu.Columns["Kdv"].DefaultCellStyle.Format = "C2";
            gridRaporSonucu.Columns["KuryeUcreti"].DefaultCellStyle.Format = "C2";
            gridRaporSonucu.Columns["KuryeHakEdis"].DefaultCellStyle.Format = "C2";
            gridRaporSonucu.Columns["KuryeHakEdis"].HeaderText = "KURYE HAK EDİŞ";
            gridRaporSonucu.Columns["Faturali"].Visible = false;        
            gridRaporSonucu.Columns["Faturasiz"].Visible = false;
            gridRaporSonucu.Columns["Cari"].Visible = false;
            gridRaporSonucu.Columns["NakitKart"].Visible = false;
            gridRaporSonucu.Columns["Kuryede"].Visible = false;
            gridRaporSonucu.Columns["Bende"].Visible = false;
            gridRaporSonucu.Columns["SilinenKayitId"].Visible = false;
            gridRaporSonucu.Columns["Tarih"].HeaderText = "TARİH";
            gridRaporSonucu.Columns["Kazanc"].HeaderText = "KAZANÇ";
            gridRaporSonucu.Columns["Kazanc"].DefaultCellStyle.Format = "C2";
            gridRaporSonucu.Columns["TeslimEdilenKisi"].HeaderText = "TESLİM ALAN";
            gridRaporSonucu.RowHeadersVisible = false;
            gridRaporSonucu.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }
        private void Kuryecombofiltreleme()
        {
            comboKuryeSec.AutoCompleteMode=AutoCompleteMode.Suggest;
            comboKuryeSec.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void MustericomboFiltreleme()
        {
            comboMusteriSec.AutoCompleteMode=AutoCompleteMode.Suggest;
            comboMusteriSec.AutoCompleteSource=AutoCompleteSource.ListItems;
        }
        private void checkTumZamanlar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTumZamanlar.Checked)
            {
                dateTimeBaslangic.Enabled = false;
                dateTimeBitis.Enabled = false;
                
            }
            else
            {
                dateTimeBaslangic.Enabled = true;
                dateTimeBitis.Enabled = true;
               
            }
        }

        private void TumKuryeler_CheckedChanged(object sender, EventArgs e)
        {
            if (TumKuryeler.Checked)
            {
                comboKuryeSec.Enabled = false;
            }
            else
            {
                comboKuryeSec.Enabled= true;
            }
            
        }

        private void checkTumMusteriler_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTumMusteriler.Checked)
            {
               
                comboMusteriSec.Enabled = false;
            }
            else
            {
                
                comboMusteriSec.Enabled= true;
            }
        }

        private void Form_Raporlama_Load(object sender, EventArgs e)
        {
            lblkazanc.Visible = false;
            lblkdv.Visible = false;
            lblSorguSonucu.Visible = false;
            lblkuryehakedis.Visible = false;
            lblkuryeuucreti.Visible = false;
            musterigetir();
            kuryegetir();
            Kuryecombofiltreleme();
            gridgetir();
            MustericomboFiltreleme();
            gridduzenle();
         
        }

        private void btnRaporla_Click(object sender, EventArgs e)
        {
            lblkuryehakedis.Visible = true;
            lblkdv.Visible=true;
            lblkazanc.Visible=true;
            lblSorguSonucu.Visible = true;
            
            if (comboKuryeSec.Enabled == true)
            {
                if (string.IsNullOrEmpty(comboKuryeSec.Text))
                {
                    MessageBox.Show("LÜTFEN BİR KURYE SEÇİNİZ.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboKuryeSec.SelectedIndex == -1 && !veri.PersonelTablosu.Any(k => k.KuryeAdiSoyadi == comboKuryeSec.Text))
                {
                    MessageBox.Show("Girdiğiniz KURYE listede bulunmamaktadır. Lütfen geçerli bir KURYE seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (comboMusteriSec.Enabled == true)
            {
                if (string.IsNullOrEmpty(comboMusteriSec.Text))
                {
                    MessageBox.Show("LÜTFEN BİR MÜŞTERİ SEÇİNİZ.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (comboMusteriSec.SelectedIndex == -1 && !veri.MusteriTablosu.Any(x => x.AdsoyadUnvan == comboMusteriSec.Text))
                {
                    MessageBox.Show("Girdiğiniz MÜŞTERİ Veri Tabanında Bulunmamaktadır.\nLütfen Geçerli Bir MÜŞTERİ Seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DateTime baslangic = DateTime.Parse(dateTimeBaslangic.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(dateTimeBitis.Value.AddDays(1).ToShortDateString());
            var sorgu = veri.KayitTablosuu.Where(x => (TumKuryeler.Checked || x.KuryeAd == comboKuryeSec.Text) && (checkTumMusteriler.Checked || x.MusteriAd == comboMusteriSec.Text) && ((checkTumZamanlar.Checked) || (x.Tarih >= baslangic && x.Tarih <= bitis))).OrderBy(x => x.Id).ToList();
            gridRaporSonucu.DataSource = sorgu;

            var islemsayisi = sorgu.Count();
            double kazanc = Convert.ToDouble(sorgu.Sum(x => x.Kazanc) ?? 0);
            double kuryeucreti = Convert.ToDouble(sorgu.Sum(x=>x.KuryeUcreti) ?? 0);
            double vergi = Convert.ToDouble(sorgu.Sum(x=>x.Kdv) ?? 0);
            double kuryehakedis  = Convert.ToDouble(sorgu.Sum(x=>x.KuryeHakEdis) ?? 0);
            lblkazanc.Text = kazanc.ToString("C2");
            lblkazanc.BackColor= Color.Green;
            lblkazanc.ForeColor = Color.Pink;
            lblkdv.Text = vergi.ToString("C2");
            lblkdv.BackColor = Color.Red;
            lblkdv.ForeColor = Color.Yellow;
            lblkuryehakedis.Text = kuryehakedis.ToString("C2");
            lblkuryehakedis.BackColor = Color.Aqua;
            lblkuryeuucreti.Text = kuryeucreti.ToString();
            lblSorguSonucu.Text="SORGU SONUCUNDA " +islemsayisi.ToString() + " ADET SONUÇ BULUNMUŞTUR";
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            
            ReportRaporu.Baslik = "KURYEPERA GENEL RAPOR";
            ReportRaporu.TarihBaslangic = dateTimeBaslangic.Value.ToShortDateString();
            ReportRaporu.TarihBitis = dateTimeBitis.Value.ToShortDateString();
            ReportRaporu.Kurye = comboKuryeSec.Text;
            ReportRaporu.Musteri= comboMusteriSec.Text;
            ReportRaporu.Kazanc = lblkazanc.Text;
            ReportRaporu.Kdv = lblkdv.Text;
            ReportRaporu.KuryeHakEdis = lblkuryehakedis.Text;
            ReportRaporu.KuryeUcreti = lblkuryeuucreti.Text;
            ReportRaporu.RaporSayfasiRaporu(gridRaporSonucu);

        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridRaporSonucu.Rows.Count > 0)
            {
                DialogResult cevap = MessageBox.Show("SEÇİLİ İŞLEM SİLİNECEK.\nONAYLIYOR MUSUNUZ ???", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    int sil = Convert.ToInt32(gridRaporSonucu.CurrentRow.Cells[0].Value);
                    var silinecek = veri.KayitTablosuu.FirstOrDefault(x => x.Id == sil);
                    if (silinecek != null)
                    {
                        var tahsilatlar = veri.KuryeOdemeTablosu.Where(x => x.KayitTablosuId == sil).ToList();
                        _ = veri.KuryeOdemeTablosu.RemoveRange(tahsilatlar);
                        veri.KayitTablosuu.Remove(silinecek);
                        veri.SaveChanges();
                    }
                    gridgetir();
                    gridduzenle();
                }
            }
        }
    }
}
