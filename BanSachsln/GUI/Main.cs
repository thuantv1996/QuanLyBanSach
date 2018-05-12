using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            //DTO.Common.QuyenTryCap = DTO.QUYEN.QL;
            InitializeComponent();
            if (DTO.Common.QuyenTryCap == DTO.QUYEN.NV_BH)
            {
                MenuChoNVBH();
            }
            else
            {
                if (DTO.Common.QuyenTryCap == DTO.QUYEN.NV_K)
                {
                    MenuChoNVK();
                }
            }
            LoadCommons();
            TaoBaoCaoTonKho();
            TaoBaoCaoCongNo();
        }
        private void MenuChoNVBH()
        {
            menuItemKho.Enabled = false;
            menuItemKhac.Enabled = false;
            menuItemDanhMuc.Enabled = false;
            menuItemBaoCao.Enabled = false;
        }
        private void MenuChoNVK()
        {
            menuItemBanHang.Enabled = false;
            menuItemKhac.Enabled = false;
            menuItemBaoCao.Enabled = false;
        }
        private void LoadCommons()
        {
            BUS.QuyDinhBUS.DanhSachQuyDinh(ref DTO.Regulations.TuoiToiThieu, ref DTO.Regulations.NoToiDa, ref DTO.Regulations.SoLuongBanSi, ref DTO.Regulations.TonToiThieu);
        }
        private void menuItemTKNV_Click(object sender, EventArgs e)
        {
            foreach(Form f in MainPanel.Controls)
            {
                f.WindowState = FormWindowState.Minimized;
            }
            TaoTaiKhoan fTaoTaiKhoan = new TaoTaiKhoan();
            fTaoTaiKhoan.Show();
            fTaoTaiKhoan.Left = 0;
            fTaoTaiKhoan.Top = 0;
            fTaoTaiKhoan.TopLevel = false;
            MainPanel.Controls.Add(fTaoTaiKhoan);
        }

        private void menuItemNhanVien_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            fNhanVien f = new fNhanVien();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemKhuyenMai_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            KhuyenMai f = new KhuyenMai();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            KhachHang f = new KhachHang();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemHoaDon_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            BanHang f = new BanHang();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemThanhToan_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            ThanhToan f = new ThanhToan();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemNhapKho_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            PhieuNhap f = new PhieuNhap();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemNhaXuatBan_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            NhaXuatBan f = new NhaXuatBan();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemTheLoai_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            TheLoai f = new TheLoai();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemSach_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            Sach f = new Sach();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(0, 0);
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            CanhBao f = new CanhBao();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemQuyDinh_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            QuyDinh f = new QuyDinh();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }
        private void TaoBaoCaoTonKho()
        {
            // Lấy tháng năm hiện tại
            DateTime now = DateTime.Now;
            // tháng năm trước đó
            DateTime pre = new DateTime(now.Year, now.Month, 1);
            pre = pre.AddDays(-1);
            if (BUS.BaoCaoTonKhoBUS.TimBaoCao(pre.Month, pre.Year))
            {
                return;
            }
            BUS.BaoCaoTonKhoBUS.ThemBaoCao(pre.Month, pre.Year);
        }
        private void TaoBaoCaoCongNo()
        {
            // Lấy tháng năm hiện tại
            DateTime now = DateTime.Now;
            // tháng năm trước đó
            DateTime pre = new DateTime(now.Year, now.Month, 1);
            pre = pre.AddDays(-1);
            if (BUS.CongNoBUS.TimBaoCao(pre.Month, pre.Year))
            {
                return;
            }
            BUS.CongNoBUS.ThemBaoCao(pre.Month, pre.Year);
        }

        private void menuItemCongNo_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            BaoCaoCongNo f = new BaoCaoCongNo();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemTonKho_Click(object sender, EventArgs e)
        {
            foreach (Form form in MainPanel.Controls)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            BaoCaoTonKho f = new BaoCaoTonKho();
            f.Show();
            f.Left = 0;
            f.Top = 0;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {
            if(BUS.LogoutBUS.Logout())
            {
                DTO.Common.ct_DiemDanh = null;
                DTO.Common.diemDanh = null;
                DTO.Common.isDangNhap = false;
                DTO.Common.taikhoan = null;
                DangNhap f = new DangNhap();
                f.Show();
                this.Hide();
            }
        }
    }
}
