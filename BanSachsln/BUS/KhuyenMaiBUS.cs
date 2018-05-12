using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KhuyenMaiBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static string Message = "";
        public static bool IsSuccess = false;

        private static KHUYENMAI Convert(KhuyenMai khuyenmai)
        {
            return new KHUYENMAI
            {
                MaKhuyenMai = khuyenmai.MaKM,
                TenKhuyenMai = khuyenmai.TenKM,
                NgayBatDauKM = khuyenmai.NgayBatDau,
                NgayKetThucKM = khuyenmai.NgayKetThuc
            };
        }

        public static void ThemKhuyenMai(KhuyenMai khuyenmai)
        {
            IsSuccess = false;
            // kiểm tra kiểu dữ liệu
            if (khuyenmai.MaKM.Length > 10)
            {
                Message = "Mã khuyến mãi tối đa 10 ký tự";
                return;
            }
            if (khuyenmai.TenKM.Length > 200)
            {
                Message = "Tên khuyến mãi tối đa 200 ký tự";
                return;
            }
            // kiểm tra ràng buộc
            if (db.KHUYENMAIs.Find(khuyenmai.MaKM) != null)
            {
                Message = "Mã khuyến mãi đã tồn tại!";
                return;
            }
            if (DateTime.Compare(khuyenmai.NgayBatDau, khuyenmai.NgayKetThuc) > 0)
            {
                Message = "Ngày kết thúc không thể xảy ra trước khi bắt đầu khuyến mãi!";
                return;
            }
            // thêm
            try
            {
                KHUYENMAI km = Convert(khuyenmai);
                db.KHUYENMAIs.Add(km);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Thêm khuyến mãi không thành công!\n" + e.Message;
                return;
            }
            Message = "Thêm khuyến mãi thành công!";
            IsSuccess = true;
            return;
        }
        public static void SuaKhuyenMai(KhuyenMai khuyenmai)
        {
            IsSuccess = false;
            // kiểm tra kiểu dữ liệu
            if (khuyenmai.MaKM.Length > 10)
            {
                Message = "Mã khuyến mãi tối đa 10 ký tự";
                return;
            }
            if (khuyenmai.TenKM.Length > 200)
            {
                Message = "Tên khuyến mãi tối đa 200 ký tự";
                return;
            }
            // kiểm tra ràng buộc
            if (db.KHUYENMAIs.Find(khuyenmai.MaKM) == null)
            {
                Message = "Mã khuyến mãi không tồn tại!";
                return;
            }
            if (DateTime.Compare(khuyenmai.NgayBatDau, khuyenmai.NgayKetThuc) > 0)
            {
                Message = "Ngày kết thúc không thể xảy ra trước khi bắt đầu khuyến mãi!";
                return;
            }
            // sửa
            try
            {
                KHUYENMAI km = db.KHUYENMAIs.Find(khuyenmai.MaKM);
                km.TenKhuyenMai = khuyenmai.TenKM;
                km.NgayBatDauKM = khuyenmai.NgayBatDau;
                km.NgayKetThucKM = khuyenmai.NgayKetThuc;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Sửa khuyến mãi không thành công!\n" + e.Message;
                return;
            }
            Message = "Sửa khuyến mãi thành công!";
            IsSuccess = true;
            return;
        }

        public static void XoaKhuyenMai(KhuyenMai khuyenmai)
        {
            // kiểm tra ràng buộc
            if (db.KHUYENMAIs.Find(khuyenmai.MaKM) == null)
            {
                Message = "Mã khuyến mãi không tồn tại!";
                return;
            }
            // xóa tất cả các chi tiết liên quan
            IEnumerable<CHITIETKHUYENMAI> dsct = from ct in db.CHITIETKHUYENMAIs
                                                 where ct.MaKhuyenMai == khuyenmai.MaKM
                                                 select ct;
            try
            {
                if (dsct != null)
                {
                    foreach (CHITIETKHUYENMAI ct in dsct)
                    {
                        db.CHITIETKHUYENMAIs.Remove(ct);
                    }
                }
            }catch(Exception e)
            {
                Message = "Xóa khuyến mãi không thành công!\n"+e.Message;
                return;
            }
            // xóa khuyến mãi
            try
            {
                db.KHUYENMAIs.Remove(db.KHUYENMAIs.Find(khuyenmai.MaKM));
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Xóa khuyến mãi không thành công!\n" + e.Message;
                return;
            }
            Message = "Xóa khuyến mãi thành công!";
            IsSuccess = true;
            return;
        }

    }
}
