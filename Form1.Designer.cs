namespace FileSinhVien
{
    partial class SinhVien
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
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.mssv_label = new System.Windows.Forms.Label();
            this.ten_label = new System.Windows.Forms.Label();
            this.txtTenSV = new System.Windows.Forms.TextBox();
            this.malop_label = new System.Windows.Forms.Label();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.dtb_label = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dataGridSinhVien = new System.Windows.Forms.DataGridView();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(132, 21);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(199, 22);
            this.txtMaSV.TabIndex = 0;
            // 
            // mssv_label
            // 
            this.mssv_label.AutoSize = true;
            this.mssv_label.Location = new System.Drawing.Point(59, 21);
            this.mssv_label.Name = "mssv_label";
            this.mssv_label.Size = new System.Drawing.Size(45, 16);
            this.mssv_label.TabIndex = 1;
            this.mssv_label.Text = "MSSV";
            // 
            // ten_label
            // 
            this.ten_label.AutoSize = true;
            this.ten_label.Location = new System.Drawing.Point(47, 64);
            this.ten_label.Name = "ten_label";
            this.ten_label.Size = new System.Drawing.Size(70, 16);
            this.ten_label.TabIndex = 2;
            this.ten_label.Text = "Họ và Tên";
            // 
            // txtTenSV
            // 
            this.txtTenSV.Location = new System.Drawing.Point(132, 64);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.Size = new System.Drawing.Size(199, 22);
            this.txtTenSV.TabIndex = 3;
            // 
            // malop_label
            // 
            this.malop_label.AutoSize = true;
            this.malop_label.Location = new System.Drawing.Point(378, 70);
            this.malop_label.Name = "malop_label";
            this.malop_label.Size = new System.Drawing.Size(52, 16);
            this.malop_label.TabIndex = 4;
            this.malop_label.Text = "Mã Lớp";
            // 
            // txtLop
            // 
            this.txtLop.Location = new System.Drawing.Point(493, 67);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(161, 22);
            this.txtLop.TabIndex = 5;
            // 
            // dtb_label
            // 
            this.dtb_label.AutoSize = true;
            this.dtb_label.Location = new System.Drawing.Point(378, 27);
            this.dtb_label.Name = "dtb_label";
            this.dtb_label.Size = new System.Drawing.Size(98, 16);
            this.dtb_label.TabIndex = 6;
            this.dtb_label.Text = "Điểm trung bình";
            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(493, 15);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(161, 22);
            this.txtDiem.TabIndex = 7;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(88, 108);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(68, 29);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dataGridSinhVien
            // 
            this.dataGridSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSV,
            this.colTen,
            this.colDiem,
            this.colLop});
            this.dataGridSinhVien.Location = new System.Drawing.Point(-4, 191);
            this.dataGridSinhVien.Name = "dataGridSinhVien";
            this.dataGridSinhVien.RowHeadersWidth = 51;
            this.dataGridSinhVien.RowTemplate.Height = 24;
            this.dataGridSinhVien.Size = new System.Drawing.Size(753, 265);
            this.dataGridSinhVien.TabIndex = 9;
            this.dataGridSinhVien.SelectionChanged += new System.EventHandler(this.dataGridSinhVien_SelectionChanged);
            // 
            // colMaSV
            // 
            this.colMaSV.DataPropertyName = "MaSV";
            this.colMaSV.HeaderText = "Mã Sinh Viên";
            this.colMaSV.MinimumWidth = 6;
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.Width = 125;
            // 
            // colTen
            // 
            this.colTen.DataPropertyName = "TenSV";
            this.colTen.HeaderText = "Tên Sinh Viên";
            this.colTen.MinimumWidth = 6;
            this.colTen.Name = "colTen";
            this.colTen.Width = 150;
            // 
            // colDiem
            // 
            this.colDiem.DataPropertyName = "Diem";
            this.colDiem.HeaderText = "Điểm sinh viên";
            this.colDiem.MinimumWidth = 6;
            this.colDiem.Name = "colDiem";
            this.colDiem.Width = 125;
            // 
            // colLop
            // 
            this.colLop.DataPropertyName = "Lop";
            this.colLop.HeaderText = "Lớp";
            this.colLop.MinimumWidth = 6;
            this.colLop.Name = "colLop";
            this.colLop.Width = 150;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(172, 108);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(68, 29);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(263, 108);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(68, 29);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(438, 108);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(68, 29);
            this.btnLuu.TabIndex = 12;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(529, 108);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(68, 29);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // SinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 454);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dataGridSinhVien);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.dtb_label);
            this.Controls.Add(this.txtLop);
            this.Controls.Add(this.malop_label);
            this.Controls.Add(this.txtTenSV);
            this.Controls.Add(this.ten_label);
            this.Controls.Add(this.mssv_label);
            this.Controls.Add(this.txtMaSV);
            this.Name = "SinhVien";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label mssv_label;
        private System.Windows.Forms.Label ten_label;
        private System.Windows.Forms.TextBox txtTenSV;
        private System.Windows.Forms.Label malop_label;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Label dtb_label;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dataGridSinhVien;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLop;
    }
}

