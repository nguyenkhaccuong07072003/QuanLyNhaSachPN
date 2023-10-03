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

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            QLNV frm = new QLNV();
            frm.Show();
            this.Hide();
        }

        private void btnQLBH_Click(object sender, EventArgs e)
        {
            QLBH frm = new QLBH();
            frm.Show();
            this.Hide();
        }

        private void btnQLK_Click(object sender, EventArgs e)
        {
            QLKho frm = new QLKho();
            frm.Show();
            this.Hide();
        }

        private void btnQLNCC_Click(object sender, EventArgs e)
        {
            QLNCC frm = new QLNCC();
            frm.Show();
            this.Hide();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            BaoCao frm = new BaoCao();
            frm.Show();
            this.Hide();
        }
    }
}
