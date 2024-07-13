
// See https://aka.ms/new-console-template for more information
//Game Loop

internal static class MonsterDictionary
{
    internal static Dictionary<string, Monster> Monsters { get; set; }
    internal static List<Range> Distribution { get; set; } = new List<Range>();
    static MonsterDictionary() => Monsters = new Dictionary<string, Monster>
        {
            { "Slime", new Monster("Slime", 5, new LootDropList()) },
            { "Goblin", new Monster("Goblin", 10, new LootDropList()) },
            { "Orc", new Monster("Orc", 20, new LootDropList()) },
            { "Troll", new Monster("Troll", 30, new LootDropList()) },
            { "Dragon", new Monster("Dragon", 50, new LootDropList()) }
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
        var monster = new Monster(monsterTemplate.Name, monsterTemplate.Life, monsterTemplate.LootDropList);
        monster.Life += (level-1) * 10;
        monster.BaseDamage += (level-1) * monster.BaseDamage;
        //for every Level, generate a random loot
        for(int i = 0; i < level; i++)
        {
            var loot = LootDictionary.GenerateRandomLoot();
            AddInsertLoot(monster, loot);
        }
        //generate an armor and weapon and add to lootdroplist
        AddInsertLoot(monster, ArmorDictionary.GenerateRandomArmor());
        AddInsertLoot(monster, WeaponDictionary.GenerateRandomWeapon());

        //base on monster live versus player hitpoints, generate weapons and armor
        if(monster.Life > 50)
        {
            monster.Inventory.LeftHand =  new Weapon("Claws", 5,10);
        }
        else if(monster.Life > 30)
        {
            monster.Inventory.LeftHand = new Weapon("Teeth",5, 5);
        }
        else
        {
            monster.Inventory.LeftHand = new Weapon("Fists",1, 2);
        }
        if(monster.Life > 50)
        {
            monster.Inventory.AddArmor (new Armor("Scales",20, 10,"Chest"));
        }
        else if(monster.Life > 30)
        {
            monster.Inventory.AddArmor(new Armor("Hide",20,  5,"Chest"));
        }
        else
        {
            monster.Inventory.AddArmor(new Armor("Skin", 5, 2,"Chest"));
        }
        System.Console.WriteLine($"A {monster.Name} appears! ", System.ConsoleColor.Red);
        System.Console.WriteLine(monster.PrintStatus());
        return monster;
    }

    private static void AddInsertLoot(Monster monster, Loot loot)
    {
        if (monster.LootDropList.Loots.ContainsKey(loot))
        {
            monster.LootDropList.Loots[loot]++;
        }
        else
        {
            monster.LootDropList.Loots.Add(loot, 1);
        }
    }
}
