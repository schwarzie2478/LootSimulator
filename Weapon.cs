// See https://aka.ms/new-console-template for more information
//Game Loop
public class Weapon: Loot
{
    public int Damage { get; set; }
    public Weapon(string name, int value,int damage):base(name,value,LootType.Weapon)
    {
        Damage = damage;
    }


    public Weapon():this("None",0,0){}
}

