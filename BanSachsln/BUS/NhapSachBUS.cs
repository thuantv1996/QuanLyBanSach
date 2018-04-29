using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class NhapSachBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static String Message = "";
        public static bool IsSucess = false;

        // convert
        private static PHIEUNHAP convert(PhieuNhap pn)
        {
            return new PHIEUNHAP
            {
                MaPhieuNhap = pn.MaPN,
                MaNV = pn.MaNV,
                MaNXB = pn.MaNXB,
                NgayLap = pn.NgayNhap,
                TongTien = pn.TongTien
            };
        }

        private static CHITIETPHIEUNHAP convert(ChiTietPhieuNhap ct)
        {
            return new CHITIETPHIEUNHAP
            {
                MaPhieuNhap = ct.MaPN,
                MaSach = ct.MaSach,
                SoLuong = ct.SoLuong
            };
        }
        //Them 
        public static void Them(PhieuNhap pn, IEnumerable<ChiTietPhieuNhap> dsct)
        {
            // Kiểm tra phieu nhap
            if (db.PHIEUNHAPs.Find(pn.MaPN) != null)
            {
                Message = "Phiếu nhập đã tồn tại";
                IsSucess = false;
                return;
            }
            NHAXUATBAN nxb = db.NHAXUATBANs.Find(pn.MaNXB);
            if (db.NHAXUATBANs.Find(pn.MaNXB) == null)
            {
                Message = "Nhà xuất bản không tồn tại";
                IsSucess = false;
                return;
            }
            if (db.NHANVIENs.Find(pn.MaNV) == null)
            {
                Message = "Nhân viên không tồn tại";
                IsSucess = false;
                return;
            }
            // kiểm tra từng chi tiết
            foreach (ChiTietPhieuNhap ct in dsct)
            {
                SACH s = db.SACHes.Find(ct.MaSach);
                if (s == null)
                {
                    Message = "Sách " + ct.TenSach + " không tồn tại";
                    IsSucess = false;
                    return;
                }
                if (s.MaNXB != nxb.MaNXB)
                {
                    Message = "Sách " + ct.TenSach + " không thuộc nhà xuất bản " + nxb.TenNXB;
                    IsSucess = false;
                    return;
                }
            }
            // tính tổng tiền
            double tongtien = 0;
            foreach (ChiTietPhieuNhap ct in dsct)
            {
                double gianhap = (from s in db.SACHes
                                  where s.MaSach == ct.MaSach
                                  select s.GiaNhap.Value).SingleOrDefault();
                tongtien += ct.SoLuong * gianhap;
            }
            pn.TongTien = tongtien;
            // thêm phiếu nhập
            try
            {
                PHIEUNHAP phieunhap = convert(pn);
                db.PHIEUNHAPs.Add(phieunhap);
            }catch(Exception e)
            {
                Message = "Thêm phiếu nhập thất bại " + e.Message;
                IsSucess = false;
                return;
            }
            // Thêm chi tiết phiếu
            foreach (ChiTietPhieuNhap ct in dsct)
            {
                try
                {
                    CHITIETPHIEUNHAP chitiet = convert(ct);
                    db.CHITIETPHIEUNHAPs.Add(chitiet);
                    db.SACHes.Find(chitiet.MaSach).SoLuong += chitiet.SoLuong;
                }
                catch (Exception e)
                {
                    Message = "Thêm phiếu nhập thất bại " + e.Message;
                    IsSucess = false;
                    return;
                }
            }
            db.SaveChanges();
            Message = "Thêm phiếu nhập thành công";
            IsSucess = true;
        }

        public static void Sua(PhieuNhap pn, IEnumerable<ChiTietPhieuNhap> dsct)
        {
            // Kiểm tra phieu nhap
            if (db.PHIEUNHAPs.Find(pn.MaPN) == null)
            {
                Message = "Phiếu nhập không tồn tại";
                IsSucess = false;
                return;
            }
            NHAXUATBAN nxb = db.NHAXUATBANs.Find(pn.MaNXB);
            if (db.NHAXUATBANs.Find(pn.MaNXB) == null)
            {
                Message = "Nhà xuất bản không tồn tại";
                IsSucess = false;
                return;
            }
            if (db.NHANVIENs.Find(pn.MaNV) == null)
            {
                Message = "Nhân viên không tồn tại";
                IsSucess = false;
                return;
            }
            // kiểm tra từng chi tiết
            foreach (ChiTietPhieuNhap ct in dsct)
            {
                SACH s = db.SACHes.Find(ct.MaSach);
                if (s == null)
                {
                    Message = "Sách " + ct.TenSach + " không tồn tại";
                    IsSucess = false;
                    return;
                }
                if (s.MaNXB != nxb.MaNXB)
                {
                    Message = "Sách " + ct.TenSach + " không thuộc nhà xuất bản " + nxb.TenNXB;
                    IsSucess = false;
                    return;
                }
            }
            // tính tổng tiền
            double tongtien = 0;
            foreach (ChiTietPhieuNhap ct in dsct)
            {
                double gianhap = (from s in db.SACHes
                                  where s.MaSach == ct.MaSach
                                  select s.GiaNhap.Value).SingleOrDefault();
                tongtien += ct.SoLuong * gianhap;
            }
            pn.TongTien = tongtien;
            // thêm phiếu nhập
            try
            {
                PHIEUNHAP phieunhap = db.PHIEUNHAPs.Find(pn.MaPN);
                phieunhap.MaNV = pn.MaNV;
                phieunhap.NgayLap = phieunhap.NgayLap;
            }
            catch (Exception e)
            {
                Message = "Sửa phiếu nhập thất bại " + e.Message;
                IsSucess = false;
                return;
            }
            // Thêm chi tiết phiếu
            foreach (ChiTietPhieuNhap ct in dsct)
            {
                try
                {
                    CHITIETPHIEUNHAP chitiet = db.CHITIETPHIEUNHAPs.Find(ct.MaPN,ct.MaSach);
                    if(chitiet == null)
                    {
                        db.CHITIETPHIEUNHAPs.Add(convert(ct));
                        db.SACHes.Find(ct.MaSach).SoLuong+=ct.SoLuong;
                    }
                    else
                    {
                        db.SACHes.Find(chitiet.MaSach).SoLuong -= chitiet.SoLuong;
                        chitiet.SoLuong = ct.SoLuong;
                        db.SACHes.Find(chitiet.MaSach).SoLuong += chitiet.SoLuong;
                        if(db.SACHes.Find(chitiet.MaSach).SoLuong<0)
                        {
                            Message = "Chi tiết với tên sách "+ db.SACHes.Find(chitiet.MaSach).TenSach+ " không hợp lệ";
                            db = new QuanLyBanSachEntities();
                            IsSucess = false;
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    Message = "Sửa phiếu nhập thất bại " + e.Message;
                    IsSucess = false;
                    return;
                }
            }
            db.SaveChanges();
            Message = "Sửa phiếu nhập thành công";
            IsSucess = true;
        }

        public static void Xoa(PhieuNhap pn)
        {
            // Kiểm tra phieu nhap
            if (db.PHIEUNHAPs.Find(pn.MaPN) == null)
            {
                Message = "Phiếu nhập không tồn tại";
                IsSucess = false;
                return;
            }
            // xóa chi tiết
            IEnumerable<CHITIETPHIEUNHAP> dsct = from ct in db.CHITIETPHIEUNHAPs
                                                 where ct.MaPhieuNhap == pn.MaPN
                                                 select ct;
            foreach(CHITIETPHIEUNHAP ct in dsct)
            {
                db.CHITIETPHIEUNHAPs.Remove(ct);
                db.SACHes.Find(ct.MaSach).SoLuong -= ct.SoLuong;
                if(db.SACHes.Find(ct.MaSach).SoLuong<0)
                {
                    Message = "Không thể xóa phiếu nhập hàng này vì sẽ làm cho số lượng sách "+ db.SACHes.Find(ct.MaSach).TenSach+" nhỏ hơn 0";
                    db = new QuanLyBanSachEntities();
                    IsSucess = false;
                    return;
                }
            }
            // Xóa phiếu nhập
            try
            {
                db.PHIEUNHAPs.Remove(db.PHIEUNHAPs.Find(pn.MaPN));
                db.SaveChanges();
            }catch(Exception e)
            {
                Message = "Xóa phiếu nhập không thành công!\n" +e.Message;
                IsSucess = false;
                return;
            }
            Message = "Xóa phiếu nhập thành công!\n";
            IsSucess = true;
            return;
        }

    }
}
