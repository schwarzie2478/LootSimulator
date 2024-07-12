// See https://aka.ms/new-console-template for more information
//Game Loop
public static class ArmorDictionary
{
    public static Dictionary<string,Armor> Armors { get; set; } = new Dictionary<string, Armor>();
    public static List<Range> Distribution { get; private set; } = new List<Range>();

    static ArmorDictionary()
    {
        Armors.Add("Cloth Chest",new Armor("Cloth", 1, "Chest"));
        Armors.Add("Leather Chest",new Armor("Leather", 5, "Chest"));
        Armors.Add("Chainmail Chest",new Armor("Chainmail", 10, "Chest"));
        Armors.Add("Plate Chest",new Armor("Plate", 20, "Chest"));
        Armors.Add("Cloth Head",new Armor("Cloth", 1, "Head"));
        Armors.Add("Leather Head",new Armor("Leather", 5, "Head"));
        Armors.Add("Chainmail Head",new Armor("Chainmail", 10, "Head"));
        Armors.Add("Plate Head",new Armor("Plate", 20, "Head"));
        Armors.Add("Cloth Legs",new Armor("Cloth", 1, "Legs"));
        Armors.Add("Leather Legs",new Armor("Leather", 5, "Legs"));
        Armors.Add("Chainmail Legs",new Armor("Chainmail", 10, "Legs"));
        Armors.Add("Plate Legs",new Armor("Plate", 20, "Legs"));
        Armors.Add("Cloth Feet",new Armor("Cloth", 1, "Feet"));
        Armors.Add("Leather Feet",new Armor("Leather", 5, "Feet"));
        Armors.Add("Chainmail Feet",new Armor("Chainmail", 10, "Feet"));
        Armors.Add("Plate Feet",new Armor("Plate", 20, "Feet"));
        Armors.Add("Cloth Hands",new Armor("Cloth", 1, "Hands"));
        Armors.Add("Leather Hands",new Armor("Leather", 5, "Hands"));
        Armors.Add("Chainmail Hands",new Armor("Chainmail", 10, "Hands"));
        Armors.Add("Plate Hands",new Armor("Plate", 20, "Hands"));
        Armors.Add("Cloth Arms",new Armor("Cloth", 1, "Arms"));
        Armors.Add("Leather Arms",new Armor("Leather", 5, "Arms"));
        Armors.Add("Chainmail Arms",new Armor("Chainmail", 10, "Arms"));
        Armors.Add("Plate Arms",new Armor("Plate", 20, "Arms"));
        Armors.Add("Cloth Shoulders",new Armor("Cloth", 1, "Shoulders"));
        Armors.Add("Leather Shoulders",new Armor("Leather", 5, "Shoulders"));
        Armors.Add("Chainmail Shoulders",new Armor("Chainmail", 10, "Shoulders"));
        Armors.Add("Plate Shoulders",new Armor("Plate", 20, "Shoulders"));
        Armors.Add("Cloth Waist",new Armor("Cloth", 1, "Waist"));
        Armors.Add("Leather Waist",new Armor("Leather", 5, "Waist"));
        Armors.Add("Chainmail Waist",new Armor("Chainmail", 10, "Waist"));
        Armors.Add("Plate Waist",new Armor("Plate", 20, "Waist"));
        Armors.Add("Bronze Neck",new Armor("Bronze", 1, "Neck"));
        Armors.Add("Silver Neck",new Armor("Silver", 5, "Neck"));
        Armors.Add("Gold Neck",new Armor("Gold", 10, "Neck"));
        Armors.Add("Platinum Neck",new Armor("Platinum", 20, "Neck"));
        Armors.Add("Bronze Finger",new Armor("Bronze", 1, "Finger"));
        Armors.Add("Silver Finger",new Armor("Silver", 5, "Finger"));
        Armors.Add("Gold Finger",new Armor("Gold", 10, "Finger"));
        Armors.Add("Platinum Finger",new Armor("Platinum", 20, "Finger"));        

    }
    static public Armor GenerateRandomArmor()
    {
        if(Distribution.Count == 0)
        {
            var start = 0;
            foreach(var armor in Armors)
            {
                var end = start + (20 / armor.Value.Defense);
                Distribution.Add(new Range(start, end, armor.Key));
            }
        }
        var random = new Random();
        var value = random.Next(0, Distribution.Last().End);
        return  Armors[Distribution.First(d => d.Start <= value && d.End >= value).Name];
    }
}
