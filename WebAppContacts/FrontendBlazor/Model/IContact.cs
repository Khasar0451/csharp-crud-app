namespace FrontendBlazor.Model;

public class IContact
{
    public int id { get; set; }
    public required string name { get; set; }
    public required string surname { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }
    public int contactCategoryId { get; set; }
    public required string contactCategory { get; set; }
    public int contactSubategoryId { get; set; }
    public required string contactSubategory { get; set; }
    public int  phoneNumber { get; set; }
    public DateOnly birthdate { get; set; }
}
