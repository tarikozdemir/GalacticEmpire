using System.Numerics;

public class Player
{
    public string Name { get; }
    public int Health { get; private set; }
    public int Gold { get; private set; }
    public Vector2 Position { get; private set; }
    public bool IsAlive => Health > 0;
    public ConsoleColor Color { get; }  // Color property


    public Player(string name, int health, int gold, ConsoleColor color)
    {
        Name = name;
        Health = health;
        Gold = gold;
        Color = color;  // Set the player's color
        // Move();
    }

    // public void Move()
    // {
    //     Position = new Vector2(Random.Shared.Next(0, 6), Random.Shared.Next(0, 6));
    // }
}