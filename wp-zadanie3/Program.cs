using System;
using System.Collections.Generic;
using wp_zadanie3.clocks;
using wp_zadanie3.screens;

namespace wp_zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var centralClock = new CentralClockImpl();
            var screens = new Dictionary<string, IScreen>()
            {
                {"kitchen", new KitchenScreen()},
                {"garden", new GardenScreen()},
                {"livingroom", new LivingroomScreen()}
            };
            Console.WriteLine(
                "Menu:\n1. Uruchom zegar centralny." +
                "\n2. Dodaj/usuń wyświetlacz pokojowy." +
                "\n3. Dodaj/usuń wyświetlacz kuchenny." +
                "\n4. Dodaj/usuń wyświetlacz ogrodowy." +
                "\n5. Zatrzymaj zegar centralny." +
                "\n6. Zakończ."
            );
            do {
                input = Console.ReadLine();
                switch (input) {
                    case "1":
                        centralClock.Start();
                        Console.WriteLine("Zegar został uruchomiony.");
                        break;
                    case "2":
                        Console.WriteLine(centralClock.AddOrRemoveSubscriber(screens["livingroom"])
                            ? "Dodano wyświetlacz pokojowy."
                            : "Usunięto wyświetlacz pokojowy.");
                        break;
                    case "3":
                        Console.WriteLine(centralClock.AddOrRemoveSubscriber(screens["kitchen"])
                            ? "Dodano wyświetlacz kuchenny."
                            : "Usunięto wyświetlacz kuchenny.");
                        break;
                    case "4":
                        Console.WriteLine(centralClock.AddOrRemoveSubscriber(screens["garden"])
                            ? "Dodano wyświetlacz ogrodowy."
                            : "Usunięto wyświetlacz ogrodowy.");
                        break;
                    case "5":
                        centralClock.Stop();
                        Console.WriteLine("Zegar został zatrzymany.");
                        break;
                    case "6": break;
                    default:
                        Console.WriteLine("Nie rozpoznano polecenia.");
                        break;
                }
            } while (input != "6");

            centralClock.Stop();
            Console.WriteLine("Zatrzymano zegar. Wychodzenie...");
        }
    }
}