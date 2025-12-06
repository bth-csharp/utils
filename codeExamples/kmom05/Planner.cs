namespace MyPlanner.src;

public class Planner
{
    private MyTaskHandler _myTaskHandler;

    public Planner()
    {
        this._myTaskHandler = new MyTaskHandler();
    }

    private static void PrintMenu()
    {
        Console.WriteLine("\nVälj mellan dessa menyalternativ:");
        Console.WriteLine("==================================");
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
            Console.WriteLine($"\nDet finns {this._myTaskHandler.GetNoOfTasks()} uppgifter sparade.");
            choice = ReadStringFromTerminal("\nDitt val: ");

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
        string type = ReadStringFromTerminal("Vilken typ av uppgift? (Privat=p och Arbete=a):");
        if (type.ToLower().Equals("a"))
        {
            CreateWorkTask();
        }
        else if (type.ToLower().Equals("p"))
        {
            CreatePrivateTask();
        }
        else
        {
            Console.WriteLine("Prova igen! Välj typ av uppgift? (Privat=p och Arbete=a)");
            HandleCreateTask();
        }
    }

    private void CreatePrivateTask()
    {
        DateTime dateTime = DateTime.Today;
        string title = ReadStringFromTerminal("Namn på uppgiften du vill skapa: ");
        string description = ReadStringFromTerminal("Beskrivning av uppgiften: ");
        string dueDate = ReadStringFromTerminal("Datum uppgiften ska vara klar (YYYY-MM-DD), enter (return) om dagens datum: ");
        if (dueDate != "")
        {
            string[] dateParts;
            dateParts = dueDate.Split('-'); // Year-dateParts[0], month-dateParts[1], day-dateParts[2]
            dateTime = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        }
        string location = ReadStringFromTerminal("Var ska uppgiften utföras: ");
        this._myTaskHandler.CreateTask(location, title, description, dateTime);
        Console.WriteLine($"\nUppgiften {title} är skapad!");
    }

    private void CreateWorkTask()
    {
        DateTime dateTime = DateTime.Today;
        string title = ReadStringFromTerminal("Namn på uppgiften du vill skapa: ");
        string description = ReadStringFromTerminal("Beskrivning av uppgiften: ");
        string dueDate = ReadStringFromTerminal("Datum uppgiften ska vara klar (YYYY-MM-DD), enter (return) om dagens datum: ");
        if (dueDate != "")
        {
            string[] dateParts;
            dateParts = dueDate.Split('-'); // Year-dateParts[0], month-dateParts[1], day-dateParts[2]
            dateTime = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        }
        int estimatedTime = ReadIntFromTerminal("Vilken är beräknad tid för uppgiften? ", "1");
        this._myTaskHandler.CreateTask(0, estimatedTime, title, description, dateTime);
        Console.WriteLine($"\nUppgiften {title} är skapad!");
    }

    private void HandleUpdateTask()
    {
        string title = ReadStringFromTerminal("Namn på uppgiften du vill uppdatera: ");
        List<string> info = this._myTaskHandler.GetTaskContent(title);
        int noOfEntries = info.Count;
        bool updateOk = false;

        if (noOfEntries == 0)
        {
            Console.WriteLine($"\nUppgiften {title} hittades inte. Inget är uppdaterat!");
        }
        else
        {
            if (info.Count == 5) { updateOk = UpdatePrivateTask(info); }
            if (info.Count == 6) { updateOk = UpdateWorkTask(info); }
            if (updateOk)
            {
                Console.WriteLine("\nFöljande uppgift är nu uppdaterad:");
                Console.WriteLine(this._myTaskHandler.GetDescription(title));
            }
            else
            {
                Console.WriteLine($"\nUppgiften {title} uppdaterades inte pga felaktig input!");
            }
        }
    }

    private bool UpdatePrivateTask(List<string> info)
    // info strings PrivateTask: title, description, dueDate, completed, location
    {
        string title = info[0];
        string[] sameDateParts = info[2].Split('-');
        DateTime newDate = new DateTime(int.Parse(sameDateParts[0]), int.Parse(sameDateParts[1]), int.Parse(sameDateParts[2]));

        Console.WriteLine($"\nUppgiften {title} hittades, befintlig information inom parentes.");
        Console.WriteLine("\nKlicka bara på enter (return) om inget ska ändras.");
        string description = ReadStringFromTerminal($"Beskrivning av uppgiften ({info[1]}): ", info[1]);
        string dueDate = ReadStringFromTerminal($"Datum uppgiften ska vara klar (YYYY-MM-DD) ({info[2]}): ", info[2]);
        if (dueDate != "")
        {
            string[] dateParts = dueDate.Split('-');
            newDate = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        }
        string location = ReadStringFromTerminal($"Var ska uppgiften utföras ({info[4]}): ", info[4]);
        string ready = (info[3].ToLower() == "true") ? "Ja" : "Nej";
        string completedStr = ReadStringFromTerminal($"Är uppgiften är klar (Ja/Nej) ({ready}): ", ready);
        bool completed = (completedStr.ToLower() == "ja") ? true : false;
        Console.WriteLine($"I Planner: {title}, {description}, {newDate.ToString("yyyy-MM-dd")}, {location}, {completed.ToString()}");

        return this._myTaskHandler.UpdateTask(location, title, description, newDate, completed);
    }

    private bool UpdateWorkTask(List<string> info)
    // info strings PrivateTask: title, description, dueDate, completed, workedTime, estimatedTime
    {
        string title = info[0];
        string[] sameDateParts = info[2].Split('-');
        DateTime newDate = new DateTime(int.Parse(sameDateParts[0]), int.Parse(sameDateParts[1]), int.Parse(sameDateParts[2]));

        Console.WriteLine($"\nUppgiften {title} hittades, befintlig information inom parentes.");
        Console.WriteLine("\nKlicka bara på enter (return) om inget ska ändras.");
        string description = ReadStringFromTerminal($"Beskrivning av uppgiften ({info[1]}): ", info[1]);
        string dueDate = ReadStringFromTerminal($"Datum uppgiften ska vara klar (YYYY-MM-DD) ({info[2]}): ", info[2]);
        if (dueDate != "")
        {
            string[] dateParts = dueDate.Split('-');
            newDate = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        }
        int estimatedTime = ReadIntFromTerminal($"Vilken är beräknad tid för uppgiften ({info[5]}): ", info[5]);
        int timeWorked = ReadIntFromTerminal($"Hur många timmar har arbetats på uppgiften ({info[4]}): ", info[4]);
        string ready = (info[3].ToLower() == "true") ? "Ja" : "Nej";
        string completedStr = ReadStringFromTerminal($"Är uppgiften är klar (Ja/Nej) ({ready}): ", ready);
        bool completed = (completedStr.ToLower() == "ja") ? true : false;

        return this._myTaskHandler.UpdateTask(estimatedTime, timeWorked, title, description, newDate, completed);
    }

    private void HandleDeleteTask()
    {
        bool deleteOk = false;
        string title = ReadStringFromTerminal("Namn på uppgiften du vill ta bort: ");
        string message = $"\nUppgiften {title} hittades inte. Ingen uppgift är borttagen!";

        deleteOk = this._myTaskHandler.DeleteTask(title);
        if (deleteOk)
        {
            message = $"\nUppgiften {title} är nu borttagen.";
        }
        Console.WriteLine(message);
    }

    private void SetTaskToCompleted()
    {
        string title = ReadStringFromTerminal("Namn på uppgiften du vill sätta till avklarad: ");

        string message = this._myTaskHandler.CompleteTask(title);
        if (message == "")
        {
            Console.WriteLine("\nFöljande uppgift är nu avklarad:");
            Console.WriteLine(this._myTaskHandler.GetDescription(title));
        }
        else
        {
            Console.WriteLine(message);
        }
    }

    private void PrintAllTasks()
    {
        int nrOfTAsks = this._myTaskHandler.GetNoOfTasks();
        if (nrOfTAsks == 0)
        {
            Console.WriteLine("\nDet finns inga uppgifter!");
        }
        else
        {
            Console.WriteLine("\nAlla uppgifter:");
            Console.WriteLine("===============================");
            for (int i = 0; i < nrOfTAsks; i++)
            {
                Console.WriteLine(this._myTaskHandler.GetDescription(i));
            }
        }
    }

    private static int ReadIntFromTerminal(string info, string defaultValue = "0")
    // Om tom input, så används defaultValue istället (används vid Update)
    {
        Console.Write(info);
        string input = Console.ReadLine() ?? defaultValue;
        if (!int.TryParse(input, out int number))
        {
            number = int.Parse(defaultValue);
        }

        return number;
    }

    private static string ReadStringFromTerminal(string info, string defaultValue = "")
    // Om tom input, så används defaultValue istället (används vid Update)
    {
        Console.Write(info);
        string input = Console.ReadLine() ?? defaultValue;
        if (input == "")
        {
            input = defaultValue;
        }

        return input;
    }
}
