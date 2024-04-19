using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Enitities.Mocks
{
    internal class MockPhotoPost : MockPost
    {
        private string description;
        private string filePath;

        public MockPhotoPost(object user, Dictionary<int, List<object>> reactions, List<object> mentionedUsers, string title, string description, string photo)
            : base(user, reactions, mentionedUsers, title)
        {
            this.description = description;
            this.filePath = photo;
        }

        public string getPhoto()
        {
            return filePath;
        }

        public string getDescription() { return description; }
    }
}
