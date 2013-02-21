using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public interface IUserRepository
    {
        User VerifyCredentials(string user, string password);
        User Add(User user);
    }
}
