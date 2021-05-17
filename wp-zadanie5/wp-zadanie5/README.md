# Uniwersytet Śląski
## Wydział Nauk Ścisłych i Technicznych
### Wzorce Projektowe, Zadanie 5 - Dekorator.
> Wykonał: Michał Ryngier, gr. PGK 2.  
> Data ćwiczenia: 10.05.2021r.

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

#  Pliki:

- Decorators:
    - <a href="#CBD">CommonBootsDecorator.cs</a>
    - <a href="#EHD">EpicHelmetDecorator.cs</a>
    - <a href="#LSD">LegendarySwordDecorator.cs</a>
    - <a href="#PD">PantsDecorator.cs</a>
    - <a href="#RGD">RareGlovesDecorator.cs</a>
- <a href="#AP">AbstractPlayer.cs</a>
- <a href="#PLAYER">Player.cs</a>
- <a href="#P">Program.cs</a>


> <a href="https://github.com/georgeFr33man/wp-cwiczenia/tree/master/wp-zadanie5/wp-zadanie5">Repozytorium GitHub</a>

<div id="P"></div>

## Program.cs
```
using System;
using System.Collections.Generic;
using wp_zadanie5.Decorators;

namespace wp_zadanie5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input;
            var abstractPlayers = new Dictionary<string, AbstractPlayer>()
            {
                {"Player", null},
                {"CommonBoots", null},
                {"EpicHelmet", null},
                {"LegendarySword", null},
                {"Pants", null},
                {"RareGloves", null},
            };
            do {
                Console.WriteLine("1. Aby stworzyć nowego bohatera naciśnij 1" +
                                  "\n2. W celu dodania/usunięcia rękawic do/z aktualnego bohatera naciśnij 2." +
                                  "\n3. W celu dodania/usunięcia butów do/z aktualnego bohatera naciśnij 3." +
                                  "\n4. W celu dodania/usunięcia spodni do/z aktualnego bohatera naciśnij 4." +
                                  "\n5. W celu dodania/usunięcia hełmu do/z aktualnego bohatera naciśnij 5." +
                                  "\n6. W celu dodania/usunięcia miecza do/z aktualnego bohatera naciśnij 6." +
                                  "\n7. Aby zatrzymać działanie programu naciśnij 0");
                input = Console.ReadLine();
                switch (input) {
                    case "1":
                        if (DictionaryHasValue(abstractPlayers, "Player")) {
                            Console.WriteLine("Bohater już istnieje.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        } else {
                            abstractPlayers["Player"] = new Player();
                            Console.WriteLine("Stworzono nowego bohatera.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        }

                        break;
                    case "2":
                        if (DictionaryHasValue(abstractPlayers, "Player") == false) {
                            Console.WriteLine("Najpierw stwórz bohatera.");
                            break;
                        }
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

```
                        if (DictionaryHasValue(abstractPlayers, "RareGloves")) {
                            abstractPlayers["Player"] =
                                new RareGlovesDecorator().RemoveAttribute(abstractPlayers["Player"]);
                            abstractPlayers["RareGloves"] = null;
                            Console.WriteLine("Usunięto Rzadkie Rękawice.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        } else {
                            abstractPlayers["Player"] = new RareGlovesDecorator(abstractPlayers["Player"]);
                            abstractPlayers["RareGloves"] = abstractPlayers["Player"];
                            Console.WriteLine("Dodano Rzadkie Rękawice.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        }

                        break;
                    case "3":
                        if (DictionaryHasValue(abstractPlayers, "Player") == false) {
                            Console.WriteLine("Najpierw stwórz bohatera.");
                            break;
                        }

                        if (DictionaryHasValue(abstractPlayers, "CommonBoots")) {
                            abstractPlayers["Player"] = 
                                new CommonBootsDecorator().RemoveAttribute(abstractPlayers["Player"]);
                            abstractPlayers["CommonBoots"] = null;
                            Console.WriteLine("Usunięto Zwyczajne Buty.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        } else {
                            abstractPlayers["Player"] = new CommonBootsDecorator(abstractPlayers["Player"]);
                            abstractPlayers["CommonBoots"] = abstractPlayers["Player"];
                            Console.WriteLine("Dodano Zwyczajne Buty.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        }

                        break;
                    case "4":
                        if (DictionaryHasValue(abstractPlayers, "Player") == false) {
                            Console.WriteLine("Najpierw stwórz bohatera.");
                            break;
                        }

                        if (DictionaryHasValue(abstractPlayers, "Pants")) {
                            abstractPlayers["Player"] = 
                                new PantsDecorator().RemoveAttribute(abstractPlayers["Player"]);
                            abstractPlayers["Pants"] = null;
                            Console.WriteLine("Usunięto Spodnie.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        } else {
                            abstractPlayers["Player"] = new PantsDecorator(abstractPlayers["Player"]);
                            abstractPlayers["Pants"] = abstractPlayers["Player"];
                            Console.WriteLine("Dodano Spodnie.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        }

                        break;
                    case "5":
                        if (DictionaryHasValue(abstractPlayers, "Player") == false) {
                            Console.WriteLine("Najpierw stwórz bohatera.");
                            break;
                        }
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

```
                        if (DictionaryHasValue(abstractPlayers, "EpicHelmet")) {
                            abstractPlayers["Player"] = 
                                new EpicHelmetDecorator().RemoveAttribute(abstractPlayers["Player"]);
                            abstractPlayers["EpicHelmet"] = null;
                            Console.WriteLine("Usunięto Epicki Hełm.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        } else {
                            abstractPlayers["Player"] = new EpicHelmetDecorator(abstractPlayers["Player"]);
                            abstractPlayers["EpicHelmet"] = abstractPlayers["Player"];
                            Console.WriteLine("Dodano Epicki Hełm.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        }

                        break;
                    case "6":
                        if (DictionaryHasValue(abstractPlayers, "Player") == false) {
                            Console.WriteLine("Najpierw stwórz bohatera.");
                            break;
                        }

                        if (DictionaryHasValue(abstractPlayers, "LegendarySword")) {
                            abstractPlayers["Player"] =
                                new LegendarySwordDecorator().RemoveAttribute(abstractPlayers["Player"]);
                            abstractPlayers["LegendarySword"] = null;
                            Console.WriteLine("Usunięto Legendarny Miecz.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        } else {
                            abstractPlayers["Player"] = new LegendarySwordDecorator(abstractPlayers["Player"]);
                            abstractPlayers["LegendarySword"] = abstractPlayers["Player"];
                            Console.WriteLine("Dodano Legendarny Miecz.");
                            Console.WriteLine(abstractPlayers["Player"].CalculateStatistics());
                        }

                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Nie rozpoznano polecenia.");
                        break;
                }
            } while (input != "0");
        }

        private static bool DictionaryHasValue(IReadOnlyDictionary<string, AbstractPlayer> abstractPlayers, string key)
        {
            return abstractPlayers[key] != null;
        }
    }
}
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

# Decorators

<div id="CBD"></div>

## CommonBootsDecorator.cs
```
namespace wp_zadanie5.Decorators
{
    public class CommonBootsDecorator : AbstractPlayer
    {
        private const int BaseAttack = 0;
        private const int BaseDefence = 3;
        private const int BaseHealthPoints = 0;

        public CommonBootsDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}
```

<div id="EHD"></div>

## EpicHelmetDecorator.cs
```
namespace wp_zadanie5.Decorators
{
    public class EpicHelmetDecorator : AbstractPlayer
    {
        private const int BaseAttack = 0;
        private const int BaseDefence = 6;
        private const int BaseHealthPoints = 2;

        public EpicHelmetDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}
```

<div id="LSD"></div>

## LegendarySwordDecorator.cs
```
namespace wp_zadanie5.Decorators
{
    public class LegendarySwordDecorator : AbstractPlayer
    {
        private const int BaseAttack = 12;
        private const int BaseDefence = 2;
        private const int BaseHealthPoints = 0;


        public LegendarySwordDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}
```

<div id="PD"></div>

## PantsDecorator.cs
```
namespace wp_zadanie5.Decorators
{
    public class LegendarySwordDecorator : AbstractPlayer
    {
        private const int BaseAttack = 12;
        private const int BaseDefence = 2;
        private const int BaseHealthPoints = 0;


        public LegendarySwordDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}
```

<div id="RGD"></div>

## RareGlovesDecorator.cs
```
namespace wp_zadanie5.Decorators
{
    public class LegendarySwordDecorator : AbstractPlayer
    {
        private const int BaseAttack = 12;
        private const int BaseDefence = 2;
        private const int BaseHealthPoints = 0;


        public LegendarySwordDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

<div id="AP"></div>

## AbstractPlayer.cs
```
using System;

namespace wp_zadanie5
{
    public abstract class AbstractPlayer
    {
        public int HealthPoints { get; set; }
        public int Attack { get; set; }
        public  int Defence { get; set; }

        public string CalculateStatistics()
        {
            return "HP: " + HealthPoints + "|Attack: " + Attack + "|Defence: " + Defence;
        }
        
        public AbstractPlayer RemoveAttribute(AbstractPlayer basePlayer)
        {
            basePlayer.Attack -= Attack;
            basePlayer.Defence -= Defence;
            basePlayer.HealthPoints -= HealthPoints;
            return basePlayer;
        }
    }
}
```

<div id="PLAYER"></div>

## Player.cs
```
namespace wp_zadanie5
{
    public class Player : AbstractPlayer
    {
        private const int BaseAttack = 10;
        private const int BaseDefence = 10;
        private const int BaseHealthPoints = 10;

        public Player()
        {
            HealthPoints = BaseHealthPoints;
            Attack = BaseAttack;
            Defence = BaseDefence;
        }
    }
}
```
