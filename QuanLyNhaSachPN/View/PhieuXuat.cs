using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSachPN.DAO;
namespace QuanLyNhaSachPN.View
{
    public partial class PhieuXuat : Form
    {
        public PhieuXuat()
        {
            InitializeComponent();
        }
        Connect con = new Connect();
        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            getdata();
            getMaNV();
        }
        public void getdata()
        {
            string query = "select * from PHIEUXUAT";
            DataSet ds = con.LayDuLieu(query);
            dgvPhieuXuat.DataSource = ds.Tables[0];

            dgvPhieuXuat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuXuat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public void clear()
        {
            txtMaPX.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

            txtMaPX.Text = "";
            cbMaNV.SelectedValue = "";
            dtpNgayXuat.Value = DateTime.Now;
        }
        public void getMaNV()
        {
            string query = "select * from NhanVien";
            DataSet ds = con.LayDuLieu(query);
            cbMaNV.DataSource = ds.Tables[0];
            cbMaNV.DisplayMember = "TenNV";
            cbMaNV.ValueMember = "MaNV";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string checkMAPX = string.Format("select * from PHIEUXUAT where MAPHIEUXUAT = N'{0}'"
                , txtMaPX.Text);
            DataSet ds = con.LayDuLieu(checkMAPX);
            if (ds.Tables[0].Rows.Count == 0)
            {
                string query = string.Format("insert into PHIEUXUAT values(N'{0}',N'{1}',N'{2}')"
                , txtMaPX.Text,cbMaNV.SelectedValue,dtpNgayXuat.Value.ToString("yyyy/MM/dd"));
                bool result = con.ThucThi(query);
                if (result)
                {
                    MessageBox.Show("Thêm thành công");
                    btnReset.PerformClick();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                MessageBox.Show("Mã phiếu xuất đã tồn tại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format("update PHIEUXUAT set MANV = N'{1}', NGAYXUAT =N'{2}' where MAPHIEUXUAT = N'{0}'",
                txtMaPX.Text,
                cbMaNV.SelectedValue,
                dtpNgayXuat.Value.ToString("yyyy/MM/dd")
                );
            bool kt = con.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Sửa thành công");
                btnReset.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format("Delete PHIEUXUAT where MAPHIEUXUAT = N'{0}'", txtMaPX.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool kt = con.ThucThi(query);
                if (kt)
                {
                    MessageBox.Show("Xóa thành công");
                    btnReset.PerformClick();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
            getdata();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from PHIEUXUAT where " +
                "MAPHIEUXUAT like N'%{0}%' or " +
                "MANV like N'%{0}%' or " +
                "NGAYXUAT like N'%{0}%' or " +
                txtTim.Text
                );
            try
            {
                DataSet ds = con.LayDuLieu(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvPhieuXuat.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("No data found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaPX.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                txtMaPX.Text = dgvPhieuXuat.Rows[r].Cells["MAPHIEUXUAT"].Value.ToString();
                cbMaNV.SelectedValue = dgvPhieuXuat.Rows[r].Cells["MANV"].Value.ToString();
                dtpNgayXuat.Text = dgvPhieuXuat.Rows[r].Cells["NGAYXUAT"].Value.ToString();
            }
        }

        private void dgvPhieuXuat_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                CTPX frm = new CTPX(dgvPhieuXuat.Rows[r].Cells["MAPHIEUXUAT"].Value.ToString());
                frm.Show();
            }
        }
    }
}
