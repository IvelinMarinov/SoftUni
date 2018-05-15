using System;
using System.Data.SqlClient;

namespace _04.Add_Minion
{
    public class AddMinion
    {
        public static void Main()
        {
            var minionArgs = Console.ReadLine().Split();
            var villainArgs = Console.ReadLine().Split();

            var minionName = minionArgs[1];
            var minionAge = int.Parse(minionArgs[2]);
            var minionTown = minionArgs[3];
            var villainName = villainArgs[1];

            SqlConnection connection = new SqlConnection(
                "Server=.\\SQLEXPRESS; " +
                "Database=Minions; " +
                "Integrated Security=true");

            connection.Open();
            using (connection)
            {
                //Check if town exists and insert
                string checkTownQuery = $"SELECT COUNT(*) " +
                                        $"FROM Towns " +
                                        $"WHERE Name = @townName";

                SqlCommand checkTownCommand = new SqlCommand(checkTownQuery, connection);
                checkTownCommand.Parameters.AddWithValue("@townName", minionTown);
                var townsCount = (int)checkTownCommand.ExecuteScalar();

                if (townsCount == 0)
                {
                    string insertTownQuery = "INSERT INTO Towns(Name, CountryId) " +
                                             "VALUES(@townName, 1)";

                    SqlCommand insertTownCommand = new SqlCommand(insertTownQuery, connection);
                    insertTownCommand.Parameters.AddWithValue("@townName", minionTown);
                    insertTownCommand.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                //Check if villain exists and insert
                string checkVillainQuery = "SELECT COUNT(*) " +
                                           "FROM Towns " +
                                           "WHERE Name = @villainName";

                SqlCommand checkVillainCommand = new SqlCommand(checkVillainQuery, connection);
                checkVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                var villainsCount = (int)checkVillainCommand.ExecuteScalar();

                if (villainsCount == 0)
                {
                    string insertVillainQuery = "INSERT INTO Villains(Name, EvilnessFactorId) " +
                                                "VALUES(@villainName, 4)";

                    SqlCommand insertVillainCommand = new SqlCommand(insertVillainQuery, connection);
                    insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                    insertVillainCommand.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                //Get TownId
                string getTownIdQuery = "SELECT Id " +
                                        "FROM Towns " +
                                        "WHERE Name = @townName";

                SqlCommand getTownIdCommand = new SqlCommand(getTownIdQuery, connection);
                getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);
                int townId = (int)getTownIdCommand.ExecuteScalar();

                //Get VillainId
                string getVillainIdQuery = "SELECT Id " +
                                           "FROM Villains WHERE Name = @villainName";

                SqlCommand getVillainIdCommand = new SqlCommand(getVillainIdQuery, connection);
                getVillainIdCommand.Parameters.AddWithValue("@villainName", villainName);
                int villainId = (int) getVillainIdCommand.ExecuteScalar();
                
                //Insert Minion
                string insertMinionQuery = "INSERT INTO Minions(Name, Age, TownId) " +
                                           "VALUES(@minionName, @age, @townId)";

                SqlCommand insertMinionCommand = new SqlCommand(insertMinionQuery, connection);
                insertMinionCommand.Parameters.AddWithValue("@minionName", minionName);
                insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
                insertMinionCommand.Parameters.AddWithValue("@townId", townId);
                insertMinionCommand.ExecuteNonQuery();

                //Get MinionId
                string getMinionIdQuery = "SELECT Id " +
                                          "FROM Minions " +
                                          "WHERE Name = @minionName";

                SqlCommand getMinionIdCommand = new SqlCommand(getMinionIdQuery, connection);
                getMinionIdCommand.Parameters.AddWithValue("@minionName", minionName);
                var minionId = getMinionIdCommand.ExecuteScalar();

                //Insert into mapping table
                string insertMappingTableQuery = "INSERT INTO MinionsVillains(MinionId, VillainId) " +
                                                 "VALUES(@minionId, @villainId)";

                SqlCommand insertMappingTableCommand = new SqlCommand(insertMappingTableQuery, connection);
                insertMappingTableCommand.Parameters.AddWithValue("@minionId", minionId);
                insertMappingTableCommand.Parameters.AddWithValue("@villainId", villainId);
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
