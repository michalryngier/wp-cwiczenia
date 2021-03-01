using System;

namespace wp_zadanie1.Rysownik
{
    public class Square : Drawer
    {
        public double Side;
        public Square(double val)
        {
            Type = "Square";
            Side = val;
        }
        
        public override void Draw()
        {
            PrintType();
            for (var i = 0; i < Side; i++) {
                Console.Write("\n");
                for (var j = 0; j < Side; j++) {
                    Console.Write(InkChar);
                }
            }
        }
    }
}