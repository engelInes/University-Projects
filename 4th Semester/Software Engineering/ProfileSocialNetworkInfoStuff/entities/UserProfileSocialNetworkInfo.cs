using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.entities
{
    public class UserProfileSocialNetworkInfo
    {
        public User user { get; set; }
        public List<BlockedProfile> blockedProfiles { get; set; }
        public List<CloseFriendProfile> closeFriendsProfiles { get; set; }
        public List<Group> groups { get; set; }

        public List<User> restrictedStoriesAudience { get; set; }

        public List<User> restrictedPostsAudience { get; set; }

        public bool isProfilePrivate { get; set; }

        public UserProfileSocialNetworkInfo() { }

        public UserProfileSocialNetworkInfo(User user, List<BlockedProfile> blockedProfiles, List<CloseFriendProfile> closeFriendsProfiles, List<Group> groups, List<User> restrictedStoriesAudience, List<User> restrictedPostsAudience)
        {
            this.user = user;
            this.blockedProfiles = blockedProfiles;
            this.closeFriendsProfiles = closeFriendsProfiles;
            this.groups = groups;
            this.restrictedStoriesAudience = restrictedStoriesAudience;
            this.restrictedPostsAudience = restrictedPostsAudience;
            this.isProfilePrivate = false;
        }

    }
}
