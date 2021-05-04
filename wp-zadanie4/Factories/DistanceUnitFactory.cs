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