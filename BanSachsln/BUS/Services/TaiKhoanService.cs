using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS.Services
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();     
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
        public IEnumerable<TaiKhoan> LayDanhSachTaiKhoan()
        {
            IEnumerable<TaiKhoan> res = from tk in db.TAIKHOANs
                                        join nv in db.NHANVIENs on tk.MaNV equals nv.MaNV
                                        select new TaiKhoan
                                        {
                                            MaTaiKhoan = tk.MaTaiKhoan,
                                            TenDangNhap = tk.TenDangNhap,
                                            MatKhau = tk.MatKhau,
                                            MaNhanVien = tk.MaNV.Value,
                                            TenNhanVien = nv.TenNV
                                        };
            return res;
        }
    }
}
