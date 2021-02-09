using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalOdev_HTS_Otomasyon
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            if (Globals.AktifDoktor != null)
            {
                lblInfo.Text = "Dr." + Globals.AktifDoktor.Ad + " " + Globals.AktifDoktor.Soyad;
            }
        }

        private void btnHastaEkle_Click(object sender, EventArgs e)
        {
            var form = new HastaEkle();
            form.Tag = this;
            this.Close();
            form.Show();
        }
    }
}
