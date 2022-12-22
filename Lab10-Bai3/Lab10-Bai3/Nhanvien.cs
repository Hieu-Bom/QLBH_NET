using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Lab10_Bai3
{
    class Nhanvien
    {
        Database db;
        public Nhanvien()
        {
            db = new Database();
        }
        public DataTable LayDSNhanvien()
        {
            string strSQL = "Select MaNhanVien,HoTenNhanVien, NgaySinh,DiaChi,Dienthoai,TenBangCap From NHANVIEN N, BANGCAP B Where N.MaBangCap = B.MaBangCap";
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
        public DataTable LayBangcap()
        {
            string strSQL = "Select * from BANGCAP";
            DataTable dt = db.Execute(strSQL); 
            return dt;
        }
        public void XoaNhanVien(string index_nv)
        {
            string sql = "Delete from NHANVIEN where MaNhanVien = " + index_nv;
            db.ExecuteNonQuery(sql);
        }
        //Thêm 1 nhân viên mới
        public void ThemNhanVien(string ten, string ngaysinh, string diachi, string dienthoai, string index_bc)
        {
            string sql = string.Format("Insert Into NHANVIEN Values(N'{0}', '{1}', N'{2}', '{3}', {4})", ten, ngaysinh, diachi, dienthoai, index_bc);
            db.ExecuteNonQuery(sql);
            
        }
        //Cập nhật nhân viên
        public void CapNhatNhanVien(string index_nv, string hoten, string ngaysinh, string diachi, string dienthoai, string index_bc)
        {
            //Chuẩn bị câu lẹnh truy vấn
            string str = string.Format("Update NHANVIEN set HoTenNhanVien = N'{0}', NgaySinh = '{1}', DiaChi =N'{2}', DienThoai = '{3}', MaBangCap = {4} where MaNhanVien = {5}", hoten, ngaysinh, diachi, dienthoai, index_bc, index_nv);
            db.ExecuteNonQuery(str);
        }

    }
}
