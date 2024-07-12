// See https://aka.ms/new-console-template for more information
//Game Loop
public class Loot
{
    public string Name { get; set; }
    public int Value { get; set; }
    public Loot(string name, int value)
    {
        Name = name;
        Value = value;
    }
    public Loot():this("Garbage",0){}
}
