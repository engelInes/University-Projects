using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Repository
{
    public class GroupsRepository
    {
        public List<Group> groupsRepository { get; set; }
        private string filePath;

        public GroupsRepository()
        {
            this.filePath = "E:\\facultate\\Sem4\\issFinal\\UBB-SE-2024-District3\\District 3 App\\ProfileSocialNetworkInfoStuff\\Groups.xml";
            this.groupsRepository = LoadGroupsFromXML();
            //this.groupsRepository = new List<Group>();
        }
        public GroupsRepository(List<Group> groupsRepository)
        {
            this.groupsRepository = groupsRepository;
            this.filePath = "E:\\facultate\\Sem4\\issFinal\\UBB-SE-2024-District3\\District 3 App\\ProfileSocialNetworkInfoStuff\\Groups.xml";

            SaveGroupsInXML();
        }


        public List<Group> LoadGroupsFromXML()
        {
            List<Group> loadedGroups = new List<Group>();

            XmlDocument xmlDoc = new XmlDocument();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = baseDirectory.Substring(0, baseDirectory.IndexOf("bin\\Debug"));

            string currfilePath = System.IO.Path.Combine(relativePath, "ProfileSocialNetworkInfoStuff");
            filePath = System.IO.Path.Combine(currfilePath, "Groups.xml");
            
            xmlDoc.Load(filePath);

            foreach (XmlNode groupNode in xmlDoc.SelectNodes("//group"))
            {
                Group group = new Group();
                group.Id = Guid.Parse(groupNode.Attributes["groupId"].Value);
                group.groupName = groupNode.Attributes["groupName"].Value;
                group.groupMembers = new List<User>();

                foreach (XmlNode userNode in groupNode.SelectNodes("members/user"))
                {
                    User user = new User();
                    user.id = Guid.Parse(userNode.Attributes["userId"].Value);
                    user.username = userNode.Attributes["username"].Value;
                    user.password = userNode.Attributes["password"].Value;
                    user.email = userNode.Attributes["email"].Value;
                    user.confirmationPassword = userNode.Attributes["confirmationPassword"].Value;

                    group.groupMembers.Add(user);
                }

                loadedGroups.Add(group);
            }

            return loadedGroups;
        }


        public void SaveGroupsInXML()
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlNode groupsNode = xmlDocument.CreateElement("groups");
            xmlDocument.AppendChild(groupsNode);


            foreach(Group group in groupsRepository)
            {
                XmlNode groupNode = xmlDocument.CreateElement("group");
                groupsNode.AppendChild(groupNode);


                XmlAttribute groupIdAttribute = xmlDocument.CreateAttribute("groupId");
                groupIdAttribute.Value = group.Id.ToString();
                groupNode.Attributes.Append(groupIdAttribute);

                XmlAttribute groupNameAttribute = xmlDocument.CreateAttribute("groupName");
                groupNameAttribute.Value = group.groupName;
                groupNode.Attributes.Append(groupNameAttribute);

                XmlNode members = xmlDocument.CreateElement("members");
                groupNode.AppendChild(members);


                foreach(var member in group.groupMembers)
                {
                    XmlNode userNode = xmlDocument.CreateElement("user");
                    members.AppendChild(userNode);

                    XmlAttribute userIdAttribute = xmlDocument.CreateAttribute("userId");
                    userIdAttribute.Value = member.id.ToString();
                    userNode.Attributes.Append(userIdAttribute);

                    XmlAttribute usernameAttribute = xmlDocument.CreateAttribute("username");
                    usernameAttribute.Value = member.username;
                    userNode.Attributes.Append(usernameAttribute);

                    XmlAttribute passwordAttribute = xmlDocument.CreateAttribute("password");
                    passwordAttribute.Value = member.password;
                    userNode.Attributes.Append(passwordAttribute);

                    XmlAttribute emailAttribute = xmlDocument.CreateAttribute("email");
                    emailAttribute.Value = member.email;
                    userNode.Attributes.Append(emailAttribute);

                    XmlAttribute confirmationPasswordAttribute = xmlDocument.CreateAttribute("confirmationPassword");
                    confirmationPasswordAttribute.Value = member.confirmationPassword;
                    userNode.Attributes.Append(confirmationPasswordAttribute);
                }

            }

            xmlDocument.Save(this.filePath);
        }


        public List<Group> GetAllGroups()
        {
            return this.groupsRepository;
        }




        public bool AddGroup(Group groupToAdd)
        {
            foreach (var group in groupsRepository)
            {
                if (group.Id == groupToAdd.Id)
                {
                    return false;
                }
            }

            this.groupsRepository.Add(groupToAdd);
            SaveGroupsInXML();
            return true;
        }


        public bool RemoveGroup(Group groupToRemove)
        {
            foreach (var group in groupsRepository)
            {
                if (group.Id == groupToRemove.Id)
                {
                    groupsRepository.Remove(group);
                    SaveGroupsInXML();
                    return true;
                }
            }
            return false;
        }

        public Group GetGroupByGroupName(string groupName)
        {
            foreach (var group in groupsRepository)
            {
                if (groupName == group.groupName)
                {
                    return group;

                }
            }
            return null;
        }

        public bool AddMemberToGroup(string groupName, User memberToAdd)
        {
            foreach (var group in groupsRepository)
            {
                if (group.groupName == groupName)
                {
                    foreach (var currentMember in group.groupMembers)
                        if (currentMember.username == memberToAdd.username)
                            return false;

                    group.groupMembers.Add(memberToAdd);
                    SaveGroupsInXML();
                    return true;
                }
            }
            return false;
        }


        public bool RemoveMemberFromGroup(string groupName, User memberToRemove)
        {
            foreach (var group in groupsRepository)
            {
                if (group.groupName == groupName)
                {
                    foreach (var currentMember in group.groupMembers)
                        if (currentMember.username == memberToRemove.username)
                        {
                            group.groupMembers.Remove(memberToRemove);
                            SaveGroupsInXML();
                            return true;
                        }

                    return false;
                }
            }
            return false;
        }

    }
}
