using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using BUS;
using DTO;

namespace QuanLyBanHang
{
    public partial class frmProducts1 : Form
    {
        Products1BUS proBUS = new Products1BUS();
        public frmProducts1()
        {
            InitializeComponent();
        }
        
        private void frmProducts1_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;

            frmLogIn frmLog = new frmLogIn();
            DialogResult result = frmLog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Enabled = true;
            }
            else
            {
                Application.Exit();
            }
            List<Products1> list = proBUS.LoadProducts1();
            dgvProducts1.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string masp, tensp, donvitinh, dongia, maloaisp;
            
            masp = txtId.Text;
            tensp = txtName.Text;
            donvitinh = txtDonvitinh.Text;
            dongia = txtDongia.Text;
            maloaisp = txtMaloaisp.Text;

            Products1 s = new Products1(masp, tensp, donvitinh, dongia, maloaisp);
            int numberOfRows = proBUS.Add(s);

            //if (numberOfRows > 0)
            //    MessageBox.Show("Them thanh cong!");
            //else
            //    MessageBox.Show("Them that bai!");
            if (numberOfRows > 0)
            {
                List<Products1> list = proBUS.LoadProducts1();
                dgvProducts1.DataSource = list;
                MessageBox.Show("Them thanh cong");
            }
            else
                MessageBox.Show("Them that bai");
        }

        private void dgvProducts1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;

            if (dgvProducts1.Columns[col] is DataGridViewButtonColumn && dgvProducts1.Columns[col].Name == "CotXoa")
            {
                int row = e.RowIndex;
                String id = dgvProducts1.Rows[row].Cells["Cotcanlay"].Value.ToString();
                int numberOfRows = proBUS.Delete(id);

                if (numberOfRows > 0)
                {
                    List<Products1> list = proBUS.LoadProducts1();
                    dgvProducts1.DataSource = list;
                    MessageBox.Show("Da xoa");
                }
                else
                    MessageBox.Show("Xoa that bai");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string masp, tensp, donvitinh, dongia, maloaisp;
            
            masp = txtId.Text;
            tensp = txtName.Text;
            donvitinh = txtDonvitinh.Text;
            maloaisp = txtMaloaisp.Text;
            dongia =txtDongia.Text;

            Products1 s = new Products1(masp, tensp, donvitinh, dongia, maloaisp);
            int numberOfRows = proBUS.Update(s);
            if (numberOfRows > 0)
            {
                List<Products1> list = proBUS.LoadProducts1();
                dgvProducts1.DataSource = list;
                MessageBox.Show("Sửa thành công!");
            }
            else
                MessageBox.Show("Sửa thất bại!");
        }

        private void dgvProducts1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string masp, tensp, donvitinh, dongia, maloaisp;
            
            masp = txtId.Text;
            tensp = txtName.Text;
            donvitinh = txtDonvitinh.Text;
            dongia = txtDongia.Text;
            maloaisp = txtMaloaisp.Text;

            int row = e.RowIndex;
            txtId.Text = dgvProducts1.Rows[row].Cells["CotCanLay"].Value.ToString();
            txtName.Text = dgvProducts1.Rows[row].Cells["tensp"].Value.ToString();
            txtDonvitinh.Text = dgvProducts1.Rows[row].Cells["donvitinh"].Value.ToString();
            txtMaloaisp.Text = dgvProducts1.Rows[row].Cells["maloaisp"].Value.ToString();
            txtDongia.Text = dgvProducts1.Rows[row].Cells["dongia"].Value.ToString();
        }

        
    }
}
