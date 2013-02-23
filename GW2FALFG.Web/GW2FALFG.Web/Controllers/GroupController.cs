using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GW2FALFG.Web.Data;
using GW2FALFG.Web.Models;
using Newtonsoft.Json;

namespace GW2FALFG.Web.Controllers
{
    public class GroupController : ApiController
    {
        public IGroupRequestRepository _repository { get; set; }

        public GroupController(IGroupRequestRepository repository)
        {
            _repository = repository;
        }
        // GET api/event
        public IEnumerable<GroupRequest> Get()
        {
            return _repository.GetAll();
        }

        // GET api/event/5
        public HttpResponseMessage Get(int id)
        {
            var grpReq = _repository.Get(id);
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
            _repository.Add(grpReq);
            return response;
        }

        // PUT api/event/5
        public void Put(int id, GroupRequest grpReq)
        {
            _repository.Update(grpReq);
        }

        // DELETE api/event/5
        public HttpResponseMessage Delete(int id)
        {
            _repository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE api/event/5
        public HttpResponseMessage Delete()
        {
            _repository.PurgeOld();
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage GetByEventName(string eventName)
        {
            var groupRequests = _repository.GetByEvent(eventName);
            if (groupRequests == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, groupRequests);
        }

        public HttpResponseMessage GetByUser(string userGuid, int q)
        {
            var groupRequests = _repository.GetByUserGuid(userGuid);
            if (groupRequests == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, groupRequests);
        }
    }
}
