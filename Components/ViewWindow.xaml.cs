using PersonalData.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PersonalData.Components
{
    public partial class ViewWindow : Window
    {
        public ViewWindow(Account account)
        {
            InitializeComponent();

            Title = "Изменить клиента";

            DataContext = account;
        }

        public ViewWindow()
        {
            InitializeComponent();

            DataContext = new Account();
        }

        private void Add_Client(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((sender as Button)?.DataContext is Account account)
                {
                    (lvAccounts.ItemsSource as ObservableCollection<Account>).Add(account);
                    MessageBox.Show("Аккаунт был успешно добавлен!", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //1) public ViewWindow(Account account)
        //{
        //    InitializeComponent();

        //    Title = "Изменить клиента";

        //    DataContext = account;
        //}
        //2) <ComboBox Grid.Row="7"
        //                  Text= "{Binding Gender}"
        //                  Name= "GenderComboBox" >
        //            < ComboBoxItem Content= "Мужчина" />
        //            < ComboBoxItem Content= "Женщина" />
        //        </ ComboBox >

        //    3) Binding Phone for edit
        //4) FOREIGN KEY(ACCOUNT_ID) REFERENCES Accounts(ID)
    }
}
