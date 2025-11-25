namespace MyBank.src;

public class Customer
{
    private string _name;

    public Customer(string name)
    {
        this._name = name;
    }

    public string GetName()
    {
        return this._name;
    }
}
