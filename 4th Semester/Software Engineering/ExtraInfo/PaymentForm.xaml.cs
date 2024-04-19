using District_3_App.LogIn;
using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Service;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace District_3_App.ExtraInfo
{
    /// <summary>
    /// Interaction logic for PaymentForm.xaml
    /// </summary>
    public partial class PaymentForm : UserControl
    {
        public Account Account { get; set; }

        private ProfileNetworkInfoService profileNetworkInfoService;

        private UserManager userManager;
        private XDocument xmlDoc;
        private string xmlFilePath = "E:\\facultate\\Sem4\\issFinal\\UBB-SE-2024-District3\\District 3 App\\Users.xml";
        public PaymentForm(ProfileNetworkInfoService profileNetworkInfoService)
        {
            this.profileNetworkInfoService = profileNetworkInfoService;
            InitializeComponent();
            try
            {
                xmlDoc = XDocument.Load(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load XML file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var users = xmlDoc.Descendants("User");
            /*foreach (var currUser in users)
            {
                User newUser = new User
                {
                    id = (Guid)currUser.Attribute("id"),
                    username = (string)currUser.Attribute("username"),
                    email = (string)currUser.Attribute("email"),
                    password = (string)currUser.Attribute("password"),
                    confirmationPassword = (string)currUser.Attribute("confirmationPassword")
                };
                //usersRepositoryList.Add(newUser);
            }*/
            Guid id = Guid.NewGuid();
            string username = "test_0";
            string email = "test0@yahoo.com";
            string password = "Test-0";
            string confirmationPassword = "Test-0";
            var user = FindUserByUsernameAndPassword(username, password);

            if (user != null)
            {
                Account = new Account(new User(id, username, password, email, confirmationPassword, 0,0), "", "", "", "");
                DataContext = this;
            }
            else
            {
                MessageBox.Show("User not found in XML.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            /*Account = new Account(new UserExtraInfo("john_doe", "securepassword"), "", "", "", "");
            DataContext = this;*/
        }
        private XElement FindUserByUsernameAndPassword(string username, string password)
        {

            var user = xmlDoc.Descendants("User")
                             .FirstOrDefault(u => (string)u.Element("Username") == username &&
                                                  (string)u.Element("Password") == password);

            return user;
        }
        /*public PaymentForm(ProfileNetworkInfoService profileNetworkInfoService)
        {
            this.profileNetworkInfoService = profileNetworkInfoService;
            InitializeComponent();
            try
            {
                string xmlFilePath = "Users.xml";
                xmlDoc = XDocument.Load(xmlFilePath);
                userManager = new UserManager(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load XML file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var users = xmlDoc.Descendants("User");
            Guid id = Guid.NewGuid();
            string username = "test_1";
            string email = "testines@gmail.com";
            string password = "Test-1";
            string confirmationPassword = "Test-1";
            var user = FindUserByUsernameAndPassword(username, password);

            if (user != null)
            {
                Account = new Account(new User(id, username, password, email, confirmationPassword), "", "", "", "");
                DataContext = this;
            }
            string username = "test_0";
            string password = "Test-0";

            // Authenticate user
            if (userManager.AuthenticateUser(username, password))
            {
                bool isLoggedIn = userManager.IsUserLoggedIn();

                if (isLoggedIn)
                {
                    User currentUser = userManager.GetUsers().FirstOrDefault(u => u.username == username);

                    if (currentUser != null)
                    {
                        Account = new Account(currentUser, "", "", "", "");
                        DataContext = this;
                    }
                    else
                    {
                        MessageBox.Show("User details not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No user is currently logged in.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("User not found or authentication failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        else
        {
            MessageBox.Show("User not found in XML.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
    private XElement FindUserByUsernameAndPassword(string username, string password)
    {
        foreach (var userElement in xmlDoc.Root.Elements("User"))
        {
            User currUser = new User
            {
                id = Guid.Parse(userElement.Attribute("id").Value),
                username = userElement.Attribute("Username").Value,
                email = userElement.Attribute("Email").Value,
                password = userElement.Attribute("Password").Value,
                confirmationPassword = userElement.Attribute("ConfirmationPassword").Value,
            };
        }
        var user = xmlDoc.Descendants("User")
                         .FirstOrDefault(u => (string)u.Element("Username") == username &&
                                              (string)u.Element("Password") == password);

        return user;
        foreach (var userElement in xmlDoc.Root.Elements("User"))
        {
            string xmlUsername = userElement.Attribute("Username")?.Value;
            string xmlPassword = userElement.Attribute("Password")?.Value;

            if (xmlUsername == username && xmlPassword == password)
            {
                return userElement;
            }
        }
        return null;
    }*/
        private void Button_Click(object sender, RoutedEventArgs e)
    {
        bool isValid = true;
        if (!ValidateCardNumber(CardNumberTextBox.Text))
        {
            MessageBox.Show("Card Number must be a string of 16 digits (numeric input only).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            isValid = false;
        }
        if (!ValidateExpirationDate(ExpirationDateTextBox.Text))
        {
            MessageBox.Show("Expiration Date must be in MM/YY format (numeric input only).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            isValid = false;
        }

        if (!ValidateCVV(CVVTextBox.Text))
        {
            MessageBox.Show("CVV must be a three-digit code (numeric input only).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            isValid = false;
        }

        if (!ValidateHolderName(HolderNameTextBox.Text))
        {
            MessageBox.Show("Holder Name must contain alphabetic characters only.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            isValid = false;
        }

        if (isValid && CardNumberTextBox.Text != "")
        {
            Account.CardNumber = CardNumberTextBox.Text;
            Account.ExpirationDate = ExpirationDateTextBox.Text;
            Account.CVV = CVVTextBox.Text;
            Account.HolderName = HolderNameTextBox.Text;

            var newContent = new PaymentConfirmed();

            CompleteGrid.Children.Clear();
            Grid.SetColumn(newContent, 1);
            CompleteGrid.Children.Add(newContent);
        }
    }
    private bool ValidateCardNumber(string cardNumber)
    {
        return !string.IsNullOrWhiteSpace(cardNumber) && (cardNumber.Length == 16 && IsNumeric(cardNumber));
    }

    private bool ValidateExpirationDate(string expirationDate)
    {
        if (string.IsNullOrWhiteSpace(expirationDate) || expirationDate.Length != 5)
            return false;

        string[] parts = expirationDate.Split('/');
        if (parts.Length != 2)
            return false;

        if (!int.TryParse(parts[0], out int month) || !int.TryParse(parts[1], out int year))
            return false;

        int currentYear = DateTime.Now.Year % 100;
        return month >= 1 && month <= 12 && year >= currentYear && year <= currentYear + 10;
    }


    private bool ValidateCVV(string cvv)
    {
        return !string.IsNullOrWhiteSpace(cvv) && (cvv.Length == 3 && IsNumeric(cvv));
    }

    private bool ValidateHolderName(string holderName)
    {
        return !string.IsNullOrWhiteSpace(holderName) && IsAlphabetic(holderName);
    }


    private bool IsNumeric(string value)
    {
        return long.TryParse(value, out _);
    }

    private bool IsAlphabetic(string value)
    {
        return value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }
}
}
