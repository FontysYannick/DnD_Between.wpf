using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DnD_Between.wpf
{
    public class Characterclass
    {
        private readonly MainWindow frm1;


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
        public int class_id { get; private set; }
        public int race_id { get; private set; }


        public Characterclass(int id, string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, int class_id, int race_id)
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
            this.class_id = class_id;
            this.race_id = race_id;
        }

        public Characterclass(MainWindow frm)
        { 
            this.frm1 = frm;
        }

        public void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT * FROM Character JOIN Class ON Character.class_id = Class.id JOIN Race ON Character.race_id = Race.id;";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Character");
                sda.Fill(dt);
                frm1.dgchar.ItemsSource = dt.DefaultView;
            }
        }
    }
}
