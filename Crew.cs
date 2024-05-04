public class Crew
{
    public string? Name { get; set; }
    public int Quantity { get; set; }

    public Crew(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}
