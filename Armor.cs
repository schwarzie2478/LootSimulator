// See https://aka.ms/new-console-template for more information
//Game Loop
public class Armor
{
    public string Name { get; set; }
    public int Defense { get; set; }
    public string BodyPart { get; set; }
    public Armor(string name, int defense, string bodyPart)
    {
        Name = name;
        Defense = defense;
        BodyPart = bodyPart;
    }
    public Armor():this("Cloth",1,"Chest"){}
}
