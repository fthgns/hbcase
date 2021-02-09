using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalOdev_HTS_Otomasyon
{
    public partial class HastaEkle : Form
    {
        public HastaEkle()
        {
            InitializeComponent();
        }

        private void HastaEkle_Load(object sender, EventArgs e)
        {
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Length == 0 || txtSoyad.Text.Length == 0)
            {
                MessageBox.Show("Tüm Bilgileri Giriniz.", "Uyarı!");
                return;
            }

            SqlConnection conn = new SqlConnection(Globals.ConnectionString);
            SqlCommand cmdHastaEkle = new SqlCommand(@"INSERT INTO [dbo].[tblHasta]
           ([DoktorID]
           ,[Ad]
           ,[Soyad]
           ,[TC]
           ,[DogumTarihi]
           ,[KayitTarihi]
           ,[Cinsiyet]
           ,[Adres]
           ,[Telefon])
     VALUES
           (@DoktorID
           ,@Ad
           ,@Soyad
           ,@TC
           ,@DogumTarihi
           ,@KayitTarihi
           ,@Cinsiyet
           ,@Adres
           ,@Telefon)", conn);
            cmdHastaEkle.Parameters.Add(new SqlParameter("DoktorID", Globals.AktifDoktor.DoktorID));
            cmdHastaEkle.Parameters.Add(new SqlParameter("Ad", txtAd.Text));
            cmdHastaEkle.Parameters.Add(new SqlParameter("Soyad", txtSoyad.Text)); 
            cmdHastaEkle.Parameters.Add(new SqlParameter("TC", txtTC.Text)); 
            cmdHastaEkle.Parameters.Add(new SqlParameter("DogumTarihi", dtDogum.Value));
            cmdHastaEkle.Parameters.Add(new SqlParameter("KayitTarihi", DateTime.Now));
            cmdHastaEkle.Parameters.Add(new SqlParameter("Cinsiyet", cbCinsiyet.SelectedText));
            cmdHastaEkle.Parameters.Add(new SqlParameter("Adres", txtAdres.Text));
            cmdHastaEkle.Parameters.Add(new SqlParameter("Telefon", txtTelefon.Text));
            conn.Open();
            if (cmdHastaEkle.ExecuteNonQuery()>0)
            {
                MessageBox.Show("Hasta Başarıyla Eklendi","Başarılı");

                AnaSayfa form = new AnaSayfa();
                    form.Show();
                    this.Close();
            }
        }
    }
}
