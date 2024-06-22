namespace WebAppContacts.Server.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surame { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ContactCategoryId { get; set; }
        public ContactCategory ContactCategory { get; set; }
        public int ContactSubcategoryId { get; set; }
        public ContactSubcategory  ContactSubcategory { get; set; }
        public string Number { get; set; }
        public DateOnly Birthdate { get; set; }
    }
}
