using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;
using System.Configuration;

namespace GW2FALFG.Web.Data
{
    public class GroupRequestRepository : IGroupRequestRepository
    {
        private GroupRequestContext _db { get; set; }

        public GroupRequestRepository()
            : this(new GroupRequestContext("LFG"))
        {
        }
        public GroupRequestRepository(GroupRequestContext db)
        {
            _db = db;
        }
        
        public GroupRequest Get(int id)
        {
            return _db.GroupRequests.SingleOrDefault(g => g.GroupRequestId == id);
        }

        public IQueryable<GroupRequest> GetAll()
        {
            var thirtyMinutes = (DateTime.UtcNow).AddMinutes(-30);
            return _db.GroupRequests.Where(t => t.Timestamp >= thirtyMinutes && t.Timestamp <= DateTime.UtcNow).OrderBy(g => g.EventName).ThenByDescending(t => t.Timestamp);
        }

        public GroupRequest Add(GroupRequest grpReq)
        {
            _db.GroupRequests.Add(grpReq);
            _db.SaveChanges();
            PurgeOld();
            return grpReq;
        }

        public GroupRequest Update(GroupRequest grpReq)
        {
            _db.Entry(grpReq).State = EntityState.Modified;
            _db.SaveChanges();
            return grpReq;
        }

        public void Delete(int groupRequestId)
        {
            var grpReq = Get(groupRequestId);
            _db.GroupRequests.Remove(grpReq);
        }

        public void PurgeOld()
        {
            var thirtyMinutes = (DateTime.UtcNow).AddMinutes(-30);
            var requests = _db.GroupRequests.Where(t => t.Timestamp < thirtyMinutes);
            foreach (var groupRequest in requests)
            {
                _db.GroupRequests.Remove(groupRequest);
            }
        }

        public IEnumerable<GroupRequest> GetByEvent(string eventName)
        {
            return _db.GroupRequests.Where(e => e.EventName == eventName);
        }

        public IEnumerable<GroupRequest> GetByLanguage(string languagePreference)
        {
            return _db.GroupRequests.Where(l => l.LanguagePreference == languagePreference);
        }

        public IEnumerable<GroupRequest> GetByUserGuid(string userGuid)
        {
            return _db.GroupRequests.Where(l => l.UserGuid == userGuid);
        }
    }
}