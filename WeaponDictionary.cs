// See https://aka.ms/new-console-template for more information
//Game Loop
//WeaponDictionary
internal static class WeaponDictionary
{
    public static Dictionary<string, Weapon> Weapons { get; set; } = new Dictionary<string, Weapon>();
    public static List<Range> Distribution { get; set; } = new List<Range>();
    static WeaponDictionary()
    {
        Weapons.Add("Stick", new Weapon("Stick", 1));
        Weapons.Add("Sword", new Weapon("Sword", 5));
        Weapons.Add("Axe", new Weapon("Axe", 10));
        Weapons.Add("Mace", new Weapon("Mace", 15));
        Weapons.Add("Spear", new Weapon("Spear", 20));
    }
    public static Weapon GenerateRandomWeapon()
    {
        if(Distribution.Count == 0)
        {
                        var start = 0;
            foreach(var weapon in Weapons)
            {
                var end = start + (100 / weapon.Value.Damage);
                Distribution.Add(new Range(start, end, weapon.Key));
                start = end;

            }
        }
        var random = new Random();
        var value = random.Next(0, Distribution.Last().End);
        return Weapons[Distribution.First(d => d.Start <= value && d.End >= value).Name];
        
    }
}

