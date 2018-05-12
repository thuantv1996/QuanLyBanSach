using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static String Message = "";
        public static bool isSucess = false;
        private static TAIKHOAN ChuyenDoi(TaiKhoan taikhoan)
        {
            return new TAIKHOAN
            {
                MaTaiKhoan = taikhoan.MaTaiKhoan,
                MaNV = taikhoan.MaNhanVien,
                MatKhau = taikhoan.MatKhau,
                TenDangNhap = taikhoan.TenDangNhap
            };
        }
        private static String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
        public static bool ThemTaiKhoan(TaiKhoan taikhoan)
        {
            isSucess = false;
            TAIKHOAN obj = ChuyenDoi(taikhoan);
            /// Bước 1: Kiểm tra thông tin
            // kiểm tra mã số nhân viên
            if (db.NHANVIENs.Find(obj.MaNV) == null)
            {
                Message = "Nhân viên không hợp lệ";
                return false;
            }
            // kiểm tra tài khoản
            TAIKHOAN tk = (from t in db.TAIKHOANs
                           where t.TenDangNhap == obj.TenDangNhap.ToLower()
                           select t).SingleOrDefault();
            if (tk != null)
            {
                Message = "Tên đăng nhập đã tồn tại";
                return false;
            }
            // chuyển tên đăng nhập về chuỗi thường
            obj.TenDangNhap = obj.TenDangNhap.ToLower();
            // Mã hóa mật khẩu
            obj.MatKhau = GetMD5(obj.MatKhau);
            /// Bước 2 Thêm tài khoản
            try
            {
                db.TAIKHOANs.Add(obj);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = e.Message;
                return false;
            }

            Message = "Thêm thành công!";
            isSucess = true;
            return true;
        }
        public static bool XoaTaiKhoan(TaiKhoan taikhoan)
        {
            isSucess = false;
            TAIKHOAN obj = ChuyenDoi(taikhoan);
            /// Bước 1: Kiểm tra thông tin
            // kiểm tra mã số tài khoản
            if (db.TAIKHOANs.Find(obj.MaTaiKhoan) == null)
            {
                Message = "Tài khoản không hợp lệ";
                return false;
            }
            /// Bước 2 Xóa tài khoản
            try
            {
                db.TAIKHOANs.Remove(db.TAIKHOANs.Find(obj.MaTaiKhoan));
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = e.Message;
                return false;
            }
            Message = "Xóa thành công!";
            isSucess = true;
            return true;
        }
        public static bool ResetTaiKhoan(TaiKhoan taikhoan)
        {
            isSucess = false;
            TAIKHOAN obj = ChuyenDoi(taikhoan);
            /// Bước 1: Kiểm tra thông tin
            // kiểm tra mã số nhân viên
            if (db.NHANVIENs.Find(obj.MaNV) == null)
            {
                Message = "Nhân viên không hợp lệ";
                return false;
            }
            // kiểm tra tài khoản
            if (db.TAIKHOANs.Where(tk => tk.TenDangNhap == obj.TenDangNhap.ToLower()).ToList().Count > 1)
            {
                Message = "Tên đăng nhập đã tồn tại";
                return false;
            }
            // chuyển tên đăng nhập về chuỗi thường
            obj.TenDangNhap = obj.TenDangNhap.ToLower();
            // Mã hóa mật khẩu
            obj.MatKhau = Regulations.MatKhau;
            obj.MatKhau = GetMD5(obj.MatKhau);
            /// Bước 2 Thêm tài khoản
            try
            {
                TAIKHOAN tk = db.TAIKHOANs.Find(taikhoan.MaTaiKhoan);
                tk.MatKhau = obj.MatKhau;
                tk.TenDangNhap = obj.TenDangNhap;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = e.Message;
                return false;
            }
            Message = "Reset thành công!";
            isSucess = true;
            return true;
        }
        public static bool DoiMatKhau(TaiKhoan taikhoan, String matkhaucu)
        {
            isSucess = false;
            TAIKHOAN obj = ChuyenDoi(taikhoan);
            /// Bước 1: Kiểm tra thông tin
            // kiểm tra tài khoản
            TAIKHOAN tk = db.TAIKHOANs.Find(obj.MaTaiKhoan);
            if (tk == null)
            {
                Message = "tài khoản không tồn tại";
                return false;
            }
            // Kiểm tra mật khẩu cũ
            if (tk.MatKhau != GetMD5(matkhaucu))
            {
                Message = "Mật khẩu cũ không đúng";
                return false;
            }
            // chuyển tên đăng nhập về chuỗi thường
            obj.TenDangNhap = obj.TenDangNhap.ToLower();
            // Mã hóa mật khẩu
            obj.MatKhau = GetMD5(obj.MatKhau);
            /// Bước 2 Thêm tài khoản
            try
            {
                tk = db.TAIKHOANs.Find(taikhoan.MaTaiKhoan);
                tk = obj;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = e.Message;
                return false;
            }
            Message = "Reset thành công!";
            isSucess = true;
            return true;
        }
        public static bool DangNhapHeThong(TaiKhoan taikhoan)
        {
            TAIKHOAN tk = (from t in db.TAIKHOANs
                           where t.TenDangNhap == taikhoan.TenDangNhap.ToLower()
                           select t).SingleOrDefault();
            if (tk == null)
            {
                return false;
            }
            if(tk.MatKhau != GetMD5(taikhoan.MatKhau))
            {
                return false;
            }
            Common.isDangNhap = true;
            Common.taikhoan = tk;
            // check in
            DiemDanh(tk);
            return true;
        }
        private static void DiemDanh(TAIKHOAN taikhoan)
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            // kiểm tra có bảng điểm danh của ngày hay chưa
            DIEMDANH dd = (from d in db.DIEMDANHs
                           where (d.NgayDiemDanh.Value.Year == year && d.NgayDiemDanh.Value.Month == month && d.NgayDiemDanh.Value.Day == day)
                           select d).SingleOrDefault();
            if(dd == null)
            {
                dd = new DIEMDANH { NgayDiemDanh = DateTime.Now };
                db.DIEMDANHs.Add(dd);
                db.SaveChanges();
            }
            // lấy lại bảng điểm danh của ngày
            dd = (from d in db.DIEMDANHs
                           where (d.NgayDiemDanh.Value.Year == year && d.NgayDiemDanh.Value.Month == month && d.NgayDiemDanh.Value.Day == day)
                           select d).SingleOrDefault();
            // lưu check in

            // kiểm tra xem trước đó có login chưa

            CHITIETDIEMDANH ctdd = (from ct in db.CHITIETDIEMDANHs
                                    where ct.MaTaiKhoan == taikhoan.MaTaiKhoan && dd.MaDiemDanh == ct.MaDiemDanh
                                    select ct).SingleOrDefault();
            if(ctdd==null)
            {
                ctdd = new CHITIETDIEMDANH
                {
                    GioBatDau = DateTime.Now.Hour,
                    MaDiemDanh = dd.MaDiemDanh,
                    MaTaiKhoan = Common.taikhoan.MaTaiKhoan
                };
                Common.ct_DiemDanh = ctdd;
                Common.diemDanh = dd;
                db.CHITIETDIEMDANHs.Add(ctdd);
                db.SaveChanges();
            }
            else
            {
                Common.ct_DiemDanh = ctdd;
                Common.diemDanh = dd;
            }
            // Lấy thông tin nhân viên
            NHANVIEN nv = (from n in db.NHANVIENs
                           join tk in db.TAIKHOANs on n.MaNV equals tk.MaNV
                           where tk.MaTaiKhoan == Common.taikhoan.MaTaiKhoan
                           select n).SingleOrDefault();
            if(nv.MaLoaiNV.Value==1)
            {
                Common.QuyenTryCap = QUYEN.QL;
            }
            else
            {
                if(nv.MaLoaiNV.Value == 2)
                {
                    Common.QuyenTryCap = QUYEN.NV_BH;
                }
                else
                {
                    Common.QuyenTryCap = QUYEN.NV_K;
                }
            }
        }
    }
}
