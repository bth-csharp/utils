using System;
using System.Collections.Generic;

namespace Education;

public class Student
{
    private string _name;
    private string[] _courses = new string[12];
    private List<string> _completedCourses = new List<string>();

    public Student()
    {
        this._name = "No name";
    }

    public Student(string name)
    {
        this._name = name;
    }

    public void SetCourses(string[] courses)
    {
        //this._courses = courses; Ska inte använda samma array utan använda en kopia
        this._courses = (string[])courses.Clone();
    }

    public void CompleteCourse(string courseName)
    {
        if (Array.IndexOf(this._courses, courseName) != -1)
        {
            this._completedCourses.Add(courseName);
        }
    }

public void AddNewCourse(string courseName)
    {
        for (int i = 0; i < this._courses.Length; i++)
        {
            if (this._courses[i] == null)
            {
                this._courses[i] = courseName;
                break;
            }
        }
    }

    public string Information()
    {
        return $"Student: {this._name} har klarat {this._completedCourses.Count} kurser.";
    }

    public string InformationCourses()
    {
        string result = "Alla kurser: ";

        for (int i = 0; i < this._courses.Length; i++)
        {
            if (this._courses[i] != null)
            {
                result += this._courses[i] + ", ";
            }
        }
        result = result.TrimEnd([',', ' ']);
        result += "\nAvklarade kurser: ";
        if (this._completedCourses != null)
            result += string.Join(", ", this._completedCourses);

        return result;
    }
}
