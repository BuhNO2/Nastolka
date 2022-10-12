using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;

namespace Nastol
{
    /// <summary>
    /// Логика взаимодействия для UsersGrid.xaml
    /// </summary>
    public partial class UsersGrid : Window
    {
        User user;
        public UsersGrid(User user)
        {
            InitializeComponent();
            this.user = user;
            ResizeMode = ResizeMode.NoResize;
            ResizeMode = ResizeMode.CanMinimize;

            TableInfo();


        }

        private async void TableInfo()
        {
            string url = "https://apis.api-mauijobs.site/Auth";
            string urlLocal = "https://localhost:25565/Auth";
            User ArrayUsers = new User()
            {
                ID = 1,
                Login = "",
                Password = "",
                Enterprice = "",
                Surname = "",
                Name = "",
                Patronomic = "",
                DateofBirth = "",
                RoleId = 3
            };
           
            string json = JsonConvert.SerializeObject(ArrayUsers);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");
            HttpResponseMessage response = await client.PostAsync(urlLocal, content);

            HttpContent responseContent = response.Content;
            var    a = await responseContent.ReadAsStringAsync();
            UGrid.AutoGenerateColumns = true;
            //UGrid = (DataGrid)JsonConvert.DeserializeObject(a, (typeof(DataGrid)));
            
            User[] UserItems = JsonConvert.DeserializeObject<User[]>(a);
            UGrid.ItemsSource = UserItems;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Menu window = new Menu(user);
            window.Show();
            this.Close();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            TableInfo();
        }
    }
}
