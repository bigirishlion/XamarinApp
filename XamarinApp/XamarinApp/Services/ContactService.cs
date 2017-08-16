using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class ContactService
    {
        public List<Contact> _contacts = new List<Contact>()
        {
            new Contact {Id = 1, Name = "Ezra", LastName = "M", Phone = "555-555-5555", Email = "ez@testing.com", Blocked = false},
            new Contact {Id = 2, Name = "Lucas", LastName = "M", Phone = "555-555-5555", Email = "luke@testing.com", Blocked = false},
            new Contact {Id = 3, Name = "Kellen", LastName = "M", Phone = "555-555-5555", Email = "kel@testing.com", Blocked = false},
            new Contact {Id = 4, Name = "Rachelle", LastName = "M", Phone = "555-555-5555", Email = "shell@testing.com", Blocked = false},
        };

        public List<Contact> GetContacts()
        {
            return _contacts;
        }

        public Contact GetContactById(int contactId)
        {
            return _contacts.FirstOrDefault(u => u.Id == contactId);
        }

        internal Contact SaveContact(Contact contact)
        {
            if (contact.Id != 0)
            {
                var exContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
                exContact = contact;
            } 
            else
            {
                contact.Id = _contacts.Count + 1;
                _contacts.Add(contact);
            }

            return contact;
        }
    }
}
