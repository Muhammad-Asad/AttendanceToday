using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Collections;
using System.Linq;
 
namespace AttendanceToday.Data
{
    public class AttendanceDatabase
    {
        private SQLiteConnection _connection;

        public AttendanceDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Student>();
        }

        public IEnumerable<Student> GetStudents()
        {
            return (from t in _connection.Table<Student>()
                    select t).ToList();
        }

        public Student GetStudent(int id)
        {
            return _connection.Table<Student>().FirstOrDefault(t => t.ID == id);
        }

        public Student GetStudent(String rollNumber)
        {
            return _connection.Table<Student>().FirstOrDefault(t => t.RollNumber == rollNumber);
        }

        public void DeleteStudent(int id)
        {
            _connection.Delete<Student>(id);
        }

        public void AddStudent(Student newStudent)
        {
            _connection.Insert(newStudent);
        }
    }
}