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
    /// Логика взаимодействия для WeddingsMenu.xaml
    /// </summary>
    public partial class WeddingsMenu : Window
    {
        public WeddingsMenu()
        {
            InitializeComponent();
        }
        private void ListBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Wedding> weddings = WorkDB.SelectDBWedding("Table_Wedding");
            foreach (Wedding wedd in weddings)
            {
                if (ListBox.SelectedItem != null && ListBox.SelectedItem.ToString() == wedd.WeddingName)
                {
                    string text = "Наименование свадьбы: "+ wedd.WeddingName + "\n" +
                    "Дата начала свадьбы: " + Convert.ToDateTime(wedd.WeddingStartDate).ToShortDateString() + "\n" +
                    "Дата конца свадьбы: " + Convert.ToDateTime(wedd.WeddingEndDate).ToShortDateString() + "\n" +
                    "Цена свадьбы: " + wedd.Cost + "\n" +
                    WorkDB.UsingWeddingsCodes(wedd.Codes);
                    WeddingText.Text = text;
                    break;
                }
                else
                {
                    WeddingText.Text = " ";
                }
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            List<Wedding> weddings = WorkDB.SelectDBWedding("Table_Wedding");
            foreach (Wedding wedd in weddings)
            {
                ListBox.Items.Add(wedd.WeddingName);
            }
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void AddWedding(object sender, RoutedEventArgs e)
        {
            Add a = new Add();
            a.Show();
            this.Close();
        }

        private void DeleteSelected(object sender, RoutedEventArgs e)
        {
            var selected = ListBox.SelectedItems.Cast<Object>().ToArray();
            List<string> users=new List<string>();
            foreach (string item in selected)
            {
                users.Add(item);
                ListBox.Items.Remove(item);
            }
            WorkDB.FullReupate("Table_Wedding", users);
        }

        private void UpdateWedding(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                var selected = ListBox.SelectedItem.ToString();
                int id = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE WeddingName=N'{selected}'","Id"));
                UpdateMenu um = new UpdateMenu(id);
                um.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите свадьбу для обновления");
            }
        }

        private void RecordArchive(object sender, RoutedEventArgs e)
        {
            Wedding w = null;
            if (ListBox.SelectedItem != null)
            {
                var slc = ListBox.SelectedItem.ToString();
                int id = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE WeddingName=N'{slc}'", "Id"));
                w = WorkDB.CopyAllWedding(id);
                DateTime wsb = DateTime.Parse(w.WeddingStartDate);
                DateTime web = DateTime.Parse(w.WeddingEndDate);
                DateTime wnb = DateTime.Now;
                WorkDB.UpdateDB($"INSERT INTO Table_Archive(Name,WeddingStartDatetime,WeddingEndDatetime,WeddingRecordDate,Cost,Codes) VALUES (N'{w.WeddingName}',N'{wsb.Year}-{wsb.Month}-{wsb.Day}',N'{web.Year}-{web.Month}-{web.Day}',N'{wnb.Year}-{wnb.Month}-{wnb.Day}',{w.Cost},N'{w.Codes}')");
                var selected = ListBox.SelectedItems.Cast<Object>().ToArray();
                List<string> users = new List<string>();
                foreach (string item in selected)
                {
                    users.Add(item);
                    ListBox.Items.Remove(item);
                }
                WorkDB.FullArchive("Table_Wedding", users);
                MessageBox.Show("Запись в архив прошла успешно");
            }
            else
            {
                MessageBox.Show("Выберите свадьбу для архива");
            }
            
        }
    }
}
