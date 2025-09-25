namespace MyPlanner2.src;

/// <summary>
/// This class WorkTask is an extension of MyTask used in the planning tool MyPlanner2.
/// It is a work task, such as planning, research, implementation, testing
/// </summary>
public class WorkTask : MyTask
{
    private int _prio;
    private int _estimatedTime;
    private int _timeWorked;
    private string _projectName;

    public WorkTask(int prio, int estimatedTime, string projectName, string title, string description, DateTime dueDate) : base(title, description, dueDate)
    {
        this._prio = prio;
        this._estimatedTime = (estimatedTime >= 1) ? estimatedTime : 1;
        this._timeWorked = 0;
        this._projectName = projectName;
    }

    public int GetPrio()
    {
        return this._prio;
    }

    public string GetProjectName()
    {
        return this._projectName;
    }

    public void SetPrio(int prio)
    {
        this._prio = prio;
    }

    public void SetEstimatedTime(int estimatedTime)
    {
        if (estimatedTime > 0 && estimatedTime >= this._timeWorked)
        {
            this._estimatedTime = estimatedTime;
        }
    }

    public void SetTimeWorked(int timeWorked)
    {
        if (timeWorked > 0 && timeWorked > this._timeWorked)
        {
            this._timeWorked = timeWorked;
        }
    }

    public void SetProjectName(string projectName)
    {
        this._projectName = projectName;
    }

    public int GetProgression()
    {
        //double quotient = ((double)this._timeWorked / (double)this._estimatedTime) * 100;
        decimal quotient = Decimal.Divide(_timeWorked, _estimatedTime) * 100;

        return (int)Math.Round(quotient);
    }

    public override void Completed()
    {
        if (this._timeWorked > 0 && GetProgression() >= 80)
        {
            base.Completed();
        }
    }

    public override string GetDescription()
    {
        string description = base.GetBaseDescription();
        description += $"\nProjektnamn: {this._projectName} och är klar till {GetProgression()}% (Prio: {this._prio})";

        return description;
    }

    public override List<string> GetInformation()
    {
        List<string> info = [];

        info.Add(_prio.ToString());
        info.Add(_estimatedTime.ToString());
        info.Add(_timeWorked.ToString());
        info.Add(_projectName);
        info.AddRange(base.GetInformation());

        return info;
    }

    public override List<string> GetFieldInfo()
    {
        return this.GetInformation();
    }
}
