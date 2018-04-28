using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BUS.Services
{
    public interface INhanVienService
    {
        IEnumerable<NhanVien> LayDanhSachNhanVien();
        IEnumerable<LoaiNhanVien> LayDanhSachLoaiNhanVien();
        NhanVien LayThongTinNhanVien(String id);
    }
}
