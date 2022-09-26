using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nastol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private string _isAuth = "1";

        private void AuthClick(object sender, RoutedEventArgs e)
        {
  /*          string postParameters = "login=" + GetHash(LoginUser.Text) + "&password=" + GetHash(PassUser.Password); //Поменять если чо пароль
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apis.api-mauijobs.site/Auth?" + postParameters);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    _isAuth = reader.ReadToEnd();
                }
            }
            response.Close();*/

            if (_isAuth != "")
            {

              //  var obj = JsonConvert.DeserializeObject<User>(_isAuth);
                var obj = new User()
                {
                    Password = "2",
                    Login = "1",
                    ID = 2,
                    Name = "ABa",
                    Surname = "11",
                    Patronomic = "fff",
                    Enterprice = "addd.",
                    DateofBirth = new DateTime()
                };
                Window secondWindow = new Menu(obj);
                secondWindow.Show();
                this.Close();
                //переход
            }
        }
    }
}
