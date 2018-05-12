using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services
{
    public interface IThanhToanService
    {
        IEnumerable<DTO.ThanhToan> LayDanhSachThanhToan(int makh);
        IEnumerable<DTO.KhachHang> LayDanhSachKhachHang();
    }
}
