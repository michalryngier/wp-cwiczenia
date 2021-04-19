# Uniwersytet Śląski
## Wydział Nauk Ścisłych i Technicznych
### Wzorce Projektowe, Zadanie 3 - Obserwator.
> Wykonał: Michał Ryngier, gr. PGK 2.  
> Data ćwiczenia: 5.04.2021r.

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

#  Pliki:

- Clocks:
    - <a href="#CCI">CentralClockImpl.cs</a>
- Screens:
    - <a href="#BSI">BaseScreenImpl.cs</a>
    - <a href="#GS">GardenScreen.cs</a>
    - <a href="#KS">KitchenScreen.cs</a>
    - <a href="#LS">LivingroomScreen.cs</a>
-  Interfaces:
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
using wp_zadanie3.interfaces;
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
using System.Threading.Tasks;
using wp_zadanie3.interfaces;

namespace wp_zadanie3.clocks
{
    public class CentralClockImpl : IClock
    {
        private readonly List<IScreen> _screens;
        private readonly int _interval = 60000;
        private int _timestamp, _clockTaskId;
        private volatile bool _working;
        private Task _clockTask;

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
                var index = _screens.IndexOf(screen);
                _screens.RemoveAt(index);
            }
            catch (Exception) {
                Console.WriteLine("Cannot remove screen.");
            }
        }

        public void Start()
        {
            if (_working) return;
            _timestamp = GetCurrentTimeStamp();
            _working = true;
            _clockTask = Task.Run(() => TimeLoop(++_clockTaskId));
        }

        public void Stop()
        {
            _working = false;
        }

        private void TimeLoop(int taskId)
        {
            while (_working && taskId == _clockTaskId) {
                NotifyObservers();
                _timestamp += _interval / 1000;
                _clockTask.Wait(_interval);
            }
        }

        /**
         * Returns IScreen type object or null.
         */
        public bool AddOrRemoveSubscriber(IScreen screen)
        {
            var oldScreen = HasSubscriber(screen);
            if (oldScreen != null) {
                Unsubscribe(oldScreen);
                return false;
            }

            Subscribe(screen);
            return true;
        }

        private IScreen HasSubscriber(IScreen screen)
        {
            try {
                if (_screens.Count - 1 < 0) throw new ArgumentNullException();
                return _screens.Last(s => s.Name == screen.Name);
            }
            catch (Exception) {
                return null;
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

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

# Screens:

<div id="BSI"></div>

## BaseScreenImpl.cs
```
using wp_zadanie3.interfaces;

namespace wp_zadanie3.screens
{
    public abstract class BaseScreenImpl : IScreen
    {
        protected BaseScreenImpl(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract void UpdateTime(string time);
    }
}
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

<div id="GS"></div>

## GardenScreen.cs
```
using System;
using System.ComponentModel;

namespace wp_zadanie3.screens
{
    public class GardenScreen : BaseScreenImpl
    {
        public GardenScreen() : base("Ogród") { }

        public override void UpdateTime(string time)
        {
            Console.WriteLine("W ogrodzie jest godzina: " + time);
        }
    }
}
```

<div id="GS"></div>

## KitchenScreen.cs
```
using System;

namespace wp_zadanie3.screens
{
    public class KitchenScreen : BaseScreenImpl
    {
        public KitchenScreen() : base("Kuchnia") { }
        
        public override void UpdateTime(string time)
        {
            Console.WriteLine("W kuchni jest godzina: " + time);
        }
    }
}
```

<div id="LS"></div>

## LivingroomScreen.cs
```
using System;

namespace wp_zadanie3.screens
{
    public class LivingroomScreen : BaseScreenImpl
    {
        public LivingroomScreen() : base("Pokój") { }

        public override void UpdateTime(string time)
        {
            Console.WriteLine("W pokoju jest godzina: " + time);
        }
    }
}
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

# Interfaces

<div id="IC"></div>

## IClock.cs
```
namespace wp_zadanie3.interfaces
{
    public interface IClock
    {
        void NotifyObservers();
        void Subscribe(IScreen screen);
        void Unsubscribe(IScreen screen);
    }
}
```

<div id="IS"></div>

## IScreen.cs
```
namespace wp_zadanie3.interfaces
{
    public interface IScreen
    {
        string Name { get; }
        public void UpdateTime(string time);
    }
}
```
