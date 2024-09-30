using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class databaseHandler
    {
        MySqlConnection connection;
        public databaseHandler()
        {
            //szerver címe
            string serverAddress = "localhost";
            string  username = "root";
            string password = "";
            string databaseName = "trabant";
            string connectionString = $"Server={serverAddress};Database={databaseName};User={username};Password={password}";
            connection = new MySqlConnection(connectionString);
        }
        public class car
        {
            public static  List<car> cars = new List<car>();
            public int id { get; set; }

            public string make { get; set; }
            public string model { get; set; }
            public string color { get; set; }
            public int year { get; set; }
            public int hp { get; set; }
        }
        public void readall()
        {
            try
            {
                connection.Open();
                string query = "select * from cars";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    car onecar = new car();
                    onecar.id = read.GetInt32(read.GetOrdinal("id"));
                    onecar.make = read.GetString(read.GetOrdinal("make"));
                    onecar.model = read.GetString(read.GetOrdinal("model"));
                    onecar.color = read.GetString(read.GetOrdinal("color"));
                    onecar.year = read.GetInt32(read.GetOrdinal("year"));
                    onecar.hp = read.GetInt32(read.GetOrdinal("power"));
                    car.cars.Add(onecar);
                }
                read.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("A hiba: " + e.Message);
            }
        }
    }
}
