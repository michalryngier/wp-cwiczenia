using System.Collections.Generic;

namespace wp_zadanie2.SortingStrategies.IntegerSorting
{
    public class IntegerInsertionSorting : ISorter<int>
    {
        public List<int> SortList(List<int> list)
        {
            for (var i = 0; i < list.Count; i++) {
                var item = list[i];
                var currentIndex = i;

                while (currentIndex > 0 && list[currentIndex - 1] > item) {
                    list[currentIndex] = list[currentIndex - 1];
                    currentIndex--;
                }

                list[currentIndex] = item;
            }

            return list;
        }
    }
}