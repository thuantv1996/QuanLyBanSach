using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS.Services
{
    public class NhaXuatBanService : INhaXuatBanService
    {
        public static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public IEnumerable<DTO.NhaXuatBan> LayDanhSachNXB()
        {
            IEnumerable<DTO.NhaXuatBan> nxb = from n in db.NHAXUATBANs
                                              select new DTO.NhaXuatBan { MaNXB = n.MaNXB,
                                                  TenNXB = n.TenNXB,
                                                  DiaChiNXB = n.DiaChiNXB,
                                                  SoDienThoaiNXB = n.SoDienThoaiNXB };
            return nxb;
        }
    }
}
