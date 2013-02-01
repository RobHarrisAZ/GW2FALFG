using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GW2FALFG.Web.Data;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Controllers
{
    public class LanguageController : ApiController
    {
        public ILanguagePreferenceRepository _languagePreferenceRepository { get; set; }

        public LanguageController(ILanguagePreferenceRepository langRepository)
        {
            _languagePreferenceRepository = langRepository;
        }
        // GET api/language
        public IEnumerable<Language> Get()
        {
            return _languagePreferenceRepository.GetAll();
        }

        // GET api/language/5
        public HttpResponseMessage Get(int id)
        {
            var language = _languagePreferenceRepository.Get(id);
            if (language == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, language);
        }

        // POST api/language
        public HttpResponseMessage Post(Language language)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, language);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("api/language/{0}", language.LanguageId));
            _languagePreferenceRepository.Add(language);
            return response;
        }

        // PUT api/language/5
        public void Put(Language language)
        {
            _languagePreferenceRepository.Update(language);
        }

        // DELETE api/language/5
        public HttpResponseMessage Delete(int id)
        {
            _languagePreferenceRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
