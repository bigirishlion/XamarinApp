using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Pages.MVVM.Models;

namespace XamarinApp.Pages.MVVM.ViewModels
{
    public interface IContactStore
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> GetContact(int id);
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(Contact contact);
    }
}
