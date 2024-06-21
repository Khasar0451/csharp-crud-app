namespace WebAppContacts.Server.Repositories
{
    public interface IUnitOfWork
    {
        IContactRepository ContactRepository { get; }
        void Save();
    }
}
