using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class KhachHangService : IKhachHangService
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public IEnumerable<KhachHang> LayDanHSachKhachHang()
        {
            IEnumerable<KhachHang> res = from kh in db.KHACHHANGs
                                         join lkh in db.LOAIKHACHHANGs on kh.MaLoaiKH equals lkh.MaLoaiKH
                                         select new KhachHang
                                         {
                                             MaKH = kh.MaKH,
                                             DiaChi = kh.DiaChi,
                                             MaLKH = kh.MaLoaiKH,
                                             SDT = kh.SoDienThoaiKH,
                                             TenKH = kh.TenKH,
                                             TienNo =kh.TienNo.Value,
                                             TenLKH = lkh.TenLoaiKH
                                         };
            return res;
        }

        public IEnumerable<LoaiKhachHang> LayDanhSachLoaiKhachHang()
        {
            IEnumerable<LoaiKhachHang> res = from lkh in db.LOAIKHACHHANGs
                                             select new LoaiKhachHang
                                             {
                                                 MaLKH = lkh.MaLoaiKH,
                                                 TenLKH = lkh.TenLoaiKH
                                             };
            return res;
        }
    }
}
