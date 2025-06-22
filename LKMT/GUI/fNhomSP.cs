using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
namespace LKMT.GUI
{
    public partial class fNhomSP : UserControl
    {
        public fNhomSP()
        {
            InitializeComponent();
            NhomSanPhamBUS.Instance.showNhomSP(dgvNhomSP);
            dgvNhomSP.Columns[0].HeaderText = "Ma nhom";
            dgvNhomSP.Columns[1].HeaderText = "Ten nhom linh kien";
            dgvNhomSP.Columns[2].HeaderText = "Ngay tao";
            dgvNhomSP.Columns[3].HeaderText = "Ngay cap nhat";
            dgvNhomSP.Columns[0].Width = 70;
            dgvNhomSP.Columns[1].Width = 250;
            dgvNhomSP.Columns[2].Width = 100;
            dgvNhomSP.Columns[3].Width = 100;
            //addBinding();

        }
        //void addBinding()
        //{
        //    txtID.DataBindings.Add(new Binding("Text", dgvNhomSP.DataSource, "id_nhom"));
        //    txtName.DataBindings.Add(new Binding("Text", dgvNhomSP.DataSource, "tennhom"));
        //    txtNgayTao.DataBindings.Add(new Binding("Text", dgvNhomSP.DataSource, "ngaytao"));
        //    txtNgayCapNhat.DataBindings.Add(new Binding("Text", dgvNhomSP.DataSource, "ngaycapnhat"));

        //}


        private void btnThem_Click(object sender, EventArgs e)
        {
           if(txtID.TextLength>5)
           {
                MessageBox.Show("Ma khong duoc vuot qua 5 ky tu!!", "Thong Bao", MessageBoxButtons.OK);
           }
           else if (txtID.TextLength == 0)
                MessageBox.Show("Ma khong duoc bo trong!!", "Thong Bao", MessageBoxButtons.OK);
           else if(txtName.TextLength==0)
                MessageBox.Show("Ten khong duoc bo trong!!", "Thong Bao", MessageBoxButtons.OK);
           else
            {
                if (NhomSanPhamBUS.Instance.themNhomSp(txtID.Text, txtName.Text))
                {
                    MessageBox.Show("Them nhom san pham thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    NhomSanPhamBUS.Instance.showNhomSP(dgvNhomSP);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Them nhom san pham that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvNhomSP.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)
            {
                if (NhomSanPhamBUS.Instance.xoaNhomSP(txtID.Text))
                {
                    MessageBox.Show("Xoa nhom linh kien thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    NhomSanPhamBUS.Instance.showNhomSP(dgvNhomSP);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Khong the xoa nhom linh kien nay, vi con ton tai loai linh kien hoac thuong hieu thuoc nhom nay!!", "Thong Bao", MessageBoxButtons.OK);
                btnLamMoi_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Vui long chon loai linh kien muon xoa!!", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvNhomSP.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (NhomSanPhamBUS.Instance.suaNhomSP(txtID.Text, txtName.Text, DateTime.Parse(txtNgayTao.Text)))
                {
                    MessageBox.Show("Cap nhat nhom linh kien thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    NhomSanPhamBUS.Instance.showNhomSP(dgvNhomSP);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Cap nhat nhom linh kien that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui long chon nhom linh kien muon cap nhat!!", "Thong Bao", MessageBoxButtons.OK);
            }         
        }
        private void dgvNhomSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvNhomSP.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvNhomSP.Rows[e.RowIndex];
                    txtID.Text = row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtNgayTao.Text = row.Cells[2].Value.ToString();
                    txtNgayCapNhat.Text = row.Cells[3].Value.ToString();
                }            
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtID.Text = null;
            txtName.Text = null;
            txtNgayCapNhat.Text = null;
            txtNgayTao.Text = null;
        }

        private void fNhomSP_Load(object sender, EventArgs e)
        {

        }

        private void txtNgayCapNhat_TextChanged(object sender, EventArgs e)
        {

        }

        private void aaa_Click(object sender, EventArgs e)
        {

        }

        private void txtNgayTao_TextChanged(object sender, EventArgs e)
        {

        }

        private void ddd_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhomSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void b_Click(object sender, EventArgs e)
        {

        }

        private void a_Click(object sender, EventArgs e)
        {

        }
    }
}