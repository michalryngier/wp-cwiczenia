# Uniwersytet Śląski
## Wydział Nauk Ścisłych i Technicznych
### Wzorce Projektowe, Zadanie 3 - Obserwator.
> Wykonał: Michał Ryngier, gr. PGK 2.  
> Data ćwiczenia: 5.04.2021r.

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

#  Pliki:

- clocks:
    - <a href="#CCI">CentralClockImpl.cs</a>
- screens:
    - <a href="#BSI">BaseScreenImpl.cs</a>
    - <a href="#GS">GardenScreen.cs</a>
    - <a href="#KS">KitchenScreen.cs</a>
    - <a href="#LS">LivingroomScreen.cs</a>
-  interfaces:
    - <a href="#IC">IClock.cs</a>
    - <a href="#IS">IScreen.cs</a>
- <a href="#P">Program.cs</a>


> <a href="https://github.com/georgeFr33man/wp-cwiczenia/tree/master/wp-zadanie3">Repozytorium GitHub</a>

<div id="P"></div>

## Program.cs
```
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
            var centralClock = new CentralClockImpl(5000);
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
            centralClock.Stop();
            Console.WriteLine("Zatrzymano zegar. Wychodzenie...");
        }
    }
}
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

<div id="CCI"></div>

## CentralClockImpl.cs
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using wp_zadanie3.interfaces;
using wp_zadanie3.screens;

namespace wp_zadanie3.clocks
{
    public class CentralClockImpl : IClock
    {
        private readonly List<IScreen> _screens;
        private readonly int _interval = 60000;
        private int _timestamp;
        private volatile bool _working;

        public CentralClockImpl()
        {
            _screens = new List<IScreen>();
        }

        public CentralClockImpl(int interval)
        {
            _interval = interval;
            _screens = new List<IScreen>();
        }

        public void NotifyObservers()
        {
            var currentTime = GetFormattedTime();
            foreach (var screen in _screens) {
                screen.UpdateTime(currentTime);
            }
        }

        public void Subscribe(IScreen screen)
        {
            _screens.Add(screen);
        }

        public void Unsubscribe(IScreen screen)
        {
            try {
                var index = _screens.IndexOf(_screens.Last(s => s.Name == screen.Name));
                _screens.RemoveAt(index);
            }
            catch (Exception e) {
                Console.WriteLine("Cannot remove screen. Sorry.");
            }
        }

        private bool HasSubscriber(IScreen screen)
        {
            try {
                if (_screens.Count - 1 < 0) throw new ArgumentNullException();
                var index = _screens.IndexOf(_screens.Last(s => s.Name == screen.Name));
                return index < _screens.Count;
            }
            catch (Exception) {
                return false;
            }
        }

        /**
         * Returns true when a Subscriber was added or false when it was removed.
         */
        public bool AddOrRemoveSubscriber(IScreen screen)
        {
            if (HasSubscriber(screen)) {
                Unsubscribe(screen);
                return false;
            }

            Subscribe(screen);
            return true;
        }

        public void Start()
        {
            if (_working) return;
            _timestamp = GetCurrentTimeStamp();
            _working = true;
            var thread = new ThreadStart(TimeLoop);
            var backgroundThread = new Thread(thread);
            backgroundThread.Start();
        }

        public void Stop()
        {
            _working = false;
        }

        private void TimeLoop()
        {
            while (_working) {
                Thread.Sleep(_interval);
                _timestamp += _interval / 1000;
                if (_working) {
                    NotifyObservers();
                }
            }
        }

        private int GetCurrentTimeStamp()
        {
            return (int) DateTime.Now.Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, 0)
            ).TotalSeconds;
        }

        private string GetFormattedTime()
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(_timestamp).ToString("HH:mm");
        }
    }
}
```