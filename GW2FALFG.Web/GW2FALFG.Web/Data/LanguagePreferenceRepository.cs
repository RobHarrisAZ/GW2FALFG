using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public class LanguagePreferenceRepository : ILanguagePreferenceRepository
    {
        private GroupRequestContext _db { get; set; }

        public LanguagePreferenceRepository() :this (new GroupRequestContext())
        {
        }
        public LanguagePreferenceRepository(GroupRequestContext db)
        {
            _db = db;
        }

        public Language Get(int id)
        {
            return _db.Languages.SingleOrDefault(l => l.LanguageId == id);
        }

        public IQueryable<Language> GetAll()
        {
            return _db.Languages;
        }

        public Language Add(Language languagePref)
        {
            _db.Languages.Add(languagePref);
            _db.SaveChanges();
            return languagePref;
            
        }

        public Language Update(Language languagePref)
        {
            _db.Entry(languagePref).State = EntityState.Modified;
            _db.SaveChanges();
            return languagePref;
        }

        public void Delete(int languageId)
        {
            var item = Get(languageId);
            _db.Languages.Remove(item);
        }
    }
}