using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKMT.GUI
{
    public partial class ManagerForm : Form
    {
        private bool dragging = false;
        private Point starPoint = new Point(0, 0);
        private bool isCollapsed = true;
        private bool isCollapsed2 = true;
        fNhomSP nsp = new fNhomSP();
        fThanhToan tt = new fThanhToan();
        fKhachHang kh = new fKhachHang();

        public ManagerForm()
        {
            InitializeComponent();


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            timer1.Start();        
        }

    
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            starPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.starPoint.X, p.Y - this.starPoint.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollapsed)
            {
                PanelDropdown.Height += 100;
                if(PanelDropdown.Size == PanelDropdown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                PanelDropdown.Height -= 100;
                if (PanelDropdown.Size == PanelDropdown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }


        private void btnSanPham_Click(object sender, EventArgs e)
        {
            fSanPham sp = new fSanPham();
            //fLoaiSP lsp = new fLoaiSP();
            //fNhomSP nsp = new fNhomSP();
            showControl(sp);
        }

        private void btnNhomSP_Click(object sender, EventArgs e)
        {
            //fSanPham sp = new fSanPham();
            //fLoaiSP lsp = new fLoaiSP();
            showControl(nsp);
        }
        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            //fSanPham sp = new fSanPham();
            fLoaiSP lsp = new fLoaiSP();
            //fNhomSP nsp = new fNhomSP();
            showControl(lsp);
        }
        private void showControl(Control ctrl)
        {
            panelControl.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            panelControl.Controls.Add(ctrl);
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            fThuongHieu th = new fThuongHieu();

            showControl(th);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnQLKho_Click(object sender, EventArgs e)
        {
            timer2.Start();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                PanelDropdown2.Height += 60;
                if (PanelDropdown2.Size == PanelDropdown2.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed2 = false;
                }
            }
            else
            {
                PanelDropdown2.Height -= 60;
                if (PanelDropdown2.Size == PanelDropdown2.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed2 = true;
                }
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            fNhapKho nk = new fNhapKho();
            showControl(nk);
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
         
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            showControl(tt);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            showControl(kh);
        }
    }
}
