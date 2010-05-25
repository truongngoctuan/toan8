using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
namespace BUS
{
    public class UserBUS
    {
        public static int KiemTraTenDangNhapCoTonTaiKhong(string tenDangNhap)
        {
            bool taiKhoanLaGiaoVien;
            bool taiKhoanLaHocSinh;
            taiKhoanLaGiaoVien = DAO.UserDAO.KiemTraTaiKhoanCoTonTaiHayKhong(tenDangNhap, DTO.UserDTO.DuongDanThuMucTeacherAccount);
            taiKhoanLaHocSinh = DAO.UserDAO.KiemTraTaiKhoanCoTonTaiHayKhong(tenDangNhap, DTO.UserDTO.DuongDanThuMucPupilAccount);
            if (taiKhoanLaGiaoVien)
                return 1;
            if (taiKhoanLaHocSinh)
                return 2;
            return 0;
        }
        public static string LayMatKhauCuaTaiKhoan(string tenDangNhap)
        {
            string ketQua = string.Empty;
            int loaiTaiKhoan = KiemTraTenDangNhapCoTonTaiKhong(tenDangNhap);
            string duongDanThuMucChuaTaiKhoan = string.Empty;
            switch (loaiTaiKhoan)
            {
                case 1:
                    duongDanThuMucChuaTaiKhoan = DTO.UserDTO.DuongDanThuMucTeacherAccount;
                    break;
                case 2:
                    duongDanThuMucChuaTaiKhoan = DTO.UserDTO.DuongDanThuMucPupilAccount;
                    break;
                default:
                    return ketQua;
            }
            ketQua = DAO.UserDAO.LayMatKhauCuaTaiKhoan(tenDangNhap, duongDanThuMucChuaTaiKhoan);
            return ketQua;
        }
    }
}
