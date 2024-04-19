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

namespace District_3_App.Settings_Privacy_GUI
{
    /// <summary>
    /// Interaction logic for SettingsPrivacy_UserControl.xaml
    /// </summary>
    public partial class SettingsPrivacy_UserControl : UserControl
    {
        private User currentConnectedUser;
        private ProfileNetworkInfoService profileNetworkInfoService;
        public bool isProfilePrivate { get; set; } 

        public SettingsPrivacy_UserControl(User currentConnectedUser, ProfileNetworkInfoService profileNetworkInfoService)
        {
            InitializeComponent();

            this.currentConnectedUser = currentConnectedUser;
            this.profileNetworkInfoService = profileNetworkInfoService;


            PopulateGroupsForCurrentUser();
            PopulateRestrictedPostsAudienceForCurrentUser();
            PopulateRestrictedStoriesAudienceForCurrentUser();
            PopulateBlockedAccountsForCurrentUser();

            this.passwordChangeTextBox.Password = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser).user.password;


            //this.profileNetworkInfoService = profileNetworkInfoService;
        }



        public void PopulateBlockedAccountsForCurrentUser()
        {
            blockedProfilesListView.Items.Clear();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);


            foreach (var blockedProfile in profile.blockedProfiles)
            {
                blockedProfilesListView.Items.Add(blockedProfile.user.username);
            }
        }

        public void PopulateRestrictedPostsAudienceForCurrentUser()
        {
            restrictedPostsAudienceListView.Items.Clear();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);


            foreach (var restrictedUser in profile.restrictedPostsAudience)
                restrictedPostsAudienceListView.Items.Add(restrictedUser.username);
        }

        public void PopulateRestrictedStoriesAudienceForCurrentUser()
        {
            restrictedStoriesAudienceListView.Items.Clear();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);


            foreach (var restrictedUser in profile.restrictedStoriesAudience)
                restrictedStoriesAudienceListView.Items.Add(restrictedUser.username);
        }


        public void PopulateGroupsForCurrentUser()
        {
            groupsListView.Items.Clear();
            //all groups for current user
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);

            //all the groups
            //List<Group> groupsRepo = profileNetworkInfoService.GetAllGroupsService();


            foreach (var group in profile.groups)
            {

                groupsListView.Items.Add(group.groupName);
                //foreach (var groupMember in group.groupMembers)
                //{
                //    groupMembersListView.Items.Add(groupMember.username);
                //}

            }

        }

        private void leaveGroupButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedGroupName = groupsListView.SelectedItem.ToString();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);





            profileNetworkInfoService.RemoveGroupFromCurrentUser(profile, profileNetworkInfoService.GetGroupByName(selectedGroupName));
            profileNetworkInfoService.SaveDataIntoXML();

            groupsListView.Items.Clear(); //reset the list view



            foreach (var gr in profile.groups)
            {

                groupsListView.Items.Add(gr.groupName);
                //foreach (var groupMember in group.groupMembers)
                //{
                //    groupMembersListView.Items.Add(groupMember.username);
                //}

            }



            //testSelectedItem.Text = selectedGroupName;
        }

        private void mantainGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            MantainGroups mantainGroupsUserControl = new MantainGroups(currentConnectedUser, profileNetworkInfoService);


            settingsPrivacyGrid.Children.Clear();
            settingsPrivacyGrid.Children.Add(mantainGroupsUserControl);
        }

        

        private void removeBlockedAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedBlockedUsername = blockedProfilesListView.SelectedItem.ToString();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);



            profileNetworkInfoService.RemoveBlockedProfileFromCurrentUser(profile, profileNetworkInfoService.GetBlockedProfileByName(profile, selectedBlockedUsername));
            profileNetworkInfoService.SaveDataIntoXML();


            blockedProfilesListView.Items.Clear(); //reset the list view



            foreach (var blockedProfile in profile.blockedProfiles)
            {

                blockedProfilesListView.Items.Add(blockedProfile.user.username);
                //foreach (var groupMember in group.groupMembers)
                //{
                //    groupMembersListView.Items.Add(groupMember.username);
                //}

            }
        }

        private void addBlockedAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameToBlockTextBox.Text != "")
            {

                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);


                bool usernameExists = false;

                foreach (var user in profileNetworkInfoService.GetAllUsers())
                    if (user.username == usernameToBlockTextBox.Text)
                        usernameExists = true;

                if (!usernameExists)
                {
                    MessageBox.Show("Error: user with such username does not exist");

                }
                else
                {





                    bool alreadyExists = false;

                    foreach (var blockedProfile in profile.blockedProfiles)
                    {
                        if (blockedProfile.user.username == usernameToBlockTextBox.Text)
                            alreadyExists = true;
                    }

                    if (alreadyExists)
                    {
                        MessageBox.Show("User is already blocked by you", "Error");
                    }
                    else
                    {
                        DateTime newDate = DateTime.Now;
                        BlockedProfile profileToBlock = new BlockedProfile(profileNetworkInfoService.GetUserByName(usernameToBlockTextBox.Text), newDate);
                        profile.blockedProfiles.Add(profileToBlock);
                        profileNetworkInfoService.SaveDataIntoXML();
                    }




                    blockedProfilesListView.Items.Clear();


                    foreach (var blockedProfile in profile.blockedProfiles)
                    {
                        blockedProfilesListView.Items.Add(blockedProfile.user.username);
                    }
                }

            }
        }

        private void addRestrictedStoriesUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameRestrictTextBox.Text != "") {

                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);


                bool usernameExists = false;

                foreach (var user in profileNetworkInfoService.GetAllUsers())
                    if (user.username == usernameRestrictTextBox.Text)
                        usernameExists = true;

                if (!usernameExists)
                {
                    MessageBox.Show("Error: user with such username does not exist");

                }
                else {



                    bool alreadyExists = false;

                    foreach (var user in profile.restrictedStoriesAudience)
                    {
                        if (user.username == usernameRestrictTextBox.Text)
                            alreadyExists = true;
                    }

                    if (alreadyExists)
                    {
                        MessageBox.Show("User is already restricted from seeing your stories", "Error");
                    }
                    else
                    {
                        profile.restrictedStoriesAudience.Add(profileNetworkInfoService.GetUserByName(usernameRestrictTextBox.Text));
                        profileNetworkInfoService.SaveDataIntoXML();
                    }


                    restrictedStoriesAudienceListView.Items.Clear();


                    foreach (var restrictedUser in profile.restrictedStoriesAudience)
                        restrictedStoriesAudienceListView.Items.Add(restrictedUser.username);

                }
            }
        }

        private void addRestrictedPostsUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameRestrictTextBox.Text != "")
            {

                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);


                bool usernameExists = false;

                foreach (var user in profileNetworkInfoService.GetAllUsers())
                    if (user.username == usernameRestrictTextBox.Text)
                        usernameExists = true;

                if (!usernameExists)
                {
                    MessageBox.Show("Error: user with such username does not exist");

                }
                else
                {



                    bool alreadyExists = false;

                    foreach (var user in profile.restrictedPostsAudience)
                    {
                        if (user.username == usernameRestrictTextBox.Text)
                            alreadyExists = true;
                    }

                    if (alreadyExists)
                    {
                        MessageBox.Show("User is already restricted from seeing your stories", "Error");
                    }
                    else
                    {
                        profile.restrictedPostsAudience.Add(profileNetworkInfoService.GetUserByName(usernameRestrictTextBox.Text));
                        profileNetworkInfoService.SaveDataIntoXML();
                    }


                    restrictedPostsAudienceListView.Items.Clear();


                    foreach (var restrictedUser in profile.restrictedPostsAudience)
                        restrictedPostsAudienceListView.Items.Add(restrictedUser.username);

                }
            }
        }

        private void removeRestrictedStoriesUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedUsername = restrictedStoriesAudienceListView.SelectedItem.ToString();
                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);



                profileNetworkInfoService.RemoveRestrictedStoriesAudienceUserFromCurrentUser(profile, profileNetworkInfoService.GetUserByName(selectedUsername));
                profileNetworkInfoService.SaveDataIntoXML();


                restrictedStoriesAudienceListView.Items.Clear(); //reset the list view



                foreach (var restrictedUser in profile.restrictedStoriesAudience)
                {

                    restrictedStoriesAudienceListView.Items.Add(restrictedUser.username);
                    //foreach (var groupMember in group.groupMembers)
                    //{
                    //    groupMembersListView.Items.Add(groupMember.username);
                    //}

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"[{ex.Message}]: No user selected to remove", "Error");
            }
        }

        private void removeRestrictedPostsUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedUsername = restrictedPostsAudienceListView.SelectedItem.ToString();
                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);



                profileNetworkInfoService.RemoveRestrictedPostsAudienceUserFromCurrentUser(profile, profileNetworkInfoService.GetUserByName(selectedUsername));
                profileNetworkInfoService.SaveDataIntoXML();


                restrictedPostsAudienceListView.Items.Clear(); //reset the list view



                foreach (var restrictedUser in profile.restrictedPostsAudience)
                {

                    restrictedPostsAudienceListView.Items.Add(restrictedUser.username);
                    //foreach (var groupMember in group.groupMembers)
                    //{
                    //    groupMembersListView.Items.Add(groupMember.username);
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[{ex.Message}]: No user selected to remove", "Error");
            }
        }


        private void changePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = passwordChangeTextBox.Password;


            if (newPassword.Length < 15)
            {
                MessageBox.Show("The new password should contian at least 15 digits", "Error");
                return;
            }

            
            bool containsSpecialCharacter = false;
            bool containsDigit = false;

            foreach (char c in newPassword)
            {
                if (char.IsDigit(c))
                {
                    containsDigit = true;
                }
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    containsSpecialCharacter = true;
                }
            }

            if (!containsSpecialCharacter || !containsDigit)
            {
                MessageBox.Show("The new password must contain at least one digit and one special character", "Error");
                return;
            }


            //set new password for the current connected user
            this.currentConnectedUser.password = newPassword;
            profileNetworkInfoService.SaveDataIntoXML();
        }

        private void isProfilePrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            profileNetworkInfoService.SwitchAccountPrivacyPublicPrivate(currentConnectedUser);
        }

        private void isProfilePrivateCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            profileNetworkInfoService.SwitchAccountPrivacyPublicPrivate(currentConnectedUser);
        }
    }
}
