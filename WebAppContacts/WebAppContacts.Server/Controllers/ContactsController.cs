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
using WebAppContacts.Server.Services;
namespace WebAppContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactsService service;
        public ContactsController(IContactsService service)
        {
            this.service = service;
        }



        [HttpGet]
        public ActionResult GetContacts()
        {
            return Ok(service.GetContacts());
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetContact(int id)
        {
            return Ok(service.GetContact(id));
        }


        [HttpGet("categories")]
        public ActionResult GetContactCategories()
        {
            return Ok(service.GetContactCategories());
        }        

        [HttpGet("categories/{id}")]
        public ActionResult GetContactCategory(int id)
        {
            return Ok(service.GetContactCategory(id));
        }

        [HttpGet("subcategories")]
        public ActionResult GetContactSubcategories()
        {
            return Ok(service.GetContactSubcategories());
        }        

        [HttpGet("subcategories/{id}")]
        public ActionResult GetContactSubcategory(int id)
        {
            return Ok(service.GetContactSubcategory(id));
        }
 
        [HttpPut("add")]
        public ActionResult AddContact(ContactAddDTO contactAddDTO)
        {
            try
            {
                service.AddContact(contactAddDTO);
                return Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
            {
                return BadRequest("Email already in use");
            }
        }


        [HttpPatch("update/{id}")]
        public ActionResult UpdateContact(int id, JsonPatchDocument<ContactDTO> contactPatchDocument)
        {
            try
            {
                service.UpdateContact(id, contactPatchDocument);
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
            service.DeleteContact(id);
            return Ok();
        }
    }
}
