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
    public class PhongBUS
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new PhongDAL(). DanhSachPhong(p, ref TotalRow);
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

        public BaseResultMOD ChiTietPhong(int id_Phong)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_Phong == null || id_Phong < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id phòng";
                    return Result;
                }
                else
                {
                    Result.Data = new PhongDAL().ChiTietPhong(id_Phong);
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
        // thêm mới năm học 
        public BaseResultMOD NewPhong(NewPhong item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập thông tin phòng cần thêm!";
                    return Result;
                }
                else if (item == null || item.id_Phong == null) { 

                    Result.Status = 0;
                    Result.Message = "ID phòng không được trống!";
                    return Result;
                }
                else if (item == null || item.Phong == null || string.IsNullOrEmpty(item.Phong))
                {

                    Result.Status = 0;
                    Result.Message = "Tên phòng không được trống!";
                    return Result;
                }

                else if (item.GiaPhong == null || string.IsNullOrEmpty(item.GiaPhong))
                {
                    Result.Status = 0;
                    Result.Message = "Giá phòng không được trống";
                    return Result;
                }
                else if (item.TrangThai == null || string.IsNullOrEmpty(item.TrangThai))
                {
                    Result.Status = 0;
                    Result.Message = "Trạng thái không được trống";
                    return Result;
                }
                else
                {
                    return new PhongDAL().NewPhong(item);
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

        // cap nhat 
        public BaseResultMOD CapNhat(EditPhong item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item.Phong == null || item.Phong.Length < 1 || item.Phong.Trim().Length > 50)
                {
                    Result.Status = 0;
                    Result.Message = "Tên phòng không được trống và độ dài không được quá 50 ký tự";
                    return Result;
                }
                else if (item.GiaPhong == null || item.GiaPhong.Length < 1 || item.GiaPhong.Trim().Length > 50)
                {
                    Result.Status = 0;
                    Result.Message = "Giá phòng không được trống và độ dài không được quá 50 ký tự";
                    return Result;
                }
                if (item.TrangThai == null || item.TrangThai.Length < 1 || item.TrangThai.Trim().Length > 50)
                {
                    Result.Status = 0;
                    Result.Message = "Trạng thái phòng không được trống và độ dài không được quá 50 ký tự";
                    return Result;
                }
                else
                {
                    return new PhongDAL().EditPhong(item);

                }

            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
            }
            return Result;
        }

        // xoa 
        public BaseResultMOD Xoa(int id_Phong)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_Phong == null || id_Phong < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id phòng trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new PhongDAL().ChiTietPhong(id_Phong);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.id_Phong < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "Id phòng không tồn tại!";
                        return Result;
                    }
                    else
                        return new PhongDAL().Xoa(id_Phong);
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