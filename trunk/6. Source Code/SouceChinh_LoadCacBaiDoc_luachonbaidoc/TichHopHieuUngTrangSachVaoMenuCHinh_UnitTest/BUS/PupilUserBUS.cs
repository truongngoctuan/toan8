using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
namespace BUS
{
    public class PupilUserBUS
    {
        public static bool KiemTraTenDangNhapCoTonTaiKhong(string tenDangNhap)
        {
            return PupilUserDAO.KiemTraTenDangNhapCoTonTaiKhong(tenDangNhap);
        }


        public static string LayMatKhauCuaTaiKhoan(string tenDangNhap)
        {
            return DAO.PupilUserDAO.LayMatKhauCuaTaiKhoan(tenDangNhap);
        }
    }
}
