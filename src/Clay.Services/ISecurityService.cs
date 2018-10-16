using Clay.WebApi;
using System.Linq;
namespace Clay.DAL
{
    public interface ISecurityService
    {
        string LogedUserName { get; }
        IQueryable<Property> UserProperties();
    }
}