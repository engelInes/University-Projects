using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using District_3_App.ProfileSocialNetworkInfoStuff.entities;

namespace District_3_App.LogIn
{
    public class UserManager
    {
        private List<User> users = new List<User>();
        //private Dictionary<string, DateTime> sessions = new Dictionary<string, DateTime>();
        //private TimeSpan sessionTimeout = TimeSpan.FromMinutes(0.2);
        //public string currentUsername;
        static User? currentUser;

        public UserManager(string filePath)
        {
            LoadUsersFromXml(filePath);
        }

        public bool AuthenticateUser(string username, string password)
        {
            User? user = users.Find(u => u.username == username);
            if (user != null && user.password == password)
            {
                StartOrRenewSession(user);
                return true;
            }
            return false;
        }

        public void StartOrRenewSession(User user)
        {
            UserManager.currentUser = user;
        }

        public bool IsUserLoggedIn()
        {
            return UserManager.currentUser != null;
        }

        public void LogOutUser(string username)
        {
            UserManager.currentUser = null;
        }

        private void LoadUsersFromXml(string filePath)
        {
            try
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                filePath = System.IO.Path.Combine(baseDirectory, @"..\..\..\" + filePath);
                XDocument doc = XDocument.Load(filePath);

                foreach (var userElement in doc.Root.Elements("User"))
                {
                    User user = new User
                    {
                        id = Guid.Parse(userElement.Attribute("id").Value),
                        username = userElement.Attribute("Username").Value,
                        email = userElement.Attribute("Email").Value,
                        password = userElement.Attribute("Password").Value,
                        confirmationPassword = userElement.Attribute("ConfirmationPassword").Value,
                        Usersession = TimeSpan.FromMinutes(0)
                    };
                    users.Add(user);
                }

            }
            catch
            {
                Console.WriteLine("File not found");
            }
        }
        public IReadOnlyList<User> GetUsers()
        {
            return users.AsReadOnly();
        }
    }
}

