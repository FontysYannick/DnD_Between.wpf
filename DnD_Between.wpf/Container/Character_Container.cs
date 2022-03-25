using DAL_DnD_Between;
using System.Collections.Generic;

namespace DnD_Between.wpf
{
    internal class Character_Container
    {
        Character_Context _Context = new Character_Context();

        public void AddCharacter(string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, int class_id, int race_id)
        {
            _Context.AddCharacter(name, str, dex, con, intt, wis, cha, level, speed, class_id, race_id);
        }

        public void DeleteCharacter(int ID)
        {
            _Context.DeleteCharacter(ID);
        }

        public List<Character> Getall()
        {
            List<Character> list_Character = new List<Character>();

            foreach (var item in _Context.Getall())
            {
                list_Character.Add(new Character(item.ID, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, new Class(item.char_class.ID, item.char_class.name), new Race(item.char_race.ID, item.char_race.name)));
            }

            return list_Character;
        }

        public List<Character> Getbyid(int ID)
        {
            List<Character> list_Character = new List<Character>();

            foreach (var item in _Context.Getall())
            {
                list_Character.Add(new Character(item.ID, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, new Class(item.char_class.ID, item.char_class.name), new Race(item.char_race.ID, item.char_race.name)));
            }

            return list_Character;
        }
    }
}
