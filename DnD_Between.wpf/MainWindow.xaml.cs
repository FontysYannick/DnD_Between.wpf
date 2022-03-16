using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace DnD_Between.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private character chafrm;
        private Characterclass chaclass;

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
            chaclass = new Characterclass(this);
            chaclass.FillDataGrid();
        }

        private void BTNCreate_Click(object sender, RoutedEventArgs e)
        {
            chafrm = new character(this);
            chafrm.Show();
        }

        private void dgchar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView _DataView = dgchar.CurrentCell.Item as DataRowView;

            if (_DataView != null)
            {
                ID = convertTOint(_DataView.Row[0].ToString());
                string name = _DataView.Row[1].ToString();
                int str = convertTOint(_DataView.Row[2].ToString());
                int dex = convertTOint(_DataView.Row[3].ToString());
                int con = convertTOint(_DataView.Row[4].ToString());
                int wis = convertTOint(_DataView.Row[5].ToString());
                int intt = convertTOint(_DataView.Row[6].ToString());
                int cha = convertTOint(_DataView.Row[7].ToString());

                LBSelect.Content = ID;
                //chaclass = new Characterclass(ID, name, str, dex, con, intt, wis, cha);

                BTNEdit.IsEnabled = true;
            }
        }

        private int convertTOint(string conv)
        {
            int convert = Int32.Parse(conv);
            return convert;
        }

        private void BTNEdit_Click(object sender, RoutedEventArgs e)
        {
            chafrm = new character(this, chaclass);
            chafrm.Show();
        }
    }
}
