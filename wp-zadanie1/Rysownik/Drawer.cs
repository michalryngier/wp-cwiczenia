using System;

namespace wp_zadanie1.Rysownik
{
    public abstract class Drawer
    {
        protected const string InkChar = " * ";
        protected const double MaxTypeLength = 31;
        protected string Type = "Not assigned";
        public abstract void Draw();

        public string GetType()
        {
            return Type;
        }

        public void PrintType()
        {
            var typeWritten = false;
            var typeLength = GetType().Length;
            var arrowLength = Convert.ToInt16(Math.Floor((MaxTypeLength - typeLength) / 2));
            
            Console.Write("\n\n<");
            for (var i = 0; i < arrowLength; i++) {
                Console.Write("-");
                if (i != arrowLength - 1 || typeWritten) continue;
                Console.Write(GetType());
                typeWritten = true;
                if ((MaxTypeLength - typeLength) % 2 != 0) ++arrowLength;
                i = 0;
            }
            Console.Write(">");
        }
    }
}