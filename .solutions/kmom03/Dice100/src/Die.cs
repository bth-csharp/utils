namespace Dice100.src;
public class Die
{
    private const int MaxValue = 6;
    private const int MinValue = 1;
    private int _value;
    private Random _dieRandom;

    public Die()
    {
        _dieRandom = new Random();
        this.Roll();
    }

    public Die(int value)
    {
        _dieRandom = new Random();
        if (value > MaxValue)
        {
            this._value = MaxValue;
        }
        else if (value < MinValue)
        {
            this._value = MinValue;
        }
        else
        {
            this._value = value;
        }
    }

    public int GetValue()
    {
        return this._value;
    }

    public void Roll()
    {
        this._value = _dieRandom.Next(MinValue, MaxValue + 1);
    }

    public string GetString()
    {
        return this._value.ToString();
    }

    public void PrintAsciiArt()
    {
        AsciiArt.PrintDie(this._value);
    }
}
