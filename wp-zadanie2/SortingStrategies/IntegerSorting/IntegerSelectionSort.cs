using System.Collections.Generic;

namespace wp_zadanie2.SortingStrategies.IntegerSorting
{
    public class IntegerSelectionSort : ISorter<int>
    {
        public List<int> SortList(List<int> list)
        {
            for (var i = 0; i < list.Count; i++) {
                var min = i;
                for (var j = i + 1; j < list.Count; j++) {
                    if (list[min] > list[j]) {
                        min = j;
                    }
                }

                if (min == i) continue;
                var lowerValue = list[min];
                list[min] = list[i];
                list[i] = lowerValue;
            }

            return list;
        }
    }
}