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
    public partial class PhieuNhap : Form
    {
        public PhieuNhap()
        {
            InitializeComponent();
        }
        Connect con = new Connect();
        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            getdata();
            getMaNCC();
            getMaNV();
            txtTongTien.Enabled = false;
        }
        public void getdata()
        {
            string query = "select * from PHIEUNHAP";
            DataSet ds = con.LayDuLieu(query);
            dgvPhieuNhap.DataSource = ds.Tables[0];

            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public void clear()
        {
            txtMaPN.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

            txtMaPN.Text = "";
            cbMaNCC.SelectedValue = "";
            cbMaNV.SelectedValue = "";
            dtpNgayNhap.Value = DateTime.Now;
            txtTongTien.Text = "";
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
        public void getMaNCC()
        {
            string query = "select * from NHACUNGCAP";
            DataSet ds = con.LayDuLieu(query);
            cbMaNCC.DataSource = ds.Tables[0];
            cbMaNCC.DisplayMember = "TenNCC";
            cbMaNCC.ValueMember = "MaNCC";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string checkMAPN = string.Format("select * from PHIEUNHAP where MAPHIEUNHAP = N'{0}'"
                 , txtMaPN.Text);
                DataSet ds = con.LayDuLieu(checkMAPN);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string query = string.Format("insert into PHIEUNHAP values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')"
                    , txtMaPN.Text, cbMaNCC.SelectedValue, cbMaNV.SelectedValue, dtpNgayNhap.Value.ToString("yyyy/MM/dd"), txtTongTien.Text);
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
                    MessageBox.Show("Mã phiếu nhập đã tồn tại!");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("update PHIEUNHAP set MANCC = N'{1}', MANV = N'{2}' ,NGAYXUAT =N'{3}',TONGTIEN = N'{4}' where MAPHIEUNHAP = N'{0}'",
                    txtMaPN.Text,
                    cbMaNCC.SelectedValue,
                    cbMaNV.SelectedValue,
                    dtpNgayNhap.Value.ToString("yyyy/MM/dd"),
                    txtTongTien.Text
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
            catch(Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("Delete PHIEUNHAP where MAPHIEUNHAP = N'{0}'", txtMaPN.Text);
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
            catch (Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
            getdata();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from PHIEUNHAP where " +
                "MAPHIEUNHAP like N'%{0}%' or " +
                "MANCC like N'%{0}%' or " +
                "MANV like N'%{0}%' or" +
                "NGAYNHAP like N'%{0}%' or" +
                "TONGTIEN like N'%{0}%' " +
                txtTim.Text
                );
            try
            {
                DataSet ds = con.LayDuLieu(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvPhieuNhap.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                if (r >= 0)
                {
                    txtMaPN.Enabled = false;
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;

                    txtMaPN.Text = dgvPhieuNhap.Rows[r].Cells["MAPHIEUNHAP"].Value.ToString();
                    cbMaNCC.SelectedValue = dgvPhieuNhap.Rows[r].Cells["MANCC"].Value.ToString();
                    cbMaNV.SelectedValue = dgvPhieuNhap.Rows[r].Cells["MANV"].Value.ToString();
                    dtpNgayNhap.Text = dgvPhieuNhap.Rows[r].Cells["NGAYNHAP"].Value.ToString();
                    txtTongTien.Text = dgvPhieuNhap.Rows[r].Cells["TONGTIEN"].Value.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void dgvPhieuNhap_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                if (r >= 0)
                {
                    CTPN frm = new CTPN(dgvPhieuNhap.Rows[r].Cells["MAPHIEUNHAP"].Value.ToString());
                    frm.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
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
