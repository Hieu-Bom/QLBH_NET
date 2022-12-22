using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiKT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void clean()
        {
            txtmasv.Text = "";
            txthoten.Text = "";
            txtquequan.Text = "";
            txtrl.Text = "";
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            string sql = "insert into sinhvien values(N'" +
                txtmasv + "', N'" +
                txthoten + "', N'" +
                txtngaysinh + "', N'" +
                cbgioitinh + "', N'" +
                txtquequan + "', N'" +
                txtrl + "', N'" +
                cbmk + "')";
            Ketnoi.ThemSuaXoa(sql);
            datadanhsach.DataSource = Ketnoi.LayBang("select * from sinhvien");
            clean();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE sinhvien SET Ten = N'" +
                txthoten.Text + "', N'" +
                txtngaysinh.Text + "', N'" +
                cbgioitinh.Text + "', N'" +
                txtquequan.Text + "', N'" +
                txtrl.Text + "', N'" +
                cbmk.Text + "' where masv =N'" +
                txtmasv.Text + "' ";
            Ketnoi.ThemSuaXoa(sql);
            datadanhsach.DataSource = Ketnoi.LayBang(
               "select * from sinhvien");
            clean();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from sinhvien where masv =N'" +
                txtmasv.Text + "'";
            Ketnoi.ThemSuaXoa(sql);
            datadanhsach.DataSource = Ketnoi.LayBang(
             "select * from sinhvien");
            MessageBox.Show("Đã xóa!", "Thống báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            clean();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txttimkiem.Text.Trim() == "")
                sql = "select * from sinhvien";
            else
                sql = "select * from sinhvien where hoten like N'" +
                   txttimkiem.Text + "%'";

            datadanhsach.DataSource = Ketnoi.LayBang(sql);
            clean();
        }

        private void QLSV_Load(object sender, EventArgs e)
        {
            datadanhsach.DataSource = Ketnoi.LayBang(
                "select * from sinhvien");
            datadanhsach.Columns[0].HeaderText = "Mã SV";
            datadanhsach.Columns[1].HeaderText = "Họ Tên";
            datadanhsach.Columns[2].HeaderText = "Ngày Sinh";
            datadanhsach.Columns[3].HeaderText = "Quê Quán";
            datadanhsach.Columns[4].HeaderText = "Điểm";
            datadanhsach.Columns[5].HeaderText = "Mã Khoa";

            datadanhsach.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            datadanhsach.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            datadanhsach.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            datadanhsach.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            datadanhsach.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            datadanhsach.Columns[5].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            SqlDataAdapter da = new SqlDataAdapter("select * from khoa", @"Data Source=DUCHIEU\HIEUBOM;Initial Catalog=NinhDucHieu_qlsv;Integrated Security=True");//SQL là câu truy vấn bảng trong cơ sở dữ liệu, cn là connection đến cơ sở dữ liệu
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbmk.DisplayMember = "tenkhoa";//tenkhoa là tên trường bạn muốn hiển thị trong combobox
            cbmk.ValueMember = "tenkhoa";
            cbmk.DataSource = dt;
        }

    }
}
