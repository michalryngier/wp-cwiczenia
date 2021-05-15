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