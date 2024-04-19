using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.FriendsSettings
{
    internal class UserInfo
    {
        public Guid Id { get; set; }
        public string username { get; set; }
        public string? email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime? birthday { get; set; }

        public UserInfo(string newUsername, string NewPhoneNumber)
        {
            username = newUsername;
            phoneNumber = NewPhoneNumber;
        }

        public UserInfo() { }
    }
}
