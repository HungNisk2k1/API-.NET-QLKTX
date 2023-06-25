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
    public class TaiKhoanBUS
    {
        public BaseResultMOD LoginBUS(DangNhapMOD login)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (login.UserName == null || login.UserName == "")
                {
                    Result.Status = 0;
                    Result.Message = "UserName không được để trống";
                    return Result;
                }
                else if (login.Password == null || login.Password == "")
                {
                    Result.Status = 0;
                    Result.Message = "Mật khẩu không được để trống";
                    return Result;
                }
                else
                {
                    var userLogin = new DangNhapDAL().LoginDAL(login.UserName, login.Password);
                    if (userLogin != null && userLogin.UserName != null)
                    {
                        Result.Status = 1;
                        Result.Message = "Đăng nhập thành công";
                        Result.Data = new LoginMOD() { Status = true, UserName = userLogin.UserName };
                    }
                    else
                    {
                        Result.Status = 0;
                        Result.Message = "Tài khoản hoặc mật khẩu không đúng!";
                    }
                    return Result;
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                throw;
            }
            return Result;
        }
       
    }
}
