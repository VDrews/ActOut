using System.IO;
using Windows.Storage;
using ActOut.Interfaces;
using ActOut.UWP.NativeServices;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteUwp))]

namespace ActOut.UWP.NativeServices
{
    public class SqLiteUwp : ISQLite
    {
        //Crea la base de datos local
        public SQLiteConnection GetConnection()
        {
            const string sqliteFilename = "Cache.db3";
            var documentsPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}