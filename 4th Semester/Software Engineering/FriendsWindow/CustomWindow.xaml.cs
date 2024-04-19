using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace District_3_App.FriendsWindow
{
    /// <summary>
    /// Interaction logic for CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        // Mock friends list
        private static Dictionary<string, UserInfo> getFriends()
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

        // Mock posts
        private static List<Post> getPosts()
        {
            List<Post> posts = new List<Post>();
            Post post = new Post(9);
            posts.Add(post);
            return posts;
        }
        private static Dictionary<Post, List<UserInfo>> makePostDictionary()
        {
            Dictionary<Post, List<UserInfo>> posts = new Dictionary<Post, List<UserInfo>>();
            foreach (Post post in getPosts())
            {
                posts[post] = new List<UserInfo>();
            }
            return posts;
        }

        private Post getCurrentPost() { return allowedProfiles.Keys.First(); }


        private Dictionary<string, UserInfo> friends = getFriends();

        private Dictionary<Post, List<UserInfo>> allowedProfiles = makePostDictionary();

        private List<string> allowedNames = new List<string>();

        //private List<Post> listPosts = getPosts();

        private void LoadUsernames()
        {
            listBox.Items.Clear();

            foreach (UserInfo user in friends.Values)
            {
                listBox.Items.Add(user.username);
            }
        }

        public CustomWindow()
        {
            InitializeComponent();
            //listBox.ItemsSource = getUsernames();
            LoadUsernames();
        }

        private void SearchButton_Clicked(object sender, RoutedEventArgs e)
        {
            string searchText = textBox.Text.ToLower();
            if (searchText != "")
            {
                List<string> filteredUsernames = friends.Values
                                                     .Where(user => user.username.ToLower().Contains(searchText))
                                                     .Select(user => user.username)
                                                     .ToList();
                listBox.Items.Clear();

                foreach (string user in filteredUsernames)
                {
                    listBox.Items.Add(user);
                }
            }
            else
            {
                LoadUsernames();
            }
        }

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
        }

        private bool addAllowedUserToSeePost(UserInfo user, Post key)
        {
            allowedProfiles[key].Add(user);
            return true;
        }

        private void SaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            foreach (UserInfo user in friends.Values)
            {
                if (allowedNames.Contains(user.username))
                {
                    addAllowedUserToSeePost(user, getCurrentPost());
                }
            }

            MessageBox.Show("Restricted Usernames: " + string.Join(", ", allowedNames));
        }

        private void CheckedFunction(object sender, RoutedEventArgs e)
        {
            CheckBox clickedButton = (CheckBox)sender;
            Grid grid = (Grid)VisualTreeHelper.GetParent(clickedButton);
            TextBlock textBlock = (TextBlock)grid.Children[1];
            string username = textBlock.Text;
            allowedNames.Add(username);
            MessageBox.Show("Restricted: " + username);
        }

        private void UnCheckedFunction(object sender, RoutedEventArgs e)
        {
            CheckBox clickedButton = (CheckBox)sender;
            Grid grid = (Grid)VisualTreeHelper.GetParent(clickedButton);
            TextBlock textBlock = (TextBlock)grid.Children[1];
            string username = textBlock.Text;
            allowedNames.Remove(username);
            MessageBox.Show("Removed from restricted: " + username);
        }
    }
}
