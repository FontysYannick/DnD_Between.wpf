using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace DnD_Between.wpf
{
    public class Characterclass
    {
        public int     ID       { get; private set; }
        public string  name     { get; private set; }
        public int     str      { get; private set; }
        public int     dex      { get; private set; }
        public int     con      { get; private set; }
        public int     intt     { get; private set; }
        public int     wis      { get; private set; }
        public int     cha      { get; private set; }


        public Characterclass(int id, string name, int str, int dex, int con, int intt, int wis, int cha)
        {
            this.ID     = id;
            this.name   = name;
            this.str    = str;
            this.dex    = dex;
            this.con    = con;
            this.intt   = intt;
            this.wis    = wis;
            this.cha    = cha;
        }
    }
}
