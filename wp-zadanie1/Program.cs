using System;

namespace wp_zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*---------------------------------------------- Zadanie 1 -----------------------------------------------*/
            Write(
                "/*---------------------------------- Zadanie 1 ----------------------------------*/"
            );
            const int lenght = 10;
            MyCustomList<string> myCustomList = new MyCustomList<string>(lenght);
            // Dodaj 5 elementów zaczynając od początku listy.
            for (var i = 0; i < 5; i++) {
                myCustomList.Add((i + 1).ToString());
            }
            
            // Wypisz dodane elementy.
            Write("\nWypisuje dodane elementy:");
            Write(myCustomList.Get(0));
            Write(myCustomList.Get(1));
            Write(myCustomList.Get(2));
            Write(myCustomList.Get(3));
            Write(myCustomList.Get(4));
            
            // Wypisz nowo dodany element
            Write("\nWypisuje nowo dodany element:");
            myCustomList.Add(6, 100.ToString());
            Write(myCustomList.Get(6));
            
            // Usuń element i wypisz wartość z tego indexu.
            Write("\nUsuwam element i sprawdzam wartość na wskazanym indexie:");
            myCustomList.Remove(0);
            Write(myCustomList.Get(0));
            
            // Pokaż i usuń ostatni niepusty element.
            Write("\nPobieram ostatni niepusty element i go usuwam (Pop()):");
            Write(myCustomList.Pop());
            
            // Wyczyść listę
            Write("\nCzyszczę listę i pokazuję element z indexem 0:");
            myCustomList.Clear();
            Write(myCustomList.Get(0));
            
            /*---------------------------------------------- Zadanie 2 -----------------------------------------------*/
            Write(
                "/*---------------------------------- Zadanie 2 ----------------------------------*/"
            );
        }

        static void Write<T>(T text)
        {
            if (text == null) {
                Console.WriteLine("null");
            } else {
                Console.WriteLine(text.ToString());
            }
        }
    }
}