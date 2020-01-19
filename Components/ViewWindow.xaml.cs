using PersonalData.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PersonalData.Components
{
    public partial class ViewWindow : Window
    {
        public Account Account { get; }

        public ViewWindow(Account account)
        {
            InitializeComponent();

            Title = "Изменить клиента";
            AddClientButton.Content = "Изменить клиента";

            Account = account;
            DataContext = Account;
        }

        public ViewWindow()
        {
            InitializeComponent();

            Account = new Account()
            {
                Id = Guid.NewGuid().ToString(),
                Phone = new ObservableCollection<string>()
                {
                    "",
                    "",
                    ""
                }
            };
            DataContext = Account;
        }

        private void Add_Client(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
