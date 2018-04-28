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
    public partial class TheLoai : Form
    {
        List<DTO.TheLoai> DanhSachTheLoai = new List<DTO.TheLoai>();
        BUS.Services.ITheLoaiService service;
        DTO.TheLoai theloai = null;
        bool IsAdd = true;
        public TheLoai()
        {
            InitializeComponent();
            service = new BUS.Services.TheLoaiService();
            ResetControls();
            LoadData();
        }
        //reset controls
        private void ResetControls()
        {
            txtTenTheLoai.Text = "";        
            btnDelete.Enabled = false;
        }

        // Load data
        private void LoadData()
        {
            DanhSachTheLoai = service.LayDanhSachTheLoai().ToList();
            dgvDanhSach.DataSource = DanhSachTheLoai;
        }

        //check data
        private bool CheckData()
        {
            if (String.IsNullOrEmpty(txtTenTheLoai.Text))
            {
                MessageBox.Show("Tên thể loại khác rỗng!");
                return false;
            }
            return true;
        }

        // thêm nhà xuất bản
        private void ThemTheLoai()
        {
            if (!this.CheckData())
            {
                return;
            }
            theloai = new DTO.TheLoai
            {
                TenTheLoai = txtTenTheLoai.Text
            };
            BUS.TheLoaiBUS.ThemTheLoai(theloai);
            MessageBox.Show(BUS.TheLoaiBUS.Message);
            if (BUS.TheLoaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                theloai = null;
                IsAdd = true;
            }
        }

        // sửa nhà xuất bản
        private void SuaTheLoai()
        {
            if (!this.CheckData())
            {
                return;
            }
            theloai.TenTheLoai = txtTenTheLoai.Text;
            BUS.TheLoaiBUS.SuaTheLoai(theloai);
            MessageBox.Show(BUS.TheLoaiBUS.Message);
            if (BUS.TheLoaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                theloai = null;
                IsAdd = true;
            }
        }

        // xóa nhà xuất bản
        private void XoaTheLoai()
        {
            BUS.TheLoaiBUS.XoaTheLoai(theloai);
            MessageBox.Show(BUS.TheLoaiBUS.Message);
            if (BUS.TheLoaiBUS.IsSuccess)
            {
                LoadData();
                ResetControls();
                theloai = null;
                IsAdd = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa thể loại này!", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }
            // xóa
            XoaTheLoai();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                // thêm
                ThemTheLoai();
            }
            else
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn sửa thể loại này!", "Thông báo", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
                // Sửa
                SuaTheLoai();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetControls();
            theloai = null;
            IsAdd = true;
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int id = Int32.Parse(dgvDanhSach.Rows[rowIndex].Cells[0].Value.ToString());
                theloai = DanhSachTheLoai.Find(tl => tl.MaTheLoai == id);
                if (theloai == null)
                {
                    return;
                }
                IsAdd = false;
                txtTenTheLoai.Text = theloai.TenTheLoai;   
                btnDelete.Enabled = true;
            }
            catch (Exception er)
            {

            }
        }
    }
}
