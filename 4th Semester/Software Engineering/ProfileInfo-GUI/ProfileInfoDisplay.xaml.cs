using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace District_3_App.ProfileInfo_GUI
{
    /// <summary>
    /// Interaction logic for ProfileInfoDisplay.xaml
    /// </summary>
    public partial class ProfileInfoDisplay : UserControl
    {
        public ProfileInfoDisplay()
        {
            InitializeComponent();
        }

        public void UpdateProfileInfo(
            string email, string phoneNumber, string dateOfBirth, string name,
            string username, string education, string educationLevel,
            string educationStartDate, string educationEndDate,
            string educationLocation, string hobbies, string music, string places,
            string work, string position, string workStartDate,
            string workEndDate, string workLocation, string description)
        {
            // Update TextBlocks with edited profile info
            TextBlockEmail.Text = email;
            TextBlockPhoneNumber.Text = phoneNumber;
            TextBlockDateOfBirth.Text = dateOfBirth;
            TextBlockName.Text = name;
            TextBlockUsername.Text = username;
            TextBlockEducation.Text = education;
            TextBlockEducationLevel.Text = educationLevel;
            TextBlockEducationStartDate.Text = educationStartDate;
            TextBlockEducationEndDate.Text = educationEndDate;
            TextBlockEducationLocation.Text = educationLocation;
            TextBlockHobbies.Text = hobbies;
            TextBlockMusic.Text = music;
            TextBlockPlaces.Text = places;
            TextBlockWork.Text = work;
            TextBlockWorkPosition.Text = position;
            TextBlockWorkStartDate.Text = workStartDate;
            TextBlockWorkEndDate.Text = workEndDate;
            TextBlockWorkLocation.Text = workLocation;
            TextBlockDescription.Text = description;
        }

        private void EditInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var newContent = new EditProfileInfo(this);
            ProfileInfoStackPanel.Children.Clear();
            ProfileInfoStackPanel.Children.Add(newContent);
        }

        private void Save_Button(object sender, RoutedEventArgs e)
        {
            // do something
        }

    }
}