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
using System.IO;

namespace TelefonRehberi
{
    public partial class AdminUI : Form
    {
        public AdminUI()
        {
            InitializeComponent();
        }

        Sqlbaglantisi bgl = new Sqlbaglantisi();
        public string admin;
        public string rutbe;
   

        private void AdminUI_Load(object sender, EventArgs e)
        {
            AdminUI.ActiveForm.Refresh();
            //Oturumda kimin olduğunu anlamak için 
            LblAdmin.Text = admin;
            LblPuan.Text = rutbe;

        //Admin bilgisi çekmek için
        SqlCommand komut = new SqlCommand("select kullaniciad From Tbl_Admin where kullaniciad=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblAdmin.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdmin.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();


            //Yetki puanını çekmek için
            SqlCommand komut2 = new SqlCommand("Select puan From Tbl_Yonetim where yonetim=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", LblPuan.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblPuan.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();


            // Departman Çekmek için
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select (departmanad) as 'Departman' From Tbl_Departmanlar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            
            //Yönetim çekmek için
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (yonetim) as 'Yönetim',departman as 'Departman' from Tbl_Yonetim ", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;




            //Kişinin Rütbesini bir dosyaya kaydediyoruz
            string dosya_yolu = "TextFile1.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(LblPuan.Text);
            sw.Flush();
            sw.Close();
            fs.Close();

   


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            PersonelDuzenle frm = new PersonelDuzenle();
            frm.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control frm = new Control();
            frm.Show();
            this.Hide();
        }

        private void BtnDepartmanBilgi_Click(object sender, EventArgs e)
        {
            DepartmanDuzenle frm = new DepartmanDuzenle();
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminBilgiDuzenle frm = new AdminBilgiDuzenle();
            frm.Show();
        }
    }
}
