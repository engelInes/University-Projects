using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Service;
using District_3_App.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ExtraInfo
{
    internal class ExtraInfoService
    {
        private StatisticsService statisticsService;
        private ProfileNetworkInfoService profileNetworkInfoService;

        public ExtraInfoService(StatisticsService statisticsService, ProfileNetworkInfoService profileNetworkInfoService)
        {
            this.statisticsService = statisticsService;
            this.profileNetworkInfoService = profileNetworkInfoService;
        }
        public StatisticsService GetStatisticsService()
        {
            return this.statisticsService;
        }
        public ProfileNetworkInfoService GetProfileNetworkInfoService()
        {
            return this.profileNetworkInfoService;
        }
    }
}
