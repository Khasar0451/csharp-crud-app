using System.ComponentModel.DataAnnotations;

namespace WebAppContacts.Server.Entities
{
    public class ContactSubcategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
