using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ThanhToanBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static string Message = "";
        public static bool IsSuccess = false;

        private static THANHTOAN Convert(ThanhToan thanhtoan)
        {
            return new THANHTOAN
            {
                MaThanhToan = thanhtoan.MaTT,
                MaKhachHang = thanhtoan.MaKH,
                NgayThanhToan = thanhtoan.NgayTT,
                SoTien = thanhtoan.SoTien
            };
        }

        public static void Them(ThanhToan thanhtoan)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            if (db.THANHTOANs.Find(thanhtoan.MaTT) != null)
            {
                Message = "Mã thanh toán đã tồn tại";
                return;
            }
            if (db.KHACHHANGs.Find(thanhtoan.MaKH) == null)
            {
                Message = "Không tìm thấy khách hàng này";
                return;
            }
            if (thanhtoan.SoTien <= 0)
            {
                Message = "Số tiền thanh toán phải lớn hơn 0!";
                return;
            }
            if (thanhtoan.SoTien > db.KHACHHANGs.Find(thanhtoan.MaKH).TienNo)
            {
                Message = "Số tiền thanh toán lớn hơn nợ hiện tại của khách hàng!";
                return;
            }
            thanhtoan.NgayTT = DateTime.Now;
            // Thêm 
            try
            {
                THANHTOAN tt = Convert(thanhtoan);
                db.THANHTOANs.Add(tt);
                KHACHHANG kh = db.KHACHHANGs.Find(thanhtoan.MaKH);
                kh.TienNo -= thanhtoan.SoTien;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Thêm thanh toán thất bại!\n" + e.Message;
                return;
            }
            Message = "Thêm thanh toán thành công!";
            IsSuccess = true;
            return;
        }
        public static void Sua(ThanhToan thanhtoan)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            if (db.THANHTOANs.Find(thanhtoan.MaTT) == null)
            {
                Message = "Mã thanh toán không tồn tại";
                return;
            }
            if (db.KHACHHANGs.Find(thanhtoan.MaKH) == null)
            {
                Message = "Không tìm thấy khách hàng này";
                return;
            }
            if(thanhtoan.SoTien <= 0)
            {
                Message = "Số tiền thanh toán phải lớn hơn 0!";
                return;
            }
            if (thanhtoan.SoTien > db.KHACHHANGs.Find(thanhtoan.MaKH).TienNo)
            {
                Message = "Số tiền thanh toán lớn hơn nợ hiện tại của khách hàng!";
                return;
            }
            // sửa 
            try
            {
                THANHTOAN tt = db.THANHTOANs.Find(thanhtoan.MaTT);
                db.KHACHHANGs.Find(tt.MaKhachHang).TienNo += tt.SoTien;
                tt.MaKhachHang = thanhtoan.MaKH;
                tt.SoTien = thanhtoan.SoTien;
                db.KHACHHANGs.Find(tt.MaKhachHang).TienNo -= tt.SoTien;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Sửa thanh toán thất bại!\n" + e.Message;
                return;
            }
            Message = "Sửa thanh toán thành công!";
            IsSuccess = true;
            return;
        }
        public static void Xoa(ThanhToan thanhtoan)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            THANHTOAN tt = db.THANHTOANs.Find(thanhtoan.MaTT);
            if (tt == null)
            {
                Message = "Không tìm thấy thanh toán này";
                return;
            }
            try
            {
                db.KHACHHANGs.Find(tt.MaKhachHang).TienNo += tt.SoTien;
                db.THANHTOANs.Remove(tt);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Xóa thanh toán thất bại!\n" + e.Message;
                return;
            }
            Message = "Xóa thanh toán thành công!";
            IsSuccess = true;
            return;
        }
    }
}
