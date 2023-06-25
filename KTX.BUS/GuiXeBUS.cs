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
    public class GuiXeBUS
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new GuiXeDAL().DanhSachGuiXe(p, ref TotalRow);
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

        public BaseResultMOD ChiTietGuiXe(int MaSV)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (MaSV == null || MaSV < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id gửi xe";
                    return Result;
                }
                else
                {
                    Result.Data = new GuiXeDAL().ChiTietGuiXe(MaSV);
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
        // thêm mới thông tin gửi xe 
        public BaseResultMOD NewGuiXe(NewGuiXe item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập thông tin gửi xe cần thêm!";
                    return Result;
                }
                else if (item == null || item.MaSV == null )
                {
                    Result.Status = 0;
                    Result.Message = "Mã sinh viên không được trống!";
                    return Result;
                }

                else if (item.LoaiXe == null || string.IsNullOrEmpty(item.LoaiXe))
                {
                    Result.Status = 0;
                    Result.Message = "Loại xe không được trống";
                    return Result;
                }
                else if (item.Bien == null || string.IsNullOrEmpty(item.Bien))
                {
                    Result.Status = 0;
                    Result.Message = "Biển số không được trống";
                    return Result;
                }
                //else if (item.SDT == null || string.IsNullOrEmpty(item.SDT))
                //{
                //    Result.Status = 0;
                //    Result.Message = "Số điện thoại không được trống";
                //    return Result;
                //}
                else
                {
                    return new GuiXeDAL().NewGuiXe(item);
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
        public BaseResultMOD CapNhat(EditGuiXe item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item.LoaiXe == null || item.LoaiXe.Length < 1 || item.LoaiXe.Trim().Length > 20)
                {
                    Result.Status = 0;
                    Result.Message = "Loại xe không được trống và độ dài không được quá 20 ký tự";
                    return Result;
                }
                if (item.Bien == null || item.Bien.Length < 1 || item.Bien.Trim().Length > 10)
                {
                    Result.Status = 0;
                    Result.Message = "Biển không được trống và độ dài không được quá 10 ký tự";
                    return Result;
                }
                //if (item.SDT == null || item.SDT.Length < 1 || item.SDT.Trim().Length > 12)
                //{
                //    Result.Status = 0;
                //    Result.Message = "Số điện thoại không được trống và độ dài không được quá 12 ký tự";

                //}
                else
                {
                    return new GuiXeDAL().EditGuiXe(item);

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
                    Result.Message = "Vui lòng chọn mã sinh viên gửi xe trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTTGuiXe = new GuiXeDAL().ChiTietGuiXe(MaSV);
                    if (kiemTraTTGuiXe == null || kiemTraTTGuiXe.MaSV < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "Mã sinh viên gửi xe không tồn tại!";
                        return Result;
                    }
                    else
                        return new GuiXeDAL().Xoa(MaSV);
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