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

namespace RegastrationOfTheWeddingOrganizer
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        bool IsSettings;
        public Authorization(bool isSettings)
        {
            InitializeComponent();
            IsSettings = isSettings;
        }

        private void OpenMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mw=new MainWindow();
            mw.Show();
            this.Close();
        }

        private void LoginIntoApp(object sender, RoutedEventArgs e)
        {
            string login = Convert.ToString(loginBox.Text);
            string password = Convert.ToString(passwordBox.Password);
            if(WorkDB.SelectWhereId("!!!ADMIN!!!", "1", login, password))
            {
                if (IsSettings)
                {
                    Settings.SettingsMenu wm = new Settings.SettingsMenu();
                    wm.Show();
                    this.Close();
                }
                else
                {
                    WeddingsMenu wm = new WeddingsMenu();
                    wm.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Введенные данные некорректны, попробуйте ещё раз");
            }
        }
    }
}
