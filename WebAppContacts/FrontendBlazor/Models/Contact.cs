namespace FrontendBlazor.Models;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int ContactCategoryId { get; set; }
    public string ContactCategory { get; set; }
    public int ContactSubcategoryId { get; set; }
    public string ContactSubcategory { get; set; }
    public string Number { get; set; }
    public string Birthdate { get; set; }

    public Contact(){
        Random rnd = new Random();
        Name = "name";
        Surname = "surname";
        Email = $"example{rnd.Next(99999)}@ex.com";
        Password = "pvukk388FW3AcPfRKvK4M8tTieolxQ2QzJHbGTNGXRyNSnffTXBazQwiil9hkyPUSoHdqzYERbUoFZFzcOgmAh15UMvzg6IwQuHC";
        ContactCategory = "";
        ContactCategoryId =1;
        ContactSubcategory = "";
        ContactSubcategoryId = 1;
        Number = "123456789";
        Birthdate = "2020-01-01";
    }
}
