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
    public partial class QLHD : Form
    {
        public static string mahd;
        public QLHD()
        {
            InitializeComponent();
        }
        Connect con = new Connect();
        public void getdata()
        {
            string query = "select * from HOADON";
            DataSet ds = con.LayDuLieu(query);
            dgvHoaDon.DataSource = ds.Tables[0];


            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public void clear()
        {
            txtMaHD.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

            txtMaHD.Text = "";
            cbMaNV.SelectedValue = "";
            dtpNglap.Value = DateTime.Now;
            txtThanhtien.Text = "";
            txtTim.Text = "";
        }
        public void getMaNV()
        {
            string query = "select * from NhanVien";
            DataSet ds = con.LayDuLieu(query);
            cbMaNV.DataSource = ds.Tables[0];
            cbMaNV.DisplayMember = "TenNV";
            cbMaNV.ValueMember = "MaNV";
        }
        private void QLHD_Load(object sender, EventArgs e)
        {
            getdata();
            getMaNV();

            txtThanhtien.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            string checkMAHD = string.Format("select * from HOADON where MAHD= N'{0}'"
                         , txtMaHD.Text);
            DataSet ds = con.LayDuLieu(checkMAHD);
            if (ds.Tables[0].Rows.Count == 0)
            {
                string query = string.Format("insert into HOADON values(N'{0}',N'{1}',N'{2}',N'{3}')"
                , txtMaHD.Text, cbMaNV.SelectedValue, dtpNglap.Value.ToString("yyyy/MM/dd"), txtThanhtien.Text);
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
                MessageBox.Show("Mã hóa đơn đã tồn tại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format("update HOADON set " +
                "MANV=N'{1}', NGAYLAP=N'{2}', THANHTIEN=N'{3}' where MAHD=N'{0}'",
                txtMaHD.Text,
                cbMaNV.SelectedValue,
                dtpNglap.Value.ToString("yyyy/MM/dd"),
                txtThanhtien.Text
                );
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
            string query = string.Format("if exists (select count(*) from CHITIETHOADON where MAHD = '{0}' group by MAHD having count(*) > 0) " +
                " begin " +
                    "Delete CHITIETHOADON where MAHD = '{0}' " +
                    "Delete HOADON where MAHD = '{0}' " +
                " end ",txtMaHD.Text);
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
            string query = string.Format("select * from HOADON where " +
                "MAHD like N'%{0}%' or " +
                "MANV like N'%{0}%' or " +
                "NGAYLAP like N'%{0}%' or " +
                "THANHTIEN like N'%{0}%' ",
                txtTim.Text
                );
            try
            {
                DataSet ds = con.LayDuLieu(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvHoaDon.DataSource = ds.Tables[0];
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

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaHD.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                txtMaHD.Text = dgvHoaDon.Rows[r].Cells["MAHD"].Value.ToString();
                cbMaNV.SelectedValue = dgvHoaDon.Rows[r].Cells["MANV"].Value.ToString();
                dtpNglap.Text = dgvHoaDon.Rows[r].Cells["NGAYLAP"].Value.ToString();
                txtThanhtien.Text = dgvHoaDon.Rows[r].Cells["THANHTIEN"].Value.ToString();
            }
        }
        private void dgvHoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                QLCTHD frm = new QLCTHD(dgvHoaDon.Rows[r].Cells["MAHD"].Value.ToString());
                frm.Show();
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                getdata();
            }
        }
    }
}
