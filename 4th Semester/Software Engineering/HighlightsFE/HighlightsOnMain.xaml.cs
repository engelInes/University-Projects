using District_3_App.Enitities;
using District_3_App.Enitities.Mocks;
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

namespace District_3_App.HighlightsFE
{
    public partial class HighlightsOnMain : UserControl
    {
        public List<HighlightInfo> Highlights { get; set; }
        private Guid? currentlyOpenHighlightId = null;
        private SnapshotsService snapshotsService;
        private CasualProfileService casualProfileService;

        public HighlightsOnMain()
        { 
            casualProfileService = new CasualProfileService();
            snapshotsService = casualProfileService.getSnapshotsService();
            InitializeComponent();
            LoadHighlights();
        }

        private void LoadHighlights()
        {
            List<Highlight> highlights = snapshotsService.getHighlightsOfUser();

            if (highlights == null || highlights.Count == 0)
            {
                Console.WriteLine("No highlights found.");
            }

            Highlights = new List<HighlightInfo>();
            foreach (Highlight highlight in highlights)
            {
                //HighlightsRepo highlightsRepo = new HighlightsRepo();
                List<MockPhotoPost> userPosts = casualProfileService.GetConnectedUserPosts();
                MockPhotoPost coverPost = userPosts.FirstOrDefault(post => post.getPostId().ToString() == highlight.getCover());

                if (coverPost != null)
                {
                    Highlights.Add(new HighlightInfo(highlight.getName(), coverPost.getPhoto(), highlight.getHighlightId()));
                }
                else
                { 
                    Highlights.Add(new HighlightInfo(highlight.getName(), "/images/black.png", highlight.getHighlightId()));
                }
            }

            DataContext = Highlights;
        }


        private void SelectHighlight_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = e.OriginalSource as Button;
            HighlightInfo highlightInfo = clickedButton.DataContext as HighlightInfo;
            Guid highlightId = highlightInfo.HighlightId;

            if (highlightId == currentlyOpenHighlightId)
            {
                navigationFrame.Content = null;
                currentlyOpenHighlightId = null;
            }
            else
            {
                navigationFrame.Navigate(new SeeHighlightPosts(highlightId));
                currentlyOpenHighlightId = highlightId;
            }
        }
    }
}
