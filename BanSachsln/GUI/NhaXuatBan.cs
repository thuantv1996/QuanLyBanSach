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
    public partial class NhaXuatBan : Form
    {
        List<DTO.NhaXuatBan> DanhSachNXB = new List<DTO.NhaXuatBan>();
        BUS.Services.INhaXuatBanService service;
        DTO.NhaXuatBan nhaxuatban = null;
        bool IsAdd = true;
        public NhaXuatBan()
        {
            InitializeComponent();
            service = new BUS.Services.NhaXuatBanService();
            ResetControls();
            LoadData();
        }

        //reset controls
        private void ResetControls()
        {
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTenNXB.Text = "";
            btnDelete.Enabled = false;
        }

        // Load data
        private void LoadData()
        { 
            DanhSachNXB = service.LayDanhSachNXB().ToList();
            dgvDanhSach.DataSource = DanhSachNXB;
        }

        //check data
        private bool CheckData()
        {
            if (String.IsNullOrEmpty(txtTenNXB.Text))
            {
                MessageBox.Show("Tên nhà xuất bản khác rỗng!");
                return false;
            }
            if (String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ khác rỗng!");
                return false;
            }
            if (String.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại khác rỗng!");
                return false;
            }
            return true;
        }

        // thêm nhà xuất bản
        private void ThemNXB()
        {
            if(!this.CheckData())
            {
                return;
            }
            nhaxuatban = new DTO.NhaXuatBan
            {
                TenNXB = txtTenNXB.Text,
                DiaChiNXB = txtDiaChi.Text,
                SoDienThoaiNXB = txtSDT.Text
            };
            BUS.NhaXuatBanBUS.ThemNhaXuatBan(nhaxuatban);
            MessageBox.Show(BUS.NhaXuatBanBUS.Message);
            if(BUS.NhaXuatBanBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                nhaxuatban = null;
                IsAdd = true;
            }
        }

        // sửa nhà xuất bản
        private void SuaNXB()
        {
            if (!this.CheckData())
            {
                return;
            }
            nhaxuatban.TenNXB = txtTenNXB.Text;
            nhaxuatban.DiaChiNXB = txtDiaChi.Text;
            nhaxuatban.SoDienThoaiNXB = txtSDT.Text;
            BUS.NhaXuatBanBUS.SuaNhaXuatBan(nhaxuatban);
            MessageBox.Show(BUS.NhaXuatBanBUS.Message);
            if (BUS.NhaXuatBanBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                nhaxuatban = null;
                IsAdd = true;
            }
        }

        // xóa nhà xuất bản
        private void XoaNXB()
        {
            BUS.NhaXuatBanBUS.XoaNhaXuatBan(nhaxuatban);
            MessageBox.Show(BUS.NhaXuatBanBUS.Message);
            if (BUS.NhaXuatBanBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                nhaxuatban = null;
                IsAdd = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(IsAdd)
            {
                // thêm
                ThemNXB();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn sửa nhà xuất bản này!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                // Sửa
                SuaNXB();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa nhà xuất bản này!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            // xóa
            XoaNXB();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetControls();
            nhaxuatban = null;
            IsAdd = true;
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int rowIndex = e.RowIndex;
                int id = Int32.Parse(dgvDanhSach.Rows[rowIndex].Cells[0].Value.ToString());
                nhaxuatban = DanhSachNXB.Find(nxb => nxb.MaNXB == id);
                if (nhaxuatban == null)
                {
                    return;
                }
                IsAdd = false;
                txtTenNXB.Text = nhaxuatban.TenNXB;
                txtSDT.Text = nhaxuatban.SoDienThoaiNXB;
                txtDiaChi.Text = nhaxuatban.DiaChiNXB;
                btnDelete.Enabled = true;
            }catch(Exception er)
            {

            }
        }

       
    }
}
