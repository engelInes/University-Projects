using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Service;
using District_3_App.Statistics;
using Statistics;
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

namespace District_3_App.ExtraInfo
{
    /// <summary>
    /// Interaction logic for VerifiedAccount.xaml
    /// </summary>
    public partial class VerifiedAccount : UserControl
    {
        private ProfileNetworkInfoService profileNetworkInfoService;
        public VerifiedAccount(ProfileNetworkInfoService profileNetworkInfoService)
        {
            this.profileNetworkInfoService = profileNetworkInfoService;
            InitializeComponent();
        }

        private void ChooseBusinessButton_Click(object sender, RoutedEventArgs e)
        {
            var paymentForm = new PaymentForm(profileNetworkInfoService);
            //VerifiedAccountGrid.Children.Clear();
            /*Grid.SetColumn(paymentForm, 0);
            Grid.SetRow(paymentForm, 1);
            Grid.SetRowSpan(paymentForm, 4);*/
            
            VerifiedAccountGrid.Children.Add(paymentForm);
        }

        private void ChooseFreeButton_Click(object sender, RoutedEventArgs e)
        {
            var newContent = new VerifiedAccount(profileNetworkInfoService);
            VerifiedAccountGrid.Children.Clear(); 
            Grid.SetColumn(newContent, 0);
            Grid.SetRow(newContent, 1);
            Grid.SetRowSpan(newContent, 4);
            
            VerifiedAccountGrid.Children.Add(newContent);
        }

    }
}
