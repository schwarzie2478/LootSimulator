// See https://aka.ms/new-console-template for more information
//Game Loop
public class Inventory
{
    public int Gold { get; set; } = 5;
    public int HealthPotions { get; set; } = 3;
    public int ManaPotions { get; set; } = 0;
    public int Keys { get; set; } = 0;
    public Dictionary<Loot,int> Loot { get; set; }
    public Weapon LeftHand { get; set; }
    public Weapon RightHand { get; set; }
    public Armor Head { get; set; }
    public Armor Chest { get; set; }
    public Armor Legs { get; set; }
    public Armor Feet { get; set; }
    public Armor Hands { get; set; }
    public Armor Arms { get; set; }
    public Armor Shoulders { get; set; }
    public Armor Waist { get; set; }
    public Armor Neck { get; set; }
    public Armor Finger1 { get; set; }
    public Armor Finger2 { get; set; }
    
    public Inventory()
    {
        Gold = 0;
        HealthPotions = 0;
        ManaPotions = 0;
        Keys = 0;
        Loot = new Dictionary<Loot, int>();
        LeftHand = new Weapon();
        RightHand = new Weapon();
        Head = new Armor();
        Chest = new Armor();
        Legs = new Armor();
        Feet = new Armor();
        Hands = new Armor();
        Arms = new Armor();
        Shoulders = new Armor();
        Waist = new Armor();
        Neck = new Armor();
        Finger1 = new Armor();
        Finger2 = new Armor();
    }
}
