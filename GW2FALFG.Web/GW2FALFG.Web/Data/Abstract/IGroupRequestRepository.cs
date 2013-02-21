using System.Collections.Generic;
using System.Linq;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public interface IGroupRequestRepository
    {
        GroupRequest Get(int id);
        IQueryable<GroupRequest> GetAll();
        GroupRequest Add(GroupRequest grpReq);
        GroupRequest Update(GroupRequest grpReq);
        void Delete(int groupRequestId);
        IEnumerable<GroupRequest> GetByEvent(string eventName);
        IEnumerable<GroupRequest> GetByUserGuid(string userGuid);
        void PurgeOld();
    }
}
