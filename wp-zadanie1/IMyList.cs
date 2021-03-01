using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace wp_zadanie1
{
    public interface IMyList<T>
    {
        void Add(T element);

        void Add(int index, T element);

        void Clear();

        T Pop();

        T Get(int index);

        int Size();

        T Remove(int index);
    }
}