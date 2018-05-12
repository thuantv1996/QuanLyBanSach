using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class ChiTietKhuyenMaiService : IChiTietKhuyenMaiService
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public IEnumerable<ChiTietKhuyenMai> LayDanhSachChiTiet(string MaKM)
        {
            IEnumerable<ChiTietKhuyenMai> res = from ct in db.CHITIETKHUYENMAIs
                                                join tl in db.THELOAIs on ct.MaTheLoai  equals tl.MaTheLoai
                                                where ct.MaKhuyenMai == MaKM
                                                select new ChiTietKhuyenMai
                                                {
                                                    MaKM = ct.MaKhuyenMai,
                                                    MaTheLoai = ct.MaTheLoai,
                                                    NoiDung = ct.NoiDung.Value,
                                                    TenTheLoai = tl.TenTheLoai
                                                };
            return res;
        }

        public IEnumerable<TheLoai> LayDanhSachTheLoai()
        {
            ITheLoaiService service = new TheLoaiService();
            return service.LayDanhSachTheLoai();
        }
    }
}
