using WebAppContacts.Server.Data;

namespace WebAppContacts.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ContactContext ctx;
        public UnitOfWork(ContactContext ctx)
        {
            this.ctx = ctx;
        }
        public IContactRepository ContactRepository => 
            new ContactRepository(ctx);

        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
