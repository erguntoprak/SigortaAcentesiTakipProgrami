using Acente.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Acente
{
   
    public partial class araYüz : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ERGUN-TOPRAK; Initial Catalog=AcenteData ;Integrated Security=True");
        SqlCommand comm = new SqlCommand();

        string Kayit_id;
        string ID;
        string Sigorta_id;
        string Tutar_id;
        string Musteri_id;
        string Adres_no;
        


        public araYüz()
        {
            InitializeComponent();

           

        }
        
      

        private void button11_Click(object sender, EventArgs e)
        {
            
            txtAd.Clear();
            txtSoyad.Clear();
            txtTel.Clear();
            txtCadde.Clear();
            txtMahalle.Clear();
            txtSehir.Clear();
            txtBina.Clear();
            txtPostaKodu.Clear();
            txtUlke.Clear();
            txtEpos.Clear();
            txtTC1.Clear();
            txtFiyat.Clear();
            cmbSirket.SelectedItem= null;
            cmbTip.SelectedItem = null;
            cmbSure.SelectedItem = null;
  

        }
       private void araYüz_Load(object sender, EventArgs e)
       {
           radioBankamatik.Focus();
           SqlConnection conn = new SqlConnection("Data Source=ERGUN-TOPRAK; Initial Catalog=AcenteData ;Integrated Security=True");
           SqlCommand comm = new SqlCommand("Select * from SIGORTA_SIRKETLERI ", conn);
           try
           {
               conn.Open();
               SqlDataReader dr = comm.ExecuteReader();
               while (dr.Read())
               {
                   cmbSirket.Items.Add(dr["Sirket_isim"]);
               }

           }
           catch (SqlException ex)
           {
               MessageBox.Show(ex.Message);
           }
           finally
           {
               conn.Close();
           }


       }

       private void genelToolStripMenuItem_Click(object sender, EventArgs e)
       {
           tbGenel.Visible = true;
       }

       private void özelNotToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Not not = new Not();
           not.Show();
       }

       private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Application.Exit();
       }

       private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
       {

       }

       private void yakınTarihToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Tarih th = new Tarih();
           th.Show();
       }

       private void btnKaydet_Click(object sender, EventArgs e)
       {
           if (txtTC1.Text == null || txtSoyad.Text == "" || txtSoyad.Text == "" || txtEpos.Text == "" || txtTel.Text == ""
                  || txtCadde.Text == "" || txtMahalle.Text == "" || txtBina.Text == "" || txtSehir.Text == "" || txtPostaKodu.Text == ""
                  || txtUlke.Text == "" || cmbTip.Text == "")
           {
               MessageBox.Show("Lütfen bütün alanları giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               try
               {

                   conn.Open();
                   comm.Connection = conn;
                   comm.Parameters.AddWithValue("@Cadde", txtCadde.Text);
                   comm.Parameters.AddWithValue("@Mahalle", txtMahalle.Text);
                   comm.Parameters.AddWithValue("@Bina_no", txtBina.Text);
                   comm.Parameters.AddWithValue("@Sehir", txtSehir.Text);
                   comm.Parameters.AddWithValue("@Posta_kodu", txtPostaKodu.Text);
                   comm.Parameters.AddWithValue("@Ulke", txtUlke.Text);
                   comm.CommandText = "INSERT INTO ADRES (Cadde,Mahalle,Bina_no,Sehir,Posta_kodu,Ulke) VALUES (@Cadde,@Mahalle,@Bina_no,@Sehir,@Posta_kodu,@Ulke)";
                   comm.ExecuteNonQuery();
                 

                   comm.Parameters.AddWithValue("@Musteri_isim", txtAd.Text);
                   comm.Parameters.AddWithValue("@Musteri_soyadi", txtSoyad.Text);
                   comm.Parameters.AddWithValue("@E_posta", txtEpos.Text);
                   comm.Parameters.AddWithValue("@Telefon", txtTel.Text);
                   comm.Parameters.AddWithValue("@Dogum_tarihi", dtDogumTarihi.Value);
                   comm.Parameters.AddWithValue("@Musteri_tc", txtTC1.Text);
                   comm.CommandText = "INSERT INTO MUSTERI (Musteri_isim,Musteri_soyadi,E_posta,Telefon,Adres_no,Dogum_tarihi,Musteri_tc) VALUES (@Musteri_isim,@Musteri_soyadi,@E_posta,@Telefon,IDENT_CURRENT('ADRES'),@Dogum_tarihi,@Musteri_tc)";
                   comm.ExecuteNonQuery();

                 
                   comm.Parameters.AddWithValue("@Sigorta_isim", cmbTip.Text);
                   comm.Parameters.AddWithValue("@Sigorta_suresi", cmbSure.Text);
                   comm.CommandText = "INSERT INTO SİGORTA_CESİTLERİ (Sigorta_isim,Sigorta_suresi) VALUES (@Sigorta_isim,@Sigorta_suresi)";
                   comm.ExecuteNonQuery();

                   


                   String odemeSekli = "";
                   if (radioPesin.Checked)
                       odemeSekli = radioPesin.Text;
                   else if (radioBankamatik.Checked)
                       odemeSekli = radioBankamatik.Text;
                   else if (radioKredi.Checked)
                       odemeSekli = radioKredi.Text;
                   comm.Parameters.AddWithValue("@Odeme_sekli", odemeSekli);
                   comm.Parameters.AddWithValue("@Fiyat", txtFiyat.Text);
                   comm.CommandText = "INSERT INTO TUTAR (Odeme_sekli,Fiyat) VALUES (@Odeme_sekli,@Fiyat)";
                   comm.ExecuteNonQuery();
                  
                   comm.Parameters.AddWithValue("@Sirket_id", cmbSirket.SelectedIndex + 1);
                   comm.CommandText = "INSERT INTO SIRKET_CESIT (Sirket_id,Sigorta_id,Tutar_id) VALUES (@Sirket_id,IDENT_CURRENT('SİGORTA_CESİTLERİ'),IDENT_CURRENT('TUTAR'))";
                   comm.ExecuteNonQuery();
                   
                   comm.Parameters.AddWithValue("@Baslama", dtBaslama.Value);
                   comm.Parameters.AddWithValue("@Bitis", dtBitis.Value);
                   comm.CommandText = "INSERT INTO BASLAMA_BITIS (Baslama,Bitis) VALUES (@Baslama,@Bitis)";
                   comm.ExecuteNonQuery();

                  

                   comm.CommandText = "INSERT INTO KAYIT (Müsteri_id,Tarih_no,ID) VALUES (IDENT_CURRENT('MUSTERI'),IDENT_CURRENT('BASLAMA_BITIS'),IDENT_CURRENT('SIRKET_CESIT'))";
                   comm.ExecuteNonQuery();

                   MessageBox.Show("Kayit basarılı","KAYIT İŞLEMİ",MessageBoxButtons.OK,MessageBoxIcon.Information);





                   /*comm.Parameters.AddWithValue("@Ticari_unvani", txtTicari.Text);
                     comm.Parameters.AddWithValue("@Vergi_numarasi", txtVergi.Text);
                     comm.Parameters.AddWithValue("Sirket_isim", txtSirket);

                     comm.CommandText = "INSERT INTO MUSTERI (Ticari_unvani,Vergi_numarasi,Adres_no,Sirket_isim) VALUES (@Ticari_unvani,@Vergi_numarasi,IDENT_CURRENT('ADRES'),@Sirket_isim)";
                     comm.ExecuteNonQuery();

                     MessageBox.Show("Kayit basarılı");

                     */


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
       }

       private void btnGüncelle_Click(object sender, EventArgs e)
       {


           try
           {
               conn.Open();
               comm.Connection = conn;
               comm.CommandText = "select * from KAYIT K LEFT JOIN MUSTERI M on (K.Müsteri_id=M.Musteri_id) LEFT JOIN ADRES A on (M.Adres_no= A.Adres_no) LEFT JOIN SIRKET_CESIT SC ON(K.ID=SC.ID) LEFT JOIN SIGORTA_SIRKETLERI SS ON(SC.Sirket_id=SS.Sirket_id) LEFT JOIN SİGORTA_CESİTLERİ SCT ON(SCT.Sigorta_id=SC.Sigorta_id) LEFT JOIN TUTAR  TT ON(SC.Tutar_id=TT.Tutar_id) LEFT JOIN BASLAMA_BITIS BB ON (K.Tarih_no=BB.Tarih_no) where Musteri_tc ='" + txtTc.Text + "' ";
               SqlDataReader dr = comm.ExecuteReader();

               while (dr.Read())
               {
                   AID.Text = dr["Adres_no"].ToString();
                   MID.Text = dr["Musteri_id"].ToString();
                   BBID.Text = dr["Tarih_no"].ToString();
                   SID.Text = dr["Sigorta_id"].ToString();
                   TID.Text = dr["Tutar_id"].ToString();
                   txtTC1.Text = dr["Musteri_tc"].ToString();
                   txtAd.Text = dr["Musteri_isim"].ToString();
                   txtSoyad.Text = dr["Musteri_soyadi"].ToString();
                   txtTel.Text = dr["Telefon"].ToString();
                   txtEpos.Text = dr["E_posta"].ToString();
                   dtDogumTarihi.Text = dr["Dogum_tarihi"].ToString();
                   cmbSirket.Text = dr["Sirket_isim"].ToString();
                   cmbTip.Text = dr["Sigorta_isim"].ToString();
                   cmbSure.Text = dr["Sigorta_suresi"].ToString();
                   txtFiyat.Text = dr["Fiyat"].ToString();
                   dtBaslama.Text = dr["Baslama"].ToString();
                   dtBitis.Text = dr["Bitis"].ToString();
                   txtCadde.Text = dr["Cadde"].ToString();
                   txtMahalle.Text = dr["Mahalle"].ToString();
                   txtBina.Text = dr["Bina_no"].ToString();
                   txtSehir.Text = dr["Sehir"].ToString();
                   txtPostaKodu.Text = dr["Posta_kodu"].ToString();
                   txtUlke.Text = dr["Ulke"].ToString();




               }   
           }
           catch(SqlException ex)
           {
               MessageBox.Show(ex.Message);
           }
           finally
           {
              conn.Close();
              
           }


       }

       private void btnGuncel_Click(object sender, EventArgs e)
       {
            try
           {
               if (txtTC1.Text == null || txtSoyad.Text == "" || txtSoyad.Text == "" || txtEpos.Text == "" || txtTel.Text==""
                   || txtCadde.Text == "" || txtMahalle.Text == "" || txtBina.Text == "" || txtSehir.Text == "" || txtPostaKodu.Text==""
                   || txtUlke.Text == "" || cmbTip.Text=="")
               {
                   MessageBox.Show("Güncelleme işlemi boş alan bıraktığınız için gerçekleşmedi !!");
               }
               else {
                   conn.Open();
                   comm.Connection = conn;
                   comm.Parameters.AddWithValue("@Cadde", txtCadde.Text);
                   comm.Parameters.AddWithValue("@Mahalle", txtMahalle.Text);
                   comm.Parameters.AddWithValue("@Bina_no", txtBina.Text);
                   comm.Parameters.AddWithValue("@Sehir", txtSehir.Text);
                   comm.Parameters.AddWithValue("@Posta_kodu", txtPostaKodu.Text);
                   comm.Parameters.AddWithValue("@Ulke", txtUlke.Text);
                   comm.CommandText = "UPDATE ADRES SET  Cadde=@Cadde,Mahalle=@Mahalle,Bina_no=@Bina_no,Sehir=@Sehir,Posta_kodu=@Posta_kodu,Ulke=@Ulke WHERE Adres_no= '"+ AID.Text+"' ";
                   comm.ExecuteNonQuery();
                   

                   comm.Parameters.AddWithValue("@Musteri_isim", txtAd.Text);
                   comm.Parameters.AddWithValue("@Musteri_soyadi", txtSoyad.Text);
                   comm.Parameters.AddWithValue("@E_posta", txtEpos.Text);
                   comm.Parameters.AddWithValue("@Telefon", txtTel.Text);
                   comm.Parameters.AddWithValue("@Dogum_tarihi", dtDogumTarihi.Value);
                   comm.Parameters.AddWithValue("@Musteri_tc", txtTC1.Text);
                   comm.CommandText = "UPDATE  MUSTERI SET Musteri_isim=@Musteri_isim,Musteri_soyadi=@Musteri_soyadi,E_posta=@E_posta,Telefon=@Telefon,Dogum_tarihi=@Dogum_tarihi,Musteri_tc=@Musteri_tc WHERE Musteri_id= '" + MID.Text + "'";
                   comm.ExecuteNonQuery();

                   
                   
                   comm.Parameters.AddWithValue("@Sigorta_isim", cmbTip.Text);
                   comm.Parameters.AddWithValue("@Sigorta_suresi", cmbSure.Text);
                   comm.CommandText = "UPDATE  SİGORTA_CESİTLERİ  SET Sigorta_isim=@Sigorta_isim,Sigorta_suresi=@Sigorta_suresi WHERE Sigorta_id ='"+SID.Text+"'";
                   comm.ExecuteNonQuery();

                  

                   
                   String odemeSekli = "";
                   if (radioPesin.Checked)
                       odemeSekli = radioPesin.Text;
                   else if (radioBankamatik.Checked)
                       odemeSekli = radioBankamatik.Text;
                   else if (radioKredi.Checked)
                       odemeSekli = radioKredi.Text;
                   comm.Parameters.AddWithValue("@Odeme_sekli", odemeSekli);
                   comm.Parameters.AddWithValue("@Fiyat", txtFiyat.Text);
                   comm.CommandText = "UPDATE TUTAR SET Odeme_sekli=@Odeme_sekli,Fiyat=@Fiyat WHERE Tutar_id='"+TID.Text+"'";
                   comm.ExecuteNonQuery();
                   

                  
                   comm.Parameters.AddWithValue("@Baslama", dtBaslama.Value);
                   comm.Parameters.AddWithValue("@Bitis", dtBitis.Value);
                   comm.CommandText = "UPDATE BASLAMA_BITIS SET Baslama=@Baslama,Bitis=@Bitis WHERE Tarih_no='"+BBID.Text+"'";
                   comm.ExecuteNonQuery();

                   MessageBox.Show("Güncelleme Başarılı", "Güncelleme İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);


       

               }
           }
           catch(SqlException ex)
           {
               MessageBox.Show(ex.Message);
           }
           finally
           {
               conn.Close();
               comm.Parameters.Clear();
           }

           
           

       }

       private void txtTemizle2_Click(object sender, EventArgs e)
       {
           lvMusteri.Items.Clear();
       }

       private void btnAra_Click(object sender, EventArgs e)
       {

           try
           {
               conn.Open();
               comm.Connection = conn;
               comm.CommandText = "select * from KAYIT K LEFT JOIN MUSTERI M on (K.Müsteri_id=M.Musteri_id) LEFT JOIN ADRES A on (M.Adres_no= A.Adres_no) LEFT JOIN SIRKET_CESIT SC ON(K.ID=SC.ID) LEFT JOIN SIGORTA_SIRKETLERI SS ON(SC.Sirket_id=SS.Sirket_id) LEFT JOIN SİGORTA_CESİTLERİ SCT ON(SCT.Sigorta_id=SC.Sigorta_id) LEFT JOIN TUTAR  TT ON(SC.Tutar_id=TT.Tutar_id) LEFT JOIN BASLAMA_BITIS BB ON (K.Tarih_no=BB.Tarih_no) where Musteri_tc ='" + txtTc2.Text + "' ";
               SqlDataReader dr = comm.ExecuteReader();
               int dizi = 0;
               lvMusteri.Items.Clear();
               while (dr.Read())
               {
                   Kayit_id = dr["Kayit_no"].ToString();
                   ID = dr["ID"].ToString();
                   Sigorta_id = dr["Sigorta_id"].ToString();
                   Tutar_id = dr["Tutar_id"].ToString();
                   Musteri_id = dr["Müsteri_id"].ToString();
                   Adres_no = dr["Adres_no"].ToString();


                   dizi = lvMusteri.Items.Count;
                   lvMusteri.Items.Add(dr["Musteri_tc"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Musteri_isim"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Musteri_soyadi"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Sigorta_isim"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Sirket_isim"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Baslama"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Bitis"].ToString());
                   MusteriRenklendirme();


               }
           }
           catch (SqlException ex)
           {
               MessageBox.Show(ex.Message);
           }
           finally
           {
               conn.Close();
           }






       }

       private void btnHepGos_Click(object sender, EventArgs e)
       {

           try
           {
               conn.Open();
               comm.Connection = conn;
               comm.CommandText = "select * from KAYIT K LEFT JOIN MUSTERI M on (K.Müsteri_id=M.Musteri_id) LEFT JOIN ADRES A on (M.Adres_no= A.Adres_no) LEFT JOIN SIRKET_CESIT SC ON(K.ID=SC.ID) LEFT JOIN SIGORTA_SIRKETLERI SS ON(SC.Sirket_id=SS.Sirket_id) LEFT JOIN SİGORTA_CESİTLERİ SCT ON(SCT.Sigorta_id=SC.Sigorta_id) LEFT JOIN TUTAR  TT ON(SC.Tutar_id=TT.Tutar_id) LEFT JOIN BASLAMA_BITIS BB ON (K.Tarih_no=BB.Tarih_no) ";
               SqlDataReader dr = comm.ExecuteReader();
               int dizi = 0;
               lvMusteri.Items.Clear();
               while (dr.Read())
               {
                   dizi = lvMusteri.Items.Count;
                   lvMusteri.Items.Add(dr["Musteri_tc"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Musteri_isim"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Musteri_soyadi"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Sigorta_isim"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Sirket_isim"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Baslama"].ToString());
                   lvMusteri.Items[dizi].SubItems.Add(dr["Bitis"].ToString());
                   MusteriRenklendirme();


               }
           }
           catch (SqlException ex)
           {
               MessageBox.Show(ex.Message);
           }
           finally
           {
               conn.Close();
           }






       }

       private void btnSil_Click(object sender, EventArgs e)
       {

           try
           {
               conn.Open();
               comm.Connection = conn;
               comm.CommandText = "Delete from KAYIT where Kayit_no = '" + Kayit_id + "'";
               comm.ExecuteNonQuery();
               comm.CommandText = "Delete from SIRKET_CESIT where ID = '" + ID+ "'";
               comm.ExecuteNonQuery();
               comm.CommandText = "Delete from SİGORTA_CESİTLERİ where Sigorta_id = '" + Sigorta_id + "'";
               comm.ExecuteNonQuery();
               comm.CommandText = "Delete from TUTAR where Tutar_id = '" + Tutar_id + "'";
               comm.ExecuteNonQuery();
               comm.CommandText = "Delete MUSTERI from  where Müsteri_id = '" + Musteri_id + "'";
               comm.ExecuteNonQuery();
               comm.CommandText = "Delete ADRES from  where Müsteri_id = '" + Adres_no + "'";
               comm.ExecuteNonQuery();


           }
           catch(SqlException ex)
           {
               MessageBox.Show("Silme Gercekleşti");
           }
           finally
           {
               conn.Close();
           }


       }

       private void btnSirketTemizle_Click(object sender, EventArgs e)
       {
           txtSirket.Text = "";
           txtTicari.Text = "";
           txtVergi.Text = "";
           txtAciklama.Text = "";
           txtCadde2.Text = "";
           txtMah2.Text = "";
           txtBina2.Text = "";
           txtSehir2.Text = "";
           txtPostaKodu2.Text = "";
           txtUlke2.Text = "";
           txtBanka.Text = "";
           txtIBAN.Text = "";
       }

       private void btnEkle_Click(object sender, EventArgs e)
       {

           if (txtSirket.Text == "" || txtTicari.Text == "" || txtVergi.Text == "" || txtAciklama.Text == "" || txtCadde2.Text == "" || txtMah2.Text == "" || txtBina2.Text == "" || txtSehir2.Text == "" || txtUlke2.Text == "" || txtPostaKodu2.Text == "" || txtBanka.Text == "" || txtIBAN.Text == "")
           {
               MessageBox.Show("Lütfen bütün alanları giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {


               try
               {
                   conn.Open();
                   comm.Connection = conn;
                   comm.Parameters.AddWithValue("@Cadde", txtCadde2.Text);
                   comm.Parameters.AddWithValue("@Mahalle", txtMah2.Text);
                   comm.Parameters.AddWithValue("@Bina_no", txtBina2.Text);
                   comm.Parameters.AddWithValue("@Sehir", txtSehir2.Text);
                   comm.Parameters.AddWithValue("@Posta_kodu", txtPostaKodu2.Text);
                   comm.Parameters.AddWithValue("@Ulke", txtUlke2.Text);
                   comm.CommandText = "INSERT INTO ADRES (Cadde,Mahalle,Bina_no,Sehir,Posta_kodu,Ulke) VALUES (@Cadde,@Mahalle,@Bina_no,@Sehir,@Posta_kodu,@Ulke)";
                   comm.ExecuteNonQuery();



                   comm.Parameters.AddWithValue("@Ticari_unvani", txtTicari.Text);
                   comm.Parameters.AddWithValue("@Vergi_numarasi", txtVergi.Text);
                   comm.Parameters.AddWithValue("@Sirket_isim", txtSirket.Text);
                   comm.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);

                   comm.CommandText = "INSERT INTO SIGORTA_SIRKETLERI (Ticari_unvani,Adres_no,Vergi_numarasi,Sirket_isim,Aciklama) VALUES (@Ticari_unvani,IDENT_CURRENT('ADRES'),@Vergi_numarasi,@Sirket_isim,@Aciklama)";
                   comm.ExecuteNonQuery();


                   comm.Parameters.AddWithValue("@Banka_adi", txtBanka.Text);
                   comm.Parameters.AddWithValue("@IBAN_no", txtIBAN.Text);

                   comm.CommandText = "INSERT INTO SIGORTA_SIRKET_HESAPLARI (Banka_adi,IBAN_no,Sirket_id) VALUES ( @Banka_adi,@IBAN_no,IDENT_CURRENT('SIGORTA_SIRKETLERI') )";
                   comm.ExecuteNonQuery();
                   MessageBox.Show("Kayit basarılı", "KAYIT İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
       }

       private void btnGecmis_Click(object sender, EventArgs e)
       {

           try
           {
               conn.Open();
               comm.Connection = conn;
               comm.CommandText = "select * from KAYIT K LEFT JOIN MUSTERI M on (K.Müsteri_id=M.Musteri_id) LEFT JOIN ADRES A on (M.Adres_no= A.Adres_no) LEFT JOIN SIRKET_CESIT SC ON(K.ID=SC.ID) LEFT JOIN SIGORTA_SIRKETLERI SS ON(SC.Sirket_id=SS.Sirket_id) LEFT JOIN SİGORTA_CESİTLERİ SCT ON(SCT.Sigorta_id=SC.Sigorta_id) LEFT JOIN TUTAR  TT ON(SC.Tutar_id=TT.Tutar_id) LEFT JOIN BASLAMA_BITIS BB ON (K.Tarih_no=BB.Tarih_no) WHERE Bitis <='" + DateTime.Now + "' ";
               SqlDataReader dr = comm.ExecuteReader();
               int dizi = 0;
               lvGecmis.Items.Clear();
               while (dr.Read())
               {
                   dizi = lvGecmis.Items.Count;
                   lvGecmis.Items.Add(dr["Musteri_tc"].ToString());
                   lvGecmis.Items[dizi].SubItems.Add(dr["Musteri_isim"].ToString());
                   lvGecmis.Items[dizi].SubItems.Add(dr["Musteri_soyadi"].ToString());
                   lvGecmis.Items[dizi].SubItems.Add(dr["Sigorta_isim"].ToString());
                   lvGecmis.Items[dizi].SubItems.Add(dr["Sirket_isim"].ToString());
                   lvGecmis.Items[dizi].SubItems.Add(dr["Baslama"].ToString());
                   lvGecmis.Items[dizi].SubItems.Add(dr["Bitis"].ToString());
                   GecmisRenklendirme();

               }
           }
           catch (SqlException ex)
           {
               MessageBox.Show(ex.Message);
           }
           finally
           {
               conn.Close();
           }
           

       }


       private void MusteriRenklendirme()
       {
           ListView lv = this.lvMusteri;
           int i = 0;
           Color renk = Color.FromArgb(240, 240, 240);
           foreach (ListViewItem item in lv.Items)
           {
               item.BackColor = Color.Green;
               item.UseItemStyleForSubItems = true;
           }




       }

       private void GecmisRenklendirme()
       {
           ListView lv = this.lvGecmis;
           int i = 0;
           Color renk = Color.FromArgb(240, 240, 240);
           foreach (ListViewItem item in lv.Items)
           {
               item.BackColor = Color.Gray;
               item.UseItemStyleForSubItems = true;
           }
       }


       }







       


    
}
