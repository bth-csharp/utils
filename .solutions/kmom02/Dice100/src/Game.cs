namespace Dice100.src;

public class Game
{
    // All private variables should have underscore first
    private const int GOAL = 100;
    private Round _tempRound;
    private int _tempPoint;
    private int _noOfRounds;

    public Game()
    {
        _tempRound = new Round();
        Reset();
    }

    public void Roll()
    {
        _tempRound.Roll();
        _tempRound.PrintRound();
        Console.WriteLine($"Rundan är värd {_tempRound.GetPoints()} poäng.");
        if (_tempRound.GetPoints() == 0) // automatiskt ny runda om 1:a
        {
            Stop();
        }
    }

    public void Stop()
    {
        _tempPoint += _tempRound.GetPoints();
        _tempRound.SetPoints(0);
        _noOfRounds++;
        if (_tempPoint < 100)
        {
            PresentRoundInfo();
        }
        else
        {
            PresentWinner();

        }
    }

    private void PresentRoundInfo()
    {
        Console.WriteLine("\nRundan är avslutad - du har:");
        Console.WriteLine($"Poäng: {_tempPoint}");
        Console.WriteLine($"Antal rundor: {_noOfRounds}");
    }

    private void PresentWinner()
    {
        Console.Clear();
        Console.WriteLine("Dice100");
        Console.WriteLine("\nDu har vunnit! Grattis!");
        Console.WriteLine($"Poäng: {_tempPoint}");
        Console.WriteLine($"Antal rundor: {_noOfRounds}");

        Reset();
    }

    public static void PrintRules()
    {
        Console.WriteLine("\nRegler Dice100");
        Console.WriteLine("\nDu har 5 tärningar och ska nå målet 100 på så få rundor");
        Console.WriteLine("som möjligt. Du väljer själv hur många slag du vill slå");
        Console.WriteLine("på varje runda. När du är är markerar du att rundan är");
        Console.WriteLine("slut med stop.");
        Console.WriteLine("\nOm du får en 1:a så får du 0 poäng den rundan.");
        Console.WriteLine("\nLycka till!");
    }

    public void Reset()
    {
        _tempPoint = 0;
        _noOfRounds = 0;
    }
}
