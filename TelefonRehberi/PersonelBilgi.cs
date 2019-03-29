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
    public partial class PersonelDuzenle : Form
    {
        public PersonelDuzenle()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();


        private void BtnEkle_Click_1(object sender, EventArgs e)        //Yeni personel eklemek için
        {
            if(TxtAd.Text== "" || TxtSoyad.Text == "" || !MskTelefon.MaskFull)
            {
                MessageBox.Show("Lütfen Ad Soyad ve Telefon kısmını doldurun");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Bilgi (ad,soyad,telefon,departman,yoneticibilgi,TC) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", MskTelefon.Text);
                komut.Parameters.AddWithValue("@p4", CmbDepartman.Text);
                komut.Parameters.AddWithValue("@p5", CmbYonetim.Text);
                komut.Parameters.AddWithValue("@p6", MskTC.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SqlCommand komut2 = new SqlCommand("Select * From Tbl_Bilgi", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut2);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnSil_Click_1(object sender, EventArgs e)     //Personel silmek için
        {
            //Silmek istenen kişinin rütbesi
            SqlCommand komut = new SqlCommand("Select puan from Tbl_Yonetim where yonetim=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbYonetim.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text=dr[0].ToString();
            }
            bgl.baglanti().Close();

            if(int.Parse(label8.Text)>int.Parse(label4.Text))       //oturumdaki kişi ile silmek istenen karşılaştırmak için
            {
                SqlCommand komutsil = new SqlCommand("Delete From Tbl_Bilgi where TC=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", MskTC.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bu kişiyi silmeye yetkiniz yok!");
            }

            SqlCommand komut2 = new SqlCommand("Select * From Tbl_Bilgi", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut2);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)        //Personel Bilgilerini güncellemek için
        {
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Bilgi set ad=@p1,soyad=@p2,telefon=@p3,departman=@p4,yoneticibilgi=@p5 where TC=@p6", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", TxtAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", MskTelefon.Text);
            komutguncelle.Parameters.AddWithValue("@p4", CmbDepartman.Text);
            komutguncelle.Parameters.AddWithValue("@p5", CmbYonetim.Text);
            komutguncelle.Parameters.AddWithValue("@p6", MskTC.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SqlCommand komut = new SqlCommand("Select * From Tbl_Bilgi", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //Datagridin hücresine tıklancığında bilgilerin Textboxa aktarılması için
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            MskTelefon.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            CmbDepartman.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            CmbYonetim.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            MskTC.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

       

        private void PersonelDuzenle_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'telefonDataSet1.Tbl_Bilgi' table. You can move, or remove it, as needed.
            this.tbl_BilgiTableAdapter.Fill(this.telefonDataSet1.Tbl_Bilgi);
            //Personel Bilgilerini çekmek için
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Bilgi ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //comboboxa departmanları çekmek için
            SqlCommand komut2 = new SqlCommand("Select departmanad From Tbl_Departmanlar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbDepartman.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();


            //comboboxa yönetim bilgisi çekmek için
            SqlCommand komut3 = new SqlCommand("Select yonetim From Tbl_Yonetim", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                CmbYonetim.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();

            //dosyadaki yazıyı okuyup oturumda kimin olduğu bilgisi çekiliyor
            string dosya_yolu = "TextFile1.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                Console.WriteLine(yazi);
                label8.Text = yazi;
                yazi = sw.ReadLine();
                
            }
            
            sw.Close();
            fs.Close();

        }

        private void CmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Departman combobox ında seçilen veriye göre yönetim combobox ında alakalı seçenekler çıkması için 
            CmbYonetim.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select yonetim from Tbl_yonetim where departman=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", CmbDepartman.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                CmbYonetim.Items.Add(dr3[0]);
            }

            bgl.baglanti().Close();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            //Arama yapmak için
            SqlCommand komut = new SqlCommand("Select * From Tbl_Bilgi where ad like '%" + TxtAra.Text + "%'", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

    }
}
