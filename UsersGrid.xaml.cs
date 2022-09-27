using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для UsersGrid.xaml
    /// </summary>
    public partial class UsersGrid : Window
    {
        public UsersGrid()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            ResizeMode = ResizeMode.CanMinimize;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            AuthUser window = new AuthUser();
            window.Show();
            this.Close();
        }
    }
}
