using KTX.MOD;
using Microsoft.AspNetCore.Mvc;
using KTX.BUS;
namespace KTX.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/Phong")]
    public class PhongController : ControllerBase
    {
        private readonly ILogger<PhongController> _logger;
        public PhongController(ILogger<PhongController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_Phong, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new PhongBUS().DanhSach(p, ref TotalRow);
            Result.TotalRow = TotalRow;
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int id_Phong)
        {
            if (id_Phong == null) return BadRequest();
            var Result = new PhongBUS().ChiTietPhong(id_Phong);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới người dùng
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] NewPhong item)
        {
            if (item == null) return BadRequest();
            var Result = new PhongBUS().NewPhong(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật người dùng
        [HttpPost]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] EditPhong item)
        {
            if (item == null) return BadRequest();
            var Result = new PhongBUS().CapNhat(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpPost]
        [Route("Xoa")]
        public IActionResult Xoa(int id_Phong)
        {
            if (id_Phong == null || id_Phong < 1) return BadRequest();
            var Result = new PhongBUS().Xoa(id_Phong);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}