using WebAppContacts.Server.DTO;
using WebAppContacts.Server.Entities;

namespace WebAppContacts.Server.Repositories
{ 
    public interface IUserRepository : IDisposable
    {
        User Login(string username, string password);
        User Register(string username, string password);
    }
}
