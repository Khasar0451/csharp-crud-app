using System.ComponentModel.DataAnnotations;

namespace WebAppContacts.Server.DTO
{
    public class ContactListDTO
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
        
    }
}
