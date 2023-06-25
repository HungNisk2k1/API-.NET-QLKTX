using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTX.MOD
{
    public class PhongMOD
    {
        public int? id_Phong { get; set; }
        public String Phong { get; set; }
        public String GiaPhong { get; set; }
        public String TrangThai { get; set; }
    }
    public class NewPhong
    {
        public int? id_Phong { get; set; }
        public String Phong { get; set; }
        public String GiaPhong { get; set; }
        public String TrangThai { get; set; }
    }
    public class EditPhong
    {
        public int id_Phong { get; set; }
        public String Phong { get; set; }
        public String GiaPhong { get; set; }
        public String TrangThai { get; set; }
    }
}
