using District_3_App.Enitities.Mocks;
using District_3_App.ExtraInfo;
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 24630eb (conflicte)
using District_3_App.LogIn;
using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Service
{
    internal class CasualProfileService
    {
        private SnapshotsService snapshotsService { get; set; }
        private ProfileInfoSettings profileInfoSettings { get; set; }
        //private ExtraInfoService extraInfoService { get; set; }

        public CasualProfileService()
        {
            this.snapshotsService = new SnapshotsService(getConnectedUserId());
            this.profileInfoSettings = new ProfileInfoSettings(getConnectedUserId());
        }
        public List<MockPost> getConnectedUserPosts() {
            return null;
        }
        public Guid getConnectedUserId() {
<<<<<<< HEAD
            UserManager userManager= new UserManager("Users.xml");
=======
            UserManager userManager= new UserManager("C:\\Users\\40723\\Source\\Repos\\913-Herta-Diana\\UBB-SE-2024-District3\\District 3 App\\Users.xml");
>>>>>>> parent of 24630eb (conflicte)
            IReadOnlyList<User> users=userManager.GetUsers();
            foreach(User user in users)
            {
                if (userManager.IsUserLoggedIn())
                    return user.id;
            }
            return new Guid("11111111-1111-1111-1111-111111111111");
        }
        public List<MockPhotoPost> GetConnectedUserPosts()
        {
            Guid userId=getConnectedUserId();
            List<MockPhotoPost> posts = new List<MockPhotoPost>();
            string path1 = "/Images/snow.jpg";
            string path2 = "/Images/peeta.jpeg";
            string path3 = "/Images/katniss.jpg";
            string path4 = "/Images/poster.jpeg";

            MockPhotoPost post1 = new MockPhotoPost(userId, new Dictionary<int, List<object>>(), new List<object>(), "Title 1", "Description 1", path1);
            post1.setPostId(new Guid("11111111-1111-1111-1111-111111111111"));
            MockPhotoPost post2 = new MockPhotoPost(userId, new Dictionary<int, List<object>>(), new List<object>(), "Title 2", "Description 2", path2);
            post2.setPostId(new Guid("22222222-2222-2222-2222-222222222222"));
            MockPhotoPost post3 = new MockPhotoPost(userId, new Dictionary<int, List<object>>(), new List<object>(), "Title 3", "Description 3", path3);
            post3.setPostId(new Guid("33333333-3333-3333-3333-333333333333"));
            MockPhotoPost post4 = new MockPhotoPost(userId, new Dictionary<int, List<object>>(), new List<object>(), "Title 4", "Description 4", path4);
            post4.setPostId(new Guid("44444444-4444-4444-4444-444444444444"));

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post4);

            return posts;
        }

        public SnapshotsService getSnapshotsService()
        {
            return snapshotsService;
        }
        public ProfileInfoSettings getProfileInfoSettings()
        {
            return profileInfoSettings;
        }
    }
}
