using System.Linq;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public interface IEventRepository
    {
        Event Get(int id);
        IQueryable<Event> GetAll();
        Event Add(Event eventItem);
        Event Update(Event eventItem);
        void Delete(int eventId);

    }
}
