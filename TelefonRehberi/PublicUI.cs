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
    public partial class PublicUI : Form
    {
        public PublicUI()
        {
            InitializeComponent();
        }

        Sqlbaglantisi bgl = new Sqlbaglantisi();
        string getir;
        private void PublicUI_Load(object sender, EventArgs e)
        {
            //datagride isim soyisim ve telefon bilgileri çekmek için
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select id,ad,soyad,telefon From Tbl_Bilgi", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listBox1.Visible = true;
            


            //datagridden seçilen kişiyle ilgili daha detaylı bilgi görebilmek için
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            getir = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

                SqlCommand komut = new SqlCommand("select ad,soyad,departman,yoneticibilgi,telefon from Tbl_Bilgi where ad=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", getir);
                SqlDataReader dr = komut.ExecuteReader();
                
                while (dr.Read())
                {
                    listBox1.Items.Add("Ad Soyad: " + dr[0] + " " + dr[1] + "..  Departman : " + dr[2] + "..  Meslek : " + dr[3] + "..  Telefon : " + dr[4]);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Giris frm = new Giris();
            frm.Show();
            this.Hide();
        }
    }
}
