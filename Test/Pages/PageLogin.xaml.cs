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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test.Models;

namespace Test.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            User user = App.DB.User.FirstOrDefault(x => x.Name == Name.Text && x.Password == Password.Text);
            if (user != null)
            {
                NavigationService.Navigate(new PageMain(user));
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
