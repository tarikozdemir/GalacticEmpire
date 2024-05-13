using Galaxy;

public class Cell
{
    public Player? Player { get; set; }
    public Planet? Planet { get; set; }
    public bool IsEmpty => Player == null && Planet == null;
    public char DisplayChar
    {
        get
        {
            if (Player != null) return 'P';
            if (Planet != null) return '@';
            return '.';
        }
    }
    public ConsoleColor Color
    {
        get
        {
            if (Player != null) return Player.Color;
            if (Planet != null) return Planet.Color;
            return ConsoleColor.White;
        }
    }
}