using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ContactApp.Interfaces;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactRepository _contactRepository;

        public ContactController(ILogger<ContactController> logger,IContactRepository _contactRepository)
        {
            _logger = logger;
            this._contactRepository = _contactRepository;
        }

        public IActionResult Index()
        {
            
            var contacts = _contactRepository.GetContacts();
            var contactViewModel = new ContactsViewModel()
            {
                Contacts = contacts.ToList()
            };
            
            return View(contactViewModel);
        }
        
        public IActionResult Create()
        {
            return View("CreateContactForm");
        }
        
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateContactForm", contact);
            }
            
            _contactRepository.CreateContact(contact);
            return RedirectToAction("Index");
        }
        
        public IActionResult Update(Guid Id)
        {
            
            var contact = _contactRepository.GetContactById(Id);
            
            if (!ModelState.IsValid)
            {
                return View("CreateContactForm", contact);
            }
            
            return View("UpdateContactForm", contact);
        }
        
        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            _contactRepository.UpdateContact(contact);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(Guid Id)
        {
            _contactRepository.DeleteContact(Id);
            return RedirectToAction("Index");
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}