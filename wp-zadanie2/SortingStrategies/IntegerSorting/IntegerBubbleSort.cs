using System.Collections.Generic;

namespace wp_zadanie2.SortingStrategies.IntegerSorting
{
    public class IntegerBubbleSort : ISorter<int>
    {
        public List<int> SortList(List<int> list)
        {
            int i, j, n = list.Count;
            for (i = 0; i < n - 1; i++) {
                for (j = 0; j < n - i - 1; j++) {
                    if (list[j] <= list[j + 1]) continue;
                    // swap temp and list[i]
                    var temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }

            return list;
        }
    }
}