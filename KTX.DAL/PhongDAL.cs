using KTX.MOD;
using KTX.ULT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTX.MOD;
using KTX.ULT;

namespace KTX.DAL
{
    public class PhongDAL
    {
        public BaseResultMOD DanhSachPhong(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<PhongMOD> ListPhong = new List<PhongMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("Keyword",SqlDbType.NVarChar,200)
            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";

            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "DM_ListPhong", parameters))
                {
                    while (dr.Read())
                    {
                        PhongMOD item = new PhongMOD();
                        item.id_Phong = Utils.ConvertToInt32(dr["id_Phong"], 0);
                        item.Phong = Utils.ConvertToString(dr["Phong"], string.Empty);
                        item.GiaPhong = Utils.ConvertToString(dr["GiaPhong"], string.Empty);
                        item.TrangThai = Utils.ConvertToString(dr["TrangThai"], string.Empty);
                        ListPhong.Add(item);
                    }
                    dr.Close();
                }
                //TotalRow = Utils.ConvertToInt32(parameters[5].Value, 0);
                Result.Status = 1;
                Result.Data = ListPhong;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                //Result.Message = Constant.API_Error_System;
                Result.Message = ex.ToString();
            }
            return Result;
        }
        public PhongMOD? ChiTietPhong(int id_Phong)
        {
            PhongMOD item = new PhongMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@id_Phong",SqlDbType.Int)
            };
            parameters[0].Value = id_Phong;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_ChiTietPhong", parameters))
                {
                    while (dr.Read())
                    {
                        item = new PhongMOD();
                        item.id_Phong = Utils.ConvertToInt32(dr["id_Phong"], 0);
                        item.Phong = Utils.ConvertToString(dr["Phong"], string.Empty);
                        item.GiaPhong = Utils.ConvertToString(dr["GiaPhong"], string.Empty);
                        item.TrangThai = Utils.ConvertToString(dr["TrangThai"], string.Empty);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return item;
        }

        public BaseResultMOD NewPhong(NewPhong item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@id_Phong", SqlDbType.Int),
                        new SqlParameter("@Phong", SqlDbType.VarChar),
                        new SqlParameter("@GiaPhong", SqlDbType.NVarChar),
                        new SqlParameter("@TrangThai", SqlDbType.VarChar),
                };
                parameters[0].Value = item.id_Phong;
                parameters[1].Value = item.Phong.Trim();
                parameters[2].Value = item.GiaPhong.Trim();
                parameters[3].Value = item.TrangThai.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = ULT.Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "DM_NewPhong", parameters).ToString(), 0);
                            trans.Commit();
                            Result.Message = "Thêm mới phòng thành công!";
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

        public BaseResultMOD EditPhong(EditPhong item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@id_Phong", SqlDbType.Int),
                        new SqlParameter("@Phong", SqlDbType.VarChar),
                        new SqlParameter("@GiaPhong", SqlDbType.NVarChar),
                        new SqlParameter("@TrangThai", SqlDbType.VarChar),
                };
                parameters[0].Value = item.id_Phong;
                parameters[1].Value = item.Phong.Trim();
                parameters[2].Value = item.GiaPhong.Trim();
                parameters[3].Value = item.TrangThai.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DM_EditPhong", parameters);
                            trans.Commit();
                            Result.Message = "Cập nhật thông tin phòng thành công!";
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
                throw;
            }
            return Result;
        }


        public BaseResultMOD Xoa(int id_Phong)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("id_Phong", SqlDbType.Int)
            };
            parameters[0].Value = id_Phong;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "DM_DeletePhong", parameters);
                        trans.Commit();
                        if (val < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Không thể xóa phòng!";
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
            Result.Message = "Xóa phòng thành công!";
            return Result;
        }

        //Kiểm tra trùng
        public int KiemTraTrung(int? id_Phong, string Phong)
        {
            var SoLuong = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@id_Phong",SqlDbType.Int),
                    new SqlParameter("@Phong",SqlDbType.VarChar)
            };
            parameters[0].Value = id_Phong ?? Convert.DBNull;
            parameters[1].Value = Phong;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_KTPhong", parameters))
                {
                    while (dr.Read())
                    {
                        SoLuong = Utils.ConvertToInt32(dr["SoLuong"], 0);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return SoLuong;
        }
    }
}
