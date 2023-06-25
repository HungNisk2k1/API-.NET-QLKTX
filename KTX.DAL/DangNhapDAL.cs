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
    public class DangNhapDAL
    {
        public DangNhapMOD LoginDAL(string UserName, string Password)
        {
            DangNhapMOD item = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserName", SqlDbType.NVarChar),
                new SqlParameter("@Password", SqlDbType.NVarChar),
            };
            parameters[0].Value = UserName;
            parameters[1].Value = Password;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_DangNhap", parameters))
                {
                    while (dr.Read())
                    {
                        item = new DangNhapMOD();
                        item.UserName = Utils.ConvertToString(dr["UserName"], string.Empty);
                        item.Password = Utils.ConvertToString(dr["Password"], string.Empty);

                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return item;
        }

    }
}