namespace Education;

public class Course
{
    private const int INCOME_PASSED_YEAR = 58400;
    private const int POINTS_PER_YEAR = 60;
    private string _code;
    private string _name;
    private float _points;

    // Konstruktor
    public Course(string code, string name, float points)
    {
        this._code = code;
        this._name = name;
        this._points = points;
    }

    public Course()
    {
        this._code = "XXXX";
        this._name = "Any name";
        this._points = 7.5F;
    }

    // Getmetod eller getter
    public string GetCode()
    {
        return this._code;
    }

    public string GetName()
    {
        return this._name;
    }

    // Setmetod eller setter
    public void SetName(string newName)
    {
        this._name = newName;
    }

    public string Information()
    {
        return $"Kursen {this._code} {this._name} är på {this._points} hp.";
    }

    public double GetCourseIncome(int noOfPassedStudents)
    {
        double yearIncome = noOfPassedStudents * this._points * INCOME_PASSED_YEAR;

        return yearIncome / POINTS_PER_YEAR;
    }
}