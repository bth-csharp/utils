namespace MyPlanner2.src;

/// <summary>
/// This class MyTaskHandler takes care of the tasks in a planning tool MyPlanner2.
/// </summary>
public class MyTaskHandler
{
    private readonly List<MyTask> _tasks;

    public MyTaskHandler()
    {
        _tasks = []; // förenklat new List<MyTask>()
    }

    public void CreateTask(string location, string title, string description, DateTime dueDate)
    {
        PrivateTask task = new PrivateTask(location, title, description, dueDate);
        _tasks.Add(task);
    }

    public void CreateTask(int prio, int estimatedTime, string projectName, string title, string description, DateTime dueDate)
    {
        WorkTask task = new WorkTask(prio, estimatedTime, projectName, title, description, dueDate);
        _tasks.Add(task);
    }

    public bool UpdateTask(string location, string title, string description, DateTime dueDate, bool completed)
    {
        bool updateOk = false;

        MyTask? task = FindMyTask(title);
        if (task != null)
        {
            updateOk = task.Update(location, title, description, dueDate);
            if (completed) { task.Completed(); }
        }

        return updateOk;
    }

    public bool UpdateTask(int prio, int estimatedTime, int timeWorked, string projectName, string title, string description, DateTime dueDate, bool completed)
    {
        bool updateOk = false;

        MyTask? task = FindMyTask(title);
        if (task != null)
        {
            updateOk = task.Update(prio, estimatedTime, timeWorked, projectName, title, description, dueDate);
            if (completed) { task.Completed(); }
        }

        return updateOk;
    }

    public void CompleteTask(string title)
    {
        MyTask? task = FindMyTask(title);

        task?.Completed(); // eller if (task != null) { task.Completed(); }
    }

    public virtual int GetNoOfTasks()
    {
        return (_tasks.Count == 0) ? 0 : _tasks.Count;
    }

    public List<string> GetOneTasksInfo(string title)
    {
        List<string> info = [];

        MyTask? aTask = FindMyTask(title);

        if (aTask != null)
        {
            info.AddRange(aTask.GetInformation());
        }

        return info;
    }

    public List<MyTask> GetTasks()
    {
        return _tasks;
    }

    public bool DeleteTask(string title)
    {
        bool deleteOk = false;

        MyTask? task = FindMyTask(title);
        if (task != null)
        {
            deleteOk = _tasks.Remove(task);
        }

        return deleteOk;
    }

    public string GetDescription(string title)
    {
        string message = $"\nUppgiften {title} kunde inte hittas, beskrivning saknas!";

        MyTask? aTask = FindMyTask(title);
        if (aTask != null)
        {
            message = aTask.GetDescription();
        }

        return message;
    }

    private MyTask? FindMyTask(String title)
    {
        foreach (var task in _tasks)
        {
            if (task.GetTitle().Equals(title, StringComparison.CurrentCultureIgnoreCase))
            {
                return task;
            }
        }

        return null; // returnera null om inget hittades
    }
}
