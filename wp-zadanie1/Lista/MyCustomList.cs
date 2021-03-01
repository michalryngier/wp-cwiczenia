using System;

namespace wp_zadanie1.Lista
{
    public class MyCustomList<T> : IMyList<T>
    {
        private int Length;
        private T[] Elements;

        public MyCustomList(int length)
        {
            Length = length;
            Elements = new T[Length];
        }

        public void Add(T element)
        {
            for (var i = 0; i < Size(); i++) {
                if (Elements[i] != null && Elements[i].Equals(default(T)) == false) continue;
                Elements[i] = element;
                break;
            }
        }

        public void Add(int index, T element)
        {
            Elements[index] = element;
        }

        public void Clear()
        {
            Elements = new T[Length];
        }

        public T Pop()
        {
            var def = default(T);
            var lastNotEmptyIndex = 0;
            for (var i = 1; i < Size(); i++) {
                if (
                    (Elements[i] == null || Elements[i].Equals(def))
                    && Elements[i - 1] != null
                    && Elements[i - 1].Equals(def) == false
                ) {
                    lastNotEmptyIndex = i - 1;
                }
            }

            return Remove(lastNotEmptyIndex);
        }

        public T Get(int index)
        {
            return Elements[index];
        }

        public int Size()
        {
            return Elements.Length;
        }

        public T Remove(int index)
        {
            var tmp = Get(index);
            Elements[index] = default;
            return tmp;
        }
    }
}