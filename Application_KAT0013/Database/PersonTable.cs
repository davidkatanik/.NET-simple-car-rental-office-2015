using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Application_KAT0013.Database
{
    public class PersonTable
    {
        public static String TABLE_NAME = "Person";

        public String SQL_SELECT = "SELECT * FROM Person";
        public String SQL_SELECT_ID = "SELECT * FROM Person WHERE id=@id";
        public String SQL_INSERT = "INSERT INTO Person VALUES (@id, @login, @name, @surname, @address, @telephone," +
            "@maximum_unfinisfed_auctions, @last_visit, @type)";
        public String SQL_DELETE_ID = "DELETE FROM Person WHERE id=@id";
        public String SQL_UPDATE = "UPDATE Person SET login=@login, name=@name, surname=@surname," +
            "address=@address, telephone=@telephone, maximum_unfinisfed_auctions=@maximum_unfinisfed_auctions," +
            "last_visit=@last_visit, type=@type WHERE id=@id";

        public PersonTable()
        {
        }

        /**
         * Insert the record.
         **/
        public int Insert(Person person)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, person);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Update the record.
         **/
        public int Update(Person person)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, person);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, Person person)
        {
            command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            command.Parameters["@id"].Value = person.Id;

            command.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, person.Login.Length));
            command.Parameters["@login"].Value = person.Login;

            command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, person.Name.Length));
            command.Parameters["@name"].Value = person.Name;

            command.Parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar, person.Surname.Length));
            command.Parameters["@surname"].Value = person.Surname;

            command.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, person.Address.Length));
            command.Parameters["@address"].Value = person.Address;

            command.Parameters.Add(new SqlParameter("@telephone", SqlDbType.VarChar, person.Telephone.Length));
            command.Parameters["@telephone"].Value = person.Telephone;

            command.Parameters.Add(new SqlParameter("@maximum_unfinisfed_auctions", SqlDbType.Int));
            command.Parameters["@maximum_unfinisfed_auctions"].Value = person.MaximumUnfinisfedAuctions;

            command.Parameters.Add(new SqlParameter("@last_visit", SqlDbType.DateTime));
            command.Parameters["@last_visit"].Value = person.LastVisit;

            command.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar, person.Type.Length));
            command.Parameters["@type"].Value = person.Type;
        }

        /**
         * Select records.
         **/
        public Collection<Person> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Person> persons = Read(reader);
            reader.Close();
            db.Close();
            return persons;
        }

        /**
         * Select the record.
         **/
        public Person Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            command.Parameters["@id"].Value = id;
            SqlDataReader reader = db.Select(command);

            Collection<Person> persons = Read(reader);
            Person person = null;
            if (persons.Count == 1)
            {
                person = persons[0];
            }
            reader.Close();
            db.Close();
            return person;
        }

        private Collection<Person> Read(SqlDataReader reader)
        {
            Collection<Person> persons = new Collection<Person>();

            while (reader.Read())
            {
                Person person = new Person();
                person.Id = reader.GetInt32(0);
                person.Login = reader.GetString(1);
                person.Name = reader.GetString(2);
                person.Surname = reader.GetString(3);
                person.Address = reader.GetString(4);
                person.Telephone = reader.GetString(5);
                person.MaximumUnfinisfedAuctions = reader.GetInt32(6);
                if (!reader.IsDBNull(7))
                {
                    person.LastVisit = reader.GetDateTime(7);
                }
                person.Type = reader.GetString(8);

                persons.Add(person);
            }
            return persons;
        }

        /**
         * Delete the record.
         */
        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            command.Parameters["@id"].Value = id;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
    }
}