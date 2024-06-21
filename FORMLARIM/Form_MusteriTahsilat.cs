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
    public partial class Form_MusteriTahsilat : Form
    {
        public Form_MusteriTahsilat()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities veri = new KuryePeraVeriTabaniEntities();
        private void musterigetir()
        {
            var musterigetir = veri.MusteriTablosu.Where(x => x.AdsoyadUnvan != null).OrderBy(x => x.AdsoyadUnvan).ToList();
            comboMusteri.ValueMember = "Id";
            comboMusteri.DisplayMember = "AdsoyadUnvan";
            comboMusteri.DataSource = musterigetir;
            comboMusteri.SelectedIndex = -1;
        }
        private void btnBorcEkle_Click(object sender, EventArgs e)
        {
            Form_MusteriBorcEkle borc = new Form_MusteriBorcEkle();
            this.Hide();
            borc.ShowDialog();
          
        }
        private void gridGetir()
        {
            var getir = veri.MusteriOdemeTablosu.ToList();
            GridMusteriTahsilat.DataSource = getir;
            GridMusteriTahsilat.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void GridDuzenle()
        {
            GridMusteriTahsilat.Columns["Id"].Visible = false;
            GridMusteriTahsilat.Columns["KayitTablosuId"].Visible = false;
            GridMusteriTahsilat.Columns["MusteriAdi"].HeaderText = "MÜŞTERİ ADI";
            GridMusteriTahsilat.Columns["OdemeDurumu"].Visible = false;
            GridMusteriTahsilat.Columns["MusteriToplamBorc"].HeaderText = "MÜŞTERİ BORCU";
            GridMusteriTahsilat.Columns["MusteriToplamBorc"].DefaultCellStyle.Format = "C2";
            GridMusteriTahsilat.Columns["MusteriTelefon"].HeaderText = "MÜŞTERİ TEL NO";
            GridMusteriTahsilat.RowHeadersVisible = false;
            GridMusteriTahsilat.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }
        private void combofiltreleme()
        {
            comboMusteri.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboMusteri.AutoCompleteSource = AutoCompleteSource.ListItems;      
        }
        private void temizle()
        {
            txtMusteriAdSoyad.Text = "";
            txtMusteriTelNo.Text= "";
            txtMusteriToplamBorc.Text = "";
            txtTahsilEdilenTutar.Text = "";
            checckVar.Checked = false;
            chechkYok.Checked = false;
            lblToplamBorc.Visible = false;
        }
        private void Form_MusteriTahsilat_Load(object sender, EventArgs e)
        {
            musterigetir();
            gridGetir();
            GridDuzenle();
            combofiltreleme();
            lblToplamBorc.Visible = false;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            lblToplamBorc.Visible = false; ;
            if (comboMusteri.SelectedIndex != -1 && comboMusteri.Items != null)
            {
                int musteriid = (int)comboMusteri.SelectedValue;
                var musteriodeme = veri.MusteriOdemeTablosu.FirstOrDefault(x=>x.Id == musteriid);              
                if (musteriodeme != null)
                {
                    string addsoyad = musteriodeme.MusteriAdi;
                    string telefonnumarasi = musteriodeme.MusteriTelefon;
                    double borc = Convert.ToDouble(musteriodeme.MusteriToplamBorc);
                    txtMusteriAdSoyad.Text = addsoyad;
                    txtMusteriTelNo.Text = telefonnumarasi;
                    txtMusteriToplamBorc.Text = borc.ToString();
                    txtMusteriToplamBorc.BackColor = borc > 0 ? Color.Red : Color.Green;
                    lblToplamBorc.Text=borc.ToString("C2");
                    if (borc>0)
                    {
                        checckVar.Checked = true;
                        chechkYok.Checked= false;
                        txtTahsilEdilenTutar.Focus();

                    }
                    else
                    {
                        chechkYok.Checked = true;
                        checckVar.Checked = false;

                    }
                }
                else
                {
                    txtMusteriAdSoyad.Text = "";
                    txtMusteriTelNo.Text = "";
                    txtMusteriToplamBorc.Text = "";
                }
             
             
            }
        }

        private void btnTahsilEt_Click(object sender, EventArgs e)
        {
            lblToplamBorc.Visible = true;
            if(comboMusteri.SelectedIndex!=-1 && comboMusteri.Items != null)
            {
                //seçilen müşterinin İD sini alıyoruz.
                int musterid = (int)comboMusteri.SelectedValue;

                //müşteri ödeme tablosundan ilgili müşteriye ait ödeme bilgilerini alıyoruz.
                var musteriodeme = veri.MusteriOdemeTablosu.FirstOrDefault(x=>x.Id==musterid);
                if(musteriodeme != null && checckVar.Checked==true && chechkYok.Checked==false)
                {
                    if (string.IsNullOrEmpty(txtTahsilEdilenTutar.Text))
                    {
                        MessageBox.Show("Lütfen Tahsil Edilecek Tutarı Boş Bırakmayınız.","HATA",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Tahsil Edilen Tutar
                    double tahsiledilentutar = Convert.ToDouble(txtTahsilEdilenTutar.Text);
                    //Müşterinin Mevcut Borcu

                    double mevcutborc = Convert.ToDouble(txtMusteriToplamBorc.Text);
                    //Yeni Borç Miktarı
                    double yeniborc = mevcutborc - tahsiledilentutar;

                    //BORCU GÜNCELLE
                    musteriodeme.MusteriToplamBorc = yeniborc;
                    veri.SaveChanges();
                    MessageBox.Show("TEBRİKLER MÜŞTERİNİN BORÇ BİLGİLERİ GÜNCELLENMİŞTİR.","TEBRİKLER",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTahsilEdilenTutar.Text = "";
                    txtMusteriToplamBorc.Text = yeniborc.ToString();
                    lblToplamBorc.Text=yeniborc.ToString("c2");
                    if (yeniborc > 0)
                    {
                        checckVar.Checked = true;
                        chechkYok.Checked = false;
                    }
                    else
                    {
                        chechkYok.Checked = true;
                        checckVar.Checked = false;
                    }
                    gridGetir();
                }
                else
                {
                    MessageBox.Show("MÜŞTERİ BİLGİLERİ BULUNAMADI", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void btnRaporAl_Click(object sender, EventArgs e)
        {
            gridGetir();
            GridDuzenle();
            temizle();

        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GridMusteriTahsilat.SelectedRows != null && GridMusteriTahsilat.SelectedRows.Count > 0)
            {
                DialogResult cevap = MessageBox.Show("SEÇİLİ KAYIT SİLİNECEK.\nONAYLIYOR MUSUNUZ ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    int sil = Convert.ToInt16(GridMusteriTahsilat.SelectedRows[0].Cells[0].Value);
                    var secilisil = veri.MusteriOdemeTablosu.FirstOrDefault(x => x.Id == sil);
                    if (secilisil != null)
                    {
                        veri.MusteriOdemeTablosu.Remove(secilisil);
                        veri.SaveChanges();
                        MessageBox.Show("TEBRİKLER KAYIT SİLİNMİŞTİR.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridGetir();
                    }
                    else
                    {
                        MessageBox.Show("KAYIT BULUNAMADI.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kayıt seçin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void GridMusteriTahsilat_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                GridMusteriTahsilat.CurrentCell = GridMusteriTahsilat.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(GridMusteriTahsilat, Location);
            }
        }

        private void txtTahsilEdilenTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
