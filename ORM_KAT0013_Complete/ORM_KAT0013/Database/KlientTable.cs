using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.ObjectModel;

namespace ORM_KAT0013.Database
{
    public class KlientTable
    {
        public static String TABLE_NAME = "Klient";

        public String SQL_SELECT =      "SELECT * FROM "+TABLE_NAME+" k JOIN "+AdresaTable.TABLE_NAME+" a ON (k.id_adresa = a.id_adresa) ";
        public String SQL_SELECT_ID = "SELECT * FROM " + TABLE_NAME + " k JOIN " + AdresaTable.TABLE_NAME + " a ON (k.id_adresa = a.id_adresa)  WHERE k.id_klient=@id_klient";
        public String SQL_SELECT_JMENO = "SELECT * FROM " + TABLE_NAME + " k JOIN " + AdresaTable.TABLE_NAME + " a ON (k.id_adresa = a.id_adresa)  WHERE k.jmeno=@jmeno";
        public String SQL_SELECT_RC = "SELECT * FROM " + TABLE_NAME + " k JOIN " + AdresaTable.TABLE_NAME + " a ON (k.id_adresa = a.id_adresa)  WHERE k.rc=@rc";
        public String SQL_SELECT_PRIJMENI = "SELECT * FROM " + TABLE_NAME + " k JOIN " + AdresaTable.TABLE_NAME + " a ON (k.id_adresa = a.id_adresa)  WHERE k.prijmeni=@prijmeni";
        public String SQL_SELECT_ID_ADRESA = "SELECT * FROM " + TABLE_NAME + " k JOIN " + AdresaTable.TABLE_NAME + " a ON (k.id_adresa = a.id_adresa)  WHERE k.id_adresa=@id_adresa";
        public String SQL_INSERT =      "INSERT INTO "+TABLE_NAME+" VALUES (@jmeno, @prijmeni, @rc, @telefon, @email, @id_adresa)";
        public String SQL_UPDATE =      "UPDATE " + TABLE_NAME + " SET jmeno=@jmeno, prijmeni=@prijmeni, rc=@rc,"+
                                        "telefon=@telefon,email=@email WHERE id_klient=@id_klient";

        //SMAZANI KLIENTA - HOTOVO

        //TISKNUTELNA SESTAVA PRO KLIENTA - HOTOVO
        //AKTUALIZACE ADRESY KLIENTA  - HOTOVO

        public KlientTable()
        {
        }
        public int Insert(Klient klient)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, klient);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }
        public int Update(Klient klient)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, klient);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, Klient klient)
        {
            command.Parameters.Add(new SqlParameter("@id_klient", SqlDbType.Int));
            command.Parameters["@id_klient"].Value = klient.Id_klient;

            command.Parameters.Add(new SqlParameter("@jmeno", SqlDbType.VarChar, klient.Jmeno.Length));
            command.Parameters["@jmeno"].Value = klient.Jmeno;

            command.Parameters.Add(new SqlParameter("@prijmeni", SqlDbType.VarChar, klient.Prijmeni.Length));
            command.Parameters["@prijmeni"].Value = klient.Prijmeni;

            command.Parameters.Add(new SqlParameter("@rc", SqlDbType.Char, klient.RC.Length));
            command.Parameters["@rc"].Value = klient.RC;

            command.Parameters.Add(new SqlParameter("@telefon", SqlDbType.Char, klient.Telefon.Length));
            command.Parameters["@telefon"].Value = klient.Telefon;

            command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, klient.Email.Length));
            command.Parameters["@email"].Value = klient.Email;

            command.Parameters.Add(new SqlParameter("@id_adresa", SqlDbType.Int));
            command.Parameters["@id_adresa"].Value = klient.Adresa.Id_adresa;
        }
        public Collection<Klient> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader,false);
            reader.Close();
            db.Close();
            return klienti;
        }

        public Collection<Klient> SelectJmeno(String jmeno)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_JMENO);
            command.Parameters.Add(new SqlParameter("@jmeno", SqlDbType.Char, Klient.LEN_ATTR_jmeno));
            command.Parameters["@jmeno"].Value = jmeno;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader,false);
            reader.Close();
            db.Close();
            return klienti;
        }
        public Collection<Klient> SelectJmenoComplete(String jmeno)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_JMENO);
            command.Parameters.Add(new SqlParameter("@jmeno", SqlDbType.Char, Klient.LEN_ATTR_jmeno));
            command.Parameters["@jmeno"].Value = jmeno;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader, true);
            reader.Close();
            db.Close();
            return klienti;
        }
        public Collection<Klient> SelectRC(String rc)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_RC);
            command.Parameters.Add(new SqlParameter("@rc", SqlDbType.Char, Klient.LEN_ATTR_rc));
            command.Parameters["@rc"].Value = rc;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader, false);
            reader.Close();
            db.Close();
            return klienti;
        }
        public Collection<Klient> SelectRCComplete(String rc)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_RC);
            command.Parameters.Add(new SqlParameter("@rc", SqlDbType.Char, Klient.LEN_ATTR_rc));
            command.Parameters["@rc"].Value = rc;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader, true);
            reader.Close();
            db.Close();
            return klienti;
        }
        public Collection<Klient> SelectPrijmeni(String prijmeni)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_PRIJMENI);
            command.Parameters.Add(new SqlParameter("@prijmeni", SqlDbType.Char, Klient.LEN_ATTR_prijmeni));
            command.Parameters["@prijmeni"].Value = prijmeni;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader,false);
            reader.Close();
            db.Close();
            return klienti;
        }
        public Collection<Klient> SelectPrijmeniComplete(String prijmeni)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_PRIJMENI);
            command.Parameters.Add(new SqlParameter("@prijmeni", SqlDbType.Char, Klient.LEN_ATTR_prijmeni));
            command.Parameters["@prijmeni"].Value = prijmeni;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader, true);
            reader.Close();
            db.Close();
            return klienti;
        }
        public Collection<Klient> SelectIdAdresa(int id)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID_ADRESA);
            command.Parameters.Add(new SqlParameter("@id_adresa", SqlDbType.Int));
            command.Parameters["@id_adresa"].Value = id;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader,false);
            reader.Close();
            db.Close();
            return klienti;
        }
        public Collection<Klient> SelectIdAdresaComplete(int id)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID_ADRESA);
            command.Parameters.Add(new SqlParameter("@id_adresa", SqlDbType.Int));
            command.Parameters["@id_adresa"].Value = id;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader, true);
            reader.Close();
            db.Close();
            return klienti;
        }
        public Klient Select(int id_klient)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id_klient", SqlDbType.Int));
            command.Parameters["@id_klient"].Value = id_klient;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader,false);
            Klient klient = null;
            if (klienti.Count == 1)
            {
                klient = klienti[0];
            }
            reader.Close();
            db.Close();
            return klient;
        }
        public Klient SelectComplete(int id_klient)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id_klient", SqlDbType.Int));
            command.Parameters["@id_klient"].Value = id_klient;
            SqlDataReader reader = db.Select(command);

            Collection<Klient> klienti = Read(reader, true);
            Klient klient = null;
            if (klienti.Count == 1)
            {
                klient = klienti[0];
            }
            reader.Close();
            db.Close();
            return klient;
        }
        private Collection<Klient> Read(SqlDataReader reader, bool complete)
        {
            Collection<Klient> klienti = new Collection<Klient>();

            while (reader.Read())
            {
                Klient klient = new Klient();
                klient.Id_klient = reader.GetInt32(0);
                klient.Jmeno = reader.GetString(1);
                klient.Prijmeni = reader.GetString(2);
                klient.RC = reader.GetString(3);
                klient.Telefon = reader.GetString(4);
                klient.Email = reader.GetString(5);
                klient.Adresa = new Adresa();
                klient.Adresa.Id_adresa = reader.GetInt32(6);
                //7 je zase id adresa

                //Kdybych nahodou potreboval vyselektovat i konkretni adresu
                //Vetsinou ale budu potrebovat jenom ID adresy
                if (complete)
                {
                    klient.Adresa.Mesto = reader.GetString(8);
                    klient.Adresa.Ulice = reader.GetString(9);
                    klient.Adresa.Stat = reader.GetString(10);
                    klient.Adresa.PSC = reader.GetString(11);
                    klient.Adresa.Pocet_klientu = reader.GetInt32(12);
                }


                klienti.Add(klient);
            }
            return klienti;
        }
        public void TiskKlienta(int id_klient)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand cmd = db.CreateCommand("tiskKlienta");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@p_id_klient", SqlDbType.Int);
            parm.Value = id_klient;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            int ret = db.ExecuteNonQuery(cmd);

            db.Close();
        }
        public void SmazKlienta(int id_klient)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand cmd = db.CreateCommand("smazKlienta");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@p_id_klient", SqlDbType.Int);
            parm.Value = id_klient;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            int ret = db.ExecuteNonQuery(cmd);

            db.Close();
        }
        public void AktualizaceAdresy(int id_klient, String mesto, String ulice, String stat, String psc)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand cmd = db.CreateCommand("citacAdres");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@p_id_klient", SqlDbType.Int);
            parm.Value = id_klient;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            SqlParameter parm2 = new SqlParameter("@p_mesto", SqlDbType.VarChar, Adresa.LEN_ATTR_mesto);
            parm2.Value = mesto;
            parm2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm2);

            SqlParameter parm3 = new SqlParameter("@p_ulice", SqlDbType.VarChar, Adresa.LEN_ATTR_ulice);
            parm3.Value = ulice;
            parm3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm3);

            SqlParameter parm4 = new SqlParameter("@p_stat", SqlDbType.Char, Adresa.LEN_ATTR_stat);
            parm4.Value = stat;
            parm4.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm4);

            SqlParameter parm5 = new SqlParameter("@p_PSC", SqlDbType.Char, Adresa.LEN_ATTR_psc);
            parm5.Value = psc;
            parm5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm5);

            int ret = db.ExecuteNonQuery(cmd);

            db.Close();
        }
    }
}