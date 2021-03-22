using System.Collections.Generic;
using wp_zadanie2.Lists;

namespace wp_zadanie2.DataFillers
{
    public interface IDataFiller<T>
    {
        public void FillWithRandomData(BaseList<T> listObject);
    }
}