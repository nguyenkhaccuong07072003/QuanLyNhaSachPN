﻿using QuanLyNhaSachPN.DAO;
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
            try
            {
                if (nmrNam.Value == 0)
                {
                    MessageBox.Show("Vui lòng nhập năm cần lập thống kê!");
                }
                else
                {
                    if (nmrThang.Value == 0)
                    {
                        DoanhThuNam();
                    }
                    else
                    {
                        if (nmrThang.Value < 1 && nmrThang.Value > 12)
                        {
                            MessageBox.Show("Phải nhập tháng từ 1 đến 12");
                        }
                        else
                        {
                            DoanhThuThang();
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }

        }
        private void DoanhThuThang()
        {
            try
            {
                string query = string.Format("WITH DoanhThuSanPham AS ( " +
                    "SELECT HANG.MAHANG, HANG.TENHANG," +
                        "SUM(CHITIETHOADON.SOLUONG * CHITIETHOADON.GIATIEN - CHITIETHOADON.SOLUONG * CHITIETPHIEUNHAP.GIANHAP) AS DOANH_THU_SAN_PHAM" +
                        "FROM HANG" +
                        "JOIN CHITIETHOADON ON HANG.MAHANG = CHITIETHOADON.MAHANG" +
                        "JOIN CHITIETPHIEUNHAP ON HANG.MAHANG = CHITIETPHIEUNHAP.MAHANG" +
                        "JOIN HOADON ON CHITIETHOADON.MAHD = HOADON.MAHD" +
                        "WHERE YEAR(HOADON.NGAYLAP) = '{0}' AND MONTH(HOADON.NGAYLAP) = '{1}' " +
                        "GROUP BY HANG.MAHANG, HANG.TENHANG)" +
                    "SELECT HANG.MAHANG,HANG.TENHANG," +
                        "SUM(CHITIETHOADON.SOLUONG)/2 AS TONG_SOLUONG, HANG.DONGIA," +
                        "SUM(CHITIETHOADON.SOLUONG/2 * HANG.DONGIA) AS TONG_TIEN_THU_DUOC," +
                        "SUM(CHITIETHOADON.SOLUONG/2 * CHITIETPHIEUNHAP.GIANHAP) AS TONG_TIEN_NHAP," +
                        "(SUM(CHITIETHOADON.SOLUONG/2 * HANG.DONGIA) - SUM(CHITIETHOADON.SOLUONG/2 * CHITIETPHIEUNHAP.GIANHAP)) AS DOANH_THU_TUNG_SAN_PHAM" +
                        "FROM HANG" +
                        "JOIN CHITIETHOADON ON HANG.MAHANG = CHITIETHOADON.MAHANG" +
                        "JOIN CHITIETPHIEUNHAP ON HANG.MAHANG = CHITIETPHIEUNHAP.MAHANG" +
                        "JOIN HOADON ON CHITIETHOADON.MAHD = HOADON.MAHD" +
                        "LEFT JOIN DoanhThuSanPham DTSP ON HANG.MAHANG = DTSP.MAHANG" +
                        "WHERE YEAR(HOADON.NGAYLAP) = '{0}' AND MONTH(HOADON.NGAYLAP) = '{1}' " +
                        "GROUP BY HANG.MAHANG, HANG.TENHANG, HANG.DONGIA;", nmrNam.Value, nmrThang.Value);
                DataSet ds = con.LayDuLieu(query);
                dgvThongKe.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra");
            }

        }
        private void DoanhThuNam()
        {
            try
            {
                string query = string.Format("WITH DoanhThuSanPham AS (" +
                "SELECT HANG.MAHANG, HANG.TENHANG," +
                    "SUM(CHITIETHOADON.SOLUONG * CHITIETHOADON.GIATIEN - CHITIETHOADON.SOLUONG * CHITIETPHIEUNHAP.GIANHAP) AS DOANH_THU_SAN_PHAM" +
                    "FROM HANG" +
                    "JOIN CHITIETHOADON ON HANG.MAHANG = CHITIETHOADON.MAHANG" +
                    "JOIN CHITIETPHIEUNHAP ON HANG.MAHANG = CHITIETPHIEUNHAP.MAHANG" +
                    "JOIN HOADON ON CHITIETHOADON.MAHD = HOADON.MAHD" +
                    "WHERE YEAR(HOADON.NGAYLAP) = '{0}'  " +
                    "GROUP BY HANG.MAHANG, HANG.TENHANG)" +
                "SELECT HANG.MAHANG,HANG.TENHANG," +
                    "SUM(CHITIETHOADON.SOLUONG)/2 AS TONG_SOLUONG, HANG.DONGIA," +
                    "SUM(CHITIETHOADON.SOLUONG/2 * HANG.DONGIA) AS TONG_TIEN_THU_DUOC," +
                    "SUM(CHITIETHOADON.SOLUONG/2 * CHITIETPHIEUNHAP.GIANHAP) AS TONG_TIEN_NHAP," +
                    "(SUM(CHITIETHOADON.SOLUONG/2 * HANG.DONGIA) - SUM(CHITIETHOADON.SOLUONG/2 * CHITIETPHIEUNHAP.GIANHAP)) AS DOANH_THU_TUNG_SAN_PHAM" +
                    "FROM HANG" +
                    "JOIN CHITIETHOADON ON HANG.MAHANG = CHITIETHOADON.MAHANG" +
                    "JOIN CHITIETPHIEUNHAP ON HANG.MAHANG = CHITIETPHIEUNHAP.MAHANG" +
                    "JOIN HOADON ON CHITIETHOADON.MAHD = HOADON.MAHD" +
                    "LEFT JOIN DoanhThuSanPham DTSP ON HANG.MAHANG = DTSP.MAHANG" +
                    "WHERE YEAR(HOADON.NGAYLAP) = '{0}' " +
                    "GROUP BY HANG.MAHANG, HANG.TENHANG, HANG.DONGIA;", nmrNam.Value);
                DataSet ds = con.LayDuLieu(query);
                dgvThongKe.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Đang Có Lỗi Xảy Ra" );
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
