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
            List<Character> list = new List<Character>();

            foreach (var item in _Context.Getall())
            {
                list.Add(new Character(item.ID, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, item.char_class, item.char_race));
            }

            return list;
        }

        public List<Character> Getbyid(int ID)
        {
            List<Character> list = new List<Character>();

            foreach (var item in _Context.Getall())
            {
                list.Add(new Character(item.ID, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, item.class_id, item.race_id));
            }

            return list;
        }
    }
}
