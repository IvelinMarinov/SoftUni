using System;
using System.Data.SqlClient;
using System.Text;

namespace _03.Minion_Names
{
    public class MinionNames
    {
        public static void Main()
        {
            var villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(
                "Server=.\\SQLEXPRESS; " +
                "Database=Minions; " +
                "Integrated Security=true");

            connection.Open();
            using (connection)
            {
                string checkIfVillainExistsQuery = $"SELECT COUNT(*) " +
                                                   $"FROM Villains " +
                                                   $"WHERE Id = @villainId";

                SqlCommand checkIfVillainExistsCommand = new SqlCommand(checkIfVillainExistsQuery, connection);
                checkIfVillainExistsCommand.Parameters.AddWithValue("@villainId", villainId);
                var villainCount = (int)checkIfVillainExistsCommand.ExecuteScalar();

                if (villainCount == 0)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                string getMinionsQuery = "SELECT v.Name AS vName, m.Name AS mName, m.Age FROM Minions AS m " +
                                         "JOIN MinionsVillains AS mv ON m.Id = mv.MinionId " +
                                         "JOIN Villains AS v ON mv.VillainId = v.Id " +
                                         $"WHERE v.Id = @villainId";
                
                SqlCommand getMinionsCommand = new SqlCommand(getMinionsQuery, connection);
                getMinionsCommand.Parameters.AddWithValue("@villainId", villainId);

                SqlDataReader reader = getMinionsCommand.ExecuteReader();
                var villainName = string.Empty;
                var minionName = string.Empty;
                var minionAge = default(int);
                var minionCounter = 1;
                var result = new StringBuilder();

                using (reader)
                {
                    while (reader.Read())
                    {
                        villainName = (string)reader["vName"];
                        minionName = (string)reader["mName"];
                        minionAge = (int) reader["Age"];
                        result.AppendLine($"{minionCounter}. {minionName} {minionAge}");
                    }
                }

                if (result.Length == 0)
                {
                    result.AppendLine("(no minions)");
                }

                Console.WriteLine($"Villain: {villainName}");
                Console.WriteLine(result.ToString().Trim());
            }
        }
    }
}
