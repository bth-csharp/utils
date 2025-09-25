namespace Dice100Extra.src;

class Menu
{
    private readonly Game _die100Game;
    private bool _gameOver;

    public Menu()
    {
        int noOfPlayers;

        Console.WriteLine("\nVälkommen till Dice100!");
        noOfPlayers = Helpers.ReadIntFromTerminal("Ange antalet spelare:");
        _die100Game = new Game(noOfPlayers);
        _gameOver = false;
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
            if (_gameOver)
            {
                Console.WriteLine("\nSPELET ÄR SLUT!");
                _gameOver = false;
                _die100Game.Reset();
                Console.WriteLine("\nTryck enter för att fortsätta (enter): ");
                choice = Console.ReadLine() ?? "";
                PrintMenu();
                choice = "";
            }
            else
            {
                _die100Game.PrintActualPlayer();
                Console.WriteLine("\nDitt val (r/s/m eller e): ");
                choice = Console.ReadLine() ?? "";
            }

            switch (choice)
            {
                case "r":
                case "roll":
                    _die100Game.Roll();
                    break;
                case "s":
                case "save":
                    _gameOver = _die100Game.Stop();
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
                case "e":
                    Console.WriteLine("\nDu har valt att avsluta! Hej då!");
                    break;
                default:
                    Console.WriteLine("Ogiltligt menyval");
                    break;
            }
        }
    }
}