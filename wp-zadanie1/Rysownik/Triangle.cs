using System;

namespace wp_zadanie1.Rysownik
{
    public class Triangle : Drawer
    {
        private double Side;
        private double Height;
        
        public Triangle(double side, double height)
        {
            Type = "Triangle";
            Side = side;
            Height = height;
        }
        
        public override void Draw()
        {
            PrintType();
            for (var i = 0; i < Height; i++) {
                Console.Write("\n");
                for (var j = 0; j < Side; j++) {
                    if (j <= i * Math.Ceiling(Side / Height)) {
                        Console.Write(InkChar);
                    }
                }
            }
        }
    }
}