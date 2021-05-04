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