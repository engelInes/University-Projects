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
using System.Xml.Linq;

namespace District_3_App.Statistics
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        StatisticsService srv = new StatisticsService("Stats.xml");
        public Statistics()
        {
            InitializeComponent();

            this.Bestie1.Text = srv.GetFriendNames()[0];
            this.Bestie2.Text = srv.GetFriendNames()[1];
            this.Bestie3.Text = srv.GetFriendNames()[2];
            this.Bestie4.Text = srv.GetFriendNames()[3];
            this.Bestie5.Text = srv.GetFriendNames()[4];

            this.Streak1.Text = srv.GetUserStreaks()[0].ToString();
            this.Streak2.Text = srv.GetUserStreaks()[1].ToString();
            this.Streak3.Text = srv.GetUserStreaks()[2].ToString();
            this.Streak4.Text = srv.GetUserStreaks()[3].ToString();
            this.Streak5.Text = srv.GetUserStreaks()[4].ToString();


        }


    }
}
