using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FileSinhVien
{
    
    public partial class SinhVien : Form
    {
        string flag;
        DataTable dtSV;
        int index;
        string mssv_timkiem;
        string filePath = @"D:\\study\\C#_project\\FileSinhVien\\FileSinhVien\\SinhVien.txt";
        public SinhVien()
        {
            InitializeComponent();
        }
        public DataTable createTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSV");
            dt.Columns.Add("TenSV");
            dt.Columns.Add("Diem");
            dt.Columns.Add("Lop");
            return dt;
        }
        public DataTable ConvertToDataTable(string filePath)
        {   
            DataTable dtSample = createTable();

            string[] lines = System.IO.File.ReadAllLines(filePath);
            

            foreach (string line in lines)
            {
                var cols = line.Split('|');
                

                DataRow dr = dtSample.NewRow();
                for (int cIndex = 0; cIndex < dtSample.Columns.Count; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }
                dtSample.Rows.Add(dr);
            }
            return dtSample;
        }
        private void SinhVien_Load(object sender, EventArgs e)
        {
            LockControl();
            //dtSV = createTable();
            dtSV = ConvertToDataTable(filePath);
            dataGridSinhVien.DataSource = dtSV;
            dataGridSinhVien.RefreshEdit();
        }

        public void LockControl()
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtMaSV.ReadOnly = true;
            txtDiem.ReadOnly = true;
            txtLop.ReadOnly = true;
            txtTenSV.ReadOnly = true;
            txtbox_timkiem.ReadOnly = false; 

            btnThem.Focus();
        }
        public void UnlockControl()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            txtMaSV.ReadOnly= false;
            txtTenSV.ReadOnly = false;
            txtDiem.ReadOnly= false;
            txtLop.ReadOnly = false;
            txtbox_timkiem.ReadOnly = false;


            txtMaSV.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnlockControl();
            flag = "add";

            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtDiem.Text = "";
            txtLop.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnlockControl();
            flag = "edit";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                if (checkData())
                {
                    dtSV.Rows.Add(txtMaSV.Text, txtTenSV.Text, txtDiem.Text, txtLop.Text);
                    dataGridSinhVien.DataSource = dtSV;
                    dataGridSinhVien.RefreshEdit();
                    

                    StreamWriter w = new StreamWriter(filePath, true);
                    foreach (DataRow row in dtSV.Rows)
                    {
                        object[] array = row.ItemArray;
                        for (int i = 0; i < array.Length - 1; i++)
                        {
                            w.Write(array[i].ToString() + " | ");
                        }
                        w.WriteLine(array[array.Length - 1].ToString());
                    }
                    w.Close();
                }
            }    
            else if(flag == "edit")
            {
                dtSV.Rows[index][0] = txtMaSV.Text;
                dtSV.Rows[index][1] = txtTenSV.Text;
                dtSV.Rows[index][2] = txtDiem.Text;
                dtSV.Rows[index][3] = txtLop.Text;
                dataGridSinhVien.DataSource = dtSV;
                dataGridSinhVien.RefreshEdit();
                StreamWriter w = new StreamWriter(filePath);
                foreach (DataRow row in dtSV.Rows)
                {
                    object[] array = row.ItemArray;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        w.Write(array[i].ToString() + " | ");
                    }
                    w.WriteLine(array[array.Length - 1].ToString());
                }
                w.Close();
            }    
            LockControl();
        }
        public bool checkData()
        {
            if(string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtMaSV.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(txtTenSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập lớp sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLop.Focus();
                return false;
            }
            return true;
        }

        private void dataGridSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridSinhVien.CurrentCell != null)
            {
                index = dataGridSinhVien.CurrentCell.RowIndex;
                DataTable dt = (DataTable)dataGridSinhVien.DataSource;
                if (dt != null)
                {
                    txtMaSV.Text = dataGridSinhVien.Rows[index].Cells[0].Value.ToString();
                    txtTenSV.Text = dataGridSinhVien.Rows[index].Cells[1].Value.ToString();
                    txtDiem.Text = dataGridSinhVien.Rows[index].Cells[2].Value.ToString();
                    txtLop.Text = dataGridSinhVien.Rows[index].Cells[3].Value.ToString();
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa sinh viên này?","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dtSV.Rows.RemoveAt(index);
                dataGridSinhVien.DataSource = dtSV;
                dataGridSinhVien.RefreshEdit();
                StreamWriter w = new StreamWriter(filePath);
                foreach (DataRow row in dtSV.Rows)
                {
                    object[] array = row.ItemArray;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        w.Write(array[i].ToString() + " | ");
                    }
                    w.WriteLine(array[array.Length - 1].ToString());
                }
                w.Close();
            }
        }
        public void ShowMyDialog()
        {
            Timkiem TimkiemDialog = new Timkiem();
            Console.WriteLine("###");
            if (TimkiemDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                this.mssv_timkiem = TimkiemDialog.txtbox_mssv.Text;
            }
            else
            {
                this.mssv_timkiem = "";
            }
            txtbox_timkiem.Text = this.mssv_timkiem;
            TimkiemDialog.Dispose();
            Timkiem(mssv_timkiem);
        }
        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            if (txtbox_timkiem.Text == null || txtbox_timkiem.Text == "")
            {
                ShowMyDialog();
            }
            else Timkiem(txtbox_timkiem.Text);

        }
        private void LockTimkiem()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = true;
            btnLuu.Enabled = false; ;
            btnHuy.Enabled = true;

            txtMaSV.ReadOnly = true;
            txtDiem.ReadOnly = false;
            txtLop.ReadOnly = false;
            txtTenSV.ReadOnly = false;
            txtbox_timkiem.ReadOnly = false;

            btnLuu.Focus();
        }
        private void Timkiem(string mssv_timkiem)
        {
            LockTimkiem();
            //string expression = $"MaSV = {mssv_timkiem}";
            //Console.WriteLine($"{ mssv_timkiem}");
            //DataRow[] rows = dtSV.Select(expression);
            //for (int i = 0; i < rows.Length; i++)
            //{
            //   Console.WriteLine(rows[i][0]);
            //}
            dtSV.DefaultView.RowFilter = string.Format("[MaSV] LIKE '%{0}%'", mssv_timkiem);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dataGridSinhVien.DataSource = dtSV;
            dataGridSinhVien.RefreshEdit();
            LockControl();
            dataGridSinhVien_SelectionChanged(null, null);
            dtSV.DefaultView.RowFilter = string.Empty;
        }
    }
}
