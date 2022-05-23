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

namespace RegastrationOfTheWeddingOrganizer.Settings
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void ChangeAdministrator(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Text;
            if (LoginBox.Text.Length>0&&PasswordBox.Text.Length>0)
            {
                WorkDB.UpdateDB($"UPDATE [!!!ADMIN!!!] SET Login = {login}, Password = {password} WHERE Id=1;");
                MessageBox.Show("Логин и пароль изменены");
            }
            else if(LoginBox.Text.Length > 0)
            {
                WorkDB.UpdateDB($"UPDATE [!!!ADMIN!!!] SET Login = {login} WHERE Id=1;");
                MessageBox.Show("Логин изменен");
            }
            else if(PasswordBox.Text.Length > 0)
            {
                WorkDB.UpdateDB($"UPDATE [!!!ADMIN!!!] SET Password = {password} WHERE Id=1;");
                MessageBox.Show("Пароль изменен");
            }
            else
            {
                MessageBox.Show("Поля для ввода пустые, введите данные для замены");
            }
        }
    }
}
