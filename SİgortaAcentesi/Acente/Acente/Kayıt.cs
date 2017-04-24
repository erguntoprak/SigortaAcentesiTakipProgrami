using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Acente
{
    public partial class Kayit : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ERGUN-TOPRAK; Initial Catalog=AcenteData ;Integrated Security=True");
        public Kayit()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
         
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (txtKod.Text == "Axbta35" && txtSifre.Text==txtSifre2.Text )
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("Insert into  GIRIS2 VALUES  ('" + txtKul.Text + "','" + txtSifre.Text + "')", conn);
                comm.ExecuteNonQuery();
                conn.Close();

            }
            else
            {
                lblUyari.Visible= true;

            }

        }
    }
}
