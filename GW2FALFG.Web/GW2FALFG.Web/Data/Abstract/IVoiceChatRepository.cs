using System.Linq;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public interface IVoiceChatRepository
    {
        VoiceChat Get(int id);
        IQueryable<VoiceChat> GetAll();
        VoiceChat Add(VoiceChat item);
        VoiceChat Update(VoiceChat item);
        void Delete(int itemId);
    }
}
