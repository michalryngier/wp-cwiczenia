using System;

namespace wp_zadanie1.Rysownik
{
    public class Rectangle : Drawer
    {
        private double SideX;
        private double SideY;

        public Rectangle(double valX, double valY)
        {
            Type = "Rectangle";
            SideX = valX;
            SideY = valY;
        }

        public override void Draw()
        {
            PrintType();
            for (var i = 0; i < SideY; i++) {
                Console.Write("\n");
                for (var j = 0; j < SideX; j++) {
                    Console.Write(InkChar);
                }
            }
        }
    }
}