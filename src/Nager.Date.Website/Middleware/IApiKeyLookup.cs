using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Nager.Date.Website.Middleware
{
    public interface IApiKeyLookup
    {
         Task<bool> IsValidKey(string apiKey, IPAddress ipFrom);
         Task AddHit(IPrincipal principal, IPAddress ipAddress);
    }
}
