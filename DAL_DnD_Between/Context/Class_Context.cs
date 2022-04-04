using Interface_DnD_Between;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD_Between
{
    public class Class_Context : DB, IClass_Context
    {
        public List<ClassDTO> Getall()
        {
            List<ClassDTO> ClassDTOList = new List<ClassDTO>();

            string query = "SELECT * FROM Class";
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
                        var items = new ClassDTO()
                        {
                            ID = reader.GetInt32(0),
                            name = reader.GetString(1),

                        };
                        ClassDTOList.Add(items);
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

            return ClassDTOList;
        }
    }
}
