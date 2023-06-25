using KTX.MOD;
using KTX.DAL;
using KTX.MOD;
using KTX.ULT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTX.BUS
{
    public class SinhVienBUS
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new SinhVienDAL().DanhSach(p, ref TotalRow);
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                Result.Data = null;
                throw;
            }
            return Result;
        }
        //public BaseResultMOD ChiTietSV(int id_SV)
        public BaseResultMOD ChiTietSV(int MaSV)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (MaSV == null|| MaSV < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn mã sinh viên";
                    return Result;
                }
                else
                {
                    Result.Data = new SinhVienDAL().ChiTietSV(MaSV);
                    Result.Status = 1;
                    return Result;
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                Result.Data = null;
                throw;
            }
            return Result;
        }
        public BaseResultMOD NewSV(NewSV item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập mã sinh viên cần thêm!";
                    return Result;
                }
                else if (item == null || item.MaSV == null )
                {
                    Result.Status = 0;
                    Result.Message = "Mã sinh viên không được trống";
                    return Result;
                }
                else if (item.HoTenSV == null || string.IsNullOrEmpty(item.HoTenSV))
                {

                    Result.Status = 0;
                    Result.Message = "Tên sinh viên không được trống!";
                    return Result;
                }
                else if (item.NgaySinh == null || string.IsNullOrEmpty(item.NgaySinh))
                {

                    Result.Status = 0;
                    Result.Message = "Ngày sinh sinh viên không được trống!";
                    return Result;
                }
                else if (item.DiaChi == null || string.IsNullOrEmpty(item.DiaChi))
                {

                    Result.Status = 0;
                    Result.Message = "Địa chỉ sinh viên không được trống!";
                    return Result;
                }
                else if (item.SDT == null || string.IsNullOrEmpty(item.SDT))
                {

                    Result.Status = 0;
                    Result.Message = "Số điện thoại sinh viên không được trống!";
                    return Result;
                }
                else
                {
                    return new SinhVienDAL().ThemMoi(item);
                }
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }
        public BaseResultMOD CapNhat(EditSV item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.MaSV == null )
                {
                    Result.Status = 0;
                    Result.Message = "Mã sinh viên không được trống";
                    return Result;
                }
                else if (item.HoTenSV.Length > 50)
                {
                    Result.Status = 0;
                    Result.Message = "Độ dài họ tên không được quá 50 ký tự";
                    return Result;
                }
                else if (item.DiaChi.Length > 100)
                {
                    Result.Status = 0;
                    Result.Message = "Độ dài địa chỉ không được quá 100 ký tự";
                    return Result;
                }
                else if (item.SDT.Length > 12)
                {
                    Result.Status = 0;
                    Result.Message = "Độ dài số điện thoại không được quá 12 ký tự";
                    return Result;
                }
                else
                {
                    //var crThamSoHeThong = new SinhVienDAL().ChiTietSV((int)item.id_SV);
                    var crThamSoHeThong = new SinhVienDAL().ChiTietSV((int)item.MaSV);
                    //if (crThamSoHeThong == null || crThamSoHeThong.id_SV < 1)
                    if (crThamSoHeThong == null || crThamSoHeThong.MaSV < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "Mã sinh viên không tồn tại!";
                        return Result;
                    }

                    else
                    {
                        return new SinhVienDAL().CapNhat(item);
                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }
        //------------
        //public BaseResultMOD Xoa(int id_SV)
        public BaseResultMOD Xoa(int MaSV)
        {
            var Result = new BaseResultMOD();
            try
            {
                //if (id_SV == null || id_SV < 1)
                if (MaSV == null || MaSV < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn mã sinh viên trước khi xóa!";
                    return Result;
                }
                else
                {
                    //var kiemTraTaiKhoan = new SinhVienDAL().ChiTietSV(id_SV);
                    var kiemTraTaiKhoan = new SinhVienDAL().ChiTietSV(MaSV);

                    //if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.id_SV < 1)
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.MaSV < 1)

                    {
                        Result.Status = 0;
                        Result.Message = "Mã sinh viên không tồn tại!";
                        return Result;
                    }
                    else
                        //return new SinhVienDAL().Xoa(id_SV);
                        return new SinhVienDAL().Xoa(MaSV);

                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = "Xóa thành công !";

            }
            return Result;
        }
    }
}
