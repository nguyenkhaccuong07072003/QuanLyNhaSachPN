using QuanLyNhaSachPN.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyNhaSachPN
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        Connect con = new Connect();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from NguoiDung where taikhoan = '{0}' and matkhau = '{1}'"
                , txtTaiKhoan.Text, txtMatKhau.Text);
            DataSet ds = con.LayDuLieu(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Đăng nhập thành công");
                TrangChu frm = new TrangChu();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKy frm = new DangKy();
            frm.Show();
            this.Hide();
        }
    }
}
