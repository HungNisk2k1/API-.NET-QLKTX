using KTX.MOD;
using Microsoft.AspNetCore.Mvc;
using KTX.BUS;
namespace KTX.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/QLChiPhi")]
    public class QLChiPhiController : ControllerBase
    {
        private readonly ILogger<QLChiPhiController> _logger;
        public QLChiPhiController(ILogger<QLChiPhiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_ChiPhi, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new QLChiPhiBUS().DanhSach(p, ref TotalRow);
            Result.TotalRow = TotalRow;
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int MaSV)
        {
            if (MaSV == null) return BadRequest();
            var Result = new QLChiPhiBUS().ChiTietQLChiPhi(MaSV);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] NewChiPhi item)
        {
            if (item == null) return BadRequest();
            var Result = new QLChiPhiBUS().NewChiPhi(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật
        [HttpPost]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] EditChiPhi item)
        {
            if (item == null) return BadRequest();
            var Result = new QLChiPhiBUS().CapNhat(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpPost]
        [Route("Xoa")]
        public IActionResult Xoa(int MaSV)
        {
            if (MaSV == null || MaSV < 1) return BadRequest();
            var Result = new QLChiPhiBUS().Xoa(MaSV);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}