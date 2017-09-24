using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.ObjectModel;

namespace Application_KAT0013.Database
{
    public class OddeleniTable
    {
        public static String TABLE_NAME = "Oddeleni";

        public String SQL_SELECT = "SELECT * FROM "+TABLE_NAME;
        public String SQL_SELECT_ID = "SELECT * FROM "+TABLE_NAME+" WHERE id_oddeleni=@id_oddeleni";
        public String SQL_INSERT = "INSERT INTO " + TABLE_NAME + " VALUES (@nazev, @zakladni_mzda)";
        public String SQL_UPDATE = "UPDATE " + TABLE_NAME + " SET nazev=@nazev WHERE id_oddeleni=@id_oddeleni";

        //ZMENA ZAKLADNICH PLATU ODDELENI - Hotovo
        public OddeleniTable()
        {
        }
        public int Insert(Oddeleni oddeleni)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, oddeleni);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }
        public int Update(Oddeleni oddeleni)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, oddeleni);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, Oddeleni oddeleni)
        {
            command.Parameters.Add(new SqlParameter("@id_oddeleni", SqlDbType.Int));
            command.Parameters["@id_oddeleni"].Value = oddeleni.Id_oddeleni;

            command.Parameters.Add(new SqlParameter("@nazev", SqlDbType.VarChar, oddeleni.Nazev.Length));
            command.Parameters["@nazev"].Value = oddeleni.Nazev;

            command.Parameters.Add(new SqlParameter("@zakladni_mzda", SqlDbType.Int));
            command.Parameters["@zakladni_mzda"].Value = oddeleni.Zakladni_mzda;
        }
        public Collection<Oddeleni> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Oddeleni> oddeleni = Read(reader);
            reader.Close();
            db.Close();
            return oddeleni;
        }
        public Oddeleni Select(int id_oddeleni)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id_oddeleni", SqlDbType.Int));
            command.Parameters["@id_oddeleni"].Value = id_oddeleni;
            SqlDataReader reader = db.Select(command);

            Collection<Oddeleni> oddeleni = Read(reader);
            Oddeleni odd = null;
            if (oddeleni.Count == 1)
            {
                odd = oddeleni[0];
            }
            reader.Close();
            db.Close();
            return odd;
        }
        private Collection<Oddeleni> Read(SqlDataReader reader)
        {
            Collection<Oddeleni> oddeleni = new Collection<Oddeleni>();

            while (reader.Read())
            {
                Oddeleni odd = new Oddeleni();
                odd.Id_oddeleni = reader.GetInt32(0);
                odd.Nazev = reader.GetString(1);
                odd.Zakladni_mzda = reader.GetInt32(2);

                oddeleni.Add(odd);
            }
            return oddeleni;
        }
        public void ZmenPlatyVOddeleni(int id_oddeleni, int nova_zakladni_mzda)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand cmd = db.CreateCommand("zmenPlatyVOddeleni");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@p_id_oddeleni", SqlDbType.Int);
            parm.Value = id_oddeleni;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            SqlParameter parm2 = new SqlParameter("@p_zakladni_mzda", SqlDbType.Int);
            parm2.Value = nova_zakladni_mzda;
            parm2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm2);

            int ret = db.ExecuteNonQuery(cmd);

            db.Close();
        }
    }
}