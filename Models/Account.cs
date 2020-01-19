using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PersonalData.Models
{
    public enum SexType { Male, Female };

    public class Account : INotifyPropertyChanged
    {
        public string Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }
        public string MiddleName { get; set; }
        public SexType Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        private ObservableCollection<string> _phone;
        public ObservableCollection<string> Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                NotifyPropertyChanged();
            }
        }

        public string Email { get; set; }
        public string AsFound { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
