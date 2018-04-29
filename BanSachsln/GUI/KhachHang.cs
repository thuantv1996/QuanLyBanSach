using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Services;

namespace GUI
{
    public partial class KhachHang : Form
    {
        DTO.KhachHang khachhang;
        List<DTO.KhachHang> DSKhachHang = new List<DTO.KhachHang>();
        List<DTO.LoaiKhachHang> DSLoaiKhachHang = new List<DTO.LoaiKhachHang>();
        BUS.Services.IKhachHangService service;
        bool IsAdd = true;
        public KhachHang()
        {
            InitializeComponent();
            service = new KhachHangService();
            LoadData();
            ResetControls();

        }
        //reset controls
        private void ResetControls()
        {
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            try
            {
                cmbLoaiKH.SelectedIndex = 0;
            }
            catch { }
            btnDelete.Enabled = false;
        }

        // Load data
        private void LoadData()
        {
            DSKhachHang = service.LayDanHSachKhachHang().ToList();
            dgvDanhSach.DataSource = DSKhachHang;
            DSLoaiKhachHang = service.LayDanhSachLoaiKhachHang().ToList();
            cmbLoaiKH.DataSource = DSLoaiKhachHang;
            cmbLoaiKH.DisplayMember = "TenLKH";
            cmbLoaiKH.ValueMember = "MaLKH";
        }

        //check data
        private bool CheckData()
        {
            if (String.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được rỗng!");
                return false;
            }
            if (String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được rỗng!");
                return false;
            }
            if (String.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được rỗng!");
                return false;
            }
            return true;
        }

        // thêm nhà xuất bản
        private void ThemKhachHang()
        {
            if (!this.CheckData())
            {
                return;
            }
            khachhang = new DTO.KhachHang
            {
                TenKH = txtTenKH.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                MaLKH = cmbLoaiKH.SelectedValue.ToString(),
                TienNo = 0,
            };
            BUS.KhachHangBUS.ThemKhachHang(khachhang);
            MessageBox.Show(BUS.KhachHangBUS.Message);
            if (BUS.KhachHangBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                khachhang = null;
                IsAdd = true;
            }
        }

        // sửa nhà xuất bản
        private void SuaKhachHang()
        {
            if (!this.CheckData())
            {
                return;
            }
            khachhang.TenKH = txtTenKH.Text;
            khachhang.DiaChi = txtDiaChi.Text;
            khachhang.SDT = txtSDT.Text;
            khachhang.MaLKH = cmbLoaiKH.SelectedValue.ToString();
            BUS.KhachHangBUS.SuaKhachHang(khachhang);
            MessageBox.Show(BUS.KhachHangBUS.Message);
            if (BUS.KhachHangBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                khachhang = null;
                IsAdd = true;
            }
        }

        // xóa nhà xuất bản
        private void XoaKhachHang()
        {
            BUS.KhachHangBUS.XoaKhachHang(khachhang);
            MessageBox.Show(BUS.KhachHangBUS.Message);
            if (BUS.KhachHangBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                khachhang = null;
                IsAdd = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                // thêm
                ThemKhachHang();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn sửa khách hàng này!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                // Sửa
                SuaKhachHang();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            // xóa
            XoaKhachHang();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetControls();
            khachhang = null;
            IsAdd = true;
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int rowIndex = e.RowIndex;
                int id = Int32.Parse(dgvDanhSach.Rows[rowIndex].Cells[0].Value.ToString());
                khachhang = DSKhachHang.Find(kh => kh.MaKH == id);
                if (khachhang == null)
                {
                    return;
                }
                IsAdd = false;
                txtTenKH.Text = khachhang.TenKH;
                txtSDT.Text = khachhang.SDT;
                txtDiaChi.Text = khachhang.DiaChi;
                cmbLoaiKH.SelectedValue = khachhang.MaLKH;
                btnDelete.Enabled = true;
            }
            catch (Exception er)
            {

            }
        }

    }
}
