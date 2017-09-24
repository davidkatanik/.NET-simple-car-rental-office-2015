using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ORM_KAT0013.Database
{
    public class LoginDML
    {

        public bool Login(string login, string password, string type) 
        {

            Database conn = new Database();
            conn.Connect();

            SqlCommand dataCommand = conn.CreateCommand("select count(*) from UserCredentials where login = @login and password=@password and type=@type");

            dataCommand.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, login.Length));
            dataCommand.Parameters["@login"].Value = login;
            dataCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, password.Length));
            dataCommand.Parameters["@password"].Value = password;
            dataCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar, type.Length));
            dataCommand.Parameters["@type"].Value = type;

            /*dataCommand.Parameters.AddWithValue("@login", login);
            dataCommand.Parameters.AddWithValue("@password", password);
            dataCommand.Parameters.AddWithValue("@type", type);*/
            SqlDataReader reader = conn.Select(dataCommand);
            if (reader.Read())
            {
                if (reader.GetInt32(0) != 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        protected void ProcedureTest(int idProduct)
        {
            Database conn = new Database();
            conn.Connect();

            SqlCommand dataCommand = conn.CreateCommand("EditProduct");
            dataCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = new SqlParameter("@p_idProduct", SqlDbType.Int, 4);
            par1.Direction = ParameterDirection.Input;
            par1.Value = idProduct;
            dataCommand.Parameters.Add(par1);

            dataCommand.ExecuteNonQuery();

            conn.Close();
        }
    }
}