using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryePera.FORMLARIM
{
    public partial class Form_KuryeTahsilat : Form
    {
        public Form_KuryeTahsilat()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities veri = new KuryePeraVeriTabaniEntities();
        private void comboboxkuryegetir()
        {
            var kuryegetir = veri.PersonelTablosu.Where(x => x.KuryeAdiSoyadi != null).OrderBy(x => x.KuryeAdiSoyadi).ToList();
            comboKuryeBul.ValueMember = "Id";
            comboKuryeBul.DisplayMember = "KuryeAdiSoyadi";
            comboKuryeBul.DataSource = kuryegetir;
            comboKuryeBul.SelectedIndex = -1;
        }
        private void combofiltreleme()
        {
            comboKuryeBul.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboKuryeBul.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void GridGetir()
        {
            GridKuryeBorcBilgileri.DataSource = veri.KuryeOdemeTablosu.ToList();
            GridKuryeBorcBilgileri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void GridDuzenle()
        {
            GridKuryeBorcBilgileri.RowHeadersVisible = false;
            GridKuryeBorcBilgileri.Columns["Id"].Visible = false;
            GridKuryeBorcBilgileri.Columns["KuryeAdi"].HeaderText = "KURYE ADI";
            GridKuryeBorcBilgileri.Columns["KuryeTelefonNumarasi"].HeaderText = "KURYE TEL NO";
            GridKuryeBorcBilgileri.Columns["KuryeyeOlanBorc"].HeaderText = "ŞİRKETİN KURYEYE ÖDEMESİ";
            GridKuryeBorcBilgileri.Columns["KuryeyeOlanBorc"].DefaultCellStyle.Format = "C2";
            GridKuryeBorcBilgileri.Columns["KuryeToplamBorc"].HeaderText = "KURYENİN ŞİRKETE ÖDEMESİ";
            GridKuryeBorcBilgileri.Columns["KayitTablosuId"].Visible = false;
            GridKuryeBorcBilgileri.Columns["KuryeToplamBorc"].DefaultCellStyle.Format = "C2";
        }
        private void temizleTahsilat()
        {

            foreach (Control c in Controls )
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }

            /* ne kadar textbox varsa foreach ile temizlenir. 100 tane textbox olursa 100 tane kod yazmana gerek yok   */


            //txtKuryeAdSoyad.Text = "";
            //txtKuryeTelNo.Text = "";
            //txtKuryeToplamBorc.Text = "";
            //txtKuryeyeOdenecekUcret.Text = "";
            checkKuryeBorcuVar.Checked = false;
            checkKuryeBorcuYok.Checked = false;
            comboKuryeBul.Text = "";
            lblToplamBorc.Text = "";
            lblKuryeyeOdenecekUcret.Text = "";
        }
        private string C2ToNormal(string c2FormattedValue)
        {
            // C2 formatında biçimlendirilmiş bir metni sayıya dönüştürme
            decimal numberInC2Format;
            if (decimal.TryParse(c2FormattedValue, NumberStyles.Currency, CultureInfo.GetCultureInfo("tr-TR"), out numberInC2Format))
            {
                // Sayıyı normal formatta bir string olarak geri döndürme
                return numberInC2Format.ToString();
            }
            else
            {
                // Eğer dönüşüm başarısız olursa, boş bir string döndürme veya hata işleme
                return ""; // veya bir hata mesajı döndürebilirsiniz
            }
        }
        private void btnBorcEkle_Click(object sender, EventArgs e)
        {
            Form_KuryeBorcu kuryeborc = new Form_KuryeBorcu();
            this.Hide();
            kuryeborc.ShowDialog();
        }

        private void btnKuryeyeBorcEkle_Click(object sender, EventArgs e)
        {
            Form_KuryeyeBorcOdeme kuryeyeolanborc = new Form_KuryeyeBorcOdeme();
            this.Hide();
            kuryeyeolanborc.ShowDialog();
        }

        private void Form_KuryeTahsilat_Load(object sender, EventArgs e)
        {
            GridGetir();
            GridDuzenle();
            comboboxkuryegetir();
            combofiltreleme();
            lblToplamBorc.Visible = false;
            lblKuryeyeOdenecekUcret.Visible = false;
        }

        private void btnKuryeAra_Click(object sender, EventArgs e)
        {
            lblToplamBorc.Visible = false;
            lblKuryeyeOdenecekUcret.Visible = false;
            if (comboKuryeBul.SelectedIndex != -1 && comboKuryeBul.Items != null)
            {
                int kuryeid = (int)comboKuryeBul.SelectedValue;
                var kuryeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.Id == kuryeid);
                if (kuryeodeme != null)
                {
                    string kuryeadi = kuryeodeme.KuryeAdi;
                    string telno = kuryeodeme.KuryeTelefonNumarasi;
                    double kuryeyeolanborc = Convert.ToDouble(kuryeodeme.KuryeyeOlanBorc);
                    double kuryetoplamborc = Convert.ToDouble(kuryeodeme.KuryeToplamBorc);
                    txtKuryeAdSoyad.Text = kuryeadi;
                    txtKuryeTelNo.Text = telno;
                    txtKuryeToplamBorc.Text = kuryetoplamborc.ToString();
                    txtKuryeToplamBorc.BackColor= kuryetoplamborc>0 ? Color.Red : Color.Green;
                    txtKuryeyeOdenecekUcret.Text = kuryeyeolanborc.ToString();
                    txtKuryeyeOdenecekUcret.BackColor=kuryeyeolanborc>0? Color.Red : Color.Green;
                    if (kuryetoplamborc > 0)
                    {
                        checkKuryeBorcuVar.Checked = true;
                        checkKuryeBorcuYok.Checked = false;
                        txtTahsilEdilenTutar.Focus();
                    }
                    else
                    {
                        checkKuryeBorcuVar.Checked = false;
                        checkKuryeBorcuYok.Checked = true;
                    }


                }
                else
                {
                    txtKuryeAdSoyad.Text = "";
                    txtKuryeTelNo.Text = "";
                    txtKuryeToplamBorc.Text = "";
                    txtKuryeyeOdenecekUcret.Text = "";
                }
                if(Convert.ToDouble(txtKuryeToplamBorc.Text) > Convert.ToDouble(txtKuryeyeOdenecekUcret.Text))
                {
                    KuryeOdemeTablosu kurye = new KuryeOdemeTablosu();
                    var kuryeeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.Id == kuryeid);
                    double kuryeborc = Convert.ToInt32(txtKuryeToplamBorc.Text);
                    double bababorcu = Convert.ToInt32(txtKuryeyeOdenecekUcret.Text);
                    double kalan = kuryeborc - bababorcu;
                    kuryeeodeme.KuryeToplamBorc = kalan;
                    kuryeeodeme.KuryeyeOlanBorc = 0;
                    veri.SaveChanges();
                    datagridYenile();

                }
                else if (Convert.ToDouble(txtKuryeyeOdenecekUcret.Text) > Convert.ToDouble(txtKuryeToplamBorc.Text))
                {                  
                    var kuryeeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x=>x.Id== kuryeid);
                    double kuryeborc = Convert.ToDouble(txtKuryeToplamBorc.Text);
                    double bababorcu = Convert.ToDouble(txtKuryeyeOdenecekUcret.Text);
                    double kalan = bababorcu-kuryeborc;
                    kuryeeodeme.KuryeyeOlanBorc= kalan;
                    kuryeeodeme.KuryeToplamBorc= 0;
                    veri.SaveChanges();
                    datagridYenile();

                }
                else if (Convert.ToDouble(txtKuryeyeOdenecekUcret.Text) == Convert.ToDouble(txtKuryeToplamBorc.Text))
                {
                    var kuryeeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.Id == kuryeid);
                    kuryeeodeme.KuryeyeOlanBorc = 0;
                    kuryeeodeme.KuryeToplamBorc = 0;
                    veri.SaveChanges();
                    datagridYenile();
                }
            }
        }

        private void checkKuryeBorcuVar_CheckedChanged(object sender, EventArgs e)
        {
            txtKuryeTahsilatOde.Enabled = false;
            if (checkKuryeBorcuVar.Checked == false)
            {
                txtKuryeTahsilatOde.Enabled = true;
            }
        }

        private void txtTahsilEdilenTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtKuryeTahsilatOde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTahsilEt_Click(object sender, EventArgs e)
        {
            lblToplamBorc.Visible = true;
            lblKuryeyeOdenecekUcret.Visible = true;
            if (comboKuryeBul.SelectedIndex != -1 && comboKuryeBul.Items != null)
            {
                int kuryeid = (int)comboKuryeBul.SelectedValue;
                var kuryeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.Id == kuryeid);
                if (kuryeodeme != null && checkKuryeBorcuVar.Checked == true && checkKuryeBorcuYok.Checked == false)
                {
                    double tahsiledilentutar = Convert.ToDouble(txtTahsilEdilenTutar.Text);
                    double mevcutborc = Convert.ToDouble(txtKuryeToplamBorc.Text);
                    double kalan = mevcutborc - tahsiledilentutar;
                    kuryeodeme.KuryeToplamBorc = kalan;
                    veri.SaveChanges();
                    MessageBox.Show("TEBRİKLER BORÇ TAHSİL EDİLMİŞTİR.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTahsilEdilenTutar.Text = "";
                    txtKuryeToplamBorc.Text = kalan.ToString();
                    lblToplamBorc.Text = kalan.ToString("C2");
                    if (kalan > 0)
                    {
                        checkKuryeBorcuVar.Checked = true;
                        checkKuryeBorcuYok.Checked = false;
                    }
                    else
                    {
                        checkKuryeBorcuYok.Checked = true;
                        checkKuryeBorcuVar.Checked = false;
                    }
                    GridGetir();

                }
                else
                {
                    MessageBox.Show("ÜZGÜNÜM , KURYE veya BORÇ BULUNAMADI.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GridGetir();
            GridDuzenle();
            temizleTahsilat();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GridKuryeBorcBilgileri.SelectedRows.Count>10000000)
            {
                DialogResult cevap = MessageBox.Show("SEÇİLİ KAYIT SİLİNECEK BUNU ONAYLIYOR MUSUNUZ ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    int sil = (int)GridKuryeBorcBilgileri.CurrentRow.Cells[0].Value;// biliyoruz ki 0. index value değeri mutlak olarak int türünderir bu yüzden convert yerine cast edebiliriz
                    var secilisil = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.Id == sil);
                    if (secilisil != null)
                    {
                        veri.KuryeOdemeTablosu.Remove(secilisil);
                        veri.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("ÜZGÜNÜM KAYIT BULUNAMADI.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }              
            }
            else
            {
                MessageBox.Show("SİLME İŞLEMİNİ KAYIT EKRANINDAN YAPINIZ.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GridGetir();
        }

        private void GridKuryeBorcBilgileri_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                GridKuryeBorcBilgileri.CurrentCell = GridKuryeBorcBilgileri.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(GridKuryeBorcBilgileri, Location);
            }
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            if (comboKuryeBul.SelectedIndex != -1 && comboKuryeBul.Items.Count != 0)
            {
                if (string.IsNullOrEmpty(txtKuryeTahsilatOde.Text))
                {
                    MessageBox.Show("Lütfen Kuryeye Ödenecek Ücreti Boş Bırakmayınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int kuryeid = (int)comboKuryeBul.SelectedValue;
                var kuryeyeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.Id == kuryeid);
                if (kuryeyeodeme != null && checkvarKuryeyeOlanBorc.Checked == true && checkyokKuryeyeOlanBorc.Checked == false)
                {
                    double kuryeyeodenentutar = Convert.ToDouble(txtKuryeTahsilatOde.Text);
                    double mevcutborc = 0;
                    try
                    {
                        mevcutborc = Convert.ToDouble(txtKuryeyeOdenecekUcret.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ŞİRKETİN KURYEYE BORCU YOKTUR.", "HATA MESAJI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    double guncelborc = mevcutborc - kuryeyeodenentutar;
                    kuryeyeodeme.KuryeyeOlanBorc = guncelborc;
                    veri.SaveChanges();
                    MessageBox.Show("TEBRİKLER ŞİRKET BORCU GÜNCELLENMİŞTİR.", "BİLGİLENDİRME MESAJI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKuryeyeOdenecekUcret.Text = guncelborc.ToString("C2");
                    txtKuryeTahsilatOde.Text = "";
                    lblKuryeyeOdenecekUcret.Text = guncelborc.ToString("C2");
                    GridGetir();

                }
            }
        }
        private void datagridYenile()
        {
            using (var context = new KuryePeraVeriTabaniEntities())
            {
                 var kuryeodemelistesi=context.KuryeOdemeTablosu.ToList();
                GridKuryeBorcBilgileri.DataSource = kuryeodemelistesi;
            }
        }
    }
}
