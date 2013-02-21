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
    public class CharacterClassController : ApiController
    {
        public ICharacterClassRepository _characterClassRepository { get; set; }

        public CharacterClassController(ICharacterClassRepository characterClassRepository)
        {
            _characterClassRepository = characterClassRepository;
        }

        // GET api/characterclass
        public IEnumerable<CharacterClass> Get()
        {
            return _characterClassRepository.GetAll().OrderBy(e => e.CharacterClassName).ToList();
        }

        // GET api/characterclass/5
        public HttpResponseMessage Get(int id)
        {
            var eventItem = _characterClassRepository.Get(id);
            if (eventItem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, eventItem);
        }

        // POST api/characterclass
        public HttpResponseMessage Post(CharacterClass characterClass)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, characterClass);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("api/characterclass/{0}", characterClass.CharacterClassId));
            _characterClassRepository.Add(characterClass);
            return response;
        }

        // PUT api/characterclass/5
        public void Put(CharacterClass characterClass)
        {
            _characterClassRepository.Update(characterClass);
        }

        // DELETE api/characterclass/5
        public HttpResponseMessage Delete(int id)
        {
            _characterClassRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
