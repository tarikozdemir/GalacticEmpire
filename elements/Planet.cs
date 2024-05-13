using System.Drawing;
using System.Numerics;
using Galaxy;

namespace Galaxy
{
    public class Planet
    {
        public string? Name { get; set; }
        public List<Resource>? Resources { get; set; }
        public List<StrategicAdvantage>? StrategicAdvantage { get; set; }
        // Each planet may have certain advantages (for example, one planet may be strong in defense while another may be rich in resources).
        public int ResourceCapacity { get; set; }
        public Vector2 Position { get; set; }
        public Player? OccupiedBy { get; set; }
        public ConsoleColor Color{ get; set; } = ConsoleColor.White;
        public string V { get; }

        public override string ToString() => $"{Name} - {Position}";

        public Planet(string name, Vector2 position, List<Resource> resources, List<StrategicAdvantage> strategicAdvantages, int resourceCapacity, ConsoleColor color)
        {
            Name = name;
            Position = position;
            Resources = resources;
            StrategicAdvantage = strategicAdvantages;
            ResourceCapacity = resourceCapacity;
            Color = color;
        }

        public Planet(string v, Vector2 position)
        {
            V = v;
            Position = position;
        }
    }

        public static class PlanetInitializer
    {
        public static List<Planet> InitializePlanets()
        {
            return new List<Planet>
            {
                new Planet(
                    name: "Veloria",
                    position: new Vector2(2, 3),
                    resources: new List<Resource> { new Resource(), new Resource() }, // Burada özel kaynak sınıflarını kullanabilirsiniz
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 5000,
                    color: ConsoleColor.Cyan
                ),
                new Planet(
                    name: "Zynthara",
                    position: new Vector2(5, 1),
                    resources: new List<Resource> { new Resource(), new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 3000,
                    color: ConsoleColor.Yellow
                ),
                new Planet(
                    name: "Erebus Prime",
                    position: new Vector2(4, 6),
                    resources: new List<Resource> { new Resource(), new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 7000,
                    color: ConsoleColor.DarkMagenta
                ),
                new Planet(
                    name: "Tarragon",
                    position: new Vector2(1, 7),
                    resources: new List<Resource> { new Resource(), new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 4000,
                    color: ConsoleColor.Blue
                ),
                new Planet(
                    name: "Calypsis",
                    position: new Vector2(3, 2),
                    resources: new List<Resource> { new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 6000,
                    color: ConsoleColor.Red
                ),
                new Planet(
                    name: "Aurelios",
                    position: new Vector2(2, 5),
                    resources: new List<Resource> { new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 3500,
                    color: ConsoleColor.Green
                ),
                new Planet(
                    name: "Nemorath",
                    position: new Vector2(7, 3),
                    resources: new List<Resource> { new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 8000,
                    color: ConsoleColor.White
                ),
                new Planet(
                    name: "Zephyros",
                    position: new Vector2(0, 4),
                    resources: new List<Resource> { new Resource(), new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 5500,
                    color: ConsoleColor.Magenta
                ),
                new Planet(
                    name: "Orphidia",
                    position: new Vector2(6, 8),
                    resources: new List<Resource> { new Resource(), new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 6500,
                    color: ConsoleColor.DarkRed
                ),
                new Planet(
                    name: "Draconis",
                    position: new Vector2(8, 2),
                    resources: new List<Resource> { new Resource(), new Resource() },
                    strategicAdvantages: new List<StrategicAdvantage> { new StrategicAdvantage() },
                    resourceCapacity: 7000,
                    color: ConsoleColor.Gray
                )
            };
        }
    }
}