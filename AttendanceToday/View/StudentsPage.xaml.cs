using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AttendanceToday.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsPage : ContentPage
    {
        private StudentListPage _parent;
        private Data.AttendanceDatabase _database;

        public StudentsPage()
        {
            InitializeComponent();
        }
        public StudentsPage(StudentListPage parent, Data.AttendanceDatabase database)
        {
            _parent = parent;
            _database = database;
        }
    }
}