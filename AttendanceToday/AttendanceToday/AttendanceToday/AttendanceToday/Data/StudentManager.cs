using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceToday.Data
{
    public class StudentManager
    {
        IRestService restService;

        public StudentManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Student>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Student student, bool isNewItem = false)
        {
            return restService.SaveStudentAsync(student, isNewItem);
        }

        public Task DeleteTaskAsync(Student student)
        {
            return restService.DeleteStudentAsync(student.ID.ToString());
        }
    }
}
