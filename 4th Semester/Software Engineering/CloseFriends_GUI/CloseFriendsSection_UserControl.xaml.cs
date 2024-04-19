using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace District_3_App.CloseFriends_GUI
{
    /// <summary>
    /// Interaction logic for CloseFriendsSection_UserControl.xaml
    /// </summary>
    public partial class CloseFriendsSection_UserControl : UserControl
    {

        private User currentConnectedUser;
        private ProfileNetworkInfoService profileNetworkInfoService;

        public CloseFriendsSection_UserControl(User u, ProfileNetworkInfoService service)
        {
            InitializeComponent();

            this.currentConnectedUser = u;
            this.profileNetworkInfoService = service;


            PopulateCloseFriends();
        }



        public void PopulateCloseFriends()
        {
            if (searchCloseFriendsTextBox.Text.Length > 0 && profileNetworkInfoService != null)
            {
                //closeFriendsListView.Items.Clear();

                //UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);

                //foreach (var user in profileNetworkInfoService.GetAllUsers())
                //{
                //    bool isCloseFriend = false;

                //    foreach (var closeFriend in profile.closeFriendsProfiles)
                //    {
                //        if (closeFriend.user.username == user.username)
                //            isCloseFriend = true;
                //    }

                //    if (!isCloseFriend)
                //    {
                //        //non close friend image
                //        closeFriendsListView.Items.Add(new { Username = user.username, ImagePath = "..\\..\\images\\round_checkBox.jpeg" });
                //    }
                //    else
                //    {
                //        //close firend image
                //        closeFriendsListView.Items.Add(new { Username = user.username, ImagePath = "..\\..\\images\\filled_round_checkBox.jpg" });
                //    }
                //}
                closeFriendsListView.Items.Clear();


                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);

                foreach (var closeFriend in profile.closeFriendsProfiles)
                    if (closeFriend.user.username.Contains(searchCloseFriendsTextBox.Text))
                        closeFriendsListView.Items.Add(closeFriend.user.username);

            }
        }

        private void searchCloseFriendsTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            PopulateCloseFriends();
        }

        private void addNewCloseFriendButton_Click(object sender, RoutedEventArgs e)
        {
            if(searchCloseFriendsTextBox.Text.Length > 0 && profileNetworkInfoService != null)
            {

                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);

                bool usernameExists = false;
                foreach(var user in profileNetworkInfoService.GetAllUsers())
                    if(user.username == searchCloseFriendsTextBox.Text)
                        usernameExists = true;


                if(!usernameExists)
                {
                    MessageBox.Show("Error: User with this username does not exist");
                }
                else
                {
                    bool alreadyCloseFriend = false;
                    foreach(var closeFriend in profile.closeFriendsProfiles)
                    {
                        if(closeFriend.user.username == searchCloseFriendsTextBox.Text)
                            alreadyCloseFriend = true;
                    }

                    if(alreadyCloseFriend)
                    {
                        MessageBox.Show("Error: User is already your close friend");
                    }
                    else
                    {
                        CloseFriendProfile closeFriendToAdd = new CloseFriendProfile(profileNetworkInfoService.GetUserByName(searchCloseFriendsTextBox.Text), DateTime.Now);
                        profile.closeFriendsProfiles.Add(closeFriendToAdd);
                        profileNetworkInfoService.SaveDataIntoXML();

                        PopulateCloseFriends();
                    }
                }
            }
        }

        private void removeCloseFriendButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedCloseFriendUsername = closeFriendsListView.SelectedItem.ToString();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);



            profileNetworkInfoService.RemoveCloseFriendFromCurrentUser(profile, profileNetworkInfoService.GetCloseFriendByName(profile, selectedCloseFriendUsername));
            profileNetworkInfoService.SaveDataIntoXML();


            closeFriendsListView.Items.Clear(); //reset the list view



            foreach (var closeFriend in profile.closeFriendsProfiles)
            {

                closeFriendsListView.Items.Add(closeFriend.user.username);
                //foreach (var groupMember in group.groupMembers)
                //{
                //    groupMembersListView.Items.Add(groupMember.username);
                //}

            }
        }
    }
}
