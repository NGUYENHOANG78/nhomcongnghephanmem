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
    public partial class fNhapKho : UserControl
    {
        public fNhapKho()
        {
            InitializeComponent();
            NhapKhoBUS.Instance.showPhieuNhap(dgvPhieuNhap);
            dgvPhieuNhap.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvPhieuNhap.Columns[1].HeaderText = "Mã linh kiện";
            dgvPhieuNhap.Columns[2].HeaderText = "Số lượng nhập";
            dgvPhieuNhap.Columns[3].HeaderText = "Giá nhập";
            dgvPhieuNhap.Columns[4].HeaderText = "Ngày nhập";

            dgvPhieuNhap.Columns[0].Width = 100;
            dgvPhieuNhap.Columns[1].Width = 100;
            dgvPhieuNhap.Columns[2].Width = 100;
            dgvPhieuNhap.Columns[3].Width = 100;
            dgvPhieuNhap.Columns[4].Width = 120;
            NhapKhoBUS.Instance.showLinhKienToComboBox(cboMaLK);
            NhapKhoBUS.Instance.showLinhKienToComboBox(cboTenLK);
            cboMaLK.DisplayMember = "id_sanpham";
            cboTenLK.DisplayMember = "tensanpham";
        }

     

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (cboMaLK.Text == null)
                MessageBox.Show("Vui lòng chọn linh kiện muốn nhập!", "Thông Báo", MessageBoxButtons.OK);
            else if(nmrSoLuong.Value ==0)
                MessageBox.Show("Vui lòng nhập số lượng linh kiện muốn nhập!", "Thông Báo", MessageBoxButtons.OK);
            else if(txtGiaNhap.TextLength == 0)
                MessageBox.Show("Vui lòng nhập giá nhập linh kiện này!", "Thông Báo", MessageBoxButtons.OK);
            {
                if (NhapKhoBUS.Instance.themPhieuNhap(cboMaLK.Text, (int)nmrSoLuong.Value, decimal.Parse(txtGiaNhap.Text)))
                {
                    MessageBox.Show("Thêm phương thức thanh toán thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    NhapKhoBUS.Instance.showPhieuNhap(dgvPhieuNhap);
                }
                else MessageBox.Show("Thêm phương thức thanh toán sản phẩm thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void cboMaLK_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            NhapKhoBUS.Instance.selectChangesFromCboMaLk(cboMaLK, cboTenLK);

        }

        private void cboTenLK_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            NhapKhoBUS.Instance.selectChangesFromCboTenLK(cboMaLK, cboTenLK);

        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvPhieuNhap.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];
                    txtMaPhieuNhap.Text = row.Cells[0].Value.ToString();
                    cboMaLK.Text = row.Cells[1].Value.ToString();
                    NhapKhoBUS.Instance.selectChangesFromCboMaLk(cboMaLK, cboTenLK);
                    nmrSoLuong.Value = int.Parse(row.Cells[2].Value.ToString());
                    txtGiaNhap.Text = row.Cells[3].Value.ToString();
                    txtNgayNhap.Text = row.Cells[4].Value.ToString();               
                }
            }
        }
    }
}
