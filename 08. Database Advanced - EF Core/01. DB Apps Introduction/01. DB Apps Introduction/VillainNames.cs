using System;
using System.Data.SqlClient;

namespace _01.DB_Apps_Introduction
{
    public class VillainNames
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection(
                "Server=.\\SQLEXPRESS; " +
                "Database=Minions; " +
                "Integrated Security=true");

            connection.Open();
            using (connection)
            {
                string commandString = "SELECT v.Name, " +
                                       "COUNT(mv.MinionId) AS MinionsCount " +
                                       "FROM Villains AS v " +
                                       "LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                                       "GROUP BY v.Name HAVING COUNT(mv.MinionId) > 3 " +
                                       "ORDER BY COUNT(mv.MinionId) DESC";
                SqlCommand command = new SqlCommand(commandString, connection);

                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string villainName = (string)reader["Name"];
                        int minionsCount = (int)reader["MinionsCount"];
                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
            }
        }
    }
}
