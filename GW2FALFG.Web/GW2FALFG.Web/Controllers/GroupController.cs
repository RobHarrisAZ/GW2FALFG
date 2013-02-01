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
    public class GroupController : ApiController
    {
        public IGroupRequestRepository _groupRequestRepository { get; set; }

        public GroupController(IGroupRequestRepository groupRequestRepository)
        {
            _groupRequestRepository = groupRequestRepository;
        }
        // GET api/event
        public IEnumerable<GroupRequest> Get()
        {
            return _groupRequestRepository.GetAll();
        }

        // GET api/event/5
        public HttpResponseMessage Get(int id)
        {
            var grpReq = _groupRequestRepository.Get(id);
            if (grpReq == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, grpReq);
        }

        // POST api/event
        public HttpResponseMessage Post(GroupRequest grpReq)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, grpReq);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("api/group/{0}", grpReq.GroupRequestId));
            _groupRequestRepository.Add(grpReq);
            return response;
        }

        // PUT api/event/5
        public void Put(GroupRequest eventItem)
        {
            _groupRequestRepository.Update(eventItem);
        }

        // DELETE api/event/5
        public HttpResponseMessage Delete(int id)
        {
            _groupRequestRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage GetByLanguagePref(string languagePreference)
        {
            var groupRequests = _groupRequestRepository.GetByLanguage(languagePreference);
            if (groupRequests == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, groupRequests);
        }

        public HttpResponseMessage GetByEventName(string eventName)
        {
            var groupRequests = _groupRequestRepository.GetByEvent(eventName);
            if (groupRequests == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, groupRequests);
        }

        public HttpResponseMessage GetByUser(string userGuid)
        {
            var groupRequests = _groupRequestRepository.GetByUserGuid(userGuid);
            if (groupRequests == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, groupRequests);
        }

        public string Index()
        {
            return "<html><body><div><strong>Sorry, but you're doing it wrong...<strong></div></body></html>";
        }
    }
}
