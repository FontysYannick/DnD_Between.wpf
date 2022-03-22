using System;
using System.Windows;

namespace DnD_Between.wpf
{
    /// <summary>
    /// Interaction logic for character.xaml
    /// </summary>
    public partial class character_form : Window
    {
        Character_Container charac = new Character_Container();
        Class_Container classcontainer = new Class_Container();
        Race_Container racecontainer = new Race_Container();
        MainWindow frm1 = new MainWindow();
        Character charclass;

        private int ID;

        public character_form(MainWindow frm)
        {
            InitializeComponent();
            loadCMB();
            this.frm1 = frm;
            BTNUpdate.IsEnabled = false;
            BTNDel.IsEnabled = false;
        }

        public character_form(MainWindow frm, Character characterclass)
        {
            InitializeComponent();
            loadCMB();
            this.frm1 = frm;
            BTNSave.IsEnabled = false;
            this.charclass = characterclass;
            this.ID = charclass.ID;
            TBName.Text = charclass.name;
            TBStr.Text = charclass.str.ToString();
            TBDex.Text = charclass.dex.ToString();
            TBCon.Text = charclass.con.ToString();
            TBWis.Text = charclass.wis.ToString();
            TBInt.Text = charclass.intt.ToString();
            TBCha.Text = charclass.cha.ToString();
            CMBLvl.Text = charclass.level.ToString();
            CMBSpeed.Text = charclass.speed.ToString();
            CMBClass.SelectedIndex = charclass.class_id - 1;
            CMBRace.SelectedIndex = charclass.race_id - 1;
        }

        private void loadCMB()
        {
            for (int i = 1; i <= 20; i++)
            {
                CMBLvl.Items.Add(i);
            }

            for (int i = 20; i <= 50; i += 5)
            {
                CMBSpeed.Items.Add(i);
            }

            CMBClass.ItemsSource = classcontainer.Getall();
            CMBRace.ItemsSource = racecontainer.Getall();

            CMBLvl.SelectedIndex = 0;
            CMBSpeed.SelectedIndex = 2;
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
            int level = Int32.Parse(CMBLvl.Text);
            int speed = Int32.Parse(CMBSpeed.Text);
            int class_id = Int32.Parse(CMBClass.SelectedValue.ToString());
            int race_id = Int32.Parse(CMBRace.SelectedValue.ToString());

            charac.AddCharacter(name, str, dex, con, intt, wis, cha, level, speed, class_id, race_id);
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
            int level = Int32.Parse(CMBLvl.Text);
            int speed = Int32.Parse(CMBSpeed.Text);
            int class_id = Int32.Parse(CMBClass.SelectedValue.ToString());
            int race_id = Int32.Parse(CMBRace.SelectedValue.ToString());

            charclass.UpdateCharacter(ID, name, str, dex, con, intt, wis, cha, level, speed, class_id, race_id);
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
