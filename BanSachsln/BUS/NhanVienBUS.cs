using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class NhanVienBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static String Message="";
        public static bool isSucess = false;
        private static NHANVIEN ChuyenDoi(NhanVien nhanvien)
        {
            return new NHANVIEN
            {
                MaNV = nhanvien.MaNV,
                TenNV = nhanvien.TenNV,
                DiaChi = nhanvien.DiaChi,
                SoDienThoaiNV = nhanvien.SDT,
                CMND = nhanvien.CMND,
                MaLoaiNV = nhanvien.MaLoaiNV,
                NgaySinh = nhanvien.NgaySinh
            };
        }
        public static bool ThemNhanVien(NhanVien nhanvien)
        {
            isSucess = false;
            NHANVIEN obj = ChuyenDoi(nhanvien);
            /// Bước 1: Kiểm tra thông tin
             // kiểm tra loại nhân viên
            if (db.LOAINHANVIENs.Find(obj.MaLoaiNV) == null)
            {
                Message = "Loại nhân viên không hợp lệ";
                return false;
            }
            // tuổi nhân viên >18
            if (DateTime.Now.Year - obj.NgaySinh.Value.Year<Regulations.TuoiToiThieu)
            {
                Message = "Tuổi nhỏ hơn "+ Regulations.TuoiToiThieu;
                return false;
            }
            // Kiểm tra chứng minh nhân dân
            if (obj.CMND.Length < 9|| obj.CMND.Length>12)
            {
                Message = "CMND không hợp lệ";
                return false;
            }
            /// Bước 2: Thêm vào
            try
            {
                db.NHANVIENs.Add(obj);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Message = e.ToString();
                return false;
            }
            Message="Thêm thành công!";
            isSucess = true;
            return true;
        }
        public static bool XoaNhanVien(NhanVien nhanvien)
        {
            isSucess = false;
            NHANVIEN obj = ChuyenDoi(nhanvien);
            /// Bước 1: Kiểm tra mã nhân viên
            if (db.NHANVIENs.Find(obj.MaNV) == null)
            {
                Message = "Nhân viên không hợp lệ";
                return false;
            }
            /// Bước 2: Xóa
            try
            {
                db.NHANVIENs.Remove(db.NHANVIENs.Find(obj.MaNV));
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Message = e.Message.ToString();
                return false;
            }
            Message = "Xóa thành công!";
            isSucess = true;
            return true;
        }
        public static bool SuaNhanVien(NhanVien nhanvien)
        {
            isSucess = false;
            NHANVIEN obj = ChuyenDoi(nhanvien);
            /// Bước 1: Kiểm tra thông tin
            // kiểm tra loại nhân viên
            if (db.LOAINHANVIENs.Find(obj.MaLoaiNV) == null)
            {
                Message = "Loại nhân viên không hợp lệ";
                return false;
            }
            // tuổi nhân viên >18
            if (DateTime.Now.Year - obj.NgaySinh.Value.Year < Regulations.TuoiToiThieu)
            {
                Message = "Tuổi nhỏ hơn "+ Regulations.TuoiToiThieu;
                return false;
            }
            // Kiểm tra chứng minh nhân dân
            if (obj.CMND.Length < 9 || obj.CMND.Length > 12)
            {
                Message = "CMND không hợp lệ";
                return false;
            }
            /// Bước 2: Sửa vào
            try
            {
                NHANVIEN nv = db.NHANVIENs.Find(obj.MaNV);
                nv.TenNV = obj.TenNV;
                nv.NgaySinh = obj.NgaySinh;
                nv.DiaChi = obj.DiaChi;
                nv.SoDienThoaiNV = obj.SoDienThoaiNV;
                nv.MaLoaiNV = obj.MaLoaiNV;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = e.ToString();
                return false;
            }
            Message = "Sửa thành công!";
            isSucess = true;
            return true;
        }
    }
}
