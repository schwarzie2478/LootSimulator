// See https://aka.ms/new-console-template for more information
//Game Loop
internal static class LootDictionary
{
    public static Dictionary<string, Loot> Loots { get; set; } = new Dictionary<string, Loot>();
    public static List<Range> Distribution { get; private set; } = new List<Range>();

    static LootDictionary()
    {
        Loots.Add("Gold", new Loot("Gold", 1000, LootType.Money));
        Loots.Add("Silver", new Loot("Silver", 100, LootType.Money));    
        Loots.Add("Bronze", new Loot("Bronze", 10, LootType.Money));
        Loots.Add("Copper", new Loot("Copper", 10, LootType.Money));
        Loots.Add("Iron", new Loot("Iron", 5, LootType.Material));
        Loots.Add("Steel", new Loot("Steel", 20, LootType.Material));
        Loots.Add("Wood", new Loot("Wood", 3, LootType.Material));
        Loots.Add("Stone", new Loot("Stone", 2, LootType.Material));
        Loots.Add("Bone", new Loot("Bone", 3, LootType.Material));
        Loots.Add("Leather", new Loot("Leather", 3, LootType.Material));
        Loots.Add("Cloth", new Loot("Cloth", 1, LootType.Material));
        Loots.Add("Rock", new Loot("Rock", 1, LootType.Material));
        Loots.Add("Twig", new Loot("Twig", 1, LootType.Material));
        Loots.Add("Pebble", new Loot("Pebble", 1,   LootType.Material));
        Loots.Add("Health Potion", new Loot("Health Potion", 10, LootType.Consumable));
        Loots.Add("Mana Potion", new Loot("Mana Potion", 20, LootType.Consumable));
        Loots.Add("Herb", new Loot("Herb", 2, LootType.Consumable));
        Loots.Add("Root", new Loot("Root", 2, LootType.Material));
        Loots.Add("Mushroom", new Loot("Mushroom", 2, LootType.Consumable));
        Loots.Add("Berry", new Loot("Berry", 1, LootType.Consumable));
        Loots.Add("Seed", new Loot("Seed", 1, LootType.Material));
        Loots.Add("Nut", new Loot("Nut", 2  , LootType.Consumable));
        Loots.Add("Fruit", new Loot("Fruit", 3  , LootType.Consumable));
        Loots.Add("Vegetable", new Loot("Vegetable", 3  , LootType.Consumable));
        Loots.Add("Grain", new Loot("Grain", 3  , LootType.Material));
        Loots.Add("Meat", new Loot("Meat", 5, LootType.Consumable));
        Loots.Add("Fish", new Loot("Fish", 3, LootType.Consumable));
        Loots.Add("Egg", new Loot("Egg", 3, LootType.Consumable));
        Loots.Add("Dairy", new Loot("Dairy", 3, LootType.Consumable));
        Loots.Add("Oil", new Loot("Oil", 10, LootType.Material));
        Loots.Add("Salt", new Loot("Salt", 2, LootType.Material));
        Loots.Add("Sugar", new Loot("Sugar", 4, LootType.Material));
        Loots.Add("Spice", new Loot("Spice", 10, LootType.Material));
        //Add Dictornary of weapons to dictionary of loot with type loot
        foreach(var weapon in WeaponDictionary.Weapons)
        {
            Loots.Add(weapon.Key, weapon.Value);
        }
        //Add Dictornary of armor to dictionary of loot with type loot
        foreach(var armor in ArmorDictionary.Armors)
        {
            Loots.Add(armor.Key, armor.Value);
        }
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