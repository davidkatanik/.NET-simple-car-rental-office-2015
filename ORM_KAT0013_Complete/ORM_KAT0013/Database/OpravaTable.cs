using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.ObjectModel;

namespace ORM_KAT0013.Database
{
    public class OpravaTable
    {
        public static String TABLE_NAME = "Oprava";

        public String SQL_SELECT =  "SELECT * FROM "+TABLE_NAME;
        public String SQL_SELECT_SPECIFIC = "SELECT * FROM "+TABLE_NAME+" WHERE datum_od=@datum_od AND datum_do=@datum_do AND spz=@spz AND id_zamestnanec=@id_zamestnanec";
        public String SQL_INSERT = "INSERT INTO " + TABLE_NAME + " VALUES (@datum_od, @datum_do, @spz, @id_zamestnanec, @cena, @popis)";
        public String SQL_UPDATE = "UPDATE " + TABLE_NAME + " SET cena=@cena, popis=@popis WHERE datum_od=@datum_od AND datum_do=@datum_do " +
                                    "AND spz=@spz AND id_zamestnanec=@id_zamestnanec";
        public OpravaTable()
        {
        }

        /**
         * Insert the record.
         **/
        public int Insert(Oprava oprava)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, oprava);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Update the record.
         **/
        public int Update(Oprava oprava)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, oprava);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, Oprava oprava)
        {
            command.Parameters.Add(new SqlParameter("@datum_od", SqlDbType.Date));
            command.Parameters["@datum_od"].Value = oprava.Datum_od;

            command.Parameters.Add(new SqlParameter("@datum_do", SqlDbType.Date));
            command.Parameters["@datum_do"].Value = oprava.Datum_do;

            command.Parameters.Add(new SqlParameter("@spz", SqlDbType.VarChar, oprava.SPZ.SPZ.Length));
            command.Parameters["@spz"].Value = oprava.SPZ.SPZ;

            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = oprava.Id_zamestnanec.Id_zamestnanec;

            command.Parameters.Add(new SqlParameter("@cena", SqlDbType.Int));
            command.Parameters["@cena"].Value = oprava.Cena;

            command.Parameters.Add(new SqlParameter("@popis", SqlDbType.VarChar, oprava.Popis.Length));
            command.Parameters["@popis"].Value = oprava.Popis;

        }

        /**
         * Select records.
         **/
        public Collection<Oprava> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Oprava> opravy = Read(reader,false);
            reader.Close();
            db.Close();
            return opravy;
        }

        /**
         * Select the record.
         **/
        public Oprava Select(DateTime datum_od, DateTime datum_do,String spz, int id_zamestnanec)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_SPECIFIC);

            command.Parameters.Add(new SqlParameter("@datum_od", SqlDbType.Date));
            command.Parameters["@datum_od"].Value = datum_od;
            command.Parameters.Add(new SqlParameter("@datum_do", SqlDbType.Date));
            command.Parameters["@datum_do"].Value = datum_do;
            command.Parameters.Add(new SqlParameter("@spz", SqlDbType.VarChar, Auto.LEN_ATTR_spz));
            command.Parameters["@spz"].Value = spz;
            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = id_zamestnanec;


            SqlDataReader reader = db.Select(command);

            Collection<Oprava> opravy = Read(reader,false);
            Oprava oprava = null;
            if (opravy.Count == 1)
            {
                oprava = opravy[0];
            }
            reader.Close();
            db.Close();
            return oprava;
        }

        private Collection<Oprava> Read(SqlDataReader reader, bool complete)
        {
            Collection<Oprava> opravy = new Collection<Oprava>();

            while (reader.Read())
            {
                Oprava oprava = new Oprava();
                oprava.Datum_od = reader.GetDateTime(0);
                oprava.Datum_do = reader.GetDateTime(1);

                oprava.SPZ = new Auto();
                oprava.SPZ.SPZ = reader.GetString(2);
                oprava.Id_zamestnanec = new Zamestnanec();
                oprava.Id_zamestnanec.Id_zamestnanec = reader.GetInt32(3);

                oprava.Cena = reader.GetInt32(4);
                oprava.Popis = reader.GetString(5);

                opravy.Add(oprava);
            }
            return opravy;
        }
    }


}