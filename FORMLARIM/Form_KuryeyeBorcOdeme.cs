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
    public partial class Form_KuryeyeBorcOdeme : Form
    {
        public Form_KuryeyeBorcOdeme()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities veri = new KuryePeraVeriTabaniEntities();
        private void ComboFiltreleme()
        {
            comboKuryeAd.AutoCompleteMode=AutoCompleteMode.Suggest;
            comboKuryeAd.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void KuryeGetir()
        {
            var kuryegetir = veri.KuryeOdemeTablosu.Where(x => x.KuryeAdi != null).OrderBy(x => x.KuryeAdi).ToList();
            comboKuryeAd.ValueMember = "Id";
            comboKuryeAd.DisplayMember = "KuryeAdi";
            comboKuryeAd.DataSource = kuryegetir;
            comboKuryeAd.SelectedIndex = -1;
        }
        private void Temizle()
        {
            comboKuryeAd.Text = "";
            txtKuryeBedeliOdeme.Text = "";
            txtKuryeBorcEkle.Text = "";
            txtKuryeTelefonNo.Text = "";
            lblKuryeyeOlanBorc.Visible = false;
        }
        private void btnKuryeAra_Click(object sender, EventArgs e)
        {
            lblKuryeyeOlanBorc.Visible = true;
            if(comboKuryeAd != null && comboKuryeAd.SelectedIndex != -1)
            {
                int kuryeid=(int)comboKuryeAd.SelectedValue;
                var kuryeyeolanborcodeme = veri.KuryeOdemeTablosu.FirstOrDefault(X => X.Id == kuryeid);
                if (kuryeyeolanborcodeme != null)
                {
                    txtKuryeTelefonNo.Text = kuryeyeolanborcodeme.KuryeTelefonNumarasi;
                    txtKuryeBorcEkle.Text = Convert.ToDouble(kuryeyeolanborcodeme.KuryeyeOlanBorc).ToString();
                    lblKuryeyeOlanBorc.Text=Convert.ToDouble(kuryeyeolanborcodeme.KuryeyeOlanBorc).ToString("C2");
                    txtKuryeBedeliOdeme.Focus();
                }
            }
        }

        private void Form_KuryeyeBorcOdeme_Load(object sender, EventArgs e)
        {
            lblKuryeyeOlanBorc.Visible = false;
            ComboFiltreleme();
            KuryeGetir();
        }

        private void txtKuryeBedeliOdeme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnBorcEkle_Click(object sender, EventArgs e)
        {
            if (comboKuryeAd.SelectedIndex != -1 && comboKuryeAd.Items != null)
            {
                int kuryeid = (int)comboKuryeAd.SelectedValue;
                var kuryeyeode=veri.KuryeOdemeTablosu.FirstOrDefault(x=>x.Id == kuryeid);
                if (kuryeyeode != null)
                {
                    if (string.IsNullOrEmpty(txtKuryeBedeliOdeme.Text))
                    {
                        MessageBox.Show("LÜTFEN BORÇ EKLE KISMINI BOŞ BIRAKMAYINIZ.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    double eklenentutar=Convert.ToDouble(txtKuryeBedeliOdeme.Text);
                    double mevcutborc = Convert.ToDouble(kuryeyeode.KuryeyeOlanBorc);
                    double yeniborc = mevcutborc + eklenentutar;
                    kuryeyeode.KuryeyeOlanBorc = yeniborc;
                    veri.SaveChanges();
                    MessageBox.Show("TEBRİKLER KURYEYE OLAN BORCUNUZ GÜNCELLENMİŞTİR.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKuryeBorcEkle.Text=yeniborc.ToString();
                    lblKuryeyeOlanBorc.Text=yeniborc.ToString("C2");
                    txtKuryeBedeliOdeme.Text = "";
                    txtKuryeBedeliOdeme.Focus();
                    Form_KuryeTahsilat tahsilat = new Form_KuryeTahsilat();
                    this.Hide();
                    tahsilat.ShowDialog();

                }
            }
        }
    }
}
