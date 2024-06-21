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
    public partial class Form_KullaniciDegistir : Form
    {
        public Form_KullaniciDegistir()
        {
            InitializeComponent();
        }    
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string kullaniciadi = txtKullaniciAdi.Text;
            string sifre=txtSifre.Text;
            if (txtKullaniciAdi.Text != "" && txtSifre.Text != "")
            {
                try
                {
                    using (var db = new KuryePeraVeriTabaniEntities())
                    {
                        if (db.KullaniciTablosu.Any())
                        {
                            var bak = db.KullaniciTablosu.Where(x => x.Kullaniciadi == kullaniciadi && x.Sifre == sifre).FirstOrDefault();
                            if (bak != null)
                            {
                                Gecis.CurrentUsername = bak.Kullaniciadi;
                                Cursor.Current = Cursors.WaitCursor;
                                Form1 form = new Form1();
                                form.btnKayitEkle.Enabled = (bool)bak.KayitEkle;
                                form.btnMusteriAdresleri.Enabled = (bool)bak.MusteriEkle;
                                form.btnKuryeEkle.Enabled = (bool)bak.KuryeEkle;
                                form.btnTahsilatlat.Enabled = (bool)bak.Tahsilatlar;
                                form.btnAyarlar.Enabled= (bool)bak.Ayarlar;
                                form.btnRaporlama.Enabled=(bool)bak.Raporlama;
                                form.btnKullaniciDegistir.Enabled = (bool)bak.KullaniciDegistir;
                                form.btnKullaniciEkle.Enabled=(bool)bak.KullaniciEkle;
                                form.lblKullanici.Text = bak.Kullaniciadi;
                                MessageBox.Show("TEBRİKLER GİRİŞ YAPILIYOR.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                form.ShowDialog();
                                Cursor.Current= Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("KULLANICI ADI VEYA ŞİFRE HATALI","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }             
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Adını veya Şifreyi Boş Bırakmayınız.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);  
            }
    
        }
    }
}
