using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json.Serialization;

namespace Nastol
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {

        public Menu()
        {
            InitializeComponent();
            UpdateData();

        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            AuthUser window = new AuthUser();
            window.Show();
            Close();
        }

        private void UpdateData()
        {
            TextName.Text = CurrentUser.user.Name;
            TextSurname.Text = CurrentUser.user.Surname;
            TextPatronomic.Text = CurrentUser.user.Patronomic;
            TextDateofBirth.Text = CurrentUser.user.DateofBirth;
            TextEnterprice.Text = CurrentUser.user.Enterprice;
        }
        private void UpdateBut(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private async void SaveData(object sender, RoutedEventArgs e)
        {
            string url = "https://apis.api-mauijobs.site/Users";
            string urlLocal = "https://localhost:25565/Auth";

            SaveButt.IsEnabled = false;

            CurrentUser.user.Name = TextName.Text;
            CurrentUser.user.Surname = TextSurname.Text;
            CurrentUser.user.Patronomic = TextPatronomic.Text;
            CurrentUser.user.DateofBirth = TextDateofBirth.Text;
            CurrentUser.user.Enterprice = TextEnterprice.Text;


            string json = JsonConvert.SerializeObject(CurrentUser.user);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var a = await responseContent.ReadAsStringAsync();
                CurrentUser.user = JsonConvert.DeserializeObject<User>(a);
                UpdateData();
                SaveButt.IsEnabled = true;
            }
        }
        private void UsersClick(object sender, RoutedEventArgs e)
        {
            UsersGrid secondWindow = new UsersGrid();
            secondWindow.Show();
            Close();
        }


        private void TaskButtClick(object sender, RoutedEventArgs e)
        {
            TasksTable window = new TasksTable();
            window.Show();
            Close();
        }
    }
}
