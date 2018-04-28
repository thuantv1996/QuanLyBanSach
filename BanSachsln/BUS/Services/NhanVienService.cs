using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class NhanVienService : INhanVienService
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public IEnumerable<LoaiNhanVien> LayDanhSachLoaiNhanVien()
        {
            IEnumerable<LoaiNhanVien> res = from lnv in db.LOAINHANVIENs
                                            select new LoaiNhanVien { MaLoai = lnv.MaLoaiNV, TenLoai = lnv.TenLoaiNV };
            return res;
        }

        public IEnumerable<NhanVien> LayDanhSachNhanVien()
        {
            IEnumerable<NhanVien> res = from nv in db.NHANVIENs
                                        join lnv in db.LOAINHANVIENs on nv.MaLoaiNV equals lnv.MaLoaiNV
                                        select new NhanVien
                                        {
                                            MaNV = nv.MaNV,
                                            TenNV = nv.TenNV,
                                            MaLoaiNV = nv.MaLoaiNV.Value,
                                            DiaChi = nv.DiaChi,
                                            NgaySinh = nv.NgaySinh.Value,
                                            SDT = nv.SoDienThoaiNV,
                                            CMND = nv.CMND,
                                            TenLoaiNV = lnv.TenLoaiNV
                                        };
            return res;
        }

        public NhanVien LayThongTinNhanVien(string id)
        {
            throw new NotImplementedException();
        }
    }
}
