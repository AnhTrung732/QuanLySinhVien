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

namespace FileSinhVien
{
    public partial class SinhVien : Form
    {
        string flag;
        DataTable dtSV;
        int index;
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
            Console.WriteLine(dtSample.Columns.Count); 

            string[] lines = System.IO.File.ReadAllLines(filePath);
            Console.WriteLine(lines[0]);

            foreach (string line in lines)
            {
                var cols = line.Split('|');
                Console.WriteLine(cols[0]);

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
                    Console.WriteLine(dtSV);

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
    }
}
