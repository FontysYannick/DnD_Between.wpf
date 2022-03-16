using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Between.wpf
{
    public class Race
    {
        private readonly character character;
        private SqlConnection mssql = new SqlConnection("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi485841;Persist Security Info=True;User ID=dbi485841;Password=Duj7t6ySa1");

        public Race(character character)
        {
            this.character = character;
        }

        public void fillcmbrace()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Race", mssql);
            mssql.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                character.CMBRace.Items.Add(sqlReader["race"].ToString());
            }

            sqlReader.Close();
        }
    }
}
