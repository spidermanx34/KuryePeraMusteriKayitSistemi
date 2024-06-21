using KuryePera.FORMLARIM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KuryePera
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnstandart8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKayitEkle_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_KayitEkle kayit = new Form_KayitEkle();
            kayit.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnMusteriAdresleri_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_MusteriEkle musteri = new Form_MusteriEkle();
            musteri.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnVergilerim_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_KuryePersoneli_Ekle kurye = new Form_KuryePersoneli_Ekle();
            kurye.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnstandart3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_Tahsilatlarim tahsilat = new Form_Tahsilatlarim();
            tahsilat.ShowDialog();
            Cursor.Current = Cursors.Default;

        }

        private void btnstandart4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_Ayarlar ayarlar= new Form_Ayarlar();
            ayarlar.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnstandart5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_Raporlama rapor = new Form_Raporlama();
            rapor.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_KullaniciEkle kullanici = new Form_KullaniciEkle
                ();
            kullanici.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnKullaniciDegistir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_KullaniciDegistir degisim = new Form_KullaniciDegistir();
            this.Hide();
            degisim.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
