using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KuryePera.CLASSLARIM;

namespace KuryePera.FORMLARIM
{
    public partial class Form_KayitEkle : Form
    {
        public Form_KayitEkle()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities veri = new KuryePeraVeriTabaniEntities();
        private void gridduzenle()
        {
            gridKayitEkrani.Columns["Id"].Visible = true;
            gridKayitEkrani.Columns["Id"].DisplayIndex = 0;
            gridKayitEkrani.Columns["Id"].HeaderText = "SIRA";
            gridKayitEkrani.Columns["MusteriAd"].HeaderText = "MÜŞTERİ ADI";
            gridKayitEkrani.Columns["KuryeAd"].HeaderText = "KURYE ADI";
            gridKayitEkrani.Columns["AlimAdresi"].HeaderText = "ALIM ADRESİ";
            gridKayitEkrani.Columns["MusteriAd"].DisplayIndex = 1;
            gridKayitEkrani.Columns["KuryeAd"].DisplayIndex = 2;
            gridKayitEkrani.Columns["AlimAdresi"].DisplayIndex = 3;
            gridKayitEkrani.Columns["TeslimAdresi"].HeaderText = "TESLİM ADRESİ";
            gridKayitEkrani.Columns["IkıncıAdres"].HeaderText = "YEDEK ADRES";
            gridKayitEkrani.Columns["PaketIcerigi"].HeaderText = "PAKET";
            gridKayitEkrani.Columns["KuryeUcreti"].HeaderText = "KURYE ÜCRETİ";
            gridKayitEkrani.Columns["Kdv"].HeaderText = "KDV";
            gridKayitEkrani.Columns["Kdv"].DefaultCellStyle.Format = "C2";
            gridKayitEkrani.Columns["KuryeUcreti"].DefaultCellStyle.Format = "C2";
            gridKayitEkrani.Columns["KuryeHakEdis"].DefaultCellStyle.Format = "C2";
            gridKayitEkrani.Columns["KuryeHakEdis"].HeaderText = "KURYE HAK EDİŞ";
            gridKayitEkrani.Columns["Faturali"].Visible = false;
            gridKayitEkrani.Columns["Faturasiz"].Visible = false;
            gridKayitEkrani.Columns["Cari"].Visible = true;
            gridKayitEkrani.Columns["NakitKart"].Visible = false;
            gridKayitEkrani.Columns["Kuryede"].Visible = false;
            gridKayitEkrani.Columns["Bende"].Visible = false;
            gridKayitEkrani.Columns["Tarih"].HeaderText = "TARİH";
            gridKayitEkrani.Columns["Kazanc"].HeaderText = "KAZANÇ";
            gridKayitEkrani.Columns["Kazanc"].DefaultCellStyle.Format = "C2";
            gridKayitEkrani.Columns["TeslimEdilenKisi"].HeaderText = "TESLİM ALAN";
            gridKayitEkrani.Columns["SilinenKayitId"].Visible = false;
            gridKayitEkrani.RowHeadersVisible = false;
            gridKayitEkrani.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }
        private void gridgetir()
        {
            var getir = veri.KayitTablosuu.ToList();
            gridKayitEkrani.DataSource = getir;
            gridKayitEkrani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void temizle()
        {
   
            comboMusteriAdi.SelectedIndex = -1;
            comboKuryeAdi.SelectedIndex = -1;
            comboPaketIcerigi.SelectedIndex = -1;
            txtTeslimAdresi.Text = "";
            txtTeslimAdresi.Clear();
            txtYedekAdres.Text = "";
            txtYedekAdres.Clear();
            txtKuryeHakEdis.Clear();
            txtAlinacakAdres.Clear();
            txtAlinacakAdres.Text = "";
            txtKuryeUcreti.Clear();
            txtTeslimEdilenKisi.Clear();
            txtTeslimEdilenKisi.Text = "";
        }
        private void zaman()
        {
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yarin = Convert.ToDateTime(bugun.AddDays(1).ToShortDateString());
            var sorgu = veri.KayitTablosuu.Where(x => x.Tarih >= bugun && x.Tarih <= yarin).OrderByDescending(x => x.Id).ToList();
            gridKayitEkrani.DataSource = sorgu;
        }
        private void personelgetir()
        {
            var personeller = veri.PersonelTablosu.Where(x => x.KuryeAdiSoyadi != null).OrderBy(x => x.KuryeAdiSoyadi).ToList();
            comboKuryeAdi.ValueMember = "Id";
            comboKuryeAdi.DisplayMember = "KuryeAdiSoyadi";
            comboKuryeAdi.DataSource = personeller;
            comboKuryeAdi.SelectedIndex = -1;
        }
        private void musterigetir()
        {
            var musteriler = veri.MusteriTablosu.Where(x => x.AdsoyadUnvan != null).OrderBy(x => x.AdsoyadUnvan).ToList();
            comboMusteriAdi.ValueMember = "Id";
            comboMusteriAdi.DisplayMember = "AdsoyadUnvan";
            comboMusteriAdi.DataSource = musteriler;
            comboMusteriAdi.SelectedIndex = -1;

        }
        private void combofiltreleme()
        {
            comboMusteriAdi.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboMusteriAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboKuryeAdi.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboKuryeAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void adresgetir()
        {
            if (comboMusteriAdi.SelectedItem != null && comboMusteriAdi.SelectedIndex != -1)
            {

                var secilikisi = (MusteriTablosu)comboMusteriAdi.SelectedItem;
                string adres = secilikisi.MusteriAdres;
                string yetkilikisi = secilikisi.YetkiliKisi;
                txtAlinacakAdres.Text = "ALINACAK ADRES : " + adres + "\r\nYETKİLİ KİŞİ : " + yetkilikisi;
            }
        }
        private string kuryetelno()
        {
            if (comboKuryeAdi.SelectedItem != null)
            {
                var kuryetelno = (PersonelTablosu)comboKuryeAdi.SelectedItem;
                return kuryetelno.KuryeTelefonNumarasi;
            }
            else
            {
                return null;
            }
        }
        private string musteritelno()
        {
            if (comboMusteriAdi.SelectedItem != null)
            {
                var musteritelno = (MusteriTablosu)comboMusteriAdi.SelectedItem;
                return musteritelno.MusteriTelefon;
            }
            else
            {
                return null;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            lblkazanc.Visible = true;
            if (btnKaydet.Text != "GÜNCELLE")
            {

                if (string.IsNullOrEmpty(comboMusteriAdi.Text))
                {
                    MessageBox.Show("Lütfen Müşteriyi Seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboMusteriAdi.SelectedIndex == -1 && !veri.MusteriTablosu.Any(x => x.AdsoyadUnvan == comboMusteriAdi.Text))
                {
                    MessageBox.Show("Müşteri Veri Tabanında Bulunamadı Lütfen Tekrar Deneyiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(txtKuryeUcreti.Text))
                {
                    MessageBox.Show("Lütfen Kurye Ücretini Giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string musteriad = comboMusteriAdi.Text;
                string kuryead = comboKuryeAdi.Text;
                string alinacakadres = txtAlinacakAdres.Text;
                string teslimedilecekadres = txtTeslimAdresi.Text;
                string paketicerigi = comboPaketIcerigi.Text;
                string ikinciadres = txtYedekAdres.Text;
                string teslimedilenkisi = txtTeslimEdilenKisi.Text;
                double kuryeucreti = 0;
                double kdv = 0.2;
                double kuryehakedis = 0;

                try
                {
                    kuryeucreti = Convert.ToDouble(txtKuryeUcreti.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Kurye Ücretine Metinsel İfadeler Girmeyiniz.\nveya BOŞ BIRAKMAYINIZ.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    kuryehakedis = Convert.ToDouble(txtKuryeHakEdis.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Kurye Hak Edişe Metinsel Değerler Girmeyiniz veya Boş Bırakmayınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!radioBende.Checked && !radioKuryede.Checked)
                {
                    MessageBox.Show("Lütfen Müşteriden Gelen Paranın Kimde Olduğunu Seçiniz.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!radioCari.Checked && !radioNakit.Checked)
                {
                    MessageBox.Show("Lütfen Müşteriden Alınan Paranın CARİ mi Yoksa NAKİT mi olduğunu Seçiniz.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double vergisiz = kuryeucreti - kuryehakedis;
                double vergi = kuryeucreti * kdv;
                double kdvharicfiyat = kuryeucreti / (1 + kdv);
                double kdvbul = kuryeucreti - kdvharicfiyat;
                double kazanc = kuryeucreti - kuryehakedis - kdvbul;
      
            
                KayitTablosuu kayit = new KayitTablosuu();
       
                if (radioFaturali.Checked)
                {
                    kayit.Faturali = true;
                    kayit.Faturasiz = false;
                    kayit.Kdv = kdvbul;
                    kayit.Kazanc=kazanc;
                    lblkazanc.Text = kazanc.ToString("C2");
                }
                if (radioFaturasiz.Checked)
                {
                    kayit.Faturasiz = true;
                    kayit.Faturali = false;
                    kdvbul = 0;
                    kazanc = kuryeucreti - kuryehakedis;
                    kayit.Kdv = kdvbul;
                    kayit.Kazanc = kazanc;
                    lblkazanc.Text = kazanc.ToString("C2");

                }
                lblkazanc.Text = kazanc.ToString("C2");
                kayit.MusteriAd = musteriad;
                kayit.KuryeAd = kuryead;
                kayit.AlimAdresi = alinacakadres;
                kayit.TeslimAdresi = teslimedilecekadres;
                kayit.IkıncıAdres = ikinciadres;
                kayit.PaketIcerigi = paketicerigi;
                kayit.KuryeUcreti = kuryeucreti;
                kayit.Kdv = kdvbul;
                kayit.KuryeHakEdis = kuryehakedis;
                kayit.Tarih = dateTimeTarih.Value;
                kayit.Kazanc = kazanc;
                kayit.TeslimEdilenKisi = teslimedilenkisi;
                veri.KayitTablosuu.Add(kayit);
                veri.SaveChanges();
                kayit.SilinenKayitId = kayit.Id;
                veri.SaveChanges();
                if (radioCari.Checked)
                {
                    
                    kayit.Cari = true;
                    kayit.NakitKart = false;
                    kayit.Kuryede = false;
                    var mussteriborcuvarmi = veri.MusteriOdemeTablosu.FirstOrDefault(x => x.MusteriAdi == comboMusteriAdi.Text);
                    if (mussteriborcuvarmi != null)
                    {
                        mussteriborcuvarmi.MusteriToplamBorc += Convert.ToDouble(txtKuryeUcreti.Text);
                    }
                    else
                    {
                        MusteriOdemeTablosu musteriborcode = new MusteriOdemeTablosu();
                        musteriborcode.MusteriAdi = comboMusteriAdi.Text;
                        musteriborcode.MusteriToplamBorc = Convert.ToDouble(txtKuryeUcreti.Text);
                        var telefonno = veri.MusteriTablosu.FirstOrDefault(x => x.AdsoyadUnvan == comboMusteriAdi.Text);
                        string telno = telefonno?.MusteriTelefon;
                        musteriborcode.MusteriTelefon = telno;
                        musteriborcode.OdemeDurumu = false;                    
                        veri.MusteriOdemeTablosu.Add(musteriborcode);

                    }
                    veri.SaveChanges();
                }
                else if (radioNakit.Checked)
                {
                    kayit.Cari = false;
                    kayit.NakitKart = true;
                    // Müşteri daha önce kaydedilmiş mi kontrol ediyoruz
                    var mevcutMusteri = veri.MusteriOdemeTablosu.FirstOrDefault(x => x.MusteriAdi == comboMusteriAdi.Text);

                    if (mevcutMusteri == null) // Eğer müşteri daha önce kaydedilmemişse
                    {
                        MusteriOdemeTablosu yeniMusteriBorcu = new MusteriOdemeTablosu();
                        yeniMusteriBorcu.MusteriAdi = comboMusteriAdi.Text;
                        yeniMusteriBorcu.MusteriToplamBorc = 0;
                        yeniMusteriBorcu.OdemeDurumu = false;
                        veri.MusteriOdemeTablosu.Add(yeniMusteriBorcu);
                    }
                    else // Eğer müşteri daha önce kaydedilmişse
                    {
                        // Mevcut tablodaki borcu sıfırlıyoruz
                        mevcutMusteri.MusteriToplamBorc += 0;
                    }

                    veri.SaveChanges();
                }
             
                if (radioKuryede.Checked)
                {
                    kayit.Kuryede = true;
                    kayit.Bende = false;
                    var kuryeborcu = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.KuryeAdi == comboKuryeAdi.Text);
                    if (kuryeborcu != null)
                    {
                        double kuryebedeli = Convert.ToDouble(txtKuryeUcreti.Text);
                        double kuryehesap = Convert.ToDouble(txtKuryeHakEdis.Text);
                        kuryeborcu.KuryeToplamBorc += kuryebedeli - kuryehesap;                   
                    }                   
                    else
                    {
                        if(comboKuryeAdi.SelectedIndex!=-1)
                        {
                            double kuryebedeli = Convert.ToDouble(txtKuryeUcreti.Text);
                            double kuryehesap = Convert.ToDouble(txtKuryeHakEdis.Text);
                            KuryeOdemeTablosu kuryeodeme = new KuryeOdemeTablosu();
                            kuryeodeme.KuryeAdi = comboKuryeAdi.Text;
                            var tel = veri.PersonelTablosu.FirstOrDefault(x => x.KuryeAdiSoyadi == comboKuryeAdi.Text);
                            string telefonnumarasikurye = tel?.KuryeTelefonNumarasi;
                            kuryeodeme.KuryeTelefonNumarasi = telefonnumarasikurye;
                            kuryeodeme.KuryeToplamBorc = kuryebedeli - kuryehesap;
                            kuryeodeme.KuryeyeOlanBorc = 0;
                            kuryeodeme.KayitTablosuId = kayit.SilinenKayitId;
                            veri.KuryeOdemeTablosu.Add(kuryeodeme);
                        } 
                    

                    }
                    veri.SaveChanges();
                }
                else if (radioBende.Checked)
                {
                   
                    kayit.Bende = true;
                    kayit.Kuryede = false;
                    var kuryeyeolanborc = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.KuryeAdi == comboKuryeAdi.Text);
                    if (kuryeyeolanborc != null)
                    {
                        double kuryebedeli = Convert.ToDouble(txtKuryeUcreti.Text);
                        double kuryehesap = Convert.ToDouble(txtKuryeHakEdis.Text);
                        kuryeyeolanborc.KuryeyeOlanBorc += kuryehesap;
                    }
                    else
                    {
                        if (comboKuryeAdi.SelectedIndex != -1)
                        {
                            double kuryebedeli = Convert.ToDouble(txtKuryeUcreti.Text);
                            double kuryehesap = Convert.ToDouble(txtKuryeHakEdis.Text);
                            KuryeOdemeTablosu kurryeodeme = new KuryeOdemeTablosu();
                            kurryeodeme.KuryeAdi = comboKuryeAdi.Text;
                            var tel = veri.PersonelTablosu.FirstOrDefault(x => x.KuryeAdiSoyadi == comboKuryeAdi.Text);
                            string telno = tel?.KuryeTelefonNumarasi;
                            kurryeodeme.KuryeTelefonNumarasi = telno;
                            kurryeodeme.KuryeToplamBorc = 0;
                            kurryeodeme.KuryeyeOlanBorc = kuryehesap;
                            kurryeodeme.KayitTablosuId = kayit.Id;
                            veri.KuryeOdemeTablosu.Add(kurryeodeme);
                        }
                  
                    }
                    veri.SaveChanges();
                }
              
                MessageBox.Show("TEBRİKLER KAYIT İŞLEMİNİZ BAŞARILI", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridgetir();
                gridduzenle();
                zaman();
                temizle();
                var telefonnumarasi = kuryetelno(); // kurye telefon numarası al 
                if (txtYedekAdres.Text == null || string.IsNullOrEmpty(txtYedekAdres.Text))
                {
                    int KaydedilenId = kayit.Id;


                    KuryeOdemeTablosu kuryeodeme = new KuryeOdemeTablosu();
                    kuryeodeme.KuryeAdi = comboKuryeAdi.Text;
                    var tel = veri.PersonelTablosu.FirstOrDefault(x => x.KuryeAdiSoyadi == comboKuryeAdi.Text);
                    string telefonnumarasikurye = tel?.KuryeTelefonNumarasi;
                    kuryeodeme.KuryeTelefonNumarasi = telefonnumarasikurye;
                   
                    // kod yapını düzeltmen lazım önce kayıt olacak sonra borç eklenecek bu şekilde kullanabilirsin
                    string adres = txtTeslimAdresi.Text;
                    string adres2 = txtAlinacakAdres.Text;
                    if (telefonnumarasi != null)
                    {
                        MessageApi sms = new MessageApi();
                        sms.SmsSender(telefonnumarasi, adres, adres2);
                        MessageBox.Show("Tebrikler Kuryeye Mesaj Gönderilmiştir.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kuryenin Telefon Numarası Bulunamadı.\nMesaj Gönderilemedi.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    string adres = txtYedekAdres.Text;
                    string adres2 = txtAlinacakAdres.Text;
                    if (telefonnumarasi != null)
                    {
                        MessageApi sms = new MessageApi();
                        sms.SmsSender(telefonnumarasi, adres, adres2);
                        MessageBox.Show("Tebrikler Kuryeye Mesaj Gönderilmiştir.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kuryenin Telefon Numarası Bulunamadı.\nMesaj Gönderilemedi.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                double kuryeucreti = 0;
                double kuryehakedis = 0;
                double kdv = 0.2;
                try
                {
                    kuryeucreti = Convert.ToDouble(txtKuryeUcreti.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Kurye Ücretine Metinsel İfadeler Girmeyiniz.\nveya BOŞ BIRAKMAYINIZ.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    kuryehakedis = Convert.ToDouble(txtKuryeHakEdis.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Kurye Hak Edişe Metinsel Değerler Girmeyiniz veya Boş Bırakmayınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (radioNakit.Checked && !radioBende.Checked && !radioKuryede.Checked)
                {
                    MessageBox.Show("Lütfen Müşteriden Gelen Paranın Kimde Olduğunu Seçiniz.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                double vergisiz = kuryeucreti - kuryehakedis;
                double vergi = kuryeucreti * kdv;
                double kdvharicfiyat = kuryeucreti / (1 + kdv);
                double kdvbul = kuryeucreti - kdvharicfiyat;
                double kazanc = kuryeucreti - kuryehakedis - kdvbul;

                int guncelle = Convert.ToInt32(gridKayitEkrani.CurrentRow.Cells[0].Value);
                var guncel = veri.KayitTablosuu.FirstOrDefault(x => x.Id == guncelle);
                guncel.KuryeAd = comboKuryeAdi.Text;
                guncel.MusteriAd = comboMusteriAdi.Text;
                guncel.PaketIcerigi = comboPaketIcerigi.Text;
                guncel.AlimAdresi = txtAlinacakAdres.Text;
                guncel.TeslimAdresi = txtTeslimAdresi.Text;
                guncel.IkıncıAdres = txtYedekAdres.Text;
                guncel.Kdv = kdvbul;
//                guncel.KuryeUcreti = Convert.ToDouble(txtKuryeUcreti.Text);
      //          guncel.KuryeHakEdis = Convert.ToDouble(txtKuryeHakEdis.Text);
                guncel.TeslimEdilenKisi = txtTeslimEdilenKisi.Text;

                if (radioFaturali.Checked)
                {
                    guncel.Faturali = true;
                    guncel.Faturasiz = false;
                    guncel.Kdv = kdvbul;
                    guncel.Kazanc = kazanc;
                }
                else if (radioFaturasiz.Checked)
                {

                    kdv = 0;
                    kazanc = kuryeucreti - kuryehakedis;
                    guncel.Faturali = false;
                    guncel.Faturasiz = true;
                    guncel.Kdv = kdvbul;
                    guncel.Kazanc = kazanc;
                }
                if (radioCari.Checked)
                {
                    double guncellenentahsilat = Convert.ToDouble(txtKuryeUcreti.Text);
                    guncel.Kuryede = false;
                    guncel.Cari = true;
                    guncel.NakitKart = false;
                    var musteriborcvarmi = veri.MusteriOdemeTablosu.FirstOrDefault(x => x.MusteriAdi == comboMusteriAdi.Text);
                    if (musteriborcvarmi != null)
                    {
                        int borcdegis = Convert.ToInt32(gridKayitEkrani.CurrentRow.Cells[0].Value);
                        var guncellenecekborc = veri.KayitTablosuu.FirstOrDefault(x => x.Id == borcdegis);
                        double eskiborc = Convert.ToDouble(guncellenecekborc.KuryeUcreti);
                        musteriborcvarmi.MusteriToplamBorc -= eskiborc;
                        double yeniborc = Convert.ToDouble(txtKuryeUcreti.Text);
                        musteriborcvarmi.MusteriToplamBorc += yeniborc;
                        guncellenecekborc.KuryeUcreti = yeniborc;
                        guncel.KuryeUcreti = Convert.ToDouble(txtKuryeUcreti.Text);
                        guncel.KuryeHakEdis = Convert.ToDouble(txtKuryeHakEdis.Text);

                    }
                    else
                    {
                        MusteriOdemeTablosu musteriborcode = new MusteriOdemeTablosu();
                        musteriborcode.MusteriAdi = comboMusteriAdi.Text;
                        musteriborcode.MusteriToplamBorc = Convert.ToDouble(txtKuryeUcreti.Text);
                        var telefonno = veri.MusteriTablosu.FirstOrDefault(x => x.AdsoyadUnvan == comboMusteriAdi.Text);
                        string telno = telefonno?.MusteriTelefon;
                        musteriborcode.MusteriTelefon = telno;
                        veri.MusteriOdemeTablosu.Add(musteriborcode);
                    }
                    veri.SaveChanges();
                }
                else if (radioNakit.Checked)
                {
                    guncel.Cari = false;
                    guncel.NakitKart = true;
                    // Müşteri daha önce kaydedilmiş mi kontrol ediyoruz
                    var mevcutMusteri = veri.MusteriOdemeTablosu.FirstOrDefault(x => x.MusteriAdi == comboMusteriAdi.Text);

                    if (mevcutMusteri == null) // Eğer müşteri daha önce kaydedilmemişse
                    {
                        MusteriOdemeTablosu yeniMusteriBorcu = new MusteriOdemeTablosu();
                        yeniMusteriBorcu.MusteriAdi = comboMusteriAdi.Text;
                        yeniMusteriBorcu.MusteriToplamBorc = 0;
                        yeniMusteriBorcu.OdemeDurumu = false;
                        veri.MusteriOdemeTablosu.Add(yeniMusteriBorcu);
                    }
                    else // Eğer müşteri daha önce kaydedilmişse
                    {
                        // Mevcut tablodaki borcu sıfırlıyoruz
                        mevcutMusteri.MusteriToplamBorc += 0;
                    }
                    veri.SaveChanges();
                }
                if (radioBende.Checked)
                {
                    guncel.Bende = true;
                    guncel.Kuryede = false;
                    var kuryeyeolanborc = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.KuryeAdi == comboKuryeAdi.Text);
                    if (kuryeyeolanborc != null)
                    {
                        int borcdegis =Convert.ToInt32(gridKayitEkrani.CurrentRow.Cells[0].Value);
                        var guncellenecekborc = veri.KayitTablosuu.FirstOrDefault(x => x.Id == borcdegis);
                        double eskiborc = Convert.ToDouble(guncellenecekborc.KuryeHakEdis);
                       kuryeyeolanborc.KuryeyeOlanBorc -= eskiborc;
                        double yeniborc = Convert.ToDouble(txtKuryeHakEdis.Text);
                        kuryeyeolanborc.KuryeyeOlanBorc += yeniborc;
                        guncellenecekborc.KuryeHakEdis = yeniborc;
                        guncel.KuryeHakEdis = Convert.ToDouble(txtKuryeHakEdis.Text);
                        guncel.KuryeUcreti = Convert.ToDouble(txtKuryeUcreti.Text);
                    }
                    else
                    {
                        string kuryead = comboKuryeAdi.Text;
                        double kuryebedeli = Convert.ToDouble(txtKuryeUcreti.Text);
                        double kuryehesap = Convert.ToDouble(txtKuryeHakEdis.Text);
                        KuryeOdemeTablosu kuryeyeolanborcum = new KuryeOdemeTablosu();
                        kuryeyeolanborcum.KuryeAdi = kuryead;
                        var kuryetelefonnumarasimi = veri.PersonelTablosu.FirstOrDefault(x => x.KuryeAdiSoyadi == comboKuryeAdi.Text);
                        string telno = kuryetelefonnumarasimi?.KuryeTelefonNumarasi;
                        kuryeyeolanborcum.KuryeTelefonNumarasi = telno;
                        kuryeyeolanborcum.KuryeToplamBorc = kuryebedeli - kuryehesap;
                        kuryeyeolanborcum.KuryeyeOlanBorc = 0;
                        veri.KuryeOdemeTablosu.Add(kuryeyeolanborcum);
                    }
                    veri.SaveChanges();
                }
                else if (radioKuryede.Checked)
                {
                    guncel.Kuryede = true;
                    guncel.Bende = false;
                    var kuryeborcu = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.KuryeAdi == comboKuryeAdi.Text);
                    if (kuryeborcu != null)
                    {
                        int borcdegis = Convert.ToInt32(gridKayitEkrani.CurrentRow.Cells[0].Value);
                        var guncellenecekborc = veri.KayitTablosuu.FirstOrDefault(x=>x.Id== borcdegis);
                        double eskiborc = Convert.ToDouble(guncellenecekborc.KuryeUcreti) - Convert.ToDouble(guncellenecekborc.KuryeHakEdis);
                        kuryeborcu.KuryeToplamBorc -= eskiborc;
                        double ucret = Convert.ToInt32(txtKuryeUcreti.Text);
                        double haketmek = Convert.ToInt32(txtKuryeHakEdis.Text);
                        double yeniborc = ucret- haketmek;
                        kuryeborcu.KuryeToplamBorc += yeniborc;
                        guncellenecekborc.KuryeUcreti = ucret;
                        guncellenecekborc.KuryeHakEdis = haketmek;
                        guncel.KuryeHakEdis = Convert.ToDouble(txtKuryeHakEdis.Text);
                        guncel.KuryeUcreti = Convert.ToDouble(txtKuryeUcreti.Text);

                    }
                    else
                    {
                        double kuryebedeli = Convert.ToDouble(txtKuryeUcreti.Text);
                        double kuryehesap = Convert.ToDouble(txtKuryeHakEdis.Text);
                        KuryeOdemeTablosu kuryeodeme = new KuryeOdemeTablosu();
                        kuryeodeme.KuryeAdi = comboKuryeAdi.Text;
                        var tel = veri.PersonelTablosu.FirstOrDefault(x => x.KuryeAdiSoyadi == comboKuryeAdi.Text);
                        string telefonnumarasikurye = tel?.KuryeTelefonNumarasi;
                        kuryeodeme.KuryeTelefonNumarasi = telefonnumarasikurye;
                        kuryeodeme.KuryeToplamBorc = kuryebedeli - kuryehesap;
                        kuryeodeme.KuryeyeOlanBorc = 0;
                        veri.KuryeOdemeTablosu.Add(kuryeodeme);

                    }
                    veri.SaveChanges();
                }
                btnKaydet.Text = "KAYDET";
                veri.SaveChanges();
                gridgetir();
                gridduzenle();
                MessageBox.Show("TEBRİKLER GÜNCELLEME İŞLEMİNİZ BAŞARIYLA GERÇEKLEŞTİRİLMİŞTİR.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
            }
        }

        private void Form_KayitEkle_Load(object sender, EventArgs e)
        {
            gridgetir();
            gridduzenle();
            zaman();
            personelgetir();
            musterigetir();
            combofiltreleme();
            temizle();
            lblkazanc.Visible = false;
            lblyenikullanici.Text = Gecis.CurrentUsername;
            List<string> paketIcerikleri = new List<string>
            {
                "EVRAK",
                "KUTU",
                "KOLİ"
            };

            // comboPaketIcerigi kontrolünün veri kaynağını ayarlayalım
            comboPaketIcerigi.DataSource = paketIcerikleri;
            comboPaketIcerigi.SelectedIndex = -1;
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridKayitEkrani.Rows.Count > 0)
            {
                DialogResult cevap = MessageBox.Show("SEÇİLİ İŞLEM SİLİNECEK.\nONAYLIYOR MUSUNUZ ???", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    int sil = Convert.ToInt32(gridKayitEkrani.CurrentRow.Cells[0].Value);
                    var silinecek = veri.KayitTablosuu.FirstOrDefault(x => x.Id == sil);
                    if (silinecek != null)
                    {
                        double silinecekborc = Convert.ToDouble(silinecek.KuryeUcreti - silinecek.KuryeHakEdis);
                        double silinecekborcsirket = Convert.ToDouble(silinecek.KuryeHakEdis);
                        double silinecekborcmusteri = Convert.ToDouble(silinecek.KuryeUcreti);
                        var kuryeadininamk = gridKayitEkrani.CurrentRow.Cells[15].Value.ToString();
                        var musteriadininamk = gridKayitEkrani.CurrentRow.Cells[14].Value.ToString();
                        var radiobende = gridKayitEkrani.CurrentRow.Cells[12].Value.ToString();
                        var radiocari = gridKayitEkrani.CurrentRow.Cells[9].Value.ToString();
                        var radiokuryede = gridKayitEkrani.CurrentRow.Cells[11].Value.ToString();
                        bool radiobendedurumu = Convert.ToBoolean(radiobende);
                        bool radiocaridurumu = Convert.ToBoolean(radiocari);
                        bool radiokuryededurumu=Convert.ToBoolean(radiokuryede);
                        var kuryeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.KuryeAdi == kuryeadininamk);
                        var musteriodeme = veri.MusteriOdemeTablosu.FirstOrDefault(x => x.MusteriAdi == musteriadininamk);
                        if (!radiobendedurumu) //RadioBende False Değer Gelirse yani para Kuryedeyse
                        {
                            if (kuryeodeme != null)
                            {
                                kuryeodeme.KuryeToplamBorc -= silinecekborc;
                                veri.SaveChanges();
                            }
                        }
                        else
                        {
                            //RadioBende True Değer Gelirse Yani Para Bendeyse
                            if (kuryeodeme != null)
                            {
                                kuryeodeme.KuryeyeOlanBorc -= silinecekborcsirket;
                                veri.SaveChanges();
                            }

                        }
                        if (!radiocaridurumu) //RadioCari False değer Gelirse Yani Müşteri Parayı Nakit vermiş borcu yoksa
                        {
                           //İŞLEM YAPMAYA GEREK YOKTUR !!!
                        }
                        else
                        {
                            //Radio Cari True değer gelirse Yani Müşteri Parayı Banka Hesabından atacaksa Şirkete Borçlanmışsa
                            if(musteriodeme != null)
                            {
                                musteriodeme.MusteriToplamBorc -= silinecekborcmusteri;
                                veri.SaveChanges();
                            }
                        }

                        veri.KayitTablosuu.Remove(silinecek);
                        veri.SaveChanges();
                        MessageBox.Show("TEBRİKLER KAYIT SİLİNMİŞTİR.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                    }
                    gridgetir();
                    gridduzenle();
                }
            }

        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridKayitEkrani.Rows.Count > 0)
            {
                int secilen = gridKayitEkrani.SelectedCells[0].RowIndex;
                bool boolDeger = (gridKayitEkrani.Rows[secilen]?.Cells[12]?.Value as bool?) ?? false;
                bool deger = (gridKayitEkrani.Rows[secilen]?.Cells[7]?.Value as bool?) ?? false;
                if (deger == true)
                {
                    radioFaturali.Checked = true;
                }
                if(deger == false)
                {
                    radioFaturasiz.Checked = false;
                }
                if (boolDeger == true)
                {
                    radioBende.Checked = true; 
                }
                if(boolDeger == false)
                {
                    radioKuryede.Checked = true;
                }

               
                int guncelle = Convert.ToInt32(gridKayitEkrani.CurrentRow.Cells[0].Value);
                var guncel = veri.KayitTablosuu.FirstOrDefault(x => x.Id == guncelle);
                comboKuryeAdi.Text = guncel.KuryeAd;
                comboMusteriAdi.Text = guncel.MusteriAd;
                comboPaketIcerigi.Text = guncel.PaketIcerigi;
                txtAlinacakAdres.Text = guncel.AlimAdresi;
                txtTeslimAdresi.Text = guncel.TeslimAdresi;
                txtYedekAdres.Text = guncel.IkıncıAdres;
                txtTeslimEdilenKisi.Text = guncel.TeslimEdilenKisi;
                txtKuryeHakEdis.Text = Convert.ToDouble(guncel.KuryeHakEdis).ToString();
                txtKuryeUcreti.Text = Convert.ToDouble(guncel.KuryeUcreti).ToString();
                if (radioBende.Checked)
                {
                    guncel.Bende = true;
                    guncel.Kuryede = false;
                }
                else if (radioKuryede.Checked)
                {
                    guncel.Kuryede = true;
                    guncel.Bende = false;
                }
                if (radioCari.Checked)
                {
                    guncel.Cari = true;
                    guncel.Kuryede = false;
                    guncel.NakitKart = false;
                }
                else if (radioNakit.Checked)
                {
                    guncel.NakitKart = true;
                    guncel.Cari = false;
                }
                double kuryeucreti = 0;
                double kuryehakedis = 0;
                double kdv = 0.2;

                if (radioNakit.Checked && !radioBende.Checked && !radioKuryede.Checked)
                {
                    MessageBox.Show("Lütfen Müşteriden Gelen Paranın Kimde Olduğunu Seçiniz.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double vergisiz = kuryeucreti - kuryehakedis;
                double vergi = kuryeucreti * kdv;
                double kdvharicfiyat = kuryeucreti / (1 + kdv);
                double kdvbul = kuryeucreti - kdvharicfiyat;
                double kazanc = kuryeucreti - kuryehakedis - kdvbul;
                if (radioFaturali.Checked)
                {


                    guncel.Faturali = true;
                    guncel.Faturasiz = false;
                    guncel.Kdv = kdvbul;
                    guncel.Kazanc = kazanc;
                }
                else if (radioFaturasiz.Checked)
                {
                    kdv = 0;
                    kazanc = kuryeucreti - kuryehakedis;
                    guncel.Faturali = false;
                    guncel.Faturasiz = true;
                    guncel.Kdv = kdvbul;
                    guncel.Kazanc = kazanc;
                }
                btnKaydet.Text = "GÜNCELLE";
            }

        }

        private void comboKuryeAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                string harf = e.KeyChar.ToString().ToUpper();

                for (int i = 0; i < comboKuryeAdi.Items.Count; i++)
                {
                    if (comboKuryeAdi.Items[i].ToString().StartsWith(harf))
                    {
                        comboKuryeAdi.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void gridKayitEkrani_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                gridKayitEkrani.CurrentCell = gridKayitEkrani.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(gridKayitEkrani, Location);
            }
        }

        private void gridKayitEkrani_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == gridKayitEkrani.Columns["KuryeAd"].Index)
            {
                object renk = e.Value;
                if (renk == null || renk == DBNull.Value || string.IsNullOrEmpty(renk.ToString()))

                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LimeGreen;
                }
            }

            if (e.ColumnIndex == gridKayitEkrani.Columns["MusteriAd"].Index)
            {
                object musteri = e.Value;
                if (musteri == null || musteri == DBNull.Value || string.IsNullOrEmpty(musteri.ToString()))

                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LimeGreen;
                }
            }
            if (e.ColumnIndex == gridKayitEkrani.Columns["TeslimAdresi"].Index)
            {
                object teslimedilecekadresi = e.Value;
                if (teslimedilecekadresi == null || teslimedilecekadresi == DBNull.Value || string.IsNullOrEmpty(teslimedilecekadresi.ToString()))

                {
                    e.CellStyle.BackColor = Color.Red;

                }
                else
                {
                    e.CellStyle.BackColor = Color.LimeGreen;
                }
            }
            if (e.ColumnIndex == gridKayitEkrani.Columns["TeslimEdilenKisi"].Index)
            {
                object teslimalan = e.Value;
                if (teslimalan == null || teslimalan == DBNull.Value || string.IsNullOrEmpty(teslimalan.ToString()))
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                }
            }
            if (e.ColumnIndex == gridKayitEkrani.Columns["Cari"].Index && e.Value!=null)
            {
                bool caridurum = (bool)e.Value;
                if (caridurum)
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.Yellow;
                    e.Value = "EVET";
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.Yellow;
                    e.Value = "HAYIR";
                }
            }

        }

        private void comboMusteriAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            adresgetir();
        }

        private void txtKuryeHakEdis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtKuryeUcreti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void radioCari_CheckedChanged(object sender, EventArgs e)
        {
            if(radioCari.Checked) 
            {
                radioBende.Checked = true;            
            }
        }

        private void radioBende_CheckedChanged(object sender, EventArgs e)
        {
            if(radioBende.Checked)
            {
                radioCari.Checked = true;
            }
        }

        private void radioNakit_CheckedChanged(object sender, EventArgs e)
        {
            if(radioNakit.Checked)
            {
                radioKuryede.Checked = true;
            }
        }

        private void radioKuryede_CheckedChanged(object sender, EventArgs e)
        {
            if(radioKuryede.Checked)
            {
                radioNakit.Checked = true;
            }
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            Form_MusteriEkle musteri = new Form_MusteriEkle();
            this.Hide();
            musteri.ShowDialog();
        }

        private void btnKuryeEkle_Click(object sender, EventArgs e)
        {
            Form_KuryePersoneli_Ekle perconel = new Form_KuryePersoneli_Ekle();
            this.Hide();
            perconel.ShowDialog();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTahsilatlarim_Click(object sender, EventArgs e)
        {
            Form_Tahsilatlarim tahsilat = new Form_Tahsilatlarim();
            this.Hide();
            tahsilat.ShowDialog();
        }

        private void btnRaporlama_Click(object sender, EventArgs e)
        {
            Form_Raporlama rapor = new Form_Raporlama();
            this.Hide();
            rapor.ShowDialog();
        }
        private void buistamam()
        {
            //SADECE KAYIT EKRANINDA TOPLAM 1000 SATIRA ULAŞAN KOD BLOĞUNUN SONUNDA PROJEMİZ SONA ERMİŞTİR.
            //TAMAMEN SADECE KENDİ EMEĞİM İLE YAPTIĞIM BU PROJEYİ KULLANANLARA HAYIRLI OLSUN DEMEK İSTERİM.
            //PROJENİN FİYATINI KAFAMDAN 10.000 TÜRK LİRASI OLARAK BELİRLEDİM.
            //UMARIM MÜŞTERİLERE SATABİLİRİM BİR İŞE YARAR 
            //SATAMAZSAMDA BABAM KULLANIR
            //İYİ GÜNLER...
        }    }
}
