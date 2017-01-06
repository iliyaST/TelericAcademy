namespace WarMachines.Engine
{
    using System;
    using Common;
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            IPilot pilot = new Pilot(name);

            Validator.ValidateNull(pilot);

            return pilot;
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            ITank tank = new Tank(name, attackPoints, defensePoints);

            Validator.ValidateNull(tank);

            return tank;
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            IFighter fighter = new Fighter(name, attackPoints, defensePoints, stealthMode);

            Validator.ValidateNull(fighter);

            return fighter;
        }
    }
}
