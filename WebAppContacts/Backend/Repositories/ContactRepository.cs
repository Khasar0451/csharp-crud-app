using WebAppContacts.Server.Data;
using WebAppContacts.Server.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebAppContacts.Server.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private bool disposedValue = false;
        private ContactContext ctx;    

        public ContactRepository(ContactContext ctx)
        {
            this.ctx = ctx;
        }

        public void AddContact(Contact contact)
        {
            ctx.Contacts.Add(contact);
        }

        public void DeleteContact(int contactID)
        {
            Contact contact = ctx.Contacts.Find(contactID); 
            ctx.Contacts.Remove(contact);
        }

        public Contact GetContactById(int contactId)
        {
            return ctx.Contacts.Find(contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return ctx.Contacts.ToList();
        }
        public IEnumerable<ContactCategory> GetContactCategories()
        {
            return ctx.Categories.ToList();
        }

        public string GetContactCategory(int id)
        {
            return ctx.Categories.Find(id).ToString();
        }
        public IEnumerable<ContactSubcategory> GetContactSubcategories()
        {
            return ctx.Subcategories.ToList();
        }

        public string GetContactSubcategory(int id)
        {
            return ctx.Subcategories.Find(id).ToString();
        }


        public void UpdateContact(Contact contact)
        {
            ctx.Entry(contact).State = EntityState.Modified;
        }

        public void Save()
        {
            ctx.SaveChanges();
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

    }
}
