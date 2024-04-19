using District_3_App.Enitities;
using District_3_App.Enitities.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace District_3_App.Repository
{
    internal class HighlightsRepo
    {
        private Dictionary<Guid, Dictionary<Guid, Highlight>> userHighlights = new Dictionary<Guid, Dictionary<Guid, Highlight>>();
        private string filePath;

        public HighlightsRepo()
        {
            filePath = generateDefaultFilePath();
            Console.WriteLine(filePath);
            if (!File.Exists(filePath))
            {
                createXml(filePath);
            }
            loadHighlights(filePath);
        }

        private string generateDefaultFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Highlights.xml");
        }

        private void createXml(string filePath)
        {
            XDocument xDocument = new XDocument(new XElement("Highlights"));
            xDocument.Save(filePath);
        }

        private void loadHighlights(string filePath)
        {
            Console.WriteLine("Reading highlights from file: " + filePath);

            XDocument xDocument = XDocument.Load(filePath);
            XElement root = xDocument.Element("Highlights");
            if (root != null && root.HasElements)
            {
                foreach (var userElem in root.Elements("User"))
                {
                    Guid userId;
                    if (!Guid.TryParse((string)userElem.Attribute("userId"), out userId))
                    {
                        // Skip this user element if userId attribute is not valid
                        continue;
                    }

                    foreach (var highlightElem in userElem.Elements("Highlight"))
                    {
                        Highlight highlight = new Highlight();
                        highlight.setUserId(userId);

                        // Wrap the parsing in a try-catch block
                        try
                        {
                            Guid guid;
                            if (Guid.TryParse((string)highlightElem.Attribute("guid"), out guid))
                            {
                                highlight.setGuid(guid);
                            }

                            highlight.setName((string)highlightElem.Attribute("name"));

                            var postsElem = highlightElem.Element("posts");
                            if (postsElem != null)
                            {
                                // Parse post elements
                                var posts = postsElem.Elements("post").Select(e =>
                                {
                                    Guid postGuid;
                                    if (Guid.TryParse(e.Value, out postGuid))
                                    {
                                        return postGuid;
                                    }
                                    else
                                    {
                                        return Guid.Empty; // or any other default value
                                    }
                                }).Where(e => e != Guid.Empty).ToList();

                                highlight.setListPosts(posts);
                            }

                            highlight.setCover((string)highlightElem.Attribute("cover"));

                            if (!userHighlights.ContainsKey(userId))
                            {
                                userHighlights[userId] = new Dictionary<Guid, Highlight>();
                            }

                            userHighlights[userId].Add(highlight.getHighlightId(), highlight);
                        }
                        catch (Exception ex)
                        {
                            // Log the error or handle it as needed
                            Console.WriteLine($"Error parsing highlight: {ex.Message}");
                        }
                    }
                }
            }
        }

        public void SaveHighlightsToXml()
        {
            try
            {
                XDocument xDocument;

                if (File.Exists(filePath))
                {
                    xDocument = XDocument.Load(filePath);
                }
                else
                {
                    xDocument = new XDocument(new XElement("Highlights"));
                }

                XElement root = xDocument.Element("Highlights");
                root?.RemoveAll();

                foreach (var userHighlight in userHighlights)
                {
                    XElement userElement = new XElement("User", new XAttribute("userId", userHighlight.Key));

                    foreach (var highlight in userHighlight.Value)
                    {
                        Highlight highlight1 = highlight.Value;
                        XElement highlightElement = new XElement("Highlight",
                            new XAttribute("userId", userHighlight.Key),
                            new XAttribute("guid", highlight1.getHighlightId()), // Use the highlight's guid
                            new XAttribute("name", highlight1.getName()), // Use the highlight's name
                            new XElement("posts", highlight1.getPosts().Select(p => new XElement("post", p))),
                            new XAttribute("cover", highlight1.getCover()));

                        userElement.Add(highlightElement);
                    }

                    root.Add(userElement);
                }

                xDocument.Save(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving highlights to XML: " + ex.Message);
            }
        }

        public List<MockPhotoPost> GetConnectedUserPosts(Guid userId)
        {
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
        public bool AddHighlight(Guid userId, Highlight highlight)
        {
            if (!userHighlights.ContainsKey(userId))
            {
                userHighlights[userId] = new Dictionary<Guid, Highlight>();
            }
            userHighlights[userId].Add(highlight.getHighlightId(), highlight);
            SaveHighlightsToXml();
            return true;
        }

        public bool RemoveHighlight(Guid userId, Guid highlightId)
        {
            if (userHighlights.ContainsKey(userId) && userHighlights[userId].ContainsKey(highlightId))
            {
                userHighlights[userId].Remove(highlightId);
                SaveHighlightsToXml();
                return true;
            }
            return false;
        }

        public bool AddPostToHighlight(Guid userId, Guid postId, Guid highlightId)
        {
            if (userHighlights.ContainsKey(userId) && userHighlights[userId].ContainsKey(highlightId))
            {
                List<Guid> listPosts = userHighlights[userId][highlightId].getPosts();
                if (!listPosts.Contains(postId))
                {
                    listPosts.Add(postId);
                    userHighlights[userId][highlightId].setListPosts(listPosts);
                    SaveHighlightsToXml();
                    return true;
                }
            }
            return false;
        }

        public bool RemovePostFromHighlight(Guid userId, Guid postId, Guid highlightId)
        {
            if (userHighlights.ContainsKey(userId) && userHighlights[userId].ContainsKey(highlightId))
            {
                List<Guid> listPosts = userHighlights[userId][highlightId].getPosts();
                if (listPosts.Contains(postId))
                {
                    listPosts.Remove(postId);
                    userHighlights[userId][highlightId].setListPosts(listPosts);
                    SaveHighlightsToXml();
                    return true;
                }
            }
            return false;
        }

        private List<Highlight> GetHighlights()
        {
            return userHighlights.Values.SelectMany(dict => dict.Values).ToList();
        }

        public List<Highlight> GetHighlightsOfUser(Guid userId)
        {
            if (userHighlights.ContainsKey(userId))
            {
                return userHighlights[userId].Values.ToList();
            }
            else
            {
                return new List<Highlight>();
            }
        }

        public Highlight GetHighlight(Guid userId, Guid highlightId)
        {
            if (userHighlights.ContainsKey(userId) && userHighlights[userId].ContainsKey(highlightId))
            {
                return userHighlights[userId][highlightId];
            }
            return null;
        }

        public List<MockPhotoPost> GetPostsOfHighlight(Guid userId, Guid highlightId)
        {
            if (userHighlights.ContainsKey(userId) && userHighlights[userId].ContainsKey(highlightId))
            {
                List<MockPhotoPost> postsOfHighlight = new List<MockPhotoPost>();
                Highlight highlight = userHighlights[userId][highlightId];
                foreach (var post in GetConnectedUserPosts(userId))
                {
                    if (highlight.getPosts().Contains(post.getPostId()))
                    {
                        postsOfHighlight.Add(post);
                    }
                }
                return postsOfHighlight;
            }
            return new List<MockPhotoPost>();
        }
    }
}
