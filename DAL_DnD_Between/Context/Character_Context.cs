using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD_Between
{
    public class Character_Context
    {
        private SqlConnection mssql = new SqlConnection("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi485841;Persist Security Info=True;User ID=dbi485841;Password=Duj7t6ySa1");

        public void AddCharacter(string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, int class_id, int race_id)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Character( [name],[strength],[dexterity],[constitution],[intelligence],[wisdom],[charisma],[level],[speed],[class_id],[race_id])" +
                "VALUES ( '" + name + "', '" + str + "', '" + dex + "','" + con + "','" + wis + "','" + intt + "','" + cha + "','" + level + "','" + speed + "','" + class_id + "','" + race_id + "')", mssql);

            try
            {
                mssql.Open();
                cmd.ExecuteNonQuery();
                mssql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteCharacter(int ID)
        {
            SqlCommand cmd = new SqlCommand("Delete from Character Where id =" + ID, mssql);

            try
            {
                mssql.Open();
                cmd.ExecuteNonQuery();
                mssql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public List<CharacterDTO> Getall()
        {
            List<CharacterDTO> CharacterDTOList = new List<CharacterDTO>();

            string query = "SELECT * FROM Character";
            SqlCommand commandDatabase = new SqlCommand(query, mssql);
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;

            try
            {
                mssql.Open();
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
                            class_id = reader.GetInt32(10),
                            race_id = reader.GetInt32(11)
                        };
                        CharacterDTOList.Add(items);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                mssql.Close();
            }
            catch (Exception ex)
            {
            }

            return CharacterDTOList;
        }

        public List<CharacterDTO> Getbyid(int id)
        {
            List<CharacterDTO> CharacterDtoList = new List<CharacterDTO>();

            string query = "SELECT * FROM Character WHERE id = " + id;
            SqlCommand commandDatabase = new SqlCommand(query);
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;

            try
            {
                mssql.Open();
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
                            class_id = reader.GetInt32(10),
                            race_id = reader.GetInt32(11)
                        };
                        CharacterDtoList.Add(items);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                mssql.Close();
            }
            catch (Exception ex)
            {
            }

            return CharacterDtoList;
        }
    }
}
