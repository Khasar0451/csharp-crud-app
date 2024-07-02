using FrontendBlazor.Models;
namespace FrontendBlazor;

public class ContactController(HttpClient http)
{
    string api = "http://localhost:5255/api/Contacts/";

    public async Task<ContactCategory[]> getContactsCategories()  {
        return await http.GetFromJsonAsync<ContactCategory[]>(api + "categories") ?? [];
    }
    public async Task<ContactSubcategory[]> getContactsSubcategories()
    {
        return await http.GetFromJsonAsync<ContactSubcategory[]>(api + "subcategories") ?? [];
    }
    public async Task<ContactList[]> getContacts()
    {
        return await http.GetFromJsonAsync<ContactList[]>(api) ?? [];
    }
    public async Task<Contact> getContact(int id)
    {
        return await http.GetFromJsonAsync<Contact>(api + id);
    }
    public async Task<Contact> deleteContact(int id)
    {
        return await http.DeleteFromJsonAsync<Contact>(api + id);
    }
    public async Task<HttpResponseMessage> addContact(Contact form)
    {
        return await http.PostAsJsonAsync(api + "add", form);
    }
    public async Task<HttpResponseMessage> editContact(Contact form, int id)
    {
        return await http.PutAsJsonAsync(api + "update/" + id, form);
    }
}
