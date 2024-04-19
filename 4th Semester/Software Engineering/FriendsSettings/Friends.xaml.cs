using District_3_App.Enitities;
using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using District_3_App.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace District_3_App.FriendsSettings
{
    /// <summary>
    /// Interaction logic for Friends.xaml
    /// </summary>
    public partial class Friends : UserControl
    {
        // Getting lists
        private static Dictionary<string, UserInfo> getContacts()
        {
            var contacts = new Dictionary<string, UserInfo>();
            string filePath;

            // Create User objects with usernames and add them to the dictionary
            /*contacts["0752111222"] = new User("@patri.stoica", "0752111222");
            contacts["0743111222"] = new User("@delia.gherasim", "0743111222");*/

            // Load the XML document
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = baseDirectory.Substring(0, baseDirectory.IndexOf("bin\\Debug"));
            string currfilePath = System.IO.Path.Combine(relativePath, "FriendsSettings");
            filePath = System.IO.Path.Combine(currfilePath, "Contacts.xml");
            Console.WriteLine(filePath);
            /*if (!File.Exists(filePath))
            {
                XDocument xDocument1 = new XDocument(new XElement("FancierProfiles"));
                xDocument1.Save(filePath);
            }*/
            //MessageBox.Show("Reading profile info from file: " + filePath);

            XDocument xDocument = XDocument.Load(filePath);

            XElement root = xDocument.Element("contacts");
            if (root != null && root.HasElements)
            {
                foreach (var userElem in root.Elements("contact"))
                {
                    Guid userId;
                    if (!Guid.TryParse((string)userElem.Element("Id"), out userId))
                    {
                        userId = Guid.NewGuid();
                    }
                    UserInfo user = new UserInfo();
                    try
                    {
                        user.Id = userId;
                        user.username = (string)userElem.Element("username");
                        user.email = (string)userElem.Element("email");
                        user.phoneNumber = (string)userElem.Element("phoneNumber");
                        user.birthday = (DateTime)userElem.Element("birthday");

                        contacts[user.phoneNumber] = user;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing profile: {ex.Message}");
                    }
                }
            }
            return contacts;
        }

        private static Dictionary<string, UserInfo> getViewers()
        {
            var contacts = new Dictionary<string, UserInfo>();
            string filePath;

            // Create User objects with usernames and add them to the dictionary
            /*contacts["0752111222"] = new User("@patri.stoica", "0752111222");
            contacts["0743111222"] = new User("@delia.gherasim", "0743111222");
            contacts["0755111222"] = new User("@anita.gorog", "0755111222");*/

            // Load the XML document
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = baseDirectory.Substring(0, baseDirectory.IndexOf("bin\\Debug"));

            string currfilePath = System.IO.Path.Combine(relativePath, "FriendsSettings");
            filePath = System.IO.Path.Combine(currfilePath, "Viewers.xml");
            Console.WriteLine(filePath);
            /*if (!File.Exists(filePath))
            {
                XDocument xDocument1 = new XDocument(new XElement("FancierProfiles"));
                xDocument1.Save(filePath);
            }*/
            //MessageBox.Show("Reading profile info from file: " + filePath);

            XDocument xDocument = XDocument.Load(filePath);

            XElement root = xDocument.Element("viewers");
            if (root != null && root.HasElements)
            {
                foreach (var userElem in root.Elements("viewer"))
                {
                    Guid userId;
                    if (!Guid.TryParse((string)userElem.Element("Id"), out userId))
                    {
                        userId = Guid.NewGuid();
                    }
                    UserInfo user = new UserInfo();
                    try
                    {
                        user.Id = userId;
                        user.username = (string)userElem.Element("username");
                        user.email = (string)userElem.Element("email");
                        user.phoneNumber = (string)userElem.Element("phoneNumber");
                        user.birthday = (DateTime)userElem.Element("birthday");

                        contacts[user.phoneNumber] = user;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing profile: {ex.Message}");
                    }
                }
            }

            return contacts;

        }

        private static Dictionary<string, UserInfo> getFriends()
        {
            var friends = new Dictionary<string, UserInfo>();
            string filePath;

            // Load the XML document
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = baseDirectory.Substring(0, baseDirectory.IndexOf("bin\\Debug"));

            string currfilePath = System.IO.Path.Combine(relativePath, "FriendsSettings");
            filePath = System.IO.Path.Combine(currfilePath, "Friends.xml");
            Console.WriteLine(filePath);
            /*if (!File.Exists(filePath))
            {
                XDocument xDocument1 = new XDocument(new XElement("FancierProfiles"));
                xDocument1.Save(filePath);
            }*/
            //MessageBox.Show("Reading profile info from file: " + filePath);

            XDocument xDocument = XDocument.Load(filePath);

            XElement root = xDocument.Element("friends");
            if (root != null && root.HasElements)
            {
                foreach (var userElem in root.Elements("friend"))
                {
                    Guid userId;
                    if (!Guid.TryParse((string)userElem.Element("Id"), out userId))
                    {
                        userId = Guid.NewGuid();
                    }
                    UserInfo user = new UserInfo();
                    try
                    {
                        user.Id = userId;
                        user.username = (string)userElem.Element("username");
                        user.email = (string)userElem.Element("email");
                        user.phoneNumber = (string)userElem.Element("phoneNumber");
                        user.birthday = (DateTime)userElem.Element("birthday");

                        friends[user.phoneNumber] = user;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing profile: {ex.Message}");
                    }
                }
            }

            return friends;
        }

        public void SaveFriendsToXml()
        {
            string filePath;

            // Load the XML document
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = baseDirectory.Substring(0, baseDirectory.IndexOf("bin\\Debug"));

            string currentFilePath = System.IO.Path.Combine(relativePath, "FriendsSettings");
            filePath = System.IO.Path.Combine(currentFilePath, "Friends.xml");

            try
            {
                XDocument xDocument = new XDocument(new XElement("friends"));

                foreach (var friend in friends.Values)
                {
                    XElement friendElement = new XElement("friend",
                        new XElement("Id", friend.Id),
                        new XElement("username", friend.username),
                        new XElement("email", friend.email),
                        new XElement("phoneNumber", friend.phoneNumber),
                        new XElement("birthday", friend.birthday)
                    );

                    xDocument.Root?.Add(friendElement);
                }

                xDocument.Save(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving friends to XML: " + ex.Message);
            }
        }

        private Dictionary<string, UserInfo> syncContacts = getContacts();

        private Dictionary<string, UserInfo> usernames_viewers = getViewers();

        private Dictionary<string, UserInfo> friends = getFriends();
        public Friends()
        {
            InitializeComponent();
        }

        private void LoadUsernamesContacts_Click(object sender, RoutedEventArgs e)
        {
            usernamesContactsComboBox.Items.Clear();

            foreach (UserInfo user in syncContacts.Values)
            {
                usernamesContactsComboBox.Items.Add(user.username);
            }
        }

        private void LoadUsernamesViewers_Click(object sender, RoutedEventArgs e)
        {
            usernamesViewersComboBox.Items.Clear();

            foreach (UserInfo user in usernames_viewers.Values)
            {
                usernamesViewersComboBox.Items.Add(user.username);
            }
        }

        private bool addSyncContact(UserInfo contactToAdd, string key)
        {
            if (friends.ContainsKey(key))
            {
                Console.WriteLine("User already added.");
                return false;
            }
            else
            {
                friends[key] = contactToAdd;

                Console.WriteLine($"User added: {contactToAdd.username}");
            }
            return true;
        }

        private bool removeSyncContact(string key)
        {
            friends.Remove(key);
            return true;
        }

        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Grid grid = (Grid)VisualTreeHelper.GetParent(clickedButton);
            TextBlock textBlock = (TextBlock)grid.Children[0];
            string username = textBlock.Text;
            bool added = false;
            foreach (UserInfo user in syncContacts.Values)
            {
                if (user.username == username)
                {
                    string phoneNumber = user.phoneNumber;
                    added = addSyncContact(user, phoneNumber);
                    if (added)
                    {
                        MessageBox.Show($"Username added to friends: {username}");
                    }
                    else
                    {
                        removeSyncContact(user.phoneNumber);
                        MessageBox.Show($"Username removed from friends: {username}");
                    }
                    SaveFriendsToXml();
                }
            }



            StringBuilder stringBuilder = new StringBuilder();
            foreach (UserInfo friend in friends.Values)
            {
                stringBuilder.AppendLine(friend.username + ',' + friend.phoneNumber);
            }
            string friendsList = stringBuilder.ToString();
            MessageBox.Show("Friends List:\n\n" + friendsList);
        }

    }
}
