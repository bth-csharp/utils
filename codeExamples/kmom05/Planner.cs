namespace MyPlanner.src;

public class Planner
{
    private readonly MyTaskHandler _myTaskHandler;

    public Planner()
    {
        _myTaskHandler = new MyTaskHandler();
    }

    private static void PrintMenu()
    {
        Console.WriteLine("\nVälj mellan dessa menyalternativ:");
        Console.WriteLine("\n==================================");
        Console.WriteLine("1 - Skapa en uppgift");
        Console.WriteLine("2 - Uppdatera en uppgift");
        Console.WriteLine("3 - Ta bort en uppgift");
        Console.WriteLine("4 - Skriv ut alla uppgifter");
        Console.WriteLine("5 - Sätt en uppgift till klar");
        Console.WriteLine("e - Avsluta");
    }

    public void Run()
    {
        // Setup console
        Console.Clear();
        Console.Title = "KMOM05 MYPLANNER";

        string choice = "";

        while (choice != "e")
        {
            PrintMenu();
            Console.WriteLine($"\nDet finns {_myTaskHandler.GetNoOfTasks()} uppgifter sparade.");
            Console.WriteLine("\nDitt val: ");
            choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    HandleCreateTask();
                    break;
                case "2":
                    HandleUpdateTask();
                    break;
                case "3":
                    HandleDeleteTask();
                    break;
                case "4":
                    PrintAllTasks();
                    break;
                case "5":
                    SetTaskToCompleted();
                    break;
                case "e":
                    Console.WriteLine("\nDu har valt att avsluta! Hej då!");
                    break;
                default:
                    Console.WriteLine("\nOgiltigt menyval");
                    break;
            }
        }
    }

    private void HandleCreateTask()
    {
        Console.WriteLine("\nDu har valt menyval 1!");
    }

    private void HandleUpdateTask()
    {
        Console.WriteLine("\nDu har valt menyval 2!");
    }


    private void HandleDeleteTask()
    {
        Console.WriteLine("\nDu har valt menyval 3!");
    }

    private void PrintAllTasks()
    {
        Console.WriteLine("\nDu har valt menyval 4!");
    }

    private void SetTaskToCompleted()
    {
        Console.WriteLine("\nDu har valt menyval 5!");
    }

    public int GetNoOfTasks()
    {
        return _myTaskHandler.GetNoOfTasks();
    }
}
