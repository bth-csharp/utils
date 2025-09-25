namespace Dice100.src;

class Menu
{
    private Game _die100Game;

    public Menu()
    {
        _die100Game = new Game();
        InitGame();
    }

    // Methods
    private static void PrintMenu()
    {
        Console.WriteLine("\nVälkommen till Dice100!\n");
        Helpers.PrintDateAndTimeNow();
        Console.WriteLine("\nr/roll. Slå och summera");
        Console.WriteLine("s/save. Spara poäng och avsluta rundan");
        Console.WriteLine("igen. Nollställ och börja om");
        Console.WriteLine("regler. Skriver ut reglerna");
        Console.WriteLine("t/topplista. Skriver ut topplistan");
        Console.WriteLine("m/menu. Skriver ut denna meny");
        Console.WriteLine("e. Avsluta");
    }

    public void Run()
    {
        // Setup
        Helpers.GetTerminalReady("DICE100");
        string choice = "";

        PrintMenu();
        while (choice != "e")
        {
            Console.WriteLine("\nDitt val (r/s/t/m eller e): ");
            choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "r":
                case "roll":
                    _die100Game.Roll();
                    break;
                case "s":
                case "save":
                    _die100Game.Stop();
                    break;
                case "igen":
                    _die100Game.Reset();
                    break;
                case "regler":
                    Game.PrintRules();
                    break;
                case "m":
                case "menu":
                    PrintMenu();
                    break;
                case "t":
                case "topplista":
                    Game.PrintTopList();
                    break;
                case "e":
                    Console.WriteLine("\nDu har valt att avsluta! Hej då!");
                    break;
                default:
                    Console.WriteLine("Ogiltligt menyval");
                    break;
            }
        }
    }

    private void InitGame()
    {
        int noOfDice = 1;
        bool okNoOfDice = false;
        string name = "";

        Console.WriteLine("\nVälkommen till Dice100!");
        name = Helpers.ReadStringFromTerminal("Ange ditt namn:");

        while (!okNoOfDice)
        {
            try
            {
                noOfDice = Helpers.ReadIntFromTerminal("Ange antalet tärningar du vill spela med:");
                _die100Game = new Game(noOfDice, name);
                okNoOfDice = true;
            }
            catch (NumberOfDieException ex)
            {
                Console.WriteLine($"\nEtt fel inträffade: {ex.Message}");
            }
        }
    }
}