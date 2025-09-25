namespace MyPlanner2.src;

/// <summary>
/// This class is the terminalprogram used for the planning tool MyPlanner2.
/// </summary>
public class Planner
{
    private readonly MyTaskHandler _myTaskHandler;
    private readonly IFileHandler _myFileHandler;

    public Planner()
    {
        _myTaskHandler = new MyTaskHandler();
        _myFileHandler = new FileHandler("tasks.txt");
        ReadTasksFromFile();
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
        Helpers.GetTerminalReady("KMOM06 MYPLANNER2");

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
                    SaveTasksToFile();
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
        string type = Helpers.ReadStringFromTerminal("Vilken typ av uppgift? (Privat=p och Arbete=a):");
        if (type.Equals("a", StringComparison.CurrentCultureIgnoreCase))
        {
            CreateWorkTask();
        }
        else if (type.Equals("p", StringComparison.CurrentCultureIgnoreCase))
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
        DateTime dateTime = DateTime.Now;
        string[] dateParts;
        string title = Helpers.ReadStringFromTerminal("Namn på uppgiften du vill skapa: ");
        string description = Helpers.ReadStringFromTerminal("Beskrivning av uppgiften: ");
        string ready = Helpers.ReadStringFromTerminal("Datum uppgiften ska vara klar (YYYY-MM-DD): ");
        if (ready != "")
        {
            dateParts = ready.Split('-');
            dateTime = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        }
        string location = Helpers.ReadStringFromTerminal("Var ska uppgiften utföras: ");
        _myTaskHandler.CreateTask(location, title, description, dateTime);
        Console.WriteLine($"\nUppgiften {title} är skapad!");
    }

    private void CreateWorkTask()
    {
        DateTime dateTime = DateTime.Now;
        string[] dateParts;
        string title = Helpers.ReadStringFromTerminal("Namn på uppgiften du vill skapa: ");
        string description = Helpers.ReadStringFromTerminal("Beskrivning av uppgiften: ");
        string ready = Helpers.ReadStringFromTerminal("Datum uppgiften ska vara klar (YYYY-MM-DD): ");
        if (ready != "")
        {
            dateParts = ready.Split('-');
            dateTime = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        }
        int prio = Helpers.ReadIntFromTerminal("Vilken prioritet har uppgiften? ");
        int estimatedTime = Helpers.ReadIntFromTerminal("Vilken är beräknad tid för uppgiften? ");
        string projectName = Helpers.ReadStringFromTerminal("Vilket projekt tillhör uppgiften? ");
        _myTaskHandler.CreateTask(prio, estimatedTime, projectName, title, description, dateTime);
        Console.WriteLine($"\nUppgiften {title} är skapad!");
    }

    private void HandleUpdateTask()
    {
        string title = Helpers.ReadStringFromTerminal("Namn på uppgiften du vill uppdatera: ");
        List<string> info = _myTaskHandler.GetOneTasksInfo(title);
        int noOfEntries = info.Count;
        bool updateOk = false;

        if (noOfEntries == 0)
        {
            Console.WriteLine($"\nUppgiften {title} hittades inte. Inget är uppdaterat!");
        }
        else
        {
            if (info.Count == 5) { updateOk = UpdatePrivateTask(info); }
            if (info.Count == 8) { updateOk = UpdateWorkTask(info); }
            if (updateOk)
            {
                Console.WriteLine("\nFöljande uppgift är nu uppdaterad:");
                Console.WriteLine(_myTaskHandler.GetDescription(title));
            }
        }
    }

    private bool UpdatePrivateTask(List<string> info)
    // info from PrivateTask: string location, string title, string description, DateTime dueDate, bool completed=false
    {
        DateTime newDate = DateTime.MinValue;

        Console.WriteLine($"\nUppgiften {info[1]} hittades, befintlig information inom parentes.");
        Console.WriteLine("\nKlicka bara på enter (return) om inget ska ändras.");
        string description = Helpers.ReadStringFromTerminal($"Beskrivning av uppgiften ({info[2]}): ");
        string ready = Helpers.ReadStringFromTerminal($"Datum uppgiften ska vara klar (YYYY-MM-DD) ({info[3]}): ");
        if (ready != "")
        {
            string[] dateParts = ready.Split('-');
            newDate = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        }
        string location = Helpers.ReadStringFromTerminal($"Var ska uppgiften utföras ({info[0]}): ");
        string completedStr = Helpers.ReadStringFromTerminal($"Ange true om uppgiften är klar, annars false ({info[4]}): ");
        bool completed = (completedStr.ToLower() == "true") ? true : false;

        return _myTaskHandler.UpdateTask(location, info[1], description, newDate, completed);
    }

    private bool UpdateWorkTask(List<string> info)
    // info from PrivateTask: int prio, int estimatedTime, int workedTime, string projectName, string title, string description, DateTime dueDate, bool completed=false
    {
        DateTime newDate = DateTime.MinValue;

        Console.WriteLine($"\nUppgiften {info[4]} hittades, befintlig information inom parentes.");
        Console.WriteLine("\nKlicka bara på enter (return) om inget ska ändras.");
        string description = Helpers.ReadStringFromTerminal($"Beskrivning av uppgiften ({info[5]}): ");
        string ready = Helpers.ReadStringFromTerminal($"Datum uppgiften ska vara klar (YYYY-MM-DD) ({info[6]}): ");
        if (ready != "")
        {
            string[] dateParts = ready.Split('-');
            newDate = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        }
        int prio = Helpers.ReadIntFromTerminal($"Vilken prioritet har uppgiften ({info[0]}): ");
        int estimatedTime = Helpers.ReadIntFromTerminal($"Vilken är beräknad tid för uppgiften ({info[1]}): ");
        int timeWorked = Helpers.ReadIntFromTerminal($"Hur många timmar har arbetats på uppgiften ({info[2]}): ");
        string projectName = Helpers.ReadStringFromTerminal($"Vilket projekt tillhör uppgiften ({info[3]}): ");
        string completedStr = Helpers.ReadStringFromTerminal($"Ange true om uppgiften är klar, annars false ({info[7]}): ");
        bool completed = (completedStr.ToLower() == "true") ? true : false;

        return _myTaskHandler.UpdateTask(prio, estimatedTime, timeWorked, projectName, info[4], description, newDate, completed);
    }

    private void HandleDeleteTask()
    {
        bool deleteOk = false;
        string title = Helpers.ReadStringFromTerminal("Namn på uppgiften du vill ta bort: ");
        string message = $"\nUppgiften {title} hittades inte. Ingen uppgift är borttagen!";

        deleteOk = _myTaskHandler.DeleteTask(title);
        if (deleteOk) { message = $"\nUppgiften {title} är nu borttagen."; }
        Console.WriteLine(message);
    }

    private void SetTaskToCompleted()
    {
        string title = Helpers.ReadStringFromTerminal("Namn på uppgiften du vill sätta till avklarad: ");

        _myTaskHandler.CompleteTask(title);
        Console.WriteLine("\nFöljande uppgift är nu avklarad:");
        Console.WriteLine(_myTaskHandler.GetDescription(title));
    }

    private void PrintAllTasks()
    {
        List<MyTask>? tasks = _myTaskHandler.GetTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("\nDet finns inga uppgifter!");
        }
        else
        {
            Console.WriteLine("\nAlla uppgifter:");
            Console.WriteLine("\n===============================");
            foreach (var item in tasks)
            {
                Console.WriteLine(item.GetDescription());
            }
        }
    }

    public int GetNoOfTasks()
    {
        return _myTaskHandler.GetNoOfTasks();
    }

    private void SaveTasksToFile()
    {
        List<string> lines = [];
        string[] strings;
        string s;

        foreach (var item in _myTaskHandler.GetTasks())
        {
            s = string.Join(",", item.GetInformation());
            lines.Add(s);
        }
        strings = lines.ToArray(); // eller [.. lines];
        _myFileHandler.Save(strings);
    }

    private void ReadTasksFromFile()
    {
        string[] taskList = _myFileHandler.Read();

        foreach (string item in taskList)
        {
            string[] parts = item.Split(',');
            if (parts.Length == 5)
            {
                CreatePrivateTaskFromFile(parts);
            }
            if (parts.Length == 8)
            {
                UpdateWorkTaskFromFile(parts);
            }
        }
    }

    private void CreatePrivateTaskFromFile(string[] info)
    // info from PrivateTask: string location, string title, string description, DateTime dueDate, bool completed
    {
        string[] dateParts = info[3].Split('-');
        DateTime newDate = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        _myTaskHandler.CreateTask(info[0], info[1], info[2], newDate);
        if (info[4].ToLower() == "true")
        {
            _myTaskHandler.CompleteTask(info[1]);
        }
    }

    private void UpdateWorkTaskFromFile(string[] info)
    // info from PrivateTask: int prio, int estimatedTime, int workedTime, string projectName, string title, string description, DateTime dueDate, bool completed
    {
        string[] dateParts = info[6].Split('-');
        DateTime newDate = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
        _myTaskHandler.CreateTask(Helpers.StringToInt(info[0]), Helpers.StringToInt(info[1]), info[3], info[4], info[5], newDate);
        bool completed = (info[7].ToLower() == "true") ? true : false;
        _myTaskHandler.UpdateTask(Helpers.StringToInt(info[0]), Helpers.StringToInt(info[1]), Helpers.StringToInt(info[2]),
            info[3], info[4], info[5], newDate, completed);
    }
}
