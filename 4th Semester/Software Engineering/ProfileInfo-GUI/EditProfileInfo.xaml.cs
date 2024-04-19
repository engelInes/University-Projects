using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
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
using System.Xml.Linq;

namespace District_3_App.ProfileInfo_GUI
{
    /// <summary>
    /// Interaction logic for EditProfileInfo.xaml
    /// </summary>
    public partial class EditProfileInfo : UserControl
    {
        private ProfileInfoDisplay _profileInfoDisplay;

        /*public EditProfileInfo()
        {
            InitializeComponent();
        }*/

        public EditProfileInfo(ProfileInfoDisplay profileInfoDisplay)
        {
            InitializeComponent();
            _profileInfoDisplay = profileInfoDisplay;

            EmailTextBox.Text = profileInfoDisplay.TextBlockEmail.Text;
            PhoneNumberTextBox.Text = profileInfoDisplay.TextBlockPhoneNumber.Text;
            DatePickerBirthDate.SelectedDate = DateTime.ParseExact(profileInfoDisplay.TextBlockDateOfBirth.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            UsernameTextBox.Text = profileInfoDisplay.TextBlockUsername.Text;
            NameTextBox.Text = profileInfoDisplay.TextBlockName.Text;
            WorkTextBox.Text = profileInfoDisplay.TextBlockWork.Text;
            PositionTextBox.Text = profileInfoDisplay.TextBlockWorkPosition.Text;
            DatePickerWorkStartDate.SelectedDate = DateTime.ParseExact(profileInfoDisplay.TextBlockWorkStartDate.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DatePickerWorkEndDate.SelectedDate = DateTime.ParseExact(profileInfoDisplay.TextBlockWorkEndDate.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            WorkLocationComboBox.SelectedItem = WorkLocationComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == profileInfoDisplay.TextBlockWorkLocation.Text);
            DescriptionTextBox.Text = profileInfoDisplay.TextBlockDescription.Text;
            EducationComboBox.SelectedItem = EducationComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == profileInfoDisplay.TextBlockEducation.Text);
            EducationLevelTextBox.Text = profileInfoDisplay.TextBlockEducationLevel.Text;
            DatePickerEducationStartDate.SelectedDate = DateTime.ParseExact(profileInfoDisplay.TextBlockEducationStartDate.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DatePickerEducationEndDate.SelectedDate = DateTime.ParseExact(profileInfoDisplay.TextBlockEducationEndDate.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            EducationLocationComboBox.SelectedItem = EducationLocationComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == profileInfoDisplay.TextBlockEducationLocation.Text);
            HobbiesTextBox.Text = profileInfoDisplay.TextBlockHobbies.Text;
            MusicTextBox.Text = profileInfoDisplay.TextBlockMusic.Text;
            PlacesComboBox.SelectedItem = PlacesComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == profileInfoDisplay.TextBlockPlaces.Text);
        }

        private void SaveChanges_Button(object sender, RoutedEventArgs e)
        {
            string Email = EmailTextBox.Text;
            string PhoneNumber = PhoneNumberTextBox.Text;
            string DateOfBirth = DatePickerBirthDate.SelectedDate?.ToString("dd.MM.yyyy");
            string Username = UsernameTextBox.Text;
            string Name = NameTextBox.Text;
            string Work = WorkTextBox.Text;
            string Position = PositionTextBox.Text;
            string WorkStartDate = DatePickerWorkStartDate.SelectedDate?.ToString("dd.MM.yyyy");
            string WorkEndDate = DatePickerWorkEndDate.SelectedDate?.ToString("dd.MM.yyyy");
            string WorkLocation = (WorkLocationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string Description = DescriptionTextBox.Text;
            string Education = (EducationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string EducationLevel = EducationLevelTextBox.Text;
            string EducationStartDate = DatePickerEducationStartDate.SelectedDate?.ToString("dd.MM.yyyy");
            string EducationEndDate = DatePickerEducationEndDate.SelectedDate?.ToString("dd.MM.yyyy");
            string EducationLocation = (EducationLocationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string Hobbies = HobbiesTextBox.Text;
            string Music = MusicTextBox.Text;
            string Places = (PlacesComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();


            // Redirect to ProfileInfoDisplay page

            // Clear the EditProfileInfoStackPanel
            EditProfileInfoStackPanel.Children.Clear();

            // Add a new ProfileInfoDisplay instance to display the updated profile information
            var newProfileInfoDisplay = new ProfileInfoDisplay();
            newProfileInfoDisplay.UpdateProfileInfo(
                Email, PhoneNumber, DateOfBirth, Name,
                Username, Education, EducationLevel,
                EducationStartDate, EducationEndDate,
                EducationLocation, Hobbies, Music, Places,
                Work, Position, WorkStartDate,
                WorkEndDate, WorkLocation, Description
            );

            EditProfileInfoStackPanel.Children.Add(newProfileInfoDisplay);

        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            var newContent = new ProfileInfoDisplay();

            EditProfileInfoStackPanel.Children.Clear();
            EditProfileInfoStackPanel.Children.Add(newContent);
        }
    }
}