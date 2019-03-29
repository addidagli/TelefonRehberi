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
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
        }

        Sqlbaglantisi bgl = new Sqlbaglantisi();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            
            //Kullanıcı Adı ve Şifre Kontrolü
            SqlCommand komut = new SqlCommand("Select * From Tbl_Admin where kullaniciad=@p1 and sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                AdminUI frm = new AdminUI();
                frm.admin = txtKullaniciAdi.Text;
                frm.rutbe = CmbYonetim.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış");
            }
            bgl.baglanti().Close();
        }

        private void Control_Load(object sender, EventArgs e)       //combobox ı yönetici bilgileriyle doldurmak için
        {
            SqlCommand komut3 = new SqlCommand("Select yonetim From Tbl_Yonetim", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                CmbYonetim.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            Giris frm = new Giris();
            frm.Show();
            this.Hide();
        }
    }
}

