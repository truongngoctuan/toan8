using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using DAO;
using DTO;
namespace BUS
{
    public class NguoiDung_BUS
    {
//---------------------------------------------------------------------------
// Xóa hàm bool KiemTraUserNameCoTonTaiChua (string tenDangNhap) - Kiến Minh     
//---------------------------------------------------------------------------
/*        
        public static bool KiemTraUserNameCoTonTaiChua(string tenDangNhap)
        {
            string duongDanHocSinh = DTO.NguoiDung_DTO.DuongDanThuMucPupilAccount + @"/" + tenDangNhap;
            string duongDanGiaoVien = DTO.NguoiDung_DTO.DuongDanThuMucTeacherAccount + @"/" + tenDangNhap;
            bool laHopLe = Directory.Exists(duongDanHocSinh);
            if (laHopLe == false)
            {
                laHopLe = Directory.Exists(duongDanGiaoVien);
            }
            return laHopLe;
        }
*/
//---------------------------------------------------------------------------
//Thay bằng hàm int KiemTraTenDangNhapCoTonTaiKhong(string tenDangNhap) - Kiến Minh
//---------------------------------------------------------------------------
        public static int KiemTraUserNameCoTonTaiChua(string tenDangNhap)
        {
            bool taiKhoanLaGiaoVien;
            bool taiKhoanLaHocSinh;
            taiKhoanLaGiaoVien = DAO.NguoiDung_DAO.KiemTraTaiKhoanCoTonTaiHayKhong(tenDangNhap, DTO.NguoiDung_DTO.DuongDanThuMucTeacherAccount);
            taiKhoanLaHocSinh = DAO.NguoiDung_DAO.KiemTraTaiKhoanCoTonTaiHayKhong(tenDangNhap, DTO.NguoiDung_DTO.DuongDanThuMucPupilAccount);
            if (taiKhoanLaGiaoVien)
                return 1;
            if (taiKhoanLaHocSinh)
                return 2;
            return 0;
        }


        public static int ThemNguoiDungMoi(XElement ThongTinDangKy)
        {
            int ketQua = 0;
            int daTonTai;
            string tenDangNhap = (string)ThongTinDangKy.Element("TenDangNhap");
            string matKhau = (string)ThongTinDangKy.Element("MatKhau");
            string duongDan = DTO.NguoiDung_DTO.DuongDanThuMucPupilAccount + @"/" + tenDangNhap;
            //daTonTai = Directory.Exists(duongDan);
            daTonTai = KiemTraUserNameCoTonTaiChua(tenDangNhap);
            if (daTonTai !=0)
            {
                ketQua = 1;
            }
            if (((tenDangNhap.Length) < 6) || (matKhau.Length<8))
            {
                ketQua = -1;
            }
            if (ketQua == 0)
            {
                DAO.NguoiDung_DAO.ThemNguoiDungMoi(duongDan,ThongTinDangKy);
            }
            return ketQua;
        }

//---------------------------------------------------------
//Phần mới thêm (16-5-2010) - Kiến Minh
//---------------------------------------------------------

        public static string LayMatKhauCuaTaiKhoan(string tenDangNhap)
        {
            string ketQua = string.Empty;
            int loaiTaiKhoan = KiemTraUserNameCoTonTaiChua(tenDangNhap);
            string duongDanThuMucChuaTaiKhoan = string.Empty;
            switch (loaiTaiKhoan)
            {
                case 1:
                    duongDanThuMucChuaTaiKhoan = DTO.NguoiDung_DTO.DuongDanThuMucTeacherAccount;
                    break;
                case 2:
                    duongDanThuMucChuaTaiKhoan = DTO.NguoiDung_DTO.DuongDanThuMucPupilAccount;
                    break;
                default:
                    return ketQua;
            }
            ketQua = DAO.NguoiDung_DAO.LayMatKhauCuaTaiKhoan(tenDangNhap, duongDanThuMucChuaTaiKhoan);
            return ketQua;
        }
    }
}
