namespace MyPlanner.src;

/// <summary>
/// This class MyTask describes a task in a planning tool.
/// </summary>
public class MyTask
{
    private string _title;
    private string _description;
    private DateTime _dueDate;
    private bool _completed;

    public MyTask(string title, string description, DateTime dueDate)
    {
        this._title = title;
        this._description = description;
        this._dueDate = dueDate;
        this._completed = false;
    }

    public virtual bool Update(string location, string title, string description, DateTime dueDate)
    {
        bool testInputData = false;
        int counter = 0;

        if (this._title == title)
        {
            if (location != "") { ((PrivateTask)this).SetLocation(location); counter++; }
            if (description != "") { this._description = description; counter++; }
            if (dueDate != DateTime.MinValue) { this._dueDate = dueDate; counter++; }
            if (counter > 0) { testInputData = true; }
        }

        return testInputData;
    }

    public virtual bool Update(int prio, int estimatedTime, int timeWorked, string projectName, string title, string description, DateTime dueDate)
    {
        bool testInputData = false;
        int counter = 0;

        if (this._title == title)
        {
            if (prio >= 0) { ((WorkTask)this).SetPrio(prio); counter++; }
            if (estimatedTime >= timeWorked) { ((WorkTask)this).SetEstimatedTime(estimatedTime); counter++; }
            if (timeWorked >= 0) { ((WorkTask)this).SetTimeWorked(timeWorked); counter++; }
            if (projectName != "") { ((WorkTask)this).SetProjectName(projectName); counter++; }
            if (description != "") { this._description = description; counter++; }
            if (dueDate != DateTime.MinValue) { this._dueDate = dueDate; counter++; }
            if (counter > 0) { testInputData = true; }
        }

        return testInputData;
    }

    public string GetTitle()
    {
        return this._title;
    }

    public DateTime GetDueDate()
    {
        return this._dueDate;
    }

    public bool IsCompleted()
    {
        return this._completed;
    }


    public virtual void Completed()
    {
        this._completed = true;
    }

    public virtual string GetDescription()
    {
        string status = this._completed == true ? "klar ✅" : "ej klar";
        string description = $"\n📋 Uppgiften {this._title} ska vara klar senast {this._dueDate.ToString("yyyy-MM-dd")} och är {status}.";
        description += $"\nBeskrivning: {this._description}";

        return description;
    }

    public virtual List<string> GetInformation()
    {
        List<string> info = [];

        info.Add(this._title);
        info.Add(this._description);
        info.Add(this._dueDate.ToString("yyyy-MM-dd"));
        info.Add(this._completed.ToString().ToLower());

        return info;
    }
}
