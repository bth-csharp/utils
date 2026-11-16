namespace Lottery;

public class NumberGenerator
{
    private int _currentNumber;
    private int _maxNumber;
    private int _minNumber;
    private static Random random = new Random();

    public NumberGenerator(int min, int max)
    {
        this._minNumber = min;
        this._maxNumber = max;
        this.GenerateNumber();
    }

    public void GenerateNumber()
    {
        this._currentNumber = random.Next(this._minNumber, this._maxNumber + 1);
    }

    public int GetCurrentNumber()
    {
        return this._currentNumber;
    }
}