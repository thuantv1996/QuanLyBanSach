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
    public partial class fNhanVien : Form
    {
        // khai báo đối tượng
        private INhanVienService ServiceNhanVienForm;
        private List<NhanVien> DanhSachNhanVien = new List<NhanVien>();
        private List<LoaiNhanVien> DSLoaiNhaNVien = new List<LoaiNhanVien>();
        private NhanVien nhanvien;
        bool isAdd = true;
        public fNhanVien()
        {
            InitializeComponent();
            ServiceNhanVienForm = new NhanVienService();
            LoadData();
            ResetControls();
        }
        // các phương thức
        private void LoadData()
        {
            try
            {
                DanhSachNhanVien = ServiceNhanVienForm.LayDanhSachNhanVien().ToList();
                dgvDanhSach.DataSource = DanhSachNhanVien.ToList();
            }
            catch (Exception e) { }
            try
            {
                DSLoaiNhaNVien = ServiceNhanVienForm.LayDanhSachLoaiNhanVien().ToList();
                cmbLoaiNV.DataSource = DSLoaiNhaNVien;
                cmbLoaiNV.DisplayMember = "TenLoai";
                cmbLoaiNV.ValueMember = "MaLoai";
            }
            catch (Exception e) { }       
        }
        // Kiểm tra dữ liệu
        private bool CheckData()
        {
            if (String.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên khác rỗng");
                return false;
            }
            if (String.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại khác rỗng");
                return false;
            }
            if (String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ khác rỗng");
                return false;
            }
            if (String.IsNullOrEmpty(txtCMND.Text))
            {
                MessageBox.Show("CMND khác rỗng");
                return false;
            }
            return true;
        }
        private void ThemNhanVien()
        {
            if(!CheckData())
            {
                return;
            }
            nhanvien = new NhanVien
            {
                TenNV = txtTenNV.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                MaLoaiNV = Int32.Parse(cmbLoaiNV.SelectedValue.ToString()),
                NgaySinh = dtNgaySinh.Value,
                CMND = txtCMND.Text,
            };
            NhanVienBUS.ThemNhanVien(nhanvien);
            MessageBox.Show(NhanVienBUS.Message);
            if(NhanVienBUS.isSucess)
            {
                LoadData();
                ResetControls();
            }
            
        }
        private void SuaNhanVien()
        {
            if (!CheckData())
            {
                return;
            }
            nhanvien.TenNV = txtTenNV.Text;
            nhanvien.DiaChi = txtDiaChi.Text;
            nhanvien.SDT = txtSDT.Text;
            nhanvien.MaLoaiNV = Int32.Parse(cmbLoaiNV.SelectedValue.ToString());
            nhanvien.NgaySinh = dtNgaySinh.Value;
            nhanvien.CMND = txtCMND.Text;
            NhanVienBUS.SuaNhanVien(nhanvien);
            MessageBox.Show(NhanVienBUS.Message);
            if (NhanVienBUS.isSucess)
            {
                LoadData();
                ResetControls();
                isAdd = true;
            }
        }
        private void XoaNhaNVien()
        {
            NhanVienBUS.XoaNhanVien(nhanvien);
            MessageBox.Show(NhanVienBUS.Message);
            if (NhanVienBUS.isSucess)
            {
                LoadData();
                ResetControls();
                isAdd = true;
            }
        }
        // reset control
        private void ResetControls()
        {
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTenNV.Text = "";
            cmbLoaiNV.SelectedIndex = 0;
            dtNgaySinh.Value = DateTime.Now;
            nhanvien = new NhanVien();
            btnDelete.Enabled = false;
        }
        // sự kiện
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(isAdd)
            {
                ThemNhanVien();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn sửa nhân viên này!", "Thông báo", MessageBoxButtons.YesNo);
                if(res == DialogResult.No)
                {
                    return;
                }
                SuaNhanVien();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            isAdd = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            XoaNhaNVien();
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int id = Int32.Parse(dgvDanhSach.Rows[rowIndex].Cells[0].Value.ToString());
                nhanvien = DanhSachNhanVien.Find(nv => nv.MaNV == id);
                if (nhanvien == null)
                {
                    return;
                }
                txtCMND.Text = nhanvien.CMND;
                txtDiaChi.Text = nhanvien.DiaChi;
                txtSDT.Text = nhanvien.SDT;
                txtTenNV.Text = nhanvien.TenNV;
                cmbLoaiNV.SelectedValue = nhanvien.MaLoaiNV;
                dtNgaySinh.Value = nhanvien.NgaySinh;
                btnDelete.Enabled = true;
                isAdd = false;
            }
            catch{ }
            
        }
    }
}
