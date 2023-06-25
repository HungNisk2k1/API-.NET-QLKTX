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
    public class GuiXeDAL
    {
        public BaseResultMOD DanhSachGuiXe(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<GuiXeMOD> ListGuiXe = new List<GuiXeMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("Keyword",SqlDbType.NVarChar,200),
                    new SqlParameter("TotalRow",SqlDbType.Int),

            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
            parameters[1].Direction = ParameterDirection.Output;

            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "DM_ListGuiXe", parameters))
                {
                    while (dr.Read())
                    {
                        GuiXeMOD item = new GuiXeMOD();
                        item.id_GX = Utils.ConvertToInt32(dr["id_GX"], 0);
                        item.MaSV = Utils.ConvertToInt32(dr["MaSV"], 0);
                        item.LoaiXe = Utils.ConvertToString(dr["LoaiXe"], string.Empty);
                        item.Bien = Utils.ConvertToString(dr["Bien"], string.Empty);
                        ListGuiXe.Add(item);
                    }
                    dr.Close();
                }
                TotalRow = Utils.ConvertToInt32(parameters[1].Value, 0);
                Result.Status = 1;
                Result.Data = ListGuiXe;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                //Result.Message = Constant.API_Error_System;
                Result.Message = ex.ToString();
            }
            return Result;
        }
        public GuiXeMOD ChiTietGuiXe(int MaSV)
        {
            //GuiXeMOD item = new GuiXeMOD();
            GuiXeMOD item = null;

            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaSV",SqlDbType.Int)
            };
            parameters[0].Value = MaSV;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_ChiTietGuiXe", parameters))
                {
                    while (dr.Read())
                    {
                        item = new GuiXeMOD();
                        item.id_GX = Utils.ConvertToInt32(dr["id_GX"], 0);
                        item.MaSV = Utils.ConvertToInt32(dr["MaSV"], 0);
                        item.LoaiXe = Utils.ConvertToString(dr["LoaiXe"], string.Empty);
                        item.Bien = Utils.ConvertToString(dr["Bien"], string.Empty);
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

        public BaseResultMOD NewGuiXe(NewGuiXe item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {new SqlParameter("@id_GX", SqlDbType.Int),
                        new SqlParameter("@MaSV", SqlDbType.Int),
                        new SqlParameter("@LoaiXe", SqlDbType.NVarChar),
                        new SqlParameter("@Bien", SqlDbType.NVarChar),
                        //new SqlParameter("@SDT", SqlDbType.NVarChar),
                };
                parameters[0].Value = item.id_GX;
                parameters[1].Value = item.MaSV;
                parameters[2].Value = item.LoaiXe.Trim();
                parameters[3].Value = item.Bien.Trim();
                //parameters[3].Value = item.SDT.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = ULT.Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "DM_NewGuiXe", parameters).ToString(), 0);
                            trans.Commit();
                            Result.Message = "Thêm mới sinh viên gửi xe thành công!";
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

        public BaseResultMOD EditGuiXe(EditGuiXe item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@id_GX", SqlDbType.Int),
                        new SqlParameter("@MaSV", SqlDbType.Int),
                        new SqlParameter("@LoaiXe", SqlDbType.NVarChar),
                        new SqlParameter("@Bien", SqlDbType.NVarChar),
                        //new SqlParameter("@SDT", SqlDbType.NVarChar),

                };
                parameters[0].Value = item.id_GX;
                parameters[1].Value = item.MaSV;
                parameters[2].Value = item.LoaiXe.Trim();
                parameters[3].Value = item.Bien.Trim();
                //parameters[4].Value = item.SDT.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DM_EditGuiXe", parameters);
                            trans.Commit();
                            Result.Message = "Cập nhật thông tin gửi xe thành công!";
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
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "DM_DeleteGuiXe", parameters);
                        trans.Commit();
                        if (val < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Không thể xóa thông tin gửi xe này!";
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
            Result.Message = "Xóa thông tin gửi xe thành công!";
            return Result;
        }

        //Kiểm tra trùng
        public int KiemTraTrung(int? id_GX,int? MaSV )
        {
            var SoLuong = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@id_GX",SqlDbType.Int),
                    new SqlParameter("@MaSV",SqlDbType.Int)
            };
            parameters[0].Value = id_GX ?? Convert.DBNull;
            parameters[1].Value = MaSV ?? Convert.DBNull;

           
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_KTGuiXe", parameters))
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
