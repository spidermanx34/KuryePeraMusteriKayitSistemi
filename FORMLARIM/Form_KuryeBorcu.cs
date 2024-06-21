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
    public partial class Form_KuryeBorcu : Form
    {
        public Form_KuryeBorcu()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities veri = new KuryePeraVeriTabaniEntities();
        private void ComboFiltreleme()
        {
            comboKuryeAd.AutoCompleteMode=AutoCompleteMode.Suggest;
            comboKuryeAd.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ComboyaMusteriGetir()
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
            txtGuncelBorc.Text = "";
            txtKuryeBorcEkle.Text = "";
            lblguncelborc.Text = "0.00";
        }
        private void txtKuryeTelefonNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtKuryeBorcEkle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            lblguncelborc.Visible = true;
            if(comboKuryeAd.SelectedIndex!=-1 && comboKuryeAd.Items != null)
            {
                int kuryeid = (int)comboKuryeAd.SelectedValue;
                var kuryeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x=>x.Id == kuryeid);
                if(kuryeodeme!= null)
                {
                    txtGuncelBorc.Text = kuryeodeme.KuryeToplamBorc.ToString();
                    lblguncelborc.Text =Convert.ToDouble(kuryeodeme.KuryeToplamBorc).ToString("C2");
                    txtKuryeBorcEkle.Focus();
                }
            }
        }

        private void Form_KuryeBorcu_Load(object sender, EventArgs e)
        {
            lblguncelborc.Visible = false;
            ComboyaMusteriGetir();
            ComboFiltreleme();           
        }

        private void btnBorcEkle_Click(object sender, EventArgs e)
        {
            if(comboKuryeAd.SelectedIndex != -1 && comboKuryeAd.Items!=null) 
            {
                int kuryeid=(int)comboKuryeAd.SelectedValue;
                var kuryeodeme = veri.KuryeOdemeTablosu.FirstOrDefault(x => x.Id == kuryeid);
                if(kuryeodeme!= null)
                {
                    if (string.IsNullOrEmpty(txtKuryeBorcEkle.Text))
                    {
                        MessageBox.Show("Lütfen Borç Ekle Kısmını Boş Bırakmayınız.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    double eklenentutar = Convert.ToDouble(txtKuryeBorcEkle.Text);
                    double mevcutborc = Convert.ToDouble(kuryeodeme.KuryeToplamBorc);
                    double yeniborc = mevcutborc + eklenentutar;
                    kuryeodeme.KuryeToplamBorc = yeniborc;
                    veri.SaveChanges();
                    MessageBox.Show("TEBRİKLER KURYE BORCU GÜNCELLENMİŞTİR.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGuncelBorc.Text = kuryeodeme.KuryeToplamBorc.ToString();
                    lblguncelborc.Text =Convert.ToDouble(kuryeodeme.KuryeToplamBorc).ToString("C2");
                    txtKuryeBorcEkle.Text = "";
                    txtKuryeBorcEkle.Focus();
                    Form_KuryeTahsilat tahsilat = new Form_KuryeTahsilat();
                    this.Hide();
                    tahsilat.ShowDialog();

                }

            }
        }
    }
}
