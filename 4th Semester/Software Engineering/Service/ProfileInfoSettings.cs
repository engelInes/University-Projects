using District_3_App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Service
{
    class ProfileInfoSettings
    {
        private FancierProfileRepo fancierRepo = new FancierProfileRepo();
        private Guid profileId;

        public ProfileInfoSettings(Guid profileId)
        {
            this.profileId = profileId;
        }

        public bool AddDailyMotto(string newMotto)
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            return fancierRepo.AddDailyMotto(profileId, newMotto, tomorrow);
        }

        public bool DeleteDailyMotto()
        {
            return fancierRepo.DeleteDailyMotto(profileId);
        }

        public string GetDailyMotto()
        {
            return fancierRepo.GetDailyMotto(profileId);
        }

        public bool AddLink(string newLink)
        {
            if  (newLink.StartsWith("http://") ||newLink.StartsWith("www.") ) {
                return fancierRepo.AddLink(profileId, newLink);
            }
            return false;
        }

        public bool DeleteLink(string linkToDelete)
        {
            return fancierRepo.DeleteLink(profileId, linkToDelete);
        }

        public List<string> GetLinks()
        {
            return fancierRepo.GetLinks(profileId);
        }

        public bool SetFrameNumber(int newFrameNumber)
        {
            return fancierRepo.SetFrameNumber(profileId, newFrameNumber);
        }

        public bool DeleteFrameNumber()
        {
            return fancierRepo.DeleteFrameNumber(profileId);
        }

        public int GetFrameNumber()
        {
            return fancierRepo.GetFrameNumber(profileId);
        }

        public bool SetHashtag(string newHashtag)
        {
            return fancierRepo.SetHashtag(profileId, newHashtag);
        }

        public bool DeleteHashtag()
        {
            return fancierRepo.DeleteHashtag(profileId);
        }

        public string GetHashtag()
        {
            return fancierRepo.GetHashtag(profileId);
        }
    }
}
