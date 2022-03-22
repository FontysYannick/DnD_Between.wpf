using System.Data.SqlClient;

namespace DnD_Between.wpf
{
    public class Class
    {
        private readonly character character;
        private SqlConnection mssql = new SqlConnection("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi485841;Persist Security Info=True;User ID=dbi485841;Password=Duj7t6ySa1");

        public Class(character character)
        {
            this.character = character;
        }

        public void fillcmbclass()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Class", mssql);
            mssql.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                character.CMBClass.Items.Add(sqlReader["class"].ToString());
            }

            sqlReader.Close();
        }
    }
}
