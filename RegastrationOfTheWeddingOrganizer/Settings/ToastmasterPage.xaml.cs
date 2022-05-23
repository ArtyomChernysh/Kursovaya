using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RegastrationOfTheWeddingOrganizer.Settings
{
    /// <summary>
    /// Логика взаимодействия для ChefPage.xaml
    /// </summary>
    public partial class ToastmasterPage : Page
    {
        List<User> users = null;
        public ToastmasterPage()
        {
            InitializeComponent();
        }
        private void FillListView(List<User> users)
        {
            foreach (User u in users)
            {
                list.Items.Add(u);
            }
        }
        private void ListViewLoaded(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
            users = WorkDB.SelectDB("Toastmaster");
            FillListView(users);
        }

        private void DeleteSelected(object sender, RoutedEventArgs e)
        {
            var selected = list.SelectedItems.Cast<Object>().ToArray();
            users.Clear();
            foreach (User item in selected)
            {
                users.Add(item);
                list.Items.Remove(item);
            }
            WorkDB.FullReupate("Toastmaster", users);
        }

        private void FillData(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameBox.Text.Length > 0 && Convert.ToInt32(CostBox.Text) > -1)
                {
                    WorkDB.UpdateDB($"INSERT INTO Toastmaster(Name,Cost) VALUES(N'{NameBox.Text}',N'{Convert.ToInt32(CostBox.Text)}')");
                    MessageBox.Show("Запись проведена успешно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
