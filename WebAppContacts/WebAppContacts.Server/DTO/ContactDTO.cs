using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace WebAppContacts.Server.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ContactCategoryId { get; set; }
        public int ContactSubcategoryId { get; set; }
        public string ContactCategory {  get; set; }
        public string ContactSubcategory { get; set; }
        
        public string Number { get; set; }
        public DateOnly Birthdate { get; set; }
    }
}
