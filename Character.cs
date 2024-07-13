// See https://aka.ms/new-console-template for more information
//Game Loop
internal class Character
{
    public int Life { get; set; }
    public string Name { get; set; }
        public int Level { get; set; } = 1;
    public int Experience { get; set; } = 1;

    public Inventory Inventory { get; set; } = new Inventory();
    public int BaseDamage { get; set; } = 1;
    public Dictionary<string, Armor> EquippedArmor { get; set; } = new Dictionary<string, Armor>();
    public Dictionary<string, Weapon> EquippedWeapons { get; set; } = new Dictionary<string, Weapon>();
    public int ArmorValue
    {
        get
        {
            //for all properties of inventory, if the type is armor,  sum it's defense
            return Inventory.GetType().GetProperties().Where(p => p.PropertyType == typeof(Armor)).Sum(p => ((Armor?)p.GetValue(Inventory))?.Defense ?? 0);

        }
    }
    public int WeaponValue
    {
        get
        {
            //for all properties of inventory, if the type is weapon,  sum it's damage
            return Inventory.GetType().GetProperties().Where(p => p.PropertyType == typeof(Weapon)).Sum(p => ((Weapon?)p.GetValue(Inventory))?.Damage ?? 0);

        }
    }
    public int TotalDamage
    {
        get
        {
            return BaseDamage + WeaponValue;
        }
    }
    public int TotalLootValue
    {
        get
        {
            return Inventory.Loot.Sum(l => l.Key.Value * l.Value);
        }
    }   
    public Character()
    {
        Name = "Unknown";
        Life = 100;
    }
    public virtual string PrintStatus(bool bDetailed = false)
    {
        var str = new System.Text.StringBuilder();
        str.AppendLine($"{Name} has {Life} life and has base damage of {BaseDamage}.");
        //Print all items in inventory
        if (bDetailed)
        {
            str.AppendLine("Inventory:");
            str.AppendLine("----------");
            foreach (var item in Inventory.Loot)
            {
                str.AppendLine($"{item.Value} {item.Key.Name}, Value: {item.Key.Value}");
            }
            str.AppendLine("----------");

        }
        //Print total loot value
        str.AppendLine($"Total Loot Value: {TotalLootValue}");
        
        if(bDetailed)
        {
            str.AppendLine("Armor:");
            str.AppendLine("----------");

            //foreach property of inventory, if it's type is armor, print it's name and defense
            foreach (var property in Inventory.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(Armor))
                {
                    var armor = (Armor?)property.GetValue(Inventory);
                    str.AppendLine($"{property.Name}:{armor?.Name} - {armor?.Defense} points of defense");
                }
            }
            str.AppendLine("----------");
            str.AppendLine("Weapons:");
            str.AppendLine("----------");

            //foreach property of inventory, if it's type is weapon, print it's name and damage
            foreach (var property in Inventory.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(Weapon))
                {
                    var weapon = (Weapon?)property.GetValue(Inventory);
                    str.AppendLine($" {property.Name}:{weapon?.Name} - {weapon?.Damage} points of damage");
                }
            }
            str.AppendLine("----------");
            

        }

        str.AppendLine($"Total Armor Value: {ArmorValue}");
        str.AppendLine($"Total Weapon Value: {WeaponValue}");
        str.AppendLine($"Total Damage: {TotalDamage}");
        
        return str.ToString();


    }   

    public bool IsDead()
    {
        return Life <= 0;
    }
}