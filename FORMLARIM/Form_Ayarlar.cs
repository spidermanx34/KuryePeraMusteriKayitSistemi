using KuryePera.CLASSLARIM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryePera.FORMLARIM
{
    public partial class Form_Ayarlar : Form
    {
        public Form_Ayarlar()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities pera = new KuryePeraVeriTabaniEntities();
        private void gridgetir()
        {
            var getir = pera.KullaniciTablosu.ToList();
            datagridkullanici.DataSource = getir;
            datagridkullanici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var getire = pera.KullaniciTablosu.ToList();
            gridyetki.DataSource = getire;
            gridyetki.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void GridYetkiDuzenleme()
        {
            gridyetki.RowHeadersVisible = false;
            gridyetki.Columns["Id"].Visible = false;
            gridyetki.Columns["Kullaniciadi"].Visible = true;
            gridyetki.Columns["Sifre"].Visible = false;
            gridyetki.Columns["isimsoyisim"].Visible = false;
            gridyetki.Columns["E_Posta"].Visible = false;
            gridyetki.Columns["TcKimlikNo"].Visible = false;
            gridyetki.Columns["KullaniciFotograf"].Visible = false;
            gridyetki.Columns["TelefonNumarasi"].Visible = false;
            gridyetki.Columns["DogumYeri"].Visible = false;
            gridyetki.Columns["DogumTarihi"].Visible = false;
            gridyetki.Columns["KayitEkle"].Visible = true;
            gridyetki.Columns["MusteriEkle"].Visible = true;
            gridyetki.Columns["KuryeEkle"].Visible = true;
            gridyetki.Columns["Ayarlar"].Visible = true;
            gridyetki.Columns["KullaniciDegistir"].Visible = true;
            gridyetki.Columns["Tahsilatlar"].Visible = true;
            gridyetki.Columns["Raporlama"].Visible = true;
            gridyetki.Columns["KullaniciEkle"].Visible = true;
            gridyetki.Columns["Kullaniciadi"].HeaderText = "KULLANICI ADI";
            gridyetki.Columns["KayitEkle"].HeaderText = "KAYIT EKLE";
            gridyetki.Columns["MusteriEkle"].HeaderText = "MÜŞTERİ EKLE";
            gridyetki.Columns["KuryeEkle"].HeaderText = "KURYE EKLE";
            gridyetki.Columns["Ayarlar"].HeaderText = "AYARLAR";
            gridyetki.Columns["KullaniciDegistir"].HeaderText = "KULLANICI DEĞİŞTİR";
            gridyetki.Columns["Tahsilatlar"].HeaderText = "TAHSİLATLAR";
            gridyetki.Columns["Raporlama"].HeaderText = "RAPORLAMA";
            gridyetki.Columns["KullaniciEkle"].HeaderText = "KULLANICI EKLE";
        }
        private void GridKullaniciBilgileri()
        {
            datagridkullanici.RowHeadersVisible = false;
            datagridkullanici.Columns["Id"].Visible = false;
            datagridkullanici.Columns["KayitEkle"].Visible = false;
            datagridkullanici.Columns["MusteriEkle"].Visible = false;
            datagridkullanici.Columns["KuryeEkle"].Visible = false;
            datagridkullanici.Columns["Ayarlar"].Visible = false;
            datagridkullanici.Columns["KullaniciDegistir"].Visible = false;
            datagridkullanici.Columns["Tahsilatlar"].Visible = false;
            datagridkullanici.Columns["Raporlama"].Visible = false;
            datagridkullanici.Columns["KullaniciEkle"].Visible = false;
            datagridkullanici.Columns["Kullaniciadi"].Visible = false;
            datagridkullanici.Columns["Sifre"].Visible = false;
            datagridkullanici.Columns["TcKimlikNo"].Visible = false;
            datagridkullanici.Columns["DogumYeri"].Visible = false;
            datagridkullanici.Columns["KullaniciFotograf"].Visible = false;
            datagridkullanici.Columns["isimsoyisim"].HeaderText = "AD SOYAD";
            datagridkullanici.Columns["E_Posta"].Visible = false;
            datagridkullanici.Columns["DogumTarihi"].Visible = false;
            datagridkullanici.Columns["TelefonNumarasi"].Visible = false;
        }
        private void btnYEDEKLE_Click(object sender, EventArgs e)
        {
            Backup.yedekleme();
        }
        private void Form_Ayarlar_Load(object sender, EventArgs e)
        {
            gridgetir();
            GridYetkiDuzenleme();
            GridKullaniciBilgileri();
            lblkullanici.Text = Gecis.CurrentUsername;
        }

        private void datagridkullanici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagridkullanici.Rows.Count > 0)
            {
                int secilen = datagridkullanici.SelectedCells[0].RowIndex;
                txtkullaniciadsoyad.Text = datagridkullanici.Rows[secilen].Cells[3].Value.ToString();
                txtkullanicidogumtarihi.Text = datagridkullanici.Rows[secilen].Cells[9].Value.ToString();
                txtkullanicieposta.Text = datagridkullanici.Rows[secilen].Cells[4].Value.ToString();
                txtkullanicitelefonno.Text = datagridkullanici.Rows[secilen].Cells[7].Value.ToString();
                pictureFotograf.ImageLocation = datagridkullanici.Rows[secilen].Cells[6].Value.ToString();
            }
        }

        private void btnYedektenYukleme_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\ProgramRestore.exe");
            Application.Exit();
        }

        private void btnYetkiVer_Click(object sender, EventArgs e)
        {
            if (gridyetki.Rows.Count > 0)
            {
                if (pera.KullaniciTablosu.Any(x => x.Kullaniciadi == lblkullaniciadi.Text))
                {
                    var yetkiduzenle = pera.KullaniciTablosu.Where(x => x.Kullaniciadi == lblkullaniciadi.Text).FirstOrDefault();
                    if (checkKayitEkle.Checked == false) //KAYIT EKLE
                    {
                        checkKayitEkle.Checked = false;
                        yetkiduzenle.KayitEkle = false;
                        pera.SaveChanges();
                        gridgetir();
                    }
                    else if (checkKayitEkle.Checked == true)
                    {
                        checkKayitEkle.Checked = true;
                        yetkiduzenle.KayitEkle = true;
                        pera.SaveChanges();
                        gridgetir();
                    }
                    //MÜŞTERİ EKLE
                    if (checkMusteriEkle.Checked == false)
                    {
                        checkMusteriEkle.Checked = false;
                        yetkiduzenle.MusteriEkle = false;
                        pera.SaveChanges(); gridgetir();
                    }
                    else if (checkMusteriEkle.Checked == true)
                    {
                        checkMusteriEkle.Checked = true;
                        yetkiduzenle.MusteriEkle = true;
                        pera.SaveChanges(); gridgetir();
                    }

                    //KURYE EKLE
                    if (checkKuryeEkle.Checked == false)
                    {
                        checkKuryeEkle.Checked = false;
                        yetkiduzenle.KuryeEkle = false;
                        pera.SaveChanges(); gridgetir();
                    }
                    else if (checkKuryeEkle.Checked == true)
                    {
                        checkKuryeEkle.Checked = true;
                        yetkiduzenle.KuryeEkle = true;
                        pera.SaveChanges(); gridgetir();
                    }
                    //TAHSİLATLARIM
                    if (checkTahsilatlarim.Checked == false)
                    {
                        checkTahsilatlarim.Checked = false;
                        yetkiduzenle.Tahsilatlar = false;
                        pera.SaveChanges(); gridgetir();

                    }
                    else if (checkTahsilatlarim.Checked == true)
                    {
                        checkTahsilatlarim.Checked = true;
                        yetkiduzenle.Tahsilatlar = true;
                        pera.SaveChanges(); gridgetir();
                    }
                    //AYARLAR
                    if (checkAyarlar.Checked == false)
                    {
                        checkAyarlar.Checked = false;
                        yetkiduzenle.Ayarlar = false;
                        pera.SaveChanges(); gridgetir();
                    }
                    else if (checkAyarlar.Checked == true)
                    {
                        checkAyarlar.Checked = true;
                        yetkiduzenle.Ayarlar = true;
                        pera.SaveChanges(); gridgetir();
                    }
                    //RAPORLAMA
                    if (checkRaporlama.Checked == false)
                    {
                        checkRaporlama.Checked = false;
                        yetkiduzenle.Raporlama = false;
                        pera.SaveChanges(); gridgetir();
                    }
                    else if (checkRaporlama.Checked == true)
                    {
                        checkRaporlama.Checked = true;
                        yetkiduzenle.Raporlama = true;
                        pera.SaveChanges(); gridgetir();
                    }
                    //KULLANICI EKLE
                    if (checkKullaniciEkle.Checked == false)
                    {
                        checkKullaniciEkle.Checked = false;
                        yetkiduzenle.KullaniciEkle = false;
                        pera.SaveChanges(); gridgetir();
                    }
                    else if (checkKullaniciEkle.Checked == true)
                    {
                        checkKullaniciEkle.Checked = true;
                        yetkiduzenle.KullaniciEkle = true;
                        pera.SaveChanges(); gridgetir();
                    }
                    //KULLANICI DEĞİŞTİR
                    if (checkKullaniciDegistir.Checked == false)
                    {
                        checkKullaniciDegistir.Checked = false;
                        yetkiduzenle.KullaniciDegistir = false;
                        pera.SaveChanges(); gridgetir();
                    }
                    else if (checkKullaniciDegistir.Checked == true)
                    {
                        checkKullaniciDegistir.Checked = true;
                        yetkiduzenle.KullaniciDegistir = true;
                        pera.SaveChanges(); gridgetir();
                    }
                    MessageBox.Show("KULLANICIYA SEÇTİĞİNİZ YETKİLER VERİLMİŞTİR.", "BİLGİLENDİRME MESAJI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("KULLANICI BULUNAMADI.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void gridyetki_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridyetki.Rows.Count > 0)
            {
                int secilen = gridyetki.SelectedCells[0].RowIndex;
                lblkullaniciadi.Text = gridyetki.Rows[secilen].Cells[1].Value?.ToString() ?? ""; // Eğer değer null ise, boş bir string atar
                checkKayitEkle.Checked = (bool)(gridyetki.Rows[secilen].Cells[10].Value ?? false); // Eğer değer null ise, false olarak kabul edilir
                checkMusteriEkle.Checked = (bool)(gridyetki.Rows[secilen].Cells[11].Value ?? false); // Eğer değer null ise, false olarak kabul edilir
                checkAyarlar.Checked = (bool)(gridyetki.Rows[secilen].Cells[13].Value ?? false); // Eğer değer null ise, false olarak kabul edilir
                checkKuryeEkle.Checked = (bool)(gridyetki.Rows[secilen].Cells[12].Value ?? false); // Eğer değer null ise, false olarak kabul edilir
                checkKullaniciDegistir.Checked = (bool)(gridyetki.Rows[secilen].Cells[14].Value ?? false); // Eğer değer null ise, false olarak kabul edilir
                checkTahsilatlarim.Checked = (bool)(gridyetki.Rows[secilen].Cells[15].Value ?? false); // Eğer değer null ise, false olarak kabul edilir
                checkRaporlama.Checked = (bool)(gridyetki.Rows[secilen].Cells[16].Value ?? false); // Eğer değer null ise, false olarak kabul edilir
                checkKullaniciEkle.Checked = (bool)(gridyetki.Rows[secilen].Cells[17].Value ?? false);
            }
        }

        private void gridyetki_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 10 && e.ColumnIndex <= 17 && e.RowIndex >= 0 && gridyetki.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                // True/false değeri metinle değiştirme
                bool value = (bool)gridyetki.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                e.Value = value ? "YETKİLİ" : "YETKİSİZ";
            }
            if (e.ColumnIndex >= 10 && e.ColumnIndex <= 17 && e.RowIndex >= 0 && gridyetki.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bool value = (bool)gridyetki.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (value)
                {
                    e.CellStyle.BackColor = Color.Green; // True ise yeşil
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red; // False ise kırmızı
                }
            }
        }
    }
}
