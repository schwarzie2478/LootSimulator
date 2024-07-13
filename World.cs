// See https://aka.ms/new-console-template for more information
internal static partial class World
{
    private static int _level = WorldStartLevel;
    public static int Level
    {
        get
        {
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
            //if money type add to player money
            if (item.Key.Type == LootType.Money)
            {
                //Repeat item.Value times
                for (int i = 0; i < item.Value; i++)
                {
                    Player.Inventory.AddMoney(item.Key);
                }

                continue;
            }
            //Auto equip armor and weapon
            if (item.Key is Armor armor)
            {
                Player.Inventory.AddArmor(armor);
                continue;
            }
            if (item.Key is Weapon weapon)
            {
                Player.Inventory.AddWeapon(weapon, "RightHand");
                continue;
            }
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
            Player.EquippedArmor[item.Key] = item.Value;
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
    public static void DoBattle()
    {
        var playerDamage = World.Player.TotalDamage - World.NextMonster().ArmorValue;
        var monsterDamage = World.NextMonster().TotalDamage - World.Player.ArmorValue;
        World.NextMonster().Life -= playerDamage > 0 ? playerDamage : 1;
        World.Player.Life -= monsterDamage > 0 ? monsterDamage : 1;

    }
}



