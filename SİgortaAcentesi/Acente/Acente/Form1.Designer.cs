namespace Acente
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
            this.btnGiris = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Uyari = new System.Windows.Forms.Label();
            this.labelKaydol = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSunuttum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnGiris.Location = new System.Drawing.Point(41, 170);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(142, 41);
            this.btnGiris.TabIndex = 0;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(38, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // txtAdi
            // 
            this.txtAdi.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdi.Location = new System.Drawing.Point(41, 64);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Size = new System.Drawing.Size(202, 30);
            this.txtAdi.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Uyari);
            this.panel1.Controls.Add(this.labelKaydol);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelSunuttum);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnGiris);
            this.panel1.Controls.Add(this.txtSifre);
            this.panel1.Controls.Add(this.txtAdi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(53, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 332);
            this.panel1.TabIndex = 4;
            // 
            // Uyari
            // 
            this.Uyari.AutoSize = true;
            this.Uyari.ForeColor = System.Drawing.Color.Red;
            this.Uyari.Location = new System.Drawing.Point(41, 218);
            this.Uyari.Name = "Uyari";
            this.Uyari.Size = new System.Drawing.Size(140, 13);
            this.Uyari.TabIndex = 9;
            this.Uyari.Text = "Kullanıcı adı veya şifre yanlış";
            this.Uyari.Visible = false;
            // 
            // labelKaydol
            // 
            this.labelKaydol.AutoSize = true;
            this.labelKaydol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelKaydol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKaydol.Location = new System.Drawing.Point(127, 287);
            this.labelKaydol.Name = "labelKaydol";
            this.labelKaydol.Size = new System.Drawing.Size(78, 13);
            this.labelKaydol.TabIndex = 8;
            this.labelKaydol.Text = "Şimdi kaydolun";
            this.labelKaydol.Click += new System.EventHandler(this.label_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Yetkin yok mu ?";
            // 
            // labelSunuttum
            // 
            this.labelSunuttum.AutoSize = true;
            this.labelSunuttum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSunuttum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSunuttum.Location = new System.Drawing.Point(38, 253);
            this.labelSunuttum.Name = "labelSunuttum";
            this.labelSunuttum.Size = new System.Drawing.Size(76, 13);
            this.labelSunuttum.TabIndex = 6;
            this.labelSunuttum.Text = "Şifreyi unuttum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(38, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Şifre";
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifre.Location = new System.Drawing.Point(41, 124);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(202, 30);
            this.txtSifre.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImage = global::Acente.Properties.Resources.arkaplan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(466, 427);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "AcenteTakip";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelKaydol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label Uyari;
        private System.Windows.Forms.Label labelSunuttum;
    }
}

