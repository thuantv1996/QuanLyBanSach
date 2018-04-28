using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class TheLoaiService : ITheLoaiService
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public IEnumerable<TheLoai> LayDanhSachTheLoai()
        {
            IEnumerable<TheLoai> res = from tl in db.THELOAIs
                                       select new TheLoai { MaTheLoai = tl.MaTheLoai, TenTheLoai = tl.TenTheLoai };
            return res;
        }
    }
}
