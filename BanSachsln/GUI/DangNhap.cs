using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class DangNhap : Form
    {
        TaiKhoan taikhoan;

        public DangNhap()
        {
            InitializeComponent();
        }
        // check data
        private bool CheckData()
        {
            if(String.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản khác rỗng!");
                return false;
            }
            if (String.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu khác rỗng!");
                return false;
            }
            return true;
        }
        // login
        private void DangNhapHeThong()
        {
            taikhoan = new TaiKhoan { TenDangNhap = txtTaiKhoan.Text, MatKhau = txtMatKhau.Text };
            if (!TaiKhoanBUS.DangNhapHeThong(taikhoan))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai!");
                return;
            }
            MessageBox.Show("Đăng nhập thành công!");
            // Lưu vết
            DTO.Common.isDangNhap = true;
            // gọi màn hình hệ thống
            Main fMain = new Main();        
            fMain.Show();
            fMain.Left = 0;
            fMain.Top = 0;
            this.Hide();

        }
        // change password
        private void DoiMatKhau()
        {
            // gọi giao diện đổi mật khẩu tại đây
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(!CheckData())
            {
                return;
            }
            DangNhapHeThong();
        }
    }
}
