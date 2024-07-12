using Microsoft.AspNetCore.JsonPatch;
using WebAppContacts.Server.DTO;
using WebAppContacts.Server.Entities;

namespace WebAppContacts.Server.Services
{
    public interface IContactsService
    {
        void AddContact(ContactAddDTO contactAddDTO);
        void DeleteContact(int id);
        ContactDTO GetContact(int id);
        IEnumerable<ContactCategory> GetContactCategories();
        string GetContactCategory(int id);
        IEnumerable<ContactDTO> GetContacts();
        IEnumerable<ContactSubcategory> GetContactSubcategories();
        string GetContactSubcategory(int id);
        void UpdateContact(int id, JsonPatchDocument<ContactDTO> contactPatchDocument);
    }
}