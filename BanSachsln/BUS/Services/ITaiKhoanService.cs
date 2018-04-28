using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public interface ITaiKhoanService
    {
        IEnumerable<TaiKhoan> LayDanhSachTaiKhoan();
        IEnumerable<NhanVien> LayDanhSachNhanVien();
    }
}
