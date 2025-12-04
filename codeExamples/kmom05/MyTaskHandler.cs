namespace MyPlanner.src;

public class MyTaskHandler
{
    private List<MyTask> _tasks;

    public MyTaskHandler()
    {
        this._tasks = [];
    }

    public void CreateTask(string location, string title, string description, DateTime dueDate)
    {
        PrivateTask task = new PrivateTask(location, title, description, dueDate);
        this._tasks.Add(task);
    }

    public void CreateTask(int workedTime, int estimatedTime, string title, string description, DateTime dueDate)
    {
        WorkTask task = new WorkTask(estimatedTime, workedTime, title, description, dueDate);
        this._tasks.Add(task);
    }

    public bool UpdateTask(string location, string title, string description, DateTime dueDate, bool completed = false)
    {
        // Uppdatera
        return false;
    }

    public bool UpdateTask(int estimatedTime, int timeWorked, string title, string description, DateTime dueDate, bool completed = false)
    {
        // Uppdatera
        return false;
    }

    public string CompleteTask(string title)
    {
        string message = "";

        // Uppdatera och returnera ett felmeddelande i message om det inte 
        // gick att sätta uppgiften till klar.

        return message;
    }

    public int GetNoOfTasks()
    {
        // Uppdatera
        return -1;
    }

    public List<string> GetTaskContent(string title)
    {
        List<string> content = [];

        // Uppdatera
        // Skapa metoden void GetContentAsStrings(List<string> content) i arvshierarkin för uppgifterna
        // Anropa denna
        // Titta i metoden HandleUpdateTask i Planner för att förstå vad listan ska innehålla

        return content;
    }

    public bool DeleteTask(string title)
    {
        // Uppdatera
        return false;
    }

    public string GetDescription(string title)
    {
        // Uppdatera
        return "";
    }
}
