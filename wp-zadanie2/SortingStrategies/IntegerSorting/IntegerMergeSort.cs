using System.Collections.Generic;
using System.Linq;

namespace wp_zadanie2.SortingStrategies.IntegerSorting
{
    public class IntegerMergeSort : ISorter<int>
    {
        public List<int> SortList(List<int> list)
        {
            return MergeSort(list);
        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            var left = new List<int>();
            var right = new List<int>();

            var middle = unsorted.Count / 2;
            for (var i = 0; i < middle; i++) {
                left.Add(unsorted[i]);
            }

            for (var i = middle; i < unsorted.Count; i++) {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(ICollection<int> left, ICollection<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 || right.Count > 0) {
                switch (left.Count > 0) {
                    case true when right.Count > 0: {
                        if (left.First() <= right.First()) {
                            result.Add(left.First());
                            left.Remove(left.First());
                        }
                        else {
                            result.Add(right.First());
                            right.Remove(right.First());
                        }

                        break;
                    }
                    case true:
                        result.Add(left.First());
                        left.Remove(left.First());
                        break;
                    default: {
                        if (right.Count > 0) {
                            result.Add(right.First());

                            right.Remove(right.First());
                        }

                        break;
                    }
                }
            }

            return result;
        }
    }
}