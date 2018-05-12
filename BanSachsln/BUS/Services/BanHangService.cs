using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS.Services
{
    public class BanHangService : IBanHangService
    {
        public IEnumerable<KhachHang> LayDanhSachKhachHang()
        {
            IKhachHangService service = new KhachHangService();
            return service.LayDanHSachKhachHang();
        }

        public IEnumerable<NhanVien> LayDanhSachNhanVien()
        {
            INhanVienService service = new NhanVienService();
            return service.LayDanhSachNhanVien();
        }

        public IEnumerable<Sach> LayDanhSachSach()
        {
            ISachService service = new SachService();
            return service.LayDanhSachSach();
        }
    }
}
