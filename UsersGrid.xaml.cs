using Newtonsoft.Json;
using System;
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
            string url = "https://apis.api-mauijobs.site/Users";
           
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            HttpContent responseContent = response.Content;
            var    a = await responseContent.ReadAsStringAsync();
            UGrid.AutoGenerateColumns = true;        
            User[] UserItems = JsonConvert.DeserializeObject<User[]>(a);
            UGrid.ItemsSource = UserItems;
/*            DatePicker datePicker = new DatePicker();
            UGrid.Columns[7].CellStyle = ;*/
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
