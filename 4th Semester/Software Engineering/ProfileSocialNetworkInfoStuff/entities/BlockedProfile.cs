using District_3_App.ExtraInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.entities
{
    public class BlockedProfile : IComparable<BlockedProfile>
    {
        public User user { get; set; }
        public DateTime blockDate { get; set; }

        public BlockedProfile() { }

        public BlockedProfile(User user, DateTime date)
        {
            this.user = user;
            this.blockDate = date;
        }

        public string DateToString()
        {
            return blockDate.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public int CompareTo(BlockedProfile other)
        {
            return this.blockDate.CompareTo(other.blockDate);
        }
    }
}
