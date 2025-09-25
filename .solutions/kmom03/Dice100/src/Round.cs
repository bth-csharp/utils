namespace Dice100.src;
public class Round
{
    private int _noOfDice = 5; // Default 5 tärningar
    private List<Die> _hand;
    private int _points;

    public Round()
    {
        this._hand = new List<Die>();
        this._points = 0;
        Reset();
    }

    public Round(int _noOfDice)
    {
        this._noOfDice = _noOfDice;
        this._hand = new List<Die>();
        this._points = 0;
        Reset();
    }

    public Round(List<int> values)
    {
        this._hand = new List<Die>();
        this._points = 0;
        for (int i = 0; i < _noOfDice; i++)
        {
            Die die = new Die(values[i]);
            this._hand.Add(die);
        }
        UpdatePoints();
    }

    private void Reset()
    {
        this._hand.Clear();
        for (int i = 0; i < this._noOfDice; i++)
        {
            Die die = new Die();
            this._hand.Add(die);
        }
        this._points = 0;
    }

    public int GetPoints()
    {
        return this._points;
    }

    public void SetPoints(int newPoint)
    {
        this._points = newPoint;
    }

    public void Roll()
    {
        foreach (Die die in this._hand)
        {
            die.Roll();
        }
        UpdatePoints();
    }

    public void Roll(List<int> indexes)
    {
        foreach (int index in indexes)
        {
            this._hand[index].Roll();
        }
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        foreach (Die die in this._hand)
        {
            if (die.GetValue() == 1)
            {
                this._points = 0;
                break;
            }
            else
            {
                this._points += die.GetValue();
            }
        }
    }

    public List<int> HandToList()
    {
        List<int> handList = new List<int>();
        foreach (var die in this._hand)
        {
            handList.Add(die.GetValue());
        }

        return handList;
    }

    public void PrintRound()
    {
        foreach (var die in this._hand)
        {
            die.PrintAsciiArt();
        }
        Console.WriteLine("\n"); // tom rad efter tärningarna
    }
}