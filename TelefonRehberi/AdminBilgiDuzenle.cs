using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TelefonRehberi
{
    public partial class AdminBilgiDuzenle : Form
    {
        public AdminBilgiDuzenle()
        {
            InitializeComponent();
        }

        Sqlbaglantisi bgl = new Sqlbaglantisi();

        private void BtnKaydet_Click(object sender, EventArgs e)         // Şifre Güncellemek için
        {
            SqlCommand komut = new SqlCommand("update Tbl_Admin set sifre=@p1 where kullaniciad=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtYeniSifre.Text);
            komut.Parameters.AddWithValue("@p2", TxtKullaniciAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifreniz Değiştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
