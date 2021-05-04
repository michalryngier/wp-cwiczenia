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