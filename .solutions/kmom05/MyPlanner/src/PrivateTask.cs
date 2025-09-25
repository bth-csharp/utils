namespace MyPlanner.src;

public class PrivateTask : MyTask
{
    private string _location;

    public PrivateTask(string location, string title, string description, DateTime dueDate)
        : base(title, description, dueDate)
    {
        this._location = location;
    }

    public string GetLocation()
    {
        return this._location;
    }

    public void SetLocation(string location)
    {
        this._location = location;
    }

    public override string GetDescription()
    {
        string description = base.GetDescription();
        description += $"\nPlats: {this._location}";

        return description;
    }

    public override List<string> GetInformation()
    {
        List<string> info = [];

        info.Add(_location);
        info.AddRange(base.GetInformation());

        return info;
    }
}
