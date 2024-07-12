// See https://aka.ms/new-console-template for more information
//Game Loop
internal static class LootDictionary
{
    public static Dictionary<string, Loot> Loots { get; set; } = new Dictionary<string, Loot>();
    public static List<Range> Distribution { get; private set; } = new List<Range>();

    static LootDictionary()
    {
        Loots.Add("Gold", new Loot("Gold", 1000));
        Loots.Add("Silver", new Loot("Silver", 100));    
        Loots.Add("Bronze", new Loot("Bronze", 10));
        Loots.Add("Copper", new Loot("Copper", 10));
        Loots.Add("Iron", new Loot("Iron", 5));
        Loots.Add("Steel", new Loot("Steel", 20));
        Loots.Add("Wood", new Loot("Wood", 3));
        Loots.Add("Stone", new Loot("Stone", 2));
        Loots.Add("Bone", new Loot("Bone", 3));
        Loots.Add("Leather", new Loot("Leather", 3));
        Loots.Add("Cloth", new Loot("Cloth", 1));
        Loots.Add("Stick", new Loot("Stick", 1));
        Loots.Add("Rock", new Loot("Rock", 1));
        Loots.Add("Twig", new Loot("Twig", 1));
        Loots.Add("Pebble", new Loot("Pebble", 1));
        Loots.Add("Health Potion", new Loot("Health Potion", 10));
        Loots.Add("Mana Potion", new Loot("Mana Potion", 20));
        Loots.Add("Herb", new Loot("Herb", 2));
        Loots.Add("Root", new Loot("Root", 2));
        Loots.Add("Mushroom", new Loot("Mushroom", 2));
        Loots.Add("Berry", new Loot("Berry", 1));
        Loots.Add("Seed", new Loot("Seed", 1));
        Loots.Add("Nut", new Loot("Nut", 2));
        Loots.Add("Fruit", new Loot("Fruit", 3));
        Loots.Add("Vegetable", new Loot("Vegetable", 3));
        Loots.Add("Grain", new Loot("Grain", 3));
        Loots.Add("Meat", new Loot("Meat", 5));
        Loots.Add("Fish", new Loot("Fish", 3));
        Loots.Add("Egg", new Loot("Egg", 3));
        Loots.Add("Dairy", new Loot("Dairy", 3));
        Loots.Add("Oil", new Loot("Oil", 10));
        Loots.Add("Salt", new Loot("Salt", 2));
        Loots.Add("Sugar", new Loot("Sugar", 4));
        Loots.Add("Spice", new Loot("Spice", 10));
        
    }
    public static Loot GenerateRandomLoot()
    {
        if( Distribution.Count == 0)
        {
            Distribution = new List<Range>();
            var start = 0;
            foreach(var loot in Loots)
            {
                var end = start + (1000 / loot.Value.Value) + 3; // make rare items more common
                Distribution.Add( new Range(start, end, loot.Key));
                start = end;
            }
        }

        var random = new Random();
        var value = random.Next(0,Distribution.Last().End);
        return Loots[Distribution.First(d => d.Start <= value && d.End  >= value).Name];

    }
}