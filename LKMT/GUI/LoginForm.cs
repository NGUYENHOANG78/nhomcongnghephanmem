using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace LKMT.GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" || txtPassword.Text != "")
            {
                DangNhapBUS dn = new DangNhapBUS();
                if(dn.checkLogin(txtEmail.Text,txtPassword.Text))
                {
                    GUI.ManagerForm f = new ManagerForm();
                    this.Hide();
                    f.ShowDialog();
                }
                else MessageBox.Show("Email hoặc mật khẩu không hợp lệ", "Thông Báo", MessageBoxButtons.OK);

            }
            else MessageBox.Show("Vui lòng nhập Email và Password!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            txtEmail.Text = null;
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = null;
        }

      
    }
}
