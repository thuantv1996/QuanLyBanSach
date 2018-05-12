using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class KhuyenMaiService : IKhuyenMaiService
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public IEnumerable<KhuyenMai> LayDanhSachKhuyenMai()
        {
            IEnumerable<KhuyenMai> res = from km in db.KHUYENMAIs
                                         select new KhuyenMai
                                         {
                                             MaKM = km.MaKhuyenMai,
                                             TenKM = km.TenKhuyenMai,
                                             NgayBatDau = km.NgayBatDauKM.Value,
                                             NgayKetThuc = km.NgayKetThucKM.Value
                                         };
            return res;
        }
    }
}
