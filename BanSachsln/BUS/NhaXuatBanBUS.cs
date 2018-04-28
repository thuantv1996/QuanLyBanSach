using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NhaXuatBanBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static bool IsSuccess = false;
        public static string Message = "";
        private static NHAXUATBAN Convert(NhaXuatBan nhaxuatban)
        {
            return new NHAXUATBAN
            {
                MaNXB = nhaxuatban.MaNXB,
                TenNXB = nhaxuatban.TenNXB,
                SoDienThoaiNXB = nhaxuatban.SoDienThoaiNXB,
                DiaChiNXB = nhaxuatban.DiaChiNXB
            };
        }
        public static void XoaNhaXuatBan(NhaXuatBan nhaxuatban)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            NHAXUATBAN nxb = db.NHAXUATBANs.Find(nhaxuatban.MaNXB);
            if (nxb == null)
            {
                Message = "Không tìm thấy nhà xuất bản!";
                return;
            }
            // xóa 
            try
            {
                db.NHAXUATBANs.Remove(nxb);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Xóa nhà xuất bản không thành công!\n" + e.Message;
                return;
            }
            Message = "Xóa nhà xuất bản thành công!";
            IsSuccess = true;
        }

        public static void SuaNhaXuatBan(NhaXuatBan nhaxuatban)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu
            NHAXUATBAN nxb = db.NHAXUATBANs.Find(nhaxuatban.MaNXB);
            if(nxb == null)
            {
                Message = "Không tìm thấy nhà xuất bản!";
                return;
            }
            // Sửa
            try
            {
                nxb.TenNXB = nhaxuatban.TenNXB;
                nxb.DiaChiNXB = nhaxuatban.DiaChiNXB;
                nxb.SoDienThoaiNXB = nhaxuatban.SoDienThoaiNXB;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Sửa nhà xuất bản không thành công!\n" + e.Message;
                return;
            }
            Message = "Sửa nhà xuất bản thành công!";
            IsSuccess = true;
        }

        public static void ThemNhaXuatBan(NhaXuatBan nhaxuatban)
        {
            IsSuccess = false;
            // kiểm tra dữ liệu

            // Thêm vào
            try
            {
                db.NHAXUATBANs.Add(Convert(nhaxuatban));
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Message = "Thêm nhà xuất bản không thành công!\n" + e.Message;
                return;
            }
            Message = "Thêm nhà xuất bản thành công!";
            IsSuccess = true;
            
        }
    }
}
