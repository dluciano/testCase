using System.Threading;
namespace Clay.DAL
{
    public interface ISecurityService
    {
        string LogedUserName { get; }
    }
}