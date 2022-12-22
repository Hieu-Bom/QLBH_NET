using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiKT
{
    internal class Ketnoi
    {
        private static string DiaChi = @"Data Source=Duchieu\hieubom;Initial Catalog=NinhDucHieu_qlsv;Integrated Security=True";
        public static SqlConnection TaoDuongOng()
        {
            return new SqlConnection(DiaChi);
        }

        public static DataTable LayBang(string sql)
        {
            SqlConnection Conn = TaoDuongOng();
            Conn.Open();
            DataTable Da = new DataTable();
            SqlDataAdapter Rs = new SqlDataAdapter(sql, Conn);
            Rs.Fill(Da);
            Rs.Dispose();
            Conn.Dispose();
            return Da;
        }
        public static void ThemSuaXoa(string sql)
        {
            SqlConnection Conn = TaoDuongOng();
            Conn.Open();
            SqlCommand Lenh = new SqlCommand(sql, Conn);
            Lenh.ExecuteNonQuery();
            Lenh.Dispose();
            Conn.Dispose();
        }
    }
}
