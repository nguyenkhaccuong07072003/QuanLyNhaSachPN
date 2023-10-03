
namespace QuanLyNhaSachPN
{
    partial class TrangChu
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
            this.btnQLNV = new System.Windows.Forms.Button();
            this.btnQLBH = new System.Windows.Forms.Button();
            this.btnQLK = new System.Windows.Forms.Button();
            this.btnQLNCC = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQLNV
            // 
            this.btnQLNV.Location = new System.Drawing.Point(35, 19);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(338, 74);
            this.btnQLNV.TabIndex = 0;
            this.btnQLNV.Text = "QUẢN LÝ NHÂN VIÊN";
            this.btnQLNV.UseVisualStyleBackColor = true;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // btnQLBH
            // 
            this.btnQLBH.Location = new System.Drawing.Point(35, 110);
            this.btnQLBH.Name = "btnQLBH";
            this.btnQLBH.Size = new System.Drawing.Size(338, 74);
            this.btnQLBH.TabIndex = 1;
            this.btnQLBH.Text = "QUẢN LÝ BÁN HÀNG";
            this.btnQLBH.UseVisualStyleBackColor = true;
            this.btnQLBH.Click += new System.EventHandler(this.btnQLBH_Click);
            // 
            // btnQLK
            // 
            this.btnQLK.Location = new System.Drawing.Point(35, 205);
            this.btnQLK.Name = "btnQLK";
            this.btnQLK.Size = new System.Drawing.Size(338, 74);
            this.btnQLK.TabIndex = 2;
            this.btnQLK.Text = "QUẢN LÝ KHO";
            this.btnQLK.UseVisualStyleBackColor = true;
            this.btnQLK.Click += new System.EventHandler(this.btnQLK_Click);
            // 
            // btnQLNCC
            // 
            this.btnQLNCC.Location = new System.Drawing.Point(35, 306);
            this.btnQLNCC.Name = "btnQLNCC";
            this.btnQLNCC.Size = new System.Drawing.Size(338, 74);
            this.btnQLNCC.TabIndex = 3;
            this.btnQLNCC.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            this.btnQLNCC.UseVisualStyleBackColor = true;
            this.btnQLNCC.Click += new System.EventHandler(this.btnQLNCC_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(35, 404);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(338, 74);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "THỐNG KÊ";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQLK);
            this.groupBox1.Controls.Add(this.btnThongKe);
            this.groupBox1.Controls.Add(this.btnQLNV);
            this.groupBox1.Controls.Add(this.btnQLNCC);
            this.groupBox1.Controls.Add(this.btnQLBH);
            this.groupBox1.Location = new System.Drawing.Point(562, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 499);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(21, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 499);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 523);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TrangChu";
            this.Text = "TrangChu";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.Button btnQLBH;
        private System.Windows.Forms.Button btnQLK;
        private System.Windows.Forms.Button btnQLNCC;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

