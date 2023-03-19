using ContactApp.Interfaces;
using ContactApp.Models;

namespace ContactApp.Services;

public class ContactRepository : IContactRepository
{
    public List<Contact> Contacts { get; set; }

    public ContactRepository()
    {
        Contacts = new List<Contact>
        {
            new Contact()
            {
                Id = Guid.NewGuid(),
                Email = "hola@hola.com",
                Name = "Erick",
                ResidencialPhone = "98899889",
                WorkPhone = "98899889",
                Phone = "98899889"
            }
        };
    }

    public List<Contact> GetContacts()
    {
        return Contacts;
    }

    public void CreateContact(Contact contact)
    {
        contact.Id = Guid.NewGuid();
        Contacts.Add(contact);
    }

    public void UpdateContact(Contact contact)
    {
        var contactToUpdate = Contacts.FirstOrDefault(c => c.Id == contact.Id);

        if (contactToUpdate == null)
        {
            throw new Exception("Contacto no encontrado");
        }

        contactToUpdate.Name = contact.Name;
        contactToUpdate.Email = contact.Email;
        contactToUpdate.Phone = contact.Phone;
        contactToUpdate.ResidencialPhone = contact.ResidencialPhone;
        contactToUpdate.WorkPhone = contact.WorkPhone;
    }

    public void DeleteContact(Guid Id)
    {
        var contactToDelete = Contacts.FirstOrDefault(c => c.Id == Id);

        if (contactToDelete == null)
        {
            throw new Exception("Contacto no encontrado");
        }

        Contacts.Remove(contactToDelete);
    }

    public Contact GetContactById(Guid Id)
    {
        var contacto = Contacts.FirstOrDefault(c => c.Id == Id);
        if (contacto == null)
        {
            throw new Exception("Contacto no encontrado");
        }

        return contacto;
    }
}