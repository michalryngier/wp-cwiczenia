using wp_zadanie4.Units;

namespace wp_zadanie4.Factories
{
    public abstract class UnitFactory
    {
        public abstract IUnit CreateUnit(string type);
    }
}