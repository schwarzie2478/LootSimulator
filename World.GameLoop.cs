
static partial class World
{
    public static void GameLoop()
    {
        Initialize();
        
        while (true)
        {
            // update
            Update();

            // draw
            Draw();

            //evaluate player health
            if (Player.Life <= 0)
            {
                Console.WriteLine("Player is dead");
                break;
            }

            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                break;
            }
            else
            {
                HandleKey(key);
            }
            
        }
    }

    private static void Initialize()
    {
        var monsters = new List<Monster>();
        World.Player.Life = PLayerStartingLife;
        World.Player.Name = "John";
        
        Console.WriteLine("Hello, Adventurer!");
        Console.WriteLine("Welcome to the game");

        Console.WriteLine("Press any key to start the game");
        Console.ReadKey();
        PrintHelp();
        Console.WriteLine("Game Started");

    }

    private static void Update()
    {
            if ((Monsters.Where(m => m.IsDead()).Count() / NextWorldLevel) >= _level)
            {
                _level++;
                Console.WriteLine($"World Level up! Now level {_level}");
            }

    }

    private static void Draw()
    {
        System.Console.WriteLine($"{World.Player.Name}({World.Player.Life} life) is fighting a {World.NextMonster().Name}({World.NextMonster().Life} life)");
        System.Console.WriteLine("------------------");
 
    }

    private static void HandleKey(ConsoleKey key)
    {
        if (key == ConsoleKey.Spacebar)
        {
            DoBattle();
        }else if (key == ConsoleKey.L)
        {
            Console.WriteLine(Player.PrintStatus(true));
        }else if (key == ConsoleKey.M)
        {
            Console.WriteLine("Monsters Killed: " + Monsters.Where(m => m.Life <= 0).Count());
        }else if (key == ConsoleKey.P)
        {
            Console.WriteLine("Player Status: " + Player.PrintStatus(true));
        }else if (key == ConsoleKey.I)
        {
            Console.WriteLine("Player Inventory: ");
            foreach (var loot in Player.Inventory.Loot)
            {
                Console.WriteLine(loot.Key.Name);
            }
        }else if ( key == ConsoleKey.Q)
        {
            Console.WriteLine("Quitting Game");
            Environment.Exit(0);
        }else if (key == ConsoleKey.H)
        {
            PrintHelp();
        }else
        {
            Console.WriteLine("Invalid Command");
            PrintHelp();
        }

    }

    private static void PrintHelp()
    {
        Console.WriteLine("Commands: ");
        Console.WriteLine("Spacebar: Attack");
        Console.WriteLine("L: Print Player Status");
        Console.WriteLine("M: Print Monsters Killed");
        Console.WriteLine("P: Print Player Status");
        Console.WriteLine("I: Print Player Inventory");
        Console.WriteLine("Q: Quit Game");
    }
}