using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class TheLoaiBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static bool IsSuccess = false;
        public static string Message = "";
        private static THELOAI Convert(TheLoai theloai)
        {
            return new THELOAI
            {
                MaTheLoai = theloai.MaTheLoai,
                TenTheLoai = theloai.TenTheLoai
            };
        }
        public static void XoaTheLoai(TheLoai theloai)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            THELOAI tl = db.THELOAIs.Find(theloai.MaTheLoai);
            if (tl == null)
            {
                Message = "Không tìm thấy thể loại!";
                return;
            }
            // xóa 
            try
            {
                db.THELOAIs.Remove(tl);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Xóa thể loại không thành công!\n" + e.Message;
                return;
            }
            Message = "Xóa thể loại thành công!";
            IsSuccess = true;
        }

        public static void SuaTheLoai(TheLoai theloai)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            THELOAI tl = db.THELOAIs.Find(theloai.MaTheLoai);
            if (tl == null)
            {
                Message = "Không tìm thấy thể loại!";
                return;
            }
            // Sửa
            try
            {
                tl.TenTheLoai = theloai.TenTheLoai;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Sửa thể loại không thành công!\n" + e.Message;
                return;
            }
            Message = "Sửa thể loại thành công!";
            IsSuccess = true;
        }

        public static void ThemTheLoai(TheLoai theloai)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu

            // Thêm vào
            try
            {
                db.THELOAIs.Add(Convert(theloai));
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Thêm thể loại không thành công!\n" + e.Message;
                return;
            }
            Message = "Thêm thể loại thành công!";
            IsSuccess = true;

        }
    }
}
