using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS.Services
{
    public interface INhapSachService
    {
        IEnumerable<NhanVien> LayDanhSachNhanVien();
        IEnumerable<NhaXuatBan> LayDanhSachNXB();
        IEnumerable<Sach> LayDanhSachSach();
        IEnumerable<PhieuNhap> LayDanhSachPhieuNhap();
        IEnumerable<ChiTietPhieuNhap> LayDanhSachChiTiet(string mapn);
    }
}
