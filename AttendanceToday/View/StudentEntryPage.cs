using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AttendanceToday.View
{
    public class StudentEntryPage : ContentPage {
        private StudentListPage _parent;
        private Data.AttendanceDatabase _database;
 
        public StudentEntryPage(StudentListPage parent, Data.AttendanceDatabase database)
        {
            _parent = parent;
            _database = database;
            Title = "Enter Student Data";
 
            var entry = new Entry ();
            var entry2 = new Entry();

            var button = new Button {
                Text = "Add"
            };
 
            button.Clicked += async (object sender, EventArgs e) => {
                Data.Student student = new Data.Student();
                student.RollNumber = entry.Text;
                student.Name = entry2.Text;
 
                _database.AddStudent(student);
 
                await Navigation.PopAsync();
 
 
                _parent.Refresh();
            };
 
            Content = new StackLayout {
                Spacing = 20,
                Padding = new Thickness(20),
                Children = { entry, entry2, button },
            };
        }
    }
}