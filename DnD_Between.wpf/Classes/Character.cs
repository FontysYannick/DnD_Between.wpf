using System;
using System.Data.SqlClient;
using DAL_DnD_Between;

namespace DnD_Between.wpf
{
    public class Character : DB
    {
        public int ID { get; private set; }
        public string name { get; private set; }
        public int str { get; private set; }
        public int dex { get; private set; }
        public int con { get; private set; }
        public int intt { get; private set; }
        public int wis { get; private set; }
        public int cha { get; private set; }
        public int level { get; private set; }
        public int speed { get; private set; }
        public Class char_class { get; private set; }
        public Race char_race { get; private set; }


        public Character(int id, string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, Class char_class, Race char_race)
        {
            this.ID = id;
            this.name = name;
            this.str = str;
            this.dex = dex;
            this.con = con;
            this.intt = intt;
            this.wis = wis;
            this.cha = cha;
            this.level = level;
            this.speed = speed;
            this.char_class = char_class;
            this.char_race = char_race;
        }

        public void UpdateCharacter(int ID, string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, int class_id, int race_id)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Character " +
                "SET [name]         = '" + name + "'," +
                " [strength]        = '" + str + "'," +
                " [dexterity]       = '" + dex + "'," +
                " [constitution]    = '" + con + "'," +
                " [intelligence]    = '" + intt + "'," +
                " [wisdom]          = '" + wis + "'," +
                " [charisma]        = '" + cha + "'," +
                " [level]           = '" + level + "'," +
                " [speed]           = '" + speed + "'," +
                " [class_id]        = '" + class_id + "'," +
                " [race_id]         = '" + race_id + "'" +
                "WHERE id           = '" + ID + "'", Connection());

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
    }
}
