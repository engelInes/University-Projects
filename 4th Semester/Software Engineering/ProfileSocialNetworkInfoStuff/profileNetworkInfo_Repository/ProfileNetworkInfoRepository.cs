using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Repository
{
    public class ProfileNetworkInfoRepository<T>
    {

        private List<UserProfileSocialNetworkInfo> repositoryList;
        private string filePath;

        public ProfileNetworkInfoRepository(List<UserProfileSocialNetworkInfo> repositoryList)
        {
            this.repositoryList = repositoryList;
            SaveProfilesInXML();
        }

        public ProfileNetworkInfoRepository()
        {
            this.filePath = "E:\\facultate\\Sem4\\issFinal\\UBB-SE-2024-District3\\District 3 App\\ProfileSocialNetworkInfoStuff\\\\Profiles.xml";
            LoadProfilesInXML();

            SaveProfilesInXML();
        }


        public void LoadProfilesInXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<UserProfileSocialNetworkInfo>));
            XmlDocument xmlDoc = new XmlDocument();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = baseDirectory.Substring(0, baseDirectory.IndexOf("bin\\Debug"));

            string currfilePath = System.IO.Path.Combine(relativePath, "ProfileSocialNetworkInfoStuff");
            filePath = System.IO.Path.Combine(currfilePath, "Profiles.xml");
            //MessageBox.Show(filePath);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                repositoryList = (List<UserProfileSocialNetworkInfo>)serializer.Deserialize(fileStream);
            }
        }


        public void SaveProfilesInXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<UserProfileSocialNetworkInfo>));
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = baseDirectory.Substring(0, baseDirectory.IndexOf("bin\\Debug"));

            string currfilePath = System.IO.Path.Combine(relativePath, "ProfileSocialNetworkInfoStuff");
            filePath = System.IO.Path.Combine(currfilePath, "Profiles.xml");

            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, repositoryList);
            }
            //XmlDocument xmlDocument = new XmlDocument();

            //XmlNode profilesNode = xmlDocument.CreateElement("profiles");
            //xmlDocument.AppendChild(profilesNode);


            //foreach (UserProfileSocialNetworkInfo profile in repositoryList)
            //{
            //    XmlNode profileNode = xmlDocument.CreateElement("profile");
            //    profilesNode.AppendChild(profileNode);

            //    XmlNode userNode = xmlDocument.CreateElement("user");
            //    profileNode.AppendChild(userNode);

            //    XmlAttribute userIdAttribute = xmlDocument.CreateAttribute("id");
            //    userIdAttribute.Value = profile.user.id.ToString();
            //    userNode.Attributes.Append(userIdAttribute);

            //    XmlAttribute usernameAttribute = xmlDocument.CreateAttribute("username");
            //    usernameAttribute.Value = profile.user.username;
            //    userNode.Attributes.Append(usernameAttribute);

            //    XmlAttribute passwordAttribute = xmlDocument.CreateAttribute("password");
            //    passwordAttribute.Value = profile.user.password;
            //    userNode.Attributes.Append(passwordAttribute);

            //    XmlAttribute emailAttribute = xmlDocument.CreateAttribute("email");
            //    emailAttribute.Value = profile.user.email;
            //    userNode.Attributes.Append(emailAttribute);

            //    XmlAttribute confirmationPasswordAttribute = xmlDocument.CreateAttribute("confirmationPassword");
            //    confirmationPasswordAttribute.Value = profile.user.confirmationPassword;
            //    userNode.Attributes.Append(confirmationPasswordAttribute);



            //    XmlNode blockedAccountsNode = xmlDocument.CreateElement("blockedAccounts");
            //    profileNode.AppendChild(blockedAccountsNode);

            //    foreach(var blockedAccount in profile.blockedProfiles)
            //    {
            //        XmlNode blockedAccNode = xmlDocument.CreateElement("blockedAccount");
            //        blockedAccountsNode.AppendChild(blockedAccNode);

            //        XmlNode userBlockedAccountNode = xmlDocument.CreateElement("user");
            //        blockedAccNode.AppendChild(userBlockedAccountNode);

            //        XmlAttribute userIdBlockedAttribute = xmlDocument.CreateAttribute("id");
            //        userIdAttribute.Value = blockedAccount.user.id.ToString();
            //        userBlockedAccountNode.Attributes.Append(userIdBlockedAttribute);

            //        XmlAttribute usernameBlockedAttribute = xmlDocument.CreateAttribute("username");
            //        usernameAttribute.Value = blockedAccount.user.username;
            //        userBlockedAccountNode.Attributes.Append(usernameBlockedAttribute);

            //        XmlAttribute passwordBlockedAttribute = xmlDocument.CreateAttribute("password");
            //        passwordAttribute.Value = blockedAccount.user.password;
            //        userBlockedAccountNode.Attributes.Append(passwordBlockedAttribute);

            //        XmlAttribute emailBlockedAttribute = xmlDocument.CreateAttribute("email");
            //        emailAttribute.Value = blockedAccount.user.email;
            //        userBlockedAccountNode.Attributes.Append(emailBlockedAttribute);

            //        XmlAttribute confirmationPasswordBlockedAttribute = xmlDocument.CreateAttribute("confirmationPassword");
            //        confirmationPasswordAttribute.Value = blockedAccount.user.confirmationPassword;
            //        userBlockedAccountNode.Attributes.Append(confirmationPasswordBlockedAttribute);


            //        XmlAttribute blockDateAttribute = xmlDocument.CreateAttribute("blockDate");
            //        blockDateAttribute.Value = blockedAccount.blockDate.ToString();
            //        userBlockedAccountNode.Attributes.Append(confirmationPasswordBlockedAttribute);

            //    }

            //    foreach(var closeFriend in profile.closeFriendsProfiles)
            //    {
            //        XmlNode blockedAccNode = xmlDocument.CreateElement("blockedAccount");
            //        blockedAccountsNode.AppendChild(blockedAccNode);

            //        XmlNode userBlockedAccountNode = xmlDocument.CreateElement("user");
            //        blockedAccNode.AppendChild(userBlockedAccountNode);

            //        XmlAttribute userIdBlockedAttribute = xmlDocument.CreateAttribute("id");
            //        userIdAttribute.Value = profile.user.id.ToString();
            //        userBlockedAccountNode.Attributes.Append(userIdBlockedAttribute);

            //        XmlAttribute usernameBlockedAttribute = xmlDocument.CreateAttribute("username");
            //        usernameAttribute.Value = profile.user.username;
            //        userBlockedAccountNode.Attributes.Append(usernameBlockedAttribute);

            //        XmlAttribute passwordBlockedAttribute = xmlDocument.CreateAttribute("password");
            //        passwordAttribute.Value = profile.user.password;
            //        userBlockedAccountNode.Attributes.Append(passwordBlockedAttribute);

            //        XmlAttribute emailBlockedAttribute = xmlDocument.CreateAttribute("email");
            //        emailAttribute.Value = profile.user.email;
            //        userBlockedAccountNode.Attributes.Append(emailBlockedAttribute);

            //        XmlAttribute confirmationPasswordBlockedAttribute = xmlDocument.CreateAttribute("confirmationPassword");
            //        confirmationPasswordAttribute.Value = profile.user.confirmationPassword;
            //        userBlockedAccountNode.Attributes.Append(confirmationPasswordBlockedAttribute);
            //    }


            //    foreach (var member in group.groupMembers)
            //    {
            //        XmlNode userNode = xmlDocument.CreateElement("user");
            //        members.AppendChild(userNode);

            //        XmlAttribute userIdAttribute = xmlDocument.CreateAttribute("userId");
            //        userIdAttribute.Value = member.id.ToString();
            //        userNode.Attributes.Append(userIdAttribute);

            //        XmlAttribute usernameAttribute = xmlDocument.CreateAttribute("username");
            //        usernameAttribute.Value = member.username;
            //        userNode.Attributes.Append(usernameAttribute);

            //        XmlAttribute passwordAttribute = xmlDocument.CreateAttribute("password");
            //        passwordAttribute.Value = member.password;
            //        userNode.Attributes.Append(passwordAttribute);

            //        XmlAttribute emailAttribute = xmlDocument.CreateAttribute("email");
            //        emailAttribute.Value = member.email;
            //        userNode.Attributes.Append(emailAttribute);

            //        XmlAttribute confirmationPasswordAttribute = xmlDocument.CreateAttribute("confirmationPassword");
            //        confirmationPasswordAttribute.Value = member.confirmationPassword;
            //        userNode.Attributes.Append(confirmationPasswordAttribute);
            //    }

            //}

            //xmlDocument.Save(this.filePath);
        }


        public List<UserProfileSocialNetworkInfo> getProfileRepositoryList()
        {
            return this.repositoryList;
        }
        public void setProfileRepositoryList(List<UserProfileSocialNetworkInfo> newList)
        {
            this.repositoryList = newList;
        }


        public bool AddProfileSocialNetworkInfo(UserProfileSocialNetworkInfo profileToAdd)
        {
            foreach (var profile in this.getProfileRepositoryList())
            {
                if (profile.user.id == profileToAdd.user.id)
                    return false;
            }
            this.repositoryList.Add(profileToAdd);
            SaveProfilesInXML();
            return true;
        }

        public bool RemoveProfileSocialNetworkInfo(UserProfileSocialNetworkInfo profileToRemove)
        {
            foreach (var profile in this.getProfileRepositoryList())
            {
                if (profile.user.id == profileToRemove.user.id)
                {
                    this.repositoryList.Remove(profile);
                    SaveProfilesInXML();
                    return true;
                }
            }

            return false;
        }
    }
}
