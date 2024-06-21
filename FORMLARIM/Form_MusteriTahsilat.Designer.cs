namespace KuryePera.FORMLARIM
{
    partial class Form_MusteriTahsilat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MusteriTahsilat));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboMusteri = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBorcEkle = new System.Windows.Forms.Button();
            this.btnRaporAl = new System.Windows.Forms.Button();
            this.btnTahsilEt = new System.Windows.Forms.Button();
            this.chechkYok = new System.Windows.Forms.CheckBox();
            this.checckVar = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTahsilEdilenTutar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblToplamBorc = new System.Windows.Forms.Label();
            this.txtMusteriToplamBorc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMusteriTelNo = new System.Windows.Forms.TextBox();
            this.txtMusteriAdSoyad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GridMusteriTahsilat = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sİLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridMusteriTahsilat)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboMusteri);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAra);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 413;
            this.splitContainer1.TabIndex = 0;
            // 
            // comboMusteri
            // 
            this.comboMusteri.FormattingEnabled = true;
            this.comboMusteri.Location = new System.Drawing.Point(118, 43);
            this.comboMusteri.Name = "comboMusteri";
            this.comboMusteri.Size = new System.Drawing.Size(190, 21);
            this.comboMusteri.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBorcEkle);
            this.groupBox2.Controls.Add(this.btnRaporAl);
            this.groupBox2.Controls.Add(this.btnTahsilEt);
            this.groupBox2.Controls.Add(this.chechkYok);
            this.groupBox2.Controls.Add(this.checckVar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtTahsilEdilenTutar);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(15, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 155);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TAHSİLAT BİLGİLERİ";
            // 
            // btnBorcEkle
            // 
            this.btnBorcEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBorcEkle.ForeColor = System.Drawing.Color.Yellow;
            this.btnBorcEkle.Image = global::KuryePera.Properties.Resources.borç_32;
            this.btnBorcEkle.Location = new System.Drawing.Point(19, 103);
            this.btnBorcEkle.Name = "btnBorcEkle";
            this.btnBorcEkle.Size = new System.Drawing.Size(116, 46);
            this.btnBorcEkle.TabIndex = 8;
            this.btnBorcEkle.Text = "BORÇ EKLE";
            this.btnBorcEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorcEkle.UseVisualStyleBackColor = false;
            this.btnBorcEkle.Click += new System.EventHandler(this.btnBorcEkle_Click);
            // 
            // btnRaporAl
            // 
            this.btnRaporAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRaporAl.ForeColor = System.Drawing.Color.Yellow;
            this.btnRaporAl.Image = global::KuryePera.Properties.Resources.Yenile32;
            this.btnRaporAl.Location = new System.Drawing.Point(263, 103);
            this.btnRaporAl.Name = "btnRaporAl";
            this.btnRaporAl.Size = new System.Drawing.Size(116, 46);
            this.btnRaporAl.TabIndex = 10;
            this.btnRaporAl.Text = "YENİLE";
            this.btnRaporAl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRaporAl.UseVisualStyleBackColor = false;
            this.btnRaporAl.Click += new System.EventHandler(this.btnRaporAl_Click);
            // 
            // btnTahsilEt
            // 
            this.btnTahsilEt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTahsilEt.ForeColor = System.Drawing.Color.Yellow;
            this.btnTahsilEt.Image = global::KuryePera.Properties.Resources.turkish_lira;
            this.btnTahsilEt.Location = new System.Drawing.Point(141, 103);
            this.btnTahsilEt.Name = "btnTahsilEt";
            this.btnTahsilEt.Size = new System.Drawing.Size(116, 46);
            this.btnTahsilEt.TabIndex = 9;
            this.btnTahsilEt.Text = "TAHSİL ET";
            this.btnTahsilEt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTahsilEt.UseVisualStyleBackColor = false;
            this.btnTahsilEt.Click += new System.EventHandler(this.btnTahsilEt_Click);
            // 
            // chechkYok
            // 
            this.chechkYok.AutoSize = true;
            this.chechkYok.Location = new System.Drawing.Point(263, 36);
            this.chechkYok.Name = "chechkYok";
            this.chechkYok.Size = new System.Drawing.Size(52, 19);
            this.chechkYok.TabIndex = 6;
            this.chechkYok.Text = "YOK";
            this.chechkYok.UseVisualStyleBackColor = true;
            // 
            // checckVar
            // 
            this.checckVar.AutoSize = true;
            this.checckVar.Location = new System.Drawing.Point(181, 36);
            this.checckVar.Name = "checckVar";
            this.checckVar.Size = new System.Drawing.Size(52, 19);
            this.checckVar.TabIndex = 5;
            this.checckVar.Text = "VAR";
            this.checckVar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Borç Durumu :";
            // 
            // txtTahsilEdilenTutar
            // 
            this.txtTahsilEdilenTutar.Location = new System.Drawing.Point(154, 73);
            this.txtTahsilEdilenTutar.Name = "txtTahsilEdilenTutar";
            this.txtTahsilEdilenTutar.Size = new System.Drawing.Size(181, 23);
            this.txtTahsilEdilenTutar.TabIndex = 7;
            this.txtTahsilEdilenTutar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTahsilEdilenTutar_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tahsil Edilen Tutar :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblToplamBorc);
            this.groupBox1.Controls.Add(this.txtMusteriToplamBorc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMusteriTelNo);
            this.groupBox1.Controls.Add(this.txtMusteriAdSoyad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(15, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 171);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MÜŞTERİ BİLGİLERİ";
            // 
            // lblToplamBorc
            // 
            this.lblToplamBorc.AutoSize = true;
            this.lblToplamBorc.ForeColor = System.Drawing.Color.Red;
            this.lblToplamBorc.Location = new System.Drawing.Point(265, 143);
            this.lblToplamBorc.Name = "lblToplamBorc";
            this.lblToplamBorc.Size = new System.Drawing.Size(43, 15);
            this.lblToplamBorc.TabIndex = 5;
            this.lblToplamBorc.Text = "label6";
            // 
            // txtMusteriToplamBorc
            // 
            this.txtMusteriToplamBorc.Location = new System.Drawing.Point(195, 110);
            this.txtMusteriToplamBorc.Name = "txtMusteriToplamBorc";
            this.txtMusteriToplamBorc.ReadOnly = true;
            this.txtMusteriToplamBorc.Size = new System.Drawing.Size(181, 23);
            this.txtMusteriToplamBorc.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Müşteri Toplam Borcu :";
            // 
            // txtMusteriTelNo
            // 
            this.txtMusteriTelNo.Location = new System.Drawing.Point(195, 70);
            this.txtMusteriTelNo.Name = "txtMusteriTelNo";
            this.txtMusteriTelNo.ReadOnly = true;
            this.txtMusteriTelNo.Size = new System.Drawing.Size(181, 23);
            this.txtMusteriTelNo.TabIndex = 3;
            // 
            // txtMusteriAdSoyad
            // 
            this.txtMusteriAdSoyad.Location = new System.Drawing.Point(195, 37);
            this.txtMusteriAdSoyad.Name = "txtMusteriAdSoyad";
            this.txtMusteriAdSoyad.ReadOnly = true;
            this.txtMusteriAdSoyad.Size = new System.Drawing.Size(181, 23);
            this.txtMusteriAdSoyad.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Müşteri Telefon Numarası :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Müşteri Adı ve Soyadı :";
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAra.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.ForeColor = System.Drawing.Color.Yellow;
            this.btnAra.Image = global::KuryePera.Properties.Resources.ara_32;
            this.btnAra.Location = new System.Drawing.Point(314, 24);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(54, 56);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "ARA";
            this.btnAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "MÜŞTERİ BUL :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GridMusteriTahsilat);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 450);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MÜŞTERİ BORÇ LİSTESİ ";
            // 
            // GridMusteriTahsilat
            // 
            this.GridMusteriTahsilat.AllowUserToAddRows = false;
            this.GridMusteriTahsilat.AllowUserToDeleteRows = false;
            this.GridMusteriTahsilat.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GridMusteriTahsilat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMusteriTahsilat.ContextMenuStrip = this.contextMenuStrip1;
            this.GridMusteriTahsilat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridMusteriTahsilat.Location = new System.Drawing.Point(3, 19);
            this.GridMusteriTahsilat.Name = "GridMusteriTahsilat";
            this.GridMusteriTahsilat.ReadOnly = true;
            this.GridMusteriTahsilat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridMusteriTahsilat.Size = new System.Drawing.Size(377, 428);
            this.GridMusteriTahsilat.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sİLToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(90, 26);
            // 
            // sİLToolStripMenuItem
            // 
            this.sİLToolStripMenuItem.Image = global::KuryePera.Properties.Resources.cancel_24;
            this.sİLToolStripMenuItem.Name = "sİLToolStripMenuItem";
            this.sİLToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.sİLToolStripMenuItem.Text = "SİL";
            this.sİLToolStripMenuItem.Click += new System.EventHandler(this.sİLToolStripMenuItem_Click);
            // 
            // Form_MusteriTahsilat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form_MusteriTahsilat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KURYEPERA MÜŞTERİ TAHSİLAT EKRANI ";
            this.Load += new System.EventHandler(this.Form_MusteriTahsilat_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridMusteriTahsilat)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboMusteri;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBorcEkle;
        private System.Windows.Forms.Button btnRaporAl;
        private System.Windows.Forms.Button btnTahsilEt;
        private System.Windows.Forms.CheckBox chechkYok;
        private System.Windows.Forms.CheckBox checckVar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTahsilEdilenTutar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMusteriToplamBorc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMusteriTelNo;
        private System.Windows.Forms.TextBox txtMusteriAdSoyad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblToplamBorc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sİLToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.DataGridView GridMusteriTahsilat;
    }
}