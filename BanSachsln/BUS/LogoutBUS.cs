using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class LogoutBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static bool Logout()
        {
            if(DTO.Common.isDangNhap == false)
            {
                return false;
            }
            if(DTO.Common.taikhoan == null)
            {
                return false;
            }
            // Ghi lại thời gian 
            try
            {
                CHITIETDIEMDANH chitiet = db.CHITIETDIEMDANHs.Find(Common.ct_DiemDanh.MaDiemDanh, Common.ct_DiemDanh.MaTaiKhoan);
                chitiet.GioKetThuc = DateTime.Now.Hour;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

    }
}
