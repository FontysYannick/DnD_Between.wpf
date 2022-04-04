using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_DnD_Between
{
    public interface ICharacter_Context
    {
        void AddCharacter(CharacterDTO character);

        void DeleteCharacter(int ID);

        List<CharacterDTO> Getall();

        List<CharacterDTO> Getbyid(int ID);
    }
}
