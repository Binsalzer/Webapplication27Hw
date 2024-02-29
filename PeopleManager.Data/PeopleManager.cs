using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication27.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class PeopleManager
    {
        private string _connection;
        public PeopleManager(string connection)
        {
            _connection = connection;
        }

        public List<Person> GetAllPeople()
        {
            var con = new SqlConnection(_connection);
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            con.Open();
            List<Person> people = new();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new()
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }

        public void AddPerson(Person person)
        {
            var con = new SqlConnection(_connection);
            var cmd = con.CreateCommand();
            cmd.CommandText = @"INSERT INTO People
                                VALUES (@firstName , @lastName, @age)";

            cmd.Parameters.AddWithValue("@firstName", person.FirstName);
            cmd.Parameters.AddWithValue("@lastName", person.LastName);
            cmd.Parameters.AddWithValue("@age", person.Age);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddMultiplePeople(List<Person> people)
        {
            foreach(Person p in people)
            {
                AddPerson(p);
            }
        }
    }
}
