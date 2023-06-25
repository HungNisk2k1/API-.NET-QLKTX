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
    public class QLChiPhiDAL
    {
        public BaseResultMOD DanhSachChiPhi(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<QLChiPhiMOD> ListQLChiPhi = new List<QLChiPhiMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("Keyword",SqlDbType.NVarChar,200),
                    new SqlParameter("TotalRow",SqlDbType.Int),
            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
            parameters[1].Direction = ParameterDirection.Output;


            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "DM_ListQLChiPhi", parameters))
                {
                    while (dr.Read())
                    {
                        QLChiPhiMOD item = new QLChiPhiMOD();
                        item.id_QLCP = Utils.ConvertToInt32(dr["id_QLCP"], 0);
                        item.MaSV = Utils.ConvertToInt32(dr["MaSV"],0);
                        item.NgayDK = Utils.ConvertToString(dr["NgayDK"], string.Empty);
                        item.NgayNop = Utils.ConvertToString(dr["NgayNop"], string.Empty);
                        item.TrangThai = Utils.ConvertToString(dr["TrangThai"], string.Empty);
                        ListQLChiPhi.Add(item);
                    }
                    dr.Close();
                }
                TotalRow = Utils.ConvertToInt32(parameters[1].Value, 0);
                Result.Status = 1;
                Result.Data = ListQLChiPhi;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                //Result.Message = Constant.API_Error_System;
                Result.Message = ex.ToString();
            }
            return Result;
        }
        public QLChiPhiMOD? ChiTietQLChiPhi(int MaSV)
        {
            QLChiPhiMOD item = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaSV",SqlDbType.Int)
            };
            parameters[0].Value = MaSV;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_ChiTietQLChiPhi", parameters))
                {
                    while (dr.Read())
                    {
                        item = new QLChiPhiMOD();
                        item.id_QLCP = Utils.ConvertToInt32(dr["id_QLCP"], 0);
                        item.MaSV = Utils.ConvertToInt32(dr["MaSV"], 0);
                        item.NgayDK = Utils.ConvertToString(dr["NgayDK"], string.Empty);
                        item.NgayNop = Utils.ConvertToString(dr["NgayNop"], string.Empty);
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

        public BaseResultMOD NewQLChiPhi(NewChiPhi item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@MaSV", SqlDbType.Int),
                        new SqlParameter("@NgayDk", SqlDbType.NVarChar),
                        new SqlParameter("@NgayNop", SqlDbType.NVarChar),
                        new SqlParameter("@TrangThai", SqlDbType.NVarChar),
                };
                parameters[0].Value = item.MaSV;
                parameters[1].Value = item.NgayDK.Trim();
                parameters[2].Value = item.NgayNop.Trim();
                parameters[3].Value = item.TrangThai.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = ULT.Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "DM_NewQLChiPhi", parameters).ToString(), 0);
                            trans.Commit();
                            Result.Message = "Thêm mới thông tin chi phí thành công!";
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

        public BaseResultMOD EditQLChiPhi(EditChiPhi item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@id_QLCP", SqlDbType.Int),
                        new SqlParameter("@MaSV", SqlDbType.Int),
                        new SqlParameter("@NgayDK", SqlDbType.NVarChar),
                        new SqlParameter("@NgayNop", SqlDbType.NVarChar),
                        new SqlParameter("@TrangThai", SqlDbType.NVarChar),
                };
                parameters[0].Value = item.id_QLCP;
                parameters[0].Value = item.MaSV;
                parameters[1].Value = item.NgayDK.Trim();
                parameters[2].Value = item.NgayNop.Trim();
                parameters[3].Value = item.TrangThai.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DM_EditQLChiPhi", parameters);
                            trans.Commit();
                            Result.Message = "Cập nhật thông tin chi phí thành công!";
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


        public BaseResultMOD Xoa(int MaSV)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("MaSV", SqlDbType.Int)
            };
            parameters[0].Value = MaSV;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "DM_DeleteQLChiPhi", parameters);
                        trans.Commit();
                        if (val < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Không thể xóa!";
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

        //Kiểm tra trùng
        public int KiemTraTrung( int MaSV)
        {
            var SoLuong = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                    //new SqlParameter("@id_QLCP",SqlDbType.Int),
                    new SqlParameter("@MaSV",SqlDbType.Int)
            };
            parameters[0].Value = MaSV ;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_KTQLCP", parameters))
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
