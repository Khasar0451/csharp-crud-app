namespace FrontendBlazor.Models;

public class Contact
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int ContactCategoryId { get; set; }
    public required string ContactCategory { get; set; }
    public int ContactSubategoryId { get; set; }
    public required string ContactSubategory { get; set; }
    public int  PhoneNumber { get; set; }
    public DateOnly Birthdate { get; set; }
}
