﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;

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
            return _db.GroupRequests.Include("GroupVoiceChats").Include("GroupVoiceChats.VoiceChat").SingleOrDefault(g => g.GroupRequestId == id);
        }

        public IQueryable<GroupRequest> GetAll()
        {
            var elapsed = (DateTime.UtcNow).AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["Elapsed"]));
            return _db.GroupRequests.Include("Event").Include("CharacterClass").Include("GroupVoiceChats").Include("GroupVoiceChats.VoiceChat").Where(t => t.Timestamp >= elapsed && t.Timestamp <= DateTime.UtcNow).OrderByDescending(t => t.Timestamp).ThenBy(g => g.Event.EventName);
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
            
            //_db.Entry(grpReq).State = EntityState.Modified;
            int id = grpReq.GroupRequestId;
            var request = _db.GroupRequests.Single(g => g.GroupRequestId == id);
            request.CharacterClassId = grpReq.CharacterClassId;
            request.Description = grpReq.Description;
            request.EventId = grpReq.EventId;
            request.Level = grpReq.Level;
            request.PlayerName = grpReq.PlayerName;
            request.Timestamp = grpReq.Timestamp;
            request.UserGuid = grpReq.UserGuid;
            _db.Entry(request).State = EntityState.Modified;

            var groupVoiceChats = _db.GroupVoiceChats.Where(v => v.GroupRequestId == id).ToList();
            bool found = false;
            //Handle additions
            foreach (var vc in grpReq.GroupVoiceChats)
            {
                foreach (var groupVoiceChat in groupVoiceChats)
                {
                    if (groupVoiceChat.VoiceChatId == vc.VoiceChatId)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)//Add new entries
                {
                    _db.GroupVoiceChats.Add(new GroupVoiceChat {GroupRequestId = id, VoiceChatId = vc.VoiceChatId});
                }
                found = false;
            }
            //Handle deletions
            foreach (var groupVoiceChat in groupVoiceChats)
            {
                foreach (var vc in grpReq.GroupVoiceChats)
                {
                    if (groupVoiceChat.VoiceChatId == vc.VoiceChatId)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)//Add new entries
                {
                    _db.GroupVoiceChats.Remove(groupVoiceChat);
                }
                found = false;
            }

            int records = _db.SaveChanges();
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
            return _db.GroupRequests.Include("Event").Where(e => e.Event.EventName == eventName);
        }

        public IEnumerable<GroupRequest> GetByUserGuid(string userGuid)
        {
            return _db.GroupRequests.Where(l => l.UserGuid == userGuid);
        }
    }
}