﻿using Newtonsoft.Json;
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

        private string _isAuth = "";

        private async void AuthClick(object sender, RoutedEventArgs e)
        {
            /*    if (LoginUser.Text == null || PassUser.Text == null)
                    return;*/

            string url = "https://apis.api-mauijobs.site/Auth";
            string urlLocal = "https://localhost:25565/Auth";

            User userAuth = new User()
            {
                ID = 1,
                Login = GetHash(LoginUser.Text),
                Password = GetHash(PassUser.Password),
                Enterprice = "",
                Surname = "",
                Name = "",
                Patronomic = "",
                DateofBirth = ""
            };

            User newUser = new User();

            string json = JsonConvert.SerializeObject(userAuth);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");
            HttpResponseMessage response = await client.PostAsync(urlLocal, content);
           
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var a = await responseContent.ReadAsStringAsync();   
                newUser = JsonConvert.DeserializeObject<User>(a);
            }






            Window secondWindow = new Menu(newUser);
            secondWindow.Show();
            Close();
        }

    }
}