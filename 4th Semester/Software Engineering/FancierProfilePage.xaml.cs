using District_3_App.Repository;
using District_3_App.Service;
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

namespace District_3_App
{
    public partial class FancierProfilePage : UserControl
    {
        private ProfileInfoSettings profileInfoSettings;
        private CasualProfileService casualProfileService=new CasualProfileService();
        private string motto;
        public FancierProfilePage()
        {
            this.profileInfoSettings=casualProfileService.getProfileInfoSettings();
            InitializeComponent();
            MottosComboBox.SelectionChanged += MottosComboBox_SelectionChanged;
            LinksPopUp.Opened += LinksPopUp_Opened;
        }
        private void AddMottoButton_Click(object sender, RoutedEventArgs e)
        {
            MottoPopUp.IsOpen = !MottoPopUp.IsOpen;
        }

        private void closePopUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (motto != null)
            {
                profileInfoSettings.AddDailyMotto(motto);
            }
            MottoPopUp.IsOpen = false;
        }
        private void MottosComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)MottosComboBox.SelectedItem;
            if (selectedItem != null)
            {
                string selectedMotto = selectedItem.Content.ToString();
                this.motto = selectedMotto;
            }
        }
        private void SaveMottoButton_Click(object sender, RoutedEventArgs e)
        {
            if (motto != null || motto!="")
            {
                profileInfoSettings.AddDailyMotto(motto);
            }
            MottoPopUp.IsOpen = false;
        }

        private void AddExtraLinksButton_Click(object sender, RoutedEventArgs e)
        {
            LinksPopUp.IsOpen = !LinksPopUp.IsOpen;
        }

        private void closeLinksPopUpButton_Click(object sender, RoutedEventArgs e)
        {
            LinksPopUp.IsOpen = false;
        }

        private void SaveLinksButton_Click(object sender, RoutedEventArgs e)
        {
            string link1 = link1Text.Text;
            string link2 = link2Text.Text;
            List<string> links = profileInfoSettings.GetLinks();
            bool? result1 = null, result2 = null;

            if (links != null)
            {
                if (links.Count >= 1)
                {
                    if (link1 != links[0])
                    {
                        profileInfoSettings.DeleteLink(links[0]);
                        result1 = profileInfoSettings.AddLink(link1);
                    }
                }
                else
                {
                    result1 = profileInfoSettings.AddLink(link1);
                }

                if (links.Count >= 2)
                {
                    if (link2 != links[1])
                    {
                        profileInfoSettings.DeleteLink(links[1]);
                        result2 = profileInfoSettings.AddLink(link2);
                    }
                }
                else
                {
                    result2 = profileInfoSettings.AddLink(link2);
                }
            }
            else
            {
                result1 = profileInfoSettings.AddLink(link1);
                result2 = profileInfoSettings.AddLink(link2);
            }

            if (result1 == false)
            {
                MessageBox.Show("Invalid link 1 :(");
            }

            if (result2 == false)
            {
                MessageBox.Show("Invalid link 2 :(");
            }

            LinksPopUp.IsOpen = false;
        }


        private void LinksPopUp_Opened(object sender, EventArgs e)
        {
            List<string> links = profileInfoSettings.GetLinks();
            if (links != null && links.Count > 0)
            {
                if (links.Count >= 1)
                {
                    link1Text.Text = links[0];
                }
                if (links.Count >= 2)
                {
                    link2Text.Text = links[1];
                }
            }
        }

        private void cancelLinksButton_Click(object sender, RoutedEventArgs e)
        {
            LinksPopUp.IsOpen = false;
        }

        private void textInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.motto = textInputBox.Text;
        }

        private void firstFrame_Click(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetFrameNumber(1))
                MessageBox.Show("New frame set :) ");
            else
                MessageBox.Show("Unable to set frame :(");
        }

        private void secondFrame_Click(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetFrameNumber(2))
                MessageBox.Show("New frame set :) ");
            else
                MessageBox.Show("Unable to set frame :(");
        }

        private void thirdFrame_Click(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetFrameNumber(3))
                MessageBox.Show("New frame set :) ");
            else
                MessageBox.Show("Unable to set frame :(");
        }

        private void forthFrame_Click(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetFrameNumber(4))
                MessageBox.Show("New frame set :) ");
            else
                MessageBox.Show("Unable to set frame :(");
        }

        private void fifthFrame_Click(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetFrameNumber(5))
                MessageBox.Show("New frame set :) ");
            else
                MessageBox.Show("Unable to set frame :(");
        }

        private void romanianFlagFrame_Click(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetFrameNumber(6))
                MessageBox.Show("New frame set :) ");
            else
                MessageBox.Show("Unable to set frame :(");
        }

        private void NoneFrame_Click(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.DeleteFrameNumber())
                MessageBox.Show("New frame set :) ");
            else
                MessageBox.Show("Unable to set frame :(");
        }

        private void Fun_Button_Click(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetHashtag("#Fun"))
                MessageBox.Show("New Hashtag set");
            else
                MessageBox.Show("Can't set this hashtag :(");
        }

        private void Sad_Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetHashtag("#Sad")) 
                MessageBox.Show("New Hashtag set");
            else
                MessageBox.Show("Can't set this hashtag :(");
        }

        private void Button_Click_Open_to_Work(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetHashtag("#Open To Work")) 
                MessageBox.Show("New Hashtag set");
            else
                MessageBox.Show("Can't set this hashtag :(");

        }

        private void Button_Click_Married(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetHashtag("#Just Married")) 
                MessageBox.Show("New Hashtag set");
            else
                MessageBox.Show("Can't set this hashtag :(");
        }

        private void Button_Click_Engaged(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetHashtag("#Engaged")) 
                MessageBox.Show("New Hashtag set");
            else
                MessageBox.Show("Can't set this hashtag :(");
        }

        private void Button_Click_Promotion(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.SetHashtag("#Big Promotion")) 
                MessageBox.Show("New Hashtag set");
            else
                MessageBox.Show("Can't set this hashtag :(");
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            if (profileInfoSettings.DeleteHashtag())
            {
                MessageBox.Show("Hashtag removed");
            }
            else
            {
                MessageBox.Show("can't remove hashtag :(");
            }
        }
    }
}
