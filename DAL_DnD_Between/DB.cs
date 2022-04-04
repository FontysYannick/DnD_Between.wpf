using System.Data.SqlClient;

namespace DAL_DnD_Between
{
    public abstract class DB
    {
        private SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi485841;Persist Security Info=True;User ID=dbi485841;Password=Duj7t6ySa1");

        public SqlConnection Connection()
        {
            return con;
        }
        public bool Open()
        {
            bool succes;
            try
            {
                con.Open();
                succes = true;
            }
            catch
            {
                succes = false;
            }
            return succes;
        }

        public bool Close()
        {
            bool succes;
            try
            {
                con.Close();
                succes = true;
            }
            catch
            {
                succes = false;
            }
            return succes;
        }
    }
}
