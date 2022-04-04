using Interface_DnD_Between;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD_Between
{
    public class Character_Context : DB , ICharacter_Context
    {
        public void AddCharacter(CharacterDTO character)
        {
            string sqlCharacter = "INSERT INTO Character ([name],[strength],[dexterity],[constitution],[intelligence],[wisdom],[charisma],[level],[speed],[class_id],[race_id]) " +
                "VALUES (@name,@str,@dex,@con,@intt,@wis,@cha,@level,@speed,@class_id,@race_id)";

            using (SqlCommand characterCmd = new SqlCommand(sqlCharacter, Connection()))
            {
                characterCmd.Parameters.AddWithValue("@name", character.name);
                characterCmd.Parameters.AddWithValue("@str", character.str);
                characterCmd.Parameters.AddWithValue("@dex", character.dex);
                characterCmd.Parameters.AddWithValue("@con", character.con);
                characterCmd.Parameters.AddWithValue("@intt", character.intt);
                characterCmd.Parameters.AddWithValue("@wis", character.wis);
                characterCmd.Parameters.AddWithValue("@cha", character.cha);
                characterCmd.Parameters.AddWithValue("@level", character.level);
                characterCmd.Parameters.AddWithValue("@speed", character.speed);
                characterCmd.Parameters.AddWithValue("@class_id", character.char_class.ID);
                characterCmd.Parameters.AddWithValue("@race_id", character.char_race.ID);

                try
                {
                    Open();
                    characterCmd.ExecuteScalar();
                    Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteCharacter(int ID)
        {
            SqlCommand cmd = new SqlCommand("Delete from Character Where id =" + ID, Connection());

            try
            {
                Open();
                cmd.ExecuteNonQuery();
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<CharacterDTO> Getall()
        {
            List<CharacterDTO> CharacterDTOList = new List<CharacterDTO>();

            string query = "SELECT Character.*, Class.class, Race.race FROM Character JOIN Class on Character.class_id = Class.Id JOIN Race on Character.race_id = Race.id";
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
                        var items = new CharacterDTO()
                        {
                            ID = reader.GetInt32(0),
                            name = reader.GetString(1),
                            str = reader.GetInt32(2),
                            dex = reader.GetInt32(3),
                            con = reader.GetInt32(4),
                            intt = reader.GetInt32(5),
                            wis = reader.GetInt32(6),
                            cha = reader.GetInt32(7),
                            level = reader.GetInt32(8),
                            speed = reader.GetInt32(9),
                            char_class = new ClassDTO() { ID = reader.GetInt32(10), name = reader.GetString(12) },
                            char_race = new RaceDTO() { ID = reader.GetInt32(11), name = reader.GetString(13) }
                        };
                        CharacterDTOList.Add(items);
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

            return CharacterDTOList;
        }

        public List<CharacterDTO> Getbyid(int id)
        {
            List<CharacterDTO> CharacterDtoList = new List<CharacterDTO>();

            string query = "SELECT * FROM Character WHERE id = " + id;
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
                        var items = new CharacterDTO()
                        {
                            ID = reader.GetInt32(0),
                            name = reader.GetString(1),
                            str = reader.GetInt32(2),
                            dex = reader.GetInt32(3),
                            con = reader.GetInt32(4),
                            intt = reader.GetInt32(5),
                            wis = reader.GetInt32(6),
                            cha = reader.GetInt32(7),
                            level = reader.GetInt32(8),
                            speed = reader.GetInt32(9),
                            char_class = new ClassDTO() { ID = reader.GetInt32(10), name = reader.GetString(12) },
                            char_race = new RaceDTO() { ID = reader.GetInt32(11), name = reader.GetString(13) }
                        };
                        CharacterDtoList.Add(items);
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

            return CharacterDtoList;
        }
    }
}
