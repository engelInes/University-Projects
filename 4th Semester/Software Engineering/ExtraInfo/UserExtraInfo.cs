using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ExtraInfo
{
    public class UserExtraInfo
    {
        private string username;
        private string password;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public UserExtraInfo(string name, string passwd)
        {
            username = name;
            password = passwd;
        }
    }
}
