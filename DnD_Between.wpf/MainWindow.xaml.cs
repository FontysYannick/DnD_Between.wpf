using System.Collections.Generic;
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
            List<Character> list = chaContainer.Getall();

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
                        int class_id = row.class_id;
                        int race_id = row.race_id;

                        chaclass = new Character(ID, name, str, dex, con, intt, wis, cha, level, speed, class_id, race_id);
                        LBSelect.Content = row.ID;
                        BTNEdit.IsEnabled = true;
                    }
                }
            }
        }
    }
}
