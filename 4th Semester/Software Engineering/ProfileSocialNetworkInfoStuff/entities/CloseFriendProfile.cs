using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.entities
{
    public class CloseFriendProfile : IComparable<CloseFriendProfile>
    {
        public User user { get; set; }

        public DateTime closeFriendedDate { get; set; } 

        public CloseFriendProfile() { }

        public CloseFriendProfile(User user, DateTime closeFriendedDate)
        {
            this.user = user;
            this.closeFriendedDate = closeFriendedDate;
        }

        public int CompareTo(CloseFriendProfile other)
        {
            return this.user.CompareTo(other.user);
        }
    }
}
