using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ORM_KAT0013.Database
{
    public class Historie_mezdTable
    {
        public static String TABLE_NAME = "Historie_mezd";

        public String SQL_SELECT = "SELECT * FROM " + TABLE_NAME+" h JOIN "+ZamestnanecTable.TABLE_NAME+" z ON(h.id_zamestnanec=z.id_zamestnanec)";
        public String SQL_SELECT_ID = "SELECT * FROM " + TABLE_NAME + " h JOIN " + ZamestnanecTable.TABLE_NAME + " z ON(h.id_zamestnanec=z.id_zamestnanec) WHERE h.id_zamestnanec=@id_zamestnanec";
        public String SQL_SELECT_SPECIFIC = "SELECT * FROM " + TABLE_NAME + " h JOIN " + ZamestnanecTable.TABLE_NAME + " z ON(h.id_zamestnanec=z.id_zamestnanec) WHERE h.datum_od=@datum_od AND h.datum_do=@datum_do AND h.id_zamestnanec=@id_zamestnanec";
        //public String SQL_INSERT = "INSERT INTO " + TABLE_NAME+" VALUES (@datum_od, @datum_do, @id_zamestnanec, @mzda)";
        //public String SQL_DELETE_ID = "DELETE FROM " + TABLE_NAME+" WHERE datum_od=@datum_od AND datum_do=@datum_do AND id_zamestnanec=@id_zamestnanec";
        //public String SQL_UPDATE = "UPDATE " + TABLE_NAME+" SET datum_od=@datum_od, datum_do=@datum_do, id_zamestnanec=@id_zamestnanec," +
        //    "mzda=@mzda WHERE datum_od=@datum_od AND datum_do=@datum_do AND id_zamestnanec=@id_zamestnanec";

        public Historie_mezdTable()
        {
        }

        /**
         * Insert the record.
         **/
        /*public int Insert(Historie_mezd hi_mezd)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, hi_mezd);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /**
         * Update the record.
         **/
        /*public int Update(Historie_mezd hi_mezd)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, hi_mezd);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, Historie_mezd hi_mezd)
        {
            command.Parameters.Add(new SqlParameter("@datum_od", SqlDbType.Date));
            command.Parameters["@datum_od"].Value = hi_mezd.Datum_od;

            command.Parameters.Add(new SqlParameter("@datum_do", SqlDbType.Date));
            command.Parameters["@datum_do"].Value = hi_mezd.Datum_do;

            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = hi_mezd.Zamestnanec.Id_zamestnanec;

            command.Parameters.Add(new SqlParameter("@mzda", SqlDbType.Int));
            command.Parameters["@mzda"].Value = hi_mezd.Mzda;

        }

        /**
         * Select records.
         **/
        public Collection<Historie_mezd> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Historie_mezd> hi_mzdy = Read(reader,false);
            reader.Close();
            db.Close();
            return hi_mzdy;
        }

        /**
         * Select the record.
         **/
        public Historie_mezd Select(DateTime datum_od, DateTime datum_do, int id_zamestnanec)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_SPECIFIC);

            command.Parameters.Add(new SqlParameter("@datum_od", SqlDbType.Date));
            command.Parameters["@datum_od"].Value = datum_od;
            command.Parameters.Add(new SqlParameter("@datum_do", SqlDbType.Date));
            command.Parameters["@datum_do"].Value = datum_do;
            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = id_zamestnanec;
            SqlDataReader reader = db.Select(command);

            Collection<Historie_mezd> hi_mzdy = Read(reader,false);
            Historie_mezd hi_mzda = null;
            if (hi_mzdy.Count == 1)
            {
                hi_mzda = hi_mzdy[0];
            }
            reader.Close();
            db.Close();
            return hi_mzda;
        }
        public Historie_mezd SelectComplete(DateTime datum_od, DateTime datum_do, int id_zamestnanec)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_SPECIFIC);

            command.Parameters.Add(new SqlParameter("@datum_od", SqlDbType.Date));
            command.Parameters["@datum_od"].Value = datum_od;
            command.Parameters.Add(new SqlParameter("@datum_do", SqlDbType.Date));
            command.Parameters["@datum_do"].Value = datum_do;
            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = id_zamestnanec;
            SqlDataReader reader = db.Select(command);

            Collection<Historie_mezd> hi_mzdy = Read(reader,true);
            Historie_mezd hi_mzda = null;
            if (hi_mzdy.Count == 1)
            {
                hi_mzda = hi_mzdy[0];
            }
            reader.Close();
            db.Close();
            return hi_mzda;
        }
        public Collection<Historie_mezd> Select(int id_zamestnanec)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = id_zamestnanec;
            SqlDataReader reader = db.Select(command);

            Collection<Historie_mezd> hi_mzdy = Read(reader,false);
            reader.Close();
            db.Close();
            return hi_mzdy;
        }
        public Collection<Historie_mezd> SelectCoplete(int id_zamestnanec)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = id_zamestnanec;
            SqlDataReader reader = db.Select(command);

            Collection<Historie_mezd> hi_mzdy = Read(reader, true);
            reader.Close();
            db.Close();
            return hi_mzdy;
        }

        private Collection<Historie_mezd> Read(SqlDataReader reader, bool complete)
        {
            Collection<Historie_mezd> hi_mzdy = new Collection<Historie_mezd>();

            while (reader.Read())
            {
                Historie_mezd hi_mzda = new Historie_mezd();
                hi_mzda.Datum_od = reader.GetDateTime(0);
                hi_mzda.Datum_do = reader.GetDateTime(1);
                hi_mzda.Zamestnanec = new Zamestnanec();
                hi_mzda.Zamestnanec.Id_zamestnanec = reader.GetInt32(2);

                hi_mzda.Mzda = reader.GetInt32(3);
                //4 je id zamestnance z tab zamestnanec
                if (complete)
                {
                    hi_mzda.Zamestnanec.Jmeno = reader.GetString(5);
                    hi_mzda.Zamestnanec.Prijmeni = reader.GetString(6);
                    hi_mzda.Zamestnanec.Typ = reader.GetString(7)[0];
                    hi_mzda.Zamestnanec.RC = reader.GetString(8);
                    hi_mzda.Zamestnanec.Telefon = reader.GetString(9);
                    hi_mzda.Zamestnanec.Email = reader.GetString(10);
                    hi_mzda.Zamestnanec.Datum_nastupu = reader.GetDateTime(11);
                    if (!reader.IsDBNull(12))
                    {
                        hi_mzda.Zamestnanec.Datum_do = reader.GetDateTime(12);
                    }
                    hi_mzda.Zamestnanec.Pohybliva_mzda = reader.GetInt32(13);
                    hi_mzda.Zamestnanec.Zakladni_mzda = reader.GetInt32(14);
                    hi_mzda.Zamestnanec.Id_adresa = new Adresa();
                    hi_mzda.Zamestnanec.Id_adresa.Id_adresa = reader.GetInt32(15);
                    hi_mzda.Zamestnanec.Id_oddeleni = new Oddeleni();
                    hi_mzda.Zamestnanec.Id_oddeleni.Id_oddeleni = reader.GetInt32(16);
                }

                hi_mzdy.Add(hi_mzda);
            }
            return hi_mzdy;
        }
    }
}