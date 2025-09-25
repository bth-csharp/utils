namespace Dice100Extra.src;

public class Player
{
    private string _name;
    private int _points;

    private int _noOfRounds;

    public Player(string nameSuggestion = "Player")
    {
        _name = nameSuggestion;
        _points = 0;
        _noOfRounds = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void AddPoints(int pointsToAdd)
    {
        _points += pointsToAdd;
        _noOfRounds++;
    }

    public int GetNoOfRounds()
    {
        return _noOfRounds;
    }
}
