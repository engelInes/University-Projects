using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Repository;
using District_3_App.ProfileSocialNetworkInfoStuff.sorting_module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Service
{
    public class ProfileNetworkInfoService
    {
        public ProfileNetworkInfoRepository<UserProfileSocialNetworkInfo> Repository { get; set; }
        public GroupsRepository groupsRepository { get; set; }
        public UsersRepository usersRepository { get; set; }


        public User currentConnectedUser { get; set; }

        public ProfileNetworkInfoService()
        {
            ////     HARDCODED STUFF

            
        }
        public ProfileNetworkInfoService(GroupsRepository groupsRepository, ProfileNetworkInfoRepository<UserProfileSocialNetworkInfo> repository, UsersRepository usersRepository)
        {
            this.groupsRepository = groupsRepository;
            this.Repository = repository;
            this.usersRepository = usersRepository;
        }


        //delegate types: takes 2 BlockedProfile params and returns int using CompareTo function
        public Func<BlockedProfile, BlockedProfile, int> compareBlockedProfilesByDate = (Profile1, Profile2) => Profile1.blockDate.CompareTo(Profile2.blockDate);
        public Func<CloseFriendProfile, CloseFriendProfile, int> compareCloseFriendsByUsername = (Profile1, Profile2) => Profile1.user.CompareTo(Profile2.user);
        public Func<Group, Group, int> compareGroupsByName = (Group1, Group2) => Group1.groupName.CompareTo(Group2.groupName);

        public Func<User, User, int> compareUsersByUsername = (User1, User2) => User1.username.CompareTo(User2.username);
        //public Func<LikedPost, LikedPost, int> compareLikedPostbyDate = (Post1, Post2) => Post1.date.CompareTo(Post2.date);


        public Func<BlockedProfile, BlockedProfile, int> CompareBlockedProfilesByDate
        {
            get { return this.compareBlockedProfilesByDate; }
        }
        public Func<CloseFriendProfile, CloseFriendProfile, int> CompareCloseFriendsByUsername
        {
            get { return this.compareCloseFriendsByUsername; }
        }
        public Func<Group, Group, int> CompareGroupsByName
        {
            get { return this.compareGroupsByName; }
        }
        public Func<User, User, int> CompareRestrictedUsersByUsername
        {
            get { return this.compareUsersByUsername; }
        }

        //public Func<LikedPost, LikedPost, int> CompareLikedPostsByDate
        //{
        //    get { return this.compareLikedPostbyDate; }
        //}


        public void QuickSortBlockedProfiles(Func<BlockedProfile, BlockedProfile, int> CompareFunction)
        {
            if (this.Repository.getProfileRepositoryList().Count > 0 && this.Repository.getProfileRepositoryList() != null)
            {
                ISortingAlgorithms<BlockedProfile> sortingAlgorithms = new SortingAlgorithms<BlockedProfile>();

                foreach (UserProfileSocialNetworkInfo profile in this.Repository.getProfileRepositoryList())
                {
                    sortingAlgorithms.QuickSortDescending(profile.blockedProfiles, CompareFunction);
                }
            }
        }

        public void QuickSortRestrictedPostsAudience(Func<User, User, int> CompareFunction)
        {
            if (this.Repository.getProfileRepositoryList().Count > 0 && this.Repository.getProfileRepositoryList() != null)
            {
                ISortingAlgorithms<User> sortingAlgorithms = new SortingAlgorithms<User>();

                foreach (UserProfileSocialNetworkInfo profile in this.Repository.getProfileRepositoryList())
                {
                    sortingAlgorithms.QuickSortAscending(profile.restrictedPostsAudience, CompareFunction);
                }
            }
        }


        public void QuickSortRestrictedStoriesAudience(Func<User, User, int> CompareFunction)
        {
            if (this.Repository.getProfileRepositoryList().Count > 0 && this.Repository.getProfileRepositoryList() != null)
            {
                ISortingAlgorithms<User> sortingAlgorithms = new SortingAlgorithms<User>();

                foreach (UserProfileSocialNetworkInfo profile in this.Repository.getProfileRepositoryList())
                {
                    sortingAlgorithms.QuickSortAscending(profile.restrictedStoriesAudience, CompareFunction);
                }
            }
        }

        public void QuickSortCloseFriends(Func<CloseFriendProfile, CloseFriendProfile, int> CompareFunction)
        {
            if (this.Repository.getProfileRepositoryList().Count > 0 && this.Repository.getProfileRepositoryList() != null)
            {
                ISortingAlgorithms<CloseFriendProfile> sortingAlgorithms = new SortingAlgorithms<CloseFriendProfile>();

                foreach (UserProfileSocialNetworkInfo profile in this.Repository.getProfileRepositoryList())
                {
                    sortingAlgorithms.QuickSortAscending(profile.closeFriendsProfiles, CompareFunction);
                }
            }
        }

        public void QuickSortGroups(Func<Group, Group, int> CompareFunction)
        {
            if (this.Repository.getProfileRepositoryList().Count > 0 && this.Repository.getProfileRepositoryList() != null)
            {
                ISortingAlgorithms<Group> sortingAlgorithms = new SortingAlgorithms<Group>();

                foreach (UserProfileSocialNetworkInfo profile in this.Repository.getProfileRepositoryList())
                {
                    sortingAlgorithms.QuickSortAscending(profile.groups, CompareFunction);
                }
            }
        }




        public bool CheckIfProfileExists(UserProfileSocialNetworkInfo profileToCheck)
        {
            foreach (var profile in this.GetAllUserProfileSocialNetworks())
            {
                if (profile.user.id == profileToCheck.user.id)
                    return true;
            }
            return false;
        }

        public List<UserProfileSocialNetworkInfo> GetAllUserProfileSocialNetworks()
        {

            return this.Repository.getProfileRepositoryList();
        }

        public UserProfileSocialNetworkInfo GetProfileSocialNetworkInfoCurrentUser(User currentUser)
        {
            foreach (var profile in this.GetAllUserProfileSocialNetworks())
            {
                if (profile.user.username == currentUser.username)
                    return profile;
            }
            return null;
        }



        public bool AddProfileSocialNetworkInfo(UserProfileSocialNetworkInfo profileToAdd)
        {
            return this.Repository.AddProfileSocialNetworkInfo(profileToAdd);
        }
        public bool RemoveProfileSocialNetworkInfo(UserProfileSocialNetworkInfo profileToRemove)
        {
            return this.Repository.RemoveProfileSocialNetworkInfo(profileToRemove);
        }




        //       add / remove group
        public bool AddGroupToCurrentUser(UserProfileSocialNetworkInfo currentUser, Group groupToAdd)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var group in currentUser.groups) //check if group already exists for this specific user
                    if (group == groupToAdd)
                        return false;

                currentUser.groups.Add(groupToAdd);
                SaveDataIntoXML();
                return true;
            }

            return false;
        }
        public bool RemoveGroupFromCurrentUser(UserProfileSocialNetworkInfo currentUser, Group groupToRemove)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var group in currentUser.groups) //if group is in the groups list for the current user
                {
                    if (group.groupName == groupToRemove.groupName)
                    {
                        currentUser.groups.Remove(group);
                        SaveDataIntoXML();
                        return true;
                    }
                }


            }

            return false;
        }




        //       add / remove close friend
        public bool AddCloseFriendToCurrentUser(UserProfileSocialNetworkInfo currentUser, CloseFriendProfile closeFriendToAdd)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var closeFriend in currentUser.closeFriendsProfiles)
                    if (closeFriend == closeFriendToAdd)
                        return false;

                currentUser.closeFriendsProfiles.Add(closeFriendToAdd);
                SaveDataIntoXML();
                return true;
            }

            return false;
        }
        public bool RemoveCloseFriendFromCurrentUser(UserProfileSocialNetworkInfo currentUser, CloseFriendProfile closeFriendToRemove)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var closeFriend in currentUser.closeFriendsProfiles)
                {
                    if (closeFriend.user.id == closeFriendToRemove.user.id)
                    {
                        currentUser.closeFriendsProfiles.Remove(closeFriend);
                        SaveDataIntoXML();
                        return true;
                    }
                }


            }

            return false;
        }








        //       add / remove blocked profile
        public bool AddBlockedProfileToCurrentUser(UserProfileSocialNetworkInfo currentUser, BlockedProfile blockedProfileToAdd)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var blockedProfile in currentUser.blockedProfiles)
                    if (blockedProfile.user.id == blockedProfileToAdd.user.id)
                        return false;

                currentUser.blockedProfiles.Add(blockedProfileToAdd);
                SaveDataIntoXML();
                return true;
            }

            return false;
        }
        public bool RemoveBlockedProfileFromCurrentUser(UserProfileSocialNetworkInfo currentUser, BlockedProfile blockedProfileToRemove)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var blockedProfile in currentUser.blockedProfiles)
                {
                    if (blockedProfile.user.id == blockedProfileToRemove.user.id)
                    {
                        currentUser.blockedProfiles.Remove(blockedProfile);
                        SaveDataIntoXML();
                        return true;
                    }
                }


            }

            return false;
        }





        //add / remove     Restricted posts
        public bool AddRestrictedPostsAudienceUserToCurrentUser(UserProfileSocialNetworkInfo currentUser, User userToAdd)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var restrictedUser in currentUser.restrictedPostsAudience)
                    if (restrictedUser == userToAdd)
                        return false;

                currentUser.restrictedPostsAudience.Add(userToAdd);
                SaveDataIntoXML();
                return true;
            }

            return false;
        }
        public bool RemoveRestrictedPostsAudienceUserFromCurrentUser(UserProfileSocialNetworkInfo currentUser, User userToRemove)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var restrictedUser in currentUser.restrictedPostsAudience) //if group is in the groups list for the current user
                {
                    if (restrictedUser.username == userToRemove.username)
                    {
                        currentUser.restrictedPostsAudience.Remove(restrictedUser);
                        SaveDataIntoXML();


                        return true;
                    }
                }


            }

            return false;
        }






        //add / remove     Restricted stories
        public bool AddRestrictedStoriesAudienceUserToCurrentUser(UserProfileSocialNetworkInfo currentUser, User userToAdd)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var restrictedUser in currentUser.restrictedStoriesAudience)
                    if (restrictedUser == userToAdd)
                        return false;

                currentUser.restrictedStoriesAudience.Add(userToAdd);
                SaveDataIntoXML();
                return true;
            }

            return false;
        }
        public bool RemoveRestrictedStoriesAudienceUserFromCurrentUser(UserProfileSocialNetworkInfo currentUser, User userToRemove)
        {
            if (this.CheckIfProfileExists(currentUser))
            {
                foreach (var restrictedUser in currentUser.restrictedStoriesAudience) //if group is in the groups list for the current user
                {
                    if (restrictedUser.username == userToRemove.username)
                    {
                        currentUser.restrictedStoriesAudience.Remove(restrictedUser);
                        SaveDataIntoXML();
                        return true;
                    }
                }


            }

            return false;
        }









        public List<Group> GetAllGroupsService()
        {
            return this.groupsRepository.GetAllGroups();
        }


        public Group GetGroupByName(string name)
        {
            return this.groupsRepository.GetGroupByGroupName(name);
        }



        public bool CreateGroupToRepository(string groupName, List<User> groupMembers)
        {
            Group groupToAdd = new Group(Guid.NewGuid(), groupName, groupMembers);

            return groupsRepository.AddGroup(groupToAdd);

        }
        public bool DeleteGroupFromRepository(string groupName)
        {
            if (groupsRepository.GetGroupByGroupName(groupName) == null)
                return false;

            groupsRepository.RemoveGroup(groupsRepository.GetGroupByGroupName(groupName));
            return true;

        }

        public bool AddMemberToGroup(string groupName, User user)
        {
            return groupsRepository.AddMemberToGroup(groupName, user);
        }

        public bool RemoveMemberFromGroup(string groupName, User user)
        {
            return groupsRepository.RemoveMemberFromGroup(groupName, user);
        }




        public void AddMemberToGroupProfile(UserProfileSocialNetworkInfo profile, string groupName, string username)
        {
            foreach(var gr in profile.groups)
            {
                if(gr.groupName == groupName)
                {

                    foreach (var user in GetAllUsers())
                    {
                        if(user.username == username)
                        gr.groupMembers.Add(user);
                    }

                }

            }
        }






        //// USERS REPOSITORY
        ///
        public User GetUserByName(string username)
        {
            return usersRepository.GetUserByName(username);
        }

        public List<User> GetAllUsers()
        {
            return usersRepository.GetAllUsers();
        }

        public UserProfileSocialNetworkInfo GetProfileSocialNetworkInfoByUser(string username)
        {
            foreach (User user in usersRepository.GetAllUsers())
            {
                if (user.username == username)
                    foreach (var profile in Repository.getProfileRepositoryList())
                    {
                        if (profile.user.username == username)
                            return profile;
                    }
            }
            return null;
        }


        public BlockedProfile GetBlockedProfileByName(UserProfileSocialNetworkInfo profile, string username)
        {

            foreach (var blockedProfile in profile.blockedProfiles)
            {
                if (blockedProfile.user.username == username) return blockedProfile;
            }

            return null;
        }


        public CloseFriendProfile GetCloseFriendByName(UserProfileSocialNetworkInfo profile, string username)
        {
            foreach(var closeFriend in profile.closeFriendsProfiles)
            {
                if (closeFriend.user.username == username) return closeFriend;

            }
            return null;
        }




        public void SwitchAccountPrivacyPublicPrivate(User currentConnectedUser)
        {
            UserProfileSocialNetworkInfo profile = GetProfileSocialNetworkInfoByUser(currentConnectedUser.username);


            profile.isProfilePrivate = !profile.isProfilePrivate;

            SaveDataIntoXML();
        }


        public void SaveDataIntoXML()
        {
            this.Repository.SaveProfilesInXML();
        }

    }
}
