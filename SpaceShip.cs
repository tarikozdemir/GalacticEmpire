using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy
{
    public class SpaceShip
    {
        // Properties
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        // Different types of ships (warships, trade ships, exploration ships, etc.)
        public List<Crew> Crews { get; } = new List<Crew>();
        public int MaxSpeed { get; set; }
        public int FuelCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public int FirePower { get; set; }
        public int ShieldStrength { get; set; }
        public string? FleetName { get; set; } = null; // bunu fleet diye obje oluştur
        public int Cost { get; set; }  // Cost in gold

        // Constructor
        public SpaceShip(string name, string description, string type, List<Crew> crews, int maxSpeed, int fuelCapacity, int cargoCapacity, int firePower, int shieldStrength, string fleetName, int cost)
        {
            Name = name;
            Description = description;
            Type = type;
            Crews = crews ?? new(); //null gelirse de boş liste kullan dedik. GPT'ye sor.
            MaxSpeed = maxSpeed;
            FuelCapacity = fuelCapacity;
            CargoCapacity = cargoCapacity;
            FirePower = firePower;
            ShieldStrength = shieldStrength;
            FleetName = fleetName;
            Cost = cost;
        }

        public void DisplaySpaceShipInfo()
        {
            Console.WriteLine($"Spaceship Name: {Name}, {Type}, {Cost}");
            Console.WriteLine($"Crews: ");
            foreach (var crew in Crews)
            {
                Console.WriteLine($"- {crew.Name}: Quantity: {crew.Quantity}");
            }
            Console.WriteLine($"Maxspeed: {MaxSpeed}");
            Console.WriteLine($"Fuel capacity: {FuelCapacity}");
            Console.WriteLine($"Cargo capacity: {CargoCapacity}");
            Console.WriteLine($"Fire power: {FirePower}");
            Console.WriteLine($"Shield strength: {ShieldStrength}");
            Console.WriteLine($"Fleet name (if assigned): {FleetName}");
        }
    }

    public enum SpaceShipType
    {
        Scout,
        // Features: Small and fast.
        // Usage: Exploration, gathering information, scanning enemy territories.
        Fighter,
        // Features: High attack and defense capabilities.
        // Usage: Attacking, capturing enemy ships or bases.
        Frigate,
        // Features: Medium-sized and balanced.
        // Usage: Balances between offense and defense.
        Destroyer,
        // Features: High attack capacity, medium defense.
        // Usage: Effective in intense combat scenarios.
        Cruiser,
        // Features: Large, durable, and multifunctional.
        // Usage: Heavy attack or defense operations.
        Capital_Ship,
        // Features: Very large and multifunctional.
        // Usage: Central point of the fleet, used as a base.
        Freighter
        // Features: High cargo capacity.
        // Usage: Resource collection, trade.
    }
}