using KTX.MOD;
using Microsoft.AspNetCore.Mvc;
using KTX.BUS;
namespace KTX.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/GuiXe")]
    public class GuiXeController : ControllerBase
    {
        private readonly ILogger<GuiXeController> _logger;
        public GuiXeController(ILogger<GuiXeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_GuiXe, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new GuiXeBUS().DanhSach(p, ref TotalRow);
            Result.TotalRow = TotalRow;
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int MaSV)
        {
            if (MaSV == null) return BadRequest();
            var Result = new GuiXeBUS().ChiTietGuiXe(MaSV);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới thông tin gửi xe
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] NewGuiXe item)
        {
            if (item == null) return BadRequest();
            var Result = new GuiXeBUS().NewGuiXe(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật người dùng
        [HttpPost]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] EditGuiXe item)
        {
            if (item == null) return BadRequest();
            var Result = new GuiXeBUS().CapNhat(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpPost]
        [Route("Xoa")]
        public IActionResult Xoa(int MaSV)
        {
            if (MaSV == null || MaSV < 1) return BadRequest();
            var Result = new GuiXeBUS().Xoa(MaSV);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}