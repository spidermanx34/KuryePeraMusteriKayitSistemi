namespace KuryePera.FORMLARIM
{
    partial class Form_KuryeBorcu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_KuryeBorcu));
            this.txtKuryeBorcEkle = new System.Windows.Forms.TextBox();
            this.txtGuncelBorc = new System.Windows.Forms.TextBox();
            this.comboKuryeAd = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorcEkle = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.lblguncelborc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtKuryeBorcEkle
            // 
            this.txtKuryeBorcEkle.Location = new System.Drawing.Point(167, 131);
            this.txtKuryeBorcEkle.Name = "txtKuryeBorcEkle";
            this.txtKuryeBorcEkle.Size = new System.Drawing.Size(172, 20);
            this.txtKuryeBorcEkle.TabIndex = 3;
            this.txtKuryeBorcEkle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKuryeBorcEkle_KeyPress);
            // 
            // txtGuncelBorc
            // 
            this.txtGuncelBorc.Location = new System.Drawing.Point(167, 90);
            this.txtGuncelBorc.Name = "txtGuncelBorc";
            this.txtGuncelBorc.Size = new System.Drawing.Size(172, 20);
            this.txtGuncelBorc.TabIndex = 2;
            this.txtGuncelBorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKuryeTelefonNo_KeyPress);
            // 
            // comboKuryeAd
            // 
            this.comboKuryeAd.FormattingEnabled = true;
            this.comboKuryeAd.Location = new System.Drawing.Point(167, 54);
            this.comboKuryeAd.Name = "comboKuryeAd";
            this.comboKuryeAd.Size = new System.Drawing.Size(172, 21);
            this.comboKuryeAd.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(36, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 27);
            this.label4.TabIndex = 14;
            this.label4.Text = "KURYE BORÇ EKLEME EKRANI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(11, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kuryeye Borç Ekle :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(39, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "GÜNCEL BORÇ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kurye Adı ve Soyadı :";
            // 
            // btnBorcEkle
            // 
            this.btnBorcEkle.BackColor = System.Drawing.Color.Lime;
            this.btnBorcEkle.Font = new System.Drawing.Font("Arial Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBorcEkle.ForeColor = System.Drawing.Color.Red;
            this.btnBorcEkle.Image = global::KuryePera.Properties.Resources.borç_32;
            this.btnBorcEkle.Location = new System.Drawing.Point(148, 162);
            this.btnBorcEkle.Name = "btnBorcEkle";
            this.btnBorcEkle.Size = new System.Drawing.Size(106, 56);
            this.btnBorcEkle.TabIndex = 4;
            this.btnBorcEkle.Text = "BORÇ EKLE";
            this.btnBorcEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBorcEkle.UseVisualStyleBackColor = false;
            this.btnBorcEkle.Click += new System.EventHandler(this.btnBorcEkle_Click);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAra.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.ForeColor = System.Drawing.Color.Yellow;
            this.btnAra.Image = global::KuryePera.Properties.Resources.ara_32;
            this.btnAra.Location = new System.Drawing.Point(345, 37);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(54, 53);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "ARA";
            this.btnAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // lblguncelborc
            // 
            this.lblguncelborc.AutoSize = true;
            this.lblguncelborc.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblguncelborc.ForeColor = System.Drawing.Color.Red;
            this.lblguncelborc.Location = new System.Drawing.Point(229, 113);
            this.lblguncelborc.Name = "lblguncelborc";
            this.lblguncelborc.Size = new System.Drawing.Size(43, 15);
            this.lblguncelborc.TabIndex = 17;
            this.lblguncelborc.Text = "label5";
            // 
            // Form_KuryeBorcu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(407, 225);
            this.Controls.Add(this.lblguncelborc);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.btnBorcEkle);
            this.Controls.Add(this.txtKuryeBorcEkle);
            this.Controls.Add(this.txtGuncelBorc);
            this.Controls.Add(this.comboKuryeAd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(423, 264);
            this.MinimumSize = new System.Drawing.Size(423, 264);
            this.Name = "Form_KuryeBorcu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KURYEPERA KURYE BORÇ EKLEME EKRANI";
            this.Load += new System.EventHandler(this.Form_KuryeBorcu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBorcEkle;
        private System.Windows.Forms.TextBox txtKuryeBorcEkle;
        private System.Windows.Forms.TextBox txtGuncelBorc;
        private System.Windows.Forms.ComboBox comboKuryeAd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label lblguncelborc;
    }
}