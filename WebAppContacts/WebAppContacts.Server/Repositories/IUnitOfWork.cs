namespace WebAppContacts.Server.Repositories
{
    public interface IUnitOfWork
    {
        IContactRepository ContactRepository { get; }
        IUserRepository UserRepository { get; }
        void Save();
    }
}
