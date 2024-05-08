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
    /// Логика взаимодействия для PageNewUser.xaml
    /// </summary>
    public partial class PageNewUser : Page
    {
        public PageNewUser()
        {
            InitializeComponent();
            ComboRoles.ItemsSource = App.DB.Role.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != null && Password.Text != null && ComboRoles.SelectedIndex != -1)
            {
                User user = new User();
                user.Name = Name.Text;
                user.Password = Password.Text;
                user.Role = ComboRoles.SelectedItem as Role;
                App.DB.User.Add(user);
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
