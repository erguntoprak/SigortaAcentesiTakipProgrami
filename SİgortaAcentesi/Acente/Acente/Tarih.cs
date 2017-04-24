using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acente
{
    public partial class Tarih : Form

    {
        SqlConnection conn = new SqlConnection("Data Source=ERGUN-TOPRAK; Initial Catalog=AcenteData ;Integrated Security=True");
        SqlCommand comm = new SqlCommand();




        public Tarih()
        {
            InitializeComponent();
        }

        public void listele()
        {

        }
        
        private void Tarih_Load(object sender, EventArgs e)
        {
            
          
        }

        private void YaklasanTarihGoster_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@simdikiZaman", DateTime.Now);
                comm.Parameters.AddWithValue("@oncekiZaman", DateTime.Now.AddDays(-3));
                comm.CommandText = "select * from KAYIT K LEFT JOIN MUSTERI M on (K.Müsteri_id=M.Musteri_id) LEFT JOIN ADRES A on (M.Adres_no= A.Adres_no) LEFT JOIN SIRKET_CESIT SC ON(K.ID=SC.ID) LEFT JOIN SIGORTA_SIRKETLERI SS ON(SC.Sirket_id=SS.Sirket_id) LEFT JOIN SİGORTA_CESİTLERİ SCT ON(SCT.Sigorta_id=SC.Sigorta_id) LEFT JOIN TUTAR  TT ON(SC.Tutar_id=TT.Tutar_id) LEFT JOIN BASLAMA_BITIS BB ON (K.Tarih_no=BB.Tarih_no) WHERE Bitis >= @simdikiZaman AND Bitis >= @oncekiZaman ";
                SqlDataReader dr = comm.ExecuteReader();
                int dizi = 0;
                lvTarih.Items.Clear();
                while (dr.Read())
                {
                    dizi = lvTarih.Items.Count;
                    lvTarih.Items.Add(dr["Musteri_tc"].ToString());
                    lvTarih.Items[dizi].SubItems.Add(dr["Musteri_isim"].ToString());
                    lvTarih.Items[dizi].SubItems.Add(dr["Musteri_soyadi"].ToString());
                    lvTarih.Items[dizi].SubItems.Add(dr["Sigorta_isim"].ToString());
                    lvTarih.Items[dizi].SubItems.Add(dr["Sirket_isim"].ToString());
                    lvTarih.Items[dizi].SubItems.Add(dr["Baslama"].ToString());
                    lvTarih.Items[dizi].SubItems.Add(dr["Bitis"].ToString());
                    KirmiziRenklendirme();
                }



            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                comm.Parameters.Clear();

            }
           

        }

        private void KirmiziRenklendirme()
        {
            ListView lv = this.lvTarih;
            int i = 0;
            Color renk = Color.FromArgb(240, 240, 240);
            foreach (ListViewItem item in lv.Items)
            {
                item.BackColor = Color.Red;
                item.UseItemStyleForSubItems = true;
            }
        }


        private void SariRenklendirme()
        {
            ListView lv = this.lvTarih;
            int i = 0;
            Color renk = Color.FromArgb(240, 240, 240);
            foreach (ListViewItem item in lv.Items)
            {
                item.BackColor = Color.Yellow;
                item.UseItemStyleForSubItems = true;
            }


        }
       
    }
}
