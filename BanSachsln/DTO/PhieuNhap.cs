using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap
    {
        public string MaPN { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNV { get; set; }
        public int MaNXB { get; set; }
        public string TenNV { get; set; }
        public string TenNXB { get; set; }
        public double TongTien { get; set; }
    }
}
