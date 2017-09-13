using AttendanceToday.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AttendanceToday
{
    public partial class MainPage : ContentPage
    {
        private StudentListPage _parent;
        private Data.AttendanceDatabase _database;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(StudentListPage parent, Data.AttendanceDatabase database)
        {
            _parent = parent;
            _database = database;
            Title = "Attandence";
        }
    }
}
