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
    public partial class DepartmanDuzenle : Form
    {
        public DepartmanDuzenle()
        {
            InitializeComponent();
        }

        Sqlbaglantisi bgl = new Sqlbaglantisi();

        private void DepartmanDuzenle_Load(object sender, EventArgs e)
        {
            //Datagride Departmanları çekmek için
            yenile();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            //Yeni Departman Eklemek için
            SqlCommand komut = new SqlCommand("insert into Tbl_Departmanlar (departmanad) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtDepartman.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Departman Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            yenile();
            AdminUI.ActiveForm.Refresh();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Departmanda çalışan olup olmadığını kontrol için  
            SqlCommand kontrol = new SqlCommand("select departman, count(*) from Tbl_Yonetim where departman=@p1  group by departman", bgl.baglanti());
            kontrol.Parameters.AddWithValue("@p1", TxtDepartman.Text);
            SqlDataReader dr = kontrol.ExecuteReader();

            if (Convert.ToInt16(dr.Read()) > 0)
            {
                MessageBox.Show("Bu departmanda çalışanlar olduğu için silinemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komutsil = new SqlCommand("Delete From Tbl_Departmanlar where id=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", Txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Departman Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            yenile();
            AdminUI.ActiveForm.Refresh();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //departmanları güncellemek için 
            SqlCommand komut2 = new SqlCommand("Update Tbl_Departmanlar set departmanad=@p1  where id=@p2", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtDepartman.Text);
            komut2.Parameters.AddWithValue("@p2", Txtid.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Departman Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            yenile();
            AdminUI.ActiveForm.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Datagridin hücresine tıklanınca bilgilerin textboxlara aktarılması için
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtDepartman.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        public void yenile()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select id,(departmanad) as 'Departman' From Tbl_Departmanlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
