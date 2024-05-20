using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy
{
    public class Fleet
    {
        public List<SpaceShip> Ships { get; } = new List<SpaceShip>();
        public int Speed => Ships.Count > 0 ? Ships.Min(s => s.MaxSpeed) : 0;

        public Fleet(List<SpaceShip> ships)
        {
            Ships.AddRange(ships);
        }

        public void AddShip(SpaceShip ship)
        {
            Ships.Add(ship);
        }

        public void DisplayFleetInfo()
        {
            Console.WriteLine($"Fleet speed: {Speed}");
            foreach (var ship in Ships)
            {
                ship.DisplaySpaceShipInfo();
            }
        }
    }
}
