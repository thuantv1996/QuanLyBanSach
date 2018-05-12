using Microsoft.Reporting.WinForms;
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
    public partial class BaoCaoCongNo : Form
    {
        public BaoCaoCongNo()
        {
            InitializeComponent();
        }

        private void BaoCaoCongNo_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime Time = new DateTime(now.Year, now.Month, 1);
            txtThang.Text = Time.AddDays(-1).Month.ToString();
            txtNam.Text = Time.AddDays(-1).Year.ToString();

            this.reportViewer1.RefreshReport();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // kiểm tra dữ liệu
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
            try
            {
                 thang = Int32.Parse(txtThang.Text);
                if(thang<1 || thang>12)
                {
                    MessageBox.Show("Tháng lớn hơn 1 và bé hơn 12");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Tháng là số");
                return;
            }
            try
            {
                nam = Int32.Parse(txtNam.Text);
                if (nam < 2000 || nam > 9999)
                {
                    MessageBox.Show("Năm là số dương lớn hơn 2000 và bé hơn 9999!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Năm phải là số!");
                return;
            }
            // Tạo repost
            QuanLyBanSach ds = new QuanLyBanSach();
            reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.BaoCaoCongNo.rdlc";
            Microsoft.Reporting.WinForms.ReportDataSource rdSource =
                        new Microsoft.Reporting.WinForms.ReportDataSource();
            rdSource.Name = "DataSet1";
            rdSource.Value = ds.BaoCaoCongNo;
            reportViewer1.LocalReport.DataSources.Add(rdSource);
            QuanLyBanSachTableAdapters.BaoCaoCongNoTableAdapter datasetAdapter =
                       new QuanLyBanSachTableAdapters.BaoCaoCongNoTableAdapter();
            datasetAdapter.ClearBeforeFill = true;
            datasetAdapter.Fill(ds.BaoCaoCongNo);
            reportViewer1.RefreshReport();
            //set Parameter
            ReportParameter[] lstPara = new ReportParameter[4];
            lstPara[0] = new ReportParameter("Thang");
            lstPara[0].Values.Add(thang.ToString());
            lstPara[1] = new ReportParameter("Nam");
            lstPara[1].Values.Add(nam.ToString());
            DateTime batdau = new DateTime(nam, thang, 1);
            DateTime ketthuc = new DateTime(nam, thang, DateTime.DaysInMonth(nam, thang));
            lstPara[2] = new ReportParameter("BatDau");
            lstPara[2].Values.Add(batdau.ToString());
            lstPara[3] = new ReportParameter("KetThuc");
            lstPara[3].Values.Add(ketthuc.ToString());
            reportViewer1.LocalReport.SetParameters(lstPara);
            reportViewer1.RefreshReport();
            //hiển thị
            reportViewer1.LocalReport.DisplayName = "CongNo";
        }
    }
}
