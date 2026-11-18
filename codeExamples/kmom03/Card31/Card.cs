public class Card
{
    private string _suit; // Ex Hjärter
    private string _rank; // Ex 3 och Kung
    private int _value; // Ex 5

    public Card(string suit, string rank)
    {
        this._suit = suit;
        this._rank = rank;
        this._value = -1;
    }

    public Card(string suit, string rank, int value)
    {
        this._suit = suit;
        this._rank = rank;
        this._value = value;
    }

    public void SetValue(int value)
    {
        if (value > 0)
            this._value = value;
    }

    public int GetValue()
    {
        return this._value;
    }

    public string GetSuit()
    {
        return this._suit;
    }

    public string GetRank()
    {
        return this._rank;
    }

    public string GetDescription()
    {
        return this._suit + " " + this._rank;
    }
}
