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
    public partial class BaoCao : Form
    {
        Connect con = new Connect();
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (nmrNam.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập năm cần lập thống kê!");
            }
            else
            {
                if (nmrThang.Value == 0)
                {
                    string query = string.Format("SELECT(SELECT SUM(THANHTIEN) FROM HOADON WHERE YEAR(HOADON.NGAYLAP) = '{0}') -" +
                                                   "(SELECT SUM(TONGTIEN) FROM PHIEUNHAP WHERE YEAR(PHIEUNHAP.NGAYNHAP) = '{0}') AS 'DOANH THU NĂM'", nmrNam.Value);
                    DataSet ds = con.LayDuLieu(query);
                    dgvThongKe.DataSource = ds.Tables[0];
                }
                else
                {
                    if (nmrThang.Value < 1 && nmrThang.Value > 12)
                    {
                        MessageBox.Show("Phải nhập tháng từ 1 đến 12");
                    }
                    else
                    {
                        string query = string.Format(" SELECT (SELECT SUM(THANHTIEN) FROM HOADON WHERE MONTH(HOADON.NGAYLAP) = '{0}' AND YEAR(HOADON.NGAYLAP) = '{1}') -" +
                                                       "(SELECT SUM(TONGTIEN) FROM PHIEUNHAP WHERE MONTH(PHIEUNHAP.NGAYNHAP) = '{0}' AND YEAR(PHIEUNHAP.NGAYNHAP) = '{1}') AS 'DOANH THU THÁNG'", nmrThang.Value, nmrNam.Value);
                        DataSet ds = con.LayDuLieu(query);
                        dgvThongKe.DataSource = ds.Tables[0];
                    }
                }
            }

        }
        private void ResetData()
        {
            DataSet dataset = new DataSet();
            dgvThongKe.DataSource = dataset;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            nmrThang.Value = 0;
            nmrNam.Value = 0;
            ResetData();
        }
    }
}
