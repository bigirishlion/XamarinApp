using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using XamarinApp.iOS.Persistence;
using XamarinApp.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]

namespace XamarinApp.iOS.Persistence
{
    class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}