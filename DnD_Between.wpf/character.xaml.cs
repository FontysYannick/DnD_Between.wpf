using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DnD_Between.wpf
{
    /// <summary>
    /// Interaction logic for character.xaml
    /// </summary>
    public partial class character : Window
    {
        private readonly MainWindow frm1;
        Characterclass charclass;
        Charactercontainer charac = new Charactercontainer();

        private int ID;

        public character(MainWindow frm)
        {
            InitializeComponent();
            frm1 = frm;
            BTNUpdate.IsEnabled = false;
            BTNDel.IsEnabled    = false;

            for (int i = 1; i <= 20; i++)
            {
                CMBLvl.Items.Add(i);
            }

            for (int i = 20; i <= 50; i += 5)
            {
                CMBSpeed.Items.Add(i);
            }
        }

        public character(MainWindow frm, Characterclass characterclass)
        {
            InitializeComponent();
            frm1 = frm;
            BTNSave.IsEnabled = false;
            this.charclass  = characterclass;
            this.ID         = charclass.ID;
            TBName.Text     = charclass.name;
            TBStr.Text      = charclass.str.ToString();
            TBDex.Text      = charclass.dex.ToString();
            TBCon.Text      = charclass.con.ToString();
            TBWis.Text      = charclass.wis.ToString();
            TBInt.Text      = charclass.intt.ToString();
            TBCha.Text      = charclass.con.ToString();
        }

        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            string name = TBName.Text;
            int str = Int32.Parse(TBStr.Text);
            int dex = Int32.Parse(TBDex.Text);
            int con = Int32.Parse(TBCon.Text);
            int intt = Int32.Parse(TBInt.Text);
            int wis = Int32.Parse(TBWis.Text);
            int cha = Int32.Parse(TBCha.Text);

            charac.AddCharacter(name, str, dex, con, intt, wis, cha);
            frm1.FillDataGrid();
            this.Close();
        }

        private void BTNUpdate_Click(object sender, RoutedEventArgs e)
        {
            string name = TBName.Text;
            int str = Int32.Parse(TBStr.Text);
            int dex = Int32.Parse(TBDex.Text);
            int con = Int32.Parse(TBCon.Text);
            int intt = Int32.Parse(TBInt.Text);
            int wis = Int32.Parse(TBWis.Text);
            int cha = Int32.Parse(TBCha.Text);

            //charac.UpdateCharacter(name, str, dex, con, intt, wis, cha);
            frm1.FillDataGrid();
            this.Close();
        }

        private void BTNDel_Click(object sender, RoutedEventArgs e)
        {
            charac.DeleteCharacter(this.ID);
            frm1.FillDataGrid();
            this.Close();
        }
    }
}
