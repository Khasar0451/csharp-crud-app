using WebAppContacts.Server.Entities;

namespace WebAppContacts.Server.Repositories
{
    public interface IContactRepository : IDisposable
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContactById(int contactId);
        void AddContact(Contact contact);
        void DeleteContact(int contactID);
        void UpdateContact(Contact contact);
        void Save();
    }
}
