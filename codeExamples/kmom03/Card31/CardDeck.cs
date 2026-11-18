public class CardDeck
{
    public static readonly string[] suits = {"Hjärter", "Klöver", "Ruter", "Spader"};
    public static readonly string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Knekt", "Dam", "Kung", "Ess" };

    private const int NUMBER_OF_CARDS = 52;
    private Card[] _deck;
    private int _currentCard;

    public CardDeck()
    {
        this._deck = new Card[NUMBER_OF_CARDS];
        this._currentCard = 0;
        this.CreateCards();
    }

    public int GetNumberOfCardsLeft()
    {
        return NUMBER_OF_CARDS - this._currentCard;
    }

    public bool HasCardsLeft()
    {
        return this._currentCard == NUMBER_OF_CARDS;
    }

    private void CreateCards()
    {
        int counter = 0; // 0-51 index i this._deck

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                this._deck[counter] = new Card(suit, rank);
                if ( rank == "Ess")
                {
                    this._deck[counter].SetValue(11);
                }
                else if (rank == "Knekt" || rank == "Dam" ||rank == "Kung")
                {
                    this._deck[counter].SetValue(10);
                }
                else
                {
                    this._deck[counter].SetValue(int.Parse(rank));
                }
                counter++;
            }
        }
    }

    public void Shuffle()
    {
        Random rand = new Random();
        for (int i=0; i< NUMBER_OF_CARDS; i++)
        {
            int index1 = rand.Next(this._currentCard, NUMBER_OF_CARDS);
            int index2 = rand.Next(this._currentCard, NUMBER_OF_CARDS);
            
            Card temp = this._deck[index1];
            this._deck[index1] = this._deck[index2];
            this._deck[index2] = temp;
        }
    }

    public Card GetCard()
    {
        return this._deck[this._currentCard++];
    }

    public void ResetDeck()
    {
        this.CreateCards();
        this._currentCard = 0;
    }
}
