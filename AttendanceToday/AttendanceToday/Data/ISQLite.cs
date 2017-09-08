using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AttendanceToday.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
