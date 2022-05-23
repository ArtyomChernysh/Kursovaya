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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
            WeddingGuestNumberBox.Text = "0";
        }

        private void CostChanging()
        {
            try
            {
                if (Convert.ToString(WeddingFoodQualityBox.Text) == "Мало")
                    WeddingFoodCostBox.Content = 10 * Convert.ToInt32(WeddingGuestNumberBox.Text);
                if (Convert.ToString(WeddingFoodQualityBox.Text) == "Нормально")
                    WeddingFoodCostBox.Content = 30 * Convert.ToInt32(WeddingGuestNumberBox.Text);
                if (Convert.ToString(WeddingFoodQualityBox.Text) == "Много")
                    WeddingFoodCostBox.Content = 60 * Convert.ToInt32(WeddingGuestNumberBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WeddingFoodQualityBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CostChanging();
        }

        private void WeddingGuestNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CostChanging();
        }

        private void WeddingFoodQualityBox_DropDownClosed(object sender, EventArgs e)
        {
            CostChanging();
        }
        private void WindowInitialized(object sender, EventArgs e)
        {
            WeddingStartBox.Text = DateTime.Now.ToShortDateString();
            WeddingEndBox.Text = DateTime.Now.AddDays(1).ToShortDateString();
            MailHaircutBox.Items.Clear();
            MailSuitBox.Items.Clear();
            MailMakeupBox.Items.Clear();
            MailRingBox.Items.Clear();
            FemailHaircutBox.Items.Clear();
            FemailSuitBox.Items.Clear();
            FemailMakeupBox.Items.Clear();
            FemailRingBox.Items.Clear();
            EntertainmentToastmasterBox.Items.Clear();
            EntertainmentChefBox.Items.Clear();
            EntertainmentDJBox.Items.Clear();
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Haircut]"))
                MailHaircutBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Suit]"))
                MailSuitBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Makeup]"))
                MailMakeupBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Ring]"))
                MailRingBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Haircut]"))
                FemailHaircutBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Suit]"))
                FemailSuitBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Makeup]"))
                FemailMakeupBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Ring]"))
                FemailRingBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Toastmaster]"))
                EntertainmentToastmasterBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [Chef]"))
                EntertainmentChefBox.Items.Add(i);
            foreach (string i in WorkDB.ComboboxDB("SELECT * FROM [DJ]"))
                EntertainmentDJBox.Items.Add(i);
        }

        private void GridLoaded(object sender, RoutedEventArgs e)
        {
            int sum = Convert.ToInt32(ChefCost.Content) + Convert.ToInt32(DJCost.Content) + Convert.ToInt32(ToastmasterCost.Content) + Convert.ToInt32(WeddingFoodCostBox.Content) + Convert.ToInt32(FemaleHaircutCost.Content) + Convert.ToInt32(FemaleMakeupCost.Content) + Convert.ToInt32(FemaleRingCost.Content) + Convert.ToInt32(FemaleSuitCost.Content) + Convert.ToInt32(MaleHaircutCost.Content) + Convert.ToInt32(MaleMakeupCost.Content) + Convert.ToInt32(MaleRingCost.Content) + Convert.ToInt32(MaleSuitCost.Content);
            ResultBox.Text = "Название свадьбы: " + WeddingNameBox.Text + "\n";
            ResultBox.Text += "Дата начала свадьбы: " + WeddingStartBox.Text + "\n";
            ResultBox.Text += "Дата конца свадьбы: " + WeddingEndBox.Text + "\n";
            ResultBox.Text += "Стрижка жениха: " + MailHaircutBox.Text + "\n";
            ResultBox.Text += "Костюм жениха: " + MailSuitBox.Text + "\n";
            ResultBox.Text += "Макияж жениха: " + MailMakeupBox.Text + "\n";
            ResultBox.Text += "Кольцо жениха: " + MailRingBox.Text + "\n";
            ResultBox.Text += "Стрижка невесты: " + FemailHaircutBox.Text + "\n";
            ResultBox.Text += "Костюм невесты: " + FemailSuitBox.Text + "\n";
            ResultBox.Text += "Макияж невесты: " + FemailMakeupBox.Text + "\n";
            ResultBox.Text += "Кольцо невесты: " + FemailRingBox.Text + "\n";
            ResultBox.Text += "Тамада: " + EntertainmentToastmasterBox.Text + "\n";
            ResultBox.Text += "Шеф-повар: " + EntertainmentChefBox.Text + "\n";
            ResultBox.Text += "Диджей: " + EntertainmentDJBox.Text + "\n";
            ResultBox.Text += "Качество еды: " + WeddingFoodQualityBox.Text + "\n";
            ResultBox.Text += "Цена еды: " + WeddingFoodCostBox.Content + "\n";
            ResultBox.Text += "Количество еды: " + WeddingGuestNumberBox.Text + "\n";
            ResultBox.Text += "Финальная цена за свадьбу: " + sum;
        }

        private void EndDateClosed(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(WeddingEndBox.Text) < Convert.ToDateTime(WeddingStartBox.Text))
                {
                    string dt = Convert.ToString(WeddingEndBox.Text);
                    WeddingEndBox.Text = WeddingStartBox.Text;
                    WeddingStartBox.Text = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenWeddingMenu(object sender, RoutedEventArgs e)
        {
            WeddingsMenu wm = new WeddingsMenu();
            wm.Show();
            this.Close();
        }

        private void AddDB(object sender, RoutedEventArgs e)
        {
            int sum = Convert.ToInt32(ChefCost.Content) + Convert.ToInt32(DJCost.Content) + Convert.ToInt32(ToastmasterCost.Content) + Convert.ToInt32(WeddingFoodCostBox.Content) + Convert.ToInt32(FemaleHaircutCost.Content) + Convert.ToInt32(FemaleMakeupCost.Content) + Convert.ToInt32(FemaleRingCost.Content) + Convert.ToInt32(FemaleSuitCost.Content) + Convert.ToInt32(MaleHaircutCost.Content) + Convert.ToInt32(MaleMakeupCost.Content) + Convert.ToInt32(MaleRingCost.Content) + Convert.ToInt32(MaleSuitCost.Content);
            WorkDB.UpdateDB($"INSERT INTO Table_NewlywedSet(Haircut,Makeup,Suit,Ring) VALUES(" +
                $"{WorkDB.CopyId($"SELECT * FROM [Haircut] WHERE Name=N'{MailHaircutBox.Text}'")}," +
                $"{WorkDB.CopyId($"SELECT * FROM [Makeup] WHERE Name=N'{MailMakeupBox.Text}'")}," +
                $"{WorkDB.CopyId($"SELECT * FROM [Suit] WHERE Name=N'{MailSuitBox.Text}'")}," +
                $"{WorkDB.CopyId($"SELECT * FROM [Ring] WHERE Name=N'{MailRingBox.Text}'")})");
           int id1=WorkDB.FindId("SELECT MAX(id) FROM Table_NewlywedSet");
            WorkDB.UpdateDB($"INSERT INTO Table_NewlywedSet(Haircut,Makeup,Suit,Ring) VALUES(" +
                $"{WorkDB.CopyId($"SELECT * FROM [Haircut] WHERE Name=N'{FemailHaircutBox.Text}'")}," +
                $"{WorkDB.CopyId($"SELECT * FROM [Makeup] WHERE Name=N'{FemailMakeupBox.Text}'")}," +
                $"{WorkDB.CopyId($"SELECT * FROM [Suit] WHERE Name=N'{FemailSuitBox.Text}'")}," +
                $"{WorkDB.CopyId($"SELECT * FROM [Ring] WHERE Name=N'{FemailRingBox.Text}'")})");
            int id2 = WorkDB.FindId("SELECT MAX(id) FROM Table_NewlywedSet");
            WorkDB.UpdateDB($"INSERT INTO Table_Entertainment(Toastmaster,Chef,DJ) VALUES(" +
                $"{WorkDB.CopyId($"SELECT * FROM [Toastmaster] WHERE Name=N'{(EntertainmentToastmasterBox.Text)}'")}," +
                $"{WorkDB.CopyId($"SELECT * FROM [Chef] WHERE Name=N'{(EntertainmentChefBox.Text)}'")}," +
                $"{WorkDB.CopyId($"SELECT * FROM [DJ] WHERE Name=N'{(EntertainmentDJBox.Text)}'")})");
            int id3 = WorkDB.FindId("SELECT MAX(id) FROM Table_Entertainment");
            WorkDB.UpdateDB($"INSERT INTO Table_Banquet(foodQuality,foodCost,guestsNumber) VALUES(N'{WeddingFoodQualityBox.Text}',N'{WeddingFoodCostBox.Content}',N'{WeddingGuestNumberBox.Text}')");
            int id4 = WorkDB.FindId("SELECT MAX(id) FROM Table_Banquet");
            string ideas = $"{id1} {id2} {id3} {id4}";
            DateTime wsb= DateTime.Parse(WeddingStartBox.Text);
            DateTime web = DateTime.Parse(WeddingEndBox.Text);
            WorkDB.UpdateDB($"INSERT INTO Table_Wedding(WeddingName,WeddingStartDatetime,WeddingEndDatetime,Cost,Codes) VALUES(" +
                $"N'{WeddingNameBox.Text}'," +
                $"N'{wsb.Year}-{wsb.Month}-{wsb.Day}'" +
                $",N'{web.Year}-{web.Month}-{web.Day}'," +
                $"{sum}," +
                $"N'{ideas}')");
            MessageBox.Show("Запись проведена успешно");
        }
    
        private void NewMailHaircutCost(object sender, EventArgs e)
        {
            MaleHaircutCost.Content = WorkDB.CopyCost($"SELECT * FROM [Haircut] WHERE Name=N'{MailHaircutBox.Text}'");
        }
        private void NewMailMakeupCost(object sender, EventArgs e)
        {
            MaleMakeupCost.Content = WorkDB.CopyCost($"SELECT * FROM [Makeup] WHERE Name=N'{MailMakeupBox.Text}'");
        }
        private void NewMailSuitCost(object sender, EventArgs e)
        {
            MaleSuitCost.Content = WorkDB.CopyCost($"SELECT * FROM [Suit] WHERE Name=N'{MailSuitBox.Text}'");
        }
        private void NewMailRingCost(object sender, EventArgs e)
        {
            MaleRingCost.Content = WorkDB.CopyCost($"SELECT * FROM [Ring] WHERE Name=N'{MailRingBox.Text}'");
        }
        private void NewFemailHaircutCost(object sender, EventArgs e)
        {
            FemaleHaircutCost.Content = WorkDB.CopyCost($"SELECT * FROM [Haircut] WHERE Name=N'{FemailHaircutBox.Text}'");
        }
        private void NewFemailMakeupCost(object sender, EventArgs e)
        {
            FemaleMakeupCost.Content = WorkDB.CopyCost($"SELECT * FROM [Makeup] WHERE Name=N'{FemailMakeupBox.Text}'");
        }
        private void NewFemailSuitCost(object sender, EventArgs e)
        {
            FemaleSuitCost.Content = WorkDB.CopyCost($"SELECT * FROM [Suit] WHERE Name=N'{FemailSuitBox.Text}'");
        }
        private void NewFemailRingCost(object sender, EventArgs e)
        {
            FemaleRingCost.Content = WorkDB.CopyCost($"SELECT * FROM [Ring] WHERE Name=N'{FemailRingBox.Text}'");
        }
        private void NewToastmasterCost(object sender, EventArgs e)
        {
            ToastmasterCost.Content = WorkDB.CopyCost($"SELECT * FROM [Toastmaster] WHERE Name=N'{EntertainmentToastmasterBox.Text}'");
        }
        private void NewChefCost(object sender, EventArgs e)
        {
            ChefCost.Content = WorkDB.CopyCost($"SELECT * FROM [Chef] WHERE Name=N'{EntertainmentChefBox.Text}'");
        }
        private void NewDJCost(object sender, EventArgs e)
        {
            DJCost.Content = WorkDB.CopyCost($"SELECT * FROM [DJ] WHERE Name=N'{EntertainmentDJBox.Text}'");
        }
        private void StartDateClosed(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(WeddingStartBox.Text) > Convert.ToDateTime(WeddingEndBox.Text))
                {
                    string dt = Convert.ToString(WeddingEndBox.Text);
                    WeddingEndBox.Text = WeddingStartBox.Text;
                    WeddingStartBox.Text = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
