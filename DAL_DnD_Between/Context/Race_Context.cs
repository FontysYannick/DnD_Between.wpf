using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD_Between
{
    public class Race_Context : DB
    {
        public List<RaceDTO> Getall()
        {
            List<RaceDTO> RaceDTOlist = new List<RaceDTO>();

            string query = "SELECT * FROM Race";
            SqlCommand commandDatabase = new SqlCommand(query, Connection());
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;

            try
            {
                Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var items = new RaceDTO()
                        {
                            ID = reader.GetInt32(0),
                            name = reader.GetString(1),

                        };
                        RaceDTOlist.Add(items);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RaceDTOlist;
        }
    }
}
