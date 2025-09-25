namespace Dice100.src;

public class Game
{
    private const int TargetPoint = 100;
    private const string TopListFile = @"toplist.txt";
    private Round _tempRound;
    private int _tempPoint;
    private int _noOfRounds;
    private (int, string, int, int)[] _topList;
    private (int, string) _tempName;

    public Game()
    {
        this._tempRound = new Round();
        this._topList = new (int, string, int, int)[20];
        Reset();
    }

    public Game(int noOfDice, string name)
    {
        if (noOfDice < 2)
        {
            throw new NumberOfDieException("Antalet tärning ska vara 2 eller fler.");
        }
        else if (noOfDice > 10)
        {
            throw new NumberOfDieException("Antalet tärning ska vara 10 eller färre.");
        }
        else
        {
            this._tempRound = new Round(noOfDice);
            this._topList = new (int, string, int, int)[20];
            this._tempName = (noOfDice, name);
        }
        Reset();
    }

    public void Roll()
    {
        this._tempRound.Roll();
        this._tempRound.PrintRound();
        Console.WriteLine($"Rundan är värd {this._tempRound.GetPoints()} poäng.");
        if (this._tempRound.GetPoints() == 0) // automatiskt ny runda om 1:a
        {
            Stop();
        }
    }

    public void Stop()
    {
        this._tempPoint += this._tempRound.GetPoints();
        this._tempRound.SetPoints(0);
        this._noOfRounds++;
        if (this._tempPoint < Game.TargetPoint)
        {
            PresentRoundInfo();
        }
        else
        {
            PresentWinner();
            SaveTopList();
            Reset();
        }
    }

    private void PresentRoundInfo()
    {
        Console.WriteLine("\nRundan är avslutad - du har:");
        Console.WriteLine($"Poäng: {this._tempPoint}");
        Console.WriteLine($"Antal rundor: {this._noOfRounds}");
    }

    private void PresentWinner()
    {
        Console.Clear();
        Console.WriteLine("Dice100");
        Console.WriteLine($"\nDu har vunnit! Grattis {this._tempName.Item2}!");
        Console.WriteLine($"Poäng: {this._tempPoint}");
        Console.WriteLine($"Antal rundor: {this._noOfRounds}");
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
        this._tempPoint = 0;
        this._noOfRounds = 0;
    }

    private void SaveTopList()
    {
        string[] lineToAdd = { string.Concat(this._tempName.Item1, ", ", this._tempName.Item2, ", ", this._tempPoint, ", ", this._noOfRounds) };

        FileHandler.SaveToFile(Game.TopListFile, lineToAdd);
    }

    public static void PrintTopList()
    {
        string[] topList = FileHandler.ReadFromFile(Game.TopListFile);
        string[] headers = { "Antal rundor", "Namn", "Antal tärningar", "Total poäng" };

        Array.Sort(topList, (x, y) => GetNoOfRounds(x).CompareTo(GetNoOfRounds(y)));
        Console.WriteLine("\nTopplistan för Dice100");
        Console.WriteLine($"{headers[0],-10}  {headers[1],-20} {headers[2],-10} {headers[3],-10}");
        foreach (string line in topList)
        {
            string[] parts = line.Split(new string[] { ", " }, StringSplitOptions.None);
            Console.WriteLine($"     {parts[3],-8} {parts[1],-20}        {parts[0],-10}   {parts[2],-10}");
        }
    }

    private static int GetNoOfRounds(string line)
    {
        string[] parts = line.Split(new string[] { ", " }, StringSplitOptions.None);

        return int.Parse(parts[3]);
    }
}
