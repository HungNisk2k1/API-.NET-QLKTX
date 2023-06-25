using KTX.BUS;
using KTX.MOD;
using Microsoft.AspNetCore.Mvc;
using KTX.DAL;

namespace KTX.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/SinhVien")]
    public class SinhVienController : ControllerBase
    {
        private readonly ILogger<SinhVienController> _logger;
        public SinhVienController(ILogger<SinhVienController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_SinhVien, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new SinhVienBUS().DanhSach(p, ref TotalRow);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        //public IActionResult ChiTiet(int id_MonHoc)
        //{
        //    if (id_MonHoc == null) return BadRequest();
        //    var Result = new SinhVienBUS().ChiTietSV(id_MonHoc);
        public IActionResult ChiTiet(int MaSV)
        {
            if (MaSV == null) return BadRequest();
            var Result = new SinhVienBUS().ChiTietSV(MaSV);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới người dùng
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] NewSV item)
        {
            if (item == null) return BadRequest();
            var Result = new SinhVienBUS().NewSV(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật người dùng
        [HttpPost]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] EditSV item)
        {
            if (item == null) return BadRequest();
            var Result = new SinhVienBUS().CapNhat(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpPost]
        [Route("Xoa")]
        //public IActionResult Xoa(int id_MonHoc)
        public IActionResult Xoa(int MaSV)
        {
            //if (id_MonHoc == null || id_MonHoc < 1) return BadRequest();
            //var Result = new SinhVienBUS().Xoa(id_MonHoc);
            if (MaSV == null || MaSV < 1) return BadRequest();
            var Result = new SinhVienBUS().Xoa(MaSV);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}