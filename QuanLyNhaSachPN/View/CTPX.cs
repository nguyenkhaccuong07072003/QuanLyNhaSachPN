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

namespace QuanLyNhaSachPN.View
{
    public partial class CTPX : Form
    {
        private string maPX;
        Connect con = new Connect();
        public CTPX()
        {
            InitializeComponent();
        }
        public CTPX(string maPX)
        {
            InitializeComponent();
            this.maPX = maPX;
        }
        public void getdata()
        {
            string query = String.Format("Select * from CHITIETPHIEUXUAT where  MAPHIEUXUAT = '{0}' ", maPX);
            DataSet ds = con.LayDuLieu(query);
            dgvCTPX.DataSource = ds.Tables[0];
        }
        public void getmahang()
        {
            string query = "select * from HANG";
            DataSet ds = con.LayDuLieu(query);
            cbMaHang.DataSource = ds.Tables[0];
            cbMaHang.DisplayMember = "TenHang";
            cbMaHang.ValueMember = "MaHang";
        }
        public void clear()
        {
            txtMaPX.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            cbMaHang.SelectedValue = "";
            nbrSoLuong.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (nbrSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                string query = string.Format("insert into CHITIETPHIEUXUAT values(N'{0}',N'{1}',N'{2}')"
                , maPX, cbMaHang.SelectedValue, nbrSoLuong.Value);
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
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format("update CHITIETPHIEUXUAT set MAHANG = N'{1}', SOLUONG=N'{2}' where MAPHIEUXUAT=N'{0}' and MAHANG = '{1}'"
                , maPX, cbMaHang.SelectedValue,nbrSoLuong.Text);

            DataSet ds = con.LayDuLieu(query);
            bool kt = con.ThucThi(query);
            if (kt == true)
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
            string query = string.Format("Delete CHITIETPHIEUXUAT where MAHANG = N'{0}'", cbMaHang.SelectedValue);
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
            string query = string.Format("select * from CHITIETPHIEUXUAT where " +
                "MAHANG like N'%{0}%' or " +
                "SOLUONG like N'%{0}%' or " +
               txtTim.Text
               );
            try
            {
                DataSet ds = con.LayDuLieu(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvCTPX.DataSource = ds.Tables[0];
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

        private void CTPX_Load(object sender, EventArgs e)
        {
            getdata();
            getmahang();
            txtMaPX.Enabled = false;
            txtMaPX.Text = maPX;
        }

        private void dgvCTPX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaPX.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                txtMaPX.Text = dgvCTPX.Rows[r].Cells["MAPHIEUXUAT"].Value.ToString();
                cbMaHang.SelectedValue = dgvCTPX.Rows[r].Cells["MAHANG"].Value.ToString();
                nbrSoLuong.Value = Decimal.Parse(dgvCTPX.Rows[r].Cells["SOLUONG"].Value.ToString());
            }
        }

    }
}
