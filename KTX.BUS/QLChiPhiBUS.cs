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
    public class QLChiPhiBUS
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new QLChiPhiDAL().DanhSachChiPhi(p, ref TotalRow);
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

        public BaseResultMOD ChiTietQLChiPhi(int MaSV)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (MaSV == null || MaSV < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id quản lý chi phí của sunh viên";
                    return Result;
                }
                else
                {
                    Result.Data = new QLChiPhiDAL().ChiTietQLChiPhi(MaSV);
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
        // thêm mới thông tin chi phí
        public BaseResultMOD NewChiPhi(NewChiPhi item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập thông tin chi phí của sinh viên cần thêm!";
                    return Result;
                }
                else if (item == null || item.MaSV == null)
                {

                    Result.Status = 0;
                    Result.Message = "Mã sinh viên không được trống!";
                    return Result;
                }

                else if (item.NgayDK == null || string.IsNullOrEmpty(item.NgayDK))
                {
                    Result.Status = 0;
                    Result.Message = "Ngày đăng ký không được trống";
                    return Result;
                }
                else if (item.NgayNop == null || string.IsNullOrEmpty(item.NgayNop))
                {
                    Result.Status = 0;
                    Result.Message = "Ngày Nộp không được trống";
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
                    return new QLChiPhiDAL().NewQLChiPhi(item);
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
        public BaseResultMOD CapNhat(EditChiPhi item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item.MaSV == null)
                {
                    Result.Status = 0;
                    Result.Message = "Mã sinh viên không được trống";
                    return Result;
                }
                else if (item.NgayDK == null)
                {
                    Result.Status = 0;
                    Result.Message = "Ngày đăng ký không được trống";
                    return Result;
                }
                else if (item.NgayNop == null)
                {
                    Result.Status = 0;
                    Result.Message = "Ngày nộp không được trống";
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
                    return new QLChiPhiDAL().EditQLChiPhi(item);

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
        public BaseResultMOD Xoa(int MaSV)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (MaSV == null || MaSV < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn thông tin mã sinh viên trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraThongTin = new QLChiPhiDAL().ChiTietQLChiPhi(MaSV);
                    if (kiemTraThongTin == null || kiemTraThongTin.MaSV < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "Thông tin mã sinh viên không tồn tại!";
                        return Result;
                    }
                    else
                        return new QLChiPhiDAL().Xoa(MaSV);
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