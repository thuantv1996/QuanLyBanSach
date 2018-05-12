using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BaoCaoTonKhoBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        private static TONKHO LayBaoCao()
        {
            TONKHO tk = (from t in db.TONKHOes
                         orderby t.MaTonKho descending
                         select t).FirstOrDefault();
            return tk;
        }
        public static bool TimBaoCao(int thang,int nam)
        {
            TONKHO tk = (from t in db.TONKHOes
                         where t.NgayBatDau.Value.Month == thang && t.NgayBatDau.Value.Year == nam
                         select t).FirstOrDefault();
            if(tk==null)
            {
                return false;
            }
            return true;
        }   

        public static void ThemBaoCao(int thang,int nam)
        {
            // tìm ngày bắt đầu và kết thúc
            DateTime NgayBD = new DateTime(nam, thang, 1);
            DateTime NgayKT = new DateTime(nam,thang,30);
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    NgayKT = new DateTime(nam, thang, 31);
                    break;
                case 2:
                    NgayKT = new DateTime(nam, thang, 28);
                    if(NgayKT.AddDays(1).Month==thang)
                    {
                        NgayKT = NgayKT.AddDays(1);
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    NgayKT = new DateTime(nam, thang, 30);
                    break;
            }
            // Bước 2: Lập báo cáo
            List<CHITIETTONKHO> DsChiTiet = new List<CHITIETTONKHO>();
            // Lấy báo cáo gần nhất
            int MaTonKho = LayBaoCao().MaTonKho;
            List<CHITIETTONKHO> DsChiTietGanNhat = (from ct in db.CHITIETTONKHOes
                                                    where ct.MaTonKho == MaTonKho
                                                    select ct).ToList();
            IEnumerable<SACH> DsSach = from s in db.SACHes
                                       select s;
            foreach(SACH s in DsSach)
            {
                // Khai báo biến lưu tồn kho hiện tại
                CHITIETTONKHO cur = new CHITIETTONKHO();
                cur.MaSach = s.MaSach;
                int TonDauKy = 0;
                CHITIETTONKHO chitiet = DsChiTietGanNhat.Find(ct => ct.MaSach == s.MaSach);
                if(chitiet!=null)
                {
                    TonDauKy = chitiet.TonCuoi.Value;
                }
                cur.TonDau = TonDauKy;
                int TonCuoiKy = 0;
                // Lấy danh sách nhập trong kỳ
                List<CHITIETPHIEUNHAP> dspn = (from ct in db.CHITIETPHIEUNHAPs
                                   join pn in db.PHIEUNHAPs on ct.MaPhieuNhap equals pn.MaPhieuNhap
                                   where pn.NgayLap.Value.Month == NgayBD.Month && pn.NgayLap.Value.Year == NgayBD.Year && ct.MaSach == s.MaSach
                                   select ct).ToList();
                int NhapTrongKy = 0;
                if (dspn != null)
                {
                    NhapTrongKy = dspn.Sum(ct => ct.SoLuong.Value);
                }
                // Lấy danh sách xuất trong kỳ
                List<CHITIETHOADON> dshd = (from ct in db.CHITIETHOADONs
                                            join hd in db.HOADONs on ct.MaHoaDon equals hd.MaHoaDon
                                            where hd.NgayHoaDon.Value.Month == NgayBD.Month && hd.NgayHoaDon.Value.Year == NgayBD.Year && ct.MaSach == s.MaSach
                                            select ct).ToList();
                int XuatTrongKy = 0;
                if(dshd !=null)
                {
                    XuatTrongKy = dshd.Sum(ct => ct.SoLuong.Value);
                }
                TonCuoiKy = TonDauKy + NhapTrongKy - XuatTrongKy;
                cur.TonCuoi = TonCuoiKy;
                DsChiTiet.Add(cur);
            }
            // Tạo báo cáo
            TONKHO tonkhohientai = new TONKHO
            {
                NgayBatDau = NgayBD,
                NgayKetThuc = NgayKT
            };
            db.TONKHOes.Add(tonkhohientai);
            // Thêm chi tiết
            db.SaveChanges();
            // Mã tồn kho mới
            MaTonKho = LayBaoCao().MaTonKho;
            foreach(CHITIETTONKHO ct in DsChiTiet)
            {
                ct.MaTonKho = MaTonKho;
                db.CHITIETTONKHOes.Add(ct);
            }
            db.SaveChanges();

        }
    }
}
