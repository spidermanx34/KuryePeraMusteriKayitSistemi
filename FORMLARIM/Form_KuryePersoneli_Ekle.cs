using KuryePera.CLASSLARIM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryePera.FORMLARIM
{
    public partial class Form_KuryePersoneli_Ekle : Form
    {
        public Form_KuryePersoneli_Ekle()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities pera = new KuryePeraVeriTabaniEntities();
        private void gridgetir()
        {
            var getir = pera.PersonelTablosu.ToList();
            gridpersonel.DataSource = getir;
            gridpersonel.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void gridduzenle()
        {
            gridpersonel.Columns["Id"].Visible = false;
            gridpersonel.Columns["KuryeAdiSoyadi"].HeaderText = "PERSONEL ADI ve SOYADI";
            gridpersonel.Columns["KuryeTelefonNumarasi"].HeaderText = "PERSONEL TELEFON NUMARASI";
            gridpersonel.Columns["KuryeMotorPlakasi"].HeaderText = "ARAÇ PLAKASI";
            gridpersonel.Columns["Tarih"].HeaderText = "PERSONEL EKLENME TARİHİ";
            gridpersonel.RowHeadersVisible = false;
            gridpersonel.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }
        private void temizle()
        {
            txtKkuryeMotorPlaka.Clear();
            txtKuryeAdiveSoyadi.Clear();
            maskedKuryeTelNo.Clear();

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
       
            if (btnKaydet.Text != "GÜNCELLE")
            {
                string kuryeadsoyad = txtKuryeAdiveSoyadi.Text.ToUpper();
                string kuryetelno = maskedKuryeTelNo.Text;
                string kuryeplaka = txtKkuryeMotorPlaka.Text.ToUpper();
                bool kuryepersonelvarmi=pera.PersonelTablosu.Any(x=>x.KuryeAdiSoyadi==kuryeadsoyad);
                if (kuryepersonelvarmi)
                {
                    MessageBox.Show("Aynı Kurye Adında bir Kurye Mevcut Lütfen Farklı Bir İsim Giriniz.","HATA",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKuryeAdiveSoyadi.Text = "";
                    txtKuryeAdiveSoyadi.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtKuryeAdiveSoyadi.Text))
                {
                    MessageBox.Show("LÜTFEN KURYE ADINI GİRİNİZ.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                if (string.IsNullOrEmpty(maskedKuryeTelNo.Text))
                {
                    MessageBox.Show("LÜTFEN KURYENİN TELEFON NUMARASINI GİRİNİZ.","UYARI",MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }              

                PersonelTablosu perconel = new PersonelTablosu();
                perconel.KuryeAdiSoyadi = kuryeadsoyad;
                perconel.KuryeTelefonNumarasi = kuryetelno;
                perconel.KuryeMotorPlakasi = kuryeplaka;
                perconel.Tarih = datetimeKuryePersoneli.Value;
                pera.PersonelTablosu.Add(perconel);
                pera.SaveChanges();
                MessageBox.Show("TEBRİKLER PERSONEL KAYIT EDİLMİŞTİR.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridgetir();
                gridduzenle();
                temizle();
            }
            else
            {
               
                int guncel = Convert.ToInt32(gridpersonel.CurrentRow.Cells[0].Value);
                var guncelle = pera.PersonelTablosu.FirstOrDefault(X => X.Id == guncel);
                guncelle.KuryeAdiSoyadi = txtKuryeAdiveSoyadi.Text;
                guncelle.KuryeMotorPlakasi = txtKkuryeMotorPlaka.Text;
                guncelle.KuryeTelefonNumarasi = maskedKuryeTelNo.Text;
                guncelle.Tarih = Convert.ToDateTime(datetimeKuryePersoneli.Value);
                btnKaydet.Text = "KAYDET";
                pera.SaveChanges();
                MessageBox.Show("TEBRİKLER GÜNCELLEME İŞLEMİNİZ BAŞARILI.","TEBRİKLER",MessageBoxButtons.OK,MessageBoxIcon.Information);
                gridgetir();
                gridduzenle();
            }

        }

        private void Form_KuryePersoneli_Ekle_Load(object sender, EventArgs e)
        {
            gridgetir();
            gridduzenle();
            lblkullanici.Text = Gecis.CurrentUsername;
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridpersonel.SelectedRows.Count > 0)
            { DialogResult cevap = MessageBox.Show("SEÇİLİ İŞLEM SİLİNECEKTİR.\nONAYLIYOR MUSUNUZ ???","UYARI",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                int secilisil = Convert.ToInt32(gridpersonel.CurrentRow.Cells[0].Value);
                var sil = pera.PersonelTablosu.FirstOrDefault(x => x.Id == secilisil);
                pera.PersonelTablosu.Remove(sil);
                pera.SaveChanges();
                MessageBox.Show("TEBRİKLER SİLME İŞLEMİNİZ BAŞARILI.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridgetir();
                gridduzenle();
            }          
            }        
        }

        private void gridpersonel_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                gridpersonel.CurrentCell = gridpersonel.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(gridpersonel, e.Location);
            }
        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridpersonel.Rows.Count > 0)
            {

                int guncel = Convert.ToInt32(gridpersonel.CurrentRow.Cells[0].Value);
                var guncelle = pera.PersonelTablosu.FirstOrDefault(x => x.Id == guncel);
                txtKkuryeMotorPlaka.Text = guncelle.KuryeMotorPlakasi;
                txtKuryeAdiveSoyadi.Text = guncelle.KuryeAdiSoyadi;
                maskedKuryeTelNo.Text = guncelle.KuryeTelefonNumarasi;
                datetimeKuryePersoneli.Value =Convert.ToDateTime(guncelle.Tarih);
                btnKaydet.Text = "GÜNCELLE";
              
            }
            
        }
    }
}
