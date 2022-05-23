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
    /// Логика взаимодействия для UpdateMenu.xaml
    /// </summary>
    public partial class UpdateMenu : Window
    {
        private int id;
        public UpdateMenu(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void OpenWeddingsMenu(object sender, RoutedEventArgs e)
        {
            WeddingsMenu wm = new WeddingsMenu();
            wm.Show();
            this.Close();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
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

            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            WeddingNameBox.Text = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "WeddingName");
            WeddingStartBox.Text = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "WeddingStartDatetime");
            WeddingEndBox.Text = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "WeddingEndDatetime");

            string[] ids = new string[4] { WorkDB.Copy($"SELECT * FROM Table_NewlywedSet WHERE Id={codes[0]}", "Haircut"), WorkDB.Copy($"SELECT * FROM Table_NewlywedSet WHERE Id={codes[0]}", "Makeup"), WorkDB.Copy($"SELECT * FROM Table_NewlywedSet WHERE Id={codes[0]}", "Suit"), WorkDB.Copy($"SELECT * FROM Table_NewlywedSet WHERE Id={codes[0]}", "Ring") };
            
            MailHaircutBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Haircut WHERE Id={ids[0]}", "Name");
            MaleHaircutCost.Content = WorkDB.CopyCost($"SELECT * FROM [Haircut] WHERE Name=N'{MailHaircutBox.Text}'");
            MailMakeupBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Makeup WHERE Id={ids[1]}", "Name");
            MaleMakeupCost.Content = WorkDB.CopyCost($"SELECT * FROM [Makeup] WHERE Name=N'{MailMakeupBox.Text}'");
            MailSuitBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Suit WHERE Id={ids[2]}", "Name");
            MaleSuitCost.Content = WorkDB.CopyCost($"SELECT * FROM [Suit] WHERE Name=N'{MailSuitBox.Text}'");
            MailRingBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Ring WHERE Id={ids[3]}", "Name");
            MaleRingCost.Content = WorkDB.CopyCost($"SELECT * FROM [Ring] WHERE Name=N'{MailRingBox.Text}'");

            ids = new string[4] { WorkDB.Copy($"SELECT * FROM Table_NewlywedSet WHERE Id={codes[1]}", "Haircut"), WorkDB.Copy($"SELECT * FROM Table_NewlywedSet WHERE Id={codes[1]}", "Makeup"), WorkDB.Copy($"SELECT * FROM Table_NewlywedSet WHERE Id={codes[1]}", "Suit"), WorkDB.Copy($"SELECT * FROM Table_NewlywedSet WHERE Id={codes[1]}", "Ring") };
            FemailHaircutBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Haircut WHERE Id={ids[0]}", "Name");
            FemaleHaircutCost.Content = WorkDB.CopyCost($"SELECT * FROM [Haircut] WHERE Name=N'{FemailHaircutBox.Text}'");
            FemailMakeupBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Makeup WHERE Id={ids[1]}", "Name");
            FemaleMakeupCost.Content = WorkDB.CopyCost($"SELECT * FROM [Makeup] WHERE Name=N'{FemailMakeupBox.Text}'");
            FemailSuitBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Suit WHERE Id={ids[2]}", "Name");
            FemaleSuitCost.Content = WorkDB.CopyCost($"SELECT * FROM [Suit] WHERE Name=N'{FemailSuitBox.Text}'");
            FemailRingBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Ring WHERE Id={ids[3]}", "Name");
            FemaleRingCost.Content = WorkDB.CopyCost($"SELECT * FROM [Ring] WHERE Name=N'{FemailRingBox.Text}'");

            ids = new string[3] { WorkDB.Copy($"SELECT * FROM Table_Entertainment WHERE Id={codes[2]}", "Toastmaster"), WorkDB.Copy($"SELECT * FROM Table_Entertainment WHERE Id={codes[2]}", "Chef"), WorkDB.Copy($"SELECT * FROM Table_Entertainment WHERE Id={codes[2]}", "DJ") };
            EntertainmentToastmasterBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Toastmaster WHERE Id={ids[0]}", "Name");
            ToastmasterCost.Content = WorkDB.CopyCost($"SELECT * FROM [Toastmaster] WHERE Name=N'{EntertainmentToastmasterBox.Text}'");
            EntertainmentChefBox.SelectedItem = WorkDB.Copy($"SELECT * FROM Chef WHERE Id={ids[1]}", "Name");
            ChefCost.Content = WorkDB.CopyCost($"SELECT * FROM [Chef] WHERE Name=N'{EntertainmentChefBox.Text}'");
            EntertainmentDJBox.SelectedItem = WorkDB.Copy($"SELECT * FROM DJ WHERE Id={ids[2]}", "Name");
            DJCost.Content = WorkDB.CopyCost($"SELECT * FROM [DJ] WHERE Name=N'{EntertainmentDJBox.Text}'");

            string fq = WorkDB.Copy($"SELECT * FROM Table_Banquet WHERE Id={codes[3]}", "foodQuality");
            WeddingFoodQualityBox.Items.Add("Мало");
            WeddingFoodQualityBox.Items.Add("Нормально");
            WeddingFoodQualityBox.Items.Add("Много");
            WeddingFoodQualityBox.SelectedItem = fq;
            WeddingFoodCostBox.Content = WorkDB.Copy($"SELECT * FROM Table_Banquet WHERE Id={codes[3]}", "foodCost");
            WeddingGuestNumberBox.Text = WorkDB.Copy($"SELECT * FROM Table_Banquet WHERE Id={codes[3]}", "guestsNumber");
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

        private void WeddingGuestNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));
            cost = cost - Convert.ToInt32(WeddingFoodCostBox.Content);
            CostChanging();
            cost = cost + Convert.ToInt32(WeddingFoodCostBox.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Banquet] SET guestsNumber = {WeddingGuestNumberBox.Text} WHERE Id={codes[3]};");
            WorkDB.UpdateDB($"UPDATE [Table_Banquet] SET foodQuality = N'{WeddingFoodQualityBox.Text}' WHERE Id={codes[3]};");
            WorkDB.UpdateDB($"UPDATE [Table_Banquet] SET foodCost = {WeddingFoodCostBox.Content} WHERE Id={codes[3]};");
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");
        }
        private void WeddingFoodQualityBox_DropDownClosed(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));
            cost = cost - Convert.ToInt32(WeddingFoodCostBox.Content);
            CostChanging();
            cost = cost + Convert.ToInt32(WeddingFoodCostBox.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Banquet] SET guestsNumber = {WeddingGuestNumberBox.Text} WHERE Id={codes[3]};");
            WorkDB.UpdateDB($"UPDATE [Table_Banquet] SET foodQuality = N'{WeddingFoodQualityBox.Text}' WHERE Id={codes[3]};");
            WorkDB.UpdateDB($"UPDATE [Table_Banquet] SET foodCost = {WeddingFoodCostBox.Content} WHERE Id={codes[3]};");
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");
        }
        private void NewMailHaircutCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));
            cost = cost - Convert.ToInt32(MaleHaircutCost.Content);
            MaleHaircutCost.Content = WorkDB.Copy($"SELECT * FROM [Haircut] WHERE Name=N'{MailHaircutBox.Text}'", "Cost");
            cost = cost + Convert.ToInt32(MaleHaircutCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");
            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Haircut] WHERE Name=N'{MailHaircutBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_NewlywedSet] SET Haircut = {idOfUpdate} WHERE Id={codes[0]};");
        }
        private void NewMailMakeupCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));
            
            cost = cost - Convert.ToInt32(MaleMakeupCost.Content);

            MaleMakeupCost.Content = WorkDB.Copy($"SELECT * FROM [Makeup] WHERE Name=N'{MailMakeupBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(MaleMakeupCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Makeup] WHERE Name=N'{MailMakeupBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_NewlywedSet] SET Makeup = {idOfUpdate} WHERE Id={codes[0]};");
        }
        private void NewMailSuitCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));

            cost = cost - Convert.ToInt32(MaleSuitCost.Content);

            MaleSuitCost.Content = WorkDB.Copy($"SELECT * FROM [Suit] WHERE Name=N'{MailSuitBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(MaleSuitCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Suit] WHERE Name=N'{MailSuitBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_NewlywedSet] SET Suit = {idOfUpdate} WHERE Id={codes[0]};");
        }
        private void NewMailRingCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));

            cost = cost - Convert.ToInt32(MaleRingCost.Content);

            MaleRingCost.Content = WorkDB.Copy($"SELECT * FROM [Ring] WHERE Name=N'{MailRingBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(MaleRingCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Ring] WHERE Name=N'{MailRingBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_NewlywedSet] SET Ring = {idOfUpdate} WHERE Id={codes[0]};");
        }
        private void NewFemailHaircutCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));
            cost = cost - Convert.ToInt32(FemaleHaircutCost.Content);
            FemaleHaircutCost.Content = WorkDB.Copy($"SELECT * FROM [Haircut] WHERE Name=N'{FemailHaircutBox.Text}'", "Cost");
            cost = cost + Convert.ToInt32(FemaleHaircutCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");
            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Haircut] WHERE Name=N'{FemailHaircutBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_NewlywedSet] SET Haircut = {idOfUpdate} WHERE Id={codes[1]};");
        }
        private void NewFemailMakeupCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));

            cost = cost - Convert.ToInt32(FemaleMakeupCost.Content);

            FemaleMakeupCost.Content = WorkDB.Copy($"SELECT * FROM [Makeup] WHERE Name=N'{FemailMakeupBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(FemaleMakeupCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Makeup] WHERE Name=N'{FemailMakeupBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_NewlywedSet] SET Makeup = {idOfUpdate} WHERE Id={codes[1]};");
        }
        private void NewFemailSuitCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));

            cost = cost - Convert.ToInt32(FemaleSuitCost.Content);

            FemaleSuitCost.Content = WorkDB.Copy($"SELECT * FROM [Suit] WHERE Name=N'{FemailSuitBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(FemaleSuitCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Suit] WHERE Name=N'{FemailSuitBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_NewlywedSet] SET Suit = {idOfUpdate} WHERE Id={codes[1]};");
        }
        private void NewFemailRingCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));

            cost = cost - Convert.ToInt32(FemaleRingCost.Content);

            FemaleRingCost.Content = WorkDB.Copy($"SELECT * FROM [Ring] WHERE Name=N'{FemailRingBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(FemaleRingCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Ring] WHERE Name=N'{FemailRingBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_NewlywedSet] SET Ring = {idOfUpdate} WHERE Id={codes[1]};");
        }
        private void NewToastmasterCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));

            cost = cost - Convert.ToInt32(ToastmasterCost.Content);

            ToastmasterCost.Content = WorkDB.Copy($"SELECT * FROM [Toastmaster] WHERE Name=N'{EntertainmentToastmasterBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(ToastmasterCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Toastmaster] WHERE Name=N'{EntertainmentToastmasterBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_Entertainment] SET Toastmaster = {idOfUpdate} WHERE Id={codes[2]};");
        }
        private void NewChefCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));

            cost = cost - Convert.ToInt32(ChefCost.Content);

            ChefCost.Content = WorkDB.Copy($"SELECT * FROM [Chef] WHERE Name=N'{EntertainmentChefBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(ChefCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [Chef] WHERE Name=N'{EntertainmentChefBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_Entertainment] SET Chef = {idOfUpdate} WHERE Id={codes[2]};");
        }
        private void NewDJCost(object sender, EventArgs e)
        {
            string[] codes = WorkDB.Copy($"SELECT * FROM Table_Wedding WHERE Id={id}", "Codes").Split(' ');
            int cost = Convert.ToInt32(WorkDB.Copy($"SELECT * FROM [Table_Wedding] WHERE Id={id}", "Cost"));

            cost = cost - Convert.ToInt32(DJCost.Content);

            DJCost.Content = WorkDB.Copy($"SELECT * FROM [DJ] WHERE Name=N'{EntertainmentDJBox.Text}'", "Cost");

            cost = cost + Convert.ToInt32(DJCost.Content);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET Cost = {cost} WHERE Id={id};");

            string idOfUpdate = WorkDB.Copy($"SELECT * FROM [DJ] WHERE Name=N'{EntertainmentDJBox.Text}'", "Id");
            WorkDB.UpdateDB($"UPDATE [Table_Entertainment] SET DJ = {idOfUpdate} WHERE Id={codes[2]};");
        }

        private void WeddingNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET WeddingName = N'{WeddingNameBox.Text}' WHERE Id={id};");
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
            DateTime wsb = DateTime.Parse(WeddingStartBox.Text);
            DateTime web = DateTime.Parse(WeddingEndBox.Text);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET WeddingStartDatetime = N'{wsb.Year}-{wsb.Month}-{wsb.Day}' WHERE Id={id};");
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET WeddingEndDatetime =  N'{web.Year}-{web.Month}-{web.Day}' WHERE Id={id};");
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
            DateTime wsb = DateTime.Parse(WeddingStartBox.Text);
            DateTime web = DateTime.Parse(WeddingEndBox.Text);
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET WeddingStartDatetime = N'{wsb.Year}-{wsb.Month}-{wsb.Day}' WHERE Id={id};");
            WorkDB.UpdateDB($"UPDATE [Table_Wedding] SET WeddingEndDatetime =  N'{web.Year}-{web.Month}-{web.Day}' WHERE Id={id};");
        }
    }
}