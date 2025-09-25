namespace MyPlanner2.src;

/// <summary>
/// This class PrivateTask is an extension of MyTask used in the planning tool MyPlanner2.
/// It is a private task, such as clean, exercise, read
/// </summary>
public class PrivateTask : MyTask
{
    /// <summary>
    /// The location where the task will take place.
    /// </summary>
    private string _location;

    /// <summary>
    /// The constructor creates an object of the <see cref="PrivateTask"/> class with the following parameters.
    /// </summary>
    /// <param name="location"></param>
    /// <param name="title">The location where the task will take place.</param>
    /// <param name="description">The description of the task.</param>
    /// <param name="dueDate">The date when the task should be ready. Can also contain the time.</param>
    /// <returns>An object of the class PrivateTask.</returns>
    /// 
    public PrivateTask(string location, string title, string description, DateTime dueDate)
        : base(title, description, dueDate)
    {
        this._location = location;
    }

    /// <summary>
    /// Gets information about where the task will take place.
    /// </summary>
    /// <returns>A string with the location.</returns>
    public string GetLocation()
    {
        return this._location;
    }

    /// <summary>
    /// Sets information where the task will take place.
    /// </summary>
    /// <param name="location">The new location of where the task will take place.</param>
    public void SetLocation(string location)
    {
        this._location = location;
    }

    /// <summary>
    /// Gets all the information about the task in some sentences.
    /// </summary>
    /// <returns>A string with all the information about the task.</returns>
    public override string GetDescription()
    {
        string description = base.GetBaseDescription();
        description += $"\nPlats: {this._location}";

        return description;
    }

    /// <summary>
    /// Gets all the attributes from the task. Used when updating tasks.
    /// </summary>
    /// <returns>A list of strings containing the attributes.</returns>
    public override List<string> GetInformation()
    {
        List<string> info = [];

        info.Add(_location);
        info.AddRange(base.GetInformation());

        return info;
    }

    /// <summary>
    /// Gets all the attributes from the task. Used when updating tasks.
    /// </summary>
    /// <returns>A list of strings containing the attributes.</returns>
    public override List<string> GetFieldInfo()
    {
        return this.GetInformation();
    }
}
