using PersonalData.Components;
using PersonalData.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PersonalData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Account> items = new List<Account>();
            items.Add(new Account() { UserID = 34, Surname = "Мерчанский", Name = "Руслан", MiddleName = "Юрьевич", Gender = SexType.Male, Birthday = new DateTime(1998, 2, 22), Country = "Украина", Region = "Харьковская", City = "Харьков", Address = "Тест", Phone = new List<int> { 0676813358, 911, 332 }, Email = "rusya998@gmail.com", AsFound = "В интернете" });
            items.Add(new Account() { UserID = 23, Surname = "Тестович", Name = "Иван", MiddleName = "Иванович", Gender = SexType.Male, Birthday = new DateTime(1995, 4, 12), Email = "testovich@gmail.com" });
            items.Add(new Account() { UserID = 65, Surname = "Иванов", Name = "Виктор", MiddleName = "Викторович", Gender = SexType.Male, Birthday = new DateTime(1991, 7, 4), Email = "ivanov@gmail.com" });
            items.Add(new Account() { UserID = 86, Surname = "Квочка", Name = "Наталья", MiddleName = "Игоревна", Gender = SexType.Female, Birthday = new DateTime(1994, 2, 22), Email = "kvochka@gmail.com" });
            lvAccounts.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvAccounts.ItemsSource);
            view.Filter = userFilter;
        }

        private bool userFilter(object item)
        {
            if (string.IsNullOrEmpty(textFilter.Text))
            {
                return true;
            }

            return (item as Account).Surname.IndexOf(textFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void textFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvAccounts.ItemsSource).Refresh();
        }

        private void New_Client(object sender, RoutedEventArgs e)
        {
            ViewWindow viewWindow = new ViewWindow();
            viewWindow.Owner = Application.Current.MainWindow;
            viewWindow.ShowDialog();
        }
    }
}
