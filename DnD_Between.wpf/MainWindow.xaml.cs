using System.Windows;
using System.Windows.Controls;

namespace DnD_Between.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Character_Container chaContainer;
        private character_form chafrm;
        private Character chaclass;

        private int ID;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            BTNEdit.IsEnabled = false;
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            chaContainer = new Character_Container();
            this.dgchar.ItemsSource = chaContainer.Getall();
        }

        private void BTNCreate_Click(object sender, RoutedEventArgs e)
        {
            chafrm = new character_form(this);
            chafrm.Show();
        }

        private void BTNEdit_Click(object sender, RoutedEventArgs e)
        {
            chafrm = new character_form(this, chaclass);
            chafrm.Show();
        }

        private void dgchar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgchar.SelectedItem != null)
            {
                if (dgchar.SelectedItem is Character)
                {
                    var row = (Character)dgchar.SelectedItem;

                    if (row != null)
                    {
                        ID = row.ID;
                        string name = row.name;
                        int str = row.str;
                        int dex = row.dex;
                        int con = row.con;
                        int wis = row.wis;
                        int intt = row.intt;
                        int cha = row.cha;
                        int level = row.level;
                        int speed = row.speed;
                        Class char_class = row.char_class;
                        Race char_race = row.char_race;


                        chaclass = new Character(ID, name, str, dex, con, intt, wis, cha, level, speed, char_class, char_race);
                        BTNEdit.IsEnabled = true;
                    }
                }
            }
        }
    }
}
