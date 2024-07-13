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
        Inventory.AddArmor(ArmorDictionary.GenerateRandomArmor());
        Inventory.AddWeapon(WeaponDictionary.GenerateRandomWeapon(), "Right Hand");

    }
    public Player() : this("Unknown", 100) { }

}
