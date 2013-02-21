using System.Data;
using System.Linq;
using GW2FALFG.Web.Models;


namespace GW2FALFG.Web.Data
{
    public class CharacterClassRepository : ICharacterClassRepository
    {
        private GroupRequestContext _db { get; set; }

        public CharacterClassRepository()
            : this(new GroupRequestContext("LFG"))
        {
        }
        public CharacterClassRepository(GroupRequestContext db)
        {
            _db = db;
        }
        
        public CharacterClass Get(int id)
        {
            return _db.CharacterClasses.SingleOrDefault(e => e.CharacterClassId == id);
        }

        public IQueryable<CharacterClass> GetAll()
        {
            return _db.CharacterClasses;
        }

        public CharacterClass Add(CharacterClass characterClass)
        {
            _db.CharacterClasses.Add(characterClass);
            _db.SaveChanges();
            return characterClass;
        }

        public CharacterClass Update(CharacterClass characterClass)
        {
            _db.Entry(characterClass).State = EntityState.Modified;
            _db.SaveChanges();
            return characterClass;
        }

        public void Delete(int characterClassId)
        {
            var item = Get(characterClassId);
            _db.CharacterClasses.Remove(item);
        }
    }
}