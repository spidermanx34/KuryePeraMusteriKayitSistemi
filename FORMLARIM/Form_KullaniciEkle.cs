using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryePera.FORMLARIM
{
    public partial class Form_KullaniciEkle : Form
    {
        public Form_KullaniciEkle()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities pera = new KuryePeraVeriTabaniEntities();
        private void btnresimekle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureKullaniciFotograf.ImageLocation = openFileDialog1.FileName;
            txtResim.Text = openFileDialog1.FileName;
        }
        private void gridgetir()
        {
            var getir = pera.KullaniciTablosu.ToList();
            gridkullaniciekleme.DataSource = getir;
            gridkullaniciekleme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void temizle()
        {
            txtKullaniciAd.Text = "";
            txtSifre.Text = "";
            txtSifreTekrar.Text = "";
            txtAdSoyad.Text = "";
            txtDogumTarihi.Text = "";
            txtDogumYeri.Text = "";
            txtEposta.Text = "";
            txtTc.Text = "";
            txtResim.Text = "";
            txtTelNo.Text = "";
            pictureKullaniciFotograf.Image = null;
        }
        private void GridDuzenle()
        {
            gridkullaniciekleme.Columns["Id"].Visible = false;
            gridkullaniciekleme.RowHeadersVisible = false;
            gridkullaniciekleme.Columns["KullaniciAdi"].HeaderText = "KULLANICI ADI";
            gridkullaniciekleme.Columns["Sifre"].HeaderText = "ŞİFRE";
            gridkullaniciekleme.Columns["isimsoyisim"].HeaderText = "AD SOYAD";
            gridkullaniciekleme.Columns["E_Posta"].HeaderText = "E-MAİL";
            gridkullaniciekleme.Columns["TcKimlikNo"].HeaderText = "T.C.";
            gridkullaniciekleme.Columns["KullaniciFotograf"].HeaderText = "FOTOĞRAF";
            gridkullaniciekleme.Columns["TelefonNumarasi"].HeaderText = "TEL NO";
            gridkullaniciekleme.Columns["DogumYeri"].HeaderText = "DOĞUM YERİ";
            gridkullaniciekleme.Columns["DogumTarihi"].HeaderText = "DOĞUM TARİHİ";
            gridkullaniciekleme.Columns["KayitEkle"].Visible = false;
            gridkullaniciekleme.Columns["MusteriEkle"].Visible = false;
            gridkullaniciekleme.Columns["KuryeEkle"].Visible = false;
            gridkullaniciekleme.Columns["Ayarlar"].Visible = false;
            gridkullaniciekleme.Columns["KullaniciDegistir"].Visible = false;
            gridkullaniciekleme.Columns["Tahsilatlar"].Visible = false;
            gridkullaniciekleme.Columns["Raporlama"].Visible = false;
            gridkullaniciekleme.Columns["KullaniciEkle"].Visible = false;
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (btnKullaniciEkle.Text== "KULLANICI EKLE\r\n")
            {
                KullaniciTablosu kullanici = new KullaniciTablosu();
                kullanici.Kullaniciadi = txtKullaniciAd.Text;
                if (txtSifreTekrar.Text == txtSifre.Text)
                {
                    kullanici.Sifre = txtSifreTekrar.Text;
                }
                else
                {
                    MessageBox.Show("ÜZGÜNÜM :( GİRDİĞİZ ŞİFRELER UYUŞMUYOR.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(txtAdSoyad.Text))
                {
                    MessageBox.Show("Lütfen İsim Soy İsimi Boş Bırakmayınız.","HATA",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                kullanici.isimsoyisim = txtAdSoyad.Text.ToUpper();
                kullanici.E_Posta = txtEposta.Text;
                kullanici.TcKimlikNo = txtTc.Text;
                kullanici.KullaniciFotograf = txtResim.Text;
                kullanici.TelefonNumarasi = txtTelNo.Text;
                kullanici.DogumYeri = txtDogumYeri.Text;
                kullanici.DogumTarihi = txtDogumTarihi.Text;
                pera.KullaniciTablosu.Add(kullanici);
                pera.SaveChanges();
                MessageBox.Show("TEBRİKLER KULLANICI EKLENMİŞTİR.", "BİLGİLENDİRME MESAJI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridgetir();
                temizle();
            }
            else if(btnKullaniciEkle.Text=="ŞİFRE DEĞİŞTİR")
            {
                int sifre = Convert.ToInt16(gridkullaniciekleme.CurrentRow.Cells[0].Value);
                var sifredegistir = pera.KullaniciTablosu.FirstOrDefault(x => x.Id == sifre);
                if (txtSifreTekrar.Text == txtSifre.Text)
                {
                    sifredegistir.Sifre = txtSifreTekrar.Text;
                }
                else
                {
                    MessageBox.Show("GİRDİĞİNİZ ŞİFRELER UYUŞMUYOR.","HATA",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
       
                btnKullaniciEkle.Text = "KULLANICI EKLE\r\n";
                pera.SaveChanges();
                MessageBox.Show("TEBRİKLER ŞİFRENİZ DEĞİŞMİŞTİR.","BİLGİLENDİRME",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtKullaniciAd.Enabled = true;
                txtDogumTarihi.Enabled = true;
                txtDogumYeri.Enabled = true;
                txtAdSoyad.Enabled = true;
                txtEposta.Enabled = true;
                txtResim.Enabled = true;
                txtTelNo.Enabled = true;
                txtTc.Enabled = true;
                gridgetir();
                temizle();
            }
            else
            {
               int guncel = Convert.ToInt16(gridkullaniciekleme.CurrentRow.Cells[0].Value);
                var secileniguncelle=pera.KullaniciTablosu.FirstOrDefault(x=>x.Id == guncel);
                secileniguncelle.isimsoyisim = txtAdSoyad.Text;
                secileniguncelle.E_Posta = txtEposta.Text;
                secileniguncelle.TcKimlikNo = txtTc.Text;
                secileniguncelle.KullaniciFotograf = txtResim.Text;
                secileniguncelle.TelefonNumarasi = txtTelNo.Text;
                secileniguncelle.DogumTarihi = txtDogumTarihi.Text;
                secileniguncelle.DogumYeri = txtDogumYeri.Text;
                btnKullaniciEkle.Text = "KULLANICI EKLE\r\n";
                pera.SaveChanges();
                MessageBox.Show("TEBRİKLER GÜNCELLEME İŞLEMİNİZ BAŞARIYLA KAYDEDİLMİŞTİR.","BİLGİLENDİRME",MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridgetir();
                GridDuzenle();
                temizle();
            
            }
     
        }

        private void Form_KullaniciEkle_Load(object sender, EventArgs e)
        {
            gridgetir();
            GridDuzenle();
        }

        private void gridkullaniciekleme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gridkullaniciekleme.Rows.Count > 0)
            {
                int secilen = gridkullaniciekleme.SelectedCells[0].RowIndex;
                txtKullaniciAd.Text = gridkullaniciekleme.Rows[secilen].Cells[1].Value.ToString();
                txtSifre.Text = gridkullaniciekleme.Rows[secilen].Cells[2].Value.ToString();
                txtSifreTekrar.Text = gridkullaniciekleme.Rows[secilen].Cells[2].Value.ToString();
                txtAdSoyad.Text = gridkullaniciekleme.Rows[secilen].Cells[3].Value.ToString();
                txtEposta.Text = gridkullaniciekleme.Rows[secilen].Cells[4].Value.ToString();
                txtTc.Text = gridkullaniciekleme.Rows[secilen].Cells[5].Value.ToString();
                txtResim.Text= gridkullaniciekleme.Rows[secilen].Cells[6].Value.ToString();
                txtTelNo.Text = gridkullaniciekleme.Rows[secilen].Cells[7].Value.ToString();
                txtDogumYeri.Text = gridkullaniciekleme.Rows[secilen].Cells[8].Value.ToString();
                txtDogumTarihi.Text = gridkullaniciekleme.Rows[secilen].Cells[9].Value.ToString();
                pictureKullaniciFotograf.ImageLocation = gridkullaniciekleme.Rows[secilen].Cells[6].Value.ToString();
            }
     
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("KULLANICI SİLİNECEKTİR.\nONAYLIYOR MUSUNUZ ????", "BİLGİLENDİRME MESAJI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                if (gridkullaniciekleme.Rows.Count > 0)
                {
                    int sil = Convert.ToInt16(gridkullaniciekleme.CurrentRow.Cells[0].Value);
                    var secilisil = pera.KullaniciTablosu.FirstOrDefault(x => x.Id == sil);
                    if (secilisil != null)
                    {
                        pera.KullaniciTablosu.Remove(secilisil);
                        pera.SaveChanges();
                        MessageBox.Show("KULLANICI SİLİNDİ.", "BİLGİLENDİRME MESAJI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridgetir();
                    }
                }
            }
           
           
        }

        private void gridkullaniciekleme_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right&& e.RowIndex>=0 && e.ColumnIndex>=0)
            {
                gridkullaniciekleme.CurrentCell = gridkullaniciekleme.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(gridkullaniciekleme, Location);
            }
        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridkullaniciekleme.Rows.Count > 0)
            {   
                int guncelle = Convert.ToInt16(gridkullaniciekleme.CurrentRow.Cells[0].Value);
                var seciliguncel = pera.KullaniciTablosu.FirstOrDefault(x => x.Id == guncelle);
                txtAdSoyad.Text = seciliguncel.isimsoyisim;
                txtEposta.Text = seciliguncel.E_Posta;
                txtTc.Text = seciliguncel.TcKimlikNo;
                txtResim.Text = seciliguncel.KullaniciFotograf;
                txtTelNo.Text = seciliguncel.TelefonNumarasi;
                txtDogumTarihi.Text = seciliguncel.DogumTarihi;
                txtDogumYeri.Text = seciliguncel.DogumYeri;
                btnKullaniciEkle.Text = "GÜNCELLE";
              
            }
         
        }

        private void şİFREDEĞİŞTİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridkullaniciekleme.Rows.Count > 0)
            {
                int sifre = Convert.ToInt16(gridkullaniciekleme.CurrentRow.Cells[0].Value);
                var sifredegistir=pera.KullaniciTablosu.FirstOrDefault(x=>x.Id==sifre);
                txtSifre.Text = sifredegistir.Sifre;
                txtSifreTekrar.Text = sifredegistir.Sifre;
                txtKullaniciAd.Enabled = false;
                txtDogumTarihi.Enabled = false;
                txtDogumYeri.Enabled = false;
                txtAdSoyad.Enabled = false;
                txtEposta.Enabled = false;
                txtResim.Enabled = false;
                txtTelNo.Enabled = false;
                txtTc.Enabled = false;              
                btnKullaniciEkle.Text = "ŞİFRE DEĞİŞTİR";
            }
        }
    }
}
