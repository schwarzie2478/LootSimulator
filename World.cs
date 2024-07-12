// See https://aka.ms/new-console-template for more information
internal static class World
{
    private static int _level = 1;
    public static int Level
    {
        get
        {
            if ((Monsters.Where(m => m.Life <= 0).Count() / 3.0) >= _level)
            {
                _level++;
                Console.WriteLine($"World Level up! Now level {_level}");
            }
            return _level;
        }
        set
        {
            _level = value;
        }
    }

    public static Player Player { get; set; } = new Player();
    public static List<Monster> Monsters { get; set; } = new List<Monster>();


    static World()
    {
        Level = 1;
    }

    public static Monster NextMonster()
    {
        if (AllMonstersDead())
        {
            if (Monsters.Count > 0)
            {
                PickupLoot();
            }


            Monsters.Add(MonsterDictionary.GenerateRandomMonster(Level));
        }
        return Monsters.FirstOrDefault(m => m.Life > 0) ?? new Monster();
    }

    private static void PickupLoot()
    {
        System.Console.WriteLine("Picking up loot");

        //Pass all items from last monster to player
        foreach (var item in Monsters.Last().LootDropList.Loots)
        {
            for (int i = 0; i < item.Value; i++)
            {
                if (Player.Inventory.Loot.ContainsKey(item.Key))
                {
                    Player.Inventory.Loot[item.Key]++;
                }
                else
                {
                    Player.Inventory.Loot[item.Key] = 1;
                }
            }
        }
        //pass all equipped items from last monster to player
        foreach (var item in Monsters.Last().EquippedArmor)
        {
            Player.EquippedArmor.Clear();
            Player.EquippedArmor[item.Key] =  item.Value;
        }
        foreach (var item in Monsters.Last().EquippedWeapons)
        {
            Player.EquippedWeapons.Clear();
            Player.EquippedWeapons[item.Key] = item.Value;
        }
        System.Console.WriteLine(World.Player.PrintStatus());
    }

    public static bool AllMonstersDead()
    {
        return Monsters.All(m => m.Life <= 0);
    }
}


