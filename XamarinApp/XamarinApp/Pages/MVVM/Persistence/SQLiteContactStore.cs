using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Pages.MVVM.Models;
using XamarinApp.Pages.MVVM.ViewModels;
using XamarinApp.Persistence;

namespace XamarinApp.Pages.MVVM.Persistence
{
    public class SQLiteContactStore : IContactStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteContactStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Contact>();
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _connection.Table<Contact>().ToListAsync();
        }

        public async Task DeleteContact(Contact contact)
        {
            await _connection.DeleteAsync(contact);
        }

        public async Task AddContact(Contact contact)
        {
            await _connection.InsertAsync(contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            await _connection.UpdateAsync(contact);
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _connection.FindAsync<Contact>(id);
        }
    }
}
