namespace MyBank.src;

public class Employee
{
    private static int _nextEmployeeNumber = 100;
    private string _name;
    private int _employeeNumber;

    public Employee(string name)
    {
        this._name = name;
        this._employeeNumber = Employee._nextEmployeeNumber;
        Employee._nextEmployeeNumber++;
    }
}