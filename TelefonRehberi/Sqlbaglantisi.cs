using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TelefonRehberi
{
    class Sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9FKNVJM\\SQLEXPRESS;Initial Catalog=Telefon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
