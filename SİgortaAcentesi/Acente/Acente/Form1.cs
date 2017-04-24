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
    public partial class Form1 : Form
    {
       
        Kayit kayit = new Kayit();
        public Form1()
        {
            InitializeComponent();
        }

        private void label_Click(object sender, EventArgs e)
        {

            kayit.Show();
            this.Hide();
            


        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=ERGUN-TOPRAK; Initial Catalog=AcenteData ;Integrated Security=True");
            if (conn.State == ConnectionState.Closed)
            {
                SqlCommand comm = new SqlCommand("Select * from GIRIS2 where Kullanici_adi = '" +txtAdi.Text +"' and Sifre='"+ txtSifre.Text +"'",conn);

                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    araYüz ay = new araYüz();
                    ay.Show();
                    this.Hide();


                }
                else
                {
                    Uyari.Visible = true;
                    txtAdi.Text = "";
                    txtSifre.Text = "";
                }

            }
        }
    }
}
