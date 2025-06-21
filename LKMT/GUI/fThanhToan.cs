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
    public partial class fThanhToan : UserControl
    {
        public fThanhToan()
        {
            InitializeComponent();
            ThanhToanBUS.Instance.showThanhToan(dgvPhuongThuc);
            dgvPhuongThuc.Columns[0].HeaderText = "Mã phương thức";
            dgvPhuongThuc.Columns[1].HeaderText = "Tên phương thức";
            dgvPhuongThuc.Columns[0].Width = 60;
            dgvPhuongThuc.Columns[1].Width = 175;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           if (txtName.TextLength == 0)
                MessageBox.Show("Tên không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
            else
            {
                if (ThanhToanBUS.Instance.themThanhToan(txtName.Text))
                {
                    MessageBox.Show("Thêm phương thức thanh toán thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    ThanhToanBUS.Instance.showThanhToan(dgvPhuongThuc);
                }
                else MessageBox.Show("Thêm phương thức thanh toán sản phẩm thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvPhuongThuc.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (ThanhToanBUS.Instance.suaThanhToan(int.Parse(txtID.Text),txtName.Text))
                {
                    MessageBox.Show("Cập nhật phương thức thanh toán thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    ThanhToanBUS.Instance.showThanhToan(dgvPhuongThuc);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Cập nhật phương thức thanh toán thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán muốn cập nhật!!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvPhuongThuc.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (ThanhToanBUS.Instance.xoaThanhToan(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Xóa phương thức thanh toán thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    ThanhToanBUS.Instance.showThanhToan(dgvPhuongThuc);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Xóa phương thức thanh toán thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán muốn xóa!!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtID.Text = null;
            txtName.Text = null;
        }

        private void dgvPhuongThuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvPhuongThuc.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvPhuongThuc.Rows[e.RowIndex];
                    txtID.Text = row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells[1].Value.ToString();
                }            
            }
        }
    }
}
