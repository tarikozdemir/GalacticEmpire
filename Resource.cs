namespace Galaxy
{
    public class Resource
    {
        public ResourceType Type { get; set; } // enum ve magic string'i GPT'ye sor.
        public string? Description { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }
    }

    public enum ResourceType 
    {
        None,
        Iron,
        Gold,
        Stone
    }
}