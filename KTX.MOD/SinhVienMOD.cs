namespace KTX.DAL
{
    public class SinhVienMOD
    {
        //public int? id_SV { get; set; }
        public int? MaSV { get; set;}
        public string HoTenSV { get; set;}
        public string NgaySinh { get; set;}
        public string DiaChi { get; set;}
        public string Phong { get; set;}    
        public string SDT { get; set;}

    }
    public class NewSV
    {

        public int? MaSV { get; set; }
        public string HoTenSV { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int? id_Phong { get; set; }
        public string SDT { get; set; }



    }
    public class EditSV
    {
        //public int? id_SV { get; set; }
        public int? MaSV { get; set; }
        public string HoTenSV { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int? id_Phong { get; set; }
        public string SDT { get; set; }



    }

}