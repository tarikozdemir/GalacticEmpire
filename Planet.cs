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

        public override string ToString() => $"{Name} - {Position}";

        public Planet(string name, Vector2 position)
        {
            Name = name;
            Position = position;
        }
    }
}