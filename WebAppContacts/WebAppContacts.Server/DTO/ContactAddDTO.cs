using System.ComponentModel.DataAnnotations;

namespace WebAppContacts.Server.DTO
{
    public class ContactAddDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, and one digit.")]
        public string Password { get; set; }
        
        [Required]
        public int ContactCategoryId { get; set; }
        
        [Required]
        public int ContactSubcategoryId { get; set; }
        public string ContactSubcategory {  get; set; }

        [Required]
        [Phone]
        public string Number { get; set; }
        
        [Required]
        public DateOnly Birthdate { get; set; }
    }
}
