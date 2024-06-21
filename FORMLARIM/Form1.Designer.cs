namespace KuryePera
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblKullanici = new System.Windows.Forms.Label();
            this.btnKayitEkle = new KuryePera.btnstandart();
            this.btnMusteriAdresleri = new KuryePera.btnstandart();
            this.btnTahsilatlat = new KuryePera.btnstandart();
            this.btnAyarlar = new KuryePera.btnstandart();
            this.btnRaporlama = new KuryePera.btnstandart();
            this.btnKullaniciEkle = new KuryePera.btnstandart();
            this.btnKullaniciDegistir = new KuryePera.btnstandart();
            this.btnExit = new KuryePera.btnstandart();
            this.btnKuryeEkle = new KuryePera.btnstandart();
            this.SuspendLayout();
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.Font = new System.Drawing.Font("Arial Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullanici.ForeColor = System.Drawing.Color.Red;
            this.lblKullanici.Location = new System.Drawing.Point(9, 297);
            this.lblKullanici.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(88, 31);
            this.lblKullanici.TabIndex = 18;
            this.lblKullanici.Text = "label1";
            // 
            // btnKayitEkle
            // 
            this.btnKayitEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnKayitEkle.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitEkle.ForeColor = System.Drawing.Color.Red;
            this.btnKayitEkle.Image = global::KuryePera.Properties.Resources.KAYIT_EKLE_64;
            this.btnKayitEkle.Location = new System.Drawing.Point(-2, -1);
            this.btnKayitEkle.Margin = new System.Windows.Forms.Padding(0);
            this.btnKayitEkle.Name = "btnKayitEkle";
            this.btnKayitEkle.Size = new System.Drawing.Size(190, 99);
            this.btnKayitEkle.TabIndex = 9;
            this.btnKayitEkle.Text = "KAYIT EKLE";
            this.btnKayitEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKayitEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKayitEkle.UseVisualStyleBackColor = false;
            this.btnKayitEkle.Click += new System.EventHandler(this.btnKayitEkle_Click);
            // 
            // btnMusteriAdresleri
            // 
            this.btnMusteriAdresleri.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMusteriAdresleri.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteriAdresleri.ForeColor = System.Drawing.Color.Yellow;
            this.btnMusteriAdresleri.Image = global::KuryePera.Properties.Resources.personel_ekle_64;
            this.btnMusteriAdresleri.Location = new System.Drawing.Point(185, -1);
            this.btnMusteriAdresleri.Margin = new System.Windows.Forms.Padding(0);
            this.btnMusteriAdresleri.Name = "btnMusteriAdresleri";
            this.btnMusteriAdresleri.Size = new System.Drawing.Size(190, 99);
            this.btnMusteriAdresleri.TabIndex = 10;
            this.btnMusteriAdresleri.Text = "MÜŞTERİ EKLE ";
            this.btnMusteriAdresleri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMusteriAdresleri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMusteriAdresleri.UseVisualStyleBackColor = false;
            this.btnMusteriAdresleri.Click += new System.EventHandler(this.btnMusteriAdresleri_Click);
            // 
            // btnTahsilatlat
            // 
            this.btnTahsilatlat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTahsilatlat.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTahsilatlat.ForeColor = System.Drawing.Color.Magenta;
            this.btnTahsilatlat.Image = global::KuryePera.Properties.Resources.TAHSİLAT_64;
            this.btnTahsilatlat.Location = new System.Drawing.Point(-2, 94);
            this.btnTahsilatlat.Margin = new System.Windows.Forms.Padding(0);
            this.btnTahsilatlat.Name = "btnTahsilatlat";
            this.btnTahsilatlat.Size = new System.Drawing.Size(190, 99);
            this.btnTahsilatlat.TabIndex = 11;
            this.btnTahsilatlat.Text = "TAHSİLATLARIM";
            this.btnTahsilatlat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTahsilatlat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTahsilatlat.UseVisualStyleBackColor = false;
            this.btnTahsilatlat.Click += new System.EventHandler(this.btnstandart3_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAyarlar.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyarlar.ForeColor = System.Drawing.Color.Green;
            this.btnAyarlar.Image = global::KuryePera.Properties.Resources.ayarlar_64;
            this.btnAyarlar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAyarlar.Location = new System.Drawing.Point(185, 94);
            this.btnAyarlar.Margin = new System.Windows.Forms.Padding(0);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(190, 99);
            this.btnAyarlar.TabIndex = 12;
            this.btnAyarlar.Text = "AYARLAR ";
            this.btnAyarlar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAyarlar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new System.EventHandler(this.btnstandart4_Click);
            // 
            // btnRaporlama
            // 
            this.btnRaporlama.BackColor = System.Drawing.Color.Maroon;
            this.btnRaporlama.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporlama.ForeColor = System.Drawing.Color.Aqua;
            this.btnRaporlama.Image = global::KuryePera.Properties.Resources.rapor_64;
            this.btnRaporlama.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRaporlama.Location = new System.Drawing.Point(373, 94);
            this.btnRaporlama.Margin = new System.Windows.Forms.Padding(0);
            this.btnRaporlama.Name = "btnRaporlama";
            this.btnRaporlama.Size = new System.Drawing.Size(192, 99);
            this.btnRaporlama.TabIndex = 13;
            this.btnRaporlama.Text = "RAPORLAMA ";
            this.btnRaporlama.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRaporlama.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRaporlama.UseVisualStyleBackColor = false;
            this.btnRaporlama.Click += new System.EventHandler(this.btnstandart5_Click);
            // 
            // btnKullaniciEkle
            // 
            this.btnKullaniciEkle.BackColor = System.Drawing.Color.Blue;
            this.btnKullaniciEkle.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciEkle.ForeColor = System.Drawing.Color.YellowGreen;
            this.btnKullaniciEkle.Image = global::KuryePera.Properties.Resources.user_ekle_64;
            this.btnKullaniciEkle.Location = new System.Drawing.Point(-2, 189);
            this.btnKullaniciEkle.Margin = new System.Windows.Forms.Padding(0);
            this.btnKullaniciEkle.Name = "btnKullaniciEkle";
            this.btnKullaniciEkle.Size = new System.Drawing.Size(190, 100);
            this.btnKullaniciEkle.TabIndex = 14;
            this.btnKullaniciEkle.Text = "KULLANICI EKLE ";
            this.btnKullaniciEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKullaniciEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKullaniciEkle.UseVisualStyleBackColor = false;
            this.btnKullaniciEkle.Click += new System.EventHandler(this.btnKullaniciEkle_Click);
            // 
            // btnKullaniciDegistir
            // 
            this.btnKullaniciDegistir.BackColor = System.Drawing.Color.Lime;
            this.btnKullaniciDegistir.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciDegistir.ForeColor = System.Drawing.Color.Black;
            this.btnKullaniciDegistir.Image = global::KuryePera.Properties.Resources.kullanıcı_değiştir_64;
            this.btnKullaniciDegistir.Location = new System.Drawing.Point(185, 189);
            this.btnKullaniciDegistir.Margin = new System.Windows.Forms.Padding(0);
            this.btnKullaniciDegistir.Name = "btnKullaniciDegistir";
            this.btnKullaniciDegistir.Size = new System.Drawing.Size(190, 100);
            this.btnKullaniciDegistir.TabIndex = 15;
            this.btnKullaniciDegistir.Text = "KULLANICI DEĞİŞTİR";
            this.btnKullaniciDegistir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKullaniciDegistir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKullaniciDegistir.UseVisualStyleBackColor = false;
            this.btnKullaniciDegistir.Click += new System.EventHandler(this.btnKullaniciDegistir_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.ForeColor = System.Drawing.Color.Lime;
            this.btnExit.Image = global::KuryePera.Properties.Resources.exit_64;
            this.btnExit.Location = new System.Drawing.Point(373, 189);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(192, 100);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "ÇIKIŞ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnstandart8_Click);
            // 
            // btnKuryeEkle
            // 
            this.btnKuryeEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnKuryeEkle.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKuryeEkle.ForeColor = System.Drawing.Color.Blue;
            this.btnKuryeEkle.Image = global::KuryePera.Properties.Resources.müşteri_ekle_64;
            this.btnKuryeEkle.Location = new System.Drawing.Point(373, -1);
            this.btnKuryeEkle.Margin = new System.Windows.Forms.Padding(0);
            this.btnKuryeEkle.Name = "btnKuryeEkle";
            this.btnKuryeEkle.Size = new System.Drawing.Size(192, 99);
            this.btnKuryeEkle.TabIndex = 17;
            this.btnKuryeEkle.Text = "KURYE EKLE";
            this.btnKuryeEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKuryeEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKuryeEkle.UseVisualStyleBackColor = false;
            this.btnKuryeEkle.Click += new System.EventHandler(this.btnVergilerim_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(563, 344);
            this.Controls.Add(this.lblKullanici);
            this.Controls.Add(this.btnKayitEkle);
            this.Controls.Add(this.btnMusteriAdresleri);
            this.Controls.Add(this.btnTahsilatlat);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnRaporlama);
            this.Controls.Add(this.btnKullaniciEkle);
            this.Controls.Add(this.btnKullaniciDegistir);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnKuryeEkle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(579, 383);
            this.MinimumSize = new System.Drawing.Size(579, 383);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KURYEPERA BAŞLANGIÇ EKRANI ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal btnstandart btnKayitEkle;
        internal btnstandart btnMusteriAdresleri;
        internal btnstandart btnTahsilatlat;
        internal btnstandart btnAyarlar;
        internal btnstandart btnRaporlama;
        internal btnstandart btnKullaniciEkle;
        internal btnstandart btnKullaniciDegistir;
        internal btnstandart btnExit;
        internal btnstandart btnKuryeEkle;
        internal System.Windows.Forms.Label lblKullanici;
    }
}

