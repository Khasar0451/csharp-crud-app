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
    public class UsersController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
            
        //[HttpPost("login")] //post, because with GET password would be stored in URL
        //public IActionResult Login(UserDTO user) {

        //}
    }
}
