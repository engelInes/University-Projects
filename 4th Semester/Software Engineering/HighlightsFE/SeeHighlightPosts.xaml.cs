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
    public partial class SeeHighlightPosts : UserControl
    {
        private List<PhotoInfo> photosInfo = new List<PhotoInfo>();
        private SnapshotsService snapshotsService;
        private CasualProfileService casualProfileService;

        public SeeHighlightPosts(Guid highlightId)
        {
           
            casualProfileService = new CasualProfileService();
            snapshotsService = casualProfileService.getSnapshotsService();

            InitializeComponent();

            
            Highlight h = snapshotsService.GetHighlight(highlightId);
            List<MockPhotoPost> postsToShow = snapshotsService.GetPostsOfHighlight(highlightId);

            foreach (MockPhotoPost post in postsToShow)
            {

                var photoInfo = new PhotoInfo(post.getPhoto(), post.getPostId());
                photoInfo.Description = post.getDescription();

                photosInfo.Add(photoInfo);
            }

            DataContext = photosInfo;
        }
    }
}
