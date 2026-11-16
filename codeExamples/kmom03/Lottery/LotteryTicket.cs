namespace Lottery;
public class LotteryTicket
{
    #region Attribut
    public const int NR_OF_LINES = 10;  
    private int _currentLineNr;
    private LotteryLine[] _lines;
    #endregion 
    public LotteryTicket() 
    {
        this._currentLineNr = 0;
        this._lines = new LotteryLine[NR_OF_LINES]; 
        for (int i=0; i<NR_OF_LINES; i++)
        {
            this._lines[i] = new LotteryLine();
        }
    }
    public int GetCurrentLineNr()
    {
        return this._currentLineNr;
    }
    public bool MarkNumberOnCurrentLine(int nr)
    {
        bool didMark = false;
        if (!this._lines[this._currentLineNr].IsFullyMarked())
        {
            this._lines[this._currentLineNr].MarkNr(nr);
            didMark = true;
        }
        return didMark;
    }
    public bool NextLine()
    {
        if (this._currentLineNr >= NR_OF_LINES)
            return false; //early return
        bool ok = false;
        if (this._lines[this._currentLineNr].IsFullyMarked())
        {
            this._currentLineNr++;
            ok = true;
        }
        return ok;
    }
    public string[] GetLotteryLinesAsStrings()
    {
        string[] linesAsStrings = new string[this._currentLineNr+1];
        
        for (int i = 0; i <= this._currentLineNr; i++)
        {
            linesAsStrings[i] = this._lines[i].MarkedNrsAsString();
        }
        return linesAsStrings;
    }
    public int CalculateNrOfCorrect(int lineNr, LotteryLine correctLine)
    {
        return this._lines[lineNr].NrOfCorrect(correctLine);
    }
    public int[] NrOfCorrectAllUsedLines(LotteryLine correctLine)
    {
        int[] results  = new int[this._currentLineNr];
        for (int i=0; i<this._currentLineNr; i++)
        {
            results[i] = this.CalculateNrOfCorrect(i, correctLine);
        }
        return results;
    }
}
