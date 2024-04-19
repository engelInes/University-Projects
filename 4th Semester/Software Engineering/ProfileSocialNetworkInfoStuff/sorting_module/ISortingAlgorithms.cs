using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.sorting_module
{
    public interface ISortingAlgorithms<T>
    {
        void BubbleSortAscending(List<T> list, Func<T, T, int> Compare);
        void BubbleSortDescending(List<T> list, Func<T, T, int> Compare);

        void MergeSortAscending(List<T> domainList, Func<T, T, int> Compare);
        void MergeSortDescending(List<T> domainList, Func<T, T, int> Compare);

        void GnomeSortAscending(List<T> domainList, Func<T, T, int> Compare);
        void GnomeSortDescending(List<T> domainList, Func<T, T, int> Compare);

        void QuickSortAscending(List<T> domainList, Func<T, T, int> Compare);
        void QuickSortDescending(List<T> domainList, Func<T, T, int> Compare);

    }
}
