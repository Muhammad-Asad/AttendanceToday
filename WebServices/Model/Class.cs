using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceToday.Model
{
    [Table("Class")]
    public class Class
    {
        public long ID { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }

        public Class()
        {
        }
    }
}
