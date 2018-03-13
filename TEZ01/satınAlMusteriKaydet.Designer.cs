namespace TEZ01
{
    partial class satınAlMusteriKaydet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(satınAlMusteriKaydet));
            this.panel10 = new System.Windows.Forms.Panel();
            this.txttc = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtepostatekrar = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txteposta = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkboxsozlesme = new System.Windows.Forms.CheckBox();
            this.txtsoyad = new System.Windows.Forms.TextBox();
            this.txtGüvenlikKodu = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtad = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnsatınal = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnguvenlıkkodu = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txttc);
            this.panel10.Controls.Add(this.label4);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.txtepostatekrar);
            this.panel10.Controls.Add(this.label24);
            this.panel10.Controls.Add(this.pictureBox3);
            this.panel10.Controls.Add(this.txteposta);
            this.panel10.Controls.Add(this.panel2);
            this.panel10.Controls.Add(this.checkboxsozlesme);
            this.panel10.Controls.Add(this.txtsoyad);
            this.panel10.Controls.Add(this.txtGüvenlikKodu);
            this.panel10.Controls.Add(this.label28);
            this.panel10.Controls.Add(this.txtad);
            this.panel10.Controls.Add(this.label25);
            this.panel10.Controls.Add(this.label27);
            this.panel10.Controls.Add(this.btnsatınal);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.label26);
            this.panel10.Location = new System.Drawing.Point(27, 34);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(307, 402);
            this.panel10.TabIndex = 3;
            // 
            // txttc
            // 
            this.txttc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txttc.Location = new System.Drawing.Point(20, 27);
            this.txttc.Mask = "00000000000";
            this.txttc.Name = "txttc";
            this.txttc.ShortcutsEnabled = false;
            this.txttc.Size = new System.Drawing.Size(177, 26);
            this.txttc.TabIndex = 0;
            this.txttc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HarfEngelle);
            this.txttc.Validated += new System.EventHandler(this.txttc_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 309);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "nı Kabul Ediyorum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(121, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Gizlilik Politikası";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Ve";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(40, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Sözleşmeyi";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtepostatekrar
            // 
            this.txtepostatekrar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtepostatekrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtepostatekrar.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtepostatekrar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtepostatekrar.Location = new System.Drawing.Point(20, 207);
            this.txtepostatekrar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtepostatekrar.Multiline = true;
            this.txtepostatekrar.Name = "txtepostatekrar";
            this.txtepostatekrar.Size = new System.Drawing.Size(261, 28);
            this.txtepostatekrar.TabIndex = 4;
            this.txtepostatekrar.Validated += new System.EventHandler(this.txtepostatekrar_Validated);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(18, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "TC NO ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Red;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(180, 254);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 33);
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            // 
            // txteposta
            // 
            this.txteposta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txteposta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txteposta.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txteposta.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txteposta.Location = new System.Drawing.Point(20, 146);
            this.txteposta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txteposta.Multiline = true;
            this.txteposta.Name = "txteposta";
            this.txteposta.Size = new System.Drawing.Size(261, 28);
            this.txteposta.TabIndex = 3;
            this.txteposta.Validated += new System.EventHandler(this.txteposta_Validated);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(20, 254);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(79, 33);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint_1);
            // 
            // checkboxsozlesme
            // 
            this.checkboxsozlesme.Location = new System.Drawing.Point(21, 309);
            this.checkboxsozlesme.Name = "checkboxsozlesme";
            this.checkboxsozlesme.Size = new System.Drawing.Size(25, 15);
            this.checkboxsozlesme.TabIndex = 47;
            this.checkboxsozlesme.UseVisualStyleBackColor = true;
            // 
            // txtsoyad
            // 
            this.txtsoyad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsoyad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsoyad.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsoyad.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtsoyad.Location = new System.Drawing.Point(177, 90);
            this.txtsoyad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtsoyad.Multiline = true;
            this.txtsoyad.Name = "txtsoyad";
            this.txtsoyad.ShortcutsEnabled = false;
            this.txtsoyad.Size = new System.Drawing.Size(104, 28);
            this.txtsoyad.TabIndex = 2;
            this.txtsoyad.Validated += new System.EventHandler(this.txtsoyad_Validated);
            // 
            // txtGüvenlikKodu
            // 
            this.txtGüvenlikKodu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGüvenlikKodu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGüvenlikKodu.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGüvenlikKodu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGüvenlikKodu.Location = new System.Drawing.Point(204, 254);
            this.txtGüvenlikKodu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGüvenlikKodu.Multiline = true;
            this.txtGüvenlikKodu.Name = "txtGüvenlikKodu";
            this.txtGüvenlikKodu.ShortcutsEnabled = false;
            this.txtGüvenlikKodu.Size = new System.Drawing.Size(77, 33);
            this.txtGüvenlikKodu.TabIndex = 5;
            this.txtGüvenlikKodu.Validated += new System.EventHandler(this.txtGüvenlikKodu_Validated);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(18, 131);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 13);
            this.label28.TabIndex = 6;
            this.label28.Text = "E POSTA :";
            // 
            // txtad
            // 
            this.txtad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtad.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtad.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtad.Location = new System.Drawing.Point(20, 90);
            this.txtad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtad.Multiline = true;
            this.txtad.Name = "txtad";
            this.txtad.ShortcutsEnabled = false;
            this.txtad.Size = new System.Drawing.Size(124, 28);
            this.txtad.TabIndex = 1;
            this.txtad.Validated += new System.EventHandler(this.txtad_Validated);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(18, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(28, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "AD :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 192);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(106, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "E POSTA TEKRAR :";
            // 
            // btnsatınal
            // 
            this.btnsatınal.Location = new System.Drawing.Point(173, 348);
            this.btnsatınal.Name = "btnsatınal";
            this.btnsatınal.Size = new System.Drawing.Size(91, 37);
            this.btnsatınal.TabIndex = 6;
            this.btnsatınal.Text = "SATIN AL";
            this.btnsatınal.UseVisualStyleBackColor = true;
            this.btnsatınal.Click += new System.EventHandler(this.btnsatınal_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.btnguvenlıkkodu);
            this.panel11.Location = new System.Drawing.Point(104, 254);
            this.panel11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(40, 33);
            this.panel11.TabIndex = 38;
            // 
            // btnguvenlıkkodu
            // 
            this.btnguvenlıkkodu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnguvenlıkkodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnguvenlıkkodu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnguvenlıkkodu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnguvenlıkkodu.BackgroundImage")));
            this.btnguvenlıkkodu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnguvenlıkkodu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnguvenlıkkodu.Location = new System.Drawing.Point(4, 3);
            this.btnguvenlıkkodu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnguvenlıkkodu.Name = "btnguvenlıkkodu";
            this.btnguvenlıkkodu.Size = new System.Drawing.Size(29, 24);
            this.btnguvenlıkkodu.TabIndex = 0;
            this.btnguvenlıkkodu.UseVisualStyleBackColor = false;
            this.btnguvenlıkkodu.Click += new System.EventHandler(this.btnguvenlıkkodu_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(177, 74);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 13);
            this.label26.TabIndex = 4;
            this.label26.Text = "SOYAD :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // satınAlMusteriKaydet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 448);
            this.Controls.Add(this.panel10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "satınAlMusteriKaydet";
            this.Text = "Satın Al Musteri Kaydet";
            this.Load += new System.EventHandler(this.satınAlMusteriKaydet_Load);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel10;
        public System.Windows.Forms.TextBox txtepostatekrar;
        public System.Windows.Forms.TextBox txteposta;
        public System.Windows.Forms.TextBox txtsoyad;
        public System.Windows.Forms.TextBox txtad;
        public System.Windows.Forms.Panel panel11;
        public System.Windows.Forms.Button btnguvenlıkkodu;
        private System.Windows.Forms.Button btnsatınal;
        private System.Windows.Forms.CheckBox checkboxsozlesme;
        public System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtGüvenlikKodu;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.MaskedTextBox txttc;
    }
}