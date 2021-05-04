# Uniwersytet Śląski
## Wydział Nauk Ścisłych i Technicznych
### Wzorce Projektowe, Zadanie 4 - Fabryka.
> Wykonał: Michał Ryngier, gr. PGK 2.  
> Data ćwiczenia: 26.04.2021r.

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

#  Pliki:

- Factories:
    - <a href="#UF">UnitFactory.cs</a>
    - <a href="#DUF">DistanceUnitFactory.cs</a>
    - <a href="#AUF">ArmedUnitFactory.cs</a>
- Units:
    - <a href="#IU">IUnit.cs</a>
    - <a href="#AUI">ArcherUnitImpl.cs</a>
    - <a href="#CUI">CatapultUnitImpl.cs</a>
    - <a href="#IUI">InfantryUnitImpl.cs</a>
    - <a href="#KUI">KnightUnitImpl.cs</a>
- <a href="#P">Program.cs</a>


> <a href="https://github.com/georgeFr33man/wp-cwiczenia/tree/master/wp-zadanie4">Repozytorium GitHub</a>

<div id="P"></div>

## Program.cs
```
using System;
using System.Collections.Generic;
using System.Linq;
using wp_zadanie4.Factories;
using wp_zadanie4.Units;

namespace wp_zadanie4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input;
            var unitList = new Dictionary<string, List<IUnit>>()
            {
                {"AU", new List<IUnit>()},
                {"DU", new List<IUnit>()}
            };
            /* MAIN MENU */
            do {
                Console.WriteLine("1. Stwórz namiot jednostek bliskiego zasięgu." +
                                  "\n2. Stwórz pole jednostek dystansowych." +
                                  "\n3. Pokaż moje jednostki." +
                                  "\n0. Wyjdź z programu.");
                input = Console.ReadLine();
                IUnit newUnit;
                switch (input) {
                    case "1":
                        newUnit = SelectArmedUnits();
                        if (newUnit != null) unitList["AU"].Add(newUnit);
                        break;
                    case "2":
                        newUnit = SelectDistanceUnits();
                        if (newUnit != null) unitList["DU"].Add(newUnit);
                        break;
                    case "3":
                        ShowUnits(unitList);
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Nie rozpoznano polecenia.");
                        break;
                }
            } while (input != "0");
        }
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

```
        private static IUnit SelectArmedUnits()
        {
            var factory = new ArmedUnitFactory();
            string input;
            do {
                Console.WriteLine("1. Stwórz piechotę." +
                                  "\n2. Stwórz rycerza." +
                                  "\n0. Powrót do menu głównego.");
                input = Console.ReadLine();
                switch (input) {
                    case "1":
                        return factory.CreateUnit(ArmedUnitFactory.Infantry);
                    case "2":
                        return factory.CreateUnit(ArmedUnitFactory.Knight);
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Nie rozpoznano polecenia.");
                        break;
                }
            } while (input != "0");

            return null;
        }

        private static IUnit SelectDistanceUnits()
        {
            var factory = new DistanceUnitFactory();
            string input;
            do {
                Console.WriteLine("1. Stwórz łuczników." +
                                  "\n2. Stwórz katapultę." +
                                  "\n0. Powrót do menu głównego.");
                input = Console.ReadLine();
                switch (input) {
                    case "1":
                        return factory.CreateUnit(DistanceUnitFactory.Archer);
                    case "2":
                        return factory.CreateUnit(DistanceUnitFactory.Catapult);
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Nie rozpoznano polecenia.");
                        break;
                }
            } while (input != "0");

            return null;
        }

        private static void ShowUnits(Dictionary<string, List<IUnit>> units)
        {
            foreach (var unit in units.SelectMany(unitKey => unitKey.Value)) {
                Console.WriteLine(unit.ToString());
            }
        }
    }
}
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

# Factories

<div id="UF"></div>

## UnitFactory.cs
```
using wp_zadanie4.Units;

namespace wp_zadanie4.Factories
{
    public abstract class UnitFactory
    {
        public abstract IUnit CreateUnit(string type);
    }
}
```

<div id="DUF"></div>

## DistanceUnitFactory.cs
```
using wp_zadanie4.Units;

namespace wp_zadanie4.Factories
{
    public class DistanceUnitFactory : UnitFactory
    {
        public const string Archer = "ARCHER";
        public const string Catapult = "CATAPULT";
        
        public override IUnit CreateUnit(string type)
        {
            switch (type) {
                case Archer: return new ArcherUnitImpl();
                case Catapult: return new CatapultUnitImpl();
                default: return null;
            }
        }
    }
}
```

<div id="AUF"></div>

## ArmedUnitFactory.cs
```
using System;
using System.Collections.Generic;
using wp_zadanie4.Units;

namespace wp_zadanie4.Factories
{
    public class ArmedUnitFactory : UnitFactory
    {
        public const string Knight = "KNIGHT";
        public const string Infantry = "INFANTRY";

        public override IUnit CreateUnit(string type)
        {
            switch (type) {
                case Knight: return new KnightUnitImpl();
                case Infantry: return new InfantryUnitImpl();
                default: return null;
            }
        }
    }
}
```
# Units

<div id="IU"></div>

## IUnit.cs
```
namespace wp_zadanie4.Units
{
    public interface IUnit
    {
        string ToString();
        string Name { get; }
        int AttackPoints { get; }
        int AttackRange { get; }
        int Cost { get; }
        int HealthPoints { get; set; }
    }
}
```

<div id="AUI"></div>

## ArcherUnitImpl.cs
```
namespace wp_zadanie4.Units
{
    public class ArcherUnitImpl : IUnit
    {
        public ArcherUnitImpl()
        {
            Name = "Archer";
            HealthPoints = 50;
            AttackPoints = 8;
            AttackRange = 8;
            Cost = 50;
        }

        public int HealthPoints { get; set; }

        public string Name { get; }

        public int AttackPoints { get; }

        public int AttackRange { get; }

        public int Cost { get; }

        public new string ToString()
        {
            return "Name: " + Name + " | HP: " + HealthPoints + " | Attack: " + AttackPoints;
        }
    }
}
```

<div id="CUI"></div>

## CatapultUnitImpl.cs
```
namespace wp_zadanie4.Units
{
    public class CatapultUnitImpl : IUnit
    {
        public CatapultUnitImpl()
        {
            Name = "Catapult";
            HealthPoints = 100;
            AttackPoints = 10;
            AttackRange = 10;
            Cost = 500;
        }

        public int HealthPoints { get; set; }

        public string Name { get; }

        public int AttackPoints { get; }

        public int AttackRange { get; }

        public int Cost { get; }

        public new string ToString()
        {
            return "Name: " + Name + " | HP: " + HealthPoints + " | Attack: " + AttackPoints;
        }
    }
}
```

<div id="IS"></div>

## InfantryUnitImpl.cs
```
namespace wp_zadanie4.Units
{
    public class InfantryUnitImpl : IUnit
    {
        public InfantryUnitImpl()
        {
            Name = "Infantry";
            HealthPoints = 50;
            AttackPoints = 10;
            AttackRange = 4;
            Cost = 50;
        }
        
        public int HealthPoints { get; set; }

        public string Name { get; }

        public int AttackPoints { get; }

        public int AttackRange { get; }

        public int Cost { get; }

        public new string ToString()
        {
            return "Name: " + Name + " | HP: " + HealthPoints + " | Attack: " + AttackPoints;
        }
    }
}
```

<div style="page-break-after: always; visibility: hidden"> 
\pagebreak 
</div>

<div id="KUI"></div>

## KnightUnitImpl.cs
```
namespace wp_zadanie4.Units
{
    public class KnightUnitImpl : IUnit
    {
        public KnightUnitImpl()
        {
            Name = "Knight";
            HealthPoints = 200;
            AttackPoints = 20;
            AttackRange = 3;
            Cost = 150;
        }

        public int HealthPoints { get; set; }

        public string Name { get; }

        public int AttackPoints { get; }

        public int AttackRange { get; }

        public int Cost { get; }

        public new string ToString()
        {
            return "Name: " + Name + " | HP: " + HealthPoints + " | Attack: " + AttackPoints;
        }
    }
}
```
