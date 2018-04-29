using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class SachService : ISachService
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public IEnumerable<NhaXuatBan> LayDanhSachNXB()
        {
            INhaXuatBanService service = new NhaXuatBanService();
            return service.LayDanhSachNXB();
        }

        public IEnumerable<Sach> LayDanhSachSach()
        {
            IEnumerable<Sach> res = from s in db.SACHes
                                    join nxb in db.NHAXUATBANs on s.MaNXB equals nxb.MaNXB
                                    join tl in db.THELOAIs on s.MaTheLoai equals tl.MaTheLoai
                                    select new Sach
                                    {
                                        MaSach = s.MaSach,
                                        TenSach = s.TenSach,
                                        MaNXB = s.MaNXB.Value,
                                        MaTheLoai = s.MaTheLoai.Value,
                                        MoTa =s.MoTa,
                                        GiaBanLe = s.GiaBanLe.Value,
                                        GiaBanSi = s.GiaBanSi.Value,
                                        SoLuong = s.SoLuong.Value,
                                        TacGia = s.TacGia,
                                        TenNXB = nxb.TenNXB,
                                        TenTheLoai = tl.TenTheLoai,
                                        GiaNhap = s.GiaNhap.Value
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
