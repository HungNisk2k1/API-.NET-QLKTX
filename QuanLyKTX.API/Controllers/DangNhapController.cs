using KTX.BUS;
using Microsoft.AspNetCore.Mvc;
using KTX.BUS;
using KTX.MOD;

namespace KTX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangNhapController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(DangNhapMOD login)
        {
            if (login == null) return BadRequest();
            var Result = new TaiKhoanBUS().LoginBUS(login);
            if (Result != null) return Ok(Result);
            else return BadRequest();

        }
    }

}
