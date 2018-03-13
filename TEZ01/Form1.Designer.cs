namespace TEZ01
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSıfreUnttum = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.picBoxAd = new System.Windows.Forms.PictureBox();
            this.txtGüvenlikKodu = new System.Windows.Forms.TextBox();
            this.picBoxSoyad = new System.Windows.Forms.PictureBox();
            this.picBoxGüvenlikKoduSimgesi = new System.Windows.Forms.PictureBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnGüvenlikKoduYenile = new System.Windows.Forms.Button();
            this.lblGüvenlikKodu = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSoyad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGüvenlikKoduSimgesi)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSıfreUnttum
            // 
            this.btnSıfreUnttum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSıfreUnttum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSıfreUnttum.Location = new System.Drawing.Point(24, 201);
            this.btnSıfreUnttum.Name = "btnSıfreUnttum";
            this.btnSıfreUnttum.Size = new System.Drawing.Size(93, 23);
            this.btnSıfreUnttum.TabIndex = 54;
            this.btnSıfreUnttum.Text = "Şifremi Unuttum";
            this.btnSıfreUnttum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSıfreUnttum.UseVisualStyleBackColor = false;
            this.btnSıfreUnttum.Click += new System.EventHandler(this.btnSıfreUnttum_Click_1);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(67, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(79, 33);
            this.panel3.TabIndex = 55;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint_1);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGirisYap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGirisYap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirisYap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirisYap.ForeColor = System.Drawing.Color.White;
            this.btnGirisYap.Location = new System.Drawing.Point(191, 162);
            this.btnGirisYap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(69, 31);
            this.btnGirisYap.TabIndex = 47;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = false;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click_1);
            // 
            // picBoxAd
            // 
            this.picBoxAd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxAd.BackgroundImage")));
            this.picBoxAd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxAd.Location = new System.Drawing.Point(77, 29);
            this.picBoxAd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picBoxAd.Name = "picBoxAd";
            this.picBoxAd.Size = new System.Drawing.Size(34, 25);
            this.picBoxAd.TabIndex = 51;
            this.picBoxAd.TabStop = false;
            // 
            // txtGüvenlikKodu
            // 
            this.txtGüvenlikKodu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGüvenlikKodu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGüvenlikKodu.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGüvenlikKodu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGüvenlikKodu.Location = new System.Drawing.Point(181, 108);
            this.txtGüvenlikKodu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGüvenlikKodu.Multiline = true;
            this.txtGüvenlikKodu.Name = "txtGüvenlikKodu";
            this.txtGüvenlikKodu.ShortcutsEnabled = false;
            this.txtGüvenlikKodu.Size = new System.Drawing.Size(79, 33);
            this.txtGüvenlikKodu.TabIndex = 46;
            // 
            // picBoxSoyad
            // 
            this.picBoxSoyad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxSoyad.BackgroundImage")));
            this.picBoxSoyad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxSoyad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxSoyad.Location = new System.Drawing.Point(77, 62);
            this.picBoxSoyad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picBoxSoyad.Name = "picBoxSoyad";
            this.picBoxSoyad.Size = new System.Drawing.Size(34, 25);
            this.picBoxSoyad.TabIndex = 52;
            this.picBoxSoyad.TabStop = false;
            // 
            // picBoxGüvenlikKoduSimgesi
            // 
            this.picBoxGüvenlikKoduSimgesi.BackColor = System.Drawing.Color.Red;
            this.picBoxGüvenlikKoduSimgesi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxGüvenlikKoduSimgesi.BackgroundImage")));
            this.picBoxGüvenlikKoduSimgesi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxGüvenlikKoduSimgesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxGüvenlikKoduSimgesi.Location = new System.Drawing.Point(153, 108);
            this.picBoxGüvenlikKoduSimgesi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picBoxGüvenlikKoduSimgesi.Name = "picBoxGüvenlikKoduSimgesi";
            this.picBoxGüvenlikKoduSimgesi.Size = new System.Drawing.Size(30, 33);
            this.picBoxGüvenlikKoduSimgesi.TabIndex = 53;
            this.picBoxGüvenlikKoduSimgesi.TabStop = false;
            // 
            // lblSoyad
            // 
            this.lblSoyad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSoyad.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSoyad.Location = new System.Drawing.Point(27, 66);
            this.lblSoyad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(42, 16);
            this.lblSoyad.TabIndex = 49;
            this.lblSoyad.Text = "Şifre :";
            // 
            // txtAd
            // 
            this.txtAd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAd.ForeColor = System.Drawing.Color.Black;
            this.txtAd.Location = new System.Drawing.Point(111, 29);
            this.txtAd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAd.MaxLength = 30;
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(149, 25);
            this.txtAd.TabIndex = 44;
            // 
            // lblAd
            // 
            this.lblAd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAd.AutoSize = true;
            this.lblAd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAd.Location = new System.Drawing.Point(41, 36);
            this.lblAd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(28, 16);
            this.lblAd.TabIndex = 50;
            this.lblAd.Text = "Ad:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnGüvenlikKoduYenile);
            this.panel5.Controls.Add(this.lblGüvenlikKodu);
            this.panel5.Location = new System.Drawing.Point(24, 162);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(128, 33);
            this.panel5.TabIndex = 48;
            // 
            // btnGüvenlikKoduYenile
            // 
            this.btnGüvenlikKoduYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGüvenlikKoduYenile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGüvenlikKoduYenile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGüvenlikKoduYenile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGüvenlikKoduYenile.BackgroundImage")));
            this.btnGüvenlikKoduYenile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGüvenlikKoduYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGüvenlikKoduYenile.Location = new System.Drawing.Point(92, 3);
            this.btnGüvenlikKoduYenile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGüvenlikKoduYenile.Name = "btnGüvenlikKoduYenile";
            this.btnGüvenlikKoduYenile.Size = new System.Drawing.Size(29, 24);
            this.btnGüvenlikKoduYenile.TabIndex = 6;
            this.btnGüvenlikKoduYenile.UseVisualStyleBackColor = false;
            this.btnGüvenlikKoduYenile.Click += new System.EventHandler(this.btnGüvenlikKoduYenile_Click_1);
            // 
            // lblGüvenlikKodu
            // 
            this.lblGüvenlikKodu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGüvenlikKodu.AutoSize = true;
            this.lblGüvenlikKodu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblGüvenlikKodu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGüvenlikKodu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGüvenlikKodu.Location = new System.Drawing.Point(1, 7);
            this.lblGüvenlikKodu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGüvenlikKodu.Name = "lblGüvenlikKodu";
            this.lblGüvenlikKodu.Size = new System.Drawing.Size(95, 16);
            this.lblGüvenlikKodu.TabIndex = 17;
            this.lblGüvenlikKodu.Text = "Güvenlik Kodu:";
            // 
            // txtSifre
            // 
            this.txtSifre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSifre.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.ForeColor = System.Drawing.Color.Black;
            this.txtSifre.Location = new System.Drawing.Point(111, 62);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSifre.MaxLength = 20;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(149, 25);
            this.txtSifre.TabIndex = 45;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(312, 259);
            this.Controls.Add(this.btnSıfreUnttum);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.picBoxAd);
            this.Controls.Add(this.txtGüvenlikKodu);
            this.Controls.Add(this.picBoxSoyad);
            this.Controls.Add(this.picBoxGüvenlikKoduSimgesi);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.txtSifre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "DALKILINÇ EMLAK";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSoyad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGüvenlikKoduSimgesi)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSıfreUnttum;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button btnGirisYap;
        public System.Windows.Forms.PictureBox picBoxAd;
        public System.Windows.Forms.TextBox txtGüvenlikKodu;
        public System.Windows.Forms.PictureBox picBoxSoyad;
        public System.Windows.Forms.PictureBox picBoxGüvenlikKoduSimgesi;
        public System.Windows.Forms.Label lblSoyad;
        public System.Windows.Forms.TextBox txtAd;
        public System.Windows.Forms.Label lblAd;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Button btnGüvenlikKoduYenile;
        public System.Windows.Forms.Label lblGüvenlikKodu;
        public System.Windows.Forms.TextBox txtSifre;
    }
}

