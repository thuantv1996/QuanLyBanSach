using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services
{
    public interface IBanHangService
    {
        IEnumerable<DTO.Sach> LayDanhSachSach();
        IEnumerable<DTO.KhachHang> LayDanhSachKhachHang();
        IEnumerable<DTO.NhanVien> LayDanhSachNhanVien();
    }
}
