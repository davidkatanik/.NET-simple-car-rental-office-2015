using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Application_KAT0013.Database
{
    public class PronajemTable
    {
        public static String TABLE_NAME = "Pronajem";

        public String SQL_SELECT = "SELECT * FROM "+TABLE_NAME;
        public String SQL_SELECT_ID = "SELECT * FROM "+TABLE_NAME+" WHERE id_pronajem=@id_pronajem";
        public String SQL_SELECT_OLD = "SELECT * FROM " + TABLE_NAME + " WHERE GETDATE() > datum_do";
        public String SQL_SELECT_ACTUAL = "SELECT * FROM " + TABLE_NAME + " WHERE GETDATE() < datum_do";
        public String SQL_INSERT = "INSERT INTO " + TABLE_NAME + " VALUES (@datum_od, @datum_do, @cena, @zaloha, @poznamka, @id_klient, @spz, @id_zamestnanec)";
        public String SQL_DELETE_ID = "DELETE FROM " + TABLE_NAME + " WHERE id_pronajem=@id_pronajem";
        public String SQL_UPDATE = "UPDATE " + TABLE_NAME + " SET datum_od=@datum_od, datum_do=@datum_do, cena=@cena, zaloha=@zaloha, " +
            "poznamka=@poznamka, id_klient=@id_klient, spz=@spz, id_zamestnanec=@id_zamestnanec WHERE id_pronajem=@id_pronajem";


        //SEZNAM PROBEHNUTYCH VYPUJCEK - HOTOVO
        //SEZNAM AKTUALNICH VYPUJCEK - HOTOVO
        public PronajemTable()
        {
        }

        public int Insert(Pronajem pronajem)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, pronajem);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Update the record.
         **/
        public int Update(Pronajem pronajem)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, pronajem);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, Pronajem pronajem)
        {
            command.Parameters.Add(new SqlParameter("@id_pronajem", SqlDbType.Int));
            command.Parameters["@id_pronajem"].Value = pronajem.Id_pronajem;

            command.Parameters.Add(new SqlParameter("@datum_od", SqlDbType.Date));
            command.Parameters["@datum_od"].Value = pronajem.Datum_od;

            command.Parameters.Add(new SqlParameter("@datum_do", SqlDbType.Date));
            command.Parameters["@datum_do"].Value = pronajem.Datum_do;

            command.Parameters.Add(new SqlParameter("@cena", SqlDbType.Int));
            command.Parameters["@cena"].Value = pronajem.Cena;

            command.Parameters.Add(new SqlParameter("@zaloha", SqlDbType.Int));
            command.Parameters["@zaloha"].Value = pronajem.Zaloha;

            command.Parameters.Add(new SqlParameter("@poznamka", SqlDbType.VarChar, Pronajem.LEN_ATTR_poznamka));
            command.Parameters["@poznamka"].Value = pronajem.Poznamka;

            command.Parameters.Add(new SqlParameter("@id_klient", SqlDbType.Int));
            command.Parameters["@id_klient"].Value = pronajem.Id_klient.Id_klient;

            command.Parameters.Add(new SqlParameter("@spz", SqlDbType.VarChar, Auto.LEN_ATTR_spz));
            command.Parameters["@spz"].Value = pronajem.SPZ.SPZ;

            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = pronajem.Id_zamestnanec.Id_zamestnanec;

        }

        /**
         * Select records.
         **/
        public Collection<Pronajem> SelectOld()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_OLD);
            SqlDataReader reader = db.Select(command);

            Collection<Pronajem> pronajmy = Read(reader);
            reader.Close();
            db.Close();
            return pronajmy;
        }
        public Collection<Pronajem> SelectActual()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ACTUAL);
            SqlDataReader reader = db.Select(command);

            Collection<Pronajem> pronajmy = Read(reader);
            reader.Close();
            db.Close();
            return pronajmy;
        }
        public Collection<Pronajem> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Pronajem> pronajmy = Read(reader);
            reader.Close();
            db.Close();
            return pronajmy;
        }

        /**
         * Select the record.
         **/
        public Pronajem Select(int id_pronajem)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id_pronajem", SqlDbType.Int));
            command.Parameters["@id_pronajem"].Value = id_pronajem;

            SqlDataReader reader = db.Select(command);

            Collection<Pronajem> pronajmy = Read(reader);
            Pronajem pronajem = null;
            if (pronajmy.Count == 1)
            {
                pronajem = pronajmy[0];
            }
            reader.Close();
            db.Close();
            return pronajem;
        }

        private Collection<Pronajem> Read(SqlDataReader reader)
        {
            Collection<Pronajem> pronajmy = new Collection<Pronajem>();

            while (reader.Read())
            {
                Pronajem pronajem = new Pronajem();
                pronajem.Id_pronajem = reader.GetInt32(0);
                pronajem.Datum_od = reader.GetDateTime(1);
                pronajem.Datum_do = reader.GetDateTime(2);
                pronajem.Cena = reader.GetInt32(3);
                pronajem.Zaloha = reader.GetInt32(4);
                if (!reader.IsDBNull(5))
                {
                    pronajem.Poznamka = reader.GetString(5);
                }
                pronajem.Id_klient = new Klient();
                pronajem.Id_klient.Id_klient = reader.GetInt32(6);
                pronajem.SPZ = new Auto();
                pronajem.SPZ.SPZ = reader.GetString(7);
                pronajem.Id_zamestnanec = new Zamestnanec();
                pronajem.Id_zamestnanec.Id_zamestnanec = reader.GetInt32(8);    

                pronajmy.Add(pronajem);
            }
            return pronajmy;
        }
        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@id_pronajem", SqlDbType.Int));
            command.Parameters["@id_pronajem"].Value = id;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
    }
}