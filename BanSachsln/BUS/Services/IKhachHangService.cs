using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services
{
    public interface IKhachHangService
    {
        IEnumerable<DTO.KhachHang> LayDanHSachKhachHang();
        IEnumerable<DTO.LoaiKhachHang> LayDanhSachLoaiKhachHang();
    }
}
