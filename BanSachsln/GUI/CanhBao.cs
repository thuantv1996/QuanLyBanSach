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
    public partial class CanhBao : Form
    {
        public CanhBao()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            BUS.Services.ISachService service = new BUS.Services.SachService();
            IEnumerable<DTO.Sach> DSSach =  service.LayDanhSachSach();
            foreach(DTO.Sach s in DSSach)
            {
                if(s.SoLuong < DTO.Regulations.TonToiThieu)
                {
                    lblMaSach.Text += s.MaSach.ToString() + "\n";
                    lblTenSach.Text += s.TenSach.ToString() + "\n";
                    lblSoLuong.Text += s.SoLuong.ToString() + "\n";
                }
            }
        }
    }
}
