namespace TEZ01
{
    partial class SifreUnuttum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreUnuttum));
            this.txteposta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtkuladı = new System.Windows.Forms.TextBox();
            this.btngonder = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txteposta
            // 
            this.txteposta.Location = new System.Drawing.Point(137, 43);
            this.txteposta.Name = "txteposta";
            this.txteposta.Size = new System.Drawing.Size(140, 20);
            this.txteposta.TabIndex = 0;
            this.txteposta.Validated += new System.EventHandler(this.txteposta_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(29, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "E POSTA ADRESİ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(29, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "KULLANICI ADI:";
            // 
            // txtkuladı
            // 
            this.txtkuladı.Location = new System.Drawing.Point(137, 75);
            this.txtkuladı.Name = "txtkuladı";
            this.txtkuladı.Size = new System.Drawing.Size(140, 20);
            this.txtkuladı.TabIndex = 1;
            this.txtkuladı.Validated += new System.EventHandler(this.txtkuladı_Validated);
            // 
            // btngonder
            // 
            this.btngonder.BackColor = System.Drawing.Color.White;
            this.btngonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngonder.ForeColor = System.Drawing.Color.Aqua;
            this.btngonder.Location = new System.Drawing.Point(191, 112);
            this.btngonder.Name = "btngonder";
            this.btngonder.Size = new System.Drawing.Size(86, 30);
            this.btngonder.TabIndex = 2;
            this.btngonder.Text = "GÖNDER";
            this.btngonder.UseVisualStyleBackColor = false;
            this.btngonder.Click += new System.EventHandler(this.btngonder_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SifreUnuttum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(317, 178);
            this.Controls.Add(this.btngonder);
            this.Controls.Add(this.txtkuladı);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txteposta);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifreUnuttum";
            this.Text = "ŞİFRE KURTARMA";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txteposta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtkuladı;
        private System.Windows.Forms.Button btngonder;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}