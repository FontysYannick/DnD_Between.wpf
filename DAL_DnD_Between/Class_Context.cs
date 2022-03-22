using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD_Between
{
    public class Class_Context
    {
        private SqlConnection mssql = new SqlConnection("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi485841;Persist Security Info=True;User ID=dbi485841;Password=Duj7t6ySa1");

        public List<ClassDTO> Getall()
        {
            List<ClassDTO> ClassDTOList = new List<ClassDTO>();

            string query = "SELECT * FROM Class";
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
                mssql.Close();
            }
            catch (Exception ex)
            {
            }

            return ClassDTOList;
        }
    }
}
