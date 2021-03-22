using System.Collections.Generic;
using System.Security.Claims;

namespace wp_zadanie2.SortingStrategies
{
    public interface ISorter<T>
    {
        public List<T> SortList(List<T> list);
    }
}