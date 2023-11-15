using QuanLyNhaSachPN.DAO;
using QuanLyNhaSachPN.View;
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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        Connect con = new Connect();
        private string CheckQH()
        {
            //Lấy tên tài khoản từ login
            string tk = DangNhap.Taikhoan;

            //Kiểm tra chức danh của tài khoản
            string sql = string.Format("select CHUCDANH from NGUOIDUNG where TAIKHOAN = '{0}'", tk);
            DataSet ds = con.LayDuLieu(sql);

            //Trả về kết quả của hàm Check quyền hạn
            return ds.Tables[0].Rows[0]["CHUCDANH"].ToString();
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {
            if(CheckQH() == "Nhan Vien")
            {
                btnQLNV.Enabled = false;
                btnQLNCC.Enabled = false;
                btnThongKe.Enabled = false;
            }    
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {

        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            openChildForm(new QLNV());
        }

        private void btnQLBH_Click(object sender, EventArgs e)
        {
            openChildForm(new QLHD());
        }

        private void btnQLK_Click(object sender, EventArgs e)
        {
            openChildForm(new QLK());
        }

        private void btnQLNCC_Click(object sender, EventArgs e)
        {
            openChildForm(new QLNCC());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            openChildForm(new BaoCao());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap frm = new DangNhap();
            frm.Show();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
