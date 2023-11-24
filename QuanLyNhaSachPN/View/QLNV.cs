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
    public partial class QLNV : Form
    {
        Connect kn = new Connect();
        string gioitinh;
        public QLNV()
        {
            InitializeComponent();
        }
        public void getdata()
        {
            string query = "select * from NHANVIEN";
            DataSet ds = kn.LayDuLieu(query);
            dgvNhanVien.DataSource = ds.Tables[0];


            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public void clear()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtManv.Enabled = true;

            txtManv.Text = "";
            txtTennv.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
            txtTim.Text = "";
            dtpNgSinh.Value = DateTime.Now;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnNam.Checked)
                {
                    gioitinh = rdbtnNam.Text;
                }
                else
                {
                    gioitinh = rdbtnNu.Text;
                }
                string checkMANV = string.Format("select * from NHANVIEN where MANV = N'{0}'"
                    , txtManv.Text);
                DataSet ds = kn.LayDuLieu(checkMANV);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string query = string.Format("insert into NHANVIEN values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')"
                    , txtManv.Text, txtTennv.Text, dtpNgSinh.Value.ToString("yyyy/MM/dd"), gioitinh, txtDiachi.Text, txtSDT.Text);
                    bool result = kn.ThucThi(query);
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
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnNam.Checked)
                {
                    gioitinh = rdbtnNam.Text;
                }
                else
                {
                    gioitinh = rdbtnNu.Text;
                }
                string query = string.Format("update NHANVIEN set TENNV=N'{1}', NGAYSINH=N'{2}', GIOITINH=N'{3}', DIACHI=N'{4}', SDT=N'{5}' where MANV=N'{0}'",
                    txtManv.Text,
                    txtTennv.Text,
                    dtpNgSinh.Value.ToString("yyyy/MM/dd"),
                    gioitinh,
                    txtDiachi.Text,
                    txtSDT.Text
                    );
                bool kt = kn.ThucThi(query);
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
            catch (Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("DELETE FROM NHANVIEN WHERE MANV=N'{0}'", txtManv.Text);
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool kt = kn.ThucThi(query);
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
            string query = string.Format("select * from NHANVIEN where " +
                "MANV like N'%{0}%' or " +
                "TENNV like N'%{0}%' or " +
                "NGAYSINH like N'%{0}%' or " +
                "GIOITINH like N'%{0}%' or " +
                "DIACHI like N'%{0}%' or " +
                "SDT like N'%{0}%' " ,
                txtTim.Text
                );
            try
            {
                DataSet ds = kn.LayDuLieu(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvNhanVien.DataSource = ds.Tables[0];
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                if (r >= 0)
                {
                    txtManv.Enabled = false;
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;

                    txtManv.Text = dgvNhanVien.Rows[r].Cells["MANV"].Value.ToString();
                    txtTennv.Text = dgvNhanVien.Rows[r].Cells["TENNV"].Value.ToString();
                    dtpNgSinh.Text = dgvNhanVien.Rows[r].Cells["NGAYSINH"].Value.ToString();
                    txtDiachi.Text = dgvNhanVien.Rows[r].Cells["DIACHI"].Value.ToString();
                    txtSDT.Text = dgvNhanVien.Rows[r].Cells["SDT"].Value.ToString();
                    gioitinh = dgvNhanVien.Rows[r].Cells["GIOITINH"].Value.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
            getdata();
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
