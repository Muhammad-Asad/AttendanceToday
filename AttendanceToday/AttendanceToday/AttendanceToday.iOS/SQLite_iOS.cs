using System;
using System.IO;
using Xamarin.Forms;
using AttendanceToday.Data;

[assembly: Dependency(typeof(AttendanceToday.iOS.SQLite_iOS))]

namespace AttendanceToday.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        #region ISQLite implementation

        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "RandomThought.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            //var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.SQLiteConnection(path, true);

            return connection;
        }

        #endregion
    }
}