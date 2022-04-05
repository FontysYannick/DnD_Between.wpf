using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DnD_Between.wpf
{
    /// <summary>
    /// Interaction logic for character.xaml
    /// </summary>
    public partial class character_form : Window
    {
        Character_Container charcontainer = new Character_Container();
        Class_Container classcontainer = new Class_Container();
        Race_Container racecontainer = new Race_Container();
        MainWindow frm1 = new MainWindow();
        Character charclass;

        private int ID;
        private string name;
        private int str;
        private int dex;
        private int con;
        private int intt;
        private int wis;
        private int cha;
        private int level;
        private int speed;
        private int class_id;
        private int race_id;


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
            CMBClass.SelectedIndex = charclass.char_class.ID - 1;
            CMBRace.SelectedIndex = charclass.char_race.ID - 1;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
            CMBClass.SelectedIndex = 0;
            CMBRace.SelectedIndex = 0;
        }

        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkempty() == true)
            {
                name = TBName.Text;
                str = Int32.Parse(TBStr.Text);
                dex = Int32.Parse(TBDex.Text);
                con = Int32.Parse(TBCon.Text);
                intt = Int32.Parse(TBInt.Text);
                wis = Int32.Parse(TBWis.Text);
                cha = Int32.Parse(TBCha.Text);
                level = Int32.Parse(CMBLvl.Text);
                speed = Int32.Parse(CMBSpeed.Text);
                class_id = Int32.Parse(CMBClass.SelectedValue.ToString());
                string class_txt = CMBClass.Text;
                race_id = Int32.Parse(CMBRace.SelectedValue.ToString());
                string race_txt = CMBRace.Text;

                Class clss = new Class(class_id,class_txt);
                Race race = new Race(race_id, race_txt);
                charclass = new Character(1, name, str, dex, con, intt, wis, cha, level, speed, clss, race);

                charcontainer.AddCharacter(charclass);
                frm1.FillDataGrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("please fill out all required fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BTNUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (checkempty())
            {
                name = TBName.Text;
                str = Int32.Parse(TBStr.Text);
                dex = Int32.Parse(TBDex.Text);
                con = Int32.Parse(TBCon.Text);
                intt = Int32.Parse(TBInt.Text);
                wis = Int32.Parse(TBWis.Text);
                cha = Int32.Parse(TBCha.Text);
                level = Int32.Parse(CMBLvl.Text);
                speed = Int32.Parse(CMBSpeed.Text);
                class_id = Int32.Parse(CMBClass.SelectedValue.ToString());
                race_id = Int32.Parse(CMBRace.SelectedValue.ToString());

                charclass.UpdateCharacter(ID, name, str, dex, con, intt, wis, cha, level, speed, class_id, race_id);
                frm1.FillDataGrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("please fill out all required fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BTNDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete *" + charclass.name + "* ?", "Are You Sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                frm1.FillDataGrid();
                this.Close();
            }
            else
            {
                charcontainer.DeleteCharacter(this.ID);
                frm1.FillDataGrid();
                this.Close();
            }
        }

        private bool checkempty()
        {
            bool empty = true;
            foreach (Object o in FRM.Children)
            {
                if (o is TextBox)
                {
                    TextBox textBox = o as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        empty = false;
                    }
                }
            }
            return empty;
        }
    }
}
