namespace Dice100Extra.src;

public class Game
{
    private const int GOAL = 100;
    private List<Player> _players;
    private int _actualPlayer;
    private Round _tempRound;

    public Game(int noOfPlayers)
    {
        _tempRound = new Round();
        _players = new List<Player>();
        _actualPlayer = 0;
        InitGame(noOfPlayers);
    }

    private void InitGame(int noOfPlayers)
    {
        for (int i = 0; i < noOfPlayers; i++)
        {
            Player player = new Player("Player " + (i + 1).ToString());
            _players.Add(player);
        }
    }

    public void Roll()
    {
        Roll(_actualPlayer);
    }

    private void Roll(int playerNo)
    {
        _tempRound.Roll();
        _tempRound.PrintRound();
        Console.WriteLine($"Rundan är värd {_tempRound.GetPoints()} poäng.");
        if (_tempRound.GetPoints() == 0)
        {
            Stop(playerNo);
        }
    }

    public bool Stop()
    {
        return Stop(_actualPlayer);
    }

    private bool Stop(int playerNo)
    {
        _players[playerNo].AddPoints(_tempRound.GetPoints());
        _tempRound = new Round();
        if (_players[playerNo].GetPoints() < GOAL)
        {
            PresentRoundInfo(playerNo);
            return false;
        }
        else
        {
            PresentWinner(playerNo);
            return true;
        }
    }

    public void PrintActualPlayer()
    {
        Console.WriteLine($"\nAktuell spelare är nummer {(_actualPlayer + 1)} som har {_players[_actualPlayer].GetPoints()} poäng.");
    }

    private void PresentRoundInfo(int playerNo)
    {
        Console.WriteLine($"{_players[playerNo].GetName()} har {_players[playerNo].GetPoints()} poäng på {_players[playerNo].GetNoOfRounds()} rundor.");
        _actualPlayer = (_actualPlayer + 1) % _players.Count;
        Console.WriteLine($"Nästa spelare är nummer {(_actualPlayer + 1)} som har {_players[_actualPlayer].GetPoints()} poäng.");
    }

    private void PresentWinner(int playerNo)
    {
        Console.Clear();
        Console.WriteLine("Dice100");
        Console.WriteLine($"{_players[playerNo].GetName()} har vunnit med {_players[playerNo].GetPoints()} poäng.");
        Console.WriteLine($"Poäng: {_players[playerNo].GetPoints()}");
        Console.WriteLine($"Antal rundor: {_players[playerNo].GetNoOfRounds()}");
    }

    public void Reset()
    {
        int noOfPlayers = 0;

        if (_players != null)
        {
            noOfPlayers = _players.Count;
        }
        _players = new List<Player>();
        for (int i = 0; i < noOfPlayers; i++)
        {
            Player player = new Player("Player " + (i + 1).ToString());
            _players.Add(player);
        }
        _tempRound = new Round();
        _actualPlayer = 0;
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
}
