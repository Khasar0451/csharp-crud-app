﻿using WebAppContacts.Server.Data;
using WebAppContacts.Server.Entities;

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

        public void UpdateContact(Contact contact)
        {
            ctx.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
