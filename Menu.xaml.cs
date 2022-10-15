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
        User user;
        public Menu(User user)
        {
            InitializeComponent();
            this.user = user;
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
            TextName.Text = user.Name;
            TextSurname.Text = user.Surname;
            TextPatronomic.Text = user.Patronomic;
            TextDateofBirth.Text = user.DateofBirth;
            TextEnterprice.Text = user.Enterprice;
        }
        private void UpdateBut(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private async void SaveData(object sender, RoutedEventArgs e)
        {
            string url = "https://apis.api-mauijobs.site/Auth";
            string urlLocal = "https://localhost:25565/Auth";

            User UserData = new User()
            {
                ID = user.ID,
                Name = TextName.Text,
                Surname = TextSurname.Text,
                Patronomic = TextPatronomic.Text,
                DateofBirth = TextDateofBirth.Text,
                Enterprice = TextEnterprice.Text,
            };

            string json = JsonConvert.SerializeObject(UserData);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var a = await responseContent.ReadAsStringAsync();
                UserData = JsonConvert.DeserializeObject<User>(a);

            }
        }
        private void UsersClick(object sender, RoutedEventArgs e)
        {
            UsersGrid secondWindow = new UsersGrid(user);
            secondWindow.Show();
            Close();
        }

        private void MarksClick(object sender, RoutedEventArgs e)
        {
            TasksTable window = new TasksTable(user);
            window.Show();
            Close();
        }
    }
}
