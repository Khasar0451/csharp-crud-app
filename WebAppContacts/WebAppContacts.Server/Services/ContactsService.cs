using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppContacts.Server.Data;
using WebAppContacts.Server.Repositories;
using WebAppContacts.Server.Entities;
using AutoMapper;
using WebAppContacts.Server.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace WebAppContacts.Server.Services
{
    public class ContactsService : IContactsService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public ContactsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        //TO DO: Add other responses (errors, created, etc)
        //TO DO: Show to user when input doesnt meet requirments (unique email, safe password)
        public IEnumerable<ContactDTO> GetContacts()
        {
            IEnumerable<Contact> contacts = unitOfWork.ContactRepository.GetContacts();
            return mapper.Map<IEnumerable<ContactDTO>>(contacts);

        }

        public ContactDTO GetContact(int id)
        {
            Contact contact = unitOfWork.ContactRepository.GetContactById(id);
            ContactDTO contactDTO = mapper.Map<ContactDTO>(contact);
            return contactDTO;
        }

        public IEnumerable<ContactCategory> GetContactCategories()
        {
            IEnumerable<ContactCategory> cat = unitOfWork.ContactRepository.GetContactCategories();
            return cat;
        }

        public string GetContactCategory(int id)
        {
            string cat = unitOfWork.ContactRepository.GetContactCategory(id);
            return cat;
        }

        public IEnumerable<ContactSubcategory> GetContactSubcategories()
        {
            IEnumerable<ContactSubcategory> cat = unitOfWork.ContactRepository.GetContactSubcategories();
            return cat;
        }

        public string GetContactSubcategory(int id)
        {
            string cat = unitOfWork.ContactRepository.GetContactSubcategory(id);
            return cat;
        }

        private void addCategories(Contact contact)
        {
            contact.ContactCategory = GetContactCategory(contact.ContactCategoryId);
            if (contact.ContactCategoryId == 1)
            {
                contact.ContactSubcategory = GetContactSubcategory(contact.ContactSubcategoryId);
            }
            else if (contact.ContactCategoryId != 1)
            {
                contact.ContactSubcategoryId = -1;
            }
        }

        public void AddContact(ContactAddDTO contactAddDTO)
        {
            Contact contact = mapper.Map<Contact>(contactAddDTO);
            addCategories(contact);
            unitOfWork.ContactRepository.AddContact(contact);
            unitOfWork.Save();
        }

        public void UpdateContact(int id, JsonPatchDocument<ContactDTO> contactPatchDocument)
        {
            Contact contact = unitOfWork.ContactRepository.GetContactById(id);
            ContactDTO contactToPatch = mapper.Map<ContactDTO>(contact);
            contactPatchDocument.ApplyTo(contactToPatch);
            mapper.Map(contactToPatch, contact);
            addCategories(contact);
            unitOfWork.Save();
        }

        public void DeleteContact(int id)
        {
            unitOfWork.ContactRepository.DeleteContact(id);
            unitOfWork.Save();
        }
    }
}
