using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class SachBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static String Message = "";
        public static bool IsSuccess = false;

        private static SACH Convert(Sach sach)
        {
            return new SACH
            {
                MaSach = sach.MaSach,
                TenSach = sach.TenSach,
                MoTa = sach.MoTa,
                GiaBanLe = sach.GiaBanLe,
                GiaBanSi = sach.GiaBanSi,
                TacGia = sach.TacGia,
                MaNXB = sach.MaNXB,
                MaTheLoai = sach.MaTheLoai,
                SoLuong = sach.SoLuong ,
                GiaNhap = sach.GiaNhap
            };
        }

        public static bool ThemSach(Sach sach)
        {
            IsSuccess = false;
            // bước 1:
            // kiểm tra 
            if(db.SACHes.Find(sach.MaSach)!=null)
            {
                Message = "Mã sách này đã có! \nVui lòng chọn mã sách mới!";
                return false;
            }
            if(sach.GiaBanLe<0)
            {
                Message = "Giá bán lẽ phải lớn hơn không!";
                return false;
            }
            if (sach.GiaBanSi < 0)
            {
                Message = "Giá bán sỉ phải lớn hơn không!";
                return false;
            }
            if (sach.GiaBanSi > sach.GiaBanLe)
            {
                Message = "Giá bán sỉ phải nhỏ hơn giá bán lẽ!";
                return false;
            }
            if (db.NHAXUATBANs.Find(sach.MaNXB) == null)
            {
                Message = "Nhà xuất bản không tồn tại!";
                return false;
            }
            if (db.THELOAIs.Find(sach.MaTheLoai) == null)
            {
                Message = "Thể loại không tồn tại!";
                return false;
            }
            // Bước 2: Thêm
            try
            {
                SACH des = Convert(sach);
                des.SoLuong = 0;
                db.SACHes.Add(des);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Thêm sách không thành công!\n"+e.Message;
                return false;
            }
            Message = "Thêm sách thành công!";
            IsSuccess = true;
            return true;
        }

        public static bool SuaSach(Sach sach)
        {
            IsSuccess = false;
            // bước 1:
            // kiểm tra 
            SACH des = db.SACHes.Find(sach.MaSach);
            if ( des == null)
            {
                Message = "Mã sách này chưa có! \nVui lòng chọn sách!";
                return false;
            }
            if (sach.GiaBanLe < 0)
            {
                Message = "Giá bán lẽ phải lớn hơn không!";
                return false;
            }
            if (sach.GiaBanSi < 0)
            {
                Message = "Giá bán sỉ phải lớn hơn không!";
                return false;
            }
            if (sach.GiaBanSi > sach.GiaBanLe)
            {
                Message = "Giá bán sỉ phải nhỏ hơn giá bán lẽ!";
                return false;
            }
            if (db.NHAXUATBANs.Find(sach.MaNXB) == null)
            {
                Message = "Nhà xuất bản không tồn tại!";
                return false;
            }
            if (db.THELOAIs.Find(sach.MaTheLoai) == null)
            {
                Message = "Thể loại không tồn tại!";
                return false;
            }
            // Bước 2: Sửa
            try
            {
                des.TenSach = sach.TenSach;
                des.MaNXB = sach.MaNXB;
                des.MaTheLoai = sach.MaTheLoai;
                des.MoTa = sach.MoTa;
                des.TacGia = sach.TacGia;
                des.GiaBanLe = sach.GiaBanLe;
                des.GiaBanSi = sach.GiaBanSi;
                des.GiaNhap = sach.GiaNhap;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Sửa thông tin sách không thành công!\n" + e.Message;
                return false;
            }
            Message = "Sửa thông tin sách thành công!";
            IsSuccess = true;
            return true;
        }

        public static bool XoaSach(Sach sach)
        {
            IsSuccess = false;
            // bước 1:
            // kiểm tra 
            SACH des = db.SACHes.Find(sach.MaSach);
            if (des == null)
            {
                Message = "Mã sách này chưa có! \nVui lòng chọn sách!";
                return false;
            }     
            // Bước 2: Sửa
            try
            {
                db.SACHes.Remove(des);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Xóa sách không thành công!\n" + e.Message;
                return false;
            }
            Message = "Xóa sách thành công!";
            IsSuccess = true;
            return true;
        }
    }
}
