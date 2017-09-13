using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AttendanceToday.Data;

[assembly: Xamarin.Forms.Dependency(typeof(AttendanceToday.Droid.SQLite_Android))]

namespace AttendanceToday.Droid
{
    //[assembly: Dependency(typeof(SQLite_Android))]
    
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        #region ISQLite implementation

        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "AttendanceToday.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentsPath, fileName);

            //var platform = new SQLite.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.SQLiteConnection(path,true);

            return connection;
        }

        #endregion
    }
}