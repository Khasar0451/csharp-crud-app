using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppContacts.Server.Data;
using WebAppContacts.Server.Repositories;
using WebAppContacts.Server.Entities;
using AutoMapper;
using WebAppContacts.Server.DTO;
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

        [HttpGet]
        public ActionResult GetContacts()
        {
            var contacts = unitOfWork.ContactRepository.GetContacts();
            return Ok(mapper.Map<IEnumerable<GetContactDTO>>(contacts));
           // return Ok(unitOfWork.ContactRepository.GetContacts());
        }

        [HttpGet("{id}")]
        public ActionResult<string>GetContact(int id)
        {
            return Ok(unitOfWork.ContactRepository.GetContactById(id));
        }

        [HttpPut("add")]
        public ActionResult AddContact(Contact contact)
        {
            unitOfWork.ContactRepository.AddContact(contact);
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
