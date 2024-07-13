// See https://aka.ms/new-console-template for more information
//Game Loop
internal class Monster: Character
{

    public LootDropList LootDropList { get; private set; }
    

    public Monster(string name, int life, LootDropList lootDropList)
    {
        Name = name;
        Life = life;
        BaseDamage = Life / 5;
        Inventory = new Inventory();
        LootDropList = lootDropList;
    }   
    public Monster():this("Unknown",100,new LootDropList())
    {
    }
 }


