namespace NnGames.PoE2.OpenDb.Models
{
    public class Currency
    {
        public string Name { get; set; } = string.Empty;
        public short StackSize { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Note { get; set; }

        public Currency(string name, short stackSize, string description, string? note = null)
        {
            Name = name;
            StackSize = stackSize;
            Description = description;
            Note = note;
        }
    }
}
