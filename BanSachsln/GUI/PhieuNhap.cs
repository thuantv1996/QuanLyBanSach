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
    public partial class PhieuNhap : Form
    {
        List<DTO.Sach> DSSach = new List<DTO.Sach>();
        List<DTO.NhaXuatBan> DSNXB = new List<DTO.NhaXuatBan>();
        List<DTO.NhanVien> DSNhanVien = new List<DTO.NhanVien>();
        List<DTO.PhieuNhap> DSPhieuNhap = new List<DTO.PhieuNhap>();
        List<DTO.ChiTietPhieuNhap> DSChiTiet = new List<DTO.ChiTietPhieuNhap>();
        DTO.PhieuNhap phieunhap = null;
        DTO.ChiTietPhieuNhap chitiet = null;
        INhapSachService service;
        bool IsAddDetail = true;
        bool IsAdd = true;

        public PhieuNhap()
        {
            InitializeComponent();
            service = new NhapSachService();
            LoadData();
            ResetControls();
        }

        // load data
        private void LoadData()
        {
            DSNhanVien = service.LayDanhSachNhanVien().ToList();
            cmbNhanVien.DataSource = DSNhanVien;
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";
            DSNXB = service.LayDanhSachNXB().ToList();
            cmbNXB.DataSource = DSNXB;
            cmbNXB.DisplayMember = "TenNXB";
            cmbNXB.ValueMember = "MaNXB";
            DSSach = service.LayDanhSachSach().Where(s => s.MaNXB == Int32.Parse(cmbNXB.SelectedValue.ToString())).ToList();
            cmbSach.DataSource = DSSach;
            cmbSach.DisplayMember = "TenSach";
            cmbSach.ValueMember = "MaSach";
            DSPhieuNhap = service.LayDanhSachPhieuNhap().ToList();
            dgvPhieuNhap.DataSource = DSPhieuNhap;
        }

        // reset controls
        private void ResetControls()
        {
            txtMaPhieu.Enabled = true;
            btnCTDelete.Enabled = false;
            btnDelete.Enabled = false;
            cmbNXB.Enabled = true;
            txtMaPhieu.Text = "";
            txtSoLuong.Text = "";
            try
            {
                cmbNhanVien.SelectedIndex = 0;
            }
            catch { }
            try
            {
                cmbNXB.SelectedIndex = 0;
            }
            catch { }
            try
            {
                cmbSach.SelectedIndex = 0;
            }
            catch { }
            dtNgayNhap.Value = DateTime.Now;
        }
        // check form
        private bool CheckBill()
        {
            if (String.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Mã phiếu nhập rỗng");
                txtMaPhieu.Focus();
                return false;
            }
            return true;
        }

        private bool CheckDetail()
        {
            if (String.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Số lượng khác rỗng!");
                txtSoLuong.Focus();
                return false;
            }
            try
            {
                if (Int32.Parse(txtSoLuong.Text) < 1)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!");
                    txtSoLuong.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng là số!");
                txtSoLuong.Focus();
                return false;
            }
            return true;
        }

        /* Xữ lý cho cả phiếu nhập*/
        // Thêm
        private void Them()
        {
            // Kiểm tra dữ liệu phieu nhap
            if (!CheckBill())
                return;
            if (DSChiTiet.Count < 1)
            {
                MessageBox.Show("Phiếu nhập cần có ít nhất 1 chi tiết!");
                return;
            }
            phieunhap = new DTO.PhieuNhap
            {
                MaPN = txtMaPhieu.Text,
                MaNV = Int32.Parse(cmbNhanVien.SelectedValue.ToString()),
                MaNXB = Int32.Parse(cmbNXB.SelectedValue.ToString()),
                NgayNhap = dtNgayNhap.Value,
            };
            // Thêm mã phiếu nhập vào từng CT
            foreach (DTO.ChiTietPhieuNhap ct in DSChiTiet)
            {
                ct.MaPN = phieunhap.MaPN;
            }
            // Thêm toàn bộ
            NhapSachBUS.Them(phieunhap, DSChiTiet);
            MessageBox.Show(NhapSachBUS.Message);
            if (NhapSachBUS.IsSucess)
            {
                ResetControls();
                LoadData();
                phieunhap = null;
                DSChiTiet = new List<DTO.ChiTietPhieuNhap>();
                dgvChiTiet.DataSource = DSChiTiet;
                IsAdd = true;
                IsAddDetail = true;
                dgvChiTiet.Refresh();
            }
        }
        // Sua
        private void Sua()
        {
            // Kiểm tra dữ liệu phieu nhap
            if (DSChiTiet.Count < 1)
            {
                MessageBox.Show("Phiếu nhập cần có ít nhất 1 chi tiết!");
                return;
            }
            phieunhap.MaNV = Int32.Parse(cmbNhanVien.SelectedValue.ToString());
            phieunhap.NgayNhap = dtNgayNhap.Value;
            
            // Thêm mã phiếu nhập vào từng CT
            foreach (DTO.ChiTietPhieuNhap ct in DSChiTiet)
            {
                ct.MaPN = phieunhap.MaPN;
            }
            //sua
            NhapSachBUS.Sua(phieunhap, DSChiTiet);
            MessageBox.Show(NhapSachBUS.Message);
            if (NhapSachBUS.IsSucess)
            {
                ResetControls();
                LoadData();
                phieunhap = null;
                DSChiTiet = new List<DTO.ChiTietPhieuNhap>();
                dgvChiTiet.DataSource = DSChiTiet;
                dgvChiTiet.Refresh();
                IsAdd = true;
                IsAddDetail = true;
            }
        }
        // Xoa
        private void Xoa()
        {
            phieunhap = new DTO.PhieuNhap
            {
                MaPN = txtMaPhieu.Text,
                MaNV = Int32.Parse(cmbNhanVien.SelectedValue.ToString()),
                MaNXB = Int32.Parse(cmbNXB.SelectedValue.ToString()),
                NgayNhap = dtNgayNhap.Value,
            };
            // xoa
            NhapSachBUS.Xoa(phieunhap);
            MessageBox.Show(NhapSachBUS.Message);
            if (NhapSachBUS.IsSucess)
            {
                ResetControls();
                LoadData();
                phieunhap = null;
                DSChiTiet = new List<DTO.ChiTietPhieuNhap>();
                dgvChiTiet.DataSource = DSChiTiet;
                dgvChiTiet.Refresh();
                IsAdd = true;
                IsAddDetail = true;
            }
        }

        /* Xữ lý cho chi tiết phiếu*/
        private void ThemCT()
        {
            if (!CheckDetail())
                return;
            chitiet = new DTO.ChiTietPhieuNhap
            {
                MaSach = cmbSach.SelectedValue.ToString(),
                SoLuong = Int32.Parse(txtSoLuong.Text),
                TenSach = cmbSach.Text,
            };
            DTO.ChiTietPhieuNhap ct = DSChiTiet.Find(c => (c.MaSach == chitiet.MaSach));
            dgvChiTiet.DataSource = new List<DTO.ChiTietPhieuNhap>();
            if (ct == null)
            {
                DSChiTiet.Add(chitiet);
            }
            else
            {
                ct.SoLuong += chitiet.SoLuong;
            }
            dgvChiTiet.DataSource = DSChiTiet;
            dgvChiTiet.Refresh();
            txtSoLuong.Text = "";
            try
            {
                cmbSach.SelectedIndex = 0;
            }
            catch { }
            IsAddDetail = true;
        }
        private void XoaCT()
        {
            DTO.ChiTietPhieuNhap ct = DSChiTiet.Find(c => (c.MaSach == chitiet.MaSach));
            DSChiTiet.Remove(ct);
            chitiet = null;   
            dgvChiTiet.DataSource = new List<DTO.ChiTietPhieuNhap>();
            dgvChiTiet.DataSource = DSChiTiet;
            dgvChiTiet.Refresh();
            txtSoLuong.Text = "";
            try
            {
                cmbSach.SelectedIndex = 0;
            }
            catch { }
            IsAddDetail = true;
            btnCTDelete.Enabled = false;
        }
        private void SuaCT()
        {
            if (!CheckDetail())
                return;
            chitiet.SoLuong = Int32.Parse(txtSoLuong.Text);
            DTO.ChiTietPhieuNhap ct = DSChiTiet.Find(c => (c.MaSach == chitiet.MaSach));
            ct.SoLuong = chitiet.SoLuong;
            chitiet = null;
            dgvChiTiet.DataSource = DSChiTiet;
            dgvChiTiet.Refresh();
            txtSoLuong.Text = "";
            try
            {
                cmbSach.SelectedIndex = 0;
            }
            catch { }
            IsAddDetail = true;
            btnCTDelete.Enabled = false;
        }


        private void cmbNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DSSach = service.LayDanhSachSach().Where(s => s.MaNXB == Int32.Parse(cmbNXB.SelectedValue.ToString())).ToList();
                cmbSach.DataSource = DSSach;
            }
            catch { }

        }

        private void btnCTOk_Click(object sender, EventArgs e)
        {
            if (IsAddDetail)
                ThemCT();
            else
                SuaCT();
        }

        private void dgvChiTiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                string ids = dgvChiTiet.Rows[rowIndex].Cells[1].Value.ToString();
                chitiet = DSChiTiet.Find(c => (c.MaSach == ids));
                txtSoLuong.Text = chitiet.SoLuong.ToString();
                cmbSach.SelectedValue = chitiet.MaSach;
                IsAddDetail = false;
                btnCTDelete.Enabled = true;
            }
            catch (Exception er)
            {
            }
        }

        private void btnCTDelete_Click(object sender, EventArgs e)
        {
            XoaCT();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                Them();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn sửa phiếu nhập này!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                Sua();
            }
        }

        private void dgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                // lấy phiếu nhập
                string id = dgvPhieuNhap.Rows[rowIndex].Cells[0].Value.ToString();
                phieunhap = DSPhieuNhap.Find(p => p.MaPN == id);
                if (phieunhap == null)
                {
                    return;
                }
                txtMaPhieu.Text = phieunhap.MaPN;
                cmbNhanVien.SelectedValue = phieunhap.MaNV;
                cmbNXB.SelectedValue = phieunhap.MaNXB;
                dtNgayNhap.Value = phieunhap.NgayNhap;
                // điều chỉnh controls
                IsAdd = false;
                txtMaPhieu.Enabled = false;
                cmbNXB.Enabled = false;
                btnDelete.Enabled = true;
                // load danh sach chi tiet
                DSChiTiet = service.LayDanhSachChiTiet(phieunhap.MaPN).ToList();
                dgvChiTiet.DataSource = DSChiTiet;
            }
            catch (Exception er)
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // nếu là manager mới được phép xóa
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập này!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            Xoa();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            LoadData();
            phieunhap = null;
            DSChiTiet = new List<DTO.ChiTietPhieuNhap>();
            dgvChiTiet.DataSource = DSChiTiet;
            dgvChiTiet.Refresh();
            IsAdd = true;
            IsAddDetail = true;
        }
    }
}
