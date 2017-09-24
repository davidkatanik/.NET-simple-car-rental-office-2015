using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Application_KAT0013.Database
{
    public class ZamestnanecTable
    {
        public static String TABLE_NAME = "Zamestnanec";

        public String SQL_SELECT = "SELECT * FROM " + TABLE_NAME + " z, " + AdresaTable.TABLE_NAME + " a, "+OddeleniTable.TABLE_NAME+
            " o WHERE z.id_adresa = a.id_adresa AND z.id_oddeleni = o.id_oddeleni";
        public String SQL_SELECT_ID = "SELECT * FROM " + TABLE_NAME + " z, " + AdresaTable.TABLE_NAME + " a, "+OddeleniTable.TABLE_NAME+ 
                            " o WHERE id_zamestnanec=@id_zamestnanec AND z.id_adresa = a.id_adresa AND z.id_oddeleni = o.id_oddeleni";


        public String SQL_INSERT = "INSERT INTO " + TABLE_NAME + " VALUES (@jmeno, @prijmeni, @typ, @rc, @telefon, @email," +
            "@datum_nastupu,@datum_do,@pohybliva_mzda,@zakladni_mzda, @id_adresa, @id_oddeleni)";
        public String SQL_UPDATE = "UPDATE " + TABLE_NAME + " SET jmeno=@jmeno, prijmeni=@prijmeni, typ=@typ," +
            "rc=@rc, telefon=@telefon, email=@email, datum_nastupu=@datum_nastupu, datum_do=@datum_do,"+
            " id_adresa=@id_adresa, id_oddeleni=@id_oddeleni WHERE id_zamestnanec=@id_zamestnanec";

        //ZMENA MZDY - HOTOVO POMOCI TRIGGERU
        //INFORMACE O ZAMESTNANCI  - hotovo
        //ZMENA ODDELENI (prepsani zakladniho platu + zapsani historie) - HOTOVO POMOCI TRIGGERU


        public ZamestnanecTable()
        {
        }
        public int Insert(Zamestnanec zamestnanec)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, zamestnanec);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Update the record.
         **/
        public int Update(Zamestnanec zamestnanec)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zamestnanec);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, Zamestnanec zamestnanec)
        {
            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = zamestnanec.Id_zamestnanec;

            command.Parameters.Add(new SqlParameter("@jmeno", SqlDbType.VarChar, zamestnanec.Jmeno.Length));
            command.Parameters["@jmeno"].Value = zamestnanec.Jmeno;

            command.Parameters.Add(new SqlParameter("@prijmeni", SqlDbType.VarChar, zamestnanec.Prijmeni.Length));
            command.Parameters["@prijmeni"].Value = zamestnanec.Prijmeni;
            
            command.Parameters.Add(new SqlParameter("@typ", SqlDbType.Char,Zamestnanec.LEN_ATTR_typ));
            command.Parameters["@typ"].Value = zamestnanec.Typ;

            command.Parameters.Add(new SqlParameter("@rc", SqlDbType.VarChar, zamestnanec.RC.Length));
            command.Parameters["@rc"].Value = zamestnanec.RC;

            command.Parameters.Add(new SqlParameter("@telefon", SqlDbType.VarChar, zamestnanec.Telefon.Length));
            command.Parameters["@telefon"].Value = zamestnanec.Telefon;

            command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, zamestnanec.Email.Length));
            command.Parameters["@email"].Value = zamestnanec.Email;

            command.Parameters.Add(new SqlParameter("@datum_nastupu", SqlDbType.Date));
            command.Parameters["@datum_nastupu"].Value = zamestnanec.Datum_nastupu;

            command.Parameters.Add(new SqlParameter("@datum_do", SqlDbType.Date));
            command.Parameters["@datum_do"].Value = zamestnanec.Datum_do;

            command.Parameters.Add(new SqlParameter("@pohybliva_mzda", SqlDbType.Int));
            command.Parameters["@pohybliva_mzda"].Value = zamestnanec.Pohybliva_mzda;

            command.Parameters.Add(new SqlParameter("@zakladni_mzda", SqlDbType.Int));
            command.Parameters["@zakladni_mzda"].Value = zamestnanec.Zakladni_mzda;

            command.Parameters.Add(new SqlParameter("@id_adresa", SqlDbType.Int));
            command.Parameters["@id_adresa"].Value = zamestnanec.Id_adresa.Id_adresa;

            command.Parameters.Add(new SqlParameter("@id_oddeleni", SqlDbType.Int));
            command.Parameters["@id_oddeleni"].Value = zamestnanec.Id_oddeleni.Id_oddeleni;

        }

        /**
         * Select records.
         **/
        public Collection<Zamestnanec> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader, false);
            reader.Close();
            db.Close();
            return zamestnanci;
        }

        /**
         * Select the record.
         **/
        public Zamestnanec Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = id;
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader, false);
            Zamestnanec zamestnanec = null;
            if (zamestnanci.Count == 1)
            {
                zamestnanec = zamestnanci[0];
            }
            reader.Close();
            db.Close();
            return zamestnanec;
        }
        public Zamestnanec SelectComplete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id_zamestnanec", SqlDbType.Int));
            command.Parameters["@id_zamestnanec"].Value = id;
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader, true);
            Zamestnanec zamestnanec = null;
            if (zamestnanci.Count == 1)
            {
                zamestnanec = zamestnanci[0];
            }
            reader.Close();
            db.Close();
            return zamestnanec;
        }

        private Collection<Zamestnanec> Read(SqlDataReader reader, bool complete)
        {
            Collection<Zamestnanec> zamestnanci = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.Id_zamestnanec = reader.GetInt32(0);
                zamestnanec.Jmeno = reader.GetString(1);
                zamestnanec.Prijmeni = reader.GetString(2);
                zamestnanec.Typ = reader.GetString(3)[0];
                zamestnanec.RC = reader.GetString(4);
                zamestnanec.Telefon = reader.GetString(5);
                zamestnanec.Email = reader.GetString(6);
                zamestnanec.Datum_nastupu = reader.GetDateTime(7);
                if (!reader.IsDBNull(8))
                {
                    zamestnanec.Datum_do = reader.GetDateTime(8);
                }
                zamestnanec.Pohybliva_mzda = reader.GetInt32(9);
                zamestnanec.Zakladni_mzda = reader.GetInt32(10);
                zamestnanec.Id_adresa = new Adresa();
                zamestnanec.Id_adresa.Id_adresa = reader.GetInt32(11);
                zamestnanec.Id_oddeleni = new Oddeleni();
                zamestnanec.Id_oddeleni.Id_oddeleni = reader.GetInt32(12);
                //Kdyby jsme potrebovali konkretni adresu a oddeleni k zamestnanci
                //Vetsinou nam budou stacit ID
                if (complete) {
                    //13 je zase id adresa
                    zamestnanec.Id_adresa.Mesto = reader.GetString(14);
                    zamestnanec.Id_adresa.Ulice = reader.GetString(15);
                    zamestnanec.Id_adresa.Stat = reader.GetString(16);
                    zamestnanec.Id_adresa.PSC = reader.GetString(17);
                    zamestnanec.Id_adresa.Pocet_klientu = reader.GetInt32(18);
                    //19 zase id oddeleni
                    zamestnanec.Id_oddeleni.Nazev = reader.GetString(20);
                    zamestnanec.Id_oddeleni.Zakladni_mzda = reader.GetInt32(21);
                }

                zamestnanci.Add(zamestnanec);
            }
            return zamestnanci;
        }
        public void SouhrnZamestnance(int id_zamestnance)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand cmd = db.CreateCommand("souhrnZamestnance");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@p_id_zamestnanec", SqlDbType.Int);
            parm.Value = id_zamestnance;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            int ret = db.ExecuteNonQuery(cmd);

            db.Close();
        }
    }
}