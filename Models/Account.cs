using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Models
{
    public enum SexType { Male, Female };

    public class Account
    {
        public int UserID { get; set; }

        // ФИО
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

        // Пол
        public SexType Gender { get; set; }

        // Дата рождения
        public DateTime Birthday { get; set; }

        // Страна, область, город, адрес
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        // Контактные телефоны: Мобильный + дополнительные 2
        public List<int> Phone { get; set; }

        // Эл. Почта
        public string Email { get; set; }

        // Откуда узнал о клинике
        public string AsFound { get; set; }
    }
}
