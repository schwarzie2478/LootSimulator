// See https://aka.ms/new-console-template for more information
//Game Loop
internal class Monster: Character
{

    public LootDropList LootDropList { get; private set; }
    

    public Monster(string name, int life, LootDropList lootDropList, Dictionary<string, Armor> equippedArmor, Dictionary<string, Weapon> equippedWeapons)
    {
        Name = name;
        Life = life;
        BaseDamage = Life / 5;
        EquippedArmor = equippedArmor;
        EquippedWeapons = equippedWeapons;
        LootDropList = lootDropList;
    }   
    public Monster():this("Unknown",100,new LootDropList(),new Dictionary<string, Armor>(),new Dictionary<string, Weapon>()){}
 }


