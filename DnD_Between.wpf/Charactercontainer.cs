using System;
using System.Data.SqlClient;
using System.Windows;

namespace DnD_Between.wpf
{
    internal class Charactercontainer
    {
        private SqlConnection mssql = new SqlConnection("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi485841;Persist Security Info=True;User ID=dbi485841;Password=Duj7t6ySa1");

        public void AddCharacter(string name, int str, int dex, int con, int intt, int wis, int cha)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Character( [name],[strength],[dexterity],[constitution],[intelligence],[wisdom],[charisma]) VALUES ( '" + name + "', '" + str + "', '" + dex + "','" + con + "','" + wis + "','" + intt + "','" + cha + "')", mssql);

            try
            {
                mssql.Open();
                cmd.ExecuteNonQuery();
                mssql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
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
                MessageBox.Show(ex.Message);
                throw;
            }

        }
    }
}
