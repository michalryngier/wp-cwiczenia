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