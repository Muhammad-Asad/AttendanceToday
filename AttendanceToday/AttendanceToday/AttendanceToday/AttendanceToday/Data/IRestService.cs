using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceToday.Data
{
	public interface IRestService
	{
		Task<List<Student>> RefreshDataAsync ();

		Task SaveStudentAsync (Student student, bool isNewItem);

		Task DeleteStudentAsync (string id);
	}
}
