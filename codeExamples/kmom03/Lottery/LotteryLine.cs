namespace Lottery;
public class LotteryLine
{
    #region Attribut
    public const int MAX_NUMBER = 35;
    public const int MIN_NUMBER = 1;
    public const int NR_TO_MARK = 7;
    private bool[] _line;
    private int _nrOfMarkedNrs;
    #endregion

    public LotteryLine()
    {
        this._line = new bool[MAX_NUMBER + 1]; // alla blir false
        this._nrOfMarkedNrs = 0;
    }
    public bool MarkNr(int nr)
    {
        if (this.IsFullyMarked())
        {
            return false;
        }
        if (nr < MIN_NUMBER || nr > MAX_NUMBER)
        {
            return false; // early return
        }

        bool didMark = false;
        if (!this._line[nr])
        {
            this._line[nr] = true;
            this._nrOfMarkedNrs++;
            didMark = true;
        }
        return didMark;
    }
    public int GetNrOfMarkedNumbers()
    {
        return this._nrOfMarkedNrs;
    }
    public bool IsFullyMarked()
    {
        return this._nrOfMarkedNrs == NR_TO_MARK;
    }
    public string MarkedNrsAsString()
    {
        string strNrs = "";
        for (int nr = 1; nr <= MAX_NUMBER; nr++)
        {
            if (this._line[nr])
                strNrs += nr.ToString() + ", ";
                
        }
        return strNrs.TrimEnd(',', ' ');
    }
    public int NrOfCorrect(LotteryLine correctLotteryLine)
    {
        int nrOfCorrect = 0;
        int nr = 1; 
        foreach (bool mark in this._line)
        {
            if (mark && correctLotteryLine._line[nr])
            {
                nrOfCorrect++;
            }
            nr++;
        }       
        return nrOfCorrect;
    }

    public void GenerateRandom()
    {
        // To continue on
        NumberGenerator numgen = new NumberGenerator(LotteryLine.MIN_NUMBER, LotteryLine.MAX_NUMBER);
        // iterera så att det blir 7 olika nummer som markeras
        while (!this.IsFullyMarked())
        {
            numgen.GenerateNumber();
            int nr = numgen.GetCurrentNumber();
            this.MarkNr(nr); // kolla så att det blir markerat
            // ....
        }
    }

}

