namespace OoGuide.src;

class RaceTrack
{
    private const string NAME = "DBWEBB Racing track";
    private const int MINIMUM_FINISH = 20;
    private int _finishLine;

    public RaceTrack(int finishLine)
    {
        this._finishLine = finishLine;
        if (finishLine < RaceTrack.MINIMUM_FINISH) 
        {
            this._finishLine = RaceTrack.MINIMUM_FINISH;
        }
    }

    // Other methods
    public void PrintFinishLine()
    {
        string spaces = new string(' ', this._finishLine);
        Console.WriteLine(string.Concat("\nSTART", spaces.AsSpan(0, spaces.Length - 6), "MÅL"));
        Console.WriteLine(spaces + "|");
    }
}