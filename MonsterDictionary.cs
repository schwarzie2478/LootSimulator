
// See https://aka.ms/new-console-template for more information
//Game Loop

internal static class MonsterDictionary
{
    internal static Dictionary<string, Monster> Monsters { get; set; }
    internal static List<Range> Distribution { get; set; } = new List<Range>();
    static MonsterDictionary() => Monsters = new Dictionary<string, Monster>
        {
            { "Slime", new Monster("Slime", 5, new LootDropList(),new Dictionary<string, Armor>(), new Dictionary<string, Weapon>()) },
            { "Goblin", new Monster("Goblin", 10, new LootDropList(),new Dictionary<string, Armor>(), new Dictionary<string, Weapon>()) },
            { "Orc", new Monster("Orc", 20, new LootDropList(),new Dictionary<string, Armor>(), new Dictionary<string, Weapon>()) },
            { "Troll", new Monster("Troll", 30, new LootDropList(),new Dictionary<string, Armor>(), new Dictionary<string, Weapon>()) },
            { "Dragon", new Monster("Dragon", 50, new LootDropList(),new Dictionary<string, Armor>(), new Dictionary<string, Weapon>()) }
        };
    public static Monster GenerateRandomMonster(int level)
    {
        if(Distribution.Count == 0)
        {
            var start = 0;
            foreach(var monst in Monsters)
            {
                var end = start + (100 / monst.Value.Life);
                Distribution.Add( new Range(start, end, monst.Key));
                start = end;
            }
        }   
        var random = new Random();
        var value = random.Next(0,Distribution.Last().End);
        var monsterTemplate = Monsters[Distribution.First(d => d.Start <= value && d.End >= value).Name];
        var monster = new Monster(monsterTemplate.Name, monsterTemplate.Life, monsterTemplate.LootDropList, monsterTemplate.EquippedArmor, monsterTemplate.EquippedWeapons);
        monster.Life += (level-1) * 10;
        //for every Level, generate a random loot
        for(int i = 0; i < level; i++)
        {
            var loot = LootDictionary.GenerateRandomLoot();
            if(monster.LootDropList.Loots.ContainsKey(loot))
            {
                monster.LootDropList.Loots[loot]++;
            }
            else
            {
                monster.LootDropList.Loots.Add(loot, 1);
            }
        }
        //base on monster live versus player hitpoints, generate weapons and armor
        if(monster.Life > 50)
        {
            monster.EquippedWeapons["Claws"] =  new Weapon("Claws", 10);
        }
        else if(monster.Life > 30)
        {
            monster.EquippedWeapons["Teeth"] = new Weapon("Teeth", 5);
        }
        else
        {
            monster.EquippedWeapons["Fists"] = new Weapon("Fists", 2);
        }
        if(monster.Life > 50)
        {
            monster.EquippedArmor["Scales"] = new Armor("Scales", 10,"Chest");
        }
        else if(monster.Life > 30)
        {
            monster.EquippedArmor["Hide"] =  new Armor("Hide", 5,"Chest");
        }
        else
        {
            monster.EquippedArmor["Skin"] = new Armor("Skin", 2,"Chest");
        }
        System.Console.WriteLine($"A {monster.Name} appears! ");
        System.Console.WriteLine(monster.PrintStatus());
        return monster;
    }
}
