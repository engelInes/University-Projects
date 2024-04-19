using District_3_App.Enitities.Mocks;
using District_3_App.Enitities;
using District_3_App.Repository;
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
using District_3_App.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace District_3_App.HighlightsFE
{
    public partial class CreateNewHighlight : Window
    {
        private List<Guid> guids = new();
        private string newHighlightName;
        private string newHighlightCover;
        private SnapshotsService snapshotsService;
        public CreateNewHighlight(List<Guid> selectedPostsGuids)
        {
            CasualProfileService casualProfileService = new CasualProfileService();
            snapshotsService = casualProfileService.getSnapshotsService();

            InitializeComponent();
            guids = selectedPostsGuids;
            int nrPosts=guids.Count;
            DataContext = nrPosts;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textInputBox.Text != "Enter Highlight Name")
               newHighlightName = textInputBox.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (guids.Count <= 0)
            {
                MessageBox.Show("You didn't add any posts. The cover will be the default black");
            }
            else
            {
                ChooseCoverPopUp.IsOpen = !ChooseCoverPopUp.IsOpen;
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                snapshotsService.addHighlight(newHighlightName, newHighlightCover, guids);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                ChooseCoverPopUp.IsOpen = false;
            }
        }


        private void coverInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string highlightCover = coverInput.Text;
            try
            {
                int numberOfPost = int.Parse(highlightCover);
                if (numberOfPost < 0 || numberOfPost> guids.Count) {
                    MessageBox.Show("Please enter a number between 1 and " + guids.Count.ToString());
                }
                newHighlightCover = guids[numberOfPost].ToString();
            }
            catch (Exception) { 
                MessageBox.Show("Something went wrong :(" + guids.Count.ToString());
            }
        }
    }
}
