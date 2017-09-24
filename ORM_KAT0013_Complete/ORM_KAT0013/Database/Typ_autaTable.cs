using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ORM_KAT0013.Database
{
    public class Typ_autaTable
    {
        public static String TABLE_NAME = "Typ_auta";

        public String SQL_SELECT = "SELECT * FROM "+TABLE_NAME;
        public String SQL_SELECT_ID = "SELECT * FROM "+TABLE_NAME+" WHERE id_typ_auta=@id_typ_auta";
        public String SQL_INSERT = "INSERT INTO " + TABLE_NAME + " VALUES (@znacka, @model)";
        public String SQL_UPDATE = "UPDATE " + TABLE_NAME + " SET znacka=@znacka, model=@model WHERE id_typ_auta=@id_typ_auta";

        public Typ_autaTable()
        {
        }

        /**
         * Insert the record.
         **/
        public int Insert(Typ_auta typ_auta)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, typ_auta);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Update the record.
         **/
        public int Update(Typ_auta typ_auta)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, typ_auta);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, Typ_auta typ_auta)
        {
            command.Parameters.Add(new SqlParameter("@id_typ_auta", SqlDbType.Int));
            command.Parameters["@id_typ_auta"].Value = typ_auta.Id_typ_auta;

            command.Parameters.Add(new SqlParameter("@znacka", SqlDbType.VarChar, typ_auta.Znacka.Length));
            command.Parameters["@znacka"].Value = typ_auta.Znacka;

            command.Parameters.Add(new SqlParameter("@model", SqlDbType.VarChar, typ_auta.Model.Length));
            command.Parameters["@model"].Value = typ_auta.Model;
        }

        /**
         * Select records.
         **/
        public Collection<Typ_auta> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Typ_auta> typy_aut = Read(reader);
            reader.Close();
            db.Close();
            return typy_aut;
        }

        /**
         * Select the record.
         **/
        public Typ_auta Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id_typ_auta", SqlDbType.Int));
            command.Parameters["@id_typ_auta"].Value = id;
            SqlDataReader reader = db.Select(command);

            Collection<Typ_auta> typy_aut = Read(reader);
            Typ_auta typ_auta = null;
            if (typy_aut.Count == 1)
            {
                typ_auta = typy_aut[0];
            }
            reader.Close();
            db.Close();
            return typ_auta;
        }

        public Collection<Typ_auta> Read(SqlDataReader reader)
        {
            Collection<Typ_auta> typy_aut = new Collection<Typ_auta>();

            while (reader.Read())
            {
                Typ_auta typ_auta = new Typ_auta();
                typ_auta.Id_typ_auta = reader.GetInt32(0);
                typ_auta.Znacka = reader.GetString(1);
                typ_auta.Model = reader.GetString(2);

                typy_aut.Add(typ_auta);
            }
            return typy_aut;
        }
    }
}