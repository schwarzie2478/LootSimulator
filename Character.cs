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
            return EquippedArmor.Values.Sum(a => a.Defense);
        }
    }
    public int WeaponValue
    {
        get
        {
            return EquippedWeapons.Values.Sum(w => w.Damage);
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
    public virtual string PrintStatus()
    {
        var str = new System.Text.StringBuilder();
        str.AppendLine($"{Name} has {Life} life and has base damage of {BaseDamage}.");
        //Print all items in inventory
        foreach (var item in Inventory.Loot)
        {
            str.AppendLine($"{item.Value} {item.Key.Name}, Value: {item.Key.Value}");
        }
        //Print total loot value
        str.AppendLine($"Total Loot Value: {TotalLootValue}");
        


        foreach (var armor in EquippedArmor)
        {
            str.AppendLine($"Armor: {armor.Value.Name} - {armor.Value.Defense} points of defense on {armor.Key}");
        }
        foreach (var weapon in EquippedWeapons)
        {
            str.AppendLine($"Weapon: {weapon.Value.Name} - {weapon.Value.Damage} points of damage");
        }

        str.AppendLine($"Total Armor Value: {ArmorValue}");
        str.AppendLine($"Total Weapon Value: {WeaponValue}");
        str.AppendLine($"Total Damage: {TotalDamage}");
        
        return str.ToString();


    }   

}