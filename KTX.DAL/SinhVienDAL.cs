using KTX.MOD;
using KTX.ULT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTX.DAL
{
    public class SinhVienDAL
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<SinhVienMOD> DanhsachSV = new List<SinhVienMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
         new SqlParameter("Keyword",SqlDbType.NVarChar,50),
                new SqlParameter("TotalRow",SqlDbType.Int),
            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
            parameters[1].Direction = ParameterDirection.Output;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "DM_ListSinhVien", parameters))
                {
                    while (dr.Read())
                    {
                        SinhVienMOD item = new SinhVienMOD();
                        //item.id_SV = Utils.ConvertToInt32(dr["id_SV"], 0);
                        //item.MaSV = Utils.ConvertToString(dr["MaSV"], string.Empty);
                        item.MaSV = Utils.ConvertToInt32(dr["MaSV"], 0);
                        item.HoTenSV = Utils.ConvertToString(dr["HoTenSV"], string.Empty);
                        item.NgaySinh = Utils.ConvertToString(dr["NgaySinh"], string.Empty);
                        item.DiaChi = Utils.ConvertToString(dr["DiaChi"], string.Empty);
                        item.Phong = Utils.ConvertToString(dr["Phong"], string.Empty);
                        item.SDT = Utils.ConvertToString(dr["SDT"], string.Empty);
                        DanhsachSV.Add(item);
                    }
                    dr.Close();
                }
                TotalRow = Utils.ConvertToInt32(parameters[1].Value, 0);
                Result.Status = 1;
                Result.Data = DanhsachSV;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                throw;
            }
            return Result;

        }
        public SinhVienMOD ChiTietSV(int MaSV)
        {
            SinhVienMOD item = null;

            SqlParameter[] parameters = new SqlParameter[]
                   {
                       //new SqlParameter("id_SV", SqlDbType.Int)
                    new SqlParameter("@MaSV", SqlDbType.Int)
                   };
            parameters[0].Value = MaSV;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_ChiTietSinhVien", parameters))
                {
                    while (dr.Read())
                    {
                        item = new SinhVienMOD();

                        //item.id_SV = Utils.ConvertToInt32(dr["id_SV"], 0);
                        //item.MaSV = Utils.ConvertToString(dr["MaSV"], string.Empty);
                        item.MaSV = Utils.ConvertToInt32(dr["MaSV"], 0);
                        item.HoTenSV = Utils.ConvertToString(dr["HoTenSV"], string.Empty);
                        item.NgaySinh = Utils.ConvertToString(dr["NgaySinh"], string.Empty);
                        item.DiaChi = Utils.ConvertToString(dr["DiaChi"], string.Empty);
                        item.Phong = Utils.ConvertToString(dr["Phong"], string.Empty);
                        item.SDT = Utils.ConvertToString(dr["SDT"], string.Empty);

                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return item;
        }
       
        public BaseResultMOD ThemMoi(NewSV item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
               {

                    new SqlParameter("MaSV", SqlDbType.Int),
                    new SqlParameter("HoTenSV", SqlDbType.NVarChar),
                    new SqlParameter("NgaySinh", SqlDbType.NVarChar),
                    new SqlParameter("DiaChi", SqlDbType.NVarChar),
                    new SqlParameter("id_Phong", SqlDbType.Int),
                    new SqlParameter("SDT", SqlDbType.NVarChar),
               };


                parameters[0].Value = item.MaSV;
                parameters[1].Value = item.HoTenSV.Trim();
                parameters[2].Value = item.NgaySinh.Trim();
                parameters[3].Value = item.DiaChi.Trim();
                parameters[4].Value = item.id_Phong;
                parameters[5].Value = item.SDT.Trim();

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "DM_NewSinhVien", parameters).ToString(), 0);
                            trans.Commit();
                            Result.Message = "Thêm mới thành công!";
                            Result.Data = Result.Status;
                        }
                        catch (Exception ex)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_INSERT;
                            trans.Rollback();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
            }
            return Result;

        }
        //-------------------
        public BaseResultMOD CapNhat(EditSV item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
               {
                   //new SqlParameter("id_SV", SqlDbType.Int),
                    new SqlParameter("MaSV", SqlDbType.Int),
                    new SqlParameter("HoTenSV", SqlDbType.NVarChar),
                    new SqlParameter("NgaySinh", SqlDbType.NVarChar),
                    new SqlParameter("DiaChi", SqlDbType.NVarChar),
                    new SqlParameter("id_Phong", SqlDbType.Int),
                   new SqlParameter("SDT", SqlDbType.NVarChar),
               };

                //parameters[0].Value = item.id_SV;
                parameters[0].Value = item.MaSV;
                parameters[1].Value = item.HoTenSV.Trim();
                parameters[2].Value = item.NgaySinh.Trim();
                parameters[3].Value = item.DiaChi.Trim();
                parameters[4].Value = item.id_Phong;
                parameters[5].Value = item.SDT.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DM_EditSinhVien ", parameters);
                            trans.Commit();
                            Result.Message = "Cập nhật thành công!";
                            Result.Data = Result.Status;
                        }
                        catch (Exception ex)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_UPDATE;
                            trans.Rollback();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_UPDATE;
            }
            return Result;
        }

        //public BaseResultMOD Xoa(int id_SV)
        public BaseResultMOD Xoa(int MaSV)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
               //new SqlParameter("id_SV", SqlDbType.Int)
               new SqlParameter("@MaSV", SqlDbType.Int)
            };
            //parameters[0].Value = id_SV;
            parameters[0].Value = MaSV;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var qr = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "DM_DeleteSinhVien ", parameters);
                        trans.Commit();
                        if (qr < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Không thể xóa sinh viên!";
                            return Result;
                        }
                    }
                    catch
                    {
                        Result.Status = -1;
                        Result.Message = Constant.ERR_DELETE;
                        trans.Rollback();
                        return Result;
                        throw;
                    }
                }
            }
            Result.Status = 1;
            Result.Message = "Xóa thành công!";
            return Result;
        }
    }
}
