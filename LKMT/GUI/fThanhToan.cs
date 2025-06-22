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
            dgvPhuongThuc.Columns[0].HeaderText = "Ma phuong thuc";
            dgvPhuongThuc.Columns[1].HeaderText = "Ten phuong thuc";
            dgvPhuongThuc.Columns[0].Width = 60;
            dgvPhuongThuc.Columns[1].Width = 175;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           if (txtName.TextLength == 0)
                MessageBox.Show("Ten khong duoc bo trong!!", "Thong Bao", MessageBoxButtons.OK);
            else
            {
                if (ThanhToanBUS.Instance.themThanhToan(txtName.Text))
                {
                    MessageBox.Show("Them phuong thuc thanh toan thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    ThanhToanBUS.Instance.showThanhToan(dgvPhuongThuc);
                }
                else MessageBox.Show("Them phuong thuc thanh toan san pham that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvPhuongThuc.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (ThanhToanBUS.Instance.suaThanhToan(int.Parse(txtID.Text),txtName.Text))
                {
                    MessageBox.Show("Cap nhat phuong thuc thanh toan thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    ThanhToanBUS.Instance.showThanhToan(dgvPhuongThuc);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Cap nhat phuong thuc thanh toan that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui long chon phuong thuc thanh toan muon cap nhat!!", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvPhuongThuc.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (ThanhToanBUS.Instance.xoaThanhToan(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Xoa phuong thuc thanh toan thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    ThanhToanBUS.Instance.showThanhToan(dgvPhuongThuc);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Xoa phuong thuc thanh toan that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui long chon phuong thuc thanh toan muon xoa!!", "Thong Bao", MessageBoxButtons.OK);
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