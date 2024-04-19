using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Enitities.Mocks
{
    internal class MockPost
    {
        private Guid postId;
        private Object User;
        private Dictionary<int, List<Object>> reactions;
        private List<Object> mentionedUsers;
        private string title;

        public MockPost(object user, Dictionary<int, List<object>> reactions, List<object> mentionedUsers, string title)
        {
            this.postId = Guid.NewGuid();
            User = user;
            this.reactions = reactions;
            this.mentionedUsers = mentionedUsers;
            this.title = title;
        }
        public Guid getPostId() { return postId; }
        public void setPostId(Guid postId) {  this.postId = postId; }

    }
}
