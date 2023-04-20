using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        public static string connStr = "Data Source=localhost;Initial Catalog=db_videogames;Integrated Security=True";

        public static void AddGame(Videogame videogame)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "INSERT INTO videogames (name, overview, release_date, software_house_id) " +
                                "VALUES ('@Name', '@Overview', '@ReleaseDate', '@SoftwareHouseId')";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", videogame.Name);
                    cmd.Parameters.AddWithValue("@Overview", videogame.Overview);
                    cmd.Parameters.AddWithValue("@ReleaseDate", videogame.ReleaseDate);
                    cmd.Parameters.AddWithValue("@SoftwareHouseId", videogame.SoftwareHouseId);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Videogioco inserito");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public static Videogame SearchById(long id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE id = @Id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var name = reader.GetString(1);
                        var overview = reader.GetString(2);
                        var releaseDate = reader.GetDateTime(3);
                        var softwareHouseId = reader.GetInt64(4);

                        Videogame videogame = new Videogame(name, overview, releaseDate, softwareHouseId);
                        return videogame;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        public static List<Videogame> SearchByName(string Name)
        {
            List<Videogame> videogamesList = new List<Videogame>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE name = @Name";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", Name);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var name = reader.GetString(1);
                        var overview = reader.GetString(2);
                        var releaseDate = reader.GetDateTime(3);
                        var softwareHouseId = reader.GetInt64(4);

                        Videogame videogame = new Videogame(name, overview, releaseDate, softwareHouseId);

                        videogamesList.Add(videogame);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return videogamesList;
        }


        public static bool DeleteGame(long id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "DELETE FROM videogames WHERE id = @Id";
                    var cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static string ListToString(List<Videogame> videogamesList)
        {
            if (videogamesList.Count == 0)
                return "Non ci sono videogiochi corrispondenti!";

            string risultato = string.Empty;

            int index = 1;

            foreach (Videogame videogame in videogamesList)
            {
                risultato += $"\r\n\t{videogame.ToString()}";
                index++;
            }

            return risultato;
        }
    }
}

