using System.ComponentModel.DataAnnotations;

namespace WebAppContacts.Server.Entities
{
    public class ContactCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
      
    }
}
