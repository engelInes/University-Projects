using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfilePage.Entities
{
    internal class User
    {
        private Guid id;
        private DateTime birthday;
        private string phoneNumber;
        private string email;
        private string username;

        public User(Guid id, DateTime birthday, string phoneNumber, string email, string username)
        {
            this.id = id;
            this.birthday = birthday;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.username = username;
        }

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
