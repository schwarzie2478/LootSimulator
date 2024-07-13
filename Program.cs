// See https://aka.ms/new-console-template for more information

//Game Loop
World.GameLoop();

Console.WriteLine("Game Over");
//New line
Console.WriteLine("------------------");
foreach (var monster in World.Monsters)
{
    //if monster is dead, print the monster name
    if (monster.IsDead())
    {
        Console.WriteLine($"Monster {monster.Name} is dead");
    }
    else
    {
        Console.WriteLine($"Monster {monster.Name} is still alive");
    }
}
System.Console.WriteLine($"Monsters Killed: {World.Monsters.Where(m => m.IsDead()).Count()}");
//print player status
System.Console.WriteLine(World.Player.PrintStatus(true));

Console.WriteLine("Game Over");
Console.WriteLine("Press any key to exit");
Console.ReadKey();



