namespace Acente
{
    partial class Tarih
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
            this.YaklasanTarihGoster = new System.Windows.Forms.Button();
            this.lvTarih = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // YaklasanTarihGoster
            // 
            this.YaklasanTarihGoster.BackColor = System.Drawing.Color.White;
            this.YaklasanTarihGoster.Image = global::Acente.Properties.Resources.Ara32x32;
            this.YaklasanTarihGoster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.YaklasanTarihGoster.Location = new System.Drawing.Point(664, 456);
            this.YaklasanTarihGoster.Name = "YaklasanTarihGoster";
            this.YaklasanTarihGoster.Size = new System.Drawing.Size(163, 42);
            this.YaklasanTarihGoster.TabIndex = 8;
            this.YaklasanTarihGoster.Text = "Yaklasan Tarihleri Göster";
            this.YaklasanTarihGoster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.YaklasanTarihGoster.UseVisualStyleBackColor = false;
            this.YaklasanTarihGoster.Click += new System.EventHandler(this.YaklasanTarihGoster_Click);
            // 
            // lvTarih
            // 
            this.lvTarih.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.lvTarih.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvTarih.ForeColor = System.Drawing.Color.White;
            this.lvTarih.Location = new System.Drawing.Point(0, 0);
            this.lvTarih.Name = "lvTarih";
            this.lvTarih.Size = new System.Drawing.Size(1040, 450);
            this.lvTarih.TabIndex = 9;
            this.lvTarih.UseCompatibleStateImageBehavior = false;
            this.lvTarih.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tc";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Adı";
            this.columnHeader7.Width = 91;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Soyadı";
            this.columnHeader10.Width = 107;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Sigorta Adı";
            this.columnHeader11.Width = 144;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Şirket Adi";
            this.columnHeader12.Width = 148;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Baslama Tarihi";
            this.columnHeader13.Width = 140;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Bitis Tarihi";
            this.columnHeader14.Width = 173;
            // 
            // Tarih
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 510);
            this.Controls.Add(this.lvTarih);
            this.Controls.Add(this.YaklasanTarihGoster);
            this.Name = "Tarih";
            this.Text = "Tarih";
            this.Load += new System.EventHandler(this.Tarih_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button YaklasanTarihGoster;
        private System.Windows.Forms.ListView lvTarih;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;


    }
}