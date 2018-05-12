using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class ThanhToanService : IThanhToanService
    {
        private QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public IEnumerable<KhachHang> LayDanhSachKhachHang()
        {
            IKhachHangService service = new KhachHangService();
            return service.LayDanHSachKhachHang();
        }

        public IEnumerable<ThanhToan> LayDanhSachThanhToan(int makh)
        {
            IEnumerable<ThanhToan> res = from tt in db.THANHTOANs
                                         join kh in db.KHACHHANGs on tt.MaKhachHang equals kh.MaKH
                                         where tt.MaKhachHang == makh
                                         select new ThanhToan
                                         {
                                             MaTT = tt.MaThanhToan,
                                             MaKH = tt.MaKhachHang,
                                             NgayTT = tt.NgayThanhToan.Value,
                                             SoTien = tt.SoTien.Value,
                                             TenKH = kh.TenKH,
                                         };
            return res;
        }
    }
}
