using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services
{
    public interface IChiTietKhuyenMaiService
    {
        IEnumerable<DTO.ChiTietKhuyenMai> LayDanhSachChiTiet(string MaKM);
        IEnumerable<DTO.TheLoai> LayDanhSachTheLoai();
    }
}
