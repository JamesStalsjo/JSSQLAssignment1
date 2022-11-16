using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JSSQLAssignment1
{
    internal class MySQLHandler
    {
        string connString = File.ReadAllText("C:\\Users\\james\\Desktop\\Campus Mölndal\\2 - ATK\\ConnectionString.txt");
        string sql = File.ReadAllText("C:\\Users\\james\\Desktop\\Campus Mölndal\\2 - ATK\\JSSQLAssignment1.sql");

        public void CreateTable()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("CREATE TABLE JSSQLAssignment1 (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, first_name VARCHAR(255), last_name VARCHAR(255), email VARCHAR(255), username VARCHAR(255), password VARCHAR(255), country VARCHAR(255))", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertData()
        {
            List<string> rows = File.ReadAllText("C:\\Users\\james\\Desktop\\Campus Mölndal\\2 - ATK\\JSSQLAssignment1.sql").Split(Environment.NewLine).ToList();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            
            foreach(string row in rows)
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            
        }

        public List<Person> NumberOfCountries(Person country)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT(country)) FROM JSSQLAssignment1", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("The number of unique countries represented is: " + reader.GetInt32("COUNT(DISTINCT(country))") + ".");
            }
            
            return null;
            
            conn.Close();
        }
        
        public List<Person> MostCommonCountry(Person country)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(country), country FROM JSSQLAssignment1 WHERE country = (SELECT MAX(country) FROM JSSQLAssignment1)", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("The most common country is: " + reader.GetString("country") + ", which occurs " + reader.GetInt32("COUNT(country)") + " times.");
                
            }

            return null;

            conn.Close();
        }
        
        public List<Person> UniqueUserAndPW(Person username, Person password)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT(username)), COUNT(DISTINCT(password)) FROM JSSQLAssignment1", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("The number of unique usernames is: " + reader.GetString("COUNT(DISTINCT(username))") + "\nThe number of unique passwords is: " + reader.GetString("COUNT(DISTINCT(password))") + ".");
            }

            return null;
            conn.Close();
        }
        
        public List<Person> NumberOfPplNordic(Person id)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(id) FROM JSSQLAssignment1 WHERE country IN('Sweden', 'Norway', 'Denmark', 'Finland', 'Iceland')", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("The number of people from the Nordic countries are: " + reader.GetInt32("COUNT(id)") + ".");
            }
            
            return null;

            conn.Close();
        }

        public List<Person> NumberOfPplScandinavia(Person id)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(id) FROM JSSQLAssignment1 WHERE country IN('Sweden', 'Norway', 'Denmark')", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine("The number of people from Scandinavia are: " + reader.GetInt32("COUNT(id)") + ".");
            }

            return null;

            conn.Close();
        }
        
        public List<Person> LastNameStartsWithLetter(Person lastname)
        { 
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            string input = Console.ReadLine().ToUpper();
                                    
            MySqlCommand cmd = new MySqlCommand($"SELECT last_name FROM JSSQLAssignment1 WHERE last_name LIKE ('{input}%') ORDER BY last_name LIMIT 0, 10", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString("last_name") + ".");
            }

            return null;
            conn.Close();
        }
        
        public List<Person> FirstAndLastNameStartsWithLetter()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            string input = Console.ReadLine().ToUpper();

            MySqlCommand cmd = new MySqlCommand($"SELECT first_name, last_name FROM JSSQLAssignment1 WHERE first_name LIKE ('{input}%') AND last_name LIKE ('{input}%')", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString("first_name") + " " + reader.GetString("last_name") + ".");
            }

            return null;
            conn.Close();
        }
       





    }
}
