using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;
using System.Configuration;

namespace GW2FALFG.Web.Data
{
    public class EventRepository : IEventRepository
    {
        private GroupRequestContext _db { get; set; }

        public EventRepository()
            : this(new GroupRequestContext("LFG"))
        {
        }
        public EventRepository(GroupRequestContext db)
        {
            _db = db;
        }


        public Event Get(int id)
        {
            return _db.Events.SingleOrDefault(e => e.EventId == id);
        }

        public IQueryable<Event> GetAll()
        {
            return _db.Events;
        }

        public Event Add(Event eventItem)
        {
            _db.Events.Add(eventItem);
            _db.SaveChanges();
            return eventItem;
        }

        public Event Update(Event eventItem)
        {
            _db.Entry(eventItem).State = EntityState.Modified;
            _db.SaveChanges();
            return eventItem;
        }

        public void Delete(int eventId)
        {
            var item = Get(eventId);
            _db.Events.Remove(item);
        }
    }
}