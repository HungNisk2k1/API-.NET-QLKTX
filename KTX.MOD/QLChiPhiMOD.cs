using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTX.MOD
{
    public class QLChiPhiMOD
    {
        public int? id_QLCP { get; set; }
        public int MaSV { get; set; }
        public String NgayDK { get; set; }
        public String NgayNop { get; set; }
        public String TrangThai { get; set; }
    }
    public class NewChiPhi
    {
        public int MaSV { get; set; }
        public String NgayDK { get; set; }
        public String NgayNop { get; set; }
        public String TrangThai { get; set; }
    }
    public class EditChiPhi
    {
        public int? id_QLCP { get; set; }
        public int MaSV { get; set; }
        public String NgayDK { get; set; }
        public String NgayNop { get; set; }
        public String TrangThai { get; set; }
    }
}
