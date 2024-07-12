// See https://aka.ms/new-console-template for more information
//Game Loop
public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
    public Weapon():this("Stick",1){}
}

