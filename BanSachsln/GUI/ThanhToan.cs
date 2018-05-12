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
    public partial class ThanhToan : Form
    {
        List<DTO.KhachHang> DsKhachHang = new List<DTO.KhachHang>();
        List<DTO.ThanhToan> DsThanhToan = new List<DTO.ThanhToan>();
        bool IsAdd = true;
        DTO.ThanhToan thanhtoan = null;
        IThanhToanService service;
        public ThanhToan()
        {
            InitializeComponent();
            service = new ThanhToanService();
            LoadData();
            ResetControls();
        }
        //reset controls
        private void ResetControls()
        {
            try { cmbKhachHang.SelectedIndex = 0; } catch { }
            txtSoTien.Text = "";
            cmbKhachHang.Enabled = true;
            btnDelete.Enabled = false;
        }

        // Load data
        private void LoadData()
        {
            try
            {
                DsKhachHang = service.LayDanhSachKhachHang().ToList();
                cmbKhachHang.DataSource = DsKhachHang;
                cmbKhachHang.DisplayMember = "TenKH";
                cmbKhachHang.ValueMember = "MaKH";
            }catch{ }
            try
            {
                DsThanhToan = service.LayDanhSachThanhToan(Int32.Parse(cmbKhachHang.SelectedValue.ToString())).ToList();
                dgvDanhSach.DataSource = DsThanhToan;
            }
            catch { }
            
        }

        //check data
        private bool CheckData()
        {
            if (String.IsNullOrEmpty(txtSoTien.Text))
            {
                MessageBox.Show("Số tiền thanh toán khác rỗng!");
                return false;
            }
            try
            {
                if(Double.Parse(txtSoTien.Text)<0)
                {
                    MessageBox.Show("Số tiền thanh toán lớn hơn 0!");
                    return false;
                }
            }catch
            {
                MessageBox.Show("Số tiền thanh toán là số thực!");
                return false;
            }
            return true;
        }

        // thêm
        private void Them()
        {
            if (!this.CheckData())
            {
                return;
            }
            thanhtoan = new DTO.ThanhToan
            {
                MaKH = Int32.Parse(cmbKhachHang.SelectedValue.ToString()),
                SoTien = Double.Parse(txtSoTien.Text),
                NgayTT = DateTime.Now,
            };
            BUS.ThanhToanBUS.Them(thanhtoan);
            MessageBox.Show(BUS.ThanhToanBUS.Message);
            if (BUS.ThanhToanBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                thanhtoan = null;
                IsAdd = true;
            }
        }

        // sửa
        private void Sua()
        {
            if (!this.CheckData())
            {
                return;
            }
            thanhtoan.MaKH = Int32.Parse(cmbKhachHang.SelectedValue.ToString());
            thanhtoan.SoTien = Double.Parse(txtSoTien.Text);
            BUS.ThanhToanBUS.Sua(thanhtoan);
            MessageBox.Show(BUS.ThanhToanBUS.Message);
            if (BUS.ThanhToanBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                thanhtoan = null;
                IsAdd = true;
            }
        }

        // xóa nhà xuất bản
        private void Xoa()
        {
            BUS.ThanhToanBUS.Xoa(thanhtoan);
            MessageBox.Show(BUS.ThanhToanBUS.Message);
            if (BUS.ThanhToanBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                thanhtoan = null;
                IsAdd = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                // thêm
                Them();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn sửa thanh toán này!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                // Sửa
                Sua();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa thanh toán này!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            // xóa
            Xoa();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetControls();
            thanhtoan = null;
            IsAdd = true;
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int rowIndex = e.RowIndex;
                int id = Int32.Parse(dgvDanhSach.Rows[rowIndex].Cells[0].Value.ToString());
                thanhtoan = DsThanhToan.Find(tt=>tt.MaTT==id);
                if (thanhtoan == null)
                {
                    return;
                }
                IsAdd = false;
                txtSoTien.Text = thanhtoan.SoTien.ToString();
                cmbKhachHang.SelectedValue = thanhtoan.MaKH;
                btnDelete.Enabled = true;
            }
            catch (Exception er)
            {

            }
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DsThanhToan = service.LayDanhSachThanhToan(Int32.Parse(cmbKhachHang.SelectedValue.ToString())).ToList();
                dgvDanhSach.DataSource = DsThanhToan;
            }
            catch { }
        }
    }
}
