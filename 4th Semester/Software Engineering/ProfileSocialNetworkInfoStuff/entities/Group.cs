using District_3_App.ExtraInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.entities
{
    public class Group : IComparable<Group>
    {
        public Guid Id { get; set; }
        public string groupName { get; set; }

        public List<User> groupMembers { get; set; }


        public Group() { }

        public Group(Guid id, string groupName, List<User> groupMembers)
        {
            this.Id = id;
            this.groupName = groupName;
            this.groupMembers = groupMembers;
        }


        public int CompareTo(Group other)
        {
            return this.groupName.CompareTo(other.groupName);
        }
    }
}
