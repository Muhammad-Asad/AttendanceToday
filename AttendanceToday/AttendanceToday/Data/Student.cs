using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AttendanceToday.Data
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string RollNumber { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string ContactNumber { get; set; }
        public int ClassID { get; set; }

        public Student()
        {
        }
    }
}
