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
    public class VoiceChatController : ApiController
    {
        public IVoiceChatRepository _repository { get; set; }

        public VoiceChatController(IVoiceChatRepository repository)
        {
            _repository = repository;
        }
        // GET api/voicechat
        public IEnumerable<VoiceChat> Get()
        {
            return _repository.GetAll().OrderBy(e => e.VoiceChatId).ToList();
        }

        // GET api/voicechat/5
        public HttpResponseMessage Get(int id)
        {
            var item = _repository.Get(id);
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        // POST api/voicechat
        public HttpResponseMessage Post(VoiceChat item)
        {
             var response = Request.CreateResponse(HttpStatusCode.Created, item);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("api/voicechat/{0}", item.VoiceChatId));
            _repository.Add(item);
            return response;
       }

        // PUT api/voicechat/5
        public void Put(VoiceChat item)
        {
            _repository.Update(item);
        }

        // DELETE api/voicechat/5
        public HttpResponseMessage Delete(int id)
        {
            _repository.Delete(id);
            return Request.CreateResponse((HttpStatusCode.NoContent));
        }
    }
}