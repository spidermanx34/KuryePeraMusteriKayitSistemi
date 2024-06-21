namespace KuryePera.FORMLARIM
{
    partial class Form_MusteriBorcEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MusteriBorcEkle));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboMusteriAd = new System.Windows.Forms.ComboBox();
            this.txtMusterininGuncelBorcu = new System.Windows.Forms.TextBox();
            this.txtBorcEkle = new System.Windows.Forms.TextBox();
            this.btnBorcEkle = new System.Windows.Forms.Button();
            this.lblguncelborc = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müşteri Adı  veya UNVANI :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(11, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "MÜŞTERİNİN GÜNCEL BORCU :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(141, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "BORÇ EKLE :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(32, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(361, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "MÜŞTERİ BORÇ EKLEME EKRANI";
            // 
            // comboMusteriAd
            // 
            this.comboMusteriAd.FormattingEnabled = true;
            this.comboMusteriAd.Location = new System.Drawing.Point(217, 55);
            this.comboMusteriAd.Name = "comboMusteriAd";
            this.comboMusteriAd.Size = new System.Drawing.Size(133, 21);
            this.comboMusteriAd.TabIndex = 0;
            // 
            // txtMusterininGuncelBorcu
            // 
            this.txtMusterininGuncelBorcu.Location = new System.Drawing.Point(252, 101);
            this.txtMusterininGuncelBorcu.Name = "txtMusterininGuncelBorcu";
            this.txtMusterininGuncelBorcu.Size = new System.Drawing.Size(132, 20);
            this.txtMusterininGuncelBorcu.TabIndex = 1;
            // 
            // txtBorcEkle
            // 
            this.txtBorcEkle.Location = new System.Drawing.Point(251, 140);
            this.txtBorcEkle.Name = "txtBorcEkle";
            this.txtBorcEkle.Size = new System.Drawing.Size(132, 20);
            this.txtBorcEkle.TabIndex = 2;
            // 
            // btnBorcEkle
            // 
            this.btnBorcEkle.BackColor = System.Drawing.Color.Lime;
            this.btnBorcEkle.Font = new System.Drawing.Font("Arial Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBorcEkle.ForeColor = System.Drawing.Color.Red;
            this.btnBorcEkle.Image = global::KuryePera.Properties.Resources.borç_32;
            this.btnBorcEkle.Location = new System.Drawing.Point(157, 162);
            this.btnBorcEkle.Name = "btnBorcEkle";
            this.btnBorcEkle.Size = new System.Drawing.Size(106, 62);
            this.btnBorcEkle.TabIndex = 3;
            this.btnBorcEkle.Text = "BORÇ EKLE";
            this.btnBorcEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBorcEkle.UseVisualStyleBackColor = false;
            this.btnBorcEkle.Click += new System.EventHandler(this.btnBorcEkle_Click);
            // 
            // lblguncelborc
            // 
            this.lblguncelborc.AutoSize = true;
            this.lblguncelborc.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblguncelborc.ForeColor = System.Drawing.Color.Red;
            this.lblguncelborc.Location = new System.Drawing.Point(296, 121);
            this.lblguncelborc.Name = "lblguncelborc";
            this.lblguncelborc.Size = new System.Drawing.Size(43, 15);
            this.lblguncelborc.TabIndex = 8;
            this.lblguncelborc.Text = "label5";
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAra.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.ForeColor = System.Drawing.Color.Yellow;
            this.btnAra.Image = global::KuryePera.Properties.Resources.ara_32;
            this.btnAra.Location = new System.Drawing.Point(361, 39);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(54, 53);
            this.btnAra.TabIndex = 9;
            this.btnAra.Text = "ARA";
            this.btnAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form_MusteriBorcEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(427, 224);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.lblguncelborc);
            this.Controls.Add(this.btnBorcEkle);
            this.Controls.Add(this.txtBorcEkle);
            this.Controls.Add(this.txtMusterininGuncelBorcu);
            this.Controls.Add(this.comboMusteriAd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(443, 263);
            this.MinimumSize = new System.Drawing.Size(443, 263);
            this.Name = "Form_MusteriBorcEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KURYEPERA MÜŞTERİ BORÇ EKLEME EKRANI";
            this.Load += new System.EventHandler(this.Form_MusteriBorcEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboMusteriAd;
        private System.Windows.Forms.TextBox txtMusterininGuncelBorcu;
        private System.Windows.Forms.TextBox txtBorcEkle;
        private System.Windows.Forms.Button btnBorcEkle;
        private System.Windows.Forms.Label lblguncelborc;
        private System.Windows.Forms.Button btnAra;
    }
}