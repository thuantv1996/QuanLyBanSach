using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public String TenNV { get; set; }
        public String DiaChi { get; set; }
        public String SDT { get; set; }
        public String CMND { get; set; }
        public DateTime NgaySinh { get; set; }
        public int MaLoaiNV { get; set; }
        public String TenLoaiNV { get; set; }
    }
}
