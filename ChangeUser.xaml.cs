using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nastol
{
    /// <summary>
    /// Логика взаимодействия для ChangeUser.xaml
    /// </summary>
    public partial class ChangeUser : Window
    {
        private User _user;
        public ChangeUser(User user)
        {
            InitializeComponent();
            _user = user;
            UpdateUser();
        }

      private void UpdateUser()
        {
            TextLogin.Text = _user.Login;
            TextPass.Text = _user.Password;
            TextName.Text = _user.Name;
            TextSurname.Text = _user.Surname;
            TextPatronomic.Text = _user.Patronomic;
            TextDateofBirth.Text = _user.DateofBirth;
            TextEnterprice.Text = _user.Enterprice;
        }

        private void BackButt_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser();
            Window secondWindow = new UsersGrid();
            secondWindow.Show();
            Close();
        }

        private async void SaveData(object sender, RoutedEventArgs e)
        {
            string url = "https://apis.api-mauijobs.site/Users";  

            SaveButt.IsEnabled = false;

            _user.Login = TextName.Text;
            _user.Name = TextName.Text;
            _user.Surname = TextSurname.Text;
            _user.Patronomic = TextPatronomic.Text;
            _user.DateofBirth = TextDateofBirth.Text;
            _user.Enterprice = TextEnterprice.Text;


            string json = JsonConvert.SerializeObject(_user);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var a = await responseContent.ReadAsStringAsync();

                Window secondWindow = new UsersGrid();
                secondWindow.Show();
                Close();
            }
        }
    }
}
