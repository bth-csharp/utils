/* Card card1 = new Card("Hjärter", "Kung", 10);

Console.WriteLine($"Card 1: {card1.GetDescription()} has value {card1.GetValue()}");

Card card2 = new Card("Hjärter", "Kung");
card2.SetValue(100);
Console.WriteLine($"Card 2: {card2.GetDescription()} has value {card2.GetValue()}");
 */

CardDeck cardDeck = new CardDeck();
Console.WriteLine($"Deck of card has {cardDeck.GetNumberOfCardsLeft()} left");

cardDeck.Shuffle();

List<Card> hand1 = [ cardDeck.GetCard(), cardDeck.GetCard(), cardDeck.GetCard()];
Console.WriteLine($"Deck of card has {cardDeck.GetNumberOfCardsLeft()} left");

int sum = 0;
foreach (var card in hand1)
{
    sum += card.GetValue();
    Console.WriteLine(card.GetDescription());
}
Console.WriteLine($"Hand 1: {sum} in total");

// add loop and choose card to remove
