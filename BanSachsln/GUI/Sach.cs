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
using BUS.Services;

namespace GUI
{
    public partial class Sach : Form
    {
        DTO.Sach sach = null;
        List<DTO.Sach> DanhSachSach = new List<DTO.Sach>();
        List<DTO.NhaXuatBan> DanhSachNXB = new List<DTO.NhaXuatBan>();
        List<DTO.TheLoai> DanhSachTheLoai = new List<DTO.TheLoai>();
        ISachService service;
        bool IsAdd = true;
        public Sach()
        {
            InitializeComponent();
            service = new SachService();
            ResetControls();
            LoadData();
        }

        //reset controls
        void ResetControls()
        {
            txtGiaLe.Text = "";
            txtGiaSi.Text = "";
            txtMaSach.Text = "";
            txtMoTa.Text = "";
            txtGiaNhap.Text = "0";
            txtTacGia.Text = "";
            txtTenSach.Text = "";
            txtGiaNhap.Text = "";
            try
            {
                cmbNhaXuatBan.SelectedIndex = 0;
                cmbTheLoai.SelectedIndex = 0;
            }
            catch { }
            //
            txtMaSach.Enabled = true;
            txtGiaNhap.Enabled = false;
            btnDelete.Enabled = false;
        }
        // load data
        void LoadData()
        {
            DanhSachSach = service.LayDanhSachSach().ToList();
            dgvDanhSach.DataSource = DanhSachSach;
            DanhSachTheLoai = service.LayDanhSachTheLoai().ToList();
            cmbTheLoai.DataSource = DanhSachTheLoai;
            cmbTheLoai.DisplayMember = "TenTheLoai";
            cmbTheLoai.ValueMember = "MaTheLoai";
            DanhSachNXB = service.LayDanhSachNXB().ToList();
            cmbNhaXuatBan.DataSource = DanhSachNXB;
            cmbNhaXuatBan.DisplayMember = "TenNXB";
            cmbNhaXuatBan.ValueMember = "MaNXB";
        }
        //check data
        bool CheckData()
        {
            if(String.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Mã sách khác rỗng!");
                txtMaSach.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtTenSach.Text))
            {
                MessageBox.Show("Tên sách khác rỗng!");
                txtTenSach.Focus();
                return false;
            }
            
            if (String.IsNullOrEmpty(txtGiaLe.Text))
            {
                MessageBox.Show("Giá bán lẽ khác rỗng!");
                txtGiaLe.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtGiaSi.Text))
            {
                MessageBox.Show("Giá bán sỉ khác rỗng!");
                txtGiaSi.Focus();
                return false;
            }
            try {
                Double.Parse(txtGiaLe.Text);
            }
            catch
            {
                MessageBox.Show("Giá bán lẽ là số!");
                txtGiaLe.Focus();
                return false;
            }
            try
            {
                Double.Parse(txtGiaSi.Text);
            }
            catch
            {
                MessageBox.Show("Giá bán sĩ là số!");
                txtGiaSi.Focus();
                return false;
            }
            try
            {
                if(Double.Parse(txtGiaNhap.Text)<0)
                {
                    MessageBox.Show("Giá bán nhập lớn hơn 0!");
                    txtGiaNhap.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Giá bán nhập là số!");
                txtGiaNhap.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtTacGia.Text))
            {
                MessageBox.Show("Tác giả sách khác rỗng!");
                txtTacGia.Focus();
                return false;
            }
            return true;
        }

        void ThemSach()
        {
            if(!CheckData())
            {
                return;
            }
            sach = new DTO.Sach
            {
                MaSach = txtMaSach.Text,
                TenSach = txtTenSach.Text,
                MaNXB = Int32.Parse(cmbNhaXuatBan.SelectedValue.ToString()),
                MaTheLoai = Int32.Parse(cmbTheLoai.SelectedValue.ToString()),
                MoTa = txtMoTa.Text,
                GiaBanLe = Double.Parse(txtGiaLe.Text),
                GiaBanSi = Double.Parse(txtGiaSi.Text),
                TacGia = txtTacGia.Text,
                SoLuong = Int32.Parse(txtGiaNhap.Text),
                 GiaNhap = Double.Parse(txtGiaNhap.Text)
            };
            SachBUS.ThemSach(sach);
            MessageBox.Show(SachBUS.Message);
            if (BUS.SachBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                sach = null;
                IsAdd = true;
            }
        }

        void SuaSach()
        {
            if (!CheckData())
            {
                return;
            }
            sach = new DTO.Sach
            {
                MaSach = txtMaSach.Text,
                TenSach = txtTenSach.Text,
                MaNXB = Int32.Parse(cmbNhaXuatBan.SelectedValue.ToString()),
                MaTheLoai = Int32.Parse(cmbTheLoai.SelectedValue.ToString()),
                MoTa = txtMoTa.Text,
                GiaBanLe = Int32.Parse(txtGiaLe.Text),
                GiaBanSi = Int32.Parse(txtGiaSi.Text),
                TacGia = txtTacGia.Text,
                SoLuong = Int32.Parse(txtGiaNhap.Text)
            };
            SachBUS.SuaSach(sach);
            MessageBox.Show(SachBUS.Message);
            if (BUS.SachBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                sach = null;
                IsAdd = true;
            }
        }

        void XoaSach()
        {
            SachBUS.XoaSach(sach);
            MessageBox.Show(SachBUS.Message);
            if (BUS.SachBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                sach = null;
                IsAdd = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(IsAdd)
            {
                ThemSach();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn sửa thông tin sách này!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                SuaSach();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa sách này!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            XoaSach();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            LoadData();
            sach = null;
            IsAdd = true;
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                String id = dgvDanhSach.Rows[rowIndex].Cells[0].Value.ToString();
                sach = DanhSachSach.Find(s => s.MaSach == id);
                if (sach == null)
                {
                    return;
                }
                IsAdd = false;
                txtMaSach.Text = sach.MaSach;
                txtTenSach.Text = sach.TenSach;
                txtMoTa.Text = sach.MoTa;
                txtGiaNhap.Text = sach.SoLuong.ToString();
                txtGiaLe.Text = sach.GiaBanLe.ToString();
                txtGiaSi.Text = sach.GiaBanSi.ToString();
                txtTacGia.Text = sach.TacGia;
                cmbNhaXuatBan.SelectedValue = sach.MaNXB;
                cmbTheLoai.SelectedValue = sach.MaTheLoai;
                txtMaSach.Enabled = false;
                btnDelete.Enabled = true;
            }
            catch { }
        }


    }
}
