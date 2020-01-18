using PersonalData.Components;
using PersonalData.Dapper;
using PersonalData.Models;
using System;
using System.Collections.ObjectModel;
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
            viewWindow.ShowDialog();
        }

        private void Edit_Client(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is Account account)
            {
                var viewWindow = new ViewWindow(account);
                viewWindow.Owner = Application.Current.MainWindow;
                viewWindow.ShowDialog();

                (lvAccounts.ItemsSource as ObservableCollection<Account>).Add(account);
                MessageBox.Show("Аккаунт был успешно изменен!", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Client(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((sender as Button)?.DataContext is Account account)
                {
                    //Dapper.Data.DeleteAccount(account.Id);
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
                account.Phone = Data.GetPhones(account.Id);
            }
        }
    }
}
