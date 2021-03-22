using System;
using Microsoft.VisualBasic.CompilerServices;
using wp_zadanie2.Lists;
using wp_zadanie2.SortingStrategies.IntegerSorting;
using static System.Int32;



namespace wp_zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            string optionSelection, data;
            bool selected = false, validData = true;
            BaseList<int> myIntegerList = new MyIntegerList();


            Console.WriteLine("----------Welcome to List Sorter!----------");
            Console.WriteLine("Please choose one option from below:");
            Console.WriteLine("  1. I'll provide data myself.\n  2. Generate random data.");

            /* Select data input */
            do {
                optionSelection = Console.ReadLine();
                switch (optionSelection) {
                    case "1":
                        do {
                            myIntegerList.Clear();
                            Console.WriteLine("----------Please provide a valid data, pattern: 1,2,3,4,5 ----------");
                            data = Console.ReadLine();
                            if (data == null) continue;
                            var subData = data.Split(",");
                            foreach (var sub in subData) {
                                var trimmedSub = sub.Trim();
                                if (TryParse(trimmedSub, out var value)) {
                                    myIntegerList.Add(value);
                                } else {
                                    validData = false;
                                    break;
                                }
                            }
                        } while (validData == false);

                        selected = true;
                        break;
                    case "2":
                        myIntegerList.FillData();
                        selected = true;
                        break;
                    default:
                        Console.WriteLine("----------Wrong option selected, please try again.----------");
                        break;
                }
            } while (selected == false);

            /* Sorting strategy selection */
            Console.WriteLine("Please choose one sorting strategy from below:");
            Console.WriteLine("  1. Bubble Sort.\n  2. Insertion Sort.\n  3. Merge Sort.\n  4. Selection Sort.");
            do {
                optionSelection = Console.ReadLine();
                switch (optionSelection) {
                    case "1":
                        myIntegerList.SelectSortingStrategy(new IntegerBubbleSort());
                        selected = true;
                        break;
                    case "2":
                        myIntegerList.SelectSortingStrategy(new IntegerInsertionSorting());
                        selected = true;
                        break;
                    case "3":
                        myIntegerList.SelectSortingStrategy(new IntegerMergeSort());
                        selected = true;
                        break;
                    case "4":
                        myIntegerList.SelectSortingStrategy(new IntegerSelectionSort());
                        selected = true;
                        break;
                    default:
                        Console.WriteLine("----------Wrong option selected, please try again.----------");
                        selected = false;
                        break;
                }
            } while (selected == false);
            
            myIntegerList.PrintList();
            Console.WriteLine("\nSorting...");
            myIntegerList.Sort();
            myIntegerList.PrintList();
        }
    }
}