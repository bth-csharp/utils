/*
 * This module contains the classes you should implement.
 */

public class Cat
{
    private string _eyeColor;
    private string _name;
    private static int _livesLeft = -1;

    public Cat(string name, string eyeColor)
    {
        this._eyeColor = eyeColor;
        this._name = name;
    }

    public string GetName()
    {
        return this._name;
    }

    public static void SetLivesLeft(int newLivesLeft)
    {
        Cat._livesLeft = newLivesLeft;
    }

    public static int GetLivesLeft()
    {
        return Cat._livesLeft;
    }

    public string Description()
    {
        return $"My cat's name is {this._name}, has {this._eyeColor} eyes and {Cat._livesLeft} lives left to live.";
    }
}

public class Owner{
    private string _ownerName;
    private List<Cat> _catList;
    Dictionary<string, Insurance> _catInfo;

    public Owner(string ownerName)
    {
        this._ownerName = ownerName;
        this._catList = new List<Cat>();
        this._catInfo = new Dictionary<string, Insurance>{};
    }

    public void AddCat(Cat cat)
    {

        this._catList.Add(cat);
    }

    public void AddCat(Cat cat, string type)
    {
        this._catList.Add(cat);
        this._catInfo.Add(cat.GetName(), new Insurance(type));
    }

    public int GetCatNoOfCats()
    {
        return this._catList.Count;
    }

    public string GetCatInfo()
    {
        string result = "";

        if (this._catInfo.Count == 0)
        {
            result = "No cats.";
        }
        else
        {
            int counter = 0;

            foreach (var item in this._catInfo)
            {
                counter++;
                result += $"Cat {counter}, named {item.Key} has {item.Value.Information()}\n";
            }
        }

        return result;
    }
}

public class Insurance
{
    private string _type;
    private decimal _price;

    public Insurance(string type)
    {
        this._type = type;
        this._price = 100;
        if (type != "Half")
        {
            this._type = "Full";
            this._price = 200;
        }
    }

    public string Information()
    {
        return $"Insurance type: {this._type}, price: {this._price} kr per month.";
    }
}
