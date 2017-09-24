using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.ObjectModel;

namespace ORM_KAT0013.Database
{
    public class AutoTable
    {
        public static String TABLE_NAME = "Auto";

        public String SQL_SELECT = "SELECT a.*,t.* FROM "+TABLE_NAME+" a JOIN "+Typ_autaTable.TABLE_NAME+" t ON (a.id_typ_auta = t.id_typ_auta)";
        public String SQL_SELECT_SPZ = "SELECT a.*,t.* FROM "+TABLE_NAME+" a JOIN "+Typ_autaTable.TABLE_NAME+" t ON (a.id_typ_auta = t.id_typ_auta) WHERE spz=@spz";
        public String SQL_SELECT_OPRAVA = "SELECT a.*,t.* FROM "+TABLE_NAME+" a JOIN "+Typ_autaTable.TABLE_NAME+" t ON (a.id_typ_auta = t.id_typ_auta) WHERE stav='O'";
        public String SQL_SELECT_NEPROVOZUSCHOPNE = "SELECT a.*,t.* FROM "+TABLE_NAME+" a JOIN "+Typ_autaTable.TABLE_NAME+" t ON (a.id_typ_auta = t.id_typ_auta) WHERE stav='N'";
        public String SQL_SELECT_PROVOZUSCHOPNE = "SELECT a.*,t.* FROM "+TABLE_NAME+" a JOIN "+Typ_autaTable.TABLE_NAME+" t ON (a.id_typ_auta = t.id_typ_auta) WHERE stav='P'";
        public String SQL_INSERT = "INSERT INTO " + TABLE_NAME + " VALUES (@spz, @denni_sazba, @porizovaci_cena," +
                                    "@rok_vyroby, @pocet_oprav, @stav, @id_typ_auta)";
        public String SQL_UPDATE = "UPDATE " + TABLE_NAME + " SET denni_sazba=@denni_sazba, porizovaci_cena=@porizovaci_cena," +
            "rok_vyroby=@rok_vyroby, pocet_oprav=@pocet_oprav, stav=@stav, id_typ_auta=@id_typ_auta WHERE spz=@spz";
        public AutoTable()
        {
        }
        public int Insert(Auto auto)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, auto);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }
        public int Update(Auto auto)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, auto);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, Auto auto)
        {
            command.Parameters.Add(new SqlParameter("@spz", SqlDbType.VarChar, auto.SPZ.Length));
            command.Parameters["@spz"].Value = auto.SPZ;

            command.Parameters.Add(new SqlParameter("@denni_sazba", SqlDbType.Int));
            command.Parameters["@denni_sazba"].Value = auto.Denni_sazba;

            command.Parameters.Add(new SqlParameter("@porizovaci_cena", SqlDbType.Int));
            command.Parameters["@porizovaci_cena"].Value = auto.Porizovaci_cena;

            command.Parameters.Add(new SqlParameter("@rok_vyroby", SqlDbType.Int));
            command.Parameters["@rok_vyroby"].Value = auto.Rok_vyroby;

            command.Parameters.Add(new SqlParameter("@pocet_oprav", SqlDbType.Int));
            command.Parameters["@pocet_oprav"].Value = auto.Pocet_oprav;

            command.Parameters.Add(new SqlParameter("@stav", SqlDbType.Char, Auto.LEN_ATTR_stav));
            command.Parameters["@stav"].Value = auto.Stav;

            command.Parameters.Add(new SqlParameter("@id_typ_auta", SqlDbType.Int));
            command.Parameters["@id_typ_auta"].Value = auto.Typ_auta.Id_typ_auta;
        }
        public Collection<Auto> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Auto> auta = Read(reader,false);
            reader.Close();
            db.Close();
            return auta;
        }
        public Auto Select(String spz)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_SPZ);

            command.Parameters.Add(new SqlParameter("@spz", SqlDbType.VarChar,Auto.LEN_ATTR_spz));
            command.Parameters["@spz"].Value = spz;
            SqlDataReader reader = db.Select(command);

            Collection<Auto> auta = Read(reader,false);
            Auto auto = null;
            if (auta.Count == 1)
            {
                auto = auta[0];
            }
            reader.Close();
            db.Close();
            return auto;
        }
        public Auto SelectComplete(String spz)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_SPZ);

            command.Parameters.Add(new SqlParameter("@spz", SqlDbType.VarChar, Auto.LEN_ATTR_spz));
            command.Parameters["@spz"].Value = spz;
            SqlDataReader reader = db.Select(command);

            Collection<Auto> auta = Read(reader,true);
            Auto auto = null;
            if (auta.Count == 1)
            {
                auto = auta[0];
            }
            reader.Close();
            db.Close();
            return auto;
        }
        public Collection<Auto> Select(char stav)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = null;
            if (stav == 'O')
            {
                command = db.CreateCommand(SQL_SELECT_OPRAVA);
            }
            else if (stav == 'N')
            {
                command = db.CreateCommand(SQL_SELECT_NEPROVOZUSCHOPNE);
            }
            else
            {
                command = db.CreateCommand(SQL_SELECT_PROVOZUSCHOPNE);
            }
            
            command.Parameters.Add(new SqlParameter("@stav", SqlDbType.Char, Auto.LEN_ATTR_stav));
            command.Parameters["@stav"].Value = stav;
            SqlDataReader reader = db.Select(command);

            Collection<Auto> auta = Read(reader,false);
            reader.Close();
            db.Close();
            return auta;
        }
        public Collection<Auto> SelectComplete(char stav)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = null;
            if (stav == 'O')
            {
                command = db.CreateCommand(SQL_SELECT_OPRAVA);
            }
            else if (stav == 'N')
            {
                command = db.CreateCommand(SQL_SELECT_NEPROVOZUSCHOPNE);
            }
            else
            {
                command = db.CreateCommand(SQL_SELECT_PROVOZUSCHOPNE);
            }

            command.Parameters.Add(new SqlParameter("@stav", SqlDbType.Char, Auto.LEN_ATTR_stav));
            command.Parameters["@stav"].Value = stav;
            SqlDataReader reader = db.Select(command);

            Collection<Auto> auta = Read(reader,true);
            reader.Close();
            db.Close();
            return auta;
        }
        private Collection<Auto> Read(SqlDataReader reader,bool complete)
        {
            Collection<Auto> adresy = new Collection<Auto>();

            while (reader.Read())
            {
                Auto auto = new Auto();
                auto.SPZ = reader.GetString(0);
                auto.Denni_sazba = reader.GetInt32(1);
                auto.Porizovaci_cena = reader.GetInt32(2);
                auto.Rok_vyroby = reader.GetInt32(3);
                auto.Pocet_oprav = reader.GetInt32(4);
                auto.Stav = reader.GetString(5)[0];
                auto.Typ_auta = new Typ_auta();
                auto.Typ_auta.Id_typ_auta = reader.GetInt32(6);
                //Kdybych potreboval konkretni model a znacku
                //Vetsinou ale staci ID
                if (complete)
                {
                    auto.Typ_auta.Znacka = reader.GetString(8);
                    auto.Typ_auta.Model = reader.GetString(9);
                }

                adresy.Add(auto);
            }
            return adresy;
        }
    }
}