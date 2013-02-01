using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public interface ILanguagePreferenceRepository
    {
        Language Get(int id);
        IQueryable<Language> GetAll();
        Language Add(Language languagePref);
        Language Update(Language languagePref);
        void Delete(int languageId);

    }
}
