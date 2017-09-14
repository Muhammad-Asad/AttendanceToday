using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceToday.Model
{
    [Table("Student")]
    public class Student
    {
        public long ID { get; set; }
        public string RollNumber { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string ContactNumber { get; set; }

        public Student()
        {
        }
    }

    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
    }

}