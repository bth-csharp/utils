namespace Dice100Extra.src;
public class Round
{
    private const int NO_OF_DICE = 5;
    private List<Die> _hand;
    private int _points;

    public Round()
    {
        _hand = new List<Die>();
        _points = 0;
        Reset();
    }

    public Round(List<int> values)
    {
        _hand = new List<Die>();
        _points = 0;
        for (int i = 0; i < NO_OF_DICE; i++)
        {
            Die die = new Die(values[i]);
            _hand.Add(die);
        }
        UpdatePoints();
    }

    private void Reset()
    {
        _hand.Clear();
        for (int i = 0; i < NO_OF_DICE; i++)
        {
            Die die = new Die();
            _hand.Add(die);
        }
        _points = 0;
    }

    public List<Die> GetHand()
    {
        return this._hand;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SetPoints(int newPoint)
    {
        _points = newPoint;
    }

    public void Roll()
    {
        foreach (Die die in _hand)
        {
            die.Roll();
        }
        UpdatePoints();
    }

    public void Roll(List<int> indexes)
    {
        foreach (int index in indexes)
        {
            _hand[index].Roll();
        }
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        foreach (Die die in _hand)
        {
            if (die.GetValue() == 1)
            {
                _points = 0;
                break;
            }
            else
            {
                _points += die.GetValue();
            }
        }
    }

    public List<int> HandToList()
    {
        List<int> handList = new List<int>();
        foreach (var die in _hand)
        {
            handList.Add(die.GetValue());
        }

        return handList;
    }

    public void PrintRound()
    {
        Console.WriteLine("\nDin runda: ");
        foreach (var die in _hand)
        {
            Console.WriteLine(die.GetString());
        }
        Console.WriteLine(""); // tom rad efter tärningarna
    }
}
