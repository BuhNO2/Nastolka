using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Nastol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthUser : Window
    {
        public AuthUser()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            ResizeMode = ResizeMode.CanMinimize;
        }
        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return BitConverter.ToString(hash).Replace("-", "");
        }


        private async void AuthClick(object sender, RoutedEventArgs e)
        {
            AuthButt.IsEnabled = false;
            string url = "https://apis.api-mauijobs.site/Auth";
            string urlLocal = "https://localhost:25565/Auth";
           User userAuth = new User()
            {
                ID = 1,
                Login = LoginUser.Text,
                Password = GetHash(PassUser.Password),
                Enterprice = "",
                Surname = "",
                Name = "",
                Patronomic = "",
                DateofBirth = "",
                RoleId = 3
            };
            User newUser = new User();

            string json = JsonConvert.SerializeObject(userAuth);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var a = await responseContent.ReadAsStringAsync();
                CurrentUser.user = JsonConvert.DeserializeObject<User>(a);

                Window secondWindow = new Menu();
                secondWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show(" Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                AuthButt.IsEnabled = true;
            }

        }

    }
}
