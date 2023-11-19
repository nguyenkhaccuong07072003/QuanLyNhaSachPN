using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSachPN.DAO
{
    class Connect
    {
        string constr = @"Data Source=DESKTOP-2MC26TB\SQLEXPRESS;Initial Catalog=QLNSPN;Integrated Security=True";
        SqlConnection conn;
        public Connect()
        {
            conn = new SqlConnection(constr);
        }
        public DataSet LayDuLieu(string truyvan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(truyvan, conn);
                da.Fill(ds);

            }
            catch { }
            return ds;
        }
        public bool ThucThi(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
       
    }

}
