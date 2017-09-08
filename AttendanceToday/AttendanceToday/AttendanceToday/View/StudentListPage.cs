using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttendanceToday.Data;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AttendanceToday.View
{
    public class StudentListPage : ContentPage
    {
        private AttendanceDatabase _database;
        private ListView _studentList;

        public StudentListPage(AttendanceDatabase database)
        {
            _database = database;
            Title = "Students";
            var students = _database.GetStudents();

            _studentList = new ListView();
            _studentList.ItemsSource = students;
            _studentList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _studentList.ItemTemplate.SetBinding(TextCell.TextProperty, "RollNumber");
            _studentList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Name");

            var toolbarItem = new ToolbarItem
            {
                Text = "Add",
                Command = new Command(() => Navigation.PushAsync(new StudentEntryPage(this, database)))
            };

            ToolbarItems.Add(toolbarItem);

            var syncToolbarItem1 = new ToolbarItem
            {
                Text = "Sync Students Data",
                Command = new Command(SyncStudentData, CanExecuteSyncStudentData)
            };


            ToolbarItems.Add(syncToolbarItem1);

            var toolbarItem1 = new ToolbarItem
            {
                Text = "Mark Attendance",
                Command = new Command(() => Navigation.PushAsync(new MainPage(this, database)))
            };

            ToolbarItems.Add(toolbarItem1);

            Content = _studentList;
        }

        private void SyncStudentData(object parameter)
        {   
             
        }

        private async Task<string> GetCustomersAsync()
        {
            
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://10.0.0.17:55365/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Customers");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else return response.ReasonPhrase;



            //var rxcui = "198440";
            //var request = HttpWebRequest.Create(string.Format(@"http://rxnav.nlm.nih.gov/REST/RxTerms/rxcui/{0}/allinfo", rxcui));
            //request.ContentType = "application/json";
            //request.Method = "GET";

            //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //{
            //    if (response.StatusCode != HttpStatusCode.OK)
            //        Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
            //    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //    {
            //        var content = reader.ReadToEnd();
            //        if (string.IsNullOrWhiteSpace(content))
            //        {
            //            Console.Out.WriteLine("Response contained empty body...");
            //        }
            //        else
            //        {
            //            Console.Out.WriteLine("Response Body: \r\n {0}", content);
            //        }

            //        //Assert.NotNull(content);
            //    }
            //}

            //return string.Empty;


        }

        private bool CanExecuteSyncStudentData(object parameter)
        {
            return true;
        }

        public void Refresh()
        {
            _studentList.ItemsSource = _database.GetStudents();
        }
    }

}