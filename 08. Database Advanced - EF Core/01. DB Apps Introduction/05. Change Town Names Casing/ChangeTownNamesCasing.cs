using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _05.Change_Town_Names_Casing
{
    public class ChangeTownNamesCasing
    {
        public static void Main()
        {
            var countryName = Console.ReadLine();
            var sb = new StringBuilder();
            IList<string> townNames = new List<string>();

            SqlConnection connection = new SqlConnection(
                "Server=DESKTOP-M93T6SJ\\SQLEXPRESS; " +
                "Database=Minions; " +
                "Integrated Security=true");

            connection.Open();
            using (connection)
            {
                //Update
                string updateQuery = "UPDATE Towns " +
                                     "SET Name = UPPER(Name) " +
                                     "WHERE CountryId = (SELECT Id FROM Countries " +
                                     "WHERE Name = @countryName)";

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@countryName", countryName);
                var affectedRows = (int)updateCommand.ExecuteNonQuery();

                if (affectedRows != 0)
                {
                    sb.Append($"{affectedRows} town names were affected.");
                }
                else
                {
                    sb.Append("No town names were affected.");
                }

                //Select
                string selectQuery = "SELECT Name FROM Towns " +
                                     "WHERE CountryId = (SELECT Id FROM Countries WHERE Name = @countryName)";

                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@countryName", countryName);
                var reader = selectCommand.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        townNames.Add((string)reader["Name"]);
                    }
                }

                Console.WriteLine(sb);

                if (townNames.Count != 0)
                {
                    Console.WriteLine($"[{string.Join(", ", townNames)}]");
                }
            }
        }
    }
}
