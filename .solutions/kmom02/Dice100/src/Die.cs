namespace Dice100.src;
public class Die
{
    private const int MAX_VALUE = 6;
    private const int MIN_VALUE = 1;
    private int _value;
    private static Random _dieRandom = new Random();

    public Die()
    {
        this.Roll();
    }

    public Die(int value)
    {
        if (value > MAX_VALUE)
        {
            this._value = MAX_VALUE;
        }
        else if (value < MIN_VALUE)
        {
            this._value = MIN_VALUE;
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
        this._value = Die._dieRandom.Next(MIN_VALUE, MAX_VALUE + 1);
    }

    public string GetString()
    {
        return this._value.ToString();
    }
}
