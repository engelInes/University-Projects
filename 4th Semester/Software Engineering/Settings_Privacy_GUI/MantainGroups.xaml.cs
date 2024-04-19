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
    /// Interaction logic for MantainGroups.xaml
    /// </summary>
    public partial class MantainGroups : UserControl
    {
        private ProfileNetworkInfoService profileNetworkInfoService;
        private User currentConnectedUser;

        public MantainGroups(User currentConnectedUser, ProfileNetworkInfoService profileNetworkInfoService)
        {
            InitializeComponent();


            this.currentConnectedUser = currentConnectedUser;
            this.profileNetworkInfoService = profileNetworkInfoService;


            //PopulateAllGroupsList();
            PopulateGroupsForCurrentUser();
            PopulateGroupMemberForSelectedGroup();
        }


        public void PopulateAllGroupsList()
        {
            if (searchGroupNameTextBox.Text != "" && profileNetworkInfoService != null)
            {
                allGroupsListView.Items.Clear();

                foreach (var group in profileNetworkInfoService.GetAllGroupsService())
                {
                    if (group.groupName.Contains(searchGroupNameTextBox.Text) || searchGroupNameTextBox.Text == "")
                        allGroupsListView.Items.Add(group.groupName);
                }
            } else if(searchGroupNameTextBox.Text == "")
            {
                allGroupsListView.Items.Clear();
                foreach (var group in profileNetworkInfoService.GetAllGroupsService())
                {
                        allGroupsListView.Items.Add(group.groupName);
                }
            }
        }


        public void PopulateGroupsForCurrentUser()
        {
            currentUserGroupsListView.Items.Clear();

            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);

            foreach (var group in profile.groups)
            {
                currentUserGroupsListView.Items.Add(group.groupName);
            }
        }


        public void PopulateGroupMemberForSelectedGroup()
        {
            if (currentUserGroupsListView.SelectedItems.Count > 0)
            {
                currentUserGroupMembersListView.Items.Clear();
                string selectedGroupName = currentUserGroupsListView.SelectedItem.ToString(); //get selected group members

                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);


                foreach (var group in profile.groups)
                {
                    if (group.groupName == selectedGroupName)
                    {
                        foreach (var groupMember in group.groupMembers)
                        {
                            currentUserGroupMembersListView.Items.Add(groupMember.username);
                        }
                    }
                }

            }
        }

        private void currentUserGroupsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateGroupMemberForSelectedGroup();
        }

        private void searchGroupNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateAllGroupsList();
        }

        private void joinGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (allGroupsListView.SelectedItems.Count > 0)
            {
                bool userAlreadyInGroup = false;
                string selectedGroupName = allGroupsListView.SelectedItem.ToString();
                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);


                foreach (var groupMember in profileNetworkInfoService.GetGroupByName(selectedGroupName).groupMembers)
                {
                    if (groupMember.username == profile.user.username)
                    {
                        userAlreadyInGroup = true;
                    }
                }
                if (userAlreadyInGroup == false)
                {
                    profileNetworkInfoService.AddGroupToCurrentUser(profile, profileNetworkInfoService.GetGroupByName(selectedGroupName));
                    profileNetworkInfoService.GetGroupByName(selectedGroupName).groupMembers.Add(profile.user);
                    profileNetworkInfoService.SaveDataIntoXML();


                    PopulateGroupsForCurrentUser();
                    PopulateGroupMemberForSelectedGroup();
                }
            }
        }

        private void createGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (newGroupNameTextBox.Text != "")
            {
                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);
                bool alreadyExists = false;

                foreach (var group in profileNetworkInfoService.GetAllGroupsService())
                {
                    if (group.groupName == newGroupNameTextBox.Text)
                        alreadyExists = true;
                }

                if (alreadyExists) MessageBox.Show("Group with this name already exists", "Error creating new group");
                else
                {
                    List<User> groupMembers = new List<User>();
                    groupMembers.Add(currentConnectedUser);


                    profileNetworkInfoService.CreateGroupToRepository(newGroupNameTextBox.Text, groupMembers);
                    profile.groups.Add(profileNetworkInfoService.GetGroupByName(newGroupNameTextBox.Text));
                    profileNetworkInfoService.SaveDataIntoXML();


                    PopulateAllGroupsList();
                    PopulateGroupsForCurrentUser();
                    PopulateGroupMemberForSelectedGroup();
                }
            }
        }

        private void addMemberToSpecificGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (addMemberToSelectedGroupTextBox.Text != "" && currentUserGroupsListView.SelectedItems.Count > 0)
            {
                string selectedGroup = currentUserGroupsListView.SelectedItem.ToString();


                if (profileNetworkInfoService.GetUserByName(addMemberToSelectedGroupTextBox.Text) != null && profileNetworkInfoService.GetGroupByName(selectedGroup) != null)
                {
                    UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);

                    if (profileNetworkInfoService.AddMemberToGroup(selectedGroup, profileNetworkInfoService.GetUserByName(addMemberToSelectedGroupTextBox.Text)))
                    {
                        UserProfileSocialNetworkInfo addedMemberProfile = profileNetworkInfoService.GetProfileSocialNetworkInfoByUser(addMemberToSelectedGroupTextBox.Text);
                        if (addedMemberProfile != null)
                        {
                            addedMemberProfile.groups.Add(profileNetworkInfoService.GetGroupByName(selectedGroup));
                            profileNetworkInfoService.AddMemberToGroupProfile(profile, selectedGroup, addMemberToSelectedGroupTextBox.Text);
                            
                            profileNetworkInfoService.SaveDataIntoXML();


                            PopulateGroupMemberForSelectedGroup();
                            PopulateGroupsForCurrentUser();
                        }
                        else
                        {
                            MessageBox.Show("Profile of give user not found, try again", "error");
                        }
                    }
                }
            }
        }
    }
}
