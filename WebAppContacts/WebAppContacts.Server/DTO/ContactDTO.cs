using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace WebAppContacts.Server.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string Surame { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Subcategory { get; set; }
        
        [Required]
        [Phone]
        public string Number { get; set; }
        [Required]
        public DateOnly Birthdate { get; set; }
    }
}
