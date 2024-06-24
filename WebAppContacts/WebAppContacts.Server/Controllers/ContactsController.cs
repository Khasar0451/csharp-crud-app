using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppContacts.Server.Data;
using WebAppContacts.Server.Repositories;
using WebAppContacts.Server.Entities;
using AutoMapper;
using WebAppContacts.Server.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace WebAppContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public ContactsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        //TO DO: Add other responses (errors, created, etc)

        [HttpGet]
        public ActionResult GetContacts()
        {
            IEnumerable<Contact> contacts = unitOfWork.ContactRepository.GetContacts(); //database always return in basic Contact type
            return Ok(mapper.Map<IEnumerable<ContactListDTO>>(contacts));               //Mapping to DTO type before sending to user
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetContact(int id)
        {
            Contact contact = unitOfWork.ContactRepository.GetContactById(id);
            ContactDTO contactDTO = mapper.Map<ContactDTO>(contact);
            return Ok(contactDTO);
        }


        [HttpGet("categories")]
        public ActionResult GetContactCategories()
        {
            IEnumerable<ContactCategory> cat = unitOfWork.ContactRepository.GetContactCategories();
            return Ok(cat);
        }        

        [HttpGet("categories/{id}")]
        public string GetContactCategory(int id)
        {
            string cat = unitOfWork.ContactRepository.GetContactCategory(id);
            return (cat);
        }        

        [HttpGet("subcategories")]
        public ActionResult GetContactSubcategories()
        {
            IEnumerable<ContactSubcategory> cat = unitOfWork.ContactRepository.GetContactSubcategories();
            return Ok(cat);
        }        

        [HttpGet("subcategories/{id}")]
        public string GetContactSubcategory(int id)
        {
            string cat = unitOfWork.ContactRepository.GetContactSubcategory(id);
            return (cat);
        }

 
        [HttpPut("add")]
        public ActionResult AddContact(ContactAddDTO contactAddDTO)
        {
            try
            {
                Contact contact = mapper.Map<Contact>(contactAddDTO);
                contact.ContactCategory = GetContactCategory(contact.ContactCategoryId);
                contact.ContactSubcategory = GetContactSubcategory(contact.ContactSubcategoryId);
                unitOfWork.ContactRepository.AddContact(contact);
                unitOfWork.Save();
                return Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
            {
                return BadRequest("Email already in use");
            }
        }

        [HttpPatch("update/{id}")]
        public ActionResult UpdateContact(int id, JsonPatchDocument<ContactUpdateDTO>contactPatchDocument)
        {
            try
            {
                Contact contact = unitOfWork.ContactRepository.GetContactById(id);
                ContactUpdateDTO contactToPatch = mapper.Map<ContactUpdateDTO>(contact);
                contactPatchDocument.ApplyTo(contactToPatch, ModelState);
                mapper.Map(contactToPatch, contact);
                unitOfWork.Save();
                return Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
            {
                return BadRequest("Email already in use");
            }
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            unitOfWork.ContactRepository.DeleteContact(id);
            unitOfWork.Save();
            return Ok();
        }
    }
}
