using System.Windows;
using System.Windows.Input;

namespace DnD_Between.wpf
{
    /// <summary>
    /// Interaction logic for Character_viewer.xaml
    /// </summary>
    public partial class Character_viewer : Window
    {
        public Character_viewer(Character character)
        {
            InitializeComponent();
            //name
            LBName.Content = character.name;

            //stats
            LBSTR.Content = character.str;
            LBDEX.Content = character.dex;
            LBCON.Content = character.con;
            LBINT.Content = character.intt;
            LBWIS.Content = character.wis;
            LBCHA.Content = character.cha;

            //modifiers


            //speed
            LBSpeed.Content = character.speed;
        }

        private int ConfigureByTable(int score)
        {
            int[] tableX1 = { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };  //Even scores
            int[] tableX2 = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31 };  //Odd scores
            int[] tableY = { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };        //Modifier values

            //Ability modifiers are assigned directly from a table.
            int result = 0;
            for (int i = 0; i < tableY.Length; i++)
            {
                if (score == tableX1[i])
                {
                    result = tableY[i];
                }
                else if (score == tableX2[i])
                {
                    result = tableY[i];
                }
            }
            score = result;
            return score;
        }
    }
}
