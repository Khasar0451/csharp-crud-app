using System.ComponentModel.DataAnnotations;

namespace WebAppContacts.Server.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        //user password should be salted and hashed
        public string Password{ get; set; }
        
    }
}
