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
using BUS.Services;
using BUS;

namespace GUI
{
    public partial class TaoTaiKhoan : Form
    {
        // danh sách tài khoản
        List<TaiKhoan> DanhSachTaiKhoan = new List<TaiKhoan>();
        // danh sách nhân viên
        List<NhanVien> DanhSachNhanVien = new List<DTO.NhanVien>();
        // tài khoản hiện tại
        TaiKhoan taikhoan;
        // đang thêm hay đang sửa
        bool isAdd = true;
        // Đối tượng lấy dữ liệu
        ITaiKhoanService service;

        public TaoTaiKhoan()
        {
            InitializeComponent();
            service = new TaiKhoanService();
            LoadData();
            ResetControls();
        }
        // get data
        void LoadData()
        {
            DanhSachTaiKhoan = service.LayDanhSachTaiKhoan().ToList();
            DanhSachNhanVien = service.LayDanhSachNhanVien().ToList();
            cmbNhanVien.DataSource = DanhSachNhanVien;
            cmbNhanVien.ValueMember = "MaNV";
            cmbNhanVien.DisplayMember = "TenNV";
            dgvDanhSach.DataSource = DanhSachTaiKhoan;
        }
        // reset controls
        void ResetControls()
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtLapLai.Text = "";
            cmbNhanVien.SelectedIndex = 0;
            taikhoan = new TaiKhoan();
            txtMatKhau.Enabled = true;
            txtLapLai.Enabled = true;
            cmbNhanVien.Enabled = true;
        }
        // check data
        bool CheckData()
        {
            if(String.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản khác rỗng!");
                return false;
            }
            if (txtTaiKhoan.Text.Length<6 || txtTaiKhoan.Text.Length > 20)
            {
                MessageBox.Show("Tài khoản nhiều hơn 6 ký tự và ít hơn 20 ký tự!");
                return false;
            }
            if (String.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu khác rỗng!");
                return false;
            }
            if (txtMatKhau.Text.Length < 6 || txtMatKhau.Text.Length > 20)
            {
                MessageBox.Show("Mật khẩu nhiều hơn 6 ký tự và ít hơn 20 ký tự!");
                return false;
            }
            if (String.IsNullOrEmpty(txtLapLai.Text))
            {
                MessageBox.Show("Lặp lại mật khẩu!");
                return false;
            }
            if(!txtMatKhau.Text.Equals(txtLapLai.Text))
            {
                MessageBox.Show("Hai mật khẩu không khớp!");
                return false;
            }
            return true;
        }
        void ThemTaiKhoan()
        {
            if(!CheckData())
            {
                return;
            }
            taikhoan = new TaiKhoan
            {
                TenDangNhap = txtTaiKhoan.Text,
                MatKhau = txtMatKhau.Text,
                MaNhanVien = Int32.Parse(cmbNhanVien.SelectedValue.ToString()),
                TenNhanVien = cmbNhanVien.SelectedText.ToString()
            };
            BUS.TaiKhoanBUS.ThemTaiKhoan(taikhoan);
            MessageBox.Show(TaiKhoanBUS.Message);
            if (TaiKhoanBUS.isSucess)
            {
                LoadData();
                ResetControls();
            }
        }
        void ResetTaiKhoan()
        {
            // kiểm tra dữ liệu
            if (String.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản khác rỗng!");
                return;
            }
            if (txtTaiKhoan.Text.Length < 6 || txtTaiKhoan.Text.Length > 20)
            {
                MessageBox.Show("Tài khoản nhiều hơn 6 ký tự và ít hơn 20 ký tự!");
                return;
            }
            //Reset mật khẩu và update thông tin đăng nhập
            taikhoan.TenDangNhap = txtTaiKhoan.Text;
            TaiKhoanBUS.ResetTaiKhoan(taikhoan);
            MessageBox.Show(TaiKhoanBUS.Message);
            if (TaiKhoanBUS.isSucess)
            {
                LoadData();
                ResetControls();
            }
        }
        void XoaTaiKhoan()
        {
            TaiKhoanBUS.XoaTaiKhoan(taikhoan);
            MessageBox.Show(TaiKhoanBUS.Message);
            if (TaiKhoanBUS.isSucess)
            {
                LoadData();
                ResetControls();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(isAdd)
            {
                ThemTaiKhoan();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn reset tài khoản này!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                ResetTaiKhoan();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            XoaTaiKhoan();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            isAdd = true;
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int id = Int32.Parse(dgvDanhSach.Rows[rowIndex].Cells[0].Value.ToString());
            taikhoan = new TaiKhoan();
            taikhoan = DanhSachTaiKhoan.Find(tk => tk.MaTaiKhoan == id);
            isAdd = false;
            txtTaiKhoan.Text = taikhoan.TenDangNhap;
            txtMatKhau.Text = "***";
            txtLapLai.Text = "***";
            cmbNhanVien.SelectedValue = taikhoan.MaNhanVien;
            txtMatKhau.Enabled = false;
            txtLapLai.Enabled = false;
            cmbNhanVien.Enabled = false;
        }
    }
}
