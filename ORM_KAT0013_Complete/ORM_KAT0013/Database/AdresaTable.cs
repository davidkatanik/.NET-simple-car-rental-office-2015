using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.ObjectModel;

namespace ORM_KAT0013.Database
{
    public class AdresaTable
    {
        public static String TABLE_NAME = "Adresa";

        public String SQL_SELECT = "SELECT * FROM "+TABLE_NAME;
        public String SQL_SELECT_ID = "SELECT * FROM "+TABLE_NAME+" WHERE id_adresa=@id_adresa";
        public String SQL_LAST_ID = "SELECT TOP 1 * FROM " + TABLE_NAME + " ORDER BY id_adresa DESC";
        public String SQL_INSERT = "INSERT INTO "+TABLE_NAME+" VALUES (@mesto, @ulice, @stat, @psc, @pocet_klientu)";
        public String SQL_UPDATE = "UPDATE " + TABLE_NAME + " SET ulice=@ulice, mesto=@mesto," +
            "psc=@psc, stat=@stat, pocet_klientu=@pocet_klientu WHERE id_adresa=@id_adresa";

        //AKTUALIZACE ADRESY PRO KLIENTA A PREPOCET - HOTOVO v klientovi
        public AdresaTable()
        {
        }
        public int Insert(Adresa adresa)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, adresa);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }
        public int Update(Adresa adresa)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, adresa);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, Adresa adresa)
        {
            command.Parameters.Add(new SqlParameter("@id_adresa", SqlDbType.Int));
            command.Parameters["@id_adresa"].Value = adresa.Id_adresa;

            command.Parameters.Add(new SqlParameter("@mesto", SqlDbType.VarChar, adresa.Mesto.Length));
            command.Parameters["@mesto"].Value = adresa.Mesto;

            command.Parameters.Add(new SqlParameter("@ulice", SqlDbType.VarChar, adresa.Ulice.Length));
            command.Parameters["@ulice"].Value = adresa.Ulice;

            command.Parameters.Add(new SqlParameter("@stat", SqlDbType.Char, adresa.Stat.Length));
            command.Parameters["@stat"].Value = adresa.Stat;

            command.Parameters.Add(new SqlParameter("@psc", SqlDbType.Char, adresa.PSC.Length));
            command.Parameters["@psc"].Value = adresa.PSC;

            command.Parameters.Add(new SqlParameter("@pocet_klientu", SqlDbType.Int));
            command.Parameters["@pocet_klientu"].Value = adresa.Pocet_klientu;
        }
        public Collection<Adresa> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Adresa> adresy = Read(reader);
            reader.Close();
            db.Close();
            return adresy;
        }
        public Adresa Select(int id_adresa)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id_adresa", SqlDbType.Int));
            command.Parameters["@id_adresa"].Value = id_adresa;
            SqlDataReader reader = db.Select(command);

            Collection<Adresa> adresy = Read(reader);
            Adresa adresa = null;
            if (adresy.Count == 1)
            {
                adresa = adresy[0];
            }
            reader.Close();
            db.Close();
            return adresa;
        }
        public Adresa SelectLast()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_LAST_ID);
            SqlDataReader reader = db.Select(command);

            Collection<Adresa> adresy = Read(reader);
            Adresa adresa = null;
            if (adresy.Count == 1)
            {
                adresa = adresy[0];
            }
            reader.Close();
            db.Close();
            return adresa;
        }
        private Collection<Adresa> Read(SqlDataReader reader)
        {
            Collection<Adresa> adresy = new Collection<Adresa>();

            while (reader.Read())
            {
                Adresa adresa = new Adresa();
                adresa.Id_adresa = reader.GetInt32(0);
                adresa.Mesto = reader.GetString(1);
                adresa.Ulice = reader.GetString(2);
                adresa.Stat = reader.GetString(3);
                adresa.PSC = reader.GetString(4);
                adresa.Pocet_klientu = reader.GetInt32(5);

                adresy.Add(adresa);
            }
            return adresy;
        }
    }
}