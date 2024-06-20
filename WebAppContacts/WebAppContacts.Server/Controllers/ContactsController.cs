using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppContacts.Server.Data;

namespace WebAppContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public ContactsController(ContactContext ctx)
        {
            this.ctx = ctx;
        }

        public ContactContext ctx { get; }

        [HttpGet]
        public ActionResult<string[]> GetContacts()
        {
          //  return new string[]{ "Jan", "kowal" , "ski"};
            return Ok(ctx.Contacts.ToArray());
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Jan";
        }
    }
}
