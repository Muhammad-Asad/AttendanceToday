using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AttendanceToday
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MainPage = new AttendanceToday.MainPage();
            var database = new Data.AttendanceDatabase();
            MainPage = new NavigationPage(new View.StudentListPage(database));

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
