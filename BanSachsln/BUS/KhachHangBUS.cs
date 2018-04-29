using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KhachHangBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static bool IsSuccess = false;
        public static string Message = "";

        // convert
        private static KHACHHANG Convert(KhachHang khachhang)
        {
            return new KHACHHANG
            {
                MaKH = khachhang.MaKH,
                DiaChi = khachhang.DiaChi,
                MaLoaiKH = khachhang.MaLKH,
                SoDienThoaiKH = khachhang.SDT,
                TenKH = khachhang.TenKH,
                TienNo = khachhang.TienNo
            };
        }

        public static void ThemKhachHang(KhachHang khachhang)
        {
            // kiểm tra
            if(db.LOAIKHACHHANGs.Find(khachhang.MaLKH)==null)
            {
                Message = "Loại khách hàng không tồn tại!";
                IsSuccess = false;
                return;
            }
            //thêm
            try
            {
                KHACHHANG hk = Convert(khachhang);
                db.KHACHHANGs.Add(hk);
                db.SaveChanges();
            }catch(Exception e)
            {
                Message = "Thêm khách hàng không thành công!\n"+e.Message;
                IsSuccess = false;
                return;
            }
            Message = "Thêm khách hàng thành công!";
            IsSuccess = true;
            return;
        }

        public static void SuaKhachHang(KhachHang khachhang)
        {
            KHACHHANG kh = db.KHACHHANGs.Find(khachhang.MaKH);
            // kiểm tra
            if(kh==null)
            {
                Message = "Khách hàng không tồn tại!";
                IsSuccess = false;
                return;
            }
            if (db.LOAIKHACHHANGs.Find(khachhang.MaLKH) == null)
            {
                Message = "Loại khách hàng không tồn tại!";
                IsSuccess = false;
                return;
            }
            // Sửa
            try
            {

                kh.TenKH = khachhang.TenKH;
                kh.DiaChi = khachhang.DiaChi;
                kh.SoDienThoaiKH = khachhang.SDT;
                kh.MaLoaiKH = khachhang.MaLKH;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Sửa khách hàng không thành công!\n" + e.Message;
                IsSuccess = false;
                return;
            }
            Message = "Sửa khách hàng thành công!";
            IsSuccess = true;
            return;
        }

        public static void XoaKhachHang(KhachHang khachhang)
        {
            KHACHHANG kh = db.KHACHHANGs.Find(khachhang.MaKH);
            // kiểm tra
            if (kh == null)
            {
                Message = "Khách hàng không tồn tại!";
                IsSuccess = false;
                return;
            }
            // xóa
            try
            {

                db.KHACHHANGs.Remove(kh);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Xóa khách hàng không thành công!\n" + e.Message;
                IsSuccess = false;
                return;
            }
            Message = "Xóa khách hàng thành công!";
            IsSuccess = true;
            return;
        }


    }
}
