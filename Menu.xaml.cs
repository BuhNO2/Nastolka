using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        User user;
        public Menu(User user)
        {
            InitializeComponent();
            this.user = user;
           ResizeMode = ResizeMode.NoResize;
            ResizeMode = ResizeMode.CanMinimize;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
           Window window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void UpdateBut(object sender, RoutedEventArgs e)
        {
            TextName.Text = user.Name;
            TextSurname.Text = user.Surname;
            TextPatronomic.Text = user.Patronomic;
            TextDateofBirth.Text = user.DateofBirth.ToString();
            TextEnterprice.Text = user.Enterprice;
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            bool isOkay;
            string jsonString = JsonSerializer.Serialize<User>(new User()
            {
                ID = user.ID,
                Name = TextName.Text,
                Surname = TextSurname.Text,
                Patronomic = TextPatronomic.Text,
                DateofBirth = DateTime.Parse(TextDateofBirth.Text),
                Enterprice = TextEnterprice.Text,
            });

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apis.api-mauijobs.site/Users?" + jsonString);
            request.Method = "POST";
            request.ContentType = "text/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    isOkay = Convert.ToBoolean(reader.ReadToEnd());
                }
            }
            response.Close();

        }

        private void UsersClick(object sender, RoutedEventArgs e)
        {
            Window secondWindow = new UsersGrid();
            secondWindow.Show();
            this.Close();
        }
    }
}
