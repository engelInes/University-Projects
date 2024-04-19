using District_3_App.Enitities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace District_3_App.Repository
{
    public class FancierProfile
    {
        public Guid ProfileId { get; set; }
        public List<string> Links { get; set; }
        public string DailyMotto { get; set; }
        public DateTime? RemoveMottoDate { get; set; }
        public int FrameNumber { get; set; }
        public string Hashtag { get; set; }
    }

    public class FancierProfileRepo
    {
        private Dictionary<Guid, FancierProfile> profileRepo = new Dictionary<Guid, FancierProfile>();
        private string filePath;

        public FancierProfileRepo()
        {
            filePath = GenerateDefaultFilePath();
            Console.WriteLine(filePath);
            if (!File.Exists(filePath))
            {
                CreateXml(filePath);
            }
            Load(filePath);
        }

        private string GenerateDefaultFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FancierProfile.xml");
        }

        private void CreateXml(string filePath)
        {
            XDocument xDocument = new XDocument(new XElement("FancierProfiles"));
            xDocument.Save(filePath);
        }

        private void Load(string filePath)
        {
            Console.WriteLine("Reading profile info fancy settings from file: " + filePath);

            XDocument xDocument = XDocument.Load(filePath);
            XElement root = xDocument.Element("FancierProfiles");
            if (root != null && root.HasElements)
            {
                foreach (var userElem in root.Elements("FancierProfile"))
                {
                    Guid userId;
                    if (!Guid.TryParse((string)userElem.Attribute("ProfileId"), out userId))
                    {
                        userId = Guid.NewGuid();
                    }
                    FancierProfile profile = new FancierProfile();
                    try
                    {
                        profile.ProfileId = userId;
                        profile.DailyMotto = (string)userElem.Attribute("DailyMotto");
                        profile.RemoveMottoDate = (DateTime)userElem.Attribute("RemoveMottoDate");
                        if (profile.RemoveMottoDate < DateTime.Now)
                        {
                            profile.DailyMotto = null;
                            profile.RemoveMottoDate = null;
                        }

                        var linksElem = userElem.Element("Links");
                        if (linksElem != null)
                        {
                            profile.Links = linksElem.Elements("Link")
                                .Select(e => e.Value)
                                .Where(e => !string.IsNullOrEmpty(e))
                                .ToList();
                        }

                        profile.FrameNumber = (int)userElem.Attribute("FrameNumber");
                        profile.Hashtag = (string)userElem.Attribute("Hashtag");

                        profileRepo.Add(userId, profile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing profile: {ex.Message}");
                    }
                }
            }
        }


        public void SaveToXml()
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
                    xDocument = new XDocument(new XElement("FancierProfiles"));
                }

                XElement root = xDocument.Element("FancierProfiles");
                root?.RemoveAll();

                foreach (var profileId in profileRepo.Keys)
                {
                    FancierProfile profile = profileRepo[profileId];

                    XElement profileElement = new XElement("FancierProfile",
                        new XAttribute("ProfileId", profile.ProfileId),
                        new XAttribute("DailyMotto", profile.DailyMotto),
                        new XAttribute("RemoveMottoDate", profile.RemoveMottoDate),
                        new XAttribute("FrameNumber", profile.FrameNumber),
                        new XAttribute("Hashtag", profile.Hashtag));

                    if (profile.Links != null && profile.Links.Any())
                    {
                        XElement linksElement = new XElement("Links");
                        foreach (var link in profile.Links)
                        {
                            linksElement.Add(new XElement("Link", link));
                        }
                        profileElement.Add(linksElement);
                    }

                    root.Add(profileElement);
                }

                xDocument.Save(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving profiles to XML: " + ex.Message);
            }
        }

        public bool AddLink(Guid userId, string newLink)
        {
            try
            {
                if (profileRepo.ContainsKey(userId))
                {
                    if (profileRepo[userId].Links == null)
                    {
                        profileRepo[userId].Links = new List<string>();
                    }
                    profileRepo[userId].Links.Add(newLink);
                    SaveToXml();
                    return true;
                }
                else
                {
                    FancierProfile profile = new FancierProfile
                    {
                        ProfileId = userId,
                        Links = new List<string> { newLink }
                    };
                    profileRepo.Add(userId, profile);
                    SaveToXml();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding link: " + ex.Message);
                return false;
            }
        }

        public bool DeleteLink(Guid userId, string linkToDelete)
        {
            try
            {
                if (profileRepo.ContainsKey(userId))
                {
                    if (profileRepo[userId].Links != null)
                    {
                        profileRepo[userId].Links.Remove(linkToDelete);
                        SaveToXml();
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("User ID not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting link: " + ex.Message);
                return false;
            }
        }

        public bool SetFrameNumber(Guid userId, int newFrameNumber)
        {
            try
            {
                if (profileRepo.ContainsKey(userId))
                {
                    profileRepo[userId].FrameNumber = newFrameNumber;
                    SaveToXml();
                    return true;
                }
                else
                {
                    FancierProfile profile = new FancierProfile
                    {
                        ProfileId = userId,
                        FrameNumber = newFrameNumber,
                    };
                    profileRepo.Add(userId, profile);
                    SaveToXml();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting frame number: " + ex.Message);
                return false;
            }
        }

        public bool DeleteFrameNumber(Guid userId)
        {
            try
            {
                if (profileRepo.ContainsKey(userId))
                {
                    profileRepo[userId].FrameNumber = 0;
                    SaveToXml();
                    return true;
                }
                else
                {
                    Console.WriteLine("User ID not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting frame number: " + ex.Message);
                return false;
            }
        }

        public bool SetHashtag(Guid userId, string newHashtag)
        {
            try
            {
                if (profileRepo.ContainsKey(userId))
                {
                    profileRepo[userId].Hashtag = newHashtag;
                    SaveToXml();
                    return true;
                }
                else
                {
                    FancierProfile profile = new FancierProfile
                    {
                        ProfileId = userId,
                        Hashtag=newHashtag,
                    };
                    profileRepo.Add(userId, profile);
                    SaveToXml();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting hashtag: " + ex.Message);
                return false;
            }
        }

        public bool DeleteHashtag(Guid userId)
        {
            try
            {
                if (profileRepo.ContainsKey(userId))
                {
                    profileRepo[userId].Hashtag = "";
                    SaveToXml();
                    return true;
                }
                else
                {
                    Console.WriteLine("User ID not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting hashtag: " + ex.Message);
                return false;
            }
        }

        public bool AddDailyMotto(Guid userId, string newMotto, DateTime dateToRemove)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].DailyMotto = newMotto;
                profileRepo[userId].RemoveMottoDate = dateToRemove;
                SaveToXml();
                return true;
            }
            else
            {
                FancierProfile profile = new FancierProfile();
                profile.DailyMotto = newMotto;
                profile.RemoveMottoDate = dateToRemove;
                profileRepo.Add(userId, profile);
                return true;
            }
            return false;
        }

        public bool DeleteDailyMotto(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].DailyMotto = null;
                SaveToXml();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetDailyMotto(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].DailyMotto;
            }
            else
            {

                return null;
            }
        }
    

        public List<string> GetLinks(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].Links;
            }
            else
            {
                return null;
            }
        }

        public int GetFrameNumber(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].FrameNumber;
            }
            else
            {
                return -1;
            }
        }

        
        public string GetHashtag(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].Hashtag;
            }
            else
            {
                return null;
            }

        }
    }
}

