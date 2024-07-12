// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Adventurer!");
Console.WriteLine("Welcome to the game");
Console.WriteLine("Press any key to start the game");
Console.ReadKey();

var monsters = new List<Monster>();
World.Player.Life = 100;
World.Player.Name = "John";
Console.WriteLine(World.Player.PrintStatus());

Console.WriteLine("Press any key to hit the monsters");
//Game Loop
while (World.Player.Life > 0)
{
    System.Console.WriteLine($"Player {World.Player.Name} is fighting a monster {World.NextMonster().Name}");

    Console.ReadKey();
    World.NextMonster().Life -= World.Player.TotalDamage - World.NextMonster().ArmorValue;
    World.Player.Life -= World.NextMonster().TotalDamage - World.Player.ArmorValue;
    Console.WriteLine($"Player {World.Player.Name} has {World.Player.Life} life points");
    Console.WriteLine($"Monster {World.NextMonster().Name} has {World.NextMonster().Life} life points");

}
Console.WriteLine("Game Over");
//New line
Console.WriteLine("------------------");
foreach (var monster in World.Monsters)
{
    //if monster is dead, print the monster name
    if (monster.Life <= 0)
    {
        Console.WriteLine($"Monster {monster.Name} is dead");
    }
    else
    {
        Console.WriteLine($"Monster {monster.Name} is still alive");
    }
}
System.Console.WriteLine($"Monsters Killed: {World.Monsters.Where(m => m.Life <= 0).Count()}");
//print player status
System.Console.WriteLine(World.Player.PrintStatus());

Console.WriteLine("Game Over");
Console.WriteLine("Press any key to exit");
Console.ReadKey();



