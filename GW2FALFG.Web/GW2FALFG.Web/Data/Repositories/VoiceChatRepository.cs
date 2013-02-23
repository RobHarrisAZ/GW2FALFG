using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public class VoiceChatRepository : IVoiceChatRepository
    {
        private GroupRequestContext _db { get; set; }

        public VoiceChatRepository()
            : this(new GroupRequestContext("LFG"))
        {
        }
        public VoiceChatRepository(GroupRequestContext db)
        {
            _db = db;
        }
        
        public VoiceChat Get(int id)
        {
            return _db.VoiceChats.SingleOrDefault(e => e.VoiceChatId == id);
        }

        public IQueryable<VoiceChat> GetAll()
        {
            return _db.VoiceChats;
        }

        public VoiceChat Add(VoiceChat item)
        {
            _db.VoiceChats.Add(item);
            _db.SaveChanges();
            return item;
        }

        public VoiceChat Update(VoiceChat item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return item;
        }

        public void Delete(int itemId)
        {
            var item = Get(itemId);
            _db.VoiceChats.Remove(item);
        }
    }
}