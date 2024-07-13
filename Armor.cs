// See https://aka.ms/new-console-template for more information
//Game Loop
public class Armor: Loot
{
    public int Defense { get; set; }
    public string BodyPart { get; set; }
    public Armor(string name,int value, int defense, string bodyPart):base(name,value,LootType.Armor)
    {
        Defense = defense;
        BodyPart = bodyPart;
    }
    public Armor():this("Naked",0,0,"Chest"){}
}
