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
    public partial class Form_MusteriBorcEkle : Form
    {
        public Form_MusteriBorcEkle()
        {
            InitializeComponent();
        }
        KuryePeraVeriTabaniEntities veri = new KuryePeraVeriTabaniEntities();
        private void ComboMusteriGetir()
        {
            var musterigetir = veri.MusteriTablosu.Where(x => x.AdsoyadUnvan != null).OrderBy(x => x.AdsoyadUnvan).ToList();
            comboMusteriAd.ValueMember = "Id";
            comboMusteriAd.DisplayMember = "AdsoyadUnvan";
            comboMusteriAd.DataSource = musterigetir;
            comboMusteriAd.SelectedIndex = -1;
        }
        private void combofiltreleme()
        {
            comboMusteriAd.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboMusteriAd.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Form_MusteriBorcEkle_Load(object sender, EventArgs e)
        {
            lblguncelborc.Visible = false;
            ComboMusteriGetir();
            combofiltreleme();
  
        }
  

        private void btnBorcEkle_Click(object sender, EventArgs e)
        {
            lblguncelborc.Visible = true;
            if(comboMusteriAd.SelectedIndex!=-1 && comboMusteriAd.Items != null)
            {
                int musterid = (int)comboMusteriAd.SelectedValue;
                var musteriodeme = veri.MusteriOdemeTablosu.FirstOrDefault(x=>x.Id== musterid);
                if(musteriodeme!= null)
                {
                    if (string.IsNullOrEmpty(txtBorcEkle.Text))
                    {
                        MessageBox.Show("Lütfen BORÇ Ekleyeceğiniz Tutarı Boş Bırakmayınız.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    double eklenentutar=Convert.ToDouble(txtBorcEkle.Text);
                    double mevcutborc=Convert.ToDouble(musteriodeme.MusteriToplamBorc);
                    double yeniborc = mevcutborc + eklenentutar;
                    musteriodeme.MusteriToplamBorc = yeniborc;
                    veri.SaveChanges();
                    MessageBox.Show("BORÇ BAŞARIYLA EKLENMİŞTİR.","TEBRİKLER",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMusterininGuncelBorcu.Text = musteriodeme.MusteriToplamBorc.ToString();
                    lblguncelborc.Text = Convert.ToDouble(musteriodeme.MusteriToplamBorc).ToString("C2");
                    txtBorcEkle.Text = "";
                    txtBorcEkle.Focus();
                    Form_MusteriTahsilat tahsilatform = new Form_MusteriTahsilat();
                    this.Hide();
                    tahsilatform.ShowDialog();
                 
                }
            }
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            lblguncelborc.Visible = true;
            if (comboMusteriAd.SelectedIndex != -1 && comboMusteriAd.Items != null)
            {
                int musterid = (int)comboMusteriAd.SelectedValue;
                var musteriodeme = veri.MusteriOdemeTablosu.FirstOrDefault(x => x.Id == musterid);
                if (musteriodeme != null)
                {
                    txtMusterininGuncelBorcu.Text = musteriodeme.MusteriToplamBorc.ToString();
                    lblguncelborc.Text = Convert.ToDouble(musteriodeme.MusteriToplamBorc).ToString("C2");
                    txtBorcEkle.Focus();

                }
            }
        }
    }
}
