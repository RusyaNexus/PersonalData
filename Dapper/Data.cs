using Dapper;
using Microsoft.Data.Sqlite;
using PersonalData.Models;
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
                return connection.Query<Account>("SELECT * FROM Accounts").ToList();
            }
        }

        public static List<string> GetPhones(int accountId)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return connection.Query<string>("SELECT Phone FROM Phones WHERE ACCOUNTS_ID = @Id", new { Id = accountId }).ToList();
            }
        }

        //public static int InsertAccount(Account account)
        //{
        //    using (var connection = new SqliteConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        connection.Open();
        //        var insertRow = connection.Execute("Insert into Student (Name, Marks) values (@Name, @Marks)", new { Name = student.Name, Marks = student.Marks });
        //        return insertRow;
        //    }
        //}

        //public static int UpdateAccount(Account account)
        //{
        //    using (var connection = new SqliteConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        connection.Open();
        //        var updateRow = connection.Execute("Update Student set Name = @Name, Marks = @Marks Where Id = @Id", account);
        //        return updateRow;
        //    }
        //}

        public static void DeleteAccount(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                connection.Execute($"DELETE FROM Accounts WHERE ID = @Id;", new { Id = id });
            }
        }
    }
}
