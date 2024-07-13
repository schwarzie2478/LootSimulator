// See https://aka.ms/new-console-template for more information
//Game Loop
public class Loot
{
    public string Name { get; set; }
    public int Value { get; set; }
    public LootType Type { get; set; }
    public Loot(string name, int value, LootType type)
    {
        Name = name;
        Value = value;
        Type = type;
    }   
    public Loot():this("Garbage",0,LootType.Junk){}
}
public enum LootType
{
    Weapon,
    Armor,
    Consumable,
    Junk,
    Material,
    Money
}
