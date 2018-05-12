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
    public partial class QuyDinh : Form
    {
        public QuyDinh()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            txtNoToiDa.Text = DTO.Regulations.NoToiDa.ToString();
            txtSoLuongBanSi.Text = DTO.Regulations.SoLuongBanSi.ToString();
            txtTonToiThieu.Text = DTO.Regulations.TonToiThieu.ToString();
            txtTuoiToiThieu.Text = DTO.Regulations.TuoiToiThieu.ToString();
        }
        private bool CheckData()
        {
            try
            {
                if(Int32.Parse(txtSoLuongBanSi.Text)<0)
                {
                    MessageBox.Show("Số lượng bán sĩ phải lớn hơn 0!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng bán sĩ phải là số!");
                return false;
            }
            try
            {
                if (Int32.Parse(txtTonToiThieu.Text) < 0)
                {
                    MessageBox.Show("Tồn tối thiểu phải lớn hơn 0!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng bán sĩ phải là số!");
                return false;
            }
            try
            {
                if (Int32.Parse(txtTuoiToiThieu.Text) < 0)
                {
                    MessageBox.Show("Tuổi tối thiểu phải lớn hơn 0!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng bán sĩ phải là số!");
                return false;
            }
            try
            {
                if (Double.Parse(txtNoToiDa.Text) < 0)
                {
                    MessageBox.Show("Nợ tối đa phải lớn hơn 0!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng bán sĩ phải là số!");
                return false;
            }
            return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!CheckData())
            {
                return;
            }
            int TuoiToiThieu = Int32.Parse(txtTuoiToiThieu.Text);
            int NoToiDa = Int32.Parse(txtNoToiDa.Text);
            int SoLuongBanSi = Int32.Parse(txtSoLuongBanSi.Text);
            int TonToiThieu = Int32.Parse(txtTonToiThieu.Text);
            // Lưu xuống csdl
            BUS.QuyDinhBUS.LuuQuyDinh(TuoiToiThieu, NoToiDa, SoLuongBanSi, TonToiThieu);
            // chỉnh sửa Tham số
            DTO.Regulations.TuoiToiThieu = (int)TuoiToiThieu;
            DTO.Regulations.NoToiDa = NoToiDa;
            DTO.Regulations.SoLuongBanSi = (int)SoLuongBanSi;
            DTO.Regulations.TonToiThieu = (int)TonToiThieu;
            MessageBox.Show("Lưu thành công!");

        }
    }
}
