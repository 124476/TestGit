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
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain(User user)
        {
            InitializeComponent();
            if (user.RoleId == 2)
            {
                New.Visibility = Visibility.Hidden;
                Del.Visibility = Visibility.Hidden;
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewUser());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            User user = DataUsers.SelectedItem as User;
            if (user != null)
            {
                App.DB.User.Remove(user);
                App.DB.SaveChanges();
                Refresh();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            DataUsers.ItemsSource = App.DB.User.ToList();
        }
    }
}
