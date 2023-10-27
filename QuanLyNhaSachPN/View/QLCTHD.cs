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
    public partial class QLCTHD : Form
    {
        private float DonGia ;
        private int Soluong;
        private float GiaTien;
        private string maHD;
        public QLCTHD()
        {
            InitializeComponent();
        }

        public QLCTHD(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }
        Connect con = new Connect();
      
        private void QLCTHD_Load(object sender, EventArgs e)
        {
            getdata();
            getmahang();
            txtMahd.Text = maHD;
            txtMahd.Enabled = false;
            txtGiatien.Enabled = false;
        }
        public void getdata()
        {
            string query = String.Format("Select * from CHITIETHOADON where  MAHD = '{0}' ",maHD);
            DataSet ds = con.LayDuLieu(query);  
            dgvCTHD.DataSource = ds.Tables[0];

            dgvCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCTHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public void getmahang()
        {
            string query = "select * from Hang";
            DataSet ds = con.LayDuLieu(query);
            cbMahang.DataSource = ds.Tables[0];
            cbMahang.DisplayMember = "TenHang";
            cbMahang.ValueMember = "MaHang";
        }
        public void clear()
        {
            txtMahd.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            cbMahang.SelectedValue = "";
            nbrSoLuong.Value = 0;
            txtGiatien.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (nbrSoLuong.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                string query = string.Format("insert into CHITIETHOADON values(N'{0}',N'{1}',N'{2}',N'{3}')"
                , maHD, cbMahang.SelectedValue, nbrSoLuong.Value, txtGiatien.Text);
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
            string query = string.Format("update CHITIETHOADON set " +
                "MAHANG = N'{1}', SOLUONG=N'{2}', GIATIEN = N'{3}' where MAHD=N'{0}' and MAHANG = '{1}'",
                txtMahd.Text,
                cbMahang.SelectedValue,
                nbrSoLuong.Value,
                txtGiatien.Text
                );

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
            string query = string.Format("Delete CHITIETHOADON where MAHANG = N'{0}'", cbMahang.SelectedValue);
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
            string query = string.Format("select * from CHITIETHOADON where " +
                "MAHANG like N'%{0}%' or " +
                "SOLUONG like N'%{0}%' or " +
                "GIATIEN like N'%{0}%' ",
               txtTim.Text
               );
            try
            {
                DataSet ds = con.LayDuLieu(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvCTHD.DataSource = ds.Tables[0];
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

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMahd.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                txtMahd.Text = dgvCTHD.Rows[r].Cells["MAHD"].Value.ToString();
                cbMahang.SelectedValue = dgvCTHD.Rows[r].Cells["MAHANG"].Value.ToString();
                nbrSoLuong.Value = Decimal.Parse(dgvCTHD.Rows[r].Cells["SOLUONG"].Value.ToString());
                txtGiatien.Text = dgvCTHD.Rows[r].Cells["GIATIEN"].Value.ToString();
            }
        }
    
        private void showPrice()
        {
            Soluong = Convert.ToInt32(nbrSoLuong.Value);
            string sql = string.Format("SELECT DONGIA FROM HANG WHERE MAHANG = '{0}'", cbMahang.SelectedValue);

            DataSet ds = con.LayDuLieu(sql);

            DonGia = float.Parse(ds.Tables[0].Rows[0]["DONGIA"].ToString());

            GiaTien = Soluong * DonGia;
            txtGiatien.Text = GiaTien.ToString();
        }

        private void nbrSoLuong_Leave(object sender, EventArgs e)
        {
            if(nbrSoLuong.Value >= 0)
            {
                showPrice();
            }
            else
            {
                txtGiatien.Text = "";
            }

        }
    }
}
