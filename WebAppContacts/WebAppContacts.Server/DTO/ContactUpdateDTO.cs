using System.ComponentModel.DataAnnotations;

namespace WebAppContacts.Server.DTO
{
    public class ContactUpdateDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Phone]
        public string Number { get; set; }
        public string Password { get; set; }
        public int ContactCategoryId { get; set; }
        public int ContactSubcategoryId { get; set; }
        public DateOnly Birthdate { get; set; }
    }
}
