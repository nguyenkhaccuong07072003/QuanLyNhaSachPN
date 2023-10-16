
namespace QuanLyNhaSachPN.View
{
    partial class QLK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHangHoa = new System.Windows.Forms.Button();
            this.btnPhieuXuat = new System.Windows.Forms.Button();
            this.btnPhieuNhap = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHangHoa);
            this.panel1.Controls.Add(this.btnPhieuXuat);
            this.panel1.Controls.Add(this.btnPhieuNhap);
            this.panel1.Location = new System.Drawing.Point(-1, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 89);
            this.panel1.TabIndex = 0;
            // 
            // btnHangHoa
            // 
            this.btnHangHoa.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHangHoa.Location = new System.Drawing.Point(583, 14);
            this.btnHangHoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHangHoa.Name = "btnHangHoa";
            this.btnHangHoa.Size = new System.Drawing.Size(230, 67);
            this.btnHangHoa.TabIndex = 3;
            this.btnHangHoa.Text = "HÀNG HÓA";
            this.btnHangHoa.UseVisualStyleBackColor = true;
            this.btnHangHoa.Click += new System.EventHandler(this.btnHangHoa_Click);
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuXuat.Location = new System.Drawing.Point(296, 14);
            this.btnPhieuXuat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.Size = new System.Drawing.Size(230, 67);
            this.btnPhieuXuat.TabIndex = 1;
            this.btnPhieuXuat.Text = "PHIẾU XUẤT";
            this.btnPhieuXuat.UseVisualStyleBackColor = true;
            this.btnPhieuXuat.Click += new System.EventHandler(this.btnPhieuXuat_Click);
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuNhap.Location = new System.Drawing.Point(17, 14);
            this.btnPhieuNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Size = new System.Drawing.Size(230, 67);
            this.btnPhieuNhap.TabIndex = 0;
            this.btnPhieuNhap.Text = "PHIẾU NHẬP";
            this.btnPhieuNhap.UseVisualStyleBackColor = true;
            this.btnPhieuNhap.Click += new System.EventHandler(this.btnPhieuNhap_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.Location = new System.Drawing.Point(-1, 91);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1085, 482);
            this.panelChildForm.TabIndex = 1;
            // 
            // QLK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 573);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLK";
            this.Text = "QLK";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPhieuNhap;
        private System.Windows.Forms.Button btnPhieuXuat;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btnHangHoa;
    }
}