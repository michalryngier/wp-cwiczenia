# Uniwersytet Śląski
## Wydział Nauk Ścisłych i Technicznych
### Wzorce Projektowe, Zadanie 2 - Strategia.
> Wykonał: Michał Ryngier, gr. PGK 2.  
> Data ćwiczenia: 22.03.2021r.

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>


#  Pliki:

- Lists:
    - <a href="#BS">BaseList.cs</a>
    - <a href="#MIL">MyIntegerList.cs</a>
- SortingStrategies:
    - <a href="#IS">ISorter.cs</a>
    - IntegerSorting:
        - <a href="#IBS">IntegerBubbleSort.cs</a>
        - <a href="#ISS">IntegerSelectionSort.cs</a>
        - <a href="#IMS">IntegerMergeSort.cs</a>
        - <a href="#IIS">IntegerInsertionSort.cs</a>
-  DataFillersStrategies:
    - <a href="#IDF">IDataFiller.cs</a>
    - <a href="#IntDF">IntegerDataFiller.cs</a>
- <a href="#P">Program.cs</a>

> Odpowiedź na pytanie zadane w poleceniu znajduje się <a href="#Answer">TUTAJ</a>  

> <a href="https://github.com/georgeFr33man/wp-cwiczenia/tree/master/wp-zadanie2">Repozytorium GitHub</a>  

<div id="P"></div>

## Program.cs
```
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
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

## Lists:

<div id="BS"></div>

### BaseList.cs
```
using System;
using System.Collections.Generic;
using wp_zadanie2.DataFillers;
using wp_zadanie2.SortingStrategies;

namespace wp_zadanie2.Lists
{
    public abstract class BaseList<T>
    {
        private ISorter<T> _sorter;
        private List<T> _list;
        private readonly IDataFiller<T> _dataFiller;

        protected BaseList(IDataFiller<T> dataFiller)
        {
            _list = new List<T>();
            _dataFiller = dataFiller;
        }

        public abstract void PrintList();

        protected List<T> GetList()
        {
            return _list;
        }

        public void Add(T val)
        {
            _list.Add(val);
        }

        public void SelectSortingStrategy(ISorter<T> sorter = null)
        {
            _sorter = sorter;
        }

        public void FillData()
        {
            _dataFiller.FillWithRandomData(this);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public void Sort()
        {
            if (_sorter != null) {
                _list = _sorter.SortList(_list);
            } else {
                _list.Sort();
            }
        }
    }
}
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

<div id="MIL"></div>

### MyIntegerList.cs
```
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
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

## Sorting strategies:

<div id="IS"></div>

### ISorter.cs
```
using System.Collections.Generic;
using System.Security.Claims;

namespace wp_zadanie2.SortingStrategies
{
    public interface ISorter<T>
    {
        public List<T> SortList(List<T> list);
    }
}
```

<div id="IBS"></div>

### IntegerBubbleSort.cs
```
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
```

<div id="IMS"></div>

### IntegerMergeSort.cs
```
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
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

<div id="ISS"></div>

### IntegerSelectionSort.cs
```
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
```

<div id="IIS"></div>

### IntegerInsertionSort.cs
```
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
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

## DataFillersStrategies:

<div id="IDF"></div>

### IDataFiller.cs
```
using System.Collections.Generic;
using wp_zadanie2.Lists;

namespace wp_zadanie2.DataFillers
{
    public interface IDataFiller<T>
    {
        public void FillWithRandomData(BaseList<T> listObject);
    }
}
```

<div id="IntDF"></div>

### IntegerDataFiller.cs
```
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
```

<div id="Answer"></div>

## Jak takie sortowanie można zrealizować na liście generycznej?
<div style="text-align: justify; background-color: #f6f8fa; padding: 5px 10px; border-radius: 2.5px">
<p>W zamieszczonym powyżej kodzie można zauważyć, że dla klas <strong>BaseList</strong> oraz <strong>ISorter</strong> zostały wykorzystane typy generyczne. Oznacza to, że chcąc skorzystać z np. obiektu klasy <strong>ExampleClass"</strong> należy utworzyć nową klasę listy rozszerzającą <strong>BaseList</strong>, np. <strong>MyExampleClassList</strong> oraz utworzyć dla niej klasę sortującą, np. dla sortowania bąbelkowego, pozostając w konwencji: <strong>MyExampleClassBubbleSort</strong>.</p>
<p>Oczywiście każdy rodzaj sortowania należy odpowiednio dostosować do wybranego typu obiektu.</p>
</div>