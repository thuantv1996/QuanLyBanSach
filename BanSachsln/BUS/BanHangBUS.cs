using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BanHangBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static string Message = "";
        public static bool IsSuccess = false;

        private static CHITIETHOADON Convert(ChiTietHoaDon chitiet)
        {
            return new CHITIETHOADON
            {
                MaHoaDon = chitiet.MaHD,
                MaSach = chitiet.MaSach,
                SoLuong = chitiet.SoLuong
            };
        }
        private static HOADON Convert(HoaDon hoadon)
        {
            return new HOADON
            {
                MaHoaDon = hoadon.MaHD,
                MaKH = hoadon.MaKH,
                MaNV = hoadon.MaNV
            };
        }
        public static double TinhDonGia(int maKH, ChiTietHoaDon chitiet)
        {
            if (db.KHACHHANGs.Find(maKH).MaLoaiKH == "LKH002")
            {
                if (chitiet.SoLuong >= Regulations.SoLuongBanSi)
                {
                    chitiet.DonGia = db.SACHes.Find(chitiet.MaSach).GiaBanSi.Value;
                }
            }
            else
            {
                chitiet.DonGia = db.SACHes.Find(chitiet.MaSach).GiaBanLe.Value;
            }
            // tính khuyến mãi
            SACH sach = db.SACHes.Find(chitiet.MaSach);
            CHITIETKHUYENMAI km = (from ct in db.CHITIETKHUYENMAIs
                                   join k in db.KHUYENMAIs on ct.MaKhuyenMai equals k.MaKhuyenMai
                                   where DateTime.Compare(k.NgayBatDauKM.Value, DateTime.Now) <= 0 && DateTime.Compare(k.NgayKetThucKM.Value, DateTime.Now) >= 0 && ct.MaTheLoai == sach.MaTheLoai
                                   orderby ct.NoiDung descending
                                   select ct).SingleOrDefault();
            if (km == null)
            {
                return chitiet.DonGia;
            }
            else
            {
                return chitiet.DonGia * (1 - (double)km.NoiDung.Value / 100);
            }
        }
        public static void ThemHoaDon(HoaDon hoadon, List<ChiTietHoaDon> dsct)
        {
            IsSuccess = false;
            // kiểm tra lại hóa đơn
            if (hoadon.MaHD.Length > 15)
            {
                Message = "Mã hóa đơn tối đa 15 ký tự";
                return;
            }
            if (db.HOADONs.Find(hoadon.MaHD) != null)
            {
                Message = "Mã hóa đơn đã tồn tại";
                return;
            }
            if (db.NHANVIENs.Find(hoadon.MaNV) == null)
            {
                Message = "Nhân viên không tồn tại";
                return;
            }
            if (db.KHACHHANGs.Find(hoadon.MaKH) == null)
            {
                Message = "Khách hàng không tồn tại";
                return;
            }
            // Kiểm tra chi tiết
            if (dsct.Count == 0)
            {
                Message = "Không có chi tiết nào trong hóa đơn";
                return;
            }
            foreach (ChiTietHoaDon ct in dsct)
            {
                ct.MaHD = hoadon.MaHD;
                if (db.SACHes.Find(ct.MaSach) == null)
                {
                    Message = "Sách " + ct.TenSach + " không tồn tại";
                    return;
                }
                if (ct.SoLuong <= 0)
                {
                    Message = "Số lượng cần mua phải là số nguyên lớn hơn 0!";
                    return;
                }
                if (ct.SoLuong > db.SACHes.Find(ct.MaSach).SoLuong)
                {
                    Message = "Số lượng cần mua lớn hơn tồn trong kho!";
                    return;
                }
                // tính lại đơn giá đã qua khuyến mãi
                ct.DonGia = TinhDonGia(hoadon.MaKH, ct);
            }

            // Thêm hóa đơn
            try
            {
                HOADON hd = Convert(hoadon);
                hd.NgayHoaDon = DateTime.Now;
                hd.TongTien = dsct.Sum(ct => ct.ThanhTien);
                // nếu là khách thành viên thì không cho nợ quá 10 triệu.
                KHACHHANG kh = db.KHACHHANGs.Find(hoadon.MaKH);
                if (kh.MaLoaiKH == "LKH002" && kh.TienNo > Regulations.NoToiDa)
                {
                    Message = "Tiền nợ hiện tại vượt mức cho phép!";
                    return;
                }
                db.HOADONs.Add(hd);
                foreach (ChiTietHoaDon ct in dsct)
                {
                    db.CHITIETHOADONs.Add(Convert(ct));
                    db.SACHes.Find(ct.MaSach).SoLuong -= ct.SoLuong;
                }
                kh.TienNo += hd.TongTien;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = "Thêm hóa đơn thất bại!\n" + e.Message;
                return;
            }
            Message = "Thêm hóa đơn thành công!\n";
            IsSuccess = true;
            return;
        }
    }
}
