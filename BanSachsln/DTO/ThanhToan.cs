using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThanhToan
    {
        public int MaTT { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public DateTime NgayTT { get; set; }
        public double SoTien { get; set; }
    }
}
