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
    public partial class Form_MusteriEkle : Form
    {
        public Form_MusteriEkle()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities pera = new KuryePeraVeriTabaniEntities();
        private void gridgetir()
        {
            var getir = pera.MusteriTablosu.ToList();
            dataGridMusteriEkle.DataSource = getir;
            dataGridMusteriEkle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void gridduzenle()
        {
            dataGridMusteriEkle.Columns["Id"].Visible = false;
            dataGridMusteriEkle.RowHeadersVisible = false;
            dataGridMusteriEkle.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridMusteriEkle.Columns["AdsoyadUnvan"].HeaderText = "Müşteri Adı veya UNVAN";
            dataGridMusteriEkle.Columns["MusteriTelefon"].HeaderText = "Müşteri Telefon Numarası";
            dataGridMusteriEkle.Columns["MusteriAdres"].HeaderText = "Müşteri Adresi";
            dataGridMusteriEkle.Columns["MusteriEposta"].HeaderText = "Müşteri E-Posta";
            dataGridMusteriEkle.Columns["MusteriVergiNo"].HeaderText = "Müşteri Vergi Numarası";
            dataGridMusteriEkle.Columns["YetkiliKisi"].HeaderText = "Yetkili Kişi";
            dataGridMusteriEkle.Columns["Tarih"].HeaderText = "TARİH";
            dataGridMusteriEkle.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMusteriEkle.DefaultCellStyle.SelectionBackColor = Color.DarkMagenta;
        }
        private void temizle()
        {
            txtMusteriAd.Clear();
            txtMusteriAdresi.Clear();
            txtMusteriEPosta.Clear();
            txtMusteriVergiNo.Clear();
            txtYetkiliKisi.Clear();
            MaskedMusteriTelefonu.Clear();
        }
       
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text != "GÜNCELLE")
            {
                string musteriadveyaunvan = txtMusteriAd.Text.ToUpper();
                string musteritelno = MaskedMusteriTelefonu.Text;
                string musteriadresi = txtMusteriAdresi.Text;
                string musteriepostasi = txtMusteriEPosta.Text;
                string musteriverginumarasi = txtMusteriVergiNo.Text;
                string yetkilikisi = txtYetkiliKisi.Text.ToUpper();
                bool aynisimusteri = pera.MusteriTablosu.Any(x => x.AdsoyadUnvan == musteriadveyaunvan);
                if (aynisimusteri)
                {
                    MessageBox.Show("Aynı İsimden Müşteri Mevcut Lütfen İsmi Farklı Giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMusteriAd.Text = "";
                    txtMusteriAd.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtMusteriAd.Text))
                {
                    MessageBox.Show("Lütfen Müşteri Adını Boş Bırakmayınız.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                if (string.IsNullOrEmpty(MaskedMusteriTelefonu.Text))
                {
                    MessageBox.Show("Lütfen Müşterinin Telefon Numarasını Boş Bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtMusteriAdresi.Text))
                {
                    MessageBox.Show("Lütfen Müşterinin Adresini Boş Bırakmayınız.","UYARI",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtYetkiliKisi.Text))
                {
                    MessageBox.Show("Lütfen Firmanın Yetkili Kişisini Boş Bırakmayınız.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                DateTime tarih = datetimeMusteriEkleme.Value;

                MusteriTablosu musteri = new MusteriTablosu();
                musteri.AdsoyadUnvan = musteriadveyaunvan;
                musteri.MusteriTelefon = musteritelno;
                musteri.MusteriAdres = musteriadresi;
                musteri.MusteriEposta = musteriepostasi;
                musteri.MusteriVergiNo = musteriverginumarasi;
                musteri.YetkiliKisi = yetkilikisi;
                musteri.Tarih = tarih;
                pera.MusteriTablosu.Add(musteri);
                pera.SaveChanges();
                MessageBox.Show("TEBRİKLER MÜŞTERİ KAYIT EDİLMİŞTİR.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gridgetir();
                gridduzenle();
                temizle();
            }
           else
            {


                int guncelleme = Convert.ToInt32(dataGridMusteriEkle.CurrentRow.Cells[0].Value);
                var guncel = pera.MusteriTablosu.FirstOrDefault(x=>x.Id == guncelleme);
                guncel.AdsoyadUnvan = txtMusteriAd.Text;
                guncel.MusteriTelefon = MaskedMusteriTelefonu.Text;
                guncel.MusteriAdres = txtMusteriAdresi.Text;
                guncel.MusteriEposta = txtMusteriEPosta.Text;
                guncel.MusteriVergiNo=txtMusteriVergiNo.Text;
                guncel.YetkiliKisi = txtYetkiliKisi.Text;
                guncel.Tarih = datetimeMusteriEkleme.Value;
                btnKaydet.Text = "KAYDET";
                pera.SaveChanges();
                MessageBox.Show("TEBRİKLER İŞLEMİNİZ GÜNCELLENMİŞTİR.","TEBRİKLER",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gridgetir();
                gridduzenle();
                temizle();
            
            }


        }

        private void Form_MusteriEkle_Load(object sender, EventArgs e)
        {
            gridgetir();
            gridduzenle();
            lblkullanici.Text = Gecis.CurrentUsername;
        }

        private void dataGridMusteriEkle_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridMusteriEkle.CurrentCell = dataGridMusteriEkle.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(dataGridMusteriEkle, e.Location);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
                if (dataGridMusteriEkle.SelectedRows.Count>0)
                {
                    DialogResult cevap = MessageBox.Show("Seçili İşlem Silinecek \n ONAYLIYOR MUSUNUZ ???", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        int secilisil = Convert.ToInt32(dataGridMusteriEkle.CurrentRow.Cells[0].Value);
                        var sil = pera.MusteriTablosu.FirstOrDefault(x => x.Id == secilisil);
                        pera.MusteriTablosu.Remove(sil);
                        pera.SaveChanges();
                        gridgetir();
                    gridduzenle();
                    }
                }
       }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridMusteriEkle.SelectedRows.Count > 0)
            {
                DialogResult cevap = MessageBox.Show("Seçili İşlem Silinecek \n ONAYLIYOR MUSUNUZ ???", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(cevap == DialogResult.Yes)
                {
                    int secilenisil = Convert.ToInt32(dataGridMusteriEkle.CurrentRow.Cells[0].Value);
                    var sil = pera.MusteriTablosu.FirstOrDefault(x => x.Id == secilenisil);
                    pera.MusteriTablosu.Remove(sil);
                    pera.SaveChanges();
                    gridgetir();
                    gridduzenle();
                }
            }
        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridMusteriEkle.SelectedRows.Count > 0)
            {
                int guncelleme = Convert.ToInt32(dataGridMusteriEkle.CurrentRow.Cells[0].Value);
                var guncel = pera.MusteriTablosu.FirstOrDefault(x=>x.Id == guncelleme);
                txtMusteriAd.Text = guncel.AdsoyadUnvan;
                MaskedMusteriTelefonu.Text = guncel.MusteriTelefon;
                txtMusteriAdresi.Text = guncel.MusteriAdres;
                txtMusteriEPosta.Text = guncel.MusteriEposta;
                txtMusteriVergiNo.Text = guncel.MusteriVergiNo;
                txtYetkiliKisi.Text = guncel.YetkiliKisi;
                datetimeMusteriEkleme.Value = Convert.ToDateTime(guncel.Tarih);
                btnKaydet.Text = "GÜNCELLE";
            }
        }



        private void txtMusteriVergiNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                
            {
                e.Handled = true;
            }
            if(txtMusteriVergiNo.Text.Length>=11 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
