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
    public partial class CTPN : Form
    {
        private string maPN;
        Connect con = new Connect();
        public CTPN()
        {
            InitializeComponent();
        }
        public CTPN(string maPN)
        {
            InitializeComponent();
            this.maPN = maPN;
        }
        public void getmahang()
        {
            string query = "select * from HANG";
            DataSet ds = con.LayDuLieu(query);
            cbMaHang.DataSource = ds.Tables[0];
            cbMaHang.DisplayMember = "TenHang";
            cbMaHang.ValueMember = "MaHang";
        }
        private void CTPN_Load(object sender, EventArgs e)
        {
            getdata();
            getmahang();
            txtMaPN.Enabled = false;
            txtMaPN.Text = maPN;
        }

        public void clear()
        {
            txtMaPN.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            cbMaHang.Text = "";
            nbrSoLuong.Value = 0;
            txtGiaNhap.Text = "";
        }
        public void getdata()
        {
            string query = String.Format("Select * from CHITIETPHIEUNHAP where  MAPHIEUNHAP = '{0}' ", maPN);
            DataSet ds = con.LayDuLieu(query);
            dgvCTPN.DataSource = ds.Tables[0];

            dgvCTPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCTPN.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (nbrSoLuong.Value == 0)
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    string query = string.Format("insert into CHITIETPHIEUNHAP values(N'{0}',N'{1}',N'{2}',N'{3}')"
                    , txtMaPN.Text, cbMaHang.SelectedValue, nbrSoLuong.Value, txtGiaNhap.Text);
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
            catch(Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("update CHITIETPHIEUNHAP set MAHANG = N'{1}', SOLUONG=N'{2}', GIANHAP = N'{3}' where MAPHIEUNHAP=N'{0}' and MAHANG = '{1}'"
                , txtMaPN.Text, cbMaHang.SelectedValue, nbrSoLuong.Value, txtGiaNhap.Text);

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
            catch(Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("Delete CHITIETPHIEUNHAP where MAHANG = N'{0}'", cbMaHang.SelectedValue);
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
            catch(Exception)
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
            string query = string.Format("select * from CHITIETPHIEUNHAP where " +
            "MAHANG like N'%{0}%' or " +
            "SOLUONG like N'%{0}%' or " +
            "GIANHAP like N'%{0}%' or" +
            txtTim.Text) ;
            try
            {
                DataSet ds = con.LayDuLieu(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvCTPN.DataSource = ds.Tables[0];
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

        private void dgvCTPN_CellClick(object sender, DataGridViewCellEventArgs e)
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

                    txtMaPN.Text = dgvCTPN.Rows[r].Cells["MAPHIEUNHAP"].Value.ToString();
                    cbMaHang.SelectedValue = dgvCTPN.Rows[r].Cells["MAHANG"].Value.ToString();
                    nbrSoLuong.Value = Decimal.Parse(dgvCTPN.Rows[r].Cells["SOLUONG"].Value.ToString());
                    txtGiaNhap.Text = dgvCTPN.Rows[r].Cells["GIANHAP"].Value.ToString();
                }
            }
            catch(Exception)
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
