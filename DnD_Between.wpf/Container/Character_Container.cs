using DAL_DnD_Between;
using Interface_DnD_Between;
using System.Collections.Generic;

namespace DnD_Between.wpf
{
    internal class Character_Container
    {
        Character_Context _Context = new Character_Context();

        public void AddCharacter(Character character)
        {
            CharacterDTO characterDTO = new CharacterDTO();
            characterDTO.ID = character.ID;
            characterDTO.name = character.name;
            characterDTO.str = character.str;
            characterDTO.dex = character.dex;
            characterDTO.con = character.con;
            characterDTO.intt = character.intt;
            characterDTO.wis = character.wis;
            characterDTO.cha = character.cha;
            characterDTO.level = character.level;
            characterDTO.speed = character.speed;


            ClassDTO classDTO = new ClassDTO();
            classDTO.ID = character.char_class.ID;
            classDTO.name = character.char_class.name;
            characterDTO.char_class = classDTO;

            RaceDTO raceDTO = new RaceDTO();
            raceDTO.ID = character.char_race.ID;
            raceDTO.name = character.char_race.name;
            characterDTO.char_race = raceDTO;

            _Context.AddCharacter(characterDTO);
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
