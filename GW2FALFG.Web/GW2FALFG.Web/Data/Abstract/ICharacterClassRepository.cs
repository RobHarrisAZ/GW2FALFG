using System.Linq;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public interface ICharacterClassRepository
    {
        CharacterClass Get(int id);
        IQueryable<CharacterClass> GetAll();
        CharacterClass Add(CharacterClass characterClass);
        CharacterClass Update(CharacterClass characterClass);
        void Delete(int characterClassId);
    }
}