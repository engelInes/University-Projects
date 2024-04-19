using District_3_App.CloseFriends_GUI;
using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Repository;
using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Service;
using District_3_App.Settings_Privacy_GUI;
using Statistics;
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



namespace District_3_App.ExtraInfo
{
    /// <summary>
    /// Interaction logic for ExtraInfo.xaml
    /// </summary>
    public partial class ExtraInfo : UserControl
    {
        private ProfileNetworkInfoService profileNetworkInfoService;
        private User currentConnectedUser;

        public ExtraInfo()
        {
            ////     HARDCODED STUFF

            User user1 = new User(Guid.NewGuid(), "username1", "password1", "user1@yahoo.ro", "password1");
            User user2 = new User(Guid.NewGuid(), "username2", "password2", "username2@gmail.ro", "password2");
            User user3 = new User(Guid.NewGuid(), "username3", "password3", "user3@yahoo.com", "password3");
            User user4 = new User(Guid.NewGuid(), "username4", "password4", "username4@stud.ubbcluj.ro", "password4");
            User user5 = new User(Guid.NewGuid(), "username5", "password5", "username4@gmail.es", "password5");
            List<User> usersList = new List<User>(); usersList.Add(user1); usersList.Add(user2); usersList.Add(user3); usersList.Add(user4); usersList.Add(user5);
            UsersRepository usersRepo = new UsersRepository(usersList);


            BlockedProfile blockedProfile1 = new BlockedProfile(user5, new DateTime(2023, 12, 02, 18, 40, 10));
            BlockedProfile blockedProfile2 = new BlockedProfile(user2, new DateTime(2023, 12, 02, 17, 50, 10));
            BlockedProfile blockedProfile3 = new BlockedProfile(user3, new DateTime(2023, 12, 02, 17, 50, 15));
            BlockedProfile blockedProfile4 = new BlockedProfile(user4, new DateTime(2022, 11, 02, 17, 50, 15));


            CloseFriendProfile closeFriendProfile1 = new CloseFriendProfile(user3, new DateTime(2023, 12, 02, 18, 40, 10));
            CloseFriendProfile closeFriendProfile2 = new CloseFriendProfile(user4, new DateTime(2023, 12, 02, 18, 40, 10));
            CloseFriendProfile closeFriendProfile3 = new CloseFriendProfile(user5, new DateTime(2023, 12, 02, 18, 40, 10));
            CloseFriendProfile closeFriendProfile4 = new CloseFriendProfile(user2, new DateTime(2023, 12, 02, 18, 40, 10));


            List<User> group1Members = new List<User>(); group1Members.Add(user2); group1Members.Add(user3); group1Members.Add(user1);
            List<User> group2Members = new List<User>(); group2Members.Add(user1); group2Members.Add(user5); group2Members.Add(user4);
            List<User> group3Members = new List<User>(); group3Members.Add(user1); group3Members.Add(user5); group3Members.Add(user2);
            List<User> anotherGroupMembers = new List<User>(); anotherGroupMembers.Add(user5); anotherGroupMembers.Add(user3);


            Group group1 = new Group(Guid.NewGuid(), "group 1", group1Members);
            Group group2 = new Group(Guid.NewGuid(), "group 3", group2Members);
            Group group3 = new Group(Guid.NewGuid(), "group 2", group3Members);
            Group group4 = new Group(Guid.NewGuid(), "another group", anotherGroupMembers);
            List<Group> groups = new List<Group>(); groups.Add(group1); groups.Add(group2); groups.Add(group3); groups.Add(group4);



            //some hardocded profile perspective examples
            UserProfileSocialNetworkInfo profileUser1 = new UserProfileSocialNetworkInfo(user1, new List<BlockedProfile> { blockedProfile2, blockedProfile3 }, new List<CloseFriendProfile> { closeFriendProfile4, closeFriendProfile3 }, new List<Group> { group1, group2, group3 }, new List<User> { user2, user3 }, new List<User> { user2, user3 });
            UserProfileSocialNetworkInfo profileUser2 = new UserProfileSocialNetworkInfo(user2, new List<BlockedProfile> { blockedProfile1, blockedProfile3 }, new List<CloseFriendProfile> { closeFriendProfile4 }, new List<Group>{group1, group3}, new List<User>(), new List<User>());
            UserProfileSocialNetworkInfo profileUser3 = new UserProfileSocialNetworkInfo(user3, new List<BlockedProfile>(), new List<CloseFriendProfile>(), new List<Group> { group1, group3 }, new List<User>(), new List<User>());
            UserProfileSocialNetworkInfo profileUser5 = new UserProfileSocialNetworkInfo(user5, new List<BlockedProfile>(), new List<CloseFriendProfile>(), new List<Group> { group2, group3, group4 }, new List<User>(), new List<User>());



            List<UserProfileSocialNetworkInfo> userProfileSocialNetworkInfos = new List<UserProfileSocialNetworkInfo>();
            userProfileSocialNetworkInfos.Add(profileUser1); userProfileSocialNetworkInfos.Add(profileUser2);  userProfileSocialNetworkInfos.Add(profileUser3); userProfileSocialNetworkInfos.Add(profileUser5);

            //init repos with profiles list and groups list
            GroupsRepository groupsRepository = new GroupsRepository();
            ProfileNetworkInfoRepository<UserProfileSocialNetworkInfo> userProfileNetowrkRepository = new ProfileNetworkInfoRepository<UserProfileSocialNetworkInfo>();
            //init profile info service with profile list
            ProfileNetworkInfoService profileNetworkInfoService = new ProfileNetworkInfoService(groupsRepository, userProfileNetowrkRepository, usersRepo);



            
            //profileNetworkInfoService.CreateGroupToRepository("group 1", group1Members);
            //profileNetworkInfoService.CreateGroupToRepository("group 3", group3Members);
            //profileNetworkInfoService.CreateGroupToRepository("group 2", group2Members);
            //profileNetworkInfoService.CreateGroupToRepository("another group", anotherGroupMembers);

           

            this.currentConnectedUser = user1;
            this.profileNetworkInfoService = profileNetworkInfoService;






            //// ADD DATA TO THE SERVICE
            profileNetworkInfoService.AddProfileSocialNetworkInfo(profileUser1);
            profileNetworkInfoService.AddProfileSocialNetworkInfo(profileUser2);
            profileNetworkInfoService.AddProfileSocialNetworkInfo(profileUser5);



            profileNetworkInfoService.AddBlockedProfileToCurrentUser(profileUser1, blockedProfile2);
            profileNetworkInfoService.AddBlockedProfileToCurrentUser(profileUser1, blockedProfile4);
            profileNetworkInfoService.AddCloseFriendToCurrentUser(profileUser1, closeFriendProfile2);

            profileNetworkInfoService.AddGroupToCurrentUser(profileUser1, group1);
            profileNetworkInfoService.AddGroupToCurrentUser(profileUser1, group3);
            profileNetworkInfoService.AddGroupToCurrentUser(profileUser1, group2);




            profileNetworkInfoService.AddRestrictedPostsAudienceUserToCurrentUser(profileUser1, user3);
            profileNetworkInfoService.AddRestrictedStoriesAudienceUserToCurrentUser(profileUser1, user3);
            profileNetworkInfoService.AddRestrictedPostsAudienceUserToCurrentUser(profileUser1, user2);
            profileNetworkInfoService.AddRestrictedStoriesAudienceUserToCurrentUser(profileUser1, user2);
            profileNetworkInfoService.AddRestrictedPostsAudienceUserToCurrentUser(profileUser1, user4);
            profileNetworkInfoService.AddRestrictedStoriesAudienceUserToCurrentUser(profileUser1, user4);


            profileNetworkInfoService.AddBlockedProfileToCurrentUser(profileUser2, blockedProfile3);
            profileNetworkInfoService.AddBlockedProfileToCurrentUser(profileUser2, blockedProfile1);
            profileNetworkInfoService.AddCloseFriendToCurrentUser(profileUser2, closeFriendProfile4);
            profileNetworkInfoService.AddGroupToCurrentUser(profileUser2, group2);
            profileNetworkInfoService.AddGroupToCurrentUser(profileUser2, group3);



            InitializeComponent();
        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            List<UIElement> elementsToRemove = new List<UIElement>();

            foreach (UIElement child in extraInfoGrid.Children)
            {
                int columnIndex = Grid.GetColumn(child);

                if (columnIndex == 1)
                {
                    elementsToRemove.Add(child);
                }
            }
            foreach (UIElement element in elementsToRemove)
            {
                extraInfoGrid.Children.Remove(element);
            }

            var profileInfo = new ProfileInfo_GUI.ProfileInfoDisplay();
            Grid.SetColumn(profileInfo, 1);
            Grid.SetRow(profileInfo, 1);
            Grid.SetRowSpan(profileInfo, 4);
            extraInfoGrid.Children.Add(profileInfo);
        }

        private void SettingsPrivacyButton_Click(object sender, RoutedEventArgs e)
        {
            var settingsPrivacyUserControl = new SettingsPrivacy_UserControl(currentConnectedUser, profileNetworkInfoService);
            Grid.SetColumn(settingsPrivacyUserControl, 1);
            Grid.SetRow(settingsPrivacyUserControl, 1);
            Grid.SetRowSpan(settingsPrivacyUserControl, 4);
            extraInfoGrid.Children.Add(settingsPrivacyUserControl);
        }

        private void FancierProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var paymentForm = new FancierProfilePage();
            Grid.SetColumn(paymentForm, 1);
            Grid.SetRow(paymentForm, 1);
            Grid.SetRowSpan(paymentForm, 4);
            extraInfoGrid.Children.Add(paymentForm);
        }

        private void SavedPostsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseFriendsButton_Click(object sender, RoutedEventArgs e)
        {
            var closeFriendsUserControl = new CloseFriendsSection_UserControl(currentConnectedUser, profileNetworkInfoService);
            Grid.SetColumn(closeFriendsUserControl, 1);
            Grid.SetRow(closeFriendsUserControl, 1);
            Grid.SetRowSpan(closeFriendsUserControl, 4);
            extraInfoGrid.Children.Add(closeFriendsUserControl);
        }

        private void VerifiedAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var newContent = new VerifiedAccount(profileNetworkInfoService);
            extraInfoGrid.Children.Add(newContent);
            Grid.SetColumn(newContent, 1);
            Grid.SetRow(newContent, 1);
            Grid.SetRowSpan(newContent, 4);

        }

        private void FriendsSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            List<UIElement> elementsToRemove = new List<UIElement>();

            foreach (UIElement child in extraInfoGrid.Children)
            {
                int columnIndex = Grid.GetColumn(child);

                if (columnIndex == 1)
                {
                    elementsToRemove.Add(child);
                }
            }

            foreach (UIElement element in elementsToRemove)
            {
                extraInfoGrid.Children.Remove(element);
            }

            var friends = new FriendsSettings.Friends();
            Grid.SetColumn(friends, 1);
            Grid.SetRow(friends, 1);
            Grid.SetRowSpan(friends, 4);
            extraInfoGrid.Children.Add(friends);
        }

        private void LikedPostsButton_Click(object sender, RoutedEventArgs e)
        {
            var likedPosts = new LikedPosts();
            Grid.SetColumn(likedPosts, 1);
            Grid.SetRow(likedPosts, 1);
            Grid.SetRowSpan(likedPosts, 4);
            extraInfoGrid.Children.Add(likedPosts);
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            var statistics = new Statistics.Statistics();
            Grid.SetColumn(statistics, 1);
            Grid.SetRow(statistics, 1);
            Grid.SetRowSpan(statistics, 4);
            extraInfoGrid.Children.Add(statistics);
        }
    }
}
