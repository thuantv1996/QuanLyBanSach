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
    public partial class ChiTietKhuyenMai : Form
    {
        List<DTO.ChiTietKhuyenMai> DSChiTiet = new List<DTO.ChiTietKhuyenMai>();
        DTO.ChiTietKhuyenMai chitiet = null;
        bool IsAdd = true;
        List<DTO.TheLoai> DsTheLoai = new List<DTO.TheLoai>();
        IChiTietKhuyenMaiService service = null;
        string ma_khuyen_mai;
        public ChiTietKhuyenMai(string mkm)
        {
            InitializeComponent();
            ma_khuyen_mai = mkm;
            service = new ChiTietKhuyenMaiService();
            LoadData();
            ResetControls();
        }
        // load data
        private void LoadData()
        {
            DSChiTiet = service.LayDanhSachChiTiet(ma_khuyen_mai).ToList();
            dgvDanhSach.DataSource = DSChiTiet;
            DsTheLoai = service.LayDanhSachTheLoai().ToList();
            try
            {
                cmbTheLoai.DataSource = DsTheLoai;
                cmbTheLoai.DisplayMember = "TenTheLoai";
                cmbTheLoai.ValueMember = "MaTheLoai";
            }
            catch { }
        }
        // reset controls
        private void ResetControls()
        {
            txtNoiDung.Text = "";
            try
            {
                cmbTheLoai.SelectedIndex = 0;
            }
            catch { }
            btnDelete.Enabled = false;
            cmbTheLoai.Enabled = true;
        }
        // check data
        private bool CheckData()
        {
            if (String.IsNullOrEmpty(txtNoiDung.Text))
            {
                MessageBox.Show("Phần trăm giảm giá khác rỗng!");
                return false;
            }
            try
            {
                if (Int32.Parse(txtNoiDung.Text) < 0)
                {
                    MessageBox.Show("Phần trăm giảm giá phải lớn hơn 0!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Phần trăm giảm giá phải là số!");
                return false;
            }
            return true;
        }
        // Them
        private void Them()
        {
            if (!CheckData())
            {
                return;
            }
            chitiet = new DTO.ChiTietKhuyenMai
            {
                MaKM = ma_khuyen_mai,
                MaTheLoai = Int32.Parse(cmbTheLoai.SelectedValue.ToString()),
                NoiDung = Int32.Parse(txtNoiDung.Text)
            };
            if (DSChiTiet.Find(ct => ct.MaTheLoai == chitiet.MaTheLoai) != null)
            {
                DialogResult res = MessageBox.Show("Bạn đang thêm một chi tiết đã có trong danh sách\n Bạn có muốn sửa thông tin chi tiết không!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    cmbTheLoai.Focus();
                    return;
                }
                else
                {
                    Sua();
                    return;
                }
            }
            // thêm bus
            ChiTietKhuyenMaiBUS.Them(chitiet);
            MessageBox.Show(ChiTietKhuyenMaiBUS.Message);
            if (ChiTietKhuyenMaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                chitiet = null;
                IsAdd = true;
            }
        }
        // sua
        private void Sua()
        {
            if (!CheckData())
            {
                return;
            }
            chitiet.MaTheLoai = Int32.Parse(cmbTheLoai.SelectedValue.ToString());
            chitiet.NoiDung = Int32.Parse(txtNoiDung.Text);
            // sửa bus
            ChiTietKhuyenMaiBUS.Sua(chitiet);
            MessageBox.Show(ChiTietKhuyenMaiBUS.Message);
            if (ChiTietKhuyenMaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                chitiet = null;
                IsAdd = true;
            }
        }
        // xoa
        private void Xoa()
        {
            // xóa bus
            ChiTietKhuyenMaiBUS.Xoa(chitiet);
            MessageBox.Show(ChiTietKhuyenMaiBUS.Message);
            if (ChiTietKhuyenMaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                chitiet = null;
                IsAdd = true;
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                Them();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có muốn sửa thông tin chi tiết không?", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                Sua();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn xóa thông tin chi tiết không?", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            Xoa();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetControls();
            chitiet = null;
            IsAdd = true;
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int idTheLoai = Int32.Parse(dgvDanhSach.Rows[rowIndex].Cells[1].Value.ToString());
                chitiet = DSChiTiet.Find(ct => ct.MaTheLoai == idTheLoai);
                if(chitiet ==null)
                {
                    return;
                }
                IsAdd = false;
                txtNoiDung.Text = chitiet.NoiDung.ToString();
                try
                {
                    cmbTheLoai.SelectedValue = chitiet.MaTheLoai;
                }
                catch { }
                btnDelete.Enabled = true;
                cmbTheLoai.Enabled = false;
                
            }
            catch { }
        }
    }
}
