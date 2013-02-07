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
    public class EventController : ApiController
    {
        public IEventRepository _eventRepository { get; set; }

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        // GET api/event
        public IEnumerable<Event> Get()
        {
            return _eventRepository.GetAll().OrderBy(e => e.EventName).ToList();
        }

        // GET api/event/5
        public HttpResponseMessage Get(int id)
        {
            var eventItem = _eventRepository.Get(id);
            if (eventItem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, eventItem);
        }

        // POST api/event
        public HttpResponseMessage Post(Event eventItem)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, eventItem);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("api/event/{0}", eventItem.EventId));
            _eventRepository.Add(eventItem);
            return response;
        }

        // PUT api/event/5
        public void Put(Event eventItem)
        {
            _eventRepository.Update(eventItem);
        }

        // DELETE api/event/5
        public HttpResponseMessage Delete(int id)
        {
            _eventRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
