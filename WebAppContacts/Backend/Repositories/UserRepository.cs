using WebAppContacts.Server.Data;
using WebAppContacts.Server.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebAppContacts.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private bool disposedValue = false;
        private ContactContext ctx;    

        public UserRepository(ContactContext ctx)
        {
            this.ctx = ctx;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public User Login(string username, string password)
        {
            User user = ctx.Users.Find(username);
            return user;
        }

        public User Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
