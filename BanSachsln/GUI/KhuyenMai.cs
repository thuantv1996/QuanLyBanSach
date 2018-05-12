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
    public partial class KhuyenMai : Form
    {
        List<DTO.KhuyenMai> DSKhuyenMai = new List<DTO.KhuyenMai>();
        DTO.KhuyenMai khuyenmai = null;
        bool IsAdd = true;
        IKhuyenMaiService service = null;
        public KhuyenMai()
        {
            InitializeComponent();
            service = new KhuyenMaiService();
            LoadData();
            ResetControls();
        }
        // load data
        private void LoadData()
        {
            DSKhuyenMai = service.LayDanhSachKhuyenMai().ToList();
            dgvDanhSach.DataSource = DSKhuyenMai;
        }
        //reset controls
        private void ResetControls()
        {
            txtMaKM.Enabled = true;
            btnDetail.Enabled = false;
            btnDelete.Enabled = false;
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            dtBatDau.Value = DateTime.Now;
            dtKetThuc.Value = DateTime.Now;
        }
        //check info
        private bool CheckData()
        {
            if(String.IsNullOrEmpty(txtMaKM.Text))
            {
                MessageBox.Show("Mã khuyến mãi khác rỗng!");
                txtMaKM.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtTenKM.Text))
            {
                MessageBox.Show("Tên khuyến mãi khác rỗng!");
                txtTenKM.Focus();
                return false;
            }
            return true;
        }
        // them
        private void ThemKhuyenMai()
        {
            if(!CheckData())
            {
                return;
            }
            khuyenmai = new DTO.KhuyenMai
            {
                MaKM = txtMaKM.Text,
                TenKM = txtTenKM.Text,
                NgayBatDau = dtBatDau.Value,
                NgayKetThuc = dtKetThuc.Value
            };
            // gọi hàm thêm của BUS
            KhuyenMaiBUS.ThemKhuyenMai(khuyenmai);
            MessageBox.Show(KhuyenMaiBUS.Message);
            if(KhuyenMaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                khuyenmai = null;
                IsAdd = true;
            }
        }
        // sua
        private void SuaKhuyenMai()
        {
            if (!CheckData())
            {
                return;
            }
            khuyenmai.TenKM = txtTenKM.Text;
            khuyenmai.NgayBatDau = dtBatDau.Value;
            khuyenmai.NgayKetThuc = dtKetThuc.Value;
            // gọi hàm sửa của BUS
            KhuyenMaiBUS.SuaKhuyenMai(khuyenmai);
            MessageBox.Show(KhuyenMaiBUS.Message);
            if (KhuyenMaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                khuyenmai = null;
                IsAdd = true;
            }
        }
        //xóa
        private void XoaKhuyenMai()
        {
            // gọi hàm xóa của bus
            KhuyenMaiBUS.XoaKhuyenMai(khuyenmai);
            MessageBox.Show(KhuyenMaiBUS.Message);
            if (KhuyenMaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                khuyenmai = null;
                IsAdd = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(IsAdd)
            {
                ThemKhuyenMai();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn sửa khuyến mãi này!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                SuaKhuyenMai();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa khuyến mãi này không?\n"+
                "Lưu ý khi xóa khuyến mãi này thì tất cả các chi tiết khuyến mãi sẽ bị xóa theo! ", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            XoaKhuyenMai();
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                string id = dgvDanhSach.Rows[rowIndex].Cells[0].Value.ToString();
                khuyenmai = DSKhuyenMai.Find(km => km.MaKM == id);
                if (khuyenmai == null)
                {
                    return;
                }
                IsAdd = false;
                txtMaKM.Text = khuyenmai.MaKM;
                txtTenKM.Text = khuyenmai.TenKM;
                dtBatDau.Value = khuyenmai.NgayBatDau;
                dtKetThuc.Value = khuyenmai.NgayKetThuc;
                btnDelete.Enabled = true;
                btnDetail.Enabled = true;
                txtMaKM.Enabled = false;
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetControls();
            khuyenmai = null;
            IsAdd = true;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            ChiTietKhuyenMai fChiTiet = new ChiTietKhuyenMai(khuyenmai.MaKM);
            fChiTiet.Show();
        }
    }
}
