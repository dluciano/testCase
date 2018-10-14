using System.Threading.Tasks;

namespace IdentityServer
{
    public interface ISeed
    {
        Task EnsureSeedDataAsync();
    }
}