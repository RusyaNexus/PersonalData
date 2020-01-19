using Dapper;
using Microsoft.Data.Sqlite;
using PersonalData.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PersonalData.Dapper
{
    public static class Data
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<Account> GetAccounts()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Account>("SELECT * FROM Accounts;").ToList();
            }
        }

        public static List<string> GetPhones(string accountId)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return connection.Query<string>("SELECT Phone FROM Phones WHERE ACCOUNT_ID = @Id;", new { Id = accountId }).ToList();
            }
        }

        public static void InsertAccount(Account account)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Accounts (ID, SURNAME, NAME, MIDDLENAME, GENDER, BIRTHDAY, COUNTRY, REGION, CITY, ADDRESS, EMAIL, ASFOUND) VALUES (@Id, @Surname, @Name, @MiddleName, @Gender, @Birthday, @Country, @Region, @City, @Address, @Email, @AsFound);", account);

                if (account.Phone != null && account.Phone.Count > 0)
                {
                    connection.Execute("INSERT INTO Phones (PHONE, ACCOUNT_ID) VALUES (@Phone, @AccountId);", account.Phone.Select(phone => new { AccountId = account.Id, Phone = phone }));
                }
            }
        }

        public static void UpdateAccount(Account account)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Accounts SET SURNAME = @Surname, NAME = @Name, MIDDLENAME = @MiddleName, GENDER = @Gender, BIRTHDAY = @Birthday, COUNTRY = @Country, REGION = @Region, CITY = @City, ADDRESS = @Address, EMAIL = @Email, ASFOUND = @AsFound WHERE ID = @Id;", account);

                connection.Execute("DELETE FROM Phones WHERE ACCOUNT_ID = @AccountId;", new { AccountId = account.Id });

                if (account.Phone != null && account.Phone.Count > 0)
                {
                    connection.Execute("INSERT INTO Phones VALUES (@Phone, @AccountId);", account.Phone.Select(phone => new { AccountId = account.Id, Phone = phone }));
                }
            }
        }

        public static void DeleteAccount(string id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM Phones WHERE ACCOUNT_ID = @AccountId;", new { AccountId = id });

                connection.Execute($"DELETE FROM Accounts WHERE ID = @Id;", new { Id = id });
            }
        }
    }
}
