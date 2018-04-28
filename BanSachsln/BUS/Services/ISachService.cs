using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS.Services
{
    public interface ISachService
    {
        IEnumerable<Sach> LayDanhSachSach();
        IEnumerable<TheLoai> LayDanhSachTheLoai();
        IEnumerable<NhaXuatBan> LayDanhSachNXB();
    }
}
