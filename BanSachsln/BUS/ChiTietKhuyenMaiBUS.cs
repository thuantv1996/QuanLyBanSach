using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChiTietKhuyenMaiBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static string Message = "";
        public static bool IsSuccess = false;

        private static CHITIETKHUYENMAI Convert(ChiTietKhuyenMai chitiet)
        {
            return new CHITIETKHUYENMAI
            {
                MaKhuyenMai = chitiet.MaKM,
                MaTheLoai = chitiet.MaTheLoai,
                NoiDung = chitiet.NoiDung
            };
        }

        public static void Them(ChiTietKhuyenMai chitiet)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            if(db.KHUYENMAIs.Find(chitiet.MaKM)==null)
            {
                Message = "Không tìm thấy khuyến mãi để thêm chi tiết";
                return;
            }
            if (db.THELOAIs.Find(chitiet.MaTheLoai) == null)
            {
                Message = "Không tìm thấy thể loại để thêm chi tiết";
                return;
            }
            if (chitiet.NoiDung<=0 || chitiet.NoiDung>100)
            {
                Message = "Phần trăm giảm giá là không âm và bé hơn 100%";
                return;
            }
            // Thêm 
            try
            {
                CHITIETKHUYENMAI ct = Convert(chitiet);
                db.CHITIETKHUYENMAIs.Add(ct);
                db.SaveChanges();
            }catch(Exception e)
            {
                Message = "Thêm chi tiết thất bại!\n"+e.Message;
                return;
            }
            Message = "Thêm chi tiết thành công!";
            IsSuccess = true;
            return;
        }
        public static void Sua(ChiTietKhuyenMai chitiet)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            CHITIETKHUYENMAI ct = db.CHITIETKHUYENMAIs.Find(chitiet.MaTheLoai, chitiet.MaKM);
            if (ct == null)
            {
                Message = "Không tìm thấy chi tiết khuyến mãi này";
                return;
            }
            if (chitiet.NoiDung <= 0 || chitiet.NoiDung > 100)
            {
                Message = "Phần trăm giảm giá là không âm và bé hơn 100%";
                return;
            }
            // Sua 
            try
            {
                ct.NoiDung = chitiet.NoiDung;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Sửa chi tiết thất bại!\n" + e.Message;
                return;
            }
            Message = "Sửa chi tiết thành công!";
            IsSuccess = true;
            return;
        }
        public static void Xoa(ChiTietKhuyenMai chitiet)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            CHITIETKHUYENMAI ct = db.CHITIETKHUYENMAIs.Find(chitiet.MaTheLoai, chitiet.MaKM);
            if (ct == null)
            {
                Message = "Không tìm thấy chi tiết khuyến mãi này";
                return;
            }
            try
            {
                db.CHITIETKHUYENMAIs.Remove(ct);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Xóa chi tiết thất bại!\n" + e.Message;
                return;
            }
            Message = "Xóa chi tiết thành công!";
            IsSuccess = true;
            return;
        }
    }
}
