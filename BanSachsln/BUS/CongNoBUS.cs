using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class CongNoBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static void ThemBaoCao(int thang, int nam)
        {
            // tìm ngày bắt đầu và kết thúc
            DateTime NgayBD = new DateTime(nam, thang, 1);
            DateTime NgayKT = new DateTime(nam, thang, 30);
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
                    if (NgayKT.AddDays(1).Month == thang)
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
            List<CHITIETCONGNO> DsChiTiet = new List<CHITIETCONGNO>();
            // Lấy báo cáo gần nhất
            int MaCongNo = LayBaoCao().MaCongNo;
            List<CHITIETCONGNO> DsChiTietGanNhat = (from ct in db.CHITIETCONGNOes
                                                    where ct.MaCongNo == MaCongNo
                                                    select ct).ToList();
            IEnumerable<KHACHHANG> DsKhachHang = from kh in db.KHACHHANGs
                                                 select kh;
            foreach(KHACHHANG kh in DsKhachHang)
            {
                CHITIETCONGNO cur = new CHITIETCONGNO();
                cur.MaKH = kh.MaKH;
                double NoDauKy = 0;
                CHITIETCONGNO chitiet = DsChiTietGanNhat.Find(ct => ct.MaKH == kh.MaKH);
                if(chitiet!=null)
                {
                    NoDauKy = chitiet.NoCuoi.Value;
                }
                cur.NoDau = NoDauKy;
                double NoCuoiKy = 0;
                List<HOADON> hd = (from h in db.HOADONs
                                  where h.NgayHoaDon.Value.Month == thang && h.NgayHoaDon.Value.Year == nam && h.MaKH == kh.MaKH
                                  select h).ToList();
                List<THANHTOAN> tt = (from t in db.THANHTOANs
                                   where t.NgayThanhToan.Value.Month == thang && t.NgayThanhToan.Value.Year == nam && t.MaKhachHang == kh.MaKH
                                   select t).ToList();
                double NoTrongKy = 0;
                if(hd!=null)
                {
                    NoTrongKy = hd.Sum(h=>h.TongTien.Value);
                }
                double ThanhToanTrongKy = 0;
                if (tt != null)
                {
                    ThanhToanTrongKy = tt.Sum(h => h.SoTien.Value);
                }
                cur.NoCuoi = NoDauKy + NoTrongKy - ThanhToanTrongKy;
                DsChiTiet.Add(cur);
            }
            CONGNO congco = new CONGNO { NgayBatDau = NgayBD, NgayKetThuc = NgayKT };
            try
            {
                db.CONGNOes.Add(congco);
                db.SaveChanges();
            }
            catch { }
            MaCongNo = LayBaoCao().MaCongNo;
            foreach(CHITIETCONGNO ct in DsChiTiet)
            {
                ct.MaCongNo = MaCongNo;
                db.CHITIETCONGNOes.Add(ct);
            }
            db.SaveChanges();
        }

        private static CONGNO LayBaoCao()
        {
            CONGNO cn = (from c in db.CONGNOes
                         orderby c.MaCongNo descending
                         select c).FirstOrDefault();
            return cn;
        }
        public static bool TimBaoCao(int thang, int nam)
        {
            CONGNO cn = (from t in db.CONGNOes
                         where t.NgayBatDau.Value.Month == thang && t.NgayBatDau.Value.Year == nam
                         select t).SingleOrDefault();
            if (cn == null)
            {
                return false;
            }
            return true;
        }
    }

}
