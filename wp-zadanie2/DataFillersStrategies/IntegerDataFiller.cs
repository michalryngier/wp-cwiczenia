using System;
using System.Collections.Generic;
using wp_zadanie2.DataFillers;
using wp_zadanie2.Lists;

namespace wp_zadanie2.DataFillersStrategies
{
    public class IntegerDataFiller : IDataFiller<int>
    {
        public void FillWithRandomData(BaseList<int> listObject)
        {
            int i;
            var rand = new Random();
            for (i = 0; i < rand.Next(10, 50); i++) {
                listObject.Add(rand.Next(0, 1000));
            }
        }
    }
}