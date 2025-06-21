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
            dgvNhomSP.Columns[0].HeaderText = "Mã nhóm";
            dgvNhomSP.Columns[1].HeaderText = "Tên nhóm linh kiện";
            dgvNhomSP.Columns[2].HeaderText = "Ngày tạo";
            dgvNhomSP.Columns[3].HeaderText = "Ngày cập nhật";
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
                MessageBox.Show("Mã không được vượt quá 5 ký tự!!", "Thông Báo", MessageBoxButtons.OK);
           }
           else if (txtID.TextLength == 0)
                MessageBox.Show("Mã không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
           else if(txtName.TextLength==0)
                MessageBox.Show("Tên không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
           else
            {
                if (NhomSanPhamBUS.Instance.themNhomSp(txtID.Text, txtName.Text))
                {
                    MessageBox.Show("Thêm nhóm sản phẩm thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    NhomSanPhamBUS.Instance.showNhomSP(dgvNhomSP);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Thêm nhóm sản phẩm thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvNhomSP.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)
            {
                if (NhomSanPhamBUS.Instance.xoaNhomSP(txtID.Text))
                {
                    MessageBox.Show("Xóa nhóm linh kiện thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    NhomSanPhamBUS.Instance.showNhomSP(dgvNhomSP);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Không thể xóa nhóm linh kiện này, vì còn tồn tại loại linh kiện hoặc thương hiệu thuộc nhóm này!!", "Thông Báo", MessageBoxButtons.OK);
                btnLamMoi_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại linh kiện muốn xóa!!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvNhomSP.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (NhomSanPhamBUS.Instance.suaNhomSP(txtID.Text, txtName.Text, DateTime.Parse(txtNgayTao.Text)))
                {
                    MessageBox.Show("Cập nhật nhóm linh kiện thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    NhomSanPhamBUS.Instance.showNhomSP(dgvNhomSP);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Cập nhật nhóm linh kiện thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhóm linh kiện muốn cập nhật!!", "Thông Báo", MessageBoxButtons.OK);
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
