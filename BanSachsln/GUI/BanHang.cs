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
    public partial class BanHang : Form
    {
        List<DTO.KhachHang> DsKhachHang = new List<DTO.KhachHang>();
        List<DTO.Sach> DsSach = new List<DTO.Sach>();
        List<DTO.NhanVien> DsNhanVien = new List<DTO.NhanVien>();
        IBanHangService service;
        DTO.HoaDon hoadon;
        DTO.ChiTietHoaDon chitiet;
        List<DTO.ChiTietHoaDon> DsChiTiet = new List<DTO.ChiTietHoaDon>();
        string maHD = "";
        public BanHang()
        {
            InitializeComponent();
            service = new BanHangService();
            LoadData();
            if(maHD =="")
            {
                maHD = TaoMaHD();
            }
            dgvChiTiet.DataSource = DsChiTiet;
            dgvChiTiet.Refresh();
            ResetControls();
        }
        private void LoadData()
        {
            try
            {
                DsNhanVien = service.LayDanhSachNhanVien().ToList();
                cmbNhanVien.DataSource = DsNhanVien;
                cmbNhanVien.DisplayMember = "TenNV";
                cmbNhanVien.ValueMember = "MaNV";
            }
            catch { }
            try
            {
                DsKhachHang = service.LayDanhSachKhachHang().ToList();
                cmbKhachHang.DataSource = DsKhachHang;
                cmbKhachHang.DisplayMember = "TenKH";
                cmbKhachHang.ValueMember = "MaKH";
            }
            catch { }
            try
            {
                DsSach = service.LayDanhSachSach().ToList();
                cmbSach.DataSource = DsSach;
                cmbSach.DisplayMember = "TenSach";
                cmbSach.ValueMember = "MaSach";
            }
            catch { }    
        }
        private string TaoMaHD()
        {
            DateTime now = DateTime.Now;
            return ""+now.Day + now.Month + now.Year + now.Hour + now.Minute+now.Second;
        }
        private void ResetControls()
        {
            txtSoLuong.Text = "";
            txtMaHD.Text = maHD;
            txtTongTien.Text = "0";
        }
        private bool CheckDetail()
        {
            if(String .IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Số lượng khác rỗng!");
                return false;
            }
            try
            {
                if (Int32.Parse(txtSoLuong.Text) < 1)
                {
                    MessageBox.Show("Số lượng lớn hơn 0!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng là số!");
                return false;
            }
            return true;

        }
        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (!CheckDetail())
                return;
            chitiet = new DTO.ChiTietHoaDon
            {
                MaHD = maHD,
                MaSach = cmbSach.SelectedValue.ToString(),
                SoLuong = Int32.Parse(txtSoLuong.Text),
                DonGia = DsSach.Find(s => s.MaSach == cmbSach.SelectedValue.ToString()).GiaBanLe,
                TenSach = DsSach.Find(s => s.MaSach == cmbSach.SelectedValue.ToString()).TenSach
            };

            chitiet.DonGia = BanHangBUS.TinhDonGia(Int32.Parse(cmbKhachHang.SelectedValue.ToString()), chitiet);
            BindingSource binding = new BindingSource();
            binding.Clear();
            if (DsChiTiet.Find(ct =>ct.MaSach == chitiet.MaSach)==null)
            {
                DsChiTiet.Add(chitiet);
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn vừa thêm một sách đã có trong hóa đơn\n Bạn có muốn cập nhật số lượng hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                DsChiTiet.Find(ct => ct.MaSach == chitiet.MaSach).SoLuong = chitiet.SoLuong;
            }
            binding.DataSource = DsChiTiet;
            dgvChiTiet.DataSource = binding;
            //dgvChiTiet.Refresh();
            try
            {
                //dgvChiTiet.DataSource = new List<DTO.ChiTietHoaDon>();
                txtSoLuong.Text = "0";
                cmbSach.SelectedIndex = 0;
                chitiet = null;
                txtTongTien.Text = DsChiTiet.Sum(ct => ct.ThanhTien).ToString("0,0");
            }
            catch { }
            
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if(chitiet==null)
            {
                return;
            }
            DsChiTiet.Remove(chitiet);
            try
            {
                dgvChiTiet.DataSource = new List<DTO.ChiTietHoaDon>();
                dgvChiTiet.Refresh();
                dgvChiTiet.DataSource = DsChiTiet;
                dgvChiTiet.Refresh();
                txtSoLuong.Text = "0";
                cmbSach.SelectedIndex = 0;
                chitiet = null;
                txtTongTien.Text = DsChiTiet.Sum(ct => ct.ThanhTien).ToString("0,0");
            }
            catch { }
        }

        private void dgvChiTiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                string id = dgvChiTiet.Rows[rowIndex].Cells[1].Value.ToString();
                chitiet = DsChiTiet.Find(ct => ct.MaSach == id);
                if (chitiet == null)
                {
                    return;
                }
                txtSoLuong.Text = chitiet.SoLuong.ToString();
                cmbSach.SelectedValue = chitiet.MaSach;
            }
            catch(Exception er) { }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này không?\n"+
                "Chú ý: sau khi xóa tất cả các chi tiết sẽ bị xóa theo!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            try
            {
                DsChiTiet = new List<DTO.ChiTietHoaDon>();
                dgvChiTiet.DataSource = DsChiTiet;
                dgvChiTiet.Refresh();
                maHD = TaoMaHD();
                ResetControls();
                chitiet = null;
            }
            catch { }

        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            hoadon = new DTO.HoaDon
            {
                MaHD = txtMaHD.Text,
                MaKH = Int32.Parse(cmbKhachHang.SelectedValue.ToString()),
                MaNV = Int32.Parse(cmbNhanVien.SelectedValue.ToString()),
            };
            // kiểm tra chi tiết
            if(DsChiTiet.Count<=0)
            {
                MessageBox.Show("Không có chi tiết nào trong hóa đơn.\nVui lòng kiểm tra lại");
                return;
            }
            // gọi hàm thêm của Bus
            BanHangBUS.ThemHoaDon(hoadon, DsChiTiet);
            MessageBox.Show(BanHangBUS.Message);
            if(BanHangBUS.IsSuccess)
            {
                // Viết phần hiển thị màn hình In chổ này
                try
                {
                    DsChiTiet = new List<DTO.ChiTietHoaDon>();
                    dgvChiTiet.DataSource = DsChiTiet;
                    dgvChiTiet.Refresh();
                    maHD = TaoMaHD();
                    ResetControls();
                    chitiet = null;
                }
                catch { }
            }
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DTO.ChiTietHoaDon ct in DsChiTiet)
                {
                    ct.DonGia = BanHangBUS.TinhDonGia(Int32.Parse(cmbKhachHang.SelectedValue.ToString()), ct);
                }
                txtTongTien.Text = DsChiTiet.Sum(ct => ct.ThanhTien).ToString("0,0");
                dgvChiTiet.DataSource = new List<DTO.ChiTietHoaDon>();
                dgvChiTiet.Refresh();
                dgvChiTiet.DataSource = DsChiTiet;
                dgvChiTiet.Refresh();
            }
            catch { }
            
        }
    }
}
