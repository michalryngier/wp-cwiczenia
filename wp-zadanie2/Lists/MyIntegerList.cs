using System;
using wp_zadanie2.DataFillersStrategies;

namespace wp_zadanie2.Lists
{
    /**
     * This is just an example of how we can specify new List with
     * some custom methods, selected type and data filling strategy.
     */
    public class MyIntegerList : BaseList<int>
    {
        public MyIntegerList() : base(new IntegerDataFiller()) { }

        public override void PrintList()
        {
            Console.WriteLine("\nYour list looks like:");
            var list = GetList();
            foreach (var el in list) {
                Console.Write(" " + el + " ");
            }
        }
    }
}