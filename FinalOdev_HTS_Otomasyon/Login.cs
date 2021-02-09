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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Giriniz.","Uyarı!");
                return;
            }

            SqlConnection conn = new SqlConnection(Globals.ConnectionString);
            SqlCommand cmdLogin = new SqlCommand("SELECT * FROM tblDoktor WHERE KullaniciAdi=@UserName and Sifre=@Password", conn);
            cmdLogin.Parameters.Add(new SqlParameter("UserName", txtUserName.Text));
            cmdLogin.Parameters.Add(new SqlParameter("Password", txtPassword.Text));
            conn.Open();
            var reader = cmdLogin.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    Globals.AktifDoktor = new Doktor
                    {
                        Ad = reader["Ad"].ToString(),
                        Soyad = reader["Soyad"].ToString(),
                        DiplomaNo = reader["DiplomaNo"].ToString(),
                        DoktorID = Int32.Parse(reader["DoktorID"].ToString()),
                        Sicil = reader["Sicil"].ToString()
                    };

                    MessageBox.Show("Sayın Dr." + Globals.AktifDoktor.Ad + " " + Globals.AktifDoktor.Soyad + " Hoş Geldiniz.", "Giriş Başarılı");
              
                    AnaSayfa form=new AnaSayfa();
                    form.Tag = this;
                    form.Show();      
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifrenizi Hatalı Girdiniz.","Giriş Başarısız");
            }
            conn.Close();
        }
    }
}
