using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class NhapSachService : INhapSachService
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public IEnumerable<ChiTietPhieuNhap> LayDanhSachChiTiet(string mapn)
        {
            IEnumerable<ChiTietPhieuNhap> res = (from ct in db.CHITIETPHIEUNHAPs
                                                 where ct.MaPhieuNhap == mapn
                                                 join s in db.SACHes on ct.MaSach equals s.MaSach
                                                 select new ChiTietPhieuNhap
                                                 {
                                                     MaPN = ct.MaPhieuNhap,
                                                     MaSach = ct.MaSach,
                                                     SoLuong = ct.SoLuong.Value,
                                                     TenSach =s.TenSach
                                                 });
            return res;
        }

        public IEnumerable<NhanVien> LayDanhSachNhanVien()
        {
            INhanVienService service = new NhanVienService();
            return service.LayDanhSachNhanVien();
        }

        public IEnumerable<NhaXuatBan> LayDanhSachNXB()
        {
            INhaXuatBanService service = new NhaXuatBanService();
            return service.LayDanhSachNXB();
        }

        public IEnumerable<PhieuNhap> LayDanhSachPhieuNhap()
        {
            IEnumerable<PhieuNhap> res = (from pn in db.PHIEUNHAPs
                                          join nv in db.NHANVIENs on pn.MaNV equals nv.MaNV
                                          join nxb in db.NHAXUATBANs on pn.MaNXB equals nxb.MaNXB
                                          select new PhieuNhap
                                          {
                                              MaPN = pn.MaPhieuNhap,
                                              NgayNhap = pn.NgayLap.Value,
                                              MaNV = pn.MaNV.Value,
                                              MaNXB = pn.MaNXB.Value,
                                              TenNV = nv.TenNV,
                                              TenNXB = nxb.TenNXB,
                                              TongTien = pn.TongTien.Value
                                          });
            return res;
        }

        public IEnumerable<Sach> LayDanhSachSach()
        {
            ISachService service = new SachService();
            return service.LayDanhSachSach();
        }
    }
}
