using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]{ "Jan", "kowal" , "ski"};
            
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Jan";
        }
    }
}
