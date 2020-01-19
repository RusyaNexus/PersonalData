using Newtonsoft.Json;
using PersonalData.Components;
using PersonalData.Dapper;
using PersonalData.Models;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PersonalData
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var accounts = Data.GetAccounts();
            lvAccounts.ItemsSource = new ObservableCollection<Account>(accounts);
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
            var viewWindow = new ViewWindow();
            viewWindow.Owner = Application.Current.MainWindow;
            if (viewWindow.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(viewWindow.SurnameTextBox.Text) || string.IsNullOrEmpty(viewWindow.NameTextBox.Text) || string.IsNullOrEmpty(viewWindow.MiddleNameTextBox.Text))
                {
                    MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(viewWindow.BirthdayTextBox.Text) || !Regex.IsMatch(viewWindow.BirthdayTextBox.Text, @"^\d{2,4}-\d{1,2}-\d{1,2}"))
                {
                    MessageBox.Show("Заполните правильно дату рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(viewWindow.CountryTextBox.Text) || string.IsNullOrEmpty(viewWindow.RegionTextBox.Text) || string.IsNullOrEmpty(viewWindow.CityTextBox.Text) || string.IsNullOrEmpty(viewWindow.AddressTextBox.Text))
                {
                    MessageBox.Show("Заполните страну, область, город, адрес проживания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(viewWindow.EmailTextBox.Text) || !Regex.IsMatch(viewWindow.EmailTextBox.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                {
                    MessageBox.Show("Заполните правильно эл.почту", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(viewWindow.PhoneTextBox.Text))
                {
                    MessageBox.Show("Заполните основной номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(viewWindow.AsFoundTextBox.Text))
                {
                    MessageBox.Show("Заполните откуда клиент узнал о нас", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Data.InsertAccount(viewWindow.Account);
                (lvAccounts.ItemsSource as ObservableCollection<Account>).Add(viewWindow.Account);
                MessageBox.Show("Аккаунт был успешно добавлен!", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Edit_Client(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is Account account)
            {
                var viewWindow = new ViewWindow(JsonConvert.DeserializeObject<Account>(JsonConvert.SerializeObject(account)));
                viewWindow.Owner = Application.Current.MainWindow;
                if (viewWindow.ShowDialog() == true)
                {
                    var accounts = (lvAccounts.ItemsSource as ObservableCollection<Account>);
                    var index = accounts.IndexOf(account);
                    if (index >= 0)
                    {
                        if (string.IsNullOrEmpty(viewWindow.SurnameTextBox.Text) || string.IsNullOrEmpty(viewWindow.NameTextBox.Text) || string.IsNullOrEmpty(viewWindow.MiddleNameTextBox.Text))
                        {
                            MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (string.IsNullOrEmpty(viewWindow.BirthdayTextBox.Text) || !Regex.IsMatch(viewWindow.BirthdayTextBox.Text, @"^\d{2,4}-\d{1,2}-\d{1,2}"))
                        {
                            MessageBox.Show("Заполните правильно дату рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (string.IsNullOrEmpty(viewWindow.CountryTextBox.Text) || string.IsNullOrEmpty(viewWindow.RegionTextBox.Text) || string.IsNullOrEmpty(viewWindow.CityTextBox.Text) || string.IsNullOrEmpty(viewWindow.AddressTextBox.Text))
                        {
                            MessageBox.Show("Заполните страну, область, город, адрес проживания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (string.IsNullOrEmpty(viewWindow.EmailTextBox.Text) || !Regex.IsMatch(viewWindow.EmailTextBox.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                        {
                            MessageBox.Show("Заполните правильно эл.почту", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (string.IsNullOrEmpty(viewWindow.PhoneTextBox.Text))
                        {
                            MessageBox.Show("Заполните основной номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (string.IsNullOrEmpty(viewWindow.AsFoundTextBox.Text))
                        {
                            MessageBox.Show("Заполните откуда клиент узнал о нас", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        Data.UpdateAccount(viewWindow.Account);
                        accounts.Remove(account);
                        accounts.Add(viewWindow.Account);
                        MessageBox.Show("Аккаунт был успешно изменен!", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void Delete_Client(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((sender as Button)?.DataContext is Account account)
                {
                    Data.DeleteAccount(account.Id);
                    (lvAccounts.ItemsSource as ObservableCollection<Account>).Remove(account);
                    MessageBox.Show("Аккаунт был успешно удален!", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvAccounts_RowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
        {
            if (e.Row.DetailsVisibility == Visibility.Visible && e.Row.DataContext is Account account)
            {
                account.Phone = new ObservableCollection<string>(Data.GetPhones(account.Id));
            }
        }
    }
}
