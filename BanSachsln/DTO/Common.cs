using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace DTO
{
    public enum QUYEN
    {
        NV_BH = 0,
        NV_K = 1,
        QL = 2
    }
    public class Common
    {
        public static bool isDangNhap;
        public static TAIKHOAN taikhoan;
        public static DIEMDANH diemDanh;
        public static CHITIETDIEMDANH ct_DiemDanh;
        public static QUYEN QuyenTryCap = QUYEN.NV_BH;
    }

    public class Regulations
    {
        public static int SoLuongBanSi = 5;
        public static double NoToiDa = 10000000;
        public static int TuoiToiThieu = 18;
        public static int TonToiThieu = 10;
        public static string MatKhau = "123456";
    }
}
