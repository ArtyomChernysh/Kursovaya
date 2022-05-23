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
using Word = Microsoft.Office.Interop.Word;
namespace RegastrationOfTheWeddingOrganizer.Settings
{
    /// <summary>
    /// Логика взаимодействия для ArchivePage.xaml
    /// </summary>
    public partial class ArchivePage : Page
    {
        public ArchivePage()
        {
            InitializeComponent();
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            List<ArchiveWedding> weddings = WorkDB.SelectDBWArchive("Table_Archive");
            foreach (ArchiveWedding wedd in weddings)
            {
                ListBox.Items.Add(wedd.WeddingName);
            }
        }
        private void ListBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            List<ArchiveWedding> weddings = WorkDB.SelectDBWArchive("Table_Archive");
            foreach (ArchiveWedding wedd in weddings)
            {
                if (ListBox.SelectedItem != null && ListBox.SelectedItem.ToString() == wedd.WeddingName)
                {
                    string text = "Наименование свадьбы: " + wedd.WeddingName + "\n" +
                    "Дата начала свадьбы: " + Convert.ToDateTime(wedd.WeddingStartDate).ToShortDateString() + "\n" +
                    "Дата конца свадьбы: " + Convert.ToDateTime(wedd.WeddingEndDate).ToShortDateString() + "\n" +
                    "Дата записи в архив: " + Convert.ToDateTime(wedd.WeddingRecordDate).ToShortDateString() + "\n" +
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

        private void Export(object sender, RoutedEventArgs e)
        {
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Add(Visible: false);
            Word.Range r = doc.Range();
            Wedding w = null;
            if (ListBox.SelectedItem != null)
            {
                var slc = ListBox.SelectedItem.ToString();
                int id = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM Table_Archive WHERE Name=N'{slc}'", "Id"));
                w = WorkDB.CopyAllArchive(id);
            }
            else
            {
                MessageBox.Show("Выберите свадьбу для экспорта");
            }
            r.Text = $"\t\tОтчет о проведении \"{w.WeddingName}\"\n\nДата начала свадьбы: {Convert.ToDateTime(w.WeddingStartDate).ToShortDateString()}\nДата конца свадьбы: {Convert.ToDateTime(w.WeddingEndDate).ToShortDateString()}\n{WorkDB.UsingWeddingsCodes(w.Codes)}\nИтоговая цена к оплате за свадьбу: {w.Cost}\n\n\nПодпись организатора ______________\tПечать организатора ______________";
            doc.Save();
            doc.Close();
            app.Quit();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var selected = ListBox.SelectedItems.Cast<Object>().ToArray();
            List<string> users = new List<string>();
            foreach (string item in selected)
            {
                users.Add(item);
                ListBox.Items.Remove(item);
            }
            WorkDB.DeleteArchive("Table_Archive", users);
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            Wedding w = null;
            if (ListBox.SelectedItem != null)
            {
                var slc = ListBox.SelectedItem.ToString();
                int id = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM Table_Archive WHERE Name=N'{slc}'", "Id"));
                w = WorkDB.CopyAllArchive(id);
            }
            else
            {
                MessageBox.Show("Выберите свадьбу для возврата");
            }
            DateTime wsb = DateTime.Parse(w.WeddingStartDate);
            DateTime web = DateTime.Parse(w.WeddingEndDate);
            WorkDB.UpdateDB($"INSERT INTO Table_Wedding(WeddingName,WeddingStartDatetime,WeddingEndDatetime,Cost,Codes) VALUES (N'{w.WeddingName}',N'{wsb.Year}-{wsb.Month}-{wsb.Day}',N'{web.Year}-{web.Month}-{web.Day}',{w.Cost},N'{w.Codes}')");
            var selected = ListBox.SelectedItems.Cast<Object>().ToArray();
            List<string> users = new List<string>();
            foreach (string item in selected)
            {
                users.Add(item);
                ListBox.Items.Remove(item);
            }
            WorkDB.FullWedding("Table_Archive", users);
            MessageBox.Show("Возвращение прошло успешно");
        }
    }
}
