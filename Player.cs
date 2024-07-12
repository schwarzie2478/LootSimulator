// See https://aka.ms/new-console-template for more information
//Game Loop
internal class Player : Character
{



    public Player(string name, int life)
    {
        Name = name;
        Life = life;
        BaseDamage = 5;
        Level = 1;
        Experience = 0;
        var weapon = WeaponDictionary.GenerateRandomWeapon();
        var armor = ArmorDictionary.GenerateRandomArmor();
        EquippedWeapons.Add(weapon.Name, weapon);
        EquippedArmor.Add(armor.Name, armor);
    }
    public Player() : this("Unknown", 100) { }

}
