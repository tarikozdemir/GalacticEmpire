using System.Numerics;
using Galaxy;

public class Player
{
    public string Name { get; }
    public int Health { get; set; }
    public int Gold { get; set; } = 1000;
    public Vector2 Position { get; private set; }
    public bool IsAlive => Health > 0;
    public ConsoleColor Color { get; }  // Color property
    public List<Fleet> Fleets { get; internal set; } = new List<Fleet>();
    public List<SpaceShip> Spaceships { get; internal set; } = new List<SpaceShip>();

    public Player(string name, int health, ConsoleColor color)
    {
        Name = name;
        Health = health;
        Color = color;  // Set the player's color
        // Move();
    }

    // public void Move()
    // {
    //     Position = new Vector2(Random.Shared.Next(0, 6), Random.Shared.Next(0, 6));
    // }
}