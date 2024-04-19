using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Enitities
{
    public class Highlight
    {
        private Guid highlightId;
        private Guid userId;
        private List<Guid> postsIds;
        private string Name;
        private string coverFilePath;

        public Highlight() { }
        public Highlight(string newName, string newCover)
        {
            this.highlightId = Guid.NewGuid();
            this.postsIds = new List<Guid>();
            this.Name = newName;
            this.coverFilePath = newCover;
        }
        public Guid getHighlightId()
        {
            return highlightId;
        }
        public List<Guid> getPosts()
        {
            return postsIds;
        }
        public string getName()
        {
            return Name;
        }
        public string getCover()
        {
            return coverFilePath;
        }
        public bool addPostToHighlight(Guid postId)
        {
            this.postsIds.Add(postId);
            return true;
        }

        public bool removePostFromHighlight(Guid postId)
        {
            this.postsIds.Remove(postId);
            return true;
        }
        public void setName(string newName)
        {
            this.Name = newName;
        }
        public void setCover(string coverFilePath)
        {
            this.coverFilePath= coverFilePath;
        }
        public void setListPosts(List<Guid> postsIds)
        {
            this.postsIds = postsIds;
        }
        public void setGuid(Guid guid)
        {
             this.highlightId = guid;
        }

        internal void setListPosts(List<string> list)
        {
           List<Guid> guids = new List<Guid>();
            foreach (var post in list)
            {
                guids.Add(Guid.Parse(post));
            }
            this.setListPosts(guids);
        }
        public void setUserId(Guid userId)
        {
            this.userId = userId;
        }
        public Guid getUserId()
        {
            return userId;
        }
    }
}
