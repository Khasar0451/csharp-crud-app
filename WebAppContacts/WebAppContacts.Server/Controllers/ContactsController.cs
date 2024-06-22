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
            IEnumerable<Contact> contacts = unitOfWork.ContactRepository.GetContacts();
            return Ok(mapper.Map<IEnumerable<ContactDTO>>(contacts));
        
        }
        
        [HttpGet("categories")]
        public ActionResult GetContactCategories()
        {
            IEnumerable<ContactCategory> cat = unitOfWork.ContactRepository.GetContactCategories();
            return Ok(cat);
        
        }

        [HttpGet("{id}")]
        public ActionResult<string>GetContact(int id)
        {
            return Ok(unitOfWork.ContactRepository.GetContactById(id));
        }

        [HttpPut("add")]
        public ActionResult AddContact(ContactDTO contactDTO)
        {
            try
            {
                Contact contact = mapper.Map<Contact>(contactDTO);
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
            Contact contact = unitOfWork.ContactRepository.GetContactById(id);
            ContactUpdateDTO contactToPatch = mapper.Map<ContactUpdateDTO>(contact);
            contactPatchDocument.ApplyTo(contactToPatch, ModelState);
            mapper.Map(contactToPatch, contact);
            unitOfWork.Save();
            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public ActionResult DeleteContact(int id)
        {
            unitOfWork.ContactRepository.DeleteContact(id);
            unitOfWork.Save();
            return Ok();
        }
    }
}
