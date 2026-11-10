namespace Dice100.src;

public class Player
{
    private string _name;
    private int _score;
    private int _noOfRounds;

    public Player()
    {
        this._name = "Player 1";
        this._score = 0;
        this._noOfRounds = 0;
    }

    public Player(string name)
    {
        this._name = name;
        this._score = 0;
        this._noOfRounds = 0;
    }

    public string GetName()
    {
        return this._name;
    }

    public int GetScore()
    {
        return this._score;
    }

    public int GetNoOfRounds()
    {
        return this._noOfRounds;
    }

    public void Reset()
    {
        this._score = 0;
        this._noOfRounds = 0;
    }

    public void AddScore(int score)
    {
        this._score = this._score + score;
    }

    public void AddRound()
    {
        this._noOfRounds = this._noOfRounds + 1;
    }

    public bool HasWon(int winningScore)
    {
        return this._score >= winningScore;
    }

    public void PrintInformation()
    {
        Console.WriteLine($"Player: {this._name} has {this._score} points in {this._noOfRounds} rounds.");
    }
}

