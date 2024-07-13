// See https://aka.ms/new-console-template for more information
//Game Loop

public class Inventory
{
    public int Money { get; set; } = 5;
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
        Money = 0;
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
    public void AddArmor(Armor armor)
    {
        //with reflection determine the body part and set the armor to the correct property
        System.Reflection.PropertyInfo[] properties = typeof(Inventory).GetProperties();
        foreach (System.Reflection.PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(Armor) && property.Name == armor.BodyPart)
            {
                var value = property.GetValue(this);
                if(value == null)
                {
                    System.Console.WriteLine($"Equipped {armor.Name} on {armor.BodyPart}");
                    property.SetValue(this, armor);
                    return;
                }
                //if defense is higher than the current armor, replace it
                if ( ((Armor)value).Defense < armor.Defense)
                {
                    System.Console.WriteLine($"Replaced {((Armor)value).Name} with {armor.Name} on {armor.BodyPart}");
                    property.SetValue(this, armor);
                }else
                {
                    if (Loot.ContainsKey((Armor)value))
                    {
                        Loot[(Armor)value]++;
                    }
                    else
                    {
                        Loot[(Armor)value] = 1;
                    }
                }
                return;
            }
        }
    }
    public void AddWeapon(Weapon weapon, string v)
    {

        var hands = new Tuple<string,Weapon>[] {Tuple.Create("LeftHand",LeftHand),Tuple.Create("RightHand",RightHand)};
        foreach (var hand in hands)
        {
            if(v == hand.Item1)
            {
                if(hand.Item2.Damage < weapon.Damage)
                {
                    System.Console.WriteLine($"Equipped {weapon.Name} in {v}");
                    typeof(Inventory).GetProperty(v)?.SetValue(this, weapon);
                }else
                {
                    if (Loot.ContainsKey(weapon))
                    {
                        Loot[weapon]++;
                    }
                    else
                    {
                        Loot[weapon] = 1;
                    }
                }
            }
 
        }
        
    }

    public void AddMoney(Loot loot)
    {
        System.Console.WriteLine($"Picked up {loot.Value} money from {loot.Name}");
        Money += loot.Value;
    }
}
