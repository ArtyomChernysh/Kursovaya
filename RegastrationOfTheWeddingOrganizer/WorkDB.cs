using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace RegastrationOfTheWeddingOrganizer
{
    internal class WorkDB// 10 30 60  жених невеста развлечения банкет
    {
        private static string connectionToDB = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        internal static bool SelectWhereId(string table, string whatSelect, string login, string password)
        {
            string sql = $"SELECT * FROM [{table}] WHERE Id={whatSelect}";
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Login = Convert.ToString(reader["Login"]);
                    string Password = Convert.ToString(reader["Password"]);
                    if (Login == login && Password == password)
                    {
                        return true;
                    }
                }
                connection.Close();
            }
            return false;
        }
        internal static void UpdateDB(string order)
        {
            string sql = order;
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        internal static List<User> SelectDB(string table)
        {
            string sql = $"SELECT * FROM [{table}]";
            List<User> list = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Id = Convert.ToString(reader["Id"]);
                    string Name = Convert.ToString(reader["Name"]);
                    string Cost = Convert.ToString(reader["Cost"]);
                    list.Add(new User(Id, Name, Cost));
                }
                connection.Close();
            }
            return list;
        }
        internal static List<Wedding> SelectDBWedding(string table)
        {
            string sql = $"SELECT * FROM [{table}]";
            List<Wedding> list = new List<Wedding>();
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Id = Convert.ToString(reader["Id"]);
                    string WeddingName = Convert.ToString(reader["WeddingName"]);
                    string WeddingStartDatetime = Convert.ToString(reader["WeddingStartDatetime"]);
                    string WeddingEndDatetime = Convert.ToString(reader["WeddingEndDatetime"]);
                    string Cost = Convert.ToString(reader["Cost"]);
                    string Codes = Convert.ToString(reader["Codes"]);
                    list.Add(new Wedding(Id, WeddingName, WeddingStartDatetime, WeddingEndDatetime, Cost, Codes));
                }
                connection.Close();
            }
            return list;
        }
        internal static List<ArchiveWedding> SelectDBWArchive(string table)
        {
            string sql = $"SELECT * FROM [{table}]";
            List<ArchiveWedding> list = new List<ArchiveWedding>();
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Id = Convert.ToString(reader["Id"]);
                    string WeddingName = Convert.ToString(reader["Name"]);
                    string WeddingStartDatetime = Convert.ToString(reader["WeddingStartDatetime"]);
                    string WeddingEndDatetime = Convert.ToString(reader["WeddingEndDatetime"]);
                    string Cost = Convert.ToString(reader["Cost"]);
                    string Codes = Convert.ToString(reader["Codes"]);
                    string WeddingRecordDate = Convert.ToString(reader["WeddingRecordDate"]);
                    list.Add(new ArchiveWedding(Id, WeddingName, WeddingStartDatetime, WeddingEndDatetime, Cost, Codes,WeddingRecordDate));
                }
                connection.Close();
            }
            return list;
        }
        internal static void FullReupate(string table, List<User> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                foreach (User i in list)
                {
                    string sql = $"DELETE FROM {table} WHERE Id={i.Id}; ";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
            }
        }
        internal static void FullReupate(string table, List<string> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                foreach (string i in list)
                {
                    string[] codes = CopyCodes($"SELECT * FROM {table} WHERE WeddingName=N'{i}'; ").Split(' ');
                    UpdateDB($"DELETE FROM {table} WHERE WeddingName=N'{i}';");
                    UpdateDB($"DELETE FROM Table_NewlywedSet WHERE Id={codes[0]}");
                    UpdateDB($"DELETE FROM Table_NewlywedSet WHERE Id={codes[1]}");
                    UpdateDB($"DELETE FROM Table_Entertainment WHERE Id={codes[2]}");
                    UpdateDB($"DELETE FROM Table_Banquet WHERE Id={codes[3]}");
                }
            }
        }
        internal static void DeleteArchive(string table, List<string> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                foreach (string i in list)
                {
                    string[] codes = CopyCodes($"SELECT * FROM {table} WHERE Name=N'{i}'; ").Split(' ');
                    UpdateDB($"DELETE FROM {table} WHERE Name=N'{i}';");
                    UpdateDB($"DELETE FROM Table_NewlywedSet WHERE Id={codes[0]}");
                    UpdateDB($"DELETE FROM Table_NewlywedSet WHERE Id={codes[1]}");
                    UpdateDB($"DELETE FROM Table_Entertainment WHERE Id={codes[2]}");
                    UpdateDB($"DELETE FROM Table_Banquet WHERE Id={codes[3]}");
                }
            }
        }
        internal static void FullArchive(string table, List<string> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                foreach (string i in list)
                {
                    string[] codes = CopyCodes($"SELECT * FROM {table} WHERE WeddingName=N'{i}'; ").Split(' ');
                    UpdateDB($"DELETE FROM {table} WHERE WeddingName=N'{i}';");
                }
            }
        }
        internal static void FullWedding(string table, List<string> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                foreach (string i in list)
                {
                    string[] codes = CopyCodes($"SELECT * FROM {table} WHERE Name=N'{i}'; ").Split(' ');
                    UpdateDB($"DELETE FROM {table} WHERE Name=N'{i}';");
                }
            }
        }

        internal static string Copy(string order, string column)
        {
            string sql = order;
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToString(reader[column]);
                }
                connection.Close();
            }
            return "EMPTY";
        }
        internal static string CopyName(string order)
        {
            string sql = order;
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToString(reader["Name"]);
                }
                connection.Close();
            }
            return "EMPTY";
        }
        internal static string CopyCost(string order)
        {
            string sql = order;
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToString(reader["Cost"]);
                }
                connection.Close();
            }
            return "EMPTY";
        }
        internal static string CopyId(string order)
        {
            string sql = order;
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToString(reader["Id"]);
                }
                connection.Close();
            }
            return "EMPTY";
        }
        internal static string CopyCodes(string order)
        {
            string sql = order;
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToString(reader["Codes"]);
                }
                connection.Close();
            }
            return "EMPTY";
        }
        internal static string CopyWeddingName(string order)
        {
            string sql = order;
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToString(reader["WeddingName"]);
                }
                connection.Close();
            }
            return "EMPTY";
        }
        internal static string WorkWithNewlywed(string id)
        {
            string sql = $"SELECT * FROM [Table_NewlywedSet] Where Id={id}";
            string returnText = "";
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returnText += "\nСтрижка: " + CopyName($"SELECT * FROM [Haircut] Where Id={reader["Haircut"]}") + "\n";
                    returnText += "Костюм: " + CopyName($"SELECT * FROM [Suit] Where Id={reader["Suit"]}") + "\n";
                    returnText += "Макияж: " + CopyName($"SELECT * FROM [Makeup] Where Id={reader["Makeup"]}") + "\n";
                    returnText += "Кольцо: " + CopyName($"SELECT * FROM [Ring] Where Id={reader["Ring"]}") + "\n";
                }
                connection.Close();
            }
            return returnText;
        }
        internal static string WorkWithEntertainment(string id)
        {
            string sql = $"SELECT * FROM [Table_Entertainment] Where Id={id}";
            string returnText = "";
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returnText += "\nТамада: " + CopyName($"SELECT * FROM [Toastmaster] Where Id={reader["Toastmaster"]}") + "\n";
                    returnText += "Шеф-повар: " + CopyName($"SELECT * FROM [Chef] Where Id={reader["Chef"]}") + "\n";
                    returnText += "Диджей: " + CopyName($"SELECT * FROM [DJ] Where Id={reader["DJ"]}") + "\n";
                }
                connection.Close();
            }
            return returnText;
        }
        internal static string WorkWithBanquet(string id)
        {
            string sql = $"SELECT * FROM [Table_Banquet] Where Id={id}";
            string returnText = "";
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returnText += "\nКоличество еды: " + reader["foodQuality"] + "\n";
                    returnText += "Стоимость еды: " + reader["foodCost"] + "\n";
                    returnText += "Количество гостей: " + reader["guestsNumber"] + "\n";
                }
                connection.Close();
            }
            return returnText;
        }
        internal static string UsingWeddingsCodes(string code)
        {
            string[] arrayOfCodes = code.Split(' ');
            string returnText = "";
            returnText += "Жених:";
            returnText += WorkWithNewlywed(Convert.ToString(arrayOfCodes[0]));
            returnText += "Невеста:";
            returnText += WorkWithNewlywed(Convert.ToString(arrayOfCodes[1]));
            returnText += "Развлечения:";
            returnText += WorkWithEntertainment(Convert.ToString(arrayOfCodes[2]));
            returnText += "Банкет:";
            returnText += WorkWithBanquet(Convert.ToString(arrayOfCodes[3]));
            return returnText;
        }
        internal static List<string> ComboboxDB(string order)
        {
            string sql = order;
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(Convert.ToString(reader["Name"]));
                }
                connection.Close();
            }
            return list;
        }
        internal static int FindId(string order)
        {
            string sql = order;
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                connection.Close();
            }
            return 0;
        }
        internal static Wedding CopyAllWedding(int id)
        {
            string sql = $"SELECT * FROM [Table_Wedding] WHERE Id={id}";
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Id = Convert.ToString(reader["Id"]);
                    string WeddingName = Convert.ToString(reader["WeddingName"]);
                    string WeddingStartDate = Convert.ToString(reader["WeddingStartDatetime"]);
                    string WeddingEndDate = Convert.ToString(reader["WeddingEndDatetime"]);
                    string Cost = Convert.ToString(reader["Cost"]);
                    string Codes = Convert.ToString(reader["Codes"]);
                    return new Wedding(Id,WeddingName,WeddingStartDate,WeddingEndDate,Cost,Codes);
                }
                connection.Close();
            }
            return new Wedding();
        }
        internal static Wedding CopyAllArchive(int id)
        {
            string sql = $"SELECT * FROM [Table_Archive] WHERE Id={id}";
            using (SqlConnection connection = new SqlConnection(connectionToDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Id = Convert.ToString(reader["Id"]);
                    string WeddingName = Convert.ToString(reader["Name"]);
                    string WeddingStartDate = Convert.ToString(reader["WeddingStartDatetime"]);
                    string WeddingEndDate = Convert.ToString(reader["WeddingEndDatetime"]);
                    string Cost = Convert.ToString(reader["Cost"]);
                    string Codes = Convert.ToString(reader["Codes"]);
                    return new Wedding(Id, WeddingName, WeddingStartDate, WeddingEndDate, Cost, Codes);
                }
                connection.Close();
            }
            return new Wedding();
        }
    }
}
