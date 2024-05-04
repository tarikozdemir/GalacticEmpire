using System.Drawing;
using System.Numerics;

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

        public Planet(string name, int spaceSize)
        {
            Name = name;
            Position = new Vector2(Random.Shared.Next(0, spaceSize), Random.Shared.Next(0, spaceSize));
        }
    }


}