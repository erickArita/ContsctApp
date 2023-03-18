using ContactApp.Models;

namespace ContactApp.Interfaces;

public interface IContactRepository
{
    public List<Contact> Contacts { get; set; }

    
    public List<Contact> GetContacts();
    public void CreateContact(Contact contact);
    public void UpdateContact(Contact contact);
    public void DeleteContact(Guid Id);
    public Contact GetContactById(Guid Id);
}